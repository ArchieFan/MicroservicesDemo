using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebServiceAutomation.Models;
using Xunit.Abstractions;
using static System.Net.WebRequestMethods;

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

            // Response data
            HttpContent responseContent = responseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            output.WriteLine(data);

            // Close the connection
            client.Dispose();

        }

        [Fact]
        public void TestGetAppEndPointwithURI()
        {
            //Step 1. To create the http client
            HttpClient client = new HttpClient();
            //step 2 & 3. Create the request and execute it
            Uri uri = new Uri(geturl);
            Task<HttpResponseMessage> httpResponse = client.GetAsync(uri);
            HttpResponseMessage responseMessage = httpResponse.Result;
            output.WriteLine(responseMessage.ToString());
            HttpStatusCode statusCode = responseMessage.StatusCode;
            output.WriteLine($"Status Code =>  {statusCode.ToString()}");
            output.WriteLine($"Status Code =>  {(int)statusCode}");

            // Response data
            HttpContent responseContent = responseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            output.WriteLine(data);

            // Close the connection
            client.Dispose();

        }

        [Fact]
        public void TestGetAppEndPointwithInvalidURI()
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

            // Response data
            HttpContent responseContent = responseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            output.WriteLine(data);

            // Close the connection
            client.Dispose();

        }

        [Fact]
        public void TestGetAppEndPointInJsonFormat()
        {
            HttpClient client = new HttpClient();
            HttpRequestHeaders requestHeaders = client.DefaultRequestHeaders;
            requestHeaders.Add("Accept", "application/json");

            Uri uri = new Uri(geturl);
            Task<HttpResponseMessage> httpResponse = client.GetAsync(uri);
            HttpResponseMessage responseMessage = httpResponse.Result;
            output.WriteLine(responseMessage.ToString());
            HttpStatusCode statusCode = responseMessage.StatusCode;
            output.WriteLine($"Status Code =>  {statusCode.ToString()}");
            output.WriteLine($"Status Code =>  {(int)statusCode}");

            // Response data
            HttpContent responseContent = responseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            output.WriteLine(data);

            // Close the connection
            client.Dispose();
        }

        [Fact]
        public void TestGetAppEndPointInXMLFormat()
        {
            HttpClient client = new HttpClient();
            HttpRequestHeaders requestHeaders = client.DefaultRequestHeaders;
            requestHeaders.Add("Accept", "application/xml");

            Uri uri = new Uri(geturl);
            Task<HttpResponseMessage> httpResponse = client.GetAsync(uri);
            HttpResponseMessage responseMessage = httpResponse.Result;
            output.WriteLine(responseMessage.ToString());
            HttpStatusCode statusCode = responseMessage.StatusCode;
            output.WriteLine($"Status Code =>  {statusCode.ToString()}");
            output.WriteLine($"Status Code =>  {(int)statusCode}");

            // Response data
            HttpContent responseContent = responseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            output.WriteLine(data);

            // Close the connection
            client.Dispose();
        }

        [Fact]
        public void TestGetAppEndPointInXMLFormatUsingAccrptHeader()
        {
            HttpClient client = new HttpClient();
            HttpRequestHeaders requestHeaders = client.DefaultRequestHeaders;
            requestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
            //requestHeaders.Add("Accept", "application/xml");

            Uri uri = new Uri(geturl);
            Task<HttpResponseMessage> httpResponse = client.GetAsync(uri);
            HttpResponseMessage responseMessage = httpResponse.Result;
            output.WriteLine(responseMessage.ToString());
            HttpStatusCode statusCode = responseMessage.StatusCode;
            output.WriteLine($"Status Code =>  {statusCode.ToString()}");
            output.WriteLine($"Status Code =>  {(int)statusCode}");

            // Response data
            HttpContent responseContent = responseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            output.WriteLine(data);

            // Close the connection
            client.Dispose();
        }

        [Fact]
        public void TestEndPointUsingSendAsync()
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.RequestUri = new Uri(geturl);
            httpRequestMessage.Method = HttpMethod.Get;
            httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpClient client = new HttpClient();
            Task<HttpResponseMessage> httpResponse = client.SendAsync(httpRequestMessage);
            HttpResponseMessage responseMessage = httpResponse.Result;
            output.WriteLine(responseMessage.ToString());
            HttpStatusCode statusCode = responseMessage.StatusCode;
            output.WriteLine($"Status Code =>  {statusCode.ToString()}");
            output.WriteLine($"Status Code =>  {(int)statusCode}");

            // Response data
            HttpContent responseContent = responseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            output.WriteLine(data);

            // Close the connection
            client.Dispose();
        }

        [Fact]
        public void TestUsingStatement()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, geturl))
                {
                    httpRequestMessage.RequestUri = new Uri(geturl);
                    httpRequestMessage.Method = HttpMethod.Get;
                    httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    Task<HttpResponseMessage> httpResponse = client.SendAsync(httpRequestMessage);
                    
                    using (HttpResponseMessage responseMessage = httpResponse.Result )
                    {
                        //output.WriteLine(responseMessage.ToString());
                        HttpStatusCode statusCode = responseMessage.StatusCode;
                        //output.WriteLine($"Status Code =>  {statusCode.ToString()}");
                        //output.WriteLine($"Status Code =>  {(int)statusCode}");

                        // Response data
                        HttpContent responseContent = responseMessage.Content;
                        Task<string> responseData = responseContent.ReadAsStringAsync();
                        string data = responseData.Result;
                        //output.WriteLine(data);

                        RestResponse restResponse = new RestResponse((int)statusCode, responseData.Result);
                        output.WriteLine(restResponse.ToString());
                    }
                }
            }
        }
    
    }
}
