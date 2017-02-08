using System.IO;
using System.Linq;
using DigitalTripDataLoader.Models.Request;
using DigitalTripDataLoader.Service.Callers;
using DigitalTripDataLoader.Service.Serializers;

namespace DigitalTripDataLoader.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var getPropertiesCaller = new GetPropertiesCaller(new EmptyRequestXmlSerializer());

            var response = getPropertiesCaller.Call();

            System.Console.WriteLine($"Loaded {response.Properties.Count()} properties");

            foreach (var property in response.Properties)
            {
                System.Console.WriteLine($"Property {property.PropertyId} with name {property.PropertyName}");

                var moreInfoCaller = new MoreInformationCaller(new MoreInformationRequestXmlSerializer());
                var moreInfoResponse = moreInfoCaller.Call(new MoreInformationRequest
                {
                    Id = property.PropertyId
                });

                var path = $"C:\\temp\\DigitalTrip\\{property.PropertyId}_{property.PropertyName}.txt";
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                using (var streamWriter = File.CreateText(path))
                {
                    foreach (var infoItem in moreInfoResponse.MoreInfo.Information)
                    {
                        streamWriter.WriteLine($"Attribute: {infoItem.InfoName}, Value: {infoItem.InfoValue}");
                    }
                }
            }

            System.Console.ReadLine();
        }
    }
}