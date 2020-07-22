namespace SOLID
{
    public class Product
    {
        public string Name { get; set; }

        public int Units { get; set; }

        public double Price { get; set; }

        public void SellProduct(int count)
        {
            Units -= count;
        }
    }
}
