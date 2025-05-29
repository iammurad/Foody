using AutoMapper;
using Foody.BusinessLayer.Abstract;
using Foody.DtoLayer.Dtos.AboutDtos;
using Foody.DtoLayer.Dtos.SliderDtos;
using Foody.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Foody.PresentationLayer.Controllers
{
    public class AboutController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService _aboutService, IMapper _mapper)
        {
            this._aboutService = _aboutService;
            this._mapper = _mapper;
        }

        public IActionResult AboutList()
        {
            var values = _aboutService.TGetAll();
            return View(_mapper.Map<List<ResultAboutDto>>(values));
        }
        public IActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            var value = _mapper.Map<About>(createAboutDto);
            _aboutService.TInsert(value);
            return RedirectToAction("AboutList");
        }
        public IActionResult DeleteAbout(int id)
        {
            _aboutService.TDelete(id);
            return RedirectToAction("AboutList");
        }

        public IActionResult UpdateAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            return View(_mapper.Map<GetByIdAboutDto>(value));
        }

        [HttpPost]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var value = _mapper.Map<About>(updateAboutDto);
            _aboutService.TUpdate(value);
            return RedirectToAction("AboutList");
        }
    }
}
