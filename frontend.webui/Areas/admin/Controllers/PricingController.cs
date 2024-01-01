using frontend.business.Abstract;
using frontend.business.Application.Dtos.Feauters;
using frontend.business.Application.Dtos.Pricing;
using Microsoft.AspNetCore.Mvc;

namespace frontend.webui.Areas.admin.Controllers
{
    [Area("admin")]
    public class PricingController : Controller
    {
        readonly private IPricingService _pricingService;

        public PricingController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }
        public async Task<IActionResult> Index()
        {
            var pricing = await _pricingService.GetAll();
            return View(pricing);
        }

        public async Task<IActionResult> Details(string id)
        {
            var pricing = await _pricingService.GetById(id);
            if (pricing == null) return NotFound();

            return View(pricing);
        }

        public async Task<IActionResult> Create()
        => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreatePricingDto model)
        {
            if (!ModelState.IsValid) return View(model);

            await _pricingService.Create(model);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(string id)
        {
            var pricing = await _pricingService.GetById(id);
            if(pricing == null) return NotFound();      
            return View(pricing);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdatePricingDto model)
        {
            if (!ModelState.IsValid) return View(model);
            await _pricingService.Update(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var pricing = await _pricingService.GetById(id);
            if(pricing==null) return NotFound();
            await _pricingService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
