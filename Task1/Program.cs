using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        private static String input_line;

        static void Main(string[] args)
        {
            
            while (true)
            {
                Console.WriteLine("Please input your string, the programm will determine automatically if it requires compression or decompression:");
                input_line = Console.ReadLine();
                bool check = false;
                foreach (char i in input_line) // Checking if line has any numbers, if it does its going to be a compressed string
                {
                    if (Char.IsNumber(i))
                    {
                        check = true;
                        break;
                    }
                }
                if (check)
                {
                    Console.WriteLine("Uncompressed line:"); // Uncompressing the string and outputting it
                    Uncompress();
                    Console.WriteLine(input_line);
                }
                else
                {
                    Console.WriteLine("Compressed line:"); // Compressing the string and outputting it
                    Compress();
                    Console.WriteLine(input_line);
                }
                
            }
        }
        static void Compress()
        {
            char[] split_string = input_line.ToCharArray(); // Splitting the input string for ease of work
            var compressed_string = new StringBuilder(" ");
            int counter = 1;
            for(int i = 0; i < input_line.Length-1; i++)
            {
                if (split_string[i] == split_string[i + 1]) // Checking if there are same symbols going after one another and counting how many
                {
                    counter++;
                }
                else
                {
                    if (counter > 1) // If there are more than one we write the amount than the symbol
                    {
                        String temp = counter.ToString() + split_string[i];
                        compressed_string.Append(temp);
                    }
                    else // If just one we write just the smybol
                    {
                        String temp = split_string[i].ToString();
                        compressed_string.Append(temp);
                    }
                     counter = 1;
                }
            }
            if (counter > 1) // Separate set of operations required for last symbol or group of symbols
            {
                String temp = counter.ToString() + split_string[input_line.Length-1];
                compressed_string.Append(temp);
            }
            else
            {
                String temp = split_string[input_line.Length-1].ToString();
                compressed_string.Append(temp);
            }
            counter = 1;
            input_line = compressed_string.ToString();
        }
        static void Uncompress()
        {
            char[] split_string = input_line.ToCharArray(); // Splitting the input string for ease of work
            var uncompressed_string = new StringBuilder(" ");
            for (int i = 0; i < input_line.Length - 1; i++)
            {
                if (Char.IsNumber(split_string[i])) // Checking if the symbol is a number or not
                {
                    for (int j = 0; j < Char.GetNumericValue(split_string[i]); j++) // If it is than we add that many of the symbol that follows in the string
                    {
                        uncompressed_string.Append(split_string[i + 1]);
                    }
                    i++; // We make sure to skip the next symbol as it has been already used for the task
                }
                else // If it isnt a number and we havent skipped it that means we add as is
                {
                    uncompressed_string.Append(split_string[i]);
                }
            }
            input_line = uncompressed_string.ToString();
        }
    }
}
