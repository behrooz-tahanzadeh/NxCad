using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Windows;
using Autodesk.AutoCAD.EditorInput;

[assembly: CommandClass(typeof(ir.tahanzadeh.app.NxAutocad.Commands.NxAbout))]

namespace ir.tahanzadeh.app.NxAutocad.Commands
{
    public class NxAbout
    {
        [CommandMethod("NxAbout")]

        public void main()
        {
            Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;

            editor.WriteMessage("--------------------------------------------\n");
            editor.WriteMessage("NxAutocad:\n");
            editor.WriteMessage("Developed by Behrooz Tahanzadeh (b-tz.com)\n");
            editor.WriteMessage("At Next Office (nextoffice.ir)\n\n");
            editor.WriteMessage("feb 2015\n");
            editor.WriteMessage("--------------------------------------------\n");
        }//eof
    }//eoc
}//eons
