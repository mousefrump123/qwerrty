
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TMDT.Models;

namespace TMDT.Patterns
{
    public class Observer
    {
        public interface IOrderObserver
        {
            void OrderStatusChanged(DONHANG order);
        }

        public class Buyer : IOrderObserver
        {
            private string email;

            public Buyer(string email)
            {
                this.email = email;
            }

            public void OrderStatusChanged(DONHANG order)
            {
                // Implement the logic to notify the buyer about the order status change
                Console.WriteLine($"Notification sent to {email}: Order {order.IDDONHANG} status changed to {order.currentState}");
            }
        }
    }
}