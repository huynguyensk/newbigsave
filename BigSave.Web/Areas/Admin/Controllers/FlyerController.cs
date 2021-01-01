using System;
using BigSave.Core.Entities;
using BigSave.Service.Interfaces;
using BigSave.Service.DataCrawl;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;
using BigSave.Web.Models.DataModel;
using System.Dynamic;

namespace BigSave.Web.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class FlyerController : Controller
    {
        private readonly IFlyerRepository _flyerRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryReposity;
        private readonly IMerchantRepository _merchantRepository;
        private readonly IFlyerCategoryRepository _flyerCategoryRepository;
        private readonly IMapper _mapper;

        public FlyerController(IFlyerRepository flyerRepository, IProductRepository productRepository, ICategoryRepository categoryReposity, IMerchantRepository merchantRepository, IFlyerCategoryRepository flyerCategoryRepository, IMapper mapper)
        {
            _flyerRepository = flyerRepository;
            _productRepository = productRepository;
            _categoryReposity = categoryReposity;
            _merchantRepository = merchantRepository;
            _flyerCategoryRepository = flyerCategoryRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var flyers = _flyerRepository.GetAll();
            var mapped = _mapper.Map<List<FlyerViewModel>>(flyers);
            return View(mapped);
        }
        public IActionResult Create()
        {
            var flyerCategories = _flyerCategoryRepository.GetAll().OrderBy(f => f.Name);
            var flyers = _flyerRepository.GetAll();
            var flyerCategoryViewModels = _mapper.Map<List<FlyerCategoryViewModel>>(flyerCategories);
            var flyerViewModel = _mapper.Map<List<FlyerViewModel>>(flyers);
            dynamic model = new ExpandoObject();
            model.fCate = flyerCategoryViewModels;
            model.flyers = flyerViewModel;
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(string flyerCategory)
        {
            var flyerCate = _flyerCategoryRepository.GetByCondition(c => c.Name == flyerCategory).FirstOrDefault();
            var linkFlyers = Helper.FlyerLink.GetLink(flyerCategory);
            foreach (var link in linkFlyers)
            {
                var flyer = new Flyer
                {
                    Url = link,
                    FlyerCategory = flyerCate,
                    IsActive = true
                };
                if (!_flyerRepository.IsExist(f => f.Url == link))
                {
                    _flyerRepository.Add(flyer);
                }
            }
            return RedirectToAction("Index");
        }



        [Obsolete]
        public ActionResult Import(int id)
        {
            var flyer = _flyerRepository.GetById(id);
            if (flyer.IsActive)
            {
                var crawlObject = Crawl.GetData(flyer.Url);
                flyer.Valid_from = crawlObject.valid_from;
                flyer.Valid_to = crawlObject.valid_to;
                Merchant merchant = null;
                var merchantName = crawlObject.merchant;
                if (!_merchantRepository.IsExist(m => m.Name == merchantName))
                {
                    merchant = new Merchant
                    {
                        Name = merchantName,
                        Url = crawlObject.merchant_url,
                        LogoFile = crawlObject.merchant_logo,
                        Flyers = new List<Flyer> { flyer }
                    };
                    _merchantRepository.Add(merchant);
                }
                else
                {
                    merchant = _merchantRepository.GetByCondition(m => m.Name == merchantName).FirstOrDefault();
                    merchant.Flyers.Add(flyer);
                }
                flyer.Merchant = merchant;
                foreach (var crawlcate in crawlObject.categories)
                {
                    var category = new Category();
                    category.Name = crawlcate.name;

                    if (!_categoryReposity.IsExist(c => c.Name == category.Name))
                    {
                        _categoryReposity.Add(category);
                    }
                    else
                    {
                        category = _categoryReposity.GetByCondition(c => c.Name == category.Name).FirstOrDefault();
                    }
                    if (!merchant.Categories.Contains(category))
                    {
                        merchant.Categories.Add(category);
                    }
                }

                foreach (var item in crawlObject.items)
                {
                    if ((item.current_price != null || item.sale_story != null) && item.category_names.Count > 0)
                    {
                        var pcate = item.category_names[0];
                        var pCate = _categoryReposity.GetByCondition(c => c.Name.Contains(pcate)).FirstOrDefault();
                        if (pCate == null)
                        {
                            pCate = new Category
                            {
                                Name = pcate
                            };
                            _categoryReposity.Add(pCate);
                        }
                        var product = new Product
                        {
                            Name = item.name,
                            CurrentPrice = Convert.ToDecimal(item.current_price),
                            Brand = item.brand,
                            Description = item.description,
                            Discount_percent = item.discount_percent.ToString(),
                            DisplayName = item.display_name,
                            Dist_coupon_image_url = item.dist_coupon_image_url,
                            Image = item.large_image_url,
                            Url = item.url,
                            InStoreOnly = item.in_store_only,
                            X_large_image_url = item.x_large_image_url,
                            Sale_Story = item.sale_story,
                            Flyer = flyer,
                            Valid_from = DateTime.Parse(item.valid_from),
                            Valid_to = DateTime.Parse(item.valid_to),
                            Category = pCate
                        };
                        _productRepository.Add(product);
                        pCate.Products.Add(product);
                        _categoryReposity.Update(pCate);
                        merchant.Products.Add(product);
                        if (!merchant.Categories.Contains(pCate))
                        {
                            merchant.Categories.Add(pCate);
                        }
                        flyer.Products.Add(product);
                    }
                }
                flyer.IsActive = false;
                _merchantRepository.Update(merchant);
                _flyerRepository.Update(flyer);
            }
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var flyer = _flyerRepository.GetById(id);
            var products = _productRepository.GetByCondition(p => p.Flyer.Id == id);
            foreach (var prodcut in products)
            {
                _productRepository.Delete(prodcut.Id);
            }
            var merchant = _merchantRepository.GetByCondition(m => m.Flyers.Contains(flyer)).FirstOrDefault();
            if (merchant != null)
            {
                var productInMerchant = _productRepository.GetProductInMerchant(merchant.Id);
                if (productInMerchant.Count == 0)
                {
                    var categories = _categoryReposity.GetCategoryByMerchant(merchant);
                    foreach (var category in categories)
                    {
                        _categoryReposity.Delete(category.Id);
                    }
                    _merchantRepository.Delete(merchant.Id);
                }
            }
            _flyerRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}