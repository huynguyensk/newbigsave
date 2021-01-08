using System.Collections.Generic;
using AutoMapper;
using BigSave.Core.Entities;
using BigSave.Service.Interfaces;
using BigSave.Web.Models.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace BigSave.Web.Areas.Admin.Controllers
{
    public class MerchantController : Controller
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IFlyerRepository _flyerRepository;
        private readonly IFlyerCategoryRepository _flyerCategoryRepository;
        private readonly IMapper _mapper;

        public MerchantController(IMerchantRepository merchantRepository, IMapper mapper)
        {
            _merchantRepository = merchantRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var merchants = _merchantRepository.GetAll();
            var mapped = _mapper.Map<List<MerchantViewModel>>(merchants);
            return View(mapped);
        }
        public IActionResult Edit(int merchantId)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(MerchantViewModel merchantView)
        {
            var merchant = _mapper.Map<Merchant>(merchantView);
            _merchantRepository.Update(merchant);
            if (merchant != null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int merchantId)
        {
            return View();
        }
    }
}