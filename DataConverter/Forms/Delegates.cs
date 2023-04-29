using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace DataConverter
{
	#region Delegates

	public delegate string GetPathDelegate();

	public delegate void SetPathDelegate(string path);

	public delegate	void DisplayMessageDelegate(string message, string caption, MessageBoxIcon icon);

	#endregion

} // End namespace.