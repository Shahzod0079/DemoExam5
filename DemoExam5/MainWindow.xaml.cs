using System.Data.Common;
using System.Windows;
using DbConnection = DemoExam5.Classes.DbConnection;
using DemoExam5.Pages;


namespace DemoExam5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DbConnection connection = new DbConnection();
        public static MainWindow Init;

        public MainWindow()
        {
            InitializeComponent();
            frame.Navigate(new Main());
            Init = this;
        }
    }
}