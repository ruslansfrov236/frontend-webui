using frontend.business.Application.Dtos.Pricing;
using frontend.business.Dtos.Recent;
using frontend.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.business.Abstract
{
    public interface IRecentService
    {
        Task<List<Recent>> GetAll();
        Task<Recent> GetById(string id);

        Task<bool> Create(CreateRecentDto model);
        Task<bool> Update(UpdateRecentDto model);
        Task<bool> Delete(string id);
    }
}
