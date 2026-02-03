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
        private static string[] numbers = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0"};

        static void Main(string[] args)
        {
            
            while (true)
            {
                input_line = Console.ReadLine();
                bool check = false;
                foreach (char i in input_line)
                {
                    if (Char.IsNumber(i))
                    {
                        check = true;
                        break;
                    }
                }
                if (check)
                {
                    Console.WriteLine("Uncompressed line:");
                    Uncompress();
                    Console.WriteLine(input_line);
                }
                else
                {
                    Console.WriteLine("Compressed line:");
                    Compress();
                    Console.WriteLine(input_line);
                }
                
            }
        }
        static void Compress()
        {
            char[] split_string = input_line.ToCharArray();
            var compressed_string = new StringBuilder(" ");
            int counter = 1;
            for(int i = 0; i < input_line.Length-1; i++)
            {
                if (split_string[i] == split_string[i + 1])
                {
                    counter++;
                }
                else
                {
                    if (counter > 1)
                    {
                        String temp = counter.ToString() + split_string[i];
                        compressed_string.Append(temp);
                    }
                    else
                    {
                        String temp = split_string[i].ToString();
                        compressed_string.Append(temp);
                    }
                     counter = 1;
                }
            }
            if (counter > 1)
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
            char[] split_string = input_line.ToCharArray();
            var uncompressed_string = new StringBuilder(" ");
            for (int i = 0; i < input_line.Length - 1; i++)
            {
                if (Char.IsNumber(split_string[i]))
                {
                    for (int j = 0; j < Char.GetNumericValue(split_string[i]); j++)
                    {
                        uncompressed_string.Append(split_string[i + 1]);
                    }
                    i++;
                }
                else
                {
                    uncompressed_string.Append(split_string[i]);
                }
            }
            input_line = uncompressed_string.ToString();
        }
    }
}
