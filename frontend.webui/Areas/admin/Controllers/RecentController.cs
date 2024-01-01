using frontend.business.Abstract;
using frontend.business.Dtos.Recent;
using Microsoft.AspNetCore.Mvc;

namespace frontend.webui.Areas.admin.Controllers
{
    [Area("admin")]
    public class RecentController : Controller
    {
        private readonly IRecentService _recentService;

        public RecentController(IRecentService recentService)
        {
            _recentService = recentService;
        }
        public async Task<IActionResult> Index()
        {
            var recent = await _recentService.GetAll();

            return View(recent);
        }


        public async Task<IActionResult> Details(string id)
        {
            var recent = await _recentService.GetById(id);
                if (recent == null) return NotFound();

                return View(recent);
        }

        public async Task<IActionResult> Create()
         => View();
        [HttpPost]
        public async Task<IActionResult> Create(CreateRecentDto model)
        {
         if (!ModelState.IsValid) return View(model);
          await _recentService.Create(model);
          return   RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(string id)
        {
            var recent = await _recentService.GetById(id);
            if (recent == null) return NotFound();
            return View(recent);
        }

        [HttpPost]
        public async Task<IActionResult> Update (UpdateRecentDto model)
        {
            if (!ModelState.IsValid) return View(model);
            var recent = await _recentService.GetAll();
            bool isReplayValue= recent.Any(r=>r.Title.ToLower().Trim()==model.Title.ToLower().Trim() && r.Id!=Guid.Parse(model.Id));    
            if(isReplayValue)
            {
                ModelState.AddModelError("Title", "tekrarlanan melumat");
            }

            await _recentService.Update(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete (string id)
        {
            var recent = await _recentService.GetById(id);
            if (recent == null) return NotFound();
            await _recentService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
