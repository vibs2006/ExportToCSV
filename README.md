# ExportToCSV
.NET C# 4.5.2 Library to Export Data in CSV File Format using C# as Language

## Sample Usage

#### Declare Class
```
public class SampleClass
{
  public string ID {get;set;}
  public string Name{get;set;}
  public string Address{get;set;}
}
```
#### Declare Class Object to use List
```
using ExportCSV; //Reference ExportCSV DLL in your references

public void sampleMethod()
{
  List<SampleClass> listObj = new List<SampleClass>();
  
  //Declare Some Sample Values
  listObj.Add(new SampleClass{ID=1,Name="Rishab Gupta",Address="Some Place, Delhi"});
  listObj.Add(new SampleClass{ID=2,Name="Vibhor Agarwal",Address="Some New Place, Mumbai"});
  
  //Create Object
  ProcessDocument<SampleClass> objProcessDocument = new ProcessDocument<SampleClass>();
  string outputString=string.Empty;
  objProcessDocument(listObj, out outputString, HttpContext); 
  // if you pass HttpContext object then Response.Write will happen resulting in export to CSV otherwise you have to export CSV yourself by using "outputString" variable mentioned
}
```




