﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deferred
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> lCars = new List<Car>
            {
                new Car{ Brand = "BMW", Speed = 50},
                new Car{ Brand = "Audi", Speed = 40},
                new Car{ Brand = "Ford", Speed = 30},
                new Car{ Brand = "Toyota", Speed = 35},
            };

            IEnumerable<Car> lFastestCars = lCars.Where(c => c.Speed > 38);
            Car lFastestCar = lCars.Where(c => c.Speed > 45).FirstOrDefault();
            List<Car> lFastestCarList = lCars.Where(c => c.Speed > 30).ToList();
            bool lSlowestCars = lCars.Any(c => c.Speed > 50);
            IEnumerable<string> lFastestCarNames = lCars.Where(c => c.Speed > 38).Select(s => s.Brand);

            Console.WriteLine($"{Environment.NewLine}Filtered with Where");
            DisplayCarsList(lFastestCars);

            Console.WriteLine($"{Environment.NewLine}Selected with ToList");
            DisplayCarsList(lFastestCarList);

            Console.WriteLine($"{Environment.NewLine}Selected with FirstOrDefault");
            DisplayCar(lFastestCar);

            Console.WriteLine($"{Environment.NewLine}Filtered with Any");
            Console.WriteLine(lSlowestCars);

            Console.WriteLine($"{Environment.NewLine}Selected with Select");
            DisplayCarNamesList(lFastestCarNames);

            lCars.Add(new Car { Brand = "Mercedes", Speed = 60 });
            Console.WriteLine("--------------------------------------------------------------------------");


            Console.WriteLine($"{Environment.NewLine}Filtered with Where after adding");
            DisplayCarsList(lFastestCars);

            Console.WriteLine($"{Environment.NewLine}Selected with ToList after adding");
            DisplayCarsList(lFastestCarList);

            Console.WriteLine($"{Environment.NewLine}Selected with FirstOrDefault after adding");
            DisplayCar(lFastestCar);

            Console.WriteLine($"{Environment.NewLine}Filtered with Any after adding");
            Console.WriteLine(lSlowestCars);

            Console.WriteLine($"{Environment.NewLine}Selected with Select after adding");
            DisplayCarNamesList(lFastestCarNames);

            IEnumerable<int> _withClass = GetRandomNumbers(5);
            Console.WriteLine("--------------------------------------------------------------------------");
            foreach (int num in _withClass)
            {
                Console.WriteLine(num);
            }

            IEnumerable<int> _withYield = GetRandomNumbersWithYeild(5);
            Console.WriteLine("--------------------------------------------------------------------------");
            foreach (int num in _withYield)
            {
                Console.WriteLine(num);
            }

            IEnumerable<int> _withList = GetRandomNumbersWithList(5);
            Console.WriteLine("--------------------------------------------------------------------------");
            foreach (int num in _withList)
            {
                Console.WriteLine(num);
            }

            Console.ReadLine();
        }

        private static IEnumerable<int> GetRandomNumbers(int count)
        {
            GetRadnomNumbersGenerated lNums = new GetRadnomNumbersGenerated();
            lNums._count = count;
            Console.WriteLine("Inside GetRandomNumbers(int count) method");
            return lNums;
        }

        private static IEnumerable<int> GetRandomNumbersWithYeild(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Inside loop in GetRandomNumbersWithYeild(int count) method");
                yield return new Random().Next();
            }
        }

        private static IEnumerable<int> GetRandomNumbersWithList(int count)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Inside loop in GetRandomNumbersWithList(int count) method");
                list.Add(new Random().Next());
            }
            return list;
        }

        private static void DisplayCarsList(IEnumerable<Car> carsList)
        {
            foreach (var item in carsList)
            {
                Console.WriteLine($"{item.Brand}: {item.Speed}");
            }
        }

        private static void DisplayCarNamesList(IEnumerable<string> carsList)
        {
            foreach (var item in carsList)
            {
                Console.WriteLine(item);
            }
        }

        private static void DisplayCar(Car car)
        {
            Console.WriteLine($"{car.Brand}: {car.Speed}");

        }
    }
}
