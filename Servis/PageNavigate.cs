using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfServisCenter
{
    public class PageNavigate
    {
        public static Frame MainWindowFrame { get; set; }

        public static void Back()
        {
            if (MainWindowFrame.NavigationService.CanGoBack) MainWindowFrame.NavigationService.GoBack();
        }
    }
}
