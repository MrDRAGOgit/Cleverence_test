using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    static class server
    {
        static private int count = 0;
        static private bool locked_for_write = false;  // Lock for trying to write or read
        static private Queue<String> id_list;  // Queue for users trying to write
        public static void GetCount()
        {
            if (locked_for_write)  // Checking if able not able to read
            {
                while (locked_for_write) // Waiting untill its possible to read again
                {
                    Task.Delay(100).Wait();
                }
            }

            if (!locked_for_write) // Reading once able too
            {
                Console.WriteLine("given count to user");
            }
        }
        public static void AddToCount(String request_id)
        {
            id_list.Enqueue(request_id); // Adding user to write queue
            if (locked_for_write) // Checking if able to write
            {
                while (locked_for_write) // Waiting untill its possible to write again
                {
                    Task.Delay(1000).Wait();
                }
            }

            if (!locked_for_write) // Writing once able too
            {
                locked_for_write = true; // Locking write and read for other users
                String worked_id = id_list.Dequeue(); // The user whose order it is to write, writes
                Console.WriteLine("count was changed by:", worked_id);
                locked_for_write = false; // Unlocking once the user has done its writing
            }
        }
    }
}
