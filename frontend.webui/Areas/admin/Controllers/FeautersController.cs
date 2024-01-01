using frontend.business.Abstract;
using frontend.business.Application.Dtos.Feauters;
using frontend.entity;
using Microsoft.AspNetCore.Mvc;

namespace frontend.webui.Areas.admin.Controllers
{
    [Area("admin")]
    public class FeautersController : Controller
    {


        readonly private IFeautersService _feauterService;

        public FeautersController(IFeautersService feautersService)
        {
            _feauterService = feautersService;
        }

        public async Task<IActionResult> Index()
        {
            List<Feauters> feauters = await _feauterService.GetAll();


            return View(feauters);
        }
        public async Task<IActionResult> Details(string id)
        {
            var feauters = await _feauterService.GetById(id);

            return View(feauters);
        }

        public IActionResult Create()
        => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateFeautersDto model)
        {
            if (!ModelState.IsValid) return View(model);
            await _feauterService.Create(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(string id)
        {
            var featurers = await _feauterService.GetById(id);

            if (featurers == null) return NotFound();



            return View(featurers);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateFeautersDto model)
        {
            var feauters = await _feauterService.GetAll();

            bool isReplayValue = feauters.Any(fs => fs.Title.ToLower().Trim() == model.Title.ToLower().Trim() && fs.Id != Guid.Parse(model.id));

            if (isReplayValue)
            {
                ModelState.AddModelError("Title", "melumat tekrarlanir");
            }

            await _feauterService.Update(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var feauters = await _feauterService.GetById(id);
            if (feauters == null) return NotFound();

            await _feauterService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
