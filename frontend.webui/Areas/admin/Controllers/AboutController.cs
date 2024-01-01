using frontend.business.Abstrations;
using frontend.business.Application.Dtos.About;
using frontend.entity;
using Microsoft.AspNetCore.Mvc;

namespace frontend.webui.Areas.admin.Controllers
{
    [Area("admin")]
    public class AboutController : Controller
    {
        readonly private IAboutService _aAboutService;
        public AboutController(IAboutService aboutService)
        {
            _aAboutService = aboutService;
        }
        public async Task<IActionResult> Index()
        {

            List<About> abouts = await _aAboutService.GetAll();
            if (abouts == null) return RedirectToAction(nameof(Create));
            return View(abouts);
        }

        public async Task<IActionResult> Details(string id)
        {
            var datas = _aAboutService.GetById(id);

            if (datas == null) return NotFound();

            return View(datas);


        }

        public async Task<IActionResult> Create()
        => View();
        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutDto model)
        {
              await  _aAboutService.Create(model);

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Update (string id)
        {

            var datas = await _aAboutService.GetById(id);
            if(datas == null) return NotFound();
         
            return View(datas);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateAboutDto model)
        {
            if (!ModelState.IsValid) return View(model);
           var datas=  await _aAboutService.GetAll();
            bool isReplayValue = datas.Any(pr => pr.Title.ToLower().Trim() == model.Title.ToLower().Trim() && pr.Id != Guid.Parse(model.Id));

            if (isReplayValue)
            {
                ModelState.AddModelError("Title", "Tekrarlanan deyer");
                return View(model);
            }
            await _aAboutService.Update(model);

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {

            await _aAboutService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
