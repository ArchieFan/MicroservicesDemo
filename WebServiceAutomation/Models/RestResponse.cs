using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceAutomation.Models
{
    public class RestResponse
    {
        private readonly int _stateCode;
        private readonly string _responseData;

        public RestResponse(int stateCode, string responseData)
        {
            _stateCode = stateCode;
            _responseData = responseData;
        }

        public int StateCode
        {
            get { return _stateCode; }
        }

        public string ResponseData { 
            get { return _responseData; } 
        }

        public override string ToString()
        {
            return string.Format("StateCode: {0} ResponseData: {1} ", StateCode, ResponseData);
        }
    }
}
