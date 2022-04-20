using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace INPC
{
    internal class PersonModel : ObservableObject
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        public PersonModel()
        {
            Task.Run(() =>
            {
                while(true)
                {
                    Random r = new();
                    Name = r.Next(1, 1000).ToString();
                    Debug.WriteLine($"Name: {Name}");
                    Thread.Sleep(500);
                }
            });
        }

    }
}
