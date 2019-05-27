using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Product
    {
        public Product(int id, string name, decimal price, bool active)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
            Active = active;
        }

        public int Id { get; set; }
        public string Name { get; set; }
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
