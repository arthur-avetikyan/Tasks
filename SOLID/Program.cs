using SOLID.ISP.Good;
using SOLID.LiskovSub.Good;
using SOLID.OpenClosed.Good;
using SOLID.SingleResponsibility.Good;
using System;

namespace SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            RunSPRBad();
            Console.WriteLine("............");
            RunSPRGood();
            Console.WriteLine("--------------------");

            RunOCBad();
            Console.WriteLine("............");
            RunOCGood();
            Console.WriteLine("--------------------");

            RunLiskovBad();
            Console.WriteLine("............");
            RunLiskovGood();
            Console.WriteLine("--------------------");

            RunISPBad();
            Console.WriteLine("............");
            RunISPGood();
            Console.WriteLine("--------------------");

        }

        private static void RunISPGood()
        {
            Exercises exerciser = new Exercises( new Swimmer(), new Runner(), new Boxer());
            exerciser.Exercise();
        }

        private static void RunISPBad()
        {
            ISP.Bad.Exercises runner = new ISP.Bad.Runner();
            runner.Run();
            ISP.Bad.Exercises swimmer = new ISP.Bad.Swimmer();
            swimmer.Swim();
            ISP.Bad.Exercises boxer = new ISP.Bad.Boxer();
            boxer.Box();
        }

        private static void RunLiskovGood()
        {
            IAreaCalculator lSquareArea = new Square(5);
            IAreaCalculator lRectangleArea = new GoodRectangle(5, 6);

            Console.WriteLine(lSquareArea.GetArea());
            Console.WriteLine(lRectangleArea.GetArea());
        }

        private static void RunLiskovBad()
        {
            LiskovSub.Bad.Rectangle lRectangle = new LiskovSub.Bad.Square();
            lRectangle.Height = 5;
            lRectangle.Width = 6;
            Console.WriteLine(lRectangle.GetArea());
        }

        private static void RunOCGood()
        {
            PaperPresenter lPaperPresenter = new PaperPresenter(new PaperOrderer());
            PDFPresenter lPdfPresenter = new PDFPresenter(new PDFOrderer());

            lPaperPresenter.Present();
            lPdfPresenter.Present();
        }

        private static void RunOCBad()
        {
            OpenClosed.Bad.PaperPresenter lPaperPresenter = new OpenClosed.Bad.PaperPresenter();
            OpenClosed.Bad.PdfPresenter lPdfPresenter = new OpenClosed.Bad.PdfPresenter();
            lPaperPresenter.PresentOnPaper();
            lPdfPresenter.PresentOnPdf();
        }

        private static void RunSPRGood()
        {
            Product lProduct = new Product
            {
                Price = 150,
                Units = 15,
                Name = "Watermelon"
            };
            DiscountProvider discountProvider = new DiscountProvider();
            ProfitCalculator profitCalculator = new ProfitCalculator(0.2, 90);

            ProductDisplayer.DisplayProduct(lProduct);
            lProduct.Price -= discountProvider.ApplyDiscount(profitCalculator.CalculateProfit(lProduct.Price));
            lProduct.SellProduct(1);
            ProductDisplayer.DisplayProduct(lProduct);
            lProduct.Price -= discountProvider.ApplyDiscount(profitCalculator.CalculateProfit(lProduct.Price));
            lProduct.SellProduct(2);
            profitCalculator.Tax = 0.1;
            ProductDisplayer.DisplayProduct(lProduct);
            lProduct.Price -= discountProvider.ApplyDiscount(profitCalculator.CalculateProfit(lProduct.Price));
            lProduct.SellProduct(3);
            ProductDisplayer.DisplayProduct(lProduct);
            lProduct.Price -= discountProvider.ApplyDiscount(profitCalculator.CalculateProfit(lProduct.Price));
            lProduct.SellProduct(2);
        }

        private static void RunSPRBad()
        {
            ProductBad lProductBad = new ProductBad
            {
                Price = 100,
                Units = 10,
                Name = "Melon",
                Tax = 0.05,
                Cost = 60
            };

            lProductBad.DisplayProduct();
            lProductBad.ApplyDiscount();
            lProductBad.SellProduct(1);

            lProductBad.DisplayProduct();
            lProductBad.ApplyDiscount();
            lProductBad.SellProduct(2);

            lProductBad.DisplayProduct();
            lProductBad.ApplyDiscount();
            lProductBad.SellProduct(2);

            lProductBad.DisplayProduct();
            lProductBad.ApplyDiscount();
            lProductBad.SellProduct(2);

            lProductBad.DisplayProduct();
            lProductBad.ApplyDiscount();
            lProductBad.SellProduct(2);
            lProductBad.DisplayProduct();
        }
    }
}
