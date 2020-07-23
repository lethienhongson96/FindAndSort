using System;
using System.Collections.Generic;
using System.Text;

namespace Person_School
{
    class Person
    {
        #region properties
        public string name { get; set; }
        public bool gender { get; set; }
        public string dateOfBirth { get; set; }
        public string address { get; set; }
        #endregion

        #region constructor

        public Person()
        {

        }

        public Person(string name,bool gender,string date,string address)
        {
            this.name = name;
            this.gender = gender;
            this.dateOfBirth = date;
            this.address = address;
        }
        #endregion

        public virtual void InputInfo()
        {
            Console.WriteLine("enter name: ");
            this.name = Console.ReadLine();

            Console.WriteLine("enter gender: ");
            string genderstr= Console.ReadLine();
            this.gender = genderstr.ToUpper() == "NAM" ? true : false;

            Console.WriteLine("enter date: ");
            this.dateOfBirth = Console.ReadLine();

            Console.WriteLine("enter address: ");
            this.address = Console.ReadLine();
        }

        public virtual string ShowInfo()
        {
            return $"name={this.name} sex={(this.gender?"male":"female")} date={this.dateOfBirth} " +
                $"address={this.address}";
        }

    }
}
