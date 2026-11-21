# Generating Source Code Documentation With DocFx

Sample for the Code Maze article on DocFx, built with DocFx 2.81.0 and .NET 11.

The REST API section needs the Swagger Petstore file, which is not part of this repository. Download https://petstore.swagger.io/v2/swagger.json and save it as `CalculatorDocumentation/docfx_project/restapi/petstore.swagger.json` before you build the site.

To build and serve the site, run this from the `CalculatorDocumentation` folder:

```bash
docfx docfx_project/docfx.json --serve
```
