
namespace Web_Repository.Context
{
    public static  class StoreContextSeeding
    {
        public static async Task seed(FirstDataBase dataBaseFirst)
        {
            if (dataBaseFirst.Products.Any())
                return;
            var branddata = File.ReadAllText("D:\\Projects\\E_Commerce_Web_Api\\WEB_DAL\\DataSeeding\\brands.json");
            var listbrand = JsonSerializer.Deserialize<List<Brand>>(branddata);
            foreach (var i in listbrand)
            {
                await dataBaseFirst.Set<Brand>().AddAsync(i);
                await dataBaseFirst.SaveChangesAsync();
            }
            //   await dataBaseFirst.Set<Brand>().AddAsync(i);

            var categdata = File.ReadAllText("D:\\Projects\\E_Commerce_Web_Api\\WEB_DAL\\DataSeeding\\types.json");
            var listcate = JsonSerializer.Deserialize<List<Category>>(categdata);
            foreach (var i in listcate)
            {
                // categories.Add(i);
                await dataBaseFirst.Set<Category>().AddAsync(i);
                await dataBaseFirst.SaveChangesAsync();
            }
            var productdata = File.ReadAllText("D:\\Projects\\E_Commerce_Web_Api\\WEB_DAL\\DataSeeding\\products.json");
            var listproduct = JsonSerializer.Deserialize<List<Product>>(productdata);
            foreach (var i in listproduct)
            {
                await dataBaseFirst.Set<Product>().AddAsync(i);
                await dataBaseFirst.SaveChangesAsync();
            }
        }
    }
}
