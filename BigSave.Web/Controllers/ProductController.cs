using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using AutoMapper;
using BigSave.Core.Entities;
using BigSave.Service.Interfaces;
using BigSave.Web.Helper;
using BigSave.Web.Models.DataModel;
using Microsoft.AspNetCore.Mvc;


namespace MyFlyer.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IMerchantRepository merchantRepository, ICategoryRepository categoryRepository, IProductRepository productRepository, IMapper mapper)
        {
            _merchantRepository = merchantRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IActionResult Index(int? merchantId, int? categoryId, int? page, string search = null, string orderBy = null, int pageSize = 36)
        {
            var merchants = new List<Merchant>();
            var categories = new List<Category>();
            var products = new List<Product>();

            if (search != null)
            {
                search = search.ToLower();
                merchants = _merchantRepository.GetAll();
                products = _productRepository.GetByCondition(p => p.Name.ToLower().Contains(search) || p.Description.ToLower().Contains(search));
            }
            else
            {
                if (!merchantId.HasValue && !categoryId.HasValue)
                {
                    products = _productRepository.GetAll().OrderBy(p => p.CurrentPrice).ToList();
                    foreach (var product in products)
                    {
                        product.Merchant = _merchantRepository.GetById(product.MerchantId);
                    }

                }

                else if (merchantId.HasValue && (!categoryId.HasValue))
                {
                    products = _productRepository.GetProductInMerchant(merchantId.Value);
                }
                else if (merchantId.HasValue && categoryId.HasValue)
                {
                    products = _productRepository.GetProductInCategory(categoryId.Value);
                }
            }


            var productsView = _mapper.Map<List<ProductViewModel>>(products);
            var pages = PagingList<ProductViewModel>.Create(productsView, page ?? 1, pageSize);

            return View(pages);
        }
        public IActionResult Detail(int productId)
        {
            var product = _productRepository.GetById(productId);
            if (product != null)
            {
                var mapped = _mapper.Map<ProductViewModel>(product);
                return View(mapped);
            }
            return RedirectToAction("Index", "PageNotFound");
        }
        public IActionResult Wishlist()
        {
            return View();
        }
        public IActionResult Compare()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
    }
}