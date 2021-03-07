using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        // a nullable boolean variable
        // in other word, WillAttend has three possible values: true, false or null
        public bool? WillAttend { get; set; }
    }
}
