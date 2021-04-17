using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Store_WPG
{
    public class Product: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }


        public int Id{ get; set; }
        static private int staticId { get; set; } = 0;
        public Product()
        {
            Id = ++staticId;
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }
        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged(); }
        }
        private string imagePath;

        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; OnPropertyChanged(); }
        }


    }
}
