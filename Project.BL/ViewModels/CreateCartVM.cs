using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.ViewModels
{
    public class CreateCartVM
    {
        [Required(ErrorMessage ="Ad daxil edin")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Sahe daxil edin")]
        public string Specialty { get; set; }


        public IFormFile? File { get; set; } 
    }
}
