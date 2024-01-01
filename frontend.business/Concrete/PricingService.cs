using frontend.business.Abstract;
using frontend.business.Abstrations;
using frontend.business.Application.Dtos.Pricing;
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
    public class PricingService : IPricingService
    {
        readonly private IPricingReadRepository _pricingReadRepository;
        readonly private IPricingWriteRepository _pricingWriteRepository;


        public PricingService(IPricingReadRepository pricingReadRepository, IPricingWriteRepository pricingWriteRepository)
        {
            _pricingReadRepository = pricingReadRepository;
            _pricingWriteRepository= pricingWriteRepository;
        }
        public async Task<bool> Create(CreatePricingDto model)
        {
            Pricing pricing = new Pricing()
            {
                Title = model.Title,
                TotalMemory = model.TotalMemory,
                Price = model.Price,
                PriceCategory = model.PriceCategory,
                PricingUser = model.PricingUser,
                PricngName = model.PricngName
            };

            await _pricingWriteRepository.AddAsync(pricing);
            await _pricingWriteRepository.SaveAsync();

            return true;

        }

        public async Task<bool> Delete(string id)
        {
            await _pricingWriteRepository.RemoveAsync(id);
            await _pricingWriteRepository.SaveAsync();
            return true;
        }

        public async Task<List<Pricing>> GetAll()
        {
            List<Pricing> pricings = await _pricingReadRepository.GetAll().ToListAsync();
          
            return pricings;
        }

        public async Task<Pricing> GetById(string id)
        => await _pricingReadRepository.GetByIdAsync(id);

        public async Task<bool> Update(UpdatePricingDto model)
        {
            var pricing = await _pricingReadRepository.GetByIdAsync(model.id);

            if (pricing == null) return false;

            pricing.Title=model.Title;
            pricing.PriceCategory= model.PriceCategory;
            pricing.TotalMemory= model.TotalMemory;
            pricing.Price=model.Price;  
            pricing.PricingUser= model.PricingUser;
            pricing.PricngName=model.PricngName;

             _pricingWriteRepository.Update(pricing);

            await _pricingWriteRepository.SaveAsync();

            return true;
        }
    }
}
