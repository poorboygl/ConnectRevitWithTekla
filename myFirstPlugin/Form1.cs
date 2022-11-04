using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ARB=Autodesk.Revit.DB;
using Form = System.Windows.Forms.Form;
using Tekla.Structures.Model;
using System.Windows.Forms;

namespace myFirstPlugin
{
    public partial class Form1 : Form
    {
        ARB.Document _doc;
        Model _modelTekla;
        public static string Material = "SS400";
        public string Color = "99";

        static public double FootingSize = 1200;
        static public string FootingName = "FOOTING";
        static public string FootingrebarName = "FootingRebar";

        static public string ColumnName = "COLUMN";

        static public string BeamName = "BEAM";
        static public string BeamColor = "3";

        static public string BaseplateName = "Stiffened Base Plate";

        public Form1(ARB.Document doc, Model modelTekla)
        {
            InitializeComponent();
            _doc = doc;
            _modelTekla = modelTekla;
        }

        private void wall_count_Click(object sender, EventArgs e)
        {
          /*  ICollection<Element> walls = 
                new FilteredElementCollector(_doc, _doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_Walls).ToElements();
            TaskDialog.Show("Wall Count", walls.Count.ToString()+" walls");*/


            // Always remember to check that you really have working connection
            if (!_modelTekla.GetConnectionStatus())
            {
                MessageBox.Show("Chua ket noi Tekla");
                return;
            }
            int count = 1;
            // Loop through X-axis  (these loops should be changed to match current grid)
            for (double PositionX = 0.0; PositionX <= 12000.0; PositionX += 3000.0)
            {
                // In first and in last line
                if (PositionX.Equals(0.0) || PositionX.Equals(12000.0))
                {
                    // Loop through Y-axis to get pad footings on the longer sides of the grid
                    for (double PositionY = 0.0; PositionY <= 30000.0; PositionY += 6000.0)
                    {
                        PadFootingAttribute(PositionX, PositionY);

                    }
                }
                else
                {   // Create pad footings on the shorter sides of the grid
                    PadFootingAttribute(PositionX, 0.0);
                    PadFootingAttribute(PositionX, 30000.0);
                }
            }
            // Always remember to commit changes to Tekla Structures, otherwise some things might be left in uncertain state
            _modelTekla.CommitChanges();

             void PadFootingAttribute(double PositionX, double PositionY)
            {

                Beam PadFooting = new Beam();

                PadFooting.Name = FootingName;
                PadFooting.Profile.ProfileString = $"{FootingSize}*{FootingSize}";
                PadFooting.Material.MaterialString = "K30-2";
                PadFooting.Class = "8";
                PadFooting.StartPoint.X = PositionX;
                PadFooting.StartPoint.Y = PositionY;
                PadFooting.StartPoint.Z = 0.0;
                PadFooting.EndPoint.X = PositionX;
                PadFooting.EndPoint.Y = PositionY;
                PadFooting.EndPoint.Z = -500.0;
                PadFooting.Position.Rotation = Position.RotationEnum.FRONT;
                PadFooting.Position.Plane = Position.PlaneEnum.MIDDLE;
                PadFooting.Position.Depth = Position.DepthEnum.MIDDLE;

                PadFooting.Insert();
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
