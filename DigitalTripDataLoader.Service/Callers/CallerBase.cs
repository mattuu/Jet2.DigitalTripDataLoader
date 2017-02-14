using System;
using System.IO;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DigitalTripDataLoader.Models.Response;
using DigitalTripDataLoader.Service.Serializers;

namespace DigitalTripDataLoader.Service.Callers
{
    public abstract class CallerBase<TResponse, TRequestSerializer, TInputData> : IDisposable
        where TResponse : ResponseBase
        where TRequestSerializer : IRequestXmlSerializer<TInputData>
    {
        private readonly string _actionHeader;
        private readonly TRequestSerializer _requestSerializer;
        private bool _disposed;
        private HttpWebRequest _request;
        private Stream _requestStream;

        protected CallerBase(TRequestSerializer requestSerializer, string actionHeader)
        {
            if (requestSerializer == null) throw new ArgumentNullException(nameof(requestSerializer));
            if (actionHeader == null) throw new ArgumentNullException(nameof(actionHeader));
            _requestSerializer = requestSerializer;
            _actionHeader = actionHeader;
        }

        private HttpWebRequest Request => _request ?? (_request = ConfigureRequest(_actionHeader));

        public void Dispose()
        {
            if (!_disposed)
            {
                _requestStream.Dispose();
                _disposed = true;
            }
        }

        public virtual async Task<TResponse> Call(TInputData data = default(TInputData))
        {
            var body = _requestSerializer.Serialize(data);

            _requestStream = Request.GetRequestStream();
            using (_requestStream)
            {
                using (var writer = new StreamWriter(_requestStream))
                {
                    writer.Write(body);
                }
            }

            var response = Request.GetResponse();

            ResponseBase resultObj = null;
            var responseSerializer = new XmlSerializer(typeof(TResponse));
            var invalidCredentialsSerializer = new XmlSerializer(typeof(InvalidCredentialsResponse));

            using (var responseStream = response.GetResponseStream())
            {
                if (responseStream != null)
                {
                    using (var reader = new StreamReader(responseStream))
                    {
                        var responseString = await reader.ReadToEndAsync();

                        using (TextReader textReader = new StringReader(responseString))
                        {
                            try
                            {
                                resultObj = (TResponse) responseSerializer.Deserialize(textReader);
                            }
                            catch (Exception)
                            {
                                resultObj = (InvalidCredentialsResponse) invalidCredentialsSerializer.Deserialize(textReader);
                                if (resultObj != null)
                                {
                                    var invalidCredentialsResponse = ((InvalidCredentialsResponse) resultObj);
                                    throw new InvalidCredentialException(invalidCredentialsResponse.Message);
                                }
                            }
                        }
                    }
                }
            }

            return (TResponse) resultObj;
        }

        private static HttpWebRequest ConfigureRequest(string actionHeader)
        {
            var request = (HttpWebRequest) WebRequest.Create("http://solmarxml.digital-trip.co.uk/accommodation.api");
            request.Method = "POST";
            request.ContentType = "application/xml; charset=utf-8";
            request.Accept = "application/xml; charset=utf-8";
            request.Host = "solmarxml.digital-trip.co.uk";
            request.Headers.Add("AuthCode", "jet2|JhWGR79G");
            request.Headers.Add("Action", actionHeader);

            return request;
        }
    }
}