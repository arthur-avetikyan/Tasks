using Store.DAL.Infrastructure;
using Store.Entities;
using Store.IServices;
using System;

namespace Store.Services
{
    public class PriceService : IPriceService
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<Price> _priceRepository;

        public PriceService(IUnitOfWork uunitOfWork)
        {
            _unitOfWork = uunitOfWork;
            _priceRepository = _unitOfWork.GetRepository<Price>();
        }

        public void DropPrice(Guid id, double amount)
        {
            _priceRepository.GetById(id).Cost -= amount;
            _unitOfWork.Save();
        }
    }
}
