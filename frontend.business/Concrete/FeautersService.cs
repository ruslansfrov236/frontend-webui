using frontend.business.Abstract;
using frontend.business.Abstrations;
using frontend.business.Application.Dtos.Feauters;
using frontend.data.Abstract;
using frontend.entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.business.Concrete
{
    public class FeautersService : IFeautersService
    {
        readonly private IFeautersReadRepository _feautersReadRepository;
        readonly private IFeautersWriteRepository _feautersWriteRepository;
        readonly private IFileService _fileService;

        public FeautersService(IFeautersReadRepository feautersReadRepository, IFeautersWriteRepository feautersWriteRepository, IFileService fileService)
        {
            _feautersReadRepository = feautersReadRepository;
            _feautersWriteRepository = feautersWriteRepository;
            _fileService = fileService;

        }

        public async Task<bool> Create(CreateFeautersDto model)
        {

            var files = model.Files
                .Select(a => new Files
                {
                    PhotoPath = a.PhotoPath ,
                    FeaturedWorkComponentId = a.FeaturedWorkComponentId ,
                    file=a.file
                
                
                }).ToList();

            foreach (var file in files)
            {
                if (!_fileService.CheckSize(file.file, 80)) return false;
                if(! _fileService.IsImage(file.file)) return false; 
                var newFile =  await _fileService.UploadAsync(file.file);



            }
                                     
            Feauters feauters = new Feauters()
            {

                Title = model.Title,
                Description = model.Description,
                Files= files
            };

            await _feautersWriteRepository.AddAsync(feauters);
            await _feautersWriteRepository.SaveAsync();
            return true;
        }

        public async Task<bool> Delete(string id)
        {
            var feauters = await _feautersReadRepository.GetByIdAsync(id);
            foreach (var item in feauters.Files)
            {

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\asets\\img\\", item.PhotoPath);

                _fileService.Delete(path);
            };

            _feautersWriteRepository.Remove(feauters);
            await _feautersWriteRepository.SaveAsync();

            return true;
        }

        public async Task<List<Feauters>> GetAll()
        {
            List<Feauters> feauters = await _feautersReadRepository.GetAll()
                .Include(a => a.Files)
                .Select(ft => new Feauters()
                {
                    Id = ft.Id,
                    Title = ft.Title,
                    Description = ft.Description,
                    CreatedDate = ft.CreatedDate,
                    UpdatedDate = ft.UpdatedDate,
                    Files = ft.Files.Select(f => new Files() { Id = f.Id, PhotoPath = f.PhotoPath }).ToList()
                })
                .ToListAsync();

            return feauters;
        }


        public async Task<Feauters> GetById(string id)
        => await _feautersReadRepository.GetByIdAsync(id);

        public async Task<bool> Update(UpdateFeautersDto model)
        {
            var feauters = await _feautersReadRepository.GetByIdAsync(model.id);
            foreach (var item in feauters.Files)
            {

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\asets\\img\\", item.PhotoPath);

                _fileService.Delete(path);
            };
            foreach (var file in model.Files)
            {
                if (!_fileService.CheckSize(file.file, 80)) return false;
                if (!_fileService.IsImage(file.file)) return false;
                var newFile = await _fileService.UploadAsync(file.file);

                file.PhotoPath = newFile;
            };


            feauters.Title = model.Title;
            feauters.Description = model.Description;
            feauters.Files = model.Files;
            _feautersWriteRepository.Update(feauters);
            await _feautersWriteRepository.SaveAsync();
            return true;

        }
    }
}
