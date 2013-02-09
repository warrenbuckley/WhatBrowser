using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WhatBrowser.Models;

namespace WhatBrowser.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /Home/SendEmail/
        [HttpPost]
        public ActionResult SendEmail(ContactFormViewModel model)
        {
            //Only send email if the model is valid...
            if (ModelState.IsValid)
            {
                //Need to get contents from page to send in email (html, saved in hidden field)
                var HTML = model.HTMLResults;
                
                //Email Message
                var emailBody       = "<h1>What Browser Report</h1>";
                emailBody          += "<h2>Name: " + model.Name + "</h2>";
                emailBody          += "<h2>Email: " + model.Email + "</h2>";
                emailBody          += "<h2>Company: " + model.Company + "</h2>";
                emailBody          += "<h2>Message:</h2><p>" + model.Message + "</p>";
                emailBody          += "<h2>Date:</h2>" + DateTime.Now.ToString("dd/MM/yy @HH:mm:ss") + "</h2>";
                emailBody          += "<hr/>";
                emailBody          += HTML;

                //Email Object
                MailMessage email   = new MailMessage();
                email.To.Add         (new MailAddress("warren@creativewebspecialist.co.uk", "Warren Buckley"));
                email.From          = new MailAddress(model.Email, model.Name);
                email.Subject       = "What Browser: Browser Report";
                email.Body          = emailBody;
                email.IsBodyHtml    = true;
                email.Priority      = MailPriority.High;

                //SMTP Object
                SmtpClient smtp     = new SmtpClient();
                smtp.Credentials    = new NetworkCredential("warrenbuckley", "R5W5t7A4w");
                smtp.Port           = 587;
                smtp.Host           = "smtp.sendgrid.com";

                try 
	            {	        
		            //Try to send the email
                    smtp.Send(email);

	            }
	            catch (Exception ex)
	            {		            
		            throw;
	            }              

            }

            return RedirectToAction("Index");
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
