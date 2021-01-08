using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BigSave.Service.Interfaces;
using BigSave.Web.Models.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace BigSave.Web.ViewComponents
{
    public class MerchantCategoryViewComponent : ViewComponent
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public MerchantCategoryViewComponent(IMerchantRepository merchantRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _merchantRepository = merchantRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var merchants = _merchantRepository.GetAll().Where(m =>m.Products.Count >0).OrderBy(m =>m.Name).ToList();
            foreach (var merchant in merchants)
            {
               var categories = _categoryRepository.GetCategoryByMerchant(merchant);
            merchant.Categories = categories.Where(c => c.Products.Count > 0).OrderBy(c => c.Name).ToList();
            }           
            var mapped = _mapper.Map<List<MerchantViewModel>>(merchants);
            return View(mapped);
        }
    }
}