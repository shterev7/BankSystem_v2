using System;
using System.Collections.Generic;

namespace BankSystem_v2.Models
{
    public class CurrencyConverter
    {
        public List<Tuple<string, string, double>> Coefficients { get; private set; }

        public CurrencyConverter()
        {
            Coefficients = new List<Tuple<string, string, double>>
            {
                new Tuple<string, string, double>("BGN", "USD", 0.540396),
                new Tuple<string, string, double>("USD", "BGN", 1.85049482),
                new Tuple<string, string, double>("BGN", "EUR", 0.511186787),
                new Tuple<string, string, double>("EUR", "BGN", 1.9562321),
                new Tuple<string, string, double>("USD", "EUR", 0.945948503),
                new Tuple<string, string, double>("EUR", "USD", 1.05714),
                new Tuple<string, string, double>("BGN", "GBP", 0.43313803),
                new Tuple<string, string, double>("GBP", "BGN", 2.30873286),
                new Tuple<string, string, double>("USD", "GBP", 0.801519681),
                new Tuple<string, string, double>("GBP", "USD", 1.24763),
                new Tuple<string, string, double>("EUR", "GBP", 0.847318516),
                new Tuple<string, string, double>("GBP", "EUR", 1.18019373),
                new Tuple<string, string, double>("BGN", "BGN", 1),
                new Tuple<string, string, double>("USD", "USD", 1),
                new Tuple<string, string, double>("EUR", "EUR", 1),
                new Tuple<string, string, double>("GBP", "GBP", 1),

            };
        }
    }
}