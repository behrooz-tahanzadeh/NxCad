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

[assembly: CommandClass(typeof(ir.btapp.NxCad.Commands.NxAbout))]

namespace ir.btapp.NxCad.Commands
{
    public class NxAbout
    {
        [CommandMethod("NxAbout")]

        public void main()
        {
            Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;

            editor.WriteMessage("--------------------------------------------\n");
            editor.WriteMessage("NxCad:\n");
            editor.WriteMessage("Developed by Behrooz Tahanzadeh (b-tz.com)\n");
            editor.WriteMessage("At Next Office (nextoffice.ir)\n\n");
            editor.WriteMessage("feb 2015\n");
            editor.WriteMessage("--------------------------------------------\n");
        }//eof
    }//eoc
}//eons
