using Asp.Net.Core.DataModel.Models;
using FastReport;
using FastReport.Export.PdfSimple;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Asp.Net.Core.DataModel.Utilities
{
    public static class Utilities
    {
        public static string SerializeObject(Object obj)
        {
            return SerializeObject(obj, false);
        }


        public static string SerializeObject(Object obj, bool generateNamespace)
        {
            XmlSerializerNamespaces ns = null;
            XmlSerializer ser = new XmlSerializer(obj.GetType()); ;

            if (generateNamespace)
            {
                ns = new XmlSerializerNamespaces();
                ns.Add("", "");
            }
            StringBuilder sb = new StringBuilder();
            using (XmlWriter writer = XmlWriter.Create(sb, new XmlWriterSettings() { OmitXmlDeclaration = true }))
            {
                if (ns == null)
                    ser.Serialize(writer, obj);
                else
                    ser.Serialize(writer, obj, ns);
                writer.Flush();
                writer.Close();

            }
            return sb.ToString();
        }


        //public static string JsonSerializeObject(object obj)
        //{
        //    JavaScriptSerializer objJsonSer = new JavaScriptSerializer();
        //    return objJsonSer.Serialize(obj);

        //}

        public static T deserializeObject<T>(string serializedObject)
        {
            TextReader objTextReaader = new StringReader(serializedObject);
            XmlSerializer objXmlSer = new XmlSerializer(typeof(T));
            return ((T)(Convert.ChangeType(objXmlSer.Deserialize(objTextReaader), typeof(T))));

        }

        //public static T JsonDeserializeObject<T>(string serializedObject)
        //{
        //    JavaScriptSerializer objJsonSer = new JavaScriptSerializer();
        //    return ((T)(Convert.ChangeType(objJsonSer.Deserialize<T>(serializedObject), typeof(T))));
        //}

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public static DataTable ToDataTable<T>(this IList<T> objList)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable objDataTable = new DataTable();
            foreach (PropertyDescriptor property in properties)
                objDataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            if (objList != null)
            {
                foreach (T item in objList)
                {
                    DataRow row = objDataTable.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    objDataTable.Rows.Add(row);
                }
            }
            return objDataTable;
        }

        public static DataTable ConvertEntityListToDataTable<T>(this IList<T> objList, List<Type> excludedTypes)
        {
            if (excludedTypes == null)
                excludedTypes = new List<Type>();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable objDataTable = new DataTable();
            foreach (PropertyDescriptor property in properties)
                if (!excludedTypes.Contains(property.PropertyType))
                    objDataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            if (objList != null)
            {
                foreach (T item in objList)
                {
                    DataRow row = objDataTable.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    objDataTable.Rows.Add(row);

                }
            }
            return objDataTable;
        }

        private static T ConvertDataRowToEntity<T>(this DataRow tableRow) where T : new()
        {
            //create a new type of the entity i want 
            Type t = typeof(T);
            T returnObject = new T();

            foreach (DataColumn col in tableRow.Table.Columns)
            {
                string colName = col.ColumnName;

                //Look for the object's property with the columns name , ignore case
                PropertyInfo pInfo = t.GetProperty(colName.ToLower(), BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                //did we find the property ?

                if (pInfo != null)
                {
                    object val = tableRow[colName];

                    //is this Nullable<> type 

                    bool ISNullable = (Nullable.GetUnderlyingType(pInfo.PropertyType) != null);
                    if (ISNullable)
                    {
                        if (val is System.DBNull)
                        {
                            val = null;

                        }

                        else
                        {
                            //cont thee db type into the T we have in our Nullable<T> type
                            val = Convert.ChangeType(val, Nullable.GetUnderlyingType(pInfo.PropertyType));

                        }
                    }
                    else
                    {
                        // convert the db type into the type of the proerty in our entity 
                        if (pInfo.PropertyType.IsEnum)
                            val = Enum.ToObject(pInfo.PropertyType, val);
                        else
                            val = Convert.ChangeType(val, pInfo.PropertyType);
                    }
                    //set the value of the property with the value from the db
                    pInfo.SetValue(returnObject, val, null);

                }

            }
            //return the entity object with values
            return returnObject;
        }

        public static List<T> ConvertDataTableToEntityList<T>(this DataTable table) where T : new()
        {
            Type t = typeof(T);

            //create a list of the entities we wnat to return 
            List<T> returnObject = new List<T>();

            //Iterate through the DataTable's rows
            foreach (DataRow dr in table.Rows)
            {
                //convert each row into an entity object and add to the list
                T newRow = dr.ConvertDataRowToEntity<T>();
                returnObject.Add(newRow);
            }
            return returnObject;
        }

        public static string Base64Encode(string plainText)
        {
            return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(plainText));
        }


        public static string Base64Decode(string base64EncodedData)
        {
            return System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(base64EncodedData));
        }

        public static FileStreamResult ReturnStreamReport(DataSet dataSet, string webRootPath)
        {
            MemoryStream stream = new MemoryStream();
            var contentType = "application/pdf";

            if (dataSet.Tables[0].Rows.Count != 0)
            {
                using (Report rpt = new Report())
                {
                    rpt.Load(webRootPath);
                    rpt.RegisterData(dataSet, "NorthWind");
                    rpt.PreparePhase1();
                    rpt.PreparePhase2();
                    PDFSimpleExport pdf = new PDFSimpleExport();
                    rpt.Export(pdf, stream);
                }
                stream.Flush();
                byte[] file = stream.ToArray();
                MemoryStream ms1 = new MemoryStream();
                ms1.Write(file, 0, file.Length);
                ms1.Position = 0;
                byte[] bytes = ms1.ToArray();
                return new FileStreamResult(ms1, contentType);
            }
            else
            {
                return new FileStreamResult(stream, contentType);
            }
        }

        public static byte[] ToByteArray(this Bitmap sourceImage, ImageFormat format)
        {
            if (sourceImage == null)
                return null;

            using (MemoryStream targetStream = new MemoryStream())
            {
                sourceImage.Save(targetStream, format);
                targetStream.Close();

                return targetStream.ToArray();
            }
        }

        public static Bitmap ToBitmap(this byte[] bytes)
        {
            if (bytes == null)
                return (Bitmap)null;

            using (MemoryStream targetStream = new MemoryStream(bytes))
            {
                return new Bitmap(targetStream);
            }
        }

        public static bool FileUpload(IFormFile file)
        {
            bool Result = false;
            // Read file path from appsettings
            var filePath = AppSettingDTO.GetValue;

            // Create Folder if not exists
            if (!Directory.Exists(filePath.ImagePath))
                Directory.CreateDirectory(filePath.ImagePath);
            

            string fileNameWithPath = Path.Combine(filePath.ImagePath, file.FileName);

            // Deleting the existing file
            if (System.IO.File.Exists(fileNameWithPath))
            {
                System.IO.File.Delete(fileNameWithPath);
            }

            using (var stream = new FileStream(fileNameWithPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                file.CopyTo(stream);
                Result = true;
            }

            return Result;
        }

        public static string FileUploadName(IFormFile file)
        {
            bool Result = false;
            // Read file path from appsettings
            var filePath = AppSettingDTO.GetValue;

            // Create Folder if not exists
            if (!Directory.Exists(filePath.ImagePath))
                Directory.CreateDirectory(filePath.ImagePath);

            var fileName = DateTime.Now.Ticks + "_" + file.FileName;

            string fileNameWithPath = Path.Combine(filePath.ImagePath, fileName);

            // Deleting the existing file
            if (System.IO.File.Exists(fileNameWithPath))
            {
                System.IO.File.Delete(fileNameWithPath);
            }

            using (var stream = new FileStream(fileNameWithPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                file.CopyTo(stream);
                Result = true;
            }

            if (Result = true)
                return fileName;
            else
                return String.Empty;
        }

        //public static FileAfterAttachment RemoveTempFile(string FileAttachPath, List<int> index, string screenName)
        //{

        //}
    }
}
