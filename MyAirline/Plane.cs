using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAirline
{
    
    //количество мест по престижности

    public struct Plane
    {
        public Plane( int _amountOfAllSeats, int _amountOfPremiumSeats)
        {
            var x = new Dictionary<int, Seat>();
            for (int i = 1; i <= _amountOfAllSeats; i++)
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
            Seats = x;
        }
        public Dictionary<int, Seat> Seats;
        public void AddPassanger(int Number, Passenger _passanger)
        {
            if (!Seats[Number].SetPassanger(_passanger))
            {
                Console.WriteLine("ADDING OF PASSANGER WAS UNSUCESSFUL");
            }
            else
            {
                Console.WriteLine("PASSANGER WAS ADDED SUCESSFULL");
            }
        }
        public List<Passenger> GetPassList()
        {
            var list = new List<Passenger>();
            foreach (var item in Seats)
            {
                if (item.Value.PassangerOnSeat != null)
                {
                    list.Add(item.Value.PassangerOnSeat);
                }
            } 
            return list;
        }
    }
}
