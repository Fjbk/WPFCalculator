using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string[] listOfButtons = { "7", "8", "9", "/", "4", "5", "6", "*", "1", "2", "3", "-", "0", "+", "C", "=" };
            foreach (string str in listOfButtons)
            {
                Button button = new Button()
                {
                    Content = str,
                    Width = 150,
                    Height = 150
                };
                if (int.TryParse(str, out int result))
                {
                    button.Background = Brushes.Orange;                    
                }
                switch (str)
                {
                    case "0":
                        button.Width = 450;
                        break;
                    case "=":
                        button.Width = 450;
                        break;
                    case "C":
                        button.Background = Brushes.Gray; 
                        break;
                    default:
                        break;
                }
                button.Click += Button_Click;
                ButtonArea.Children.Add(button);
            }

            void Button_Click(object sender, RoutedEventArgs e)
            {
                Button clickedButton = sender as Button;
                string buttonText = clickedButton.Content.ToString();

                if (clickedButton != null)
                {
                    if (buttonText == "=")
                    {
                        DataTable dataTable= new DataTable();
                        object result = dataTable.Compute(Display.Text, "");
                        Display.Text = result.ToString();
                    }
                    else if (buttonText == "C")
                    {
                        Display.Text = "";
                    }
                    else
                    {
                        Display.Text += buttonText;
                    }
                }
            }
        }
    }
}
