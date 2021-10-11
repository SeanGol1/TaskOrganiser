using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOrgraniser
{
    //public enum TimeScale
    //{
    //    10, 20, 30+
    //};
    public class Task
    {        
        public string Name { get; set; }
        public int Priority { get; set; }
        public int TimeScale { get; set; }
        public string Notes { get; set; }

        public Task(string _name, int _pr, int _time,string _notes)
        {
            Name = _name;
            Priority = _pr;
            TimeScale = _time;
            Notes = _notes;
        }
    }
}
