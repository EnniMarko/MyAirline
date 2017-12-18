using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAirline
{
//    Пасспорт
//    страна по паспорту
//    имя, фамилия
//  дата рождения,

    public class Passenger
    {
        
        public string   Passport { get; set; }
        public string   Nationality { get; set; }
        public string   Name  { get; set; }
        public string   Surname { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Passenger(string Passport, string Nationality, string Name, string Surname, DateTime DateOfBirth)
        {
            this.Passport = Passport;
            this.Nationality = Nationality;
            this.Name = Name;
            this.Surname = Surname;
            this.DateOfBirth = DateOfBirth;
        }
        public override string ToString()
        {
            return $"{Name} {Surname} {DateOfBirth.ToString("d/MM/yyyy")},  Passport:{Nationality},{Passport}  ";
        }
    }
}
