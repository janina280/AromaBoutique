using DataBaseLayout.Models;

namespace Perfume.Repositories.Interfaces;

public interface IFeatureRepository
{
    Task<List<Feature>> GetFeaturesAsync();
    Task CreateFeatureAsync(Feature model);
    Task DeleteFeatureAsync(string name);
}