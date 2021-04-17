using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace Store_WPG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public List<Product> products = new List<Product> {
        new Product{
        Name="Coca-cola", Price=0.50,ImagePath="CocaCola.png"
        },
            new Product{
        Name="Fanta", Price=0.50,ImagePath="Fanta.png"
        },
              new Product{
        Name="Sprite", Price=0.60,ImagePath="Sprite.png"
        },
              new Product{
        Name="7 UP", Price=0.80,ImagePath="7up.png"
        },
        new Product{
        Name="Fuse tea classic", Price=0.80,ImagePath="FuseTea1.png"
        },
        new Product{
        Name="Fuse tea manqo", Price=0.80,ImagePath="Manqo.png"
        },
        new Product{
        Name="Beer", Price=0.80,ImagePath="beer.png"
        },
        };
        private object openFileDialog;

        public MainWindow()
        {
            InitializeComponent();
            ListBox.ItemsSource = (products);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var product = ListBox.SelectedItem as Product;
            if (ListBox.SelectedItem != null)
            {
                EditImage.Visibility = Visibility.Visible;
                EditImage.Source = new BitmapImage(new Uri(product.ImagePath, UriKind.Relative));
                NameOfProductTxtBox.Text = product.Name;
                PriceOfProductTxtBox.Text = product.Price.ToString();
            }
            else
            {
                System.Windows.MessageBox.Show("First you must select and after that you can add.", "Information!");
            }



        }
        string newImagePath;
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var product = ListBox.SelectedItem as Product;
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG)|*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG|All files (*.*)|*.*";
            // dialog.InitialDirectory = @"C:\";
            //dialog.Title = "Please select an image file to encrypt.";

            if (openFileDialog.ShowDialog() == true)
            {

                using (StreamReader reader = File.OpenText(openFileDialog.FileName))
                {
                    newImagePath = openFileDialog.FileName;
                    ImageBrush imageBrush = new ImageBrush();
                    Uri imageUri = new Uri(newImagePath, UriKind.Relative);
                    BitmapImage imageBitmap = new BitmapImage(imageUri);
                    imageBrush.ImageSource = imageBitmap;
                    EditImage.Source = imageBrush.ImageSource;
                    //product.ImagePath = EditImage.Source.ToString();

                }

            }


        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NameOfProductTxtBox.Text == string.Empty && PriceOfProductTxtBox.Text == string.Empty)
            {
                System.Windows.MessageBox.Show("You can't save name of product or price of product empty");
            }
            else
            {

                var product = ListBox.SelectedItem as Product;
                foreach (var item in products)
                {
                    if (item.Id == product.Id)
                    {
                        item.Name = NameOfProductTxtBox.Text;
                        item.Price = double.Parse(PriceOfProductTxtBox.Text);
                        item.ImagePath = newImagePath;

                    }
                }


            }

        }
    }
}
