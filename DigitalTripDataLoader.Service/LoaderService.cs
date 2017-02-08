using System;
using System.IO;
using System.Net;
using System.Security.Authentication;
using System.Xml.Serialization;
using DigitalTripDataLoader.Models.Response;
using DigitalTripDataLoader.Service.Serializers;

namespace DigitalTripDataLoader.Service
{
    public class LoaderService : IDisposable
    {
        private readonly MoreInfoRequestXmlSerializer _moreInfoRequestXmlSerializer;
        private Stream _requestStream;

        public LoaderService(MoreInfoRequestXmlSerializer moreInfoRequestXmlSerializer)
        {
            if (moreInfoRequestXmlSerializer == null) throw new ArgumentNullException(nameof(moreInfoRequestXmlSerializer));
            _moreInfoRequestXmlSerializer = moreInfoRequestXmlSerializer;
        }

        public void Dispose()
        {
            _requestStream.Dispose();
        }

        public MoreInfoResponse Load(int id, Guid guid)
        {
            var request = (HttpWebRequest) WebRequest.Create("http://solmarxml.digital-trip.co.uk/accommodation.api");
            request.Method = "POST";
            request.ContentType = "application/xml; charset=utf-8";
            request.Accept = "application/xml; charset=utf-8";
            request.Host = "solmarxml.digital-trip.co.uk";
            request.Headers.Add("AuthCode", "jet2|JhWGR79G");

            _requestStream = request.GetRequestStream();

            var body = _moreInfoRequestXmlSerializer.GetXml(id, guid);

            using (var writer = new StreamWriter(_requestStream))
            {
                writer.Write(body);
            }

            var response = request.GetResponse();

            object resultObj = null;
            var moreInfoSerializer = new XmlSerializer(typeof(MoreInfoResponse));
            var invalidCredentialsSerializer = new XmlSerializer(typeof(InvalidCredentialsResponse));

            using (var responseStream = response.GetResponseStream())
            {
                if (responseStream != null)
                {
                    using (var reader = new StreamReader(responseStream))
                    {
                        var responseString = reader.ReadToEnd();

                        using (TextReader textReader = new StringReader(responseString))
                        {
                            resultObj = (InvalidCredentialsResponse) invalidCredentialsSerializer.Deserialize(textReader);
                            if (resultObj != null)
                            {
                                var invalidCredentialsResponse = ((InvalidCredentialsResponse) resultObj);
                                throw new InvalidCredentialException(invalidCredentialsResponse.Message);
                            }

                            resultObj = (MoreInfoResponse) moreInfoSerializer.Deserialize(textReader);
                        }
                    }
                }
            }


            return (MoreInfoResponse) resultObj;
        }
    }
}