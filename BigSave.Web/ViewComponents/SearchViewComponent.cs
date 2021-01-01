using System.Collections.Generic;
using AutoMapper;
using BigSave.Service.Interfaces;
using BigSave.Web.Models.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace BigSave.Data.ViewComponents
{
    public class SearchViewComponent : ViewComponent
    {
        private readonly IFlyerRepository _flyerRepository;
        private readonly IMapper _mapper;
        public SearchViewComponent(IFlyerRepository flyerRepository, IMapper mapper)
        {
            _flyerRepository = flyerRepository;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var flyers = _flyerRepository.GetAll();
            var mapped = _mapper.Map<List<FlyerViewModel>>(flyers);
            return View(mapped);
        }
    }
}