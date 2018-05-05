using System;
using System.Collections.Generic;
using System.Text;

namespace DeadFace.Data
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
    }
    public class Passport
    {
        public string serial;
        public string number;
        public DateTime birthDate;
        public string ufms;
    }
}
