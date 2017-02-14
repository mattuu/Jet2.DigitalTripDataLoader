using System;
using System.Net;
using System.Threading.Tasks;
using DigitalTripDataLoader.eCommerce.Mappers;
using DigitalTripDataLoader.eCommerce.Models;
using DigitalTripDataLoader.Models.Response;
using DigitalTripDataLoader.Utils;

namespace DigitalTripDataLoader.eCommerce.Services
{
    public class PropertyExporter : IPropertyExporter
    {
        private readonly IAppConfigProvider _appConfigProvider;
        private readonly IPropertyModelJsonSerializer _jsonSerializer;
        private readonly IMapper<MoreInfo, PropertyModel> _moreInfoToPropertyModelMapper;

        private WebClient _webClient;

        public PropertyExporter(IAppConfigProvider appConfigProvider,
                                IPropertyModelJsonSerializer jsonSerializer,
                                IMapper<MoreInfo, PropertyModel> moreInfoToPropertyModelMapper)
        {
            if (appConfigProvider == null) throw new ArgumentNullException(nameof(appConfigProvider));
            if (jsonSerializer == null) throw new ArgumentNullException(nameof(jsonSerializer));
            if (moreInfoToPropertyModelMapper == null) throw new ArgumentNullException(nameof(moreInfoToPropertyModelMapper));
            _appConfigProvider = appConfigProvider;
            _jsonSerializer = jsonSerializer;
            _moreInfoToPropertyModelMapper = moreInfoToPropertyModelMapper;

            _webClient = new WebClient();
        }

        //internal WebClient HttpWebRequest => _webClient ?? (_webClient = WebRequest.CreateHttp(_appConfigProvider.ECommercePropertyMappingEndpoint));

        public async Task Export(MoreInfo moreInfo)
        {
            var propertyModel = _moreInfoToPropertyModelMapper.Map(moreInfo);

            var payload = _jsonSerializer.Serialize(propertyModel);

            var uri = _appConfigProvider.ECommercePropertyMappingEndpoint;

            await _webClient.UploadStringTaskAsync(uri, payload);

            //string result = "";
            //using (var client = new WebClient())
            //{
            //    client.Headers[HttpRequestHeader.ContentType] = "application/json";
            //    result = client.UploadStringAsync(url, "POST", json);
            //}

            //using (var requestStream = HttpWebRequest.GetRequestStream())
            //{
            //    using (TextWriter textWriter = new StreamWriter(requestStream))
            //    {
            //        await textWriter.WriteAsync(payload);
            //    }
            //}

            //throw new NotImplementedException();
            //return null;
        }
    }
}