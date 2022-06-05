using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfServisCenter
{
    partial class ContextEF
    {
        private static ContextEF Context;
        public static ContextEF GetContext()
        {
            if (Context == null) Context = new ContextEF();
            return Context;
        }
    }
}
