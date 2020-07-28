namespace Store.DTO
{
    public class ProductDTO : DTOBase
    {
         public string Name { get; set; }

        public PriceDTO Price { get; set; }

        public StockDTO Stock { get; set; }
    }
}
