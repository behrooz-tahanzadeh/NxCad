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

[assembly: CommandClass(typeof(ir.btapp.NxCad.Commands.NxCoding))]

namespace ir.btapp.NxCad.Commands
{
	public class NxCoding
	{
		static PaletteSet _ps = null;




		[CommandMethod("NxCoding")]
		public void main()
		{
			if (_ps == null)
				_ps = new PaletteSet
				(
					"Nx Palettes",
					new Guid("61135FFD-EE9A-4A5D-B3E1-993AB17E93BD")
				);

			if (_ps.Count != 0)
				_ps[0].PaletteSet.Remove(0);

			var p = _ps.Add("NxCoding", new Uri("http://server:81/nextoffice/index.php?r=service/filenaming"));

			_ps.Visible = true;
		}//eof




        [JavaScriptCallback("NxCodingCreateTextJsCallback")]
        public void NxCodingCreateTextJsCallback(string jsonArgs = "")
        {
        }
	}//eoc
}//eons
