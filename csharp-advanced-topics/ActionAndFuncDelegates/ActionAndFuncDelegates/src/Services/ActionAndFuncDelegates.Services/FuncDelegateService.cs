using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegates.Services
{
    public class FuncDelegateService
    {
        public FuncDelegateService()
        {
                
        }

        public Func<int, int, int>? AdditionFunc;
        public Func<int, int, int>? SubtractionFunc;
        public Func<int, int, int>? MultiplicationFunc;
        public Func<int, int, double>? DivisionFunc;

        public Func<double, double>? CalculateTitheFunc { get; set; }
        public Func<string, bool>? EventFilterFunc { get; set; }
        public Predicate<string>? EventFilterBySearchTextFunc { get; set; }


        public int Add(int a, int b)
        {
            return AdditionFunc?.Invoke(a, b) ?? throw new InvalidOperationException("AdditionFunc is not defined.");
        }

        public int Subtract(int a, int b)
        {
            return SubtractionFunc?.Invoke(a, b) ?? throw new InvalidOperationException("SubtractionFunc is not defined.");
        }

        public int Multiply(int a, int b)
        {
            return MultiplicationFunc?.Invoke(a, b) ?? throw new InvalidOperationException("MultiplicationFunc is not defined.");
        }

        public double Divide(int a, int b)
        {
            return DivisionFunc?.Invoke(a, b) ?? throw new InvalidOperationException("DivisionFunc is not defined.");
        }

        public double CalculateTithe(double earnings)
        {
            if (CalculateTitheFunc == null)
            {
                throw new InvalidOperationException("CalculateTitheFunc is not defined.");
            }

            return CalculateTitheFunc(earnings);
        }

        // Method to filter events based on the provided Func delegate
        public List<string> FilterEvents(Func<string, bool> filterCriteria, List<string> registeredEvents)
        {
            if (filterCriteria == null)
            {
                throw new InvalidOperationException("FilterCriteria is not set.");
            }

            // Perform filtering logic on registeredEvents list using the provided Func delegate
            return registeredEvents.Where(filterCriteria!).ToList();
        }

        public List<string> FilterEventsBySearchText(Predicate<string> predicate, List<string> registeredEvents)
        {
            // Check if the predicate is not null
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate), "Predicate is not set.");
            }

            // Perform filtering logic on registeredEvents list using the provided Predicate delegate
            return registeredEvents.FindAll(predicate);
        }




    }
}
