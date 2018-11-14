using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace BuildAbike
{
    /// <summary>
    /// Interaction logic for customerDetails.xaml
    /// </summary>
    public partial class CustomerDetailsWindow : Window
    {
        Customer customer;

        public CustomerDetailsWindow(Customer c)
        {
            InitializeComponent();
            customer = c;
        }

        private void btn_pay_Click(object sender, RoutedEventArgs e)
        {// Get customer details, check validity
            string name = txtb_name.Text;
            string address = txtb_address.Text;
            string email = txtb_email.Text;

            if (name != "" && address != "" && email != "" && email.Contains('@'))
            {
                customer.Name = name;
                customer.Address = address;
                customer.Email = email;

                this.Hide();
            }
            else
            {
                MessageBox.Show("Input Invalid");
            }
        }
    }
}
