using frontend.business.Abstrations;
using frontend.business.Application.Dtos.ContactHeader;
using Microsoft.AspNetCore.Mvc;

namespace frontend.webui.Areas.admin.Controllers
{
    [Area("admin")]
    public class ContactHeaderController : Controller
    {
        private readonly IContactHeaderService _contactHeaderService;

        public ContactHeaderController(IContactHeaderService contactHeaderService)
        {
            _contactHeaderService = contactHeaderService;
        }
        public async Task<IActionResult> Index()
        {

            var contactHeader = await _contactHeaderService.GetAll();

            return View(contactHeader);
        }

        public async Task<IActionResult> Details(string id)
        {
            var contactHeader = await _contactHeaderService.GetById(id);

            if (contactHeader == null) return NotFound();

            return View(contactHeader); 
        }

        public async Task<IActionResult> Create()
        => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateContactHeaderDto model)
        {
            if (!ModelState.IsValid) return View(model);
            await _contactHeaderService.Create(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(string id)
        {
            var contactHeader = await _contactHeaderService.GetById(id);

            if(contactHeader == null) return NotFound();


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateContactHeaderDto model)
        {

            if(!ModelState.IsValid) return View(model);
            var contactHeader = await _contactHeaderService.GetAll();
            bool isReplayValue = contactHeader.Any(ch=>ch.Title.ToLower().Trim()==model.Title.ToLower().Trim() && ch.Id!=Guid.Parse(model.id));
            if (isReplayValue)
            {
                ModelState.AddModelError("Title", "tekrarlanan alan ");
            }
            await _contactHeaderService.Update(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete (string id)
        {
            var contactHeader = _contactHeaderService.GetById(id);

            if(contactHeader==null) return NotFound();

            await _contactHeaderService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
