using System;
using System.Collections.Generic;
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
using DemoExam5.Elements;
using DemoExam5.Models;

namespace DemoExam5.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
       
        public Main()
        {
            InitializeComponent();
            LoadDocumentsAccs();

        }

        public void LoadDocumentsAccs()
        {
            spItems.Children.Clear();
            foreach (DocumentAcc d in MainWindow.connection.DocumentAccS.ToList())
            {
                spItems.Children.Add(new Item(d, this));
            }
        }

        private void Add(object sender, RoutedEventArgs e) =>
            MainWindow.Init.frame.Navigate(new Add());
    }
}
