﻿using DataBaseLayout.Models;

namespace Perfume.Repositories.Interfaces;

public interface IReviewRepository
{
    Task<List<Review>> GetReviewsAsync();
    Task<Review> GetReviewAsync(Guid id);
    Task CreateReviewAsync(Review model);
    Task DeleteReviewAsync(Guid id);
}