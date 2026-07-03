using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Phone
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public float Price { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Phone(string name, string manufacturer, float price, DateTime releaseDate)
        {
            Name = name;
            Manufacturer = manufacturer;
            Price = price;
            ReleaseDate = releaseDate;
        }

        public override string ToString() {
            return $"Name: {Name}, Manufacturer: {Manufacturer}, Price: {Price}, Release Date: {ReleaseDate}";
        }

    }
}
