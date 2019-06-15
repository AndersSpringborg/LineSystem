using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core
{
    public class Product
    {
        private int _id;
        private string _name;
        public Product(int id, string name, decimal price, bool active)
        {
            Id = id;
            Name = name;
            Price = price;
            Active = active;
        }

        public int Id
        {
            get => _id;
            set
            {
                if (value > 0)
                {
                    _id = value;
                }
            }
        }

        public string Name
        {
            get => _name;
            set => _name = Regex.Replace(value, "<.*?>", String.Empty);
        }
        public decimal Price { get; set; }
        public bool Active { get; set; }
        public bool CanBeBoughtOnCredit { get; set; }

        public override string ToString()
        {
            return $"{Id, 4} | {Name, -40} | {Price}";
        }

    }

    class SeasonalProduct : Product
    {
        public SeasonalProduct(int id, string name, decimal price, bool active, TimeSpan deactivateDate) : base(id, name, price, active)
        {
            SeasonEndDate = deactivateDate;
        }
        public TimeSpan SeasonStartDate { get; set; }
        public TimeSpan SeasonEndDate { get; set; }

      
    }
}
