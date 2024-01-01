﻿using frontend.entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.business.Abstrations
{
    public  interface IFileService
    {
        Task<string> UploadAsync(IFormFile file);
        bool IsImage(IFormFile file);
        bool CheckSize(IFormFile file, int maxSize);
        void Delete(string path);
    }
}
