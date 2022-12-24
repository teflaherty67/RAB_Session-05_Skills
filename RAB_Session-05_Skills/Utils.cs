using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAB_Session_05_Skills
{
    internal static class Utils
    {
        public static void MyStaticMethod()
        {
            TaskDialog.Show("test", "This is my static method!");
        }
    }
}
