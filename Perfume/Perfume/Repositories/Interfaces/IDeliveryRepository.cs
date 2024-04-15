using DataBaseLayout.Models;

namespace Perfume.Repositories.Interfaces;

public interface IDeliveryRepository
{
    Task<List<Delivery>> GetDeliveriesAsync();
    Task<Delivery> getDeliveryTaskAsync(string name);
    Task CreateDeliveryAsync(Delivery model);
    Task DeleteDeliveryAsync(string name);
}