 #region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;

#endregion

namespace RAB_Session_05_Skills
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;



            return Result.Succeeded;
        }
    }

    public class Neighborhood
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }

    }

    public class Building
    {
        public string Name { get; set; }
        public int MyProperty { get; set; }
        public int NumFloors { get; set; }
        public double Area { get; set; }
    }
}
