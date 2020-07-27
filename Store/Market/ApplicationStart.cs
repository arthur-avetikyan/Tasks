using Store.DAL.Infrastructure;
using Store.Entities;

namespace Market
{
    public class ApplicationStart
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<Product> _repository;

        public ApplicationStart(IUnitOfWork unitOfWork, IRepository<Product> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public void Run()
        {
            _repository.Insert(new Product
            {
                Name = "Book",
                Price = new Price
                {
                    Cost = 100,
                    Currency = "Amd",
                },
                Stock = new Stock
                {
                    InStock = 10
                }
            });
            _unitOfWork.Save();
        }
    }
}