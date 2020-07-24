using IServices;

namespace Market
{
    public class ApplicationStart
    {
        private IDiscountProvider _discountProvider;

        public ApplicationStart(IDiscountProvider discountProvider)
        {
            _discountProvider = discountProvider;
        }

        public void Run()
        {

        }
    }
}