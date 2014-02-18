using ccgMVCApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ccgMVCApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string name, string email)
        {
           
                //ObservableCollection<Product> products = new ObservableCollection<Product>();
                List<Product> products = new List<Product>();

                WebClient client = new WebClient();
                var data = client.DownloadString("http://www.corpcomm.com/ccgwebapi/sample.ashx");
                var jArray = JArray.Parse(data);
                var jArr = jArray[0];

                // products.Clear();
                //  List<Product> products = new List<Product>();
                if (products.Count() == 0)
                {
                    foreach (var j in jArray)
                        products.Add(JsonConvert.DeserializeObject<Product>(j.ToString()));
                }

                if (!String.IsNullOrEmpty(name))
                    products = products.Where(p => p.quantity.Equals(name)).ToList();

                ViewData["_products"] = products;

                if (!String.IsNullOrEmpty(email))
                    sendMail(email);

                return View(products);
            
           // return View();
        }

        protected void sendMail(string email)
        {
            try
            {

                SmtpClient mySmtpClient = new SmtpClient("smtp.gmail.com", 587);

                // set smtp-client with basicAuthentication
                mySmtpClient.UseDefaultCredentials = false;
                System.Net.NetworkCredential basicAuthenticationInfo = new
                   System.Net.NetworkCredential("ogolanick@gmail.com", "gzee6900");
                mySmtpClient.Credentials = basicAuthenticationInfo;

                //if (EmailFromProductLookup)
                //{
                    // add from,to mailaddresses
                    MailAddress from = new MailAddress("ogolanick@gmail.com", "Nick Ogola");
                    MailAddress to = new MailAddress(email, "8th wonder");
                    MailMessage myMail = new System.Net.Mail.MailMessage(from, to);

                    // add ReplyTo
                    MailAddress replyto = new MailAddress("ogolanick@gmail.com");
                    myMail.ReplyTo = replyto;

                    // set subject and encoding
                    myMail.Subject = "Product Details";
                    myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                    // set body-message and encoding
                    myMail.Body = "<b>Below are product details sent to you from " + from;

                    List<Product> products = new List<Product>();

                    products = (List<Product>)ViewData["_products"];
                   
                    if (products.Count() > 1)
                    {
                        foreach (Product product in products)
                        {
                            myMail.Body += " </b><br /><br /><b>Product Sku: </b> " + product.sku +
                            "<br /> <b>Name: </b>" + product.name + "<br /> <b>Description: </b>" + product.description + "<br /> <b>Quantity: </b>" + product.quantity;
                        }
                    }
                    else
                    {
                        myMail.Body += " </b><br /><br /><b>Product Sku: </b> " + products[0].sku +
                            "<br /> <b>Name: </b>" + products[0].name + "<br /> <b>Description: </b>" + products[0].description + "<br /> <b>Quantity: </b>" + products[0].quantity;
                    }

                    myMail.BodyEncoding = System.Text.Encoding.UTF8;
                    // text or html
                    myMail.IsBodyHtml = true;
                    mySmtpClient.EnableSsl = true;
                    mySmtpClient.Send(myMail);
                //}
                //else if (EmailFromContactSection)
                //{
                //    // add from,to mailaddresses
                //    MailAddress from = new MailAddress(email.Value, "Nick Ogola");
                //    MailAddress to = new MailAddress("ogolanick@gmail.com", name.Value);
                //    MailMessage myMail = new System.Net.Mail.MailMessage(from, to);

                //    // add ReplyTo
                //    MailAddress replyto = new MailAddress("ogolanick@gmail.com");
                //    myMail.ReplyTo = replyto;

                //    // set subject and encoding
                //    myMail.Subject = "Customer Contact";
                //    myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                //    // set body-message and encoding
                //    myMail.Body = "<b>Below is a message sent to you from " + name.Value + "<br /><br />" + message.Value;

                //    //"<b>Below are product details sent to you from " + from;

                //    //myMail.Body += " </b><br /><br /><b>Product Sku: </b> " + products[0].sku +
                //    //    "<br /> <b>Name: </b>" + products[0].name + "<br /> <b>Description: </b>" + products[0].description + "<br /> <b>Quantity: </b>" + products[0].quantity;


                //    myMail.BodyEncoding = System.Text.Encoding.UTF8;
                //    // text or html
                //    myMail.IsBodyHtml = true;
                //    mySmtpClient.EnableSsl = true;
                //    mySmtpClient.Send(myMail);
                //}

            }

            catch (SmtpException ex)
            {
                throw new ApplicationException
                  ("SmtpException has occured: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Search(string name)
        {
            //some operations goes here

            return View(); //return some view to the user
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}