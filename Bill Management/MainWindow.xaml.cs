using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bill_Management
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<String> app = new List<String>();
        public List<String> bev = new List<String>();
        public List<String> main = new List<String>();
        public List<String> des = new List<String>();
        public List<GridData> gdata = new List<GridData>();
        Food ff = new Food();
        public ObservableCollection<Food> foodlist = new ObservableCollection <Food>();
        public MainWindow()
        {
            InitializeComponent();
            foodlist.Add(new Food { name = "Buffalo Wings", price = 6, type = "Appetizer" });
            foodlist.Add(new Food { name = "Buffalo Fingers", price = 6, type = "Appetizer" });
            foodlist.Add(new Food { name = "Potato Skiny", price = 8, type = "Appetizer" });
            foodlist.Add(new Food { name = "Nachos", price = 8, type = "Appetizer" });
            foodlist.Add(new Food { name = "Mushroom Caps", price = 10, type = "Appetizer" });
            foodlist.Add(new Food { name = "Shrimp Cocktail", price = 12, type = "Appetizer" });
            foodlist.Add(new Food { name = "Chips and Salsa", price = 6, type = "Appetizer" });

            foodlist.Add(new Food { name = "Soda", price = 2, type = "Beverages"});
            foodlist.Add(new Food { name = "Tea", price = 1, type = "Beverages" });
            foodlist.Add(new Food { name = "Coffee", price = 1, type = "Beverages" });
            foodlist.Add(new Food { name = "Mineral Water", price = 2, type = "Beverages" });
            foodlist.Add(new Food { name = "Juice", price = 2, type = "Beverages" });
            foodlist.Add(new Food { name = "Milk", price = 1, type = "Beverages" });

            foodlist.Add(new Food { name = "Seafood Alfredo", price = 15, type = "Main Course" });
            foodlist.Add(new Food { name = "Chicken Alfredo", price = 13, type = "Main Course" });
            foodlist.Add(new Food { name = "Chicken Picatta", price = 13, type = "Main Course" });
            foodlist.Add(new Food { name = "Turkey Club", price = 11, type = "Main Course" });
            foodlist.Add(new Food { name = "Lobster Pie", price = 19, type = "Main Course" });
            foodlist.Add(new Food { name = "Prime Rib", price = 20, type = "Main Course" });
            foodlist.Add(new Food { name = "Shrimp Scampi", price = 18, type = "Main Course" });

            foodlist.Add(new Food { name = "Apple Pie", price = 5, type = "Dessert" });
            foodlist.Add(new Food { name = "Sundae", price = 3, type = "Dessert" });
            foodlist.Add(new Food { name = "Carrot Cake", price = 5, type = "Dessert" });
            foodlist.Add(new Food { name = "Mud Pie", price = 4, type = "Dessert" });
            foodlist.Add(new Food { name = "Apple Crisp", price = 5, type = "Dessert" });


            foreach (Food obj in foodlist)
            {
               if(obj.type == "Beverages")
                {
                    bev.Add(obj.name);
                }
                if (obj.type == "Appetizer")
                {
                    app.Add(obj.name);
                }
                if (obj.type == "Dessert")
                {
                    des.Add(obj.name);
                }
                if (obj.type == "Main Course")
                {
                    main.Add(obj.name);
                }

            }
            Beverages.ItemsSource = bev;
            Appetizer.ItemsSource = app;
            Dessert.ItemsSource = des;
            MainCourse.ItemsSource = main;

        }



        private void Appetizer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string typeItem = Appetizer.SelectedValue.ToString();
            bool checker= false;
            foreach (Food f in foodlist)
            {
                if(f.name == typeItem)
                {
                    foreach (GridData d  in gdata)
                    {
                        if(d.name == f.name)
                        {
                            d.quantity++;
                            
                            checker = true;
                            break;
                        }

                       
                    }
                    if(checker!=true)
                    {
                        gdata.Add(new GridData { name = f.name, category = f.type, price = f.price, quantity = 1 });
                        
                        checker = false;
                    }
                    dataGrid1.Items.Clear();
                    foreach (GridData d in gdata)
                    {
                        dataGrid1.Items.Add(d);
                    }
                }
            }

    }

        private void Dessert_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            string typeItem = Dessert.SelectedValue.ToString();
            
            


            bool checker = false;
            foreach (Food f in foodlist)
            {
                if (f.name == typeItem)
                {
                    foreach (GridData d in gdata)
                    {
                        if (d.name == f.name)
                        {
                            d.quantity++;

                            checker = true;
                            break;
                        }


                    }
                    if (checker != true)
                    {
                        gdata.Add(new GridData { name = f.name, category = f.type, price = f.price, quantity = 1 });

                        checker = false;
                    }
                    dataGrid1.Items.Clear();
                    foreach (GridData d in gdata)
                    {
                        dataGrid1.Items.Add(d);
                        
                    }
             
                }
            
            }
        }

        private void Beverages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string typeItem = Beverages.SelectedValue.ToString();
            bool checker = false;
            foreach (Food f in foodlist)
            {
                if (f.name == typeItem)
                {
                    foreach (GridData d in gdata)
                    {
                        if (d.name == f.name)
                        {
                            d.quantity++;

                            checker = true;
                            break;
                        }


                    }
                    if (checker != true)
                    {
                        gdata.Add(new GridData { name = f.name, category = f.type, price = f.price, quantity = 1 });

                        checker = false;
                    }
                    dataGrid1.Items.Clear();
                    foreach (GridData d in gdata)
                    {
                        dataGrid1.Items.Add(d);
                    }
                }
            }
        }

        private void MainCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string typeItem = MainCourse.SelectedValue.ToString();
            bool checker = false;
            foreach (Food f in foodlist)
            {
                if (f.name == typeItem)
                {
                    foreach (GridData d in gdata)
                    {
                        if (d.name == f.name)
                        {
                            d.quantity++;

                            checker = true;
                            break;
                        }


                    }
                    if (checker != true)
                    {
                        gdata.Add(new GridData { name = f.name, category = f.type, price = f.price, quantity = 1 });

                        checker = false;
                    }
                    dataGrid1.Items.Clear();
                    foreach (GridData d in gdata)
                    {
                        dataGrid1.Items.Add(d);
                    }
                }
            }
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gdata.Clear();
            dataGrid1.Items.Clear();

        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            double prices = 0;
            foreach (GridData data in gdata)
            {
                prices += (data.quantity * data.price);
            }
            output1.Text = prices.ToString();
        }
    }
}
