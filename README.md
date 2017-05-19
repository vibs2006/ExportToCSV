# ExportToCSV
.NET C# 4.5.2 Library to Export Data in CSV File Format using C# as Language
## Sample Usage

![Snapshot Overview of the Process](https://raw.githubusercontent.com/vibs2006/ExportToCSV/master/ExportCSV/icons/Snapshot.png)

#### Declare Class
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
  
  //Declare Some Sample Values
  listObj.Add(new SampleClass{ID=1,Name="Rishab Gupta",Address="Some Place, Delhi"});
  listObj.Add(new SampleClass{ID=2,Name="Vibhor Agarwal",Address="Some New Place, Mumbai"});
```

#### Create Export to CSV Object (ProcessDocument Class)
```C#  
  ProcessDocument<SampleClass> objProcessDocument = new ProcessDocument<SampleClass>();
  string outputString=string.Empty;
``` 
**if you pass HttpContext object then Response.Write will happen resulting in 'export to CSV' Action**
```C#
  objProcessDocument(listObj, out outputString, HttpContext); 
```
### OR
**If you do not want to triger RESPONSE.WRITE function and want to simply take the output to string (outputString) to handle in your own CSV then you can pass null in place of the third variable.**
```C#
  objProcessDocument(listObj, out outputString, null); 
```
