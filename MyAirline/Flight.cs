using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAirline
{
    //    Номер полета
    //    Станция отправления
    //Станция прибытия
    //Время Прибытия
    //Время отправления
    //Самолет
    //Статус
    //места  
    
    public class Flight
    {
        public string FlightNumber;
        public StationData Destination;
        public StationData From;
        public Plane FlightPlane; //места находятся структурой в самолете
        public FlightStatus Status;
        public double Price;

        public Flight()
        {

        }
        public Flight(string FlightNumber, StationData Destination, StationData From, Plane FlightPlane, double Price, FlightStatus Status=FlightStatus.ExpectedAt )
        {
            this.FlightNumber = FlightNumber;
            this.Destination = Destination;
            this.From = From;
            this.FlightPlane = FlightPlane; 
            this.Status =  Status;
            this.Price = Price;
        }

        public class StationData
        {
            public string Port { get; set; }
            public string Gate { get; set; }
            public string Terminal { get; set; }
            public DateTime Time;

            public StationData(string port, string terminal, string gate, DateTime time)
            {
                Port = port;
                Gate = gate;
                Terminal = terminal;
                Time = time;
            }
        }
        public override string ToString()
            {
                return $"{FlightNumber} \t {From.Port} -\t {Destination.Port} \nDeparture:{From.Time.ToString("d MMM yyyy HH:mm", new CultureInfo("en-US"))} \t Arrival:{Destination.Time.ToString("d MMM yyyy HH:mm",new CultureInfo("en-US"))} Status: {Status} \n ";
            }
        public void SetStatus()
        {
            Console.WriteLine("Type number: ");
            foreach(var item in Enum.GetValues(typeof(FlightStatus)))
            {
                Console.WriteLine("{0} - {1}" , (int)item, (FlightStatus)item );
            }
            while (true)
            {
                string _perm = Console.ReadLine();
                FlightStatus _flightStatus;
                if (Enum.TryParse(_perm, out _flightStatus))
                {
                    Status = _flightStatus;
                    break;
                }
                else
                {
                    Console.WriteLine("TRY AGAIN");
                }
            }
        }
        public List<Passenger> GetPassList()
        {
            if (FlightPlane.GetPassList() == null)
            {
                return null;
            }
            return FlightPlane.GetPassList();
        }


    }
}
