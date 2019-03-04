using System;
using System.Net;
using System.Xml;
using System.IO;
using System.Security;
using System.Collections.Generic;
using System.Collections;
using System.Web.Script.Serialization;
using System.Text;
using System.Linq;
using PS = Microsoft.ProjectServer.Client;
using SP = Microsoft.SharePoint.Client;

namespace Intersoft_ProjectOnline_QC_2017
{
    /// <summary>
    /// Class for helping around Project Online 
    /// 
    /// </summary>
    class HelperPO
    {
        public HashSet<poTable> Tables { get; set; }
        public HashSet<poField> Fields { get; set; }

        //HelperLog imsLOG = new HelperLog();
        public POSiteSettings oTSCurrent { get; set; } = null;

        // Holder på projectcontext
        private PS.ProjectContext pc;


        /// <summary>
        /// Logger inn i Project online 
        /// </summary>
        /// <returns></returns>
        public int PO_Login()
        {

            // Login to Project Server Online
            SecureString secpassword = new SecureString();
            foreach (char c in oTSCurrent.PO_Password.ToCharArray()) secpassword.AppendChar(c);


            pc = new PS.ProjectContext(oTSCurrent.PO_Site);
            pc.Credentials = new SP.SharePointOnlineCredentials(oTSCurrent.PO_Username, secpassword);

            return 1;
        } // PO Login

        /// <summary>
        /// Henter sikkerhetscookie for bruker til å sjekke om bruker har tilgang
        /// </summary>
        /// <param name="webUri"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        static CookieContainer GetAuthCookies(Uri webUri, string userName, string password)
        {
            var securePassword = new SecureString();
            foreach (var c in password) { securePassword.AppendChar(c); }
            var credentials = new SP.SharePointOnlineCredentials(userName, securePassword);
            var authCookie = credentials.GetAuthenticationCookie(webUri);
            var cookieContainer = new CookieContainer();
            cookieContainer.SetCookies(webUri, authCookie);
            return cookieContainer;
        }

