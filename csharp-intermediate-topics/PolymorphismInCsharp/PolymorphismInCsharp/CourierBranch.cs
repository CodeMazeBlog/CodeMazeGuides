using System;
using System.Collections.Generic;
using Polymorphism_v2;

namespace Polymorphism
{
    public class CourierBranch
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Package> packages { get; set; }

        public CourierBranch(string name, string address)
        {
            Name = name;
            Address = address;
            packages = new List<Package>();
        }

        public void AddPackage(Package newPackage)
        {
            packages.Add(newPackage);
        }

        public decimal GetTotalCost()
        {
            decimal totalCost = 0;
            foreach (var package in packages)
            {
                totalCost += package.GetDeliveryCost();
            }
            return totalCost;
        }

        public void PrintList()
        {
            foreach (var package in packages)
            {
                Console.WriteLine("Cost: " + package.GetDeliveryCost());
                Console.WriteLine("Delivery date: " + package.GetDeliveryDate());
            }
        }
    }
}
