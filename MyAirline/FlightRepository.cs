using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAirline
{
    class FlightRepository
    {
        // тут у меня поиск будет, потом
        List<Flight> Flights;
        public FlightRepository()
        {
            Flights = new List<Flight>();
        }

        public void Add(Flight _flight)
        {
            if (!Flights.Contains(_flight))
            {
                Flights.Add(_flight);
            }
            FreeSpace(); 
        }

        private void FreeSpace()
        {
            for (int i = 0; i < Flights.Count; i++)
            {
                if (Flights[i] != null)
                {
                    if ((Flights[i].Status == FlightStatus.Arrived|| Flights[i].Status == FlightStatus.Canceled|| Flights[i].Status == FlightStatus.Unknown)&& Flights[i].Destination.Time.AddDays(1) < DateTime.Now)
                        // условия удаления: отменен, прибыл, неизвестно и т.д. И прошел 1 день с предпологаемой даты прибытия
                    {
                       Flights.RemoveAt(i) ;
                        i--;   
                    }
                }
            }
        }

        public List<Passenger> GetAllPassList()
        {
            List<Passenger> list = new List<Passenger>();
            foreach (var item in Flights)
            {
                list.AddRange(item.GetPassList());
            }
            return list;
        }

        public List<Passenger> SearchByName(string _substring)
        {
            return GetAllPassList().Where(x => (x.Name+ " "+x.Surname).Contains(_substring)).ToList();
        }

        public string PassangerFlights(string _substring)
        {
            var _passFlights = Flights.Where(x => x.GetPassList().Where(y => y.ToString().Contains(_substring)));
            string res = string.Empty;
            foreach (var item in _passFlights)
            {
                res += item.FlightNumber+'\t';
            }
            return res;
            
        }

        public List<Passenger> SearchByPassport(string _substring)
        {
            return GetAllPassList().Where(x => (x.Passport.Contains(_substring))).ToList();
        }

        public void Remove(Flight _flight)
        {
            Flights.Remove(_flight);
        }

        public void Remove(string _flightNumber)
        {
            Remove(GetByFlightNumber( _flightNumber));
        }

        public Flight GetByFlightNumber (string _flightNumber)
            //Тут вылазит эксепшн
        {
            try
            {
                return (Flights.Single((x) => x.FlightNumber.Equals(_flightNumber)));
            }
            catch
            {
                return null;
            }
        }

        public List<Flight> GetOutgoing(string OutgoingPort)
        {
            return Flights.Where((x) => x.Destination.Port.Equals(OutgoingPort)).ToList();
        }

        public List<Flight> GetArrivals(string arrivalPort)
        {
            return Flights.Where((x) => x.Destination.Port.Equals(arrivalPort)).ToList();
        }

        public List<Flight> GetFlights(string arrivalPort, string OutgoingPort)
        {
            return GetArrivals(arrivalPort).Intersect(GetOutgoing(OutgoingPort)).ToList();
        }

        public void PrintFlights()
        {
            string res = String.Empty;
            foreach (var item in Flights)
            {
                res += item.ToString();
            }
            if( res == string.Empty)
            {
                Console.WriteLine("No flights found");
            }
            Console.WriteLine(res);
            
        }

        public List<Flight> SearchByPrice(double _price)
        {
            return Flights.Where(x => (x.Price < _price)).ToList();
        }

    }
}
