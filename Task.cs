using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOrgraniser
{

    public class Task
    {        
        public string Name { get; set; }
        public int Priority { get; set; }
        public int TimeScale { get; set; }
        public string Notes { get; set; }
        public DateTime DueDate { get; set; }

        //Creating New
        public Task(string _name, int _pr, int _time,DateTime _date)
        {
            Name = _name;
            Priority = _pr;
            TimeScale = _time;             
            DueDate = _date;
        }

        //Loading Tasks
        public Task(string _name, int _pr, int _time,string _notes, DateTime _date)
        {
            Name = _name;
            Priority = _pr;
            TimeScale = _time;
            Notes = _notes;
            DueDate = _date;
        }
    }
}
