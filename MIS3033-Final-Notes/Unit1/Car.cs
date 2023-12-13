using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit1
{
    public class Car
    {
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public decimal SalePrice { get; set; }

        public Car()
        {

        }

        public Car(string vin, string make, string color, int year, string model, decimal salePrice)
        {
            VIN = vin;
            Make = make;
            Color = color;
            Year = year;
            Model = model;
            SalePrice = salePrice;
        }

        // Optional: Override ToString for better display in debugging
        public override string ToString()
        {
            return $"{Year} {Make} - {Model}";
        }
    }
}
