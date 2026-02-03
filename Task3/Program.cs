using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            //FileInfo fileinfo = new FileInfo(path);
            String path_read = "";
            String path_write = "";
            string[] all_logs = File.ReadAllLines(path_read); // We read all log entries from input file
            LogEntry[] logs_list = { };
            foreach (String log in all_logs)  // For each entry in the file we do the next things:
            {
                if (log.Contains("|")) // We check what of the two entry formats it is based on the separator
                {
                    string[] temp_log = log.Split('|'); // We split the log into its components using said separator
                    if (temp_log.Length == 5) // If there are five different entries in the log we assume that the calling method isnt empty and keep it as is
                    {
                        logs_list.Append(new LogEntry(temp_log[0], temp_log[1], temp_log[2], temp_log[3], temp_log[4])); // We create an object of the LogEntry class for ease of work with it and add it to a list
                    }
                    else if (temp_log.Length == 4) // If there are only four entries in the log we assume that the calling method is empty and replace it with a string
                    {
                        logs_list.Append(new LogEntry(temp_log[0], temp_log[1], temp_log[2], "DEFAULT", temp_log[3]));
                    }
                }
                else // We do the same for the other format of log entry
                {
                    string[] temp_log = log.Split(' ');
                    if (temp_log.Length == 5)
                    {
                        logs_list.Append(new LogEntry(temp_log[0], temp_log[1], temp_log[2], temp_log[3], temp_log[4]));
                    }
                    else if (temp_log.Length == 4)
                    {
                        logs_list.Append(new LogEntry(temp_log[0], temp_log[1], temp_log[2], "DEFAULT", temp_log[3]));
                    }
                }
                
            }

            foreach (LogEntry log in logs_list) // After we are done converting all the entries from the input file we print the reformated log entries into a new file.
            {
                File.AppendAllText(path_write, log.WriteLog());
            }
        }
    }
    class LogEntry
    {
        private DateTime log_datetime;
        private String logging_level;
        private String calling_method;
        private String message;

        public LogEntry(string date, string time, string logging_level, string calling_method, string message)
        {
            this.log_datetime = DateTime.Parse(date + " " + time); // We combine date and time into a single variable for ease of work
            if (logging_level == "INFORMATION") // We shorten long loggin level entries to the specified format
            {
                this.logging_level = "INFO";
            }
            else if (logging_level == "WARNING")
            {
                this.logging_level = "WARN";
            }
            else
            {
                this.logging_level = logging_level;
            }
            this.calling_method = calling_method; // We keep the calling method as is, as the only exception gets handeled at object creation
            this.message = message; // We keep this unchanged as per the task
        }
        public String WriteLog() // This methods forms a string of the specified format to be written into the new log file
        {
            String output_string = this.log_datetime.ToString("DD-MM-YYYY") + "\t" + this.log_datetime.TimeOfDay + "\t" + this.logging_level + "\t" + this.calling_method + "\t" + this.message;
            return output_string;
        }
    }
}
