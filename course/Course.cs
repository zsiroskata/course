using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course
{
    internal class Course
    {
        public string Name { get; set; }
        public bool Gender { get; set; }
        public int Payment { get; set; }
        public int[] Result { get; set; }
        public Course(string data) 
        {
            var s = data.Split(';');
            Name = s[0];
            Gender = s[1] == "m";
            Payment = Convert.ToInt32(s[2]);

            Result = s.Skip(3).Select(int.Parse).ToArray();
        }
        public double Backend()
        {
            return Result[3];
        }
    }
}
