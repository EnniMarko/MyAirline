using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAirline
{

    class Program
    {
        public static FlightRepository Repo = new FlightRepository(); 
        static void Main()
        {
            //Console.OutputEncoding = Encoding.Unicode;
            ////    public string FlightNumber;
            ////public StationData Destination { get; set; }
            ////public StationData From { get; set; }
            ////public Plane FlightPlane; //места находятся структурой в самолете
            ////public FlightStatus Status;
            //var a = Examples.GetFlight();
            //Console.WriteLine(a);
            //Console.Read();

            // НАДО МНЕ НАДО ПОИСК ПО АЭРОПОРТАМ
            Menu menu = new Menu();
            menu.Start(); 
        }
    }
}
