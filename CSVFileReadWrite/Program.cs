using CsvHelper;
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        Product product= new Product();
        using (var write = new StreamWriter("D:/CSVfile/product.csv"))
        {
            using(var csvWrite= new CsvWriter(write,CultureInfo.InvariantCulture))
            {
                csvWrite.WriteRecords(product.GetProducts());
            }
        }

        using (var reader = new StreamReader("D:/CSVfile/product.csv"))
        {
            using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csvReader.GetRecords<Product>();
                foreach (var record in records)
                {
                    Console.WriteLine($"Product ID = {record.Id}\n Product Name = {record.Name}\n Product Description= {record.Description}\n\n\n");
                }
            }
        }

            Console.WriteLine("Hello, World!");
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public List<Product> GetProducts()
    {
        var productList= new List<Product> 
        {
            new Product { Id = 1, Name = "Test1",Description="Test" },
            new Product { Id = 1, Name = "Test2",Description="Test" },
            new Product { Id = 1, Name = "Test3",Description="Test" },
        };
        return productList;
    }
}