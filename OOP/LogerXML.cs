using System.Xml.Linq;
namespace OOP
{
	internal static class LogerXML
	{
		internal static void Log(string nameXMLDoc, XElement xElement)
		{
			var xDoc = new XDocument();
			xDoc.Add(xElement);
			xDoc.Save($"{nameXMLDoc}.xml");
		}
	}
}