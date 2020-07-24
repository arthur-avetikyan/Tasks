using IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class DiscountProvider : IDiscountProvider
    {
        IDiscountStrategy _discountStrategy;
       // IRepository _repository;

        //public DiscountProvider(IRepository repository)
        //{
        //    _repository = repository;
        //}


        public double ApplyDiscount(IDiscountStrategy discountStrategy, Guid productId)
        {
            //var entity = _repository.GetEntityById(productId);
            //return entity.TotalPrice - 
             return   _discountStrategy.GetDiscount(productId
                  //  entity.Id
                    );
        }

        public void SetDiscountStrategy(IDiscountStrategy discountStrategy)
        {
            _discountStrategy = discountStrategy;
        }
    }
}
