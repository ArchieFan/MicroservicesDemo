using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.Net;

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
            // Close the connection
            client.Dispose();

        }
    }
}