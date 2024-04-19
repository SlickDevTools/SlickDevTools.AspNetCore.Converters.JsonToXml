namespace SlickDevTools.AspNetCore.Converters.JsonToXml;

/// <summary>
///     Service to convert JSON to XML
/// </summary>
/// <remarks>
///     This project defines a C# class named `JsonToXmlConverterService` that provides a service to convert JSON to
///     XML. The class has a constructor that takes an optional `JsonToXmlConverterOptions` object as a parameter. The
///     `Convert` method of the class takes a JSON string as input and returns an object of type `JsonToXmlConverterResult`
///     that contains the converted XML string.
/// </remarks>
public class JsonToXmlConverterService
{
    private readonly JsonToXmlConverterOptions _options;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="options"></param>
    public JsonToXmlConverterService(JsonToXmlConverterOptions? options = null)
    {
        _options = options ?? new JsonToXmlConverterOptions();
    }

    /// <summary>
    ///     Convert JSON to XML
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    public JsonToXmlConverterResult Convert(string json)
    {
        var converter = new JsonToXmlConverter();

        var xml = converter.Convert(json, _options.RootElementName);
        var result = new JsonToXmlConverterResult
        {
            Xml = xml
        };

        return result;
    }
}