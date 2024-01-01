using frontend.business.Abstrations;
using frontend.business.Application.Dtos.AboutHeader;
using frontend.entity;
using Microsoft.AspNetCore.Mvc;
namespace frontend.webui.Areas.admin.Controllers
{
    [Area("admin")]
    public class AboutHeaderController : Controller
    {
        readonly private IAboutHeaderService _aboutHeaderService;
        public AboutHeaderController(IAboutHeaderService aboutHeaderService)
        {
            _aboutHeaderService = aboutHeaderService;
        }
        public async Task<IActionResult> Index()
        {
            List<AboutHeader> aboutHeaders=  await _aboutHeaderService.GetAll();
            
            return View(aboutHeaders);
        }
        public async Task<IActionResult> Details (string id)
        {
            var datas= await _aboutHeaderService.GetById(id);
            if (datas == null) return NotFound();

            return View(datas);  
        }

        public async Task<IActionResult> Create()
         => View();
        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutHeaderDto model)
        {
            if (!ModelState.IsValid) return View(model);
            await  _aboutHeaderService.Create(model);
            return RedirectToAction(nameof(Index));   
        }
        public async Task<IActionResult> Update (string id)
        {
            var datas = await _aboutHeaderService.GetById(id);
            if (datas == null) return NotFound();

            return View(datas);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateAboutHeaderDto model)
        {
            if (!ModelState.IsValid) return View(model);
            var datas = await _aboutHeaderService.GetAll();
            bool isReplayValue = datas.Any(pr => pr.Title.ToLower().Trim() == model.Title.ToLower().Trim() && pr.Id != Guid.Parse(model.Id) && pr.Id!=Guid.Parse(model.Id));

            if (isReplayValue)
            {
                ModelState.AddModelError("Title", "Tekrarlanan deyer");
                return View(model);
            }
            await _aboutHeaderService.Update(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete (string id)
        {
            await _aboutHeaderService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
