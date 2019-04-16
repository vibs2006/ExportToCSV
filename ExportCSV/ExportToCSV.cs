
//To be used under MIT License
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;
using System.Web;

namespace ExportCSV
{
    public class ProcessDocument<TModel>
    {
        StringBuilder sb;
        public ProcessDocument()
        {
            sb = new StringBuilder();
        }
        /// <summary>
        /// This function Exports the incoming List of AnyClassType to a CSV String / Response.Write Command (Optional)
        /// </summary>
        /// <param name="itemslist">Pass your List Here. This function will automatically calculate number of columns from total number of Public Properties of Class</param>
        /// <param name="outputString">You can get CSV Format String in this variable. This is the reason it is declared as OUT</param>
        /// <param name="objHttpContext">This is an optional parameter. Pass current client's HTTPContext if you want to trigger an Export to CSV download popup in your Web Browser</param>
        public void ExportToCsv(List<TModel> itemslist, out string outputString, HttpContextBase objHttpContext = null)
        {
            outputString = string.Empty;
         
            Type type = typeof(TModel);
            int propertyCount = type.GetProperties().Length;

            PropertyInfo[] propInfoArray = type.GetProperties();

            int loopCount = 0;
            foreach (var propInfo in propInfoArray)
            {
                loopCount += 1;
                sb.Append("\"" + propInfo.Name + "\"");
                if (loopCount == propertyCount)
                {
                    sb.Append(Environment.NewLine);
                }
                else
                {
                    sb.Append(",");
                }
            }
            

            loopCount = 0;
            foreach (TModel item in itemslist)
            {
                Type typeInner = item.GetType();
                PropertyInfo[] propInfoArrayInner = typeInner.GetProperties();

                foreach (var innerPropInfo in propInfoArrayInner)
                {
                    loopCount += 1;
                    var columnValue = innerPropInfo.GetValue(item).ToString();
                    sb.Append(sanitizeCommaAndQuotes(columnValue));
                    if (loopCount == propertyCount)
                    {
                        sb.Append(Environment.NewLine);
                        loopCount = 0;
                    }
                    else
                    {
                        sb.Append(",");
                    }
                }
            }
            outputString = sb.ToString();
            Trace.WriteLine(outputString);
            if (objHttpContext != null)
            {
                string attachment = "attachment; filename=Export-" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm") + ".csv";
                objHttpContext.Response.Clear();
                objHttpContext.Response.ClearHeaders();
                objHttpContext.Response.ClearContent();
                objHttpContext.Response.AddHeader("content-disposition", attachment);
                objHttpContext.Response.ContentType = "text/csv";
                objHttpContext.Response.AddHeader("ParcelVision", "public");
                objHttpContext.Response.Write(outputString);
                objHttpContext.Response.End();
            }
        }

        private static string sanitizeCommaAndQuotes(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                if (input.Contains(Environment.NewLine))
                {
                    input = input.Replace(Environment.NewLine, " ");
                }

                if (input.Contains("\r"))
                {
                    input = input.Replace('\r', ' ');
                }

                if (input.Contains("\n"))
                {
                    input = input.Replace('\n', ' ');
                }

                if (input.Contains("\t"))
                {
                    input = input.Replace('\t', ' ');
                }

                if (input.Contains("\""))
                {
                    input = input.Replace('\"', '`');
                }

                //if (input.Contains(","))
                //{
                //    input = "\"" + input + "\"";  
                //}
            }

            return "\"" + input + "\"";
        }
        
         /// <summary>
        /// This function Exports the incoming List of AnyClassType to a CSV String 
        /// </summary>
        /// <param name="itemslist">Pass your List Here. This function will automatically calculate number of columns from total number of Public Properties of Class</param>                
        public string ExportToCsv(List<TModel> itemslist)
        {

            Type type = typeof(TModel);
            int propertyCount = type.GetProperties().Length;

            PropertyInfo[] propInfoArray = type.GetProperties();

            int loopCount = 0;
            foreach (var propInfo in propInfoArray)
            {
                loopCount += 1;
                sb.Append("\"" + propInfo.Name + "\"");
                if (loopCount == propertyCount)
                {
                    sb.Append(Environment.NewLine);
                }
                else
                {
                    sb.Append(",");
                }
            }


            loopCount = 0;
            foreach (TModel item in itemslist)
            {
                Type typeInner = item.GetType();
                PropertyInfo[] propInfoArrayInner = typeInner.GetProperties();

                foreach (var innerPropInfo in propInfoArrayInner)
                {
                    loopCount += 1;
                    var columnValue = innerPropInfo.GetValue(item).ToString();
                    sb.Append(sanitizeCommaAndQuotes(columnValue));
                    if (loopCount == propertyCount)
                    {
                        sb.Append(Environment.NewLine);
                        loopCount = 0;
                    }
                    else
                    {
                        sb.Append(",");
                    }
                }
            }
            return sb.ToString();
            //Trace.WriteLine(outputString);

        }
        
    }
}
