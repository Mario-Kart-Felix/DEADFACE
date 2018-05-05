﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeadFace;
using DeadFace.Data;
using DeadFace.Finders;
using  Newtonsoft;
using Newtonsoft.Json;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            InputData[] test_data = new InputData[]
            {
                new InputData
                {
                    name = new Name
                    {
                      firstName  = "Вадим",
                      lastName = "Иванов",
                      patronymic = "Иванович"
                    },
                    phone = "123"
                },
                new InputData
                {
                    name = new Name
                    {
                        firstName  = "Егор",
                        lastName = "Воронов",
                        patronymic = "Иванович"
                    }
                }
            };
            foreach (var data in test_data)
            {
                var main = new MainFinder();
                main.Input = data;
                main.Find();
                Console.WriteLine("INPUT:");
                Console.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented));
                Console.WriteLine("OUTPUT:");
                Console.WriteLine(JsonConvert.SerializeObject(main.Output, Formatting.Indented));
                Console.WriteLine(Environment.NewLine);
            }
            Console.Read();
        }
    }
}