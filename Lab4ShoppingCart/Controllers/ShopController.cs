using Lab4ShoppingCart.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab4ShoppingCart.Controllers
{
    public class ShopController : Controller
    {
        private static List<ProductItem> products = new List<ProductItem>()
        {
            new ProductItem() {ProductCode="001", ProductDescription="Cuddly Toy", ProductPrice=5.00},
            new ProductItem() {ProductCode="002", ProductDescription="Toothbrush", ProductPrice=2.50},
            new ProductItem() {ProductCode="003", ProductDescription="Necklace", ProductPrice=16.00},
            new ProductItem() {ProductCode="004", ProductDescription="Coke", ProductPrice=1.50}
        };

        private static ShoppingCart myCart = new ShoppingCart();

        public ActionResult Index()
        {
            ViewBag.TotalPrice = myCart.CalculateCart();
            return View(products);
        }
        
        public ActionResult Add(string productCode)
        {
            try
            {
                ProductItem found = products.FirstOrDefault(p=>p.ProductCode == productCode);
                if (found != null)
                {
                    myCart.AddItem(found);
                }
            }
            catch
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            return RedirectToAction("Index");
        }
    }
}
