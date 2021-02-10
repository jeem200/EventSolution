using Event.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSolution.ViewModels
{
    public class VendorViewModel
    {
        public IFormFile PromoFile { get; set; }
        public VendorModel VendorInfo { get; set; }
    }
}
