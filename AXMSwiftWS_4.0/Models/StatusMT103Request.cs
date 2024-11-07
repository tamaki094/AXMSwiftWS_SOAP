using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AXMSwiftWS_4._0.Models
{
    [DataContract]
    public class StatusMT103Request
    {
        [DataMember]
        public string app { get; set; }
        [DataMember]
        public string user { get; set; }
        [DataMember]
        public string option { get; set; }
        [DataMember]
        public List<Tickets> tickets { get; set; }

        internal string GetTickets()
        {
            string tickets_concat = "";

            foreach (Tickets ticket in tickets)
            {
                tickets_concat += ticket.id + ",";
            }

            return tickets_concat.Remove(tickets_concat.Length - 1);
        }
    }
}
