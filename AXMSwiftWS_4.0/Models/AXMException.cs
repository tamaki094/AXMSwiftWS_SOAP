using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AXMSwiftWS_4._0.Models
{
    [DataContract]
    public class AXMException 
    {

        private string _errorcode;
        private string _errormessage;

        [DataMember]
        public string errorcode
        {
            get { return _errorcode; }
            set { _errorcode = value; }
        }

        [DataMember]
        public string errormessage
        {
            get { return _errormessage; }
            set { _errormessage = value; }
        }

        public AXMException(string codigo, string mensaje)
        {
            _errorcode = codigo;
            _errormessage = mensaje;
        }

        
    }
}
