using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AXMSwiftWS_4._0.Models
{
    public class TransfInternacionalDTO
    {
        private string _senderAccount;
        private string _accountHeader;
        private string _bankOperationCode;
        private string _amountInformation;
        private string _orderingAccount;
        private string _correspondentBankId;
        private string _beneficiaryAccount;
        private string _senderShortName;
        private string _mainReference;
        private string _accountType;
        private string _beneficiaryName;
        private string _beneficiaryMainAddress;
        private string _beneficiaryAddressStreet;
        private string _beneficiaryAddressZone;
        public long idMessage { get; set; }
        public string senderHeader { get; set; }
        public string accountHeader
        {
            get
            {
                return _accountHeader;
            }
            set
            {
                value = value.Substring(4, (value.Length - 4));
                _accountHeader = value;
            }
        }
        public string bankOperationCode
        {
            get
            {
                return _bankOperationCode;
            }
            set
            {
                value = value.Substring(5, (value.Length - 5));
                _bankOperationCode = value;
            }
        }
        public string amountInformation
        {
            get
            {
                return _amountInformation;
            }
            set
            {
                value = value.Substring(5, (value.Length - 5));
                value = value.Replace(',', ' ');
                value = value.Replace(" ", "");
                value = value.Trim();
                _amountInformation = value;
            }
        }
        public string senderAccount
        {
            get
            {
                return _senderAccount;
            }
            set
            {
                value = value.Substring(6, (value.Length - 6));
                value = value.Substring(0, 10) + "  ";
                _senderAccount = value;
            }
        }
        public string senderName { get; set; }
        public string senderMainAddress { get; set; }
        public string senderAddressStreet { get; set; }
        public string senderAddressZone { get; set; }
        public string senderCity { get; set; }
        public string senderCountryName { get; set; }
        public string senderCountryCode { get; set; }
        public string orderingAccount
        {
            get
            {
                return _orderingAccount;
            }
            set
            {
                value = value.Substring(7, (value.Length - 7));
                _orderingAccount = value;
            }
        }
        public string orderingName { get; set; }
        public string intermediateBankId { get; set; }
        public string intermediateBankName { get; set; }
        public string intermediateBankAddress { get; set; }
        public string intermediateBankStreet { get; set; }
        public string intermediateBankZone { get; set; }
        public string correspondentBankId
        {
            get
            {
                return _correspondentBankId;
            }
            set
            {
                value = value.Substring(7, (value.Length - 7));
                _correspondentBankId = value;
            }
        }
        public string correspondentBankName { get; set; }
        public string correspondentBankLocation { get; set; }
        public string beneficiaryAccount
        {
            get
            {
                return _beneficiaryAccount;
            }
            set
            {
                value = value.Substring(6, (value.Length - 6));
                _beneficiaryAccount = value;
            }
        }
        public string beneficiaryName
        {
            get
            {
                return _beneficiaryName;
            }
            set
            {
                value = value.Substring(2, (value.Length - 2));
                _beneficiaryName = value;
            }
        }
        public string beneficiaryMainAddress
        {
            get
            {
                return _beneficiaryMainAddress;
            }
            set
            {
                value = value.Substring(2, (value.Length - 2));
                _beneficiaryMainAddress = value;
            }
        }
        public string beneficiaryAddressStreet
        {
            get
            {
                return _beneficiaryAddressStreet;
            }
            set
            {
                value = value.Substring(2, (value.Length - 2));
                _beneficiaryAddressStreet = value;
            }
        }
        public string beneficiaryAddressZone
        {
            get
            {
                return _beneficiaryAddressZone;
            }
            set
            {
                value = value.Substring(2, (value.Length - 2));
                _beneficiaryAddressZone = value;
            }
        }
        public string beneficiaryCity { get; set; }
        public string beneficiaryCountryName { get; set; }
        public string beneficiaryCountryCode { get; set; }
        public string senderShortName
        {
            get
            {
                return _senderShortName;
            }
            set
            {
                value = value.Substring(4, (value.Length - 4));
                _senderShortName = value;
            }
        }
        public string mainReference
        {
            get
            {
                return _mainReference;
            }
            set
            {
                value = value.Substring(5, (value.Length - 5));
                _mainReference = value;
            }
        }
        public string accountType
        {
            get
            {
                return _accountType;
            }
            set
            {
                value = value.Substring(4, (value.Length - 4));
                _accountType = value;
            }
        }
        public string detailsCommission { get; set; }
    }
}