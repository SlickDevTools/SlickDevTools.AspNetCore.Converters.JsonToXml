using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace SlickDevTools.AspNetCore.Converters.JsonToXml;
/// <summary>
///     Convert a JSON string to an XML string with a specified root element name by recursively adding the JSON object and its properties to an XML document
/// </summary>
internal class JsonToXmlConverter
{
    /// <summary>
    ///     Convert a JSON string to an XML string with a specified root element name
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    public string Convert(string json, string rootElementName = "root")
    {
        JObject jObject = JObject.Parse(json);
        
        XmlDocument xmlDocument = new XmlDocument();
        // the caller can leave the rootElement name as empty quotes so intervene 
        var rootName = string.IsNullOrWhiteSpace(rootElementName) ? "root" : rootElementName;
        XmlElement rootNode = xmlDocument.CreateElement(rootName); 
        xmlDocument.AppendChild(rootNode);
        
        AddJobjectToXmlDocument(jObject, rootNode, xmlDocument);
        return xmlDocument.OuterXml;
    }
    
    private void AddJobjectToXmlDocument(JObject jObject, XmlElement parentElement, XmlDocument xmlDocument)
    {
        foreach (var property in jObject.Properties())
        {
            var element = xmlDocument.CreateElement(property.Name);
            
            if (property.Value.Type == JTokenType.Object)
            {
               
                AddJobjectToXmlDocument((JObject) property.Value, element, xmlDocument);

            }
            else if (property.Value.Type == JTokenType.Array)
            {
                foreach (JObject obj in property.Value)
                {
                    AddJobjectToXmlDocument(obj, element, xmlDocument);
                }
            }
            else
            {
                element.InnerText = property.Value.ToString();
            }
            parentElement.AppendChild(element);
        }
    }
}