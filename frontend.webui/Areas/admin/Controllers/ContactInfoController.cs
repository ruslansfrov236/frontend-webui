using frontend.business.Abstrations;
using frontend.business.Application.Dtos.ContactInfo;
using Microsoft.AspNetCore.Mvc;

namespace frontend.webui.Areas.admin.Controllers
{
    [Area("admin")]
    public class ContactInfoController : Controller
    {
        private readonly IContactInfoService _contactInfoService;

        public ContactInfoController(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }
        public async Task<IActionResult> Index()
        {
            var contactInfo = await _contactInfoService.GetAll();

            return View(contactInfo);
        }
       
        public async Task<IActionResult> Details(string id)
        {
            var contactInfo = await _contactInfoService.GetById(id);
            if (contactInfo == null) return NotFound();

            return View(contactInfo);
        }

        public async Task<IActionResult> Create()
       => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateContactInfoDto model)
        {

          await   _contactInfoService.Create(model);
            return RedirectToAction(nameof(Index)); 
        }

        public async Task<IActionResult> Update(string id)
        {
            var contactInfo = await _contactInfoService.GetById(id);
            if(contactInfo==null) return NotFound();    

            return View(contactInfo);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateContactInfoDto model)
        {
            var contactInfo = await _contactInfoService.GetAll();
            if (!ModelState.IsValid) return View(model);
            bool isReplayValue = contactInfo.Any(ci => ci.Title.ToLower().Trim() == model.Title.ToLower().Trim() && ci.Id != Guid.Parse(model.id));
            await _contactInfoService.Update(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
