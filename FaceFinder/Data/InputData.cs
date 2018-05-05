using System;

namespace FaceFinder.Data
{
    public class InputData
    {
        public string phone;
        public Name name;
        public Passport passport;
    }
    public class Name
    {
        public string firstName;
        public string lastName;
        public string patronymic;
        public override string ToString()
        {
            return lastName + " " + firstName + " " + patronymic;
        }
    }
    public class Passport
    {
        public string serial;
        public string number;
        public DateTime birthDate;
        public string ufms;
    }
}
