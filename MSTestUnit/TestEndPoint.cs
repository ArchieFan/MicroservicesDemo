using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.Net;
using System.Net.Http.Headers;

namespace MSTestUnit
{
    [TestClass]
    public class TestEndPoint
    {
        private string geturl = "https://localhost:5803/api/stocks/";

        [TestMethod]
        public void TestGetAppEndPoint()
        {
            Console.WriteLine("Test Start");
            //Step 1. To create the http client
            HttpClient client = new HttpClient();
            //step 2 & 3. Create the request and execute it
            Task<HttpResponseMessage> httpResponse = client.GetAsync(geturl);
            HttpResponseMessage responseMessage = httpResponse.Result;
            Console.WriteLine(responseMessage.ToString());
            HttpStatusCode statusCode = responseMessage.StatusCode;
            Console.WriteLine($"Status Code =>  {statusCode.ToString()}");
            Console.WriteLine($"Status Code =>  {(int)statusCode}");

            // Response data
            HttpContent responseContent = responseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);

            // Close the connection
            client.Dispose();

        }

        [TestMethod]
        public void TestGetAppEndPointwithURI()
        {
            //Step 1. To create the http client
            HttpClient client = new HttpClient();
            //step 2 & 3. Create the request and execute it
            Uri uri = new Uri(geturl);
            Task<HttpResponseMessage> httpResponse = client.GetAsync(uri);
            HttpResponseMessage responseMessage = httpResponse.Result;
            Console.WriteLine(responseMessage.ToString());
            HttpStatusCode statusCode = responseMessage.StatusCode;
            Console.WriteLine($"Status Code =>  {statusCode.ToString()}");
            Console.WriteLine($"Status Code =>  {(int)statusCode}");

            // Response data
            HttpContent responseContent = responseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);

            // Close the connection
            client.Dispose();

        }

        [TestMethod]
        public void TestGetAppEndPointwithInvalidURI()
        {
            //Step 1. To create the http client
            HttpClient client = new HttpClient();
            //step 2 & 3. Create the request and execute it
            Uri uri = new Uri(geturl + "/invalid");
            Task<HttpResponseMessage> httpResponse = client.GetAsync(uri);
            HttpResponseMessage responseMessage = httpResponse.Result;
            Console.WriteLine(responseMessage.ToString());
            HttpStatusCode statusCode = responseMessage.StatusCode;
            Console.WriteLine($"Status Code =>  {statusCode.ToString()}");
            Console.WriteLine($"Status Code =>  {(int)statusCode}");

            // Response data
            HttpContent responseContent = responseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);

            // Close the connection
            client.Dispose();

        }

        [TestMethod]
        public void TestGetAppEndPointInJsonFormat()
        {
            HttpClient client = new HttpClient();
            HttpRequestHeaders requestHeaders = client.DefaultRequestHeaders;
            requestHeaders.Add("Accept", "application/json");

            Uri uri = new Uri(geturl);
            Task<HttpResponseMessage> httpResponse = client.GetAsync(uri);
            HttpResponseMessage responseMessage = httpResponse.Result;
            Console.WriteLine(responseMessage.ToString());
            HttpStatusCode statusCode = responseMessage.StatusCode;
            Console.WriteLine($"Status Code =>  {statusCode.ToString()}");
            Console.WriteLine($"Status Code =>  {(int)statusCode}");

            // Response data
            HttpContent responseContent = responseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);

            // Close the connection
            client.Dispose();
        }

        [TestMethod]
        public void TestGetAppEndPointInXMLFormat()
        {
            HttpClient client = new HttpClient();
            HttpRequestHeaders requestHeaders = client.DefaultRequestHeaders;
            requestHeaders.Add("Accept", "application/xml");

            Uri uri = new Uri(geturl);
            Task<HttpResponseMessage> httpResponse = client.GetAsync(uri);
            HttpResponseMessage responseMessage = httpResponse.Result;
            Console.WriteLine(responseMessage.ToString());
            HttpStatusCode statusCode = responseMessage.StatusCode;
            Console.WriteLine($"Status Code =>  {statusCode.ToString()}");
            Console.WriteLine($"Status Code =>  {(int)statusCode}");

            // Response data
            HttpContent responseContent = responseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);

            // Close the connection
            client.Dispose();
        }

    }
}