using System.Collections.Generic;
using AutoMapper;
using BigSave.Service.Interfaces;
using BigSave.Web.Models.DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace BigSave.Web.ViewComponents
{
    public class FlyerCategoryViewComponent : ViewComponent
    {
        private readonly IFlyerCategoryRepository _flyerCategoryRepository;
        private readonly IMapper _mapper;

        public FlyerCategoryViewComponent(IFlyerCategoryRepository flyerCategoryRepository, IMapper mapper)
        {
            _flyerCategoryRepository = flyerCategoryRepository;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var flyerCategories = _flyerCategoryRepository.GetAll().OrderBy(f =>f.Name).ToList();
            var mapped = _mapper.Map<List<FlyerCategoryViewModel>>(flyerCategories);
            return View(mapped);
        }
    }
}