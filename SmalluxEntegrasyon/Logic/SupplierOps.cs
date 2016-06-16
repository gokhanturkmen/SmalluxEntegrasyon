using SmalluxEntegrasyon.Model;
using System;
using System.Linq;
using System.Xml.Linq;

namespace SmalluxEntegrasyon.Logic
{
    class SupplierOps
    {
        internal static Supplier GetSupplier(int supplierId, string settingsFile)
        {
            var xmlSettings = settingsFile;
            XDocument xml = XDocument.Load(xmlSettings);

            var query = (from c in xml.Root.Descendants("supplier")
                         where (int)c.Attribute("id") == supplierId
                         select c).FirstOrDefault();
            if (query != null)
            {
                Supplier sp = new Supplier();
                sp.Id = supplierId;
                sp.Name = query.Attribute("name").Value;
                sp.Site = query.Attribute("site").Value;
                sp.XmlURL = query.Attribute("xmlurl").Value;
                foreach (var item in query.Descendants("tags").Descendants())
                {
                    try
                    {
                        var tag = sp.GetTagByName(item.Name.LocalName);
                        if (tag == null) continue;
                        var type = item.Attribute("type").Value.Trim().ToLower();
                        switch (type)
                        {
                            case "null":
                                tag.Type = TagTypes.Null;
                                break;
                            case "tagname":
                                tag.Type = TagTypes.TagName;
                                break;
                            case "combine":
                                tag.Type = TagTypes.Combine;
                                break;
                            case "split":
                                tag.Type = TagTypes.Split;
                                break;
                            case "increment":
                                tag.Type = TagTypes.Increment;
                                break;
                            case "selfclosing":
                                tag.Type = TagTypes.SelfClosing;
                                break;
                            default:
                                tag.Type = TagTypes.Null;
                                break;
                        }
                        tag.CData = (item.Attribute("cdata").Value.Trim().ToLower() == "true");
                        tag.SplitChar = (string)item.Attribute("splitChar") ?? "";
                        tag.CombineChar = (string)item.Attribute("combineChar") ?? "";
                        tag.Default = (string)item.Attribute("default") ?? "";
                        tag.Parent = (string)item.Attribute("parent") ?? "";
                        tag.ChildLevel = int.Parse((string)item.Attribute("child-level") ?? "0");
                        tag.Value = item.Value.Trim();
                    }
                    catch (Exception) { }
                }

                return sp;
            }
            else
            {
                return null;
            }
        }
    }
}
