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
    public class HotelAndLocationService : IHotelAndLocation
    {
        public string TmsToken { get; set; }

        public dynamic[] GetAllHotelAndLocationData(string url, IDictionary<string, string> queryParameters, string token)
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
        public ResponseMessage Ping(string url, RequestMessage message, ModeType modeType)
        {
            var responseMessage = new ResponseMessage();
            var request = (HttpWebRequest)HttpWebRequest.Create(url);
            try
            {
                if (modeType == ModeType.Authentication)
                {
                    var response = (HttpWebResponse) request.GetResponse();
                    return GetResponseMessage(response, ModeType.Authentication);
                }
                else if (modeType == ModeType.Ping)
                {
                    request.Headers.Add("Authourization", string.Format("TMS{0}", message.Token));
                    var response = (HttpWebResponse) request.GetResponse();
                    return GetResponseMessage(response, ModeType.Ping);
                }
            }
            catch (Exception e)
            {
               responseMessage.Content = new[] {e.Message, e.StackTrace};
               return responseMessage;
            }

            responseMessage.Content = new[] { "Unsupported Operation", "Unsupported Operation" };
            return responseMessage;
        }

        private ResponseMessage GetResponseMessage(HttpWebResponse response, ModeType modeType)
        {
            using (var stream = response.GetResponseStream())
            {
                var streamReader = new StreamReader(stream);
                try
                {
                    dynamic result =null;

                    switch(modeType)
                    {
                        case ModeType.Ping:
                        result = streamReader.ReadToEnd();
                        return new ResponseMessage {Content = new List<object> {true}.ToArray()};

                        case ModeType.Request:
                            var responseMessage = new ResponseMessage();
                        var xml = streamReader.ReadToEnd();
                        result = AnteeoXmlHelper.ParseFromXmlString(xml);
                        responseMessage.Content = result.ToArray();
                        return responseMessage;

                        case ModeType.Authentication:
                        result = streamReader.ReadToEnd();
                        return new ResponseMessage { Content = new List<object> { result }.ToArray() };

                    }
                }
                catch (Exception e)
                {
                    return new ResponseMessage { Content = new List<object> { string.Format("An error Occured!!: {0}", e.Message) ,e.StackTrace}.ToArray() };
                }
                return new ResponseMessage{Content = new[]{ "No Service Mode Stated!!"}};
            }
        }
        private dynamic[] Request(string url, RequestMessage message)
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
                        responseMessage = GetResponseMessage(response, ModeType.Request);
                        return responseMessage.Content;

                    case HttpMethod.POST:
                        //Implement Post and other HttpVerbs
                        break;
                }

            }
            catch (Exception e)
            {
                responseMessage.Content = new[] { e.Message, e.StackTrace };
                return responseMessage.Content;
            }

            return responseMessage.Content;
        }
    }
}
