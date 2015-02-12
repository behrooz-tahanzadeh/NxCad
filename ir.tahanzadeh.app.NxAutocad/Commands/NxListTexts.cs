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

[assembly: CommandClass(typeof(ir.tahanzadeh.app.NxAutocad.Commands.NxListTexts))]

namespace ir.tahanzadeh.app.NxAutocad.Commands
{
public class NxListTexts
{
    [CommandMethod("NxListTexts")]

    public void main()
    {
        // Get the current document editor and database
        Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
        Database database = Application.DocumentManager.MdiActiveDocument.Database;

        using (Transaction transaction = database.TransactionManager.StartTransaction())
        {
            PromptSelectionResult pSelRes = editor.GetSelection(getSelectionFilter());

            if (pSelRes.Status == PromptStatus.OK)
            {
                PromptResult pStrRes = editor.GetString(getStringOptions());

                string output = "";

                foreach (SelectedObject obj in pSelRes.Value)
                {
                    output += getSelectedObjectString(transaction, obj, pStrRes.StringResult);
                }

                editor.WriteMessage(output);
                System.Windows.Forms.Clipboard.SetText(output);
                editor.WriteMessage("Texts contents have been copied to clipboard...");

                transaction.Commit();
            }
        }//eo using
    }//eof




    private SelectionFilter getSelectionFilter()
    {
        TypedValue[] typedValue = new TypedValue[1];
        typedValue.SetValue(new TypedValue((int)DxfCode.Start, "*TEXT"), 0);

        return new SelectionFilter(typedValue);
    }//eof




    private PromptStringOptions getStringOptions()
    {
        PromptStringOptions pStrOpt = new PromptStringOptions("\nPrefix: ");
        pStrOpt.AllowSpaces = true;

        return pStrOpt;
    }//eof




    private String getSelectedObjectString(Transaction transaction, SelectedObject obj, string prefix = "")
    {
        string output = "";

        if (obj != null)
        {
            DBObject dbObj = transaction.GetObject(obj.ObjectId, OpenMode.ForRead);

            if (dbObj is MText)
            {
                MText mTxtObj = dbObj as MText;
                output += prefix + mTxtObj.Contents + "\n";
            }
            else if (dbObj is DBText)
            {
                DBText dbTxtObj = dbObj as DBText;
                output += prefix + dbTxtObj.TextString + "\n";
            }
            else
            {
                Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("Unknown type...!");
            }
        }

        return output;
    }//eof




}//eoc
}//eons
