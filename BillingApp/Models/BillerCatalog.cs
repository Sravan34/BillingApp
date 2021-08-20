using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingApp.Models
{
    public class BillerCatalog
    {
        public long BillerID { get; set; }
        public string BillerDescription { get; set; }
        public string BillerName { get; set; }
        public string BillerType { get; set; }
        public int CatalogVersion { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public int Id { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }
}