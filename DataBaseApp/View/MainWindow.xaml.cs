using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataBaseApp.Model.DataBase;

namespace DataBaseApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DB db = new DB();
        CollectionViewSource custViewSource;
        CollectionViewSource ordViewSource;
        public MainWindow()
        {
            InitializeComponent();
            custViewSource = ((CollectionViewSource)(FindResource("customerViewSource")));
            ordViewSource = ((CollectionViewSource)(FindResource("customerOrdersViewSource")));
            DataContext = this;
        }


        private void LastCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            custViewSource.View.MoveCurrentToLast();
        }

        private void PreviousCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            custViewSource.View.MoveCurrentToPrevious();
        }

        private void NextCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            custViewSource.View.MoveCurrentToNext();
        }

        private void FirstCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            custViewSource.View.MoveCurrentToFirst();
        }

        private void DeleteCustomerCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            // If existing window is visible, delete the customer and all their orders.  
            // In a real application, you should add warnings and allow the user to cancel the operation.  
            var cur = custViewSource.View.CurrentItem as User;

            var cust = (from c in db.Users
                        where c.email == cur.email
                        select c).FirstOrDefault();

            if (cust != null)
            {
                foreach (var ord in cust.email.ToList())
                {
                    
                }
                db.Users.Remove(cust);
            }
            db.SaveChanges();
            custViewSource.View.Refresh();
        }

        // Commit changes from the new customer form, the new order form,  
        // or edits made to the existing customer form.  
        private void UpdateCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if (newCustomerGrid.IsVisible)
            {
                // Create a new object because the old one  
                // is being tracked by EF now.  
                User newCustomer = new User()
                {
                   
                    login = add_contactNameTextBox.Text,
                    email = add_contactTitleTextBox.Text,
                    password = add_countryTextBox.Text,
                    
                };

                // Perform very basic validation  
               
                newCustomerGrid.Visibility = Visibility.Collapsed;
                existingCustomerGrid.Visibility = Visibility.Visible;
            }



            //else if (newOrderGrid.IsVisible)
            //{
                // Order ID is auto-generated so we don't set it here.  
                // For CustomerID, address, etc we use the values from current customer.  
                // User can modify these in the datagrid after the order is entered.  

            //    Customer currentCustomer = (Customer)custViewSource.View.CurrentItem;

            //    Order newOrder = new Order()
            //    {
            //        OrderDate = add_orderDatePicker.SelectedDate,
            //        RequiredDate = add_requiredDatePicker.SelectedDate,
            //        ShippedDate = add_shippedDatePicker.SelectedDate,
            //        CustomerID = currentCustomer.CustomerID,
            //        ShipAddress = currentCustomer.Address,
            //        ShipCity = currentCustomer.City,
            //        ShipCountry = currentCustomer.Country,
            //        ShipName = currentCustomer.CompanyName,
            //        ShipPostalCode = currentCustomer.PostalCode,
            //        ShipRegion = currentCustomer.Region
            //    };

            //    try
            //    {
            //        newOrder.EmployeeID = Int32.Parse(add_employeeIDTextBox.Text);
            //    }
            //    catch
            //    {
            //        MessageBox.Show("EmployeeID must be a valid integer value.");
            //        return;
            //    }

            //    try
            //    {
            //        // Exercise for the reader if you are using Northwind:  
            //        // Add the Northwind Shippers table to the model.

            //        // Acceptable ShipperID values are 1, 2, or 3.  
            //        if (add_ShipViaTextBox.Text == "1" || add_ShipViaTextBox.Text == "2"
            //            || add_ShipViaTextBox.Text == "3")
            //        {
            //            newOrder.ShipVia = Convert.ToInt32(add_ShipViaTextBox.Text);
            //        }
            //        else
            //        {
            //            MessageBox.Show("Shipper ID must be 1, 2, or 3 in Northwind.");
            //            return;
            //        }
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Ship Via must be convertible to int");
            //        return;
            //    }

            //    try
            //    {
            //        newOrder.Freight = Convert.ToDecimal(add_freightTextBox.Text);
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Freight must be convertible to decimal.");
            //        return;
            //    }

            //    // Add the order into the EF model  
            //    context.Orders.Add(newOrder);
            //    ordViewSource.View.Refresh();
            //}

            //// Save the changes, either for a new customer, a new order  
            //// or an edit to an existing customer or order.
            db.SaveChanges();
        }

        // Sets up the form so that user can enter data. Data is later  
        // saved when user clicks Commit.  
        private void AddCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            existingCustomerGrid.Visibility = Visibility.Collapsed;
            newOrderGrid.Visibility = Visibility.Collapsed;
            newCustomerGrid.Visibility = Visibility.Visible;

            // Clear all the text boxes before adding a new customer.  
            foreach (var child in newCustomerGrid.Children)
            {
                var tb = child as TextBox;
                if (tb != null)
                {
                    tb.Text = "";
                }
            }
        }

        private void NewOrder_click(object sender, RoutedEventArgs e)
        {
            var cust = custViewSource.View.CurrentItem as User;
            if (cust == null)
            {
                MessageBox.Show("No customer selected.");
                return;
            }

            existingCustomerGrid.Visibility = Visibility.Collapsed;
            newCustomerGrid.Visibility = Visibility.Collapsed;
            newOrderGrid.UpdateLayout();
            newOrderGrid.Visibility = Visibility.Visible;
        }

        // Cancels any input into the new customer form  
        private void CancelCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            add_addressTextBox.Text = "";
            add_cityTextBox.Text = "";
            add_companyNameTextBox.Text = "";
            add_contactNameTextBox.Text = "";
            add_contactTitleTextBox.Text = "";
            add_countryTextBox.Text = "";
            add_customerIDTextBox.Text = "";
            add_faxTextBox.Text = "";
            add_phoneTextBox.Text = "";
            add_postalCodeTextBox.Text = "";
            add_regionTextBox.Text = "";

            existingCustomerGrid.Visibility = Visibility.Visible;
            newCustomerGrid.Visibility = Visibility.Collapsed;
            newOrderGrid.Visibility = Visibility.Collapsed;
        }

      
        private void DeleteOrderCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            // Get the Order in the row in which the Delete button was clicked.  
           
        }
    }
}
