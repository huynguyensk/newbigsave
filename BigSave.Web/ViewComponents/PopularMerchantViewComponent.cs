using System.Collections.Generic;
using AutoMapper;
using BigSave.Service.Interfaces;
using BigSave.Web.Models.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace BigSave.Web.ViewComponents
{
    public class PopularMerchantViewComponent : ViewComponent
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly IMapper _mapper;

        public PopularMerchantViewComponent(IMerchantRepository merchantRepository, IMapper mapper)
        {
            _merchantRepository = merchantRepository;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var merchants = _merchantRepository.GetAll();
            var mapped = _mapper.Map<List<MerchantViewModel>>(merchants);
            return View(mapped);
        }
    }
}