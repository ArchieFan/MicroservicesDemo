using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace WebServiceAutomation.GetEndPoint
{
    public class TestEndPoint
    {
        private readonly ITestOutputHelper output;

        public TestEndPoint(ITestOutputHelper output)
        {
            this.output = output;
        }

        private string geturl = "https://localhost:5803/api/stocks/";
        [Fact]
        public void TestGetAppEndPoint()
        {
            //Step 1. To create the http client
            HttpClient client = new HttpClient();
            //step 2 & 3. Create the request and execute it
            Task<HttpResponseMessage> httpResponse = client.GetAsync(geturl);
            HttpResponseMessage responseMessage = httpResponse.Result;
            output.WriteLine(responseMessage.ToString());
            HttpStatusCode statusCode = responseMessage.StatusCode;
            output.WriteLine($"Status Code =>  {statusCode.ToString()}");
            output.WriteLine($"Status Code =>  {(int)statusCode}");
            // Close the connection
            client.Dispose();

        }

        [Fact]
        public void TestGetAppEndPointwithURL()
        {
            //Step 1. To create the http client
            HttpClient client = new HttpClient();
            //step 2 & 3. Create the request and execute it
            Uri uri = new Uri(geturl);
            client.GetAsync(uri);

            // Close the connection
            client.Dispose();

        }

        [Fact]
        public void TestGetAppEndPointwithInvalidURL()
        {
            //Step 1. To create the http client
            HttpClient client = new HttpClient();
            //step 2 & 3. Create the request and execute it
            Uri uri = new Uri(geturl + "/invalid");
            Task<HttpResponseMessage> httpResponse = client.GetAsync(uri);
            HttpResponseMessage responseMessage = httpResponse.Result;
            output.WriteLine(responseMessage.ToString());
            HttpStatusCode statusCode = responseMessage.StatusCode;
            output.WriteLine($"Status Code =>  {statusCode.ToString()}");
            output.WriteLine($"Status Code =>  {(int)statusCode}");
            // Close the connection
            client.Dispose();

        }
    }
}
