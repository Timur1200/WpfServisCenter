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


    }
}
