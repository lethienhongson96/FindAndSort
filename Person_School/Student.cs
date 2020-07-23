using System;
using System.Collections.Generic;
using System.Text;

namespace Person_School
{
    class Student : Person
    {
        public string id { get; set; }
        public double avgScore { get; set; }
        public string email { get; set; }

        public override void InputInfo()
        {
            base.InputInfo();


        }
    }
}
