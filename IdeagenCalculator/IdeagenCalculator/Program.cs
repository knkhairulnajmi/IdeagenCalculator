/* SUMMARY
 Name: Khairul Najmi Mazupi
 Time Taken: 1 Hour 30 Minutes
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace IdeagenCalculator
{
    class Program
    {
        public static void Main(string[] args)
        {
            var program = new Program();
            double finalResult = program.Calculate("10 - ( 2 + 3 * ( 7 - 5 ) )");
            Console.WriteLine($"The result is: {finalResult}");
        }

        public double Calculate(string sum)
        {
            //Your code starts here
            List<string> sumList = sum.Split(" ").ToList();
            double result = 0;

            for (int i = 0; i < sumList.Count; i++)
            {
                // Check for bracket
                if (sumList[i] == "(" && sumList[i + 1] != "(")
                {
                    for (int j = i + 1; j < sumList.Count; j++)
                    {
                        // Check for nested bracket
                        if (sumList[j] == "(" && sumList[j + 1] != "(")
                        {
                            for (int k = j + 1; k < sumList.Count; k++)
                            {
                                // Handle division for nested bracket
                                if (sumList[k] == "/" && sumList[k + 1] != "(" && sumList[k + 1] != ")" && sumList[k - 1] != "(" && sumList[k - 1] != ")")
                                {
                                    result = Convert.ToDouble(sumList[k - 1]) / Convert.ToDouble(sumList[k + 1]);

                                    sumList[k + 1] = result.ToString();
                                    sumList.RemoveRange(k - 1, 2);
                                    k -= 2;
                                }
                            }

                            for (int k = j + 1; k < sumList.Count; k++)
                            {
                                // Handle multiply for nested bracket
                                if (sumList[k] == "*" && sumList[k + 1] != "(" && sumList[k + 1] != ")" && sumList[k - 1] != "(" && sumList[k - 1] != ")")
                                {
                                    result = Convert.ToDouble(sumList[k - 1]) * Convert.ToDouble(sumList[k + 1]);

                                    sumList[k + 1] = result.ToString();
                                    sumList.RemoveRange(k - 1, 2);
                                    k -= 2;
                                }
                            }

                            for (int k = j + 1; k < sumList.Count; k++)
                            {
                                // Handle add for nested bracket
                                if (sumList[k] == "+" && sumList[k + 1] != "(" && sumList[k + 1] != ")" && sumList[k - 1] != "(" && sumList[k - 1] != ")")
                                {
                                    result = Convert.ToDouble(sumList[k - 1]) + Convert.ToDouble(sumList[k + 1]);

                                    sumList[k + 1] = result.ToString();
                                    sumList.RemoveRange(k - 1, 2);
                                    k -= 2;
                                }
                            }

                            for (int k = j + 1; k < sumList.Count; k++)
                            {
                                // Handle subtract for nested bracket
                                if (sumList[k] == "-" && sumList[k + 1] != "(" && sumList[k + 1] != ")" && sumList[k - 1] != "(" && sumList[k - 1] != ")")
                                {
                                    result = Convert.ToDouble(sumList[k - 1]) - Convert.ToDouble(sumList[k + 1]);

                                    sumList[k + 1] = result.ToString();
                                    sumList.RemoveRange(k - 1, 2);
                                    k -= 2;
                                }
                            }

                            for (int k = j + 1; k < sumList.Count; k++)
                            {
                                if (sumList[k - 1] == "(" && sumList[k + 1] == ")")
                                {
                                    sumList[k + 1] = sumList[k];
                                    sumList.RemoveRange(k - 1, 2);
                                }
                            }
                        }
                    }

                    for (int j = i + 1; j < sumList.Count; j++)
                    {
                        // Handle division for bracket
                        if (sumList[j] == "/" && sumList[j + 1] != "(" && sumList[j + 1] != ")" && sumList[j - 1] != "(" && sumList[j - 1] != ")")
                        {
                            result = Convert.ToDouble(sumList[j - 1]) / Convert.ToDouble(sumList[j + 1]);

                            sumList[j + 1] = result.ToString();
                            sumList.RemoveRange(j - 1, 2);
                            j -= 2;
                        }
                    }

                    for (int j = i + 1; j < sumList.Count; j++)
                    {
                        // Handle multiply for bracket
                        if (sumList[j] == "*" && sumList[j + 1] != "(" && sumList[j + 1] != ")" && sumList[j - 1] != "(" && sumList[j - 1] != ")")
                        {
                            result = Convert.ToDouble(sumList[j - 1]) * Convert.ToDouble(sumList[j + 1]);

                            sumList[j + 1] = result.ToString();
                            sumList.RemoveRange(j - 1, 2);
                            j -= 2;
                        }
                    }

                    for (int j = i + 1; j < sumList.Count; j++)
                    {
                        // Handle add for bracket
                        if (sumList[j] == "+" && sumList[j + 1] != "(" && sumList[j + 1] != ")" && sumList[j - 1] != "(" && sumList[j - 1] != ")")
                        {
                            result = Convert.ToDouble(sumList[j - 1]) + Convert.ToDouble(sumList[j + 1]);

                            sumList[j + 1] = result.ToString();
                            sumList.RemoveRange(j - 1, 2);
                            j -= 2;
                        }
                    }

                    for (int j = i + 1; j < sumList.Count; j++)
                    {
                        // Handle subtract for bracket
                        if (sumList[j] == "-" && sumList[j + 1] != "(" && sumList[j + 1] != ")" && sumList[j - 1] != "(" && sumList[j - 1] != ")")
                        {
                            result = Convert.ToDouble(sumList[j - 1]) - Convert.ToDouble(sumList[j + 1]);

                            sumList[j + 1] = result.ToString();
                            sumList.RemoveRange(j - 1, 2);
                            j -= 2;
                        }
                    }

                    for (int j = i + 1; j < sumList.Count; j++)
                    {
                        if (sumList[j - 1] == "(" && sumList[j + 1] == ")")
                        {
                            sumList[j + 1] = sumList[j];
                            sumList.RemoveRange(j - 1, 2);
                        }
                    }

                    i = -1;
                }
            }

            for (int i = 0; i < sumList.Count; i++)
            {
                // Handle division without bracket
                if (sumList[i] == "/" && sumList[i + 1] != "(")
                {
                    result = Convert.ToDouble(sumList[i - 1]) / Convert.ToDouble(sumList[i + 1]);

                    sumList[i + 1] = result.ToString();
                    sumList.RemoveRange(i - 1, 2);
                    i -= 2;
                }
            }

            for (int i = 0; i < sumList.Count; i++)
            {
                // Handle multiply without bracket
                if (sumList[i] == "*" && sumList[i + 1] != "(")
                {
                    result = Convert.ToDouble(sumList[i - 1]) * Convert.ToDouble(sumList[i + 1]);

                    sumList[i + 1] = result.ToString();
                    sumList.RemoveRange(i - 1, 2);
                    i -= 2;
                }
            }

            for (int i = 0; i < sumList.Count; i++)
            {
                // Handle add without bracket
                if (sumList[i] == "+" && sumList[i + 1] != "(")
                {
                    result = Convert.ToDouble(sumList[i - 1]) + Convert.ToDouble(sumList[i + 1]);

                    sumList[i + 1] = result.ToString();
                    sumList.RemoveRange(i - 1, 2);
                    i -= 2;
                }
            }

            for (int i = 0; i < sumList.Count; i++)
            {
                // Handle subtract without bracket
                if (sumList[i] == "-" && sumList[i + 1] != "(")
                {
                    result = Convert.ToDouble(sumList[i - 1]) - Convert.ToDouble(sumList[i + 1]);

                    sumList[i + 1] = result.ToString();
                    sumList.RemoveRange(i - 1, 2);
                    i -= 2;
                }
            }

            return Convert.ToDouble(sumList[0]);
        }
    }
}
