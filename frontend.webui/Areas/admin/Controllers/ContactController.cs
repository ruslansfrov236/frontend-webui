using frontend.business.Abstrations;
using frontend.business.Application.Dtos.Contact;
using frontend.data.Abstract;
using frontend.entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace frontend.webui.Areas.admin.Controllers
{
    [Area("admin")]
    public class ContactController : Controller
    {
        readonly private IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public async Task<IActionResult> Index()
        {
            List<Contact> contacts = await _contactService.GetAll();


            return View(contacts);
        }

        public async Task<IActionResult> Details(string id)
        {

            var contact = await _contactService.GetById(id);
            if (contact == null) return NotFound();

            return View(contact);
        }

        public async Task<IActionResult> Create()
         => View();
        [HttpPost]
        public async Task<IActionResult> Create(CreateContactDto model)
        {
            if (!ModelState.IsValid) return NotFound();
            await _contactService.Create(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(string id)
        {
            var contact = _contactService.GetById(id);

            if (contact == null) return BadRequest();

            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateContactDto model)
        {
            var contact = await _contactService.GetAll();
            if (!ModelState.IsValid) return View(model);
            bool isReplayValue = contact.Any(c => c.FullName.ToLower().Trim() == model.FullName.ToLower().Trim() && c.TitleWork.ToLower().Trim() == model.TitleWork.ToLower().Trim() && c.Id != Guid.Parse(model.Id));


            if (isReplayValue)
            {
                ModelState.AddModelError("FullName", "Melumat tekrarlanir");
                ModelState.AddModelError("TitleWork", "Melumat tekrarlanir");
            }

            await _contactService.Update(model);

            return RedirectToAction(nameof(Index));

        }
    }
}

