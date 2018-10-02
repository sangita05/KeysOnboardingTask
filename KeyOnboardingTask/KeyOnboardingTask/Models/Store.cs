using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeyOnboardingTask.Models
{
    [Bind(Exclude = "Id")]
    public class Store
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Store Name is required")]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Store Address is required")]
        [StringLength(300)]
        public string Address { get; set; }

    }
}