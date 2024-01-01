using frontend.business.Abstrations;
using frontend.business.Application.Dtos.AboutHeader;
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



    public class AboutHeaderService : IAboutHeaderService
    {
        readonly private IAboutHeaderReadRepository _aboutHeaderReadRepository;
        readonly private IAboutHeaderWriteRepository _aboutHeaderWriteRepository;
        readonly private IFileService _fileService;

        public AboutHeaderService(IAboutHeaderReadRepository aboutHeaderReadRepository, IAboutHeaderWriteRepository aboutHeaderWriteRepository, IFileService fileService)
        {
            _aboutHeaderReadRepository = aboutHeaderReadRepository;
            _aboutHeaderWriteRepository = aboutHeaderWriteRepository;
            _fileService = fileService;

        }
        public async Task<bool> Create(CreateAboutHeaderDto model)
        {
            if (model.File == null) return false;

            if (!_fileService.CheckSize(model.File, 80))
            {

                return false;
            }

            if (!_fileService.IsImage(model.File)) return false;

            var newFile = await _fileService.UploadAsync(model.File);
            AboutHeader aboutHeader = new AboutHeader()
            {
                Text = model.Text,
                Description = model.Description,
                Url = model.Url,
                UrlText = model.UrlText,
                FilePath = newFile


            };


            await _aboutHeaderWriteRepository.AddAsync(aboutHeader);
            await _aboutHeaderWriteRepository.SaveAsync();

            return true;
        }

        public async Task<bool> Delete(string id)
        {

            var aboutHeader = await _aboutHeaderReadRepository.GetByIdAsync(id);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/img", aboutHeader.FilePath);
            _fileService.Delete(path);

            await _aboutHeaderWriteRepository.RemoveAsync(id);
            await _aboutHeaderWriteRepository.SaveAsync(); 
            return true;
        }

        public async Task<List<AboutHeader>> GetAll()
        {
            List<AboutHeader> aboutHeaders = await _aboutHeaderReadRepository.GetAll().ToListAsync();

            return aboutHeaders;
        }

        public async Task<AboutHeader> GetById(string id)
       => await _aboutHeaderReadRepository.GetByIdAsync(id);

        public async  Task<bool> Update(UpdateAboutHeaderDto model)
        {
            var aboutHeader = await _aboutHeaderReadRepository.GetByIdAsync(model.Id);
           
            if (aboutHeader == null) return false;
        

            _fileService.Delete(aboutHeader.FilePath);
            if (!_fileService.CheckSize(model.File, 80)) return false;
            if(! _fileService.IsImage(model.File)) return false;
             var uploadFile= await  _fileService.UploadAsync(model.File);
            aboutHeader.Text=model.Description;
            aboutHeader.Description=model.Description;
            aboutHeader.Title=model.Title;
            aboutHeader.FilePath= uploadFile;

            _aboutHeaderWriteRepository.Update(aboutHeader);
            await _aboutHeaderWriteRepository.SaveAsync();
            return true;
        }
    }
}
