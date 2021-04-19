using DeliVeggie.Client.Rpc.Services;
using System.Threading.Tasks;

namespace DeliVeggie.Client.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var productService = new ProductService();

            var products = await productService.ListProductsAsync();

            if(products != null && products.ProductList != null)
            {
                System.Console.WriteLine("Product list-----------------------------------------------------------");
                foreach (var p in products.ProductList)
                {
                    System.Console.WriteLine("Product id: {0}", p.Id);
                    System.Console.WriteLine("Product name: {0}", p.Name);                    
                    System.Console.WriteLine("-------------------------------------------------------------------------------");
                }

                System.Console.WriteLine("Product details for each product-----------------------------------------------------------");
                foreach (var p in products.ProductList)
                {
                    var pR = await productService.GetProductDetailsAsync(p.Id);
                    if (pR != null)
                    {
                        System.Console.WriteLine("Product id: {0}", pR.Product.Id);
                        System.Console.WriteLine("Product name: {0}", pR.Product.Name);
                        System.Console.WriteLine("Product entry date: {0}", pR.Product.EntryDate);
                        System.Console.WriteLine("Product price with reduction: {0}", pR.Product.PriceWithReduction);
                        System.Console.WriteLine("-------------------------------------------------------------------------------");
                    }
                    else
                    {
                        System.Console.WriteLine($"Product details [id: {p.Id}] not found.");
                    }
                }
            }
            else
            {
                System.Console.WriteLine("No result in the last call");
            }

            System.Console.WriteLine("Hit <return> to continue.");
            System.Console.ReadLine();
        }
    }
}
