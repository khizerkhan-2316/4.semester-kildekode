using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_7._4
{
    internal class Person : INotifyPropertyChanged
    {

        private string name;
        private double weight;
        private int age;
        private int score;
        private bool accepted;

        public string Name
        {

            get

            { return name; }

            set

            {
                name = value;
                PropertyChangedEvent("Name");
            }



        }

        private void PropertyChangedEvent(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public double Weight
        {
            get => weight; set
            {
                weight = value;
                PropertyChangedEvent("Weight");


            }
        }

        public int Age
        {
            get => age; set
            {
                age = value;
                PropertyChangedEvent("Age");

            }
        }

        public int Score
        {
            get => score; set
            {
                score = value;
                PropertyChangedEvent("Score");

            }
        }
        public bool Accepted
        {
            get => accepted; set
            {

                accepted = value;
                PropertyChangedEvent("Accepted");

            }
        }


        public Person(string name, double weight, int age)
        {
            Name = name;
            Weight = weight;
            Age = age;
            Accepted = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"{Name}, {Age}, {Weight}, {Score}, {Accepted}";
        }


    }
}
