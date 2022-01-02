using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.IO;

namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            Products[] product = new Products[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите номер");
                int num = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название");
                string name = Console.ReadLine();
                Console.WriteLine("Введите цену");
                int price = Convert.ToInt32(Console.ReadLine());
                product[i] = new Products() { NumGood = num, NameGood = name, PriceGood = price };
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(product, options);
            using (StreamWriter sw = new StreamWriter("../../../Products.json"))
            {
                sw.WriteLine(jsonString);
            }
            using (StreamReader sr = new StreamReader("../../../Products.json"))
            {
                jsonString = sr.ReadToEnd();
            }
            Products[] employees = JsonSerializer.Deserialize<Products[]>(jsonString);
            Products maxEmployee = employees[0];
            foreach (Products p in employees)
            {
                if (p.PriceGood > maxEmployee.PriceGood)
                {
                    maxEmployee = p;
                }
            }
            Console.WriteLine(maxEmployee.PriceGood);
            Console.ReadKey();
        }
    }
}
