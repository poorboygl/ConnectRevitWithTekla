using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using System.Windows.Forms;
using Form = System.Windows.Forms.Form;
using Tekla.Structures;
using Tekla.Structures.Model;

namespace myFirstPlugin
{
    /// <summary>
    /// Implements revit add-in IExternalCommand interface
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Command : IExternalCommand
    {

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;
            Model modelTekla = new Model();

            using (Form form = new Form1(doc, modelTekla))
            {
                if(form.ShowDialog() == DialogResult.OK)
                {
                    return Result.Succeeded;
                }
                else
                {
                    return Result.Cancelled;
                }
            }
                       
        }       

    }

}
