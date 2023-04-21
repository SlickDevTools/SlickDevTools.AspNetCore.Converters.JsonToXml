namespace SlickDevTools.AspNetCore.Converters.JsonToXml;
/// <summary>
///     Service to convert JSON to XML
/// </summary>
public class JsonToXmlConverterService
{
    private JsonToXmlConverterOptions _options;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="options"></param>
    public JsonToXmlConverterService(JsonToXmlConverterOptions options = null)
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