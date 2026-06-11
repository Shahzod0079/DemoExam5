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
using DemoExam5.Models;
using Microsoft.Win32;

namespace DemoExam5.Pages
{

    public partial class Add : Page
    {
        public DocumentAcc document = null;


        public Add(DocumentAcc document = null)
        {
            InitializeComponent();
            this.document = document;

            var directions = MainWindow.connection.Directions.ToList();
            foreach(Direction dir in directions)
            {
                tDirection.Items.Add(dir.Name);
            }

            if(document != null)
            {
                tName.Text = document.Name;
                tResponsible.Text = document.Responsible;
                tReceiptDate.SelectedDate = document.ReceiptDate;
                tDocumentCode.Text = document.DocumentCode;
                tOrganization.Text = document.Organization;
                tStatus.Text = document.Status;

                int index = directions.FindIndex(x => x.Id == document.IdDirection);
                if(index >= 0)
                {
                    tDirection.SelectedIndex = index;
                }
            }

        }

        private void Back(object sender, RoutedEventArgs e) =>
            MainWindow.Init.frame.Navigate(new Main());

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tName.Text))
                {
                    MessageBox.Show("Введите наименование");
                    return;
                }

                if (string.IsNullOrEmpty(tResponsible.Text))
                {
                    MessageBox.Show("Введите ответственного");
                    return;
                }

                if (tReceiptDate.SelectedDate == null) 
                {
                    MessageBox.Show("Выберите дату поступления");
                    return;
                }
                if (string.IsNullOrEmpty(tDocumentCode.Text))
                {
                    MessageBox.Show("Введите код документа");
                    return;
                }
                if (string.IsNullOrEmpty(tOrganization.Text))
                {
                    MessageBox.Show("Введите организцаию");
                    return;
                }
                if (string.IsNullOrEmpty(tStatus.Text))
                {
                    MessageBox.Show("Введите статус");
                    return;
                }
                if(tDirection.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите направление");
                    return;
                }

                if(document == null)
                {
                    document = new DocumentAcc();
                    MainWindow.connection.DocumentAccS.Add(document);
                }

                document.Name = tName.Text;
                document.Responsible = tResponsible.Text;
                document.ReceiptDate = tReceiptDate.SelectedDate.Value;
                document.DocumentCode = tDocumentCode.Text;
                document.Organization = tOrganization.Text;
                document.Status = tStatus.Text;

                var selectedDirection = MainWindow.connection.Directions.ToList()[tDirection.SelectedIndex];
                document.IdDirection = selectedDirection.Id;

                MainWindow.connection.SaveChanges();
                MessageBox.Show("Данные сохрнены");
                Back(null, null);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            } 
        }
    }
}
