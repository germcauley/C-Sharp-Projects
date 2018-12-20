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
using System.Data.Entity;


namespace CarRental
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //connect to database
        CarRental__S00174412Entities db = new CarRental__S00174412Entities();
        //decalre string to be used later
        string result;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //load default image
            image.Source = new BitmapImage(new Uri("/images/car.jpg", UriKind.Relative));
            //load size types to combo box
            comboCarType.ItemsSource = Enum.GetNames(typeof(CarType));




          
        }       




        //enum for car type
        public enum CarType { Small, Medium, Large };

        private void lstBoxAvailableCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           //create new car object
            Car c = lstBoxAvailableCars.SelectedItem as Car;

           //decalre some variables used for car object
            string one = c.Model;     
            int orderID = c.ID;
            DateTime start = new DateTime();
            DateTime end = new DateTime();

            //car size obtained from the combobox
            string carSize = comboCarType.SelectedItem.ToString();


            start = Convert.ToDateTime(dateStart.Text);
            end = Convert.ToDateTime(dateEnd.Text);

            //rental date is part of the partial class used for bookings
            c.RentalDate = start;
            c.ReturnDate = end;

            //if a car has been selected
            if (orderID > 0)
            {
                //returns the car equal to the id of selected car
                string query2 = (from cc in db.Cars
                                 where cc.ID == orderID
                                 select cc).First().GetDetails(); //uses getDetails method            
                       
                //the query result is assigned to the result string      
                result = query2;
                //the textbox is populated with the data
                txtSelectedCar.Text = result;


                //when a car is selected an image of the car is displayed
                //change image display
                if (orderID == 1)
                {
                    image.Source = new BitmapImage(new Uri("/images/Bmw.jpg", UriKind.Relative));
                }
                else if (orderID == 2)
                {
                    image.Source = new BitmapImage(new Uri("/images/Duster.jpg", UriKind.Relative));
                }                   
                else if (orderID == 3)
                {
                    image.Source = new BitmapImage(new Uri("/images/Mustang.jpg", UriKind.Relative));
                }
                else if (orderID == 4)
                {
                    image.Source = new BitmapImage(new Uri("/images/Corsa.jpg", UriKind.Relative));
                }
                else if (orderID == 5)
                {
                    image.Source = new BitmapImage(new Uri("/images/Clio.jpg", UriKind.Relative));
                }
                else if (orderID == 6)
                {
                    image.Source = new BitmapImage(new Uri("/images/Avensis.jpg", UriKind.Relative));
                }
                else if (orderID == 7)
                {
                    image.Source = new BitmapImage(new Uri("/images/Yaris.jpg", UriKind.Relative));
                }
                else if (orderID == 8)
                {
                    image.Source = new BitmapImage(new Uri("/images/Polo.jpg", UriKind.Relative));
                }
                else if (orderID == 9)
                {
                    image.Source = new BitmapImage(new Uri("/images/Passat.jpg", UriKind.Relative));
                }
                else 
                {
                    image.Source = new BitmapImage(new Uri("/images/Golf.jpg", UriKind.Relative));
                }
               

            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {//searches for cars that fit the time and size choices input by the user
            
            //this query returns the car make and model to the list
            //var query1 = from c in db.Cars
            //             orderby c.ID
            //             select c.Make + " " + c.Model;
                      

           
            //create DateTime objects
            DateTime start = new DateTime();
            DateTime end= new DateTime();

           
          
            string carSize = comboCarType.SelectedItem.ToString();

            start = Convert.ToDateTime(dateStart.Text);
            end = Convert.ToDateTime(dateEnd.Text);

           
            var query3 = from c in db.Cars
                         join b in db.Bookings on c.ID equals b.CarID                      
                         where (start < b.StartDate && end < b.StartDate && c.Size == carSize) || (start > b.EndDate && end > b.EndDate && c.Size == carSize)
                         select c;                       
            //returns cars whose booked dates dont overlap with those input by the user. So User start and end dates will be less than or greater than the start/end booking dates in the booking table
            //Issue arises when more than one booking made with the same car havnt worked out a way to compare dates for that.

          
            lstBoxAvailableCars.ItemsSource = query3.ToList().Distinct();
           
        }


        //Confirm booking
        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            //using new connection to database called context
            using (var context = new CarRental__S00174412Entities())
            {
                
                //create new car object
                Car c = lstBoxAvailableCars.SelectedItem as Car;

                //decalre datetime 
                DateTime start = new DateTime();
                DateTime end = new DateTime();

                start = Convert.ToDateTime(dateStart.Text);
                end = Convert.ToDateTime(dateEnd.Text);
                //assign dates to the car object
                c.RentalDate = start;
                c.ReturnDate = end;
               

                //create a booking
                Booking newBooking = new Booking
                {
                    //input properties
                    CarID = c.ID,
                    StartDate = start,
                    EndDate = end
                };
                //add booking to the Bookings table
                context.Bookings.Add(newBooking);
                //save it
                context.SaveChanges();

            }
            //display a confrimation message in the messagebox
            MessageBox.Show("Booking Confirmed! \n"+result);

            Application.Current.Shutdown();
            System.Windows.Forms.Application.Restart();
        }




    

        private void txtSelectedCar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
