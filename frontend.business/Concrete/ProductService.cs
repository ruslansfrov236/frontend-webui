using frontend.business.Abstrations;
using frontend.business.Application.Dtos.Product;
using frontend.data.Abstract;
using frontend.entity;
using Microsoft.EntityFrameworkCore;



namespace frontend.business.Concrete
{
    public class ProductService : IProductService
    {

        readonly private IProductReadRepository _productReadRepository;
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IFileService _fileService;

        public ProductService(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository ,IFileService fileService)
        {

            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _fileService= fileService;
        }
        public async Task<bool> Create(CreateProductDto model)
        {
            if (model == null ) return false;

            if(model.File==null) return false;
            _fileService.IsImage(model.File);
            _fileService.CheckSize(model.File, 250);
            var newFile = await _fileService.UploadAsync(model.File);
            if (newFile == null) return false;

            Product product = new Product()
            {
                Title = model.Title,
                Text = model.Text,
                FilePath = newFile,
            };

            await _productWriteRepository.AddAsync(product);
            await _productWriteRepository.SaveAsync();

            return true;
        }

        public async Task<bool> Delete(string id)
        {
            var product = await _productReadRepository.GetByIdAsync(id);
            if(product==null) return (false);
            _fileService.Delete(product.FilePath);
               _productWriteRepository.Remove(product);
            await _productWriteRepository.SaveAsync();

            return true;
        }
        
        public async Task<List<Product>> GetAll()
        {
            List<Product> product = await _productReadRepository.GetAll().ToListAsync();
            if (product == null)
            {
                return null;
            }

            return product;
        }

        public async  Task<Product> GetById(string id)
       => await _productReadRepository.GetByIdAsync(id);

        public async Task<bool> Update(UpdateProductDto model)
        {
        
            var product = await _productReadRepository.GetByIdAsync(model.Id);
         
            // Check file using _fileService
            if (!_fileService.IsImage(model.File))
            {
                return false; 
            }

          
            if (!_fileService.CheckSize(model.File, 60))
            {
                return false; 
            }

            var photoName = await  _fileService.UploadAsync(model.File);

        
            if (product == null)
            {
                return true;
            }

           
            product.Text = model.Text;
            product.Title = model.Title;
            product.FilePath = photoName;

             _productWriteRepository.Update(product);   
            await _productWriteRepository.SaveAsync();

            return true;
        }



    }
}
