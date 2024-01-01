using frontend.business.Application.Dtos.Feauters;
using frontend.business.Application.Dtos.Product;
using frontend.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.business.Abstract
{
    public interface IFeautersService
    {
        Task<List<Feauters>> GetAll();
        Task<Feauters> GetById(string id);

        Task<bool> Create(CreateFeautersDto model);
        Task<bool> Update(UpdateFeautersDto model);
        Task<bool> Delete(string id);
    }
}
