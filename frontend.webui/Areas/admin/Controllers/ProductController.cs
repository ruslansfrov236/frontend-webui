using frontend.business.Abstrations;
using frontend.business.Application.Dtos.Product;
using frontend.entity;
using Microsoft.AspNetCore.Mvc;

namespace frontend.webui.Areas.admin.Controllers
{

    [Area("admin")]
    public class ProductController : Controller
    {
        readonly private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {

            List<Product> products = await _productService.GetAll();

            return View(products);
        }

        public async Task<IActionResult> Details(string id)
        {
            var products = await _productService.GetById(id);
            if (products == null) return NotFound();
            return View(products);

        }
        [HttpGet]
        public async Task<IActionResult> Create()
        => View();
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto model)
        {


            await _productService.Create(model);

            return RedirectToAction(nameof(Index));
        }
    
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {


            var datas = await _productService.GetById(id);
            UpdateProductDto updateProductDto = new UpdateProductDto()
            {
                Text=datas.Text,
                Title=datas.Title,
                FilePath=datas.FilePath,    

            };

            if (datas == null) return NotFound();
            if (!ModelState.IsValid) return View(datas);

            return View(updateProductDto);


        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductDto model)
        {
            var product = await _productService.GetAll();
            bool isReplayValue = product.Any(pr => pr.Title.ToLower().Trim() == model.Title.ToLower().Trim() && pr.Id != Guid.Parse(model.Id));

            if (isReplayValue)
            {
                ModelState.AddModelError("Title", "Tekrarlanan deyer");
                return View(model);
            }
            await _productService.Update(model);
            return RedirectToAction(nameof(Index));

        }

        [HttpPost]

        public async Task<IActionResult> Delete(string id)
        {
            await _productService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
