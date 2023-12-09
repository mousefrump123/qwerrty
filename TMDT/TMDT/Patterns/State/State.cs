
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TMDT.Models;

namespace TMDT.Patterns
{
    public class State
    {
        public interface IOrderState
        {
            void ProcessOrder(DONHANG order);
            void ShipOrder(DONHANG order);
        }

        // PendingState.cs
        public class PendingState : IOrderState
        {
            public void ProcessOrder(DONHANG order)
            {
                // Logic for processing an order in the pending state
                order.IDTRANGTHAIDH = 2; // Assuming 2 is the ID for Processing state
                                         // Additional processing logic...
            }

            public void ShipOrder(DONHANG order)
            {
                // Logic for shipping an order in the pending state
                order.IDTRANGTHAIDH = 3; // Assuming 3 is the ID for Shipped state
                                         // Additional shipping logic...
            }
        }

        // ProcessingState.cs
        public class ProcessingState : IOrderState
        {
            public void ProcessOrder(DONHANG order)
            {
                // Logic for processing an order in the processing state
                // Additional processing logic...
            }

            public void ShipOrder(DONHANG order)
            {
                // Logic for shipping an order in the processing state
                order.IDTRANGTHAIDH = 3; // Assuming 3 is the ID for Shipped state
                                         // Additional shipping logic...
            }
        }

        // ShippedState.cs
        public class ShippedState : IOrderState
        {
            public void ProcessOrder(DONHANG order)
            {
                // Logic for processing an order in the shipped state
                // Additional processing logic...
            }

            public void ShipOrder(DONHANG order)
            {
                // Logic for shipping an order in the shipped state
                // Additional shipping logic...
            }
        }

    }
}