using CRUDHw.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDHw.Controllers
{
    public class ProductController : Controller
    {
        private static readonly List<Product> products = new()
		{
			new Product()
			{
				Id= 0,
				Name = "Cola",
				Description = "Cola is a carbonated soft drink flavored with vanilla, cinnamon, citrus oils, and other flavorings. Cola became popular worldwide after the American pharmacist John Stith Pemberton invented Coca-Cola, a trademarked brand, in 1886, which was imitated by other manufacturers.",
				Quantity = 10,
				Price = 2.5,
				Image = "cola.jpg"
			},
			new Product()
			{
				Id= 1,
				Name = "Fanta",
				Description = "Fanta is an American-owned German brand of fruit-flavored carbonated soft drinks created by Coca-Cola Deutschland under the leadership of German businessman Max Keith. There are more than 200 flavors worldwide",
				Quantity = 200,
				Price = 2,
				Image = "fanta.jpg"
			}

		};
		private static int id = 2;
        public IActionResult Index()
        {
			return View(products);
        }

		[HttpPost]
		public IActionResult AddProduct(Product product)
		{
			product.Id = id++;
			product.Image = "default.png";
			products.Add(product);
			return RedirectToAction("Index");
		}

		[HttpGet] 
		public IActionResult AddProduct()
		{
			return View("AddProduct");
		}

		[HttpPost]
		public IActionResult Delete(Product findProduct)
		{
			var product = products.FirstOrDefault(p => p.Name == findProduct.Name);
			if (product is not null)
				products.Remove(product);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult View(int id)
		{
			var product = products.FirstOrDefault(p => p.Id == id);
			if (product is not null)
			{
				return View("View", product);
			}
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Search(string name)
		{
			var filteredProducts = new List<Product>();
			if (name is not null)
				filteredProducts = products.Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();
			return View(filteredProducts);

		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			var product = products.FirstOrDefault(p => p.Id == id);
			if (product is not null)
			{
				var myProduct = new Product()
				{
					Id = product.Id,
					Image = product.Image,
					Description = product.Description,
					Name = product.Name,
					Price = product.Price,
					Quantity = product.Quantity
				};
				return View("View", myProduct);
			}
			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult Edit(Product updatedProduct)
		{
			var product = products.FirstOrDefault(p => p.Id == updatedProduct.Id);
			if (product is not null)
			{
				product.Name = updatedProduct.Name;
				product.Description = updatedProduct.Description;
				product.Price = updatedProduct.Price;
				product.Quantity = updatedProduct.Quantity;
			}
			return RedirectToAction("Index");
		}
	}
}
