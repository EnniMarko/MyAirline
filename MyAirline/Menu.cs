using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAirline
{
    class Menu
    //я не успевая сделать возможность задавать сложные маршруты самолета (a - b - c -...)
    {
        public void Start()
        {
            var Repo = Program.Repo;
            Console.WriteLine("Press number of action you want to do:");
            Console.WriteLine(
@"1.Print all flights.
2.	Print all flight’s passengers.
3.	Search passengers by Firstname or Lastname (partial coincidence).	
4	Search passengers by passport (partial coincidence)
5.	Search all flights by price.
6.	Input, deleting and editing  of flights and passengers
c - clear console;

");

            var correct = false;
            while (!correct)
            {
                correct = false;
                ConsoleKeyInfo myKey = Console.ReadKey();
                switch (myKey.KeyChar)
                {
                    case '1':
                        Program.Repo.PrintFlights();//need massage if nothing
                        correct = true;
                        break;
                    case '2':
                        Console.WriteLine("Type Flight number:");
                        string str = Console.ReadLine();
                        var list = new List<Passenger>();
                        try
                        {
                            list = Program.Repo.GetByFlightNumber(Console.ReadLine()).GetPassList();
                        }
                        catch (NullReferenceException ex)
                        { } 
                        if (list.Count == 0)
                        {
                            Console.WriteLine("Flight with this flight number was not found.");
                            break;
                        }
                        foreach (var x in list)
                        {
                            Console.WriteLine(x);
                        }
                        correct = true;
                        break;
                    case '3':
                        // Need to Get Passanger's flights;
                        Console.WriteLine("Type Surname or Name");
                        var permList = Program.Repo.SearchByName(Console.ReadLine());
                        if (permList.Count == 0)
                        {
                            Console.WriteLine("Any passanger was not found");
                            break;
                        }
                        foreach (var item in permList)
                        {
                            Console.WriteLine(item);
                        }
                        correct = true;
                        //Search passengers by Firstname or Lastname (partial coincidence).	
                        break;
                    case '4':
                        permList = Program.Repo.SearchByName(Console.ReadLine());
                        if (permList.Count == 0)
                        {
                            Console.WriteLine("Any passanger was not found");
                            break;
                        }
                        foreach (var item in permList)
                        {
                            Console.WriteLine(item);
                        }
                        // Search passengers by passport (partial coincidence)
                        correct = true;
                        break;
                    case '5':
                        double valueprice;
                        bool isDouble = double.TryParse(Console.ReadLine(), out valueprice);
                        var permFlightList = Program.Repo.SearchByPrice(valueprice);
                        if (permFlightList.Count == 0)
                        {
                            Console.WriteLine("Any flight was not found");
                            break;
                        }
                        foreach (var item in permFlightList)
                        {
                            Console.WriteLine(item);
                        }
                        correct = true;
                        //Search all flights by price.
                        break;
                    case '6':
                        EditingInfo();
                        correct = true;
                        //Input, deleting and editing  of flights and passengers
                        break;
                    case 'c':
                        Console.Clear();
                        Start();
                        break;
                    default:
                        Console.WriteLine("Please try again.");
                        break;
                }
            }
            Start();
        }
        public void EditingInfo()
        {
            Console.WriteLine(@"Choose what you want to do:
1.Edit some fields;
2.Deleting informaton;
3.creating new flights.
");
            while (true)
            {
                ConsoleKeyInfo myKey = Console.ReadKey();
                switch (myKey.KeyChar)
                {
                    case '1':
                        //editing

                        break;
                    case '2':
                        //deleting
                        Deliting();
                        break;
                    case '3':
                        //creating
                        Flight _temp = null;
                        try
                        {
                            _temp = CreatingNewFlight();
                        }
                        catch (Exception ex)
                        {
                            Console.Clear();
                            Console.WriteLine("Your input was not accepted try again!");                            
                        }
                        finally
                        {
                            Start();
                        }
                        Program.Repo.Add(_temp);
                        break;
                }
                Start();
            }
        }
        public Flight CreatingNewFlight() //надо метод "чтослучилось" чтобі понимать где накосячил ввод из сообщения єксепшона

        {
            //                 public Flight(string FlightNumber, StationData Destination, StationData From, Plane FlightPlane, double Price, FlightStatus Status = FlightStatus.ExpectedAt)
            Console.WriteLine("YOU ARE CREATING NEW FLIGHT");
            Console.WriteLine("Input your flight number:");
            var _flightNumber = Console.ReadLine();
            //public StationData(string port, string terminal, string gate, DateTime time)
            Console.WriteLine("Type Outgoing airPort name:");
            var _stationName1 = Console.ReadLine();
            Console.WriteLine("Input terminal:");
            var _terminal1 = Console.ReadLine();
            Console.WriteLine("Gate:");
            var _gate1 = Console.ReadLine();
            Console.WriteLine("type date in format: yyyy-MM-dd HH:mm");
            DateTime _time1 = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            Console.WriteLine("Type arrival airPort name:");
            var _stationName2 = Console.ReadLine();
            Console.WriteLine("Input terminal:");
            var _terminal2 = Console.ReadLine();
            Console.WriteLine("Gate:");
            var _gate2 = Console.ReadLine();
            Console.WriteLine("type date in format: yyyy-MM-dd HH:mm");
            DateTime _time2 = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            Console.WriteLine("Creating of plane in flight: \n ");
            Console.WriteLine("Type number of all seats:");
            int _numberOfAllSeats = int.Parse(Console.ReadLine());
            Console.WriteLine("Type number of premium seats (less than {0}):", _numberOfAllSeats);
            int _numberOfPremiumSeats = int.Parse(Console.ReadLine());
            Plane _tempPlane = new Plane(_numberOfAllSeats, _numberOfPremiumSeats);
            Console.WriteLine("Type price for economy seats(Business price = price*1,5) USE ',' ,not '.'! ");
            double _price = double.Parse(Console.ReadLine());
            //Destination
            var _tempFlight = new Flight(_flightNumber, new Flight.StationData(_stationName2, _terminal2, _gate2, _time2), new Flight.StationData(_stationName1, _terminal1, _gate1, _time1), _tempPlane, _price);
            Console.WriteLine("set flight status EXEPTED AT?\n PRESS Y -yes N - no");
            bool exit = false;
            while (true)
            {

                if (exit) break; 
                switch (Console.ReadKey().KeyChar)
                {
                    case 'y':
                        exit = true;
                         break;
                    case 'n':
                        {
                            _tempFlight.SetStatus();
                            exit = true;
                        }
                        break;
                    default:
                        Console.WriteLine("Try again, please:");
                        break;
                }

            }
            Console.WriteLine("Flight was added sucessfully!");
            return _tempFlight;
        }
        public void Deliting()
        {

        }
    }
}
