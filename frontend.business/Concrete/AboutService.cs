using frontend.business.Abstrations;
using frontend.business.Application.Dtos.About;
using frontend.data.Abstract;
using frontend.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.business.Concrete
{
    public class AboutService : IAboutService
    {

        readonly private IAboutReadRepository _aboutReadRepository;
        readonly private IAboutWriteRepository _aboutWriteRepository;
        readonly private IFileService _fileService;

        public AboutService(IAboutReadRepository aboutReadRepository, IAboutWriteRepository aboutWriteRepository, IFileService fileService)
        {
            _aboutReadRepository = aboutReadRepository;
            _aboutWriteRepository = aboutWriteRepository;
            _fileService = fileService;
        }
        public async Task<bool> Create(CreateAboutDto model)
        {
            if (!_fileService.CheckSize(model.File, 80)) return false;
            if (!_fileService.IsImage(model.File)) return false;

            var newFile = await _fileService.UploadAsync(model.File);
            About about = new About()
            {
                Title= model.Title, 
                Description= model.Description,
                FilePath = newFile,

            };

         await _aboutWriteRepository.AddAsync(about);
        await _aboutWriteRepository.SaveAsync();    

            return true;
        }

        public async Task<bool> Delete(string id)
        {
            var about = await _aboutReadRepository.GetByIdAsync(id);
            if (about == null) return false;
            _aboutWriteRepository.Remove(about);
            await _aboutWriteRepository.SaveAsync();

            return true;
        }

        public async Task<List<About>> GetAll()
        {
            List<About> about = await _aboutReadRepository.GetAll().ToListAsync();

            return about;

        }

        public async Task<About> GetById(string id)
        => await _aboutReadRepository.GetByIdAsync(id);

        public async Task<bool> Update(UpdateAboutDto model)
        {
           var about = await _aboutReadRepository.GetByIdAsync(model.Id);

            if (about == null) return false;    
           if( !_fileService.CheckSize(model.File, 80)) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\img\\", model.FilePath);
             _fileService.Delete(path);
           var newFile= await _fileService.UploadAsync(model.File);

            about.Title = model.Title;
            about.Description = model.Description;
            about.FilePath = newFile;
            _aboutWriteRepository.Update(about);
            await _aboutWriteRepository.SaveAsync();
            return true;
        }
    }
}
