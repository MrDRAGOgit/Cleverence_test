using System;
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
            this.log_datetime = DateTime.Parse(date + " " + time);
            if (logging_level == "INFORMATION")
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
            this.calling_method = calling_method;
            this.message = message;
        }
        public void WriteLog()
        {
            String output_string = this.log_datetime.ToString("DD-MM-YYYY") + "\t" + this.log_datetime.TimeOfDay + "\t" + this.logging_level + "\t" + this.calling_method + "\t" + this.message;
        }
    }
}
