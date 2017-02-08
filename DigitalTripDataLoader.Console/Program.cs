using System;
using System.Linq;
using DigitalTripDataLoader.Service;
using DigitalTripDataLoader.Service.Callers;
using DigitalTripDataLoader.Service.Serializers;

namespace DigitalTripDataLoader.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            var caller = new GetPropertiesCaller(new EmptyRequestSeriazlier());

            var response = caller.Call();

            //var loader = new LoaderService(new MoreInfoRequestXmlSerializer());

            //const int id = 145;
            //var guid = Guid.Parse("67e5733e-919d-436a-af55-18c8b3c1eab7");

            //var moreInfoResponse = loader.Load(id, guid);

            System.Console.WriteLine($"Loaded {response.Properties.Count()} properties");

            foreach (var property in response.Properties)
            {
                System.Console.WriteLine($"Property {property.PropertyId} with name {property.PropertyName}");
            }

            System.Console.ReadLine();
        }
    }
}
