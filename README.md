# ExportToCSV
.NET C# 4.5.2 Library to Export Data in CSV File Format from C# List\<AnyClassType>
## Sample Usage

![Snapshot Overview of the Process](https://raw.githubusercontent.com/vibs2006/ExportToCSV/master/ExportCSV/icons/Snapshot.png)

#### Declare Class (of any number of public properties)
```C#
public class SampleClass
{
  public string ID {get;set;}
  public string Name{get;set;}
  public string Address{get;set;}
}
```
#### Declare Class Object to use List
```C#
//Reference ExportCSV DLL in your references
using ExportCSV; 

public void sampleMethod()
{
  List<SampleClass> listObj = new List<SampleClass>();
  listObj.Add(new SampleClass{ID=1,Name="Rishab Gupta",Address="Some Place, Delhi"});
  listObj.Add(new SampleClass{ID=2,Name="Vibhor Agarwal",Address="Some New Place, Mumbai"});
}
```

#### Create Export to CSV Object from ProcessDocument Class and create an string variable to catch the return back CSVString
```C#  
  ProcessDocument<SampleClass> objProcessDocument = new ProcessDocument<SampleClass>();
  string outputString=string.Empty;
``` 
**if you pass HttpContext object then Response.Write will happen resulting in 'export to CSV' Action**
```C#
  objProcessDocument(listObj, out outputString, HttpContext); 
```
#### OR
**If you do not want to triger Response.Write() function and want to simply take the output to string (outputString) to handle in your own CSV (for example saving CSV outstring string to a database or StreamWriter) then you can pass null in place of the third variable.**
```C#
  objProcessDocument(listObj, out outputString); //Do not pass HttpContext to prevent trigger of Response.Write
```
#### Click below to simply download DLL, reference it and start using it in your project 
[Download ExportToCSV.DLL](https://github.com/vibs2006/ExportToCSV/blob/master/ExportCSV/bin/Debug/ExportCSV.dll?raw=true)

#### OR

[Click here to visit GITHUB to see the Source Code](https://github.com/vibs2006/ExportToCSV)

##### See the Video by clicking on image BELOW to Simply Refer ExportToCSV.Dll in a sample ASP.NET MVC 5 Web Application Project and start using it without any research or efforts!
[![](https://i.ytimg.com/vi/NhUaSHkeYnE/maxresdefault.jpg)](https://www.youtube.com/watch?v=NhUaSHkeYnE)
