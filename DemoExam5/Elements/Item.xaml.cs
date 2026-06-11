using System.Windows;
using System.Windows.Controls;
using DemoExam5.Models;
using DemoExam5.Pages;

namespace DemoExam5.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        public DocumentAcc documentAcc;
        public Main main; 

        public Item(DocumentAcc documentAcc, Main main)
        {
            InitializeComponent();
            this.documentAcc = documentAcc;
            this.main = main;

            lName.Content = $"Наименование: {documentAcc.Name}";
            lResponsible.Content = $"Ответственный: {documentAcc.ReceiptDate}";
            lReceiptDate.Content = $"Дата поступления: {documentAcc.ReceiptDate}";
            lDocumentCode.Content = $"Код докумнета : {documentAcc.DocumentCode}";
            lOrganization.Content = $"Организация: {documentAcc.Organization}";
            lStatus.Content = $"Статус: {documentAcc.Status}";

            var direction = MainWindow.connection.DocumentAccS.FirstOrDefault(x => x.Id == documentAcc.IdDirection);
            string DirectionName = direction?.Name ?? "Не указана";

            lDirection.Content = $"Направление: {DirectionName}";
            

        }

        private void Update(object sender, RoutedEventArgs e) =>
            MainWindow.Init.frame.Navigate(new Add(documentAcc));

        private void Delete(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Вы уверены что хотите удалить документ?", "Увдомление",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                MainWindow.connection.DocumentAccS.Remove(documentAcc);
                MainWindow.connection.SaveChanges();
                main.spItems.Children.Remove(this);
                
            }
        }
    }
}
