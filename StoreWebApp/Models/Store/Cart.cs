using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApp.Models.Store
{
    public class Cart
    {
        public Cart()
        {
        }

        [Key]
        public int CartId
        {
            get;
            set;
        }

        public int? CustomerId
        {
            get;
            set;
        }

        public DateTime StartDate
        {
            get;
            set;
        }

        public virtual List<CartDish> CartDishes
        {
            get;
            set;
        }

        public virtual Order Order
        {
            get;
            set;
        }
    }
}
