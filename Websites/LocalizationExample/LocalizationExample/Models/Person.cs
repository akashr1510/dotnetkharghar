using LocalizationExample.App_GlobalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocalizationExample.Models
{
    public class Person
    {
        [Display(Name ="Name1", ResourceType = typeof(Resource))]
        public string Name { get; set; }

        public string Message { get; set; }

        public string Today { get; set; }
    }
}