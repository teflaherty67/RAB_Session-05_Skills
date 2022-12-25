 #region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
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

            List<Building> buildingList = new List<Building>();
            buildingList.Add(myBuilding);
            buildingList.Add(myBuilding1);
            buildingList.Add(myBuilding2);
            buildingList.Add(myBuilding3);
            buildingList.Add(new Building("Store", "50 Main Street", 2, 20000));

            Neighborhood neighborhood = new Neighborhood("Downtown", "Boston", "MA", buildingList);

            TaskDialog.Show("Test", "There are " + neighborhood.GetBuildingCount().ToString()
                + " buildings in " + neighborhood.Name + " " + neighborhood.City);

            Utils.MyStaticMethod();

            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfCategory(BuiltInCategory.OST_Rooms);

            using (Transaction t = new Transaction(doc))
            {
                t.Start("Insert family");

                foreach (SpatialElement room in collector)
                {
                    LocationPoint loc = room.Location as LocationPoint;
                    XYZ roomPoint = loc.Point;

                    FamilySymbol myFS = Utils.GetFamilySymbolByName(doc, "Desk", "60\" x 30\"");
                    FamilyInstance myInstance = doc.Create.NewFamilyInstance(roomPoint, myFS,
                        StructuralType.NonStructural);

                    SetParameterVaule(room, "Ceiling Finish", "ACT");
                }

                t.Commit();
            }            

            return Result.Succeeded;
        }

        private void SetParameterVaule(Element curElement, string paramName, string paramValue)
        {
            IList<Parameter> paramList = curElement.GetParameters(paramName);

            foreach(Parameter param in paramList)
            {
                param.Set(paramValue);
            }
        }
    }

    public class Neighborhood
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public List<Building> BuildingList { get; set; }
        public Neighborhood(string name, string city, string state, List<Building> buildingList)
        {
            Name = name;
            City = city;
            State = state;
            BuildingList = buildingList;
        }

        public int GetBuildingCount()
        {
            return BuildingList.Count;
        }                    
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

        public double GetBuildingArea()
        {
            return Area * NumFloors;
        }
    }
}
