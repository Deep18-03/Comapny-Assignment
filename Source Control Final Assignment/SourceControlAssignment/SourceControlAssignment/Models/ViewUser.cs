using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SourceControlAssignment.Models
{
    public class ViewUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }

        public string Address { get; set; }

        public string MobileNo { get; set; }

        public Nullable<int> Age { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string image { get; set; }
    }
}