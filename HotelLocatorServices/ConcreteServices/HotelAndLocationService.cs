using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Runtime.CompilerServices;
using Anteeo.Hotel.Domain.TransferObjects;
using AnteeoXMLEngine;
using HotelLocatorServices.ServiceInterfaces;

namespace HotelLocatorServices.ConcreteServices
{
    public class HotelAndLocationService<T> : IHotelAndLocation<T> where T:class
    {
        public string TmsToken { get; set; }

        public T[] GetAllHotelAndLocationData(string url, IDictionary<string, string> queryParameters, string token)
        {
            var requestObject = new RequestMessage { QueryString = GetParametersAsQueryString(queryParameters), Token = token, HttpMethod = HttpMethod.GET };
            var responseObject = Request(url, requestObject);
            return responseObject;
        }

        private string GetParametersAsQueryString(IDictionary<string, string> parameterDictionary)
        {
            var queryBuilder = new StringBuilder();
            queryBuilder.Append("?");
            foreach (var key in parameterDictionary.Keys)
            {
                queryBuilder.Append(key + "=" + parameterDictionary[key] + "&");
            }

            return queryBuilder.ToString().Trim('&');
        }

        //////////////////////////////////////////////////////////////////////////////////////////
        //Requires Refactoring!! No time to do this    Not enough time - so mental notes  ////////
        //DRY Principles not adhered too - I should separate common code (httpWebRequest code/////
        //////////////////////////////////////////////////////////////////////////////////////////
        public ResponseMessage Ping(string url, RequestMessage message)
        {
            var responseMessage = new ResponseMessage();
            var request = (HttpWebRequest)HttpWebRequest.Create(url);
            if (!string.IsNullOrEmpty(message.Token))
                request.Headers.Add("Authourization", string.Format("TMS{0}", message.Token));

            var response = (HttpWebResponse)request.GetResponse();
            var isPing = true;
            return GetResponseMessage(response, true);
        }

        private ResponseMessage GetResponseMessage(HttpWebResponse response,bool isPing)
        {
            using (var stream = response.GetResponseStream())
            {
                var streamReader = new StreamReader(stream);
                try
                {
                    if (isPing)
                    {
                        var result = streamReader.ReadToEnd();
                        return new ResponseMessage {Content = new List<string> {result}.ToArray()};
                    }
                    else
                    {
                        var responseMessage = new ResponseMessage();
                        var xml = streamReader.ReadToEnd();
                        var result = AnteeoXmlHelper.ParseFromXmlString(xml);
                        responseMessage.Content = result.ToArray();
                        return responseMessage;
                    }
                }
                catch (Exception e)
                {
                    return new ResponseMessage { Content = new List<string> { string.Format("An error Occured!!: {0}", e.Message) }.ToArray() };
                }
            }
        }
        private T[] Request(string url, RequestMessage message)
        {
            var responseMessage = new ResponseMessage();
            try
            {
                switch (message.HttpMethod)
                {
                    case HttpMethod.GET:
                        var request = (HttpWebRequest)HttpWebRequest.Create(url);
                        request.Headers.Add("Authorization", string.Format("TMS{0}", message.Token));

                        var response = (HttpWebResponse)request.GetResponse();
                        responseMessage = GetResponseMessage(response, false);
                        return responseMessage.Content as T[];
                        break;
                    case HttpMethod.POST:
                        //Implement Post and other HttpVerbs
                        break;
                }

            }
            catch (Exception e)
            {
                responseMessage.Content = new[] { e.Message as T, e.StackTrace as T };
                return responseMessage.Content as T[];
            }

            return responseMessage.Content as T[];
        }
    }
}
