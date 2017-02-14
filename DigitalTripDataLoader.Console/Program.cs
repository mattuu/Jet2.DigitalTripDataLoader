using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DigitalTripDataLoader.Models.Request;
using DigitalTripDataLoader.Service.Callers;
using DigitalTripDataLoader.Service.Serializers;

namespace DigitalTripDataLoader.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = Run();
            task.ContinueWith(t => System.Console.ReadLine());
            Task.WaitAll(task);
        }

        static async Task Run()
        {
            var getPropertiesCaller = new GetPropertiesCaller(new EmptyRequestXmlSerializer());

            var response = await getPropertiesCaller.Call();

            System.Console.WriteLine($"Loaded {response.Properties.Count()} properties");

            var tasks = new HashSet<Task>();
            foreach (var property in response.Properties)
            {
                System.Console.WriteLine($"Property {property.PropertyId} with name {property.PropertyName}");

                var moreInfoCaller = new MoreInformationCaller(new MoreInformationRequestXmlSerializer());
                var moreInfoTask = moreInfoCaller.Call(new MoreInformationRequest
                {
                    Id = property.PropertyId
                });

                tasks.Add(moreInfoTask);

                var path = $"C:\\temp\\DigitalTrip\\{property.PropertyId}_{property.PropertyName}.txt";
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                await moreInfoTask.ContinueWith(moreInfoResponse =>
                {
                    using (var streamWriter = File.CreateText(path))
                    {
                        foreach (var infoItem in moreInfoResponse.Result.MoreInfo.Information)
                        {
                            streamWriter.WriteLine($"Attribute: {infoItem.InfoName}");
                            streamWriter.WriteLine($"Value: {infoItem.InfoValue}");
                            streamWriter.WriteLine();
                        }
                    }
                });
            }

            Task.WaitAll(tasks.ToArray());

            System.Console.ReadLine();
        }
    }
}