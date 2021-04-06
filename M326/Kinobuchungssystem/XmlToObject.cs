using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kinobuchungssystem
{
    class XmlToObject
    {
        public readonly string Path;

        private readonly XDocument document;
        public XmlToObject(string path)
        {
            Path = path;

            document = XDocument.Load(path);
        }

        public Dictionary<int, Movie> GetObject()
        {
            Dictionary<int, Movie> dict = new Dictionary<int, Movie>();

            FieldInfo[] info = typeof(Movie).GetFields();

            foreach (XElement parent in document.Root.Element(typeof(Movie).Name).Elements())
            {
                int id = Convert.ToInt32(parent.Attribute("id").Value);

                string title = parent.Element(info[0].Name).GetTextAttribute();
                string genre = parent.Element(info[1].Name).GetTextAttribute();
                int length = Convert.ToInt32(parent.Element(info[2].Name).GetTextAttribute());

                dict.Add(id, new Movie(title, genre, length)); 
            }

            return dict;
        }
    }

    public static class XElementExtensions
    {
        public static string GetTextAttribute(this XElement element)
        {
            return element.GetAttribute("Text");
        }

        public static int GetIdAttribute(this XElement element)
        {
            return Convert.ToInt32(element.GetAttribute("id"));
        }

        public static string GetAttribute(this XElement element, string attribute)
        {
            return element.Attribute(attribute).Value;
        }
    }
}
