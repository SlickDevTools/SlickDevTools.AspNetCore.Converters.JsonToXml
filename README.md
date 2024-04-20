# SlickDevTools.AspNetCore.Converters.JsonToXml

This library provides a service to convert JSON data to XML format using C#. The main class `JsonToXmlConverterService`
allows you to convert JSON strings to XML strings.

## Features

- Easy-to-use JSON to XML conversion
- Allows customization through `JsonToXmlConverterOptions`
- Returns conversion result in `JsonToXmlConverterResult` object

## Usage

### Basic instantiation and conversion

1. Instantiate `JsonToXmlConverterService` class:

```csharp
JsonToXmlConverterService converterService = new JsonToXmlConverterService();
```

2. Convert JSON to XML:

```csharp
string json = "{ \"key\": \"value\" }";
JsonToXmlConverterResult result = converterService.Convert(json);
```

3. Access the converted XML string:

```csharp
string xml = result.Xml;
```

### Alternate instantiation and conversion with options

1. Instantiate `JsonToXmlConverterService` class with options:

```csharp
// json string for a product
string json = @"{
    ""id"": 1,
    ""name"": ""Product 1"",
    ""price"": 100
}";
        
// create an instance of the json to xml serializer with options that sets the root element name to "product"
var service = new JsonToXmlConverterService(new JsonToXmlConverterOptions { RootElementName = "product" });
```

2. Convert JSON to XML:

```csharp
var result = service.Convert(json);
```

3. Access the converted XML string:

```csharp
// output the xml
var xmlString = result.Xml;
```

## Classes

### JsonToXmlConverterService

The main class that handles JSON to XML conversion. The constructor takes an optional `JsonToXmlConverterOptions`
parameter to customize the conversion process. It has one public method, `Convert`, which takes a JSON string as input
and returns a `JsonToXmlConverterResult` object containing the XML string.

### JsonToXmlConverterOptions

A class that allows customization of the JSON to XML conversion process. Currently, it does not have any options, but it
can be extended in the future.

### JsonToXmlConverterResult

A class that holds the result of the JSON to XML conversion. It has one property, `Xml`, which contains the converted
XML string.

## Dependencies

- This library relies on the `JsonToXmlConverter` class to perform the actual JSON to XML conversion. Ensure that this
  class is included in your project.

_Supports: **.NET Core 8.0**_

## License

This project is released under the [MIT License](https://opensource.org/licenses/MIT).
