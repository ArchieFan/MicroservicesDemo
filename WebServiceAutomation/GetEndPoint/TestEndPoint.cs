using Microsoft.VisualStudio.TestPlatform.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
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

        [Fact]
        public void TestDeserilizationOfJsonResponse()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, geturl))
                {
                    httpRequestMessage.RequestUri = new Uri(geturl);
                    httpRequestMessage.Method = HttpMethod.Get;
                    httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    Task<HttpResponseMessage> httpResponse = client.SendAsync(httpRequestMessage);

                    using (HttpResponseMessage responseMessage = httpResponse.Result)
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

                        List<Stock> stockList = JsonConvert.DeserializeObject<List<Stock>>(data);
                        foreach (var stock in stockList)
                        {
                            output.WriteLine(stock.ticker);
                        }
                        
                    }
                }
            }
        }

        [Fact]
        public void TestDeserilizationOfXMLResponse()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, geturl))
                {
                    httpRequestMessage.RequestUri = new Uri(geturl);
                    httpRequestMessage.Method = HttpMethod.Get;
                    httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                    Task<HttpResponseMessage> httpResponse = client.SendAsync(httpRequestMessage);

                    using (HttpResponseMessage responseMessage = httpResponse.Result)
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

                        // Step 1 - Create the instance of XMLserializer class and pass the model type as an parameter to the constructor of the class
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(XMLArrayOfStock));

                        // Step 2 - Create the instance of TextReader to read the response content
                        TextReader textReader = new StringReader(data);

                        // Step 3 - Call the Deserialize() and pass the instance of text reader as an argument
                        XMLArrayOfStock xmlData = (XMLArrayOfStock) xmlSerializer.Deserialize(textReader)!;
                        foreach (var item in xmlData.XMLStock!)
                        {
                            output.WriteLine(item.Ticker);
                        }
                        
                    }
                }
            }
        }
    }
}
