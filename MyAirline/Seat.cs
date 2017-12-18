using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAirline
{
//    класс,
//пассажир.
// КАК СДЕЛАТЬ, ЧТОБЫ НЕЛЬЗЯ БЫЛО "ПЕРЕЗАПИСАТЬ ЧЕЛОВЕКА?"

    public class Seat
    {
        public Seat(ClassesOfService _service)
        {
            Service = _service;
        }
        public Seat(ClassesOfService _service, Passenger _passanger)
        {
            Service = _service;
            PassangerOnSeat = _passanger;
        }

        public bool SetPassanger(Passenger _passanger)
        {
            if (PassangerOnSeat == null)
            {
                PassangerOnSeat = _passanger;
                return true;
            }
            return false;
        }
        public ClassesOfService Service { get; set; }
        public Passenger PassangerOnSeat;
        
    }
}
