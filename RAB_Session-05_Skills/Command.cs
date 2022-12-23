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

            Building myBuilding = new Building("Office Building", "10 Main Street", 10, 10000);

            myBuilding.Name = "Office Building 2";

            Building myBuilding1 = new Building("Hospital", "20 Main Street", 20, 20000);
            Building myBuilding2 = new Building("Apartment Building", "30 Main Street", 30, 40000);
            Building myBuilding3 = new Building("Office Building", "40 Main Street", 5, 4000);



            return Result.Succeeded;
        }
    }

    public class Neighborhood
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public List<Building> buildingList { get; set; }
    }

    public class Building
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int NumFloors { get; set; }
        public double Area { get; set; }
        public Building(string name, string address, int numFloors, double area)
        {
            Name = name;
            Address = address;
            NumFloors = numFloors;
            Area = area;
        }
    }
}
