using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfServisCenter
{
    internal static class MySystem
    {
        public static object CheckDataGrid(DataGrid dg)
        {
            if (dg.SelectedItem == null)
            {
                MessageBox.Show("Нужно выбрать запись");
                return null;
            }
            else
            {
                
                return (dg.SelectedItem);
            }
        }

        public static bool CheckPhone(string Phone)
        {
            bool Valid = true;
            if (string.IsNullOrEmpty(Phone)) return false;
            foreach(char item in Phone.ToCharArray())
            {
                if (item == '_') {
                   Valid = false;
                }
            }
            return Valid;
        }

    }
}
