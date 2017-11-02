using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApp.Models.Store
{
    public class Order
    {
        public Order()
        {
            StartDate = DateTime.Now;
        }

        public int OrderId
        {
            get;
            set;
        }

        public int CustomerId
        {
            get;
            set;

        }

        [Key, ForeignKey("Cart")]
        public int CartId
        {
            get;
            set;
        }

        public decimal TotalPrice
        {
            get;
            set;
        }

        public string OrderStatus
        {
            get;
            set;
        }

        public DateTime DeliveryDate
        {
            get;
            set;
        }

        public DateTime StartDate
        {
            get;
            set;
        }

        public Cart Cart
        {
            get;
            set;
        }

    }
}
