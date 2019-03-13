# Asp.Net Core WebApi with Local Report (RDLC)

Run files RDLC (Local Report) in Asp.Net Core WebApi.
 
## Prerequisites - Nuget Packages

    - `Install-Package AspNetCore.Reporting -Version 2.1.0`
	- `Install-Package System.Text.Encoding.CodePages -Version 4.5.1`
	- `Install-Package System.Drawing.Common -Version 4.5.1`


## Code example to generate PDF.

    - Implement code below in action to execute

    ```csharp
		System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);	
		var _file = @"Reports\testeReport.rdlc";
		LocalReport localReport = new LocalReport(_file);
		...
		localReport.AddDataSource("DataSet1", dt);
		...
		var result = localReport.Execute(RenderType.Pdf, extension, parameters: reportParams);
		byte[] file = result.MainStream;
		...
    ```