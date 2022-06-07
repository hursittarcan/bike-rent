using System;

namespace BikeRent
{
    public static class BusinessRules // this should remain static!
    {
        // ToDo: implement CalculatePrice
        //       1 day rent    => full price
        //       2 day rent    => 20% discount
        //       > 2 day rent  => 30% discount
        public static double CalculatePrice(int days, double price)
        {
            if (days == 1)
            {
                return price;
            }
            else if (days == 2)
            {
                return days * (price * 0.8); 
            }
            else if (days > 2)
            {
                return days * (price * 0.7);
            }
            else
            {
                throw new ArgumentException("Wrong arguments"); 
            }
        }

        // ToDo: implement CheckStartDate(string text)
        //       should be of format dd/mm/jjjj
        //       should not be in the past
        //       throws a ValidationException if these rules are violated
    }
}