        /// <summary>
        /// Functions to result from project Online
        /// Getting table, fields and table count
        /// </summary>
        /// 
        /// <param name="tmpTable"></param>
        /// <returns></returns>
        private bool xml_getTableCount(poTable tmpTable)
        {
            if (PO_Login()==1)
            {

                string url = oTSCurrent.PO_Site + "/_api/ProjectData/[en-us]//" + tmpTable.TableName + "()?$Top=1&$Inlinecount=allpages";

                var req = (HttpWebRequest)WebRequest.Create(url);
                req.Credentials = pc.Credentials;
                req.Headers["X-FORMS_BASED_AUTH_ACCEPTED"] = "f";

                var resp = (HttpWebResponse)req.GetResponse();
                var receiveStream = resp.GetResponseStream();

                var readStream = new StreamReader(receiveStream, Encoding.UTF8);
                var data = readStream.ReadToEnd();

                XmlDocument xmlDoc = new XmlDocument();

                xmlDoc.LoadXml(data);

                XmlReader oNode = new XmlNodeReader(xmlDoc.DocumentElement);
                XmlNodeList name = xmlDoc.GetElementsByTagName("m:count");

                if (name.Count == 0)
                { }
                else
                {
                    var test = name[0].InnerText;

                    if (Int64.TryParse(test, out Int64 value))
                    {
                        tmpTable.TableCount = value;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Get all tables and fields in Project Online
        /// </summary>
        /// <returns></returns>
        public HashSet<poTable> xml_TableNames()
        {
            HashSet<poTable> colTables = new HashSet<poTable>();
            HashSet<poField> colFields = new HashSet<poField>();


            if (PO_Login()==1)
            {
                int indent = 0;
                
                string url = oTSCurrent.PO_Site + "/_api/ProjectData/[en-us]/$metadata";

                var req = (HttpWebRequest)WebRequest.Create(url);
                req.Credentials = pc.Credentials;

                req.Headers["X-FORMS_BASED_AUTH_ACCEPTED"] = "f";

                var resp = (HttpWebResponse)req.GetResponse();
                var receiveStream = resp.GetResponseStream();

                var readStream = new StreamReader(receiveStream, Encoding.UTF8);

                var data = readStream.ReadToEnd();

                XmlDocument xmlDoc = new XmlDocument();

                xmlDoc.LoadXml(data);

                XmlReader oNode = new XmlNodeReader(xmlDoc.DocumentElement);
                XmlNodeList tmpTables = xmlDoc.GetElementsByTagName("EntityType");


                for (int i = 0; i < tmpTables.Count; i++)
                {
                    poTable newTable = new poTable();
                    XmlNode tmpNode = tmpTables[i];
                    if (tmpNode.Attributes.Count == 1)
                    {
                        // Getting the table name
                        XmlAttribute tmpAttr = tmpNode.Attributes[0];

                        newTable.TableName = tmpAttr.Value;

                        // Check property to all fields and results
                        if (tmpNode.HasChildNodes)
                        {
                            foreach (XmlNode t in tmpNode.ChildNodes)
                            {
                                switch (t.Name)
                                {
                                    case "Key":
                                        XmlAttributeCollection oAttrKeys = t.Attributes;

                                        foreach (XmlAttribute oAttKey in oAttrKeys)
                                        {
                                            switch (oAttKey.Name)
                                            {
                                                case "Name":
                                                    break;
                                                case "Nullable":
                                                    break;
                                                case "Type":
                                                    break;
                                            }
                                        }
                                        break;
                                    case "Property":
                                        poField newField = new poField();
                                        // Getting all fields for the tables
                                        XmlAttributeCollection oAttFields = t.Attributes;

                                        foreach (XmlAttribute oAttField in oAttFields)
                                        {
                                            switch (oAttField.Name)
                                            {
                                                case "Name":
                                                    newField.Fieldname = oAttField.Value;
                                                    break;
                                                case "Nullable":
                                                    if (oAttField.Value == "true")
                                                    {
                                                        newField.Fieldnullable = true;
                                                    }
                                                    break;
                                                case "Type":
                                                    newField.Fieldtype = oAttField.Value;
                                                    break;
                                            }
                                        }

                                        newField.TableName = newTable.TableName;
                                        newTable.Fields.Add(newField);
                                        colFields.Add(newField);

                                        break;
                                    case "NavigationProperty":
                                        break;

                                }
                            }
                        }
                    }

                    if (newTable.Validate())
                    {
                        colTables.Add(newTable);
                    }
                }

                this.Tables = colTables;
                this.Fields = colFields;

                //DataSet oDS = new DataSet();
                //oDS.ReadXml(oNode);

                //GetTables(oDS);
            }
            return colTables;
        }

        public bool xml_getTableCountAll()
        {
            bool bStatus = true;

            foreach(poTable otable in this.Tables)
            {

                if (xml_getTableCount(otable))
                {
                    // Save to database

                }
            }

            return bStatus;
        }

        public bool PO_getCustomFields(HashSet<poField> colFields)
        {

            if (PO_Login() == 1)
            {
                
                pc.Load(pc.LookupTables);
                //pc.ExecuteQuery();
                

                pc.Load(pc.CustomFields);
                pc.ExecuteQuery();

                foreach (var cf in pc.CustomFields)
                {
                    pc.Load(cf.EntityType);
                    pc.Load(cf.LookupTable);

                    pc.ExecuteQuery();


                    //Console.WriteLine("customfield:" + cf.Name + " Internalname:" + cf.InternalName);
                    //Console.WriteLine("Id:" + cf.Id + " Entitytype:" + cf.EntityType.Name);
                    string tmpName = RemoveSpecialCharacters(cf.Name);

                    poField otmpField = colFields.Where(w => w.Fieldname.Contains(tmpName)).FirstOrDefault();
                    var result = colFields.Where(w => w.Fieldname.Contains(tmpName));

                    var dictionary = result.ToDictionary(h => h, h => (object)null);

                    foreach (var pair in dictionary)
                    {

                        poField otmpField2 = (poField)pair.Key;
                        otmpField2.IsCustomfield = true;
                        otmpField2.FieldGUid = cf.Id;
                        otmpField2.InternalName = cf.InternalName;
                        otmpField2.EntityName = cf.EntityType.Name;
                        otmpField2.Description = cf.Description;
                        otmpField2.InternalFieldType = cf.FieldType.ToString();

                        try
                        {
                            otmpField2.LookupTable = cf.LookupTable.Name;
                        }
                        catch(Exception ex)
                        {
                            otmpField2.LookupTable = "";
                        }


                    }


                    /*
                    if (dictionary.Count>1)
                    {
                        Console.Write(dictionary.Count.ToString());
                    }

                    if ( otmpField != null)
                    {
                        otmpField.IsCustomfield = true;
                        Console.WriteLine("customfield(" + tmpName + "):" + cf.EntityType.Name);
                    }
                    else
                    {
                        Console.WriteLine("customfield(" + tmpName + "):" + cf.Name + " Internalname:" + cf.InternalName);
                    }
                    */

                    var test = cf.LookupTable.GetType();
                    //Console.WriteLine("LT:" + cf.LookupTable.Name);

                }
            }
            return true;
        }
        public string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }



    }// Class HelperPO

    /// <summary>
    /// Table objects
    /// </summary>
    class poTable
    {
        public string TableName { get; set; } = "";
        public string TableFullName { get; set; } = "";
        public int TableIndex { get; set; } = -1;
        public Int64 TableCount { get; set; } = 0;
        public DateTime LastUpdate { get; set; }
        public HashSet<poField> Fields { get; set; } = new HashSet<poField>();

        public bool Validate()
        {
            bool bStatus = false;
            try
            {
                if (this.TableName == "Time" || this.TableName.Contains("Data"))
                {
                    this.TableName = this.TableName + "Set";
                }
                else
                {
                    if (this.TableName == "TimesheetClass")
                    { this.TableName = "TimesheetClasses"; }
                    else
                    {
                        if (this.TableName.EndsWith("s"))
                        {
                            this.TableName = this.TableName;
                        }
                        else
                        {
                            this.TableName = this.TableName + "s";
                        }
                    }
                }

                bStatus = true;
            }
            catch
            {

            }

            return bStatus;
        }

        public string OData_Count()
        {
            string url = "https://" + "[domain]" + ".sharepoint.com/sites/" + "[pwa]" + "/_api/ProjectData/[en-us]//" + TableName + "()?$Inlinecount=allpages";

            return url;
        }

    } // Class POTable

    /// <summary>
    /// Fields in a table
    /// </summary>
    class poField
    {

        public string Fieldname { get; set; }
        public string Fieldtype { get; set; }
        public bool Fieldnullable { get; set; }
        public bool Fieldrequird { get; set; }
        public Int64 TableIndex { get; set; }
        public string TableName { get; set; }

        public Guid FieldGUid { get; set; }
        public string InternalName { get; set; } = "";

        public string EntityName { get; set; } = "Standard";
        public bool IsCustomfield { get; set; }

        public string Description { get; set; }
        public string InternalFieldType { get; set; }

        public string LookupTable { get; set; } = "";


        public string Database_Field()
        {
            string tmpDBFieldAdd;
            switch (Fieldtype.ToUpper())
            {
                case "EDM.BOOLEAN":
                    {
                        tmpDBFieldAdd = "[" + Fieldname + "] [bit] NULL";
                        break;
                    }
                case "EDM.BYTE":
                    {
                        tmpDBFieldAdd = "[" + Fieldname + "] [decimal](25, 6) NULL";
                        break;
                    }
                case "EDM.DATETIME":
                    {
                        tmpDBFieldAdd = "[" + Fieldname + "] DATETIME NULL";
                        break;
                    }
                case "EDM.DECIMAL":
                    {
                        tmpDBFieldAdd = "[" + Fieldname + "] [decimal](25, 6) NULL";
                        break;
                    }
                case "EDM.GUID":
                    {
                        tmpDBFieldAdd = "[" + Fieldname + "] [uniqueidentifier] NULL";
                        break;
                    }
                case "EDM.INT16":
                    {
                        tmpDBFieldAdd = "[" + Fieldname + "] [smallint] NULL";
                        break;
                    }
                case "EDM.INT32":
                    {
                        tmpDBFieldAdd = "[" + Fieldname + "] [int] NULL";
                        break;
                    }
                case "EDM.STRING":
                    {
                        tmpDBFieldAdd = "[" + Fieldname + "] [nvarchar](max) NULL";
                        break;
                    }
                case "EDM.DOUBLE":
                    {
                        tmpDBFieldAdd = "[" + Fieldname + "] [nvarchar](max) NULL";
                        break;
                    }
                default:
                    {
                        tmpDBFieldAdd = "* NB  [" + Fieldname + "] [" + Fieldtype.ToUpper() + " NB *";
                        break;
                    }
            }

            return tmpDBFieldAdd;
        } // end of function
    }// Class poFields

    /// <summary>
    /// Helping parse xml strings
    /// </summary>
    class HelperXMLParse
    {
        

    }// HelperXMLParse

}// Namespace Intersoft_ProjectOnline_QC_2017
