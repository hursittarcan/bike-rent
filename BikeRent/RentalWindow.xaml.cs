using System;
using System.Windows;

namespace BikeRent
{
    /// <summary>
    /// Interaction logic for RentalWindow.xaml
    /// </summary>
    public partial class RentalWindow : Window
    {
        //ToDo : you may add an extra constructor parameter to pass along information
        private BikeBase _bike; 

        public RentalWindow(BikeBase bike)
        {
            InitializeComponent();
            _bike = bike;

            //ToDo: call the following methods
            //  EnableControls
            //  BindCurrentBike
            EnableControls(_bike); 
            BindCurrentBike(_bike);

            //ToDo: call UpdateDaysAndTotalPrice when the user moves the slider
            daysSlider.ValueChanged += DaysSlider_ValueChanged;
        }

        private void DaysSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateDaysAndTotalPrice();
        }

        private void UpdateDaysAndTotalPrice()
        {
            int days = (int)daysSlider.Value;
            daysTextBlock.Text = $"{days}";

            // ToDo: Use method CalculatePrice from class BusinessRules to set totalTextBlock.Text
            totalTextBlock.Text = BusinessRules.CalculatePrice(days, _bike.PricePerDay).ToString();
        }

        private void BindCurrentBike(BikeBase bike)
        {
            titleTextBlock.Text = $"Fiets {bike.Id:D3} - {bike.Brand}";
            if (bike.IsOccupied) // we are returning the bike
            {
                this.Title = "Lever in";
                var rental = bike.FindCurrentRental();
                startDateTextBox.Text = $"{rental.StartDate:d}";
                customerTextBox.Text = rental.Customer;
                daysSlider.Value = (rental.EndDate - rental.StartDate).Days;
            }
            else
            {
                this.Title = "Verhuur";
                customerTextBox.Text = string.Empty;
                startDateTextBox.Text = $"{DateTime.Now:d}";
                daysSlider.Value = 1;
            }
            UpdateDaysAndTotalPrice();
        }

        private void EnableControls(BikeBase bike)
        {
            if (bike.IsOccupied) // we are returning the bike
            {
                submitButton.Content = "Lever in";
                startDateTextBox.IsEnabled = false;
                customerTextBox.IsEnabled = false;

                daysSlider.IsEnabled = false;

                kmTextBlock.Visibility = Visibility.Visible;
                kmTextBox.Visibility = Visibility.Visible;
            }
            else
            {
                submitButton.Content = "Huur";

                kmTextBlock.Visibility = Visibility.Hidden;
                kmTextBox.Visibility = Visibility.Hidden;
            }
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            //ToDo: uncomment and provide proper exception handling

            if (_bike.IsOccupied)
            {
                ReturnTheBike();
            }
            else
            {
                RentTheBike();
            }
            this.Close();
        }

        private void RentTheBike()
        {
            //ToDo: uncomment
            try
            {
                DateTime startDate = BusinessRules.CheckStartDate(startDateTextBox.Text);
                string customer = customerTextBox.Text;
                int days = (int)daysSlider.Value;

                _bike.Rent(startDate, days, customer);

                MessageBox.Show("Nieuwe verhuring geaccepteerd");
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }

        private void ReturnTheBike()
        {
            //ToDo: uncomment
            
            //double distance = Convert.ToDouble(kmTextBox.Text);
            //_bike.Return(distance);

            //MessageBox.Show("Fiets ingeleverd");
        }
    }
}
