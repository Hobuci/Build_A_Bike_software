using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace BuildAbike
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Load in Stock
            Stock.Load();
            // Populate ComboBoxes
            comboBoxLoad();
        }
        // Create customer object
        Customer customer = new Customer();
        // Temporarily stores orders of a customer
        List<Order> customerOrdersTemp = new List<Order>();

        private void btn_addOrder_Click(object sender, RoutedEventArgs e)
        {
            // Make sure input is correct
            if (isInputCorrect())
            {
                // Get input values from combo boxes
                string frameColour = comboBox_frameColour.Text;
                string frameSize = comboBox_frameSize.Text;
                int gearsBreaks = Stock.getItemID(comboBox_gearsBreaks.Text);
                int wheels = Stock.getItemID(comboBox_wheels.Text);
                int handlebarSaddle = Stock.getItemID(comboBox_handlebarSaddle.Text);
                bool warranty = checkBox_warranty.IsChecked ?? false;
                // Generate new order
                Order order = new Order(frameSize, frameColour, gearsBreaks, wheels, handlebarSaddle, warranty);
                // Add order to the orders list
                customerOrdersTemp.Add(order);
                // Clear Combo Boxes
                comboBoxClear();

                if (customerOrdersTemp.Count > 1)
                {// If the customer has more orders than one, display price for each order 5 MAX
                    switch (customerOrdersTemp.Count)
                    {
                        case 2:
                            DisplayMultipleOrders(2);
                            break;
                        case 3:
                            DisplayMultipleOrders(3);
                            break;
                        case 4:
                            DisplayMultipleOrders(4);
                            break;
                        case 5:
                            DisplayMultipleOrders(5);
                            break;
                    }
                }
                else
                {// Display the price
                    DisplayPrice(gearsBreaks, wheels, handlebarSaddle, warranty);
                }
                DisplayDeliveryTime(customerOrdersTemp);
            }
            else
            {// Display error message if input is empty
                MessageBox.Show("Input field empty");
            }
        }
        private void btn_pay_Click(object sender, RoutedEventArgs e)
        {// Initialize payment procedure
            Payment payment = new Payment();
            // Attach orders to customer object
            customer.Orders = customerOrdersTemp;
            // Get customer details and proceed with payment
            payment.getCustomerDetails(customer);

            // Reset windows
            priceBoxClear();
        }
        private bool isInputCorrect()
        {// Returns false if any of the input zones are empty
            if (comboBox_frameColour.Text != "" &&
                comboBox_frameSize.Text != "" &&
                comboBox_gearsBreaks.Text != "" &&
                comboBox_wheels.Text != "" &&
                comboBox_handlebarSaddle.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void DisplayPrice(int gearsBreak, int wheels, int handlebarSaddle, bool warranty)
        {
            // Display component name
            label_p1.Content = Stock.getItemName(gearsBreak);
            label_p2.Content = Stock.getItemName(wheels);
            label_p3.Content = Stock.getItemName(handlebarSaddle);
            label_warranty.Content = "Warranty";
            // Display price
            label_price_p1.Content = "£ " + Stock.getItemPrice(gearsBreak);
            label_price_p2.Content = "£ " + Stock.getItemPrice(wheels);
            label_price_p3.Content = "£ " + Stock.getItemPrice(handlebarSaddle);
            if (warranty)
            {
                label_price_warranty.Content = "£ 50";
            }
            else
            {
                label_price_warranty.Content = "£ 0";
            }

            label_price_total.Content = "£ " + customerOrdersTemp.ElementAt(0).getPrice();
        }
        private void DisplayMultipleOrders(int numberOfOrders)
        {
            switch (numberOfOrders)
            {
                case 2:
                    //Clear labels
                    priceBoxClear();
                    //Display Order name
                    label_p1.Content = "Order 1";
                    label_p2.Content = "Order 2";
                    //Display Order total
                    label_price_p1.Content = "£ " + customerOrdersTemp.ElementAt(0).getPrice();
                    label_price_p2.Content = "£ " + customerOrdersTemp.ElementAt(1).getPrice();
                    //Display total price of all Orders
                    label_price_total.Content = "£ " + (customerOrdersTemp.ElementAt(0).getPrice() +
                                                        customerOrdersTemp.ElementAt(1).getPrice());
                    break;
                case 3:
                    priceBoxClear();
                    label_p1.Content = "Order 1";
                    label_p2.Content = "Order 2";
                    label_p3.Content = "Order 3";
                    label_price_p1.Content = "£ " + customerOrdersTemp.ElementAt(0).getPrice();
                    label_price_p2.Content = "£ " + customerOrdersTemp.ElementAt(1).getPrice();
                    label_price_p3.Content = "£ " + customerOrdersTemp.ElementAt(2).getPrice();
                    label_price_total.Content = "£ " + (customerOrdersTemp.ElementAt(0).getPrice() +
                                                        customerOrdersTemp.ElementAt(1).getPrice() +
                                                        customerOrdersTemp.ElementAt(2).getPrice());
                    label_p4.Content = "";
                    label_warranty.Content = "";
                    break;
                case 4:
                    priceBoxClear();
                    label_p1.Content = "Order 1";
                    label_p2.Content = "Order 2";
                    label_p3.Content = "Order 3";
                    label_p4.Content = "Order 4";
                    label_price_p1.Content = "£ " + customerOrdersTemp.ElementAt(0).getPrice();
                    label_price_p2.Content = "£ " + customerOrdersTemp.ElementAt(1).getPrice();
                    label_price_p3.Content = "£ " + customerOrdersTemp.ElementAt(2).getPrice();
                    label_price_p4.Content = "£ " + customerOrdersTemp.ElementAt(3).getPrice();
                    label_price_total.Content = "£ " + (customerOrdersTemp.ElementAt(0).getPrice() +
                                                        customerOrdersTemp.ElementAt(1).getPrice() +
                                                        customerOrdersTemp.ElementAt(2).getPrice() +
                                                        customerOrdersTemp.ElementAt(3).getPrice());
                    label_warranty.Content = "";
                    break;
                case 5:
                    priceBoxClear();
                    label_p1.Content = "Order 1";
                    label_p2.Content = "Order 2";
                    label_p3.Content = "Order 3";
                    label_p4.Content = "Order 4";
                    label_warranty.Content = "Order 5";
                    label_price_p1.Content = "£ " + customerOrdersTemp.ElementAt(0).getPrice();
                    label_price_p2.Content = "£ " + customerOrdersTemp.ElementAt(1).getPrice();
                    label_price_p3.Content = "£ " + customerOrdersTemp.ElementAt(2).getPrice();
                    label_price_p4.Content = "£ " + customerOrdersTemp.ElementAt(3).getPrice();
                    label_price_warranty.Content = "£ " + customerOrdersTemp.ElementAt(3).getPrice();
                    label_price_total.Content = "£ " + (customerOrdersTemp.ElementAt(0).getPrice() +
                                                        customerOrdersTemp.ElementAt(1).getPrice() +
                                                        customerOrdersTemp.ElementAt(2).getPrice() +
                                                        customerOrdersTemp.ElementAt(3).getPrice() +
                                                        customerOrdersTemp.ElementAt(4).getPrice());
                    break;
            }
        }
        private void DisplayDeliveryTime(List<Order> customerOrdersTemp)
        {// Displays delivery time, if an item is not on stock adds a week to it
            int days = 1;
            // If we already need to deliver a part, ordering another one will not take an additional week, so use this to handle that case
            bool needDelivery = false;

            foreach (var order in customerOrdersTemp)
            {
                if ((Stock.getItemCount(order.GearsBreaks) < 1 || Stock.getItemCount(order.Wheels) < 1 || Stock.getItemCount(order.HandlebarSaddle) < 1)
                        && !needDelivery)
                {
                    days += 7;
                    needDelivery = true;
                }
                // Update stock count
                Stock.decreaseItemCount(order.GearsBreaks);
                Stock.decreaseItemCount(order.Wheels);
                Stock.decreaseItemCount(order.HandlebarSaddle);
            }
            label_deliveryDate.Content = days + " Days";
        }
        private void comboBoxLoad()
        {// Populates comboBoxes from stock
            // Colours
            foreach (var item in Stock.Colours)
            {
                comboBox_frameColour.Items.Add(item);
            }
            // Sizes
            foreach (var item in Stock.Sizes)
            {
                comboBox_frameSize.Items.Add(item);
            }
            // Gears and Breaks
            foreach (var item in Stock.Items)
            {
                if (item.Key > 100 && item.Key < 200)
                {
                    comboBox_gearsBreaks.Items.Add(item.Value);
                }
            }
            // Wheels
            foreach (var item in Stock.Items)
            {
                if (item.Key > 200 && item.Key < 300)
                {
                    comboBox_wheels.Items.Add(item.Value);
                }
            }
            // Handlebar and Saddle
            foreach (var item in Stock.Items)
            {
                if (item.Key > 300 && item.Key < 400)
                {
                    comboBox_handlebarSaddle.Items.Add(item.Value);
                }
            }
        }
        private void comboBoxClear()
        {
            comboBox_frameColour.SelectedItem = null;
            comboBox_frameSize.SelectedItem = null;
            comboBox_gearsBreaks.SelectedItem = null;
            comboBox_wheels.SelectedItem = null;
            comboBox_handlebarSaddle.SelectedItem = null;
            checkBox_warranty.IsChecked = false;
        }
        private void priceBoxClear()
        {
            label_p1.Content = "";
            label_p2.Content = "";
            label_p3.Content = "";
            label_p4.Content = "";
            label_warranty.Content = "";
            label_price_p1.Content = "";
            label_price_p2.Content = "";
            label_price_p3.Content = "";
            label_price_p4.Content = "";
            label_price_warranty.Content = "";
            label_price_total.Content = "";
            label_deliveryDate.Content = " Days";
        }
    }
}
