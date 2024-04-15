using DataBaseLayout;
using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;
using Perfume.Repositories.Interfaces;

namespace Perfume.Repositories;

public class DeliveryRepository: IDeliveryRepository
{
    private readonly IContext _context;

    public DeliveryRepository(IContext context)
    {
        _context = context;
    }
    public async Task<List<Delivery>> GetDeliveriesAsync()
    {
        var delivery = await _context.Deliveries.Include(x=>x.Perfumes).ToListAsync();

        return delivery;
    }

    public async Task<Delivery> getDeliveryTaskAsync(string name)
    {
        var delivery = await _context.Deliveries.Include(x => x.Perfumes).SingleAsync();
        return delivery;
    }

    public async Task CreateDeliveryAsync(Delivery model)
    {
        await _context.Deliveries.AddAsync(model);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteDeliveryAsync(string name)
    {
        var delivery = await _context.Deliveries.SingleAsync(scp => scp.Name == name);
        _context.Deliveries.Remove(delivery);

        await _context.SaveChangesAsync();
    }
}