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
using Word = Microsoft.Office.Interop.Word;

namespace WpfServisCenter.View.Pages.Orders
{
    /// <summary>
    /// Логика взаимодействия для ReadyOrdersPage.xaml
    /// </summary>
    public partial class ReadyOrdersPage : Page
    {
        public ReadyOrdersPage()
        {
            InitializeComponent();
        }
      
        private readonly string TemplateFileName = System.IO.Path.GetFullPath(@"Word/Чек.docx");
        void ReplaceWordStub(String stubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }
        private void ToWord(Заказ заказ)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var aa = ContextEF.GetContext().СписокМатериаловСклада.Where(q => q.КодЗаказа == заказ.Код);
            int sumStorage = 0;
            foreach(var item in aa)
            {
                stringBuilder.Append(item.Name);
                sumStorage += item.Количество * item.Склад.Цена.Value;
            }

            var wordApp = new Word.Application();

            wordApp.Visible = false;
            var wordDocument = wordApp.Documents.Open(TemplateFileName);
            ReplaceWordStub("(код)", $"{заказ.Код}", wordDocument);
            ReplaceWordStub("(клиент)", $"{заказ.Клиент.Фио}", wordDocument);
            ReplaceWordStub("(мастер)", $"{заказ.Персонал.Фио}", wordDocument);
            ReplaceWordStub("(дата1)", $"{заказ.Дата1}", wordDocument);
            ReplaceWordStub("(дата2)", $"{заказ.Дата2}", wordDocument);
            ReplaceWordStub("(техника)", $"{заказ.Техника}", wordDocument);
            ReplaceWordStub("(стоимость)", $"{заказ.Цена}", wordDocument);
            ReplaceWordStub("(сумма)", $"{sumStorage}", wordDocument);
            ReplaceWordStub("(склад)", $"{stringBuilder}", wordDocument);
            ReplaceWordStub("(итог)", $"{заказ.Цена + sumStorage}", wordDocument);
            wordDocument.SaveAs2(System.IO.Path.GetFullPath($@"Word/Чек_{Guid.NewGuid()}.docx"));

            wordApp.Visible = true;
        }

        private void ReadyClick(object sender, RoutedEventArgs e)
        {
            Заказ order = DGridOrder.SelectedItem as Заказ;
            order.Статус = (int)СтатусЗаказов.Выдан;
            order.ДатаВыдачи = DateTime.Now;
            ContextEF.GetContext().SaveChanges();
            ToWord(order);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           DGridOrder.ItemsSource = ContextEF.GetContext().Заказ.Where(q=>q.Статус==(int)СтатусЗаказов.Завершен).ToList();
        }
    }
}
