
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TMDT.Models;


namespace TMDT.Patterns
{
    internal class Command
    {
        public interface ICommand
        {
            void Execute();
        }

        public class ProcessOrderCommand : ICommand
        {
            private OrderProcessor _orderProcessor;
            private DONHANG _order;

            public ProcessOrderCommand(OrderProcessor orderProcessor, DONHANG order)
            {
                _orderProcessor = orderProcessor;
                _order = order;
            }

            public void Execute()
            {
                _orderProcessor.ProcessOrder(_order);
            }
        }

        public class CommandInvoker
        {
            private ICommand _command;

            public void SetCommand(ICommand command)
            {
                _command = command;
            }

            public void ExecuteCommand()
            {
                _command.Execute();
            }
        }

        
    }

    
}