using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AXMSwiftWS_4._0.Models
{
    public class TKEException : Exception
    {
        private string _errorcode;
        private string _errormessage;


        public TKEException(string codigo, string mensaje)
        {
            _errorcode = codigo;
            _errormessage = mensaje;
        }

        public string errorcode
        {
            get
            {
                return _errorcode;
            }
            set
            {
                _errorcode = value;
            }
        }

        public string errormessage
        {
            get
            {
                return _errormessage;
            }
            set
            {
                _errormessage = value;
            }
        }

        public override string Message => errormessage;
    }
}