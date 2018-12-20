using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    using System;
    using System.Collections.Generic;

    public partial class Car
    {
        public DateTime RentalDate{ get; set; }
        public DateTime ReturnDate { get; set; }

        public override string ToString()
            //over ride to string method
            //returns some info about the car
        {
            return string.Format("Make of Car: {0}"+ "\r\n Model: {1}" + "\r\n  Size: {2}", Make,Model,Size);
        }

        public string GetDetails()
        //returns more info about the car including rental dates,dates are formated to short date format
        {
            return string.Format("Make of Car: {0}" + "\r\n Model: {1}" + "\r\n  Size: {2}" + "\r\n  RentalDate: {3}" + "\r\n  ReturnDate: {4}", Make, Model, Size, RentalDate.ToShortDateString(), ReturnDate.ToShortDateString());
        }
    }
}
