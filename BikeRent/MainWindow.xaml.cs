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
        }

        private void rentOrReturnButton_Click(object sender, RoutedEventArgs e)
        {
            // ToDo: Show a new RentalWindow object as a modal dialog
            //       and pass along the information from the CurrentBike.
            //       After the RentalWindow is closed, update the information in
            //       this window.
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
