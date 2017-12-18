using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAirline
{
   public  enum ClassesOfService
    {
        Business, Economy
    }
    public enum FlightStatus
    {
        CheckIn, GateClosed, Arrived, DepartedAt, Unknown, Canceled, ExpectedAt, Delayed, InFlight
    }
//enum Airports  //few ukrainian airports
//    {
//        KBP,
//        DNK,
//        IFO,
//        HRK,
//        KHE,
//        IEV,
//        KWG,
//        LWO,
//        ODS,
//        RWN,
//        UMY,
//        TNL
//    }
    public class Examples
    {

        public static Dictionary<int, Seat> Get40EmptySeats(int _amountOfSeats = 40, int _amountOfPremiumSeats = 20)
            // firstly there are premium Seats, then  - economy
        {

            var x = new Dictionary<int, Seat>();
            for (int i = 1; i <= _amountOfSeats; i++)
            {
                if (i <= _amountOfPremiumSeats)
                {
                    x.Add(i, new Seat(ClassesOfService.Business));
                }
                else
                {
                    x.Add(i, new Seat(ClassesOfService.Economy));
                }
            }
            return x;
        }
        
        public static Flight GetFlight(int _amountOfSeats = 40, int _amountOfPremiumSeats = 20)
        {
            Flight a = new Flight()
            {
                FlightNumber = "f5234",
                Destination = new Flight.StationData("DNIPRO", "T", "T5", DateTime.Now),
                From = new Flight.StationData("DNIPRO2", "T", "T5", DateTime.Now.AddHours(-6)),
                FlightPlane = new Plane() { Seats = Get40EmptySeats(_amountOfSeats , _amountOfPremiumSeats) },
                Status  = FlightStatus.ExpectedAt

            };
            return a;
        }
    }

}
//NB! Надо, чтобы статус менялся, когда время меняеться и т.д. (хотя не обязательно)
