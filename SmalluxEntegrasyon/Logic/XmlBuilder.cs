﻿using SmalluxEntegrasyon.Model;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml.Linq;
using System;

namespace SmalluxEntegrasyon.Logic
{
    public class XmlBuilder
    {
        private static readonly object _lockObj = new object();

        public static string Build(int supplierId, string settingsFile)
        {
            //Get supplier xml options
            Supplier sp = SupplierOps.GetSupplier(supplierId, settingsFile);
            if (sp != null)
            {
                //save supplier xml to server as a temp file
                string localTempXML = DownloadXml(sp.XmlURL);

                // generate xml and return as string
                var xml = new StringBuilder();
                var spXML = XDocument.Load(localTempXML);
                DeleteFile(localTempXML);                                   // delete unnecessary temp file from our host
                var productNodes = spXML.Descendants(sp.GetTagByName("item").Value).ToList();

                int incr = 0;
                xml.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
                xml.AppendLine("<root>");
                foreach (var p in productNodes)
                {
                    xml.AppendLine("<item>");
                    foreach (var tag in sp.Tags)
                    {
                        if (tag.Value == "")
                        {
                            if (tag.Type == TagTypes.SelfClosing)
                            {
                                xml.AppendLine("<" + tag.Name + " />");
                                continue;
                            }

                            xml.Append("<" + tag.Name + ">");
                            var tmp = tag.Default;
                            var num = 0;
                            if (tag.Type == TagTypes.TagName)
                            {
                                xml.AppendLine("</" + tag.Name + ">");
                                continue;
                            }
                            else if (tag.Type == TagTypes.Increment && int.TryParse(tag.Default, out num))
                            {
                                num += incr;
                                incr++;
                                tmp = Escape((num).ToString());
                            }
                            if (tag.CData)
                            {
                                xml.Append("<![CDATA[" + tmp + "]]>");
                            }
                            else
                            {
                                xml.Append(tmp);
                            }
                            xml.AppendLine("</" + tag.Name + ">");
                            continue;
                        }
                        if (p.Element(tag.Value) == null && tag.Parent == "") continue;
                        xml.Append("<" + tag.Name + ">");
                        string value = "";
                        switch (tag.Type)
                        {
                            case TagTypes.Null:
                                break;
                            case TagTypes.TagName:
                                if (tag.Parent != "")
                                {
                                    var temp = p.Descendants(tag.Value).FirstOrDefault();
                                    value = (temp == null) ? "" : temp.Value;
                                }
                                else
                                {
                                    value = p.Element(tag.Value).Value;
                                }
                                if (tag.CData)
                                {
                                    xml.Append("<![CDATA[" + Escape(value) + "]]>");
                                }
                                else
                                {
                                    xml.Append(Escape(value));
                                }
                                break;
                            case TagTypes.Combine:
                                var elms = tag.Value.Split(tag.SplitChar[0]);
                                if (tag.CData)
                                {
                                    xml.Append("<![CDATA[");
                                    foreach (var elm in elms)
                                    {
                                        var subValue = p.Element(sp.GetTagByName(elm).Value).Value.Trim(tag.CombineChar[0]);
                                        xml.Append(Escape(p.Element(sp.GetTagByName(elm).Value).Value + tag.CombineChar[0]));
                                    }
                                    xml.Length--;
                                    xml.Append("]]>");
                                }
                                else
                                {
                                    foreach (var elm in elms)
                                    {
                                        var subValue = p.Element(sp.GetTagByName(elm).Value).Value.Trim(tag.CombineChar[0]);
                                        xml.Append(Escape(p.Element(sp.GetTagByName(elm).Value).Value + tag.CombineChar[0]));
                                    }
                                }
                                break;
                            case TagTypes.Split:
                                value = p.Element(tag.Value).Value;
                                var sValue = value.Split(tag.SplitChar[0]);
                                value = string.Join(tag.CombineChar, sValue);
                                if (tag.CData)
                                {
                                    xml.Append("<![CDATA[" + Escape(value) + "]]>");
                                }
                                else
                                {
                                    xml.Append(Escape(value));
                                }
                                break;
                            case TagTypes.Increment:

                                break;
                            case TagTypes.SelfClosing:

                                break;
                            default:
                                break;
                        }

                        xml.AppendLine("</" + tag.Name + ">");
                    }
                    xml.AppendLine("</item>");
                }
                xml.AppendLine("</root>");
                return xml.ToString();
            }
            else
            {
                return null;
            }

        }

        private static string Escape(string text) { return text.Replace("&", "&amp;").Replace("<", "&lt;"); }

        private static void DeleteFile(string localTempXML)
        {
            lock (_lockObj)
            {
                if (File.Exists(localTempXML)) ;
                {
                    File.Delete(localTempXML);
                }
            }
        }

        private static string DownloadXml(string xmlURL)
        {
            lock (_lockObj)
            {
                string localTemp = Path.Combine(HttpRuntime.AppDomainAppPath, "TempFiles/temp");
                int i = 0;
                while (File.Exists(localTemp + i.ToString() + ".xml"))
                {
                    i++;
                }
                localTemp += i.ToString() + ".xml";
                WebClient Client = new WebClient();
                Client.DownloadFile(xmlURL, localTemp);
                return localTemp;
            }
        }


    }
}
