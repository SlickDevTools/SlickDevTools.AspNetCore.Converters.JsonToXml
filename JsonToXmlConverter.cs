using FluentAssertions;
using Newtonsoft.Json.Linq;
using System.Xml;
using System;

namespace SlickDevTools.AspNetCore.Converters.JsonToXml;

/// <summary>
///     Convert a JSON string to an XML string with a specified root element name by recursively adding the JSON object and its properties to an XML document
/// </summary>
internal class JsonToXmlConverter
{
    private const string DefaultRootElementName = "root";

    /// <summary>
    ///     Convert a JSON string to an XML string with a specified root element name
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    public string Convert(string json, string rootElementName = DefaultRootElementName)
    {
#if DEBUG
        json.Should().NotBeNullOrEmpty("Input JSON string should not be null or empty.");
#endif

        var jObject = JObject.Parse(json);

#if DEBUG
        jObject.Should().NotBeNull("Parsed JObject should not be null.");
#endif

        var xmlDocument = new XmlDocument();

        // the caller can leave the rootElement name as empty quotes so intervene 
        var rootName = string.IsNullOrWhiteSpace(rootElementName) ? DefaultRootElementName : rootElementName;
        var rootNode = xmlDocument.CreateElement(rootName);

#if DEBUG
        rootNode.Should().NotBeNull("RootElement should not be null.");
#endif

        xmlDocument.AppendChild(rootNode);

        AddJobjectToXmlDocument(jObject, rootNode, xmlDocument);
        return xmlDocument.OuterXml;
    }

    private void AddJobjectToXmlDocument(JObject jObject, XmlElement parentElement, XmlDocument xmlDocument)
    {
#if DEBUG
        jObject.Should().NotBeNull("JObject should not be null.");
        parentElement.Should().NotBeNull("Parent XML element should not be null.");
        xmlDocument.Should().NotBeNull("XmlDocument should not be null.");
#endif

        foreach (var property in jObject.Properties())
        {
            var element = xmlDocument.CreateElement(property.Name);

#if DEBUG
            element.Should().NotBeNull("Created XML element should not be null.");
#endif

            if (property.Value.Type == JTokenType.Object)
                AddJobjectToXmlDocument((JObject)property.Value, element, xmlDocument);
            else if (property.Value.Type == JTokenType.Array)
                foreach (JObject obj in property.Value)
                    AddJobjectToXmlDocument(obj, element, xmlDocument);
            else
                element.InnerText = property.Value.ToString();
            parentElement.AppendChild(element);
        }
    }
}