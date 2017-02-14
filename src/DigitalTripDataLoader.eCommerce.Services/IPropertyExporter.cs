using System.Threading.Tasks;
using DigitalTripDataLoader.Models.Response;

namespace DigitalTripDataLoader.eCommerce.Services
{
    public interface IPropertyExporter
    {
        Task Export(MoreInfo moreInfo);
    }
}