using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AXMSwiftWS_4._0.Models
{
    [DataContract]
    public class TKEResponse
    {
        private string _code;
        private string _message;


        public TKEResponse(string codigo, string mensaje)
        {
            _code = codigo;
            _message = mensaje;
        }

        [DataMember]
        public string code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
            }
        }

        [DataMember]
        public string message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
            }
        }


    }
}