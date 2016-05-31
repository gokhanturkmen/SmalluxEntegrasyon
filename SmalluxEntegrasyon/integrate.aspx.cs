using System;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace SmalluxEntegrasyon
{
    public partial class integrate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string sId = Request.QueryString["supplier"];
                int s;

                if (int.TryParse(sId, out s))
                {
                    string settingsFile = Path.Combine(Server.MapPath("~") + "suppliers.xml");
                    string xml = Logic.XmlBuilder.Build(s, Path.Combine(settingsFile));
                    if (xml != null)
                    {
                        Response.ContentType = "text/xml";
                        byte[] toBytes = Encoding.UTF8.GetBytes(xml);

                        Response.OutputStream.Write(toBytes, 0, toBytes.Length);
                        Response.AddHeader("Content-Disposition", "attachment;filename=products.xml");
                        Response.End();

                        //Response.ContentType = "text/xml";        //Must be 'text/xml'
                        //Response.ContentEncoding = Encoding.UTF8; //We'd like UTF-8
                        //var doc = XDocument.Parse(xml);
                        //doc.Save(Response.Output);                //Save to the text-writer
                        //Response.End();
                    }
                }
            }
            catch (Exception ex)
            {
                LblMessage.Text = "<span class='title'>Message: </span><span class='context'>" + ex.Message + "</span>";
                LblInner.Text = "<span class='title'>InnerException: </span><span class='context'>" + ex.InnerException + "</span>";
                LblMessage.Text = "<span class='title'>Full: </span><span class='context'>" + ex + "</span>";
            }
            
        }
    }
}