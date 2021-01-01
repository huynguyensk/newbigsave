using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BigSave.Service.Interfaces;
using BigSave.Web.Models.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace BigSave.Web.ViewComponents
{
    public class MerchantCategoriesViewComponent : ViewComponent
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public MerchantCategoriesViewComponent(IMerchantRepository merchantRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _merchantRepository = merchantRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var merchants = _merchantRepository.GetAll().OrderBy(m => m.Name);
            //var fmerchants = merchants.Where(m => m.Products.Count > 0);
            foreach (var merchant in merchants)
            {
                merchant.Categories = _categoryRepository.GetCategoryByMerchant(merchant); ;
                merchant.Categories.OrderBy(c => c.Name);
            }
            var mapped = _mapper.Map<List<MerchantViewModel>>(merchants);
            return View(mapped);
        }
    }
}