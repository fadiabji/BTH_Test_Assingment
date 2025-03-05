using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class KataCalculator
    {
        public int add(string numbers)
        {

            if (numbers == "")
                return 0;
            else if (numbers.Length >= 0)
            {
                string[] numbersArray = numbers.Split(new Char[] { ',', '\n', '/', ';', '|' });
                List<int> intsList = new List<int>();
                var potentiallNegativeNums = new List<int>();
                foreach (string n in numbersArray)
                {
                    int numericValue;
                    bool IsNumber = int.TryParse(n, out numericValue);
                    if (IsNumber && numericValue > 0)
                        intsList.Add(numericValue);
                    else if (numericValue < 0)
                        potentiallNegativeNums.Add(numericValue);
                    else
                        intsList.Add(0);
                }
                if (potentiallNegativeNums.Any())
                    throw new Exception("Negatives Not allowed: " + string.Join(",", potentiallNegativeNums));
                int sumResult = intsList.AsQueryable().Sum();
                return sumResult;
            }
            else
                return 0;
        }

    }
}

