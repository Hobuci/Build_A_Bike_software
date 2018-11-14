using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BuildAbike
{
    public class Payment
    {
        private DateTime date;
        private double amount;

        public void getCustomerDetails(Customer c)
        {
            CustomerDetailsWindow customerWindow = new CustomerDetailsWindow(c);
            customerWindow.ShowDialog(); // Return only when the window is closed
            recordCustomer();
            Pay();
        }

        public void recordCustomer()
        {
            // RECORD CUSTOMER DETAILS IN EXTERNAL FILE
        }

        public void Pay()
        {
            // PAYMENT PROCEDURE
            MessageBox.Show("Payment procedure...");
        }
    }
}
