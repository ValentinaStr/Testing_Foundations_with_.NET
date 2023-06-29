using OOP.TypesOfTransport;
using System.Xml.Linq;
namespace OOP
{
	internal static class LogerXML
	{
		public static void Log(XElement xdoc, string PATH)
		{
			using StreamWriter writer = new StreamWriter(PATH);
			writer.Write(xdoc);
		}
	}
}