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

namespace WpfServisCenter.View.Pages.Servis
{
    /// <summary>
    /// Логика взаимодействия для ListServisAddEditPage.xaml
    /// </summary>
    public partial class ListServisAddEditPage : Page
    {
        public ListServisAddEditPage(СписокОказанияУслуг списокОказанияУслуг)
        {
            InitializeComponent();
            _listServis = списокОказанияУслуг;
            DataContext = _listServis;
            ThisPage = this;

        }
        private СписокОказанияУслуг _listServis { get; set; }

        public static ListServisAddEditPage ThisPage { get; set; }
        public  void Reload()
        {
            Page_Loaded(null, null);
        }
        private int fullSum;
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var a = ContextEF.GetContext().ОказаниеУслуг.Where(q => q.КодСпискаОказанияУслуг == _listServis.Код).ToList();
            fullSum = a.Sum(q => q.Услуги.Цена.Value);
            FullSumTextBox.Text = fullSum.ToString()+" Руб";
            ServisListBox.ItemsSource = a;
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            Windows.AddServisWindow addServisWindow = new Windows.AddServisWindow(_listServis);
            addServisWindow.ShowDialog();
        }

        private void DelClick(object sender, RoutedEventArgs e)
        {
            if (ServisListBox.SelectedItem == null)
            {
                return;
            }
            var usedServis = ServisListBox.SelectedItem as ОказаниеУслуг;
            ContextEF.GetContext().ОказаниеУслуг.Remove(usedServis);
            ContextEF.GetContext().SaveChanges();
            Reload();
        }
        private readonly string TemplateFileName = System.IO.Path.GetFullPath(@"Word/Servis.docx");
        void ReplaceWordStub(String stubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }

        private void ToWord(СписокОказанияУслуг ServisList)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var a = ContextEF.GetContext().ОказаниеУслуг.Where(q=>q.КодСпискаОказанияУслуг==ServisList.Код).ToList();
            foreach(var s in a)
            {
                stringBuilder.AppendLine(s.Услуги.Имя);
            }

            var wordApp = new Word.Application();

            wordApp.Visible = false;
            var wordDocument = wordApp.Documents.Open(TemplateFileName);
            ReplaceWordStub("(код)", ServisList.Код.ToString(), wordDocument);
            ReplaceWordStub("(клиент)", ServisList.Клиент.Фио, wordDocument);
            ReplaceWordStub("(дата)", ServisList.Дата1, wordDocument);
            ReplaceWordStub("(стоимость)", ServisList.Стоимость.ToString(), wordDocument);
            ReplaceWordStub("(услуга)", stringBuilder.ToString(), wordDocument);

            wordDocument.SaveAs2(System.IO.Path.GetFullPath($@"Word/Servis{Guid.NewGuid()}.docx"));

            wordApp.Visible = true;
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            _listServis.Стоимость = fullSum;
            ContextEF.GetContext().SaveChanges();
            ToWord(_listServis);
            PageNavigate.Back();
        }
    }
}
