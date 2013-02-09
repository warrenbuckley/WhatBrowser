using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhatBrowser.Models
{
    public class ContactFormViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Company { get; set; }

        public string Message { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string HTMLResults { get; set; }
    }
}