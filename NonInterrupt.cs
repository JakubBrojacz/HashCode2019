using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    public static class NonInterrupt
    {
        public static void InfiniteLoop(Action action, Action endOperation)
        {
            continueInvoking = true;

            ConsoleCancelEventHandler consoleCancel = new ConsoleCancelEventHandler(myHandler);
            Console.CancelKeyPress += consoleCancel;

            while(continueInvoking)
            {
                action();
            }
            endOperation();

            Console.CancelKeyPress -= consoleCancel;
        }

        private static bool continueInvoking;

        private static void myHandler(object sender, ConsoleCancelEventArgs args)
        {
            Console.WriteLine("Ending operations");
            continueInvoking = false;

            // Set the Cancel property to true to prevent the process from terminating.
            args.Cancel = true;
        }
    }
}
