using frontend.business.Abstract;
using frontend.business.Abstrations;
using frontend.business.Application.Dtos.Pricing;
using frontend.business.Dtos.Recent;
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
    public class RecentService : IRecentService
    {
        readonly private IRecentReadRepository _recentReadRepository;
        readonly private IRecentWriteRepository _recentWriteRepository;
        readonly private IFileService _fileService;

        public RecentService(IRecentReadRepository recentReadRepository, IRecentWriteRepository recentWriteRepository, IFileService fileService)
        {
            _fileService = fileService;
            _recentReadRepository = recentReadRepository;
            _recentWriteRepository = recentWriteRepository;
        }
        public async Task<bool> Create(CreateRecentDto model)
        {
            if (model.File == null) return false;
            if (_fileService.IsImage(model.File)) return false;
            if (!_fileService.CheckSize(model.File, 80)) return false;

            var newFile = await _fileService.UploadAsync(model.File);

            Recent recent = new Recent()
            {
                Title= model.Title,
                Description= model.Description,
                FilePath= newFile,
            };

            return true;


        }

        public async Task<bool> Delete(string id)
        {
           var recent =await  _recentReadRepository.GetByIdAsync(id);
            if (recent == null) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\assets\\ing\\" , recent.FilePath );

             _fileService.Delete(path);
            _recentWriteRepository.Remove(recent);
            await _recentWriteRepository.SaveAsync();

            return true;
        }

        public async Task<List<Recent>> GetAll()
        {
         List<Recent> recents= await _recentReadRepository.GetAll().ToListAsync();

            return recents;
        }

        public async Task<Recent> GetById(string id)
        => await _recentReadRepository.GetByIdAsync(id);

        public async Task<bool> Update(UpdateRecentDto model)
        {
            var recent = await _recentReadRepository.GetByIdAsync(model.Id);
           
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\ing\\", recent.FilePath);

            _fileService.Delete(path);
            var newFile = await _fileService.UploadAsync(model.File);
            if (model.File == null) return false;
            if (_fileService.IsImage(model.File)) return false;
            if (!_fileService.CheckSize(model.File, 80)) return false;

            recent.Title= model.Title;  
            recent.Description= model.Description;
            recent.FilePath = newFile;

            _recentWriteRepository.Update(recent);
          await  _recentWriteRepository.SaveAsync();
            return true;
        }
    }
}
