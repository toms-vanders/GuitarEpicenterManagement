using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GE.WebAPI.Models
{
    public class ApplicationUserModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public Dictionary<string, string> Roles { get; set; } = new Dictionary<string, string>();
    }
}