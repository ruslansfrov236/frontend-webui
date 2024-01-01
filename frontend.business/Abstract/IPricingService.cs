using frontend.business.Application.Dtos.Pricing;
using frontend.business.Application.Dtos.Product;
using frontend.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.business.Abstract
{
    public interface IPricingService
    {

        Task<List<Pricing>> GetAll();
        Task<Pricing> GetById(string id);

        Task<bool> Create(CreatePricingDto model);
        Task<bool> Update(UpdatePricingDto model);
        Task<bool> Delete(string id);
    }
}
