using System;

namespace BikeRent
{
    public class Rental
    {
        public Rental(DateTime startDate, int days, double pricePerDay, string customer)
        {
            //ToDo: complete constructor
            // EndDate is calculated from startDate and days
            // Price = Use method CalculatePrice from class BusinessRules
            StartDate = startDate;
            Customer = customer;
            EndDate = startDate + TimeSpan.FromDays(days);
            Price = BusinessRules.CalculatePrice(days, pricePerDay);
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Customer { get; set; }
        public double Distance { get; set; }
        public double Price { get; set; }
    }
}
