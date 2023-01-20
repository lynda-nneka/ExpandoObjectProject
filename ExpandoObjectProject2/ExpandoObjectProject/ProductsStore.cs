using System;
using System.Dynamic;
namespace ExpandoObjectProject
{
	public class ProductsStore
	{
		public List<Product> products = new();

		public ProductsStore()
		{
            products = new List<Product>();
            products.Add(new Product { name = "Product 1", id = 1, price = 19, category = "Electronics", quantity = 3, orderCount = 45 });
            products.Add(new Product { name = "Product 2", id = 2, price = 9,  category = "Home & Kitchen", quantity = 90, orderCount = 67 });
            products.Add(new Product { name = "Product 3", id = 3, price = 29, category = "Outdoors", quantity = 7, orderCount = 87 });
            products.Add(new Product { name = "Product 4", id = 4, price = 14, category = "Clothing", quantity = 4, orderCount = 56 });
        }

		public List<dynamic> ProductsList(List<string> properties = null)
		{
			if (properties == null)
			{
				return products.Select((Product product) =>
				{
					dynamic expandoObject = new ExpandoObject();
					expandoObject.id = product.id;
					expandoObject.name = product.name;
					expandoObject.price = product.price;
					expandoObject.quantity = product.quantity;
					expandoObject.category = product.category;
					expandoObject.orderCount = product.orderCount;

					return expandoObject;
				}).ToList();

			} else
			{
				return products.Select((Product product) =>
				{
                    dynamic expandoObject = new ExpandoObject();

					if (properties.Contains("Id".ToLower()))
					{
                        expandoObject.id = product.id;
                    }
                    if (properties.Contains("Name".ToLower()))
                    {
                        expandoObject.name = product.name;
                    }
                    if (properties.Contains("Price".ToLower()))
                    {
                        expandoObject.price = product.price;
                    }
                    if (properties.Contains("Quantity".ToLower()))
                    {
                        expandoObject.quantity = product.quantity;
                    }
                    if (properties.Contains("Category".ToLower()))
                    {
                        expandoObject.category = product.category;
                    }
                    if (properties.Contains("OrderCount".ToLower()))
                    {
                        expandoObject.orderCount = product.orderCount;
                    }

					return expandoObject;
                }).ToList();
			}
		}
	}
}

