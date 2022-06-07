using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace BikeRent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Company _company;

        private BitmapImage _maleBikeImage;
        private BitmapImage _femaleBikeImage;
        private BitmapImage _electricalImage;
        
        public MainWindow()
        {
            InitializeComponent();

            _maleBikeImage = ImageUtils.CreateBitmapImage("Images/MaleBike.png");
            _femaleBikeImage = ImageUtils.CreateBitmapImage("Images/FemaleBike.png");
            _electricalImage = ImageUtils.CreateBitmapImage("Images/Electrical.png");

            _company = new Company();
            
            BindCurrentBike(_company.CurrentBike);
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            _company.Next();
            BindCurrentBike(_company.CurrentBike);
        }

        private void BindCurrentBike(BikeBase bike)
        {
            // ToDo:
            //  - Place info on the screen
            //  - look at the screenshots to know exactly what and when
            idTextBlock.Text = bike.Id.ToString("000");
            brandTextBlock.Text = bike.Brand;
            typeTextBlock.Text = bike.Type;
            descriptionTextBlock.Text = bike.Description;
            maintenanceProgressBar.Value = bike.TotalDistance / 100;
            maintenanceTextBlock.Text = $"{bike.TotalDistance} / 10000 km";
            rentOrReturnButton.Content = "Huur";
            rentOrReturnButton.IsEnabled = true; 
            rentStatusTextBlock.Text = String.Empty;

            if (bike.IsOccupied)
            {
                rentStatusTextBlock.Text = $"Verhuurd aan {_company.CurrentBike.FindCurrentRental().Customer} tot {_company.CurrentBike.FindCurrentRental().EndDate.ToString("dd/MM/yyyy")}";
                rentOrReturnButton.Content = "Retour"; 
            }

            if (bike.TotalDistance >= bike.KmPerMaintenanceCycle)
            {
                rentOrReturnButton.IsEnabled = false;
                maintenanceTextBlock.Text = bike.KmPerMaintenanceCycle.ToString(); 
            }
            
            electricalImage.Visibility = Visibility.Collapsed; 
            batteryTextBlock.Visibility = Visibility.Collapsed;
            if (bike is EBike)
            {
                electricalImage.Visibility = Visibility.Visible;
                batteryTextBlock.Visibility = Visibility.Visible;

                maintenanceProgressBar.Value = bike.TotalDistance / 75;
                maintenanceTextBlock.Text = $"{bike.TotalDistance} / 7500 km";
            }

            genderImage.Source = _maleBikeImage; 
            if (bike.Gender == Gender.Female)
            {
                genderImage.Source = _femaleBikeImage;
            }
        }

        private void rentOrReturnButton_Click(object sender, RoutedEventArgs e)
        {
            // ToDo: Show a new RentalWindow object as a modal dialog
            //       and pass along the information from the CurrentBike.
            //       After the RentalWindow is closed, update the information in
            //       this window.
            RentalWindow rentalWindow = new RentalWindow(_company.CurrentBike);

            this.Hide();
            rentalWindow.ShowDialog();
            this.Show();
            BindCurrentBike(_company.CurrentBike); 
        }

        private void exportItem_Click(object sender, RoutedEventArgs e)
        {
            // ToDo
            //  Create a report on the desktop of the current user
            //  report name: e.g. Bike_003.html (use Id property)
            //  Use CreateReport from ReportUtils   
        }

        private void exitItem_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
