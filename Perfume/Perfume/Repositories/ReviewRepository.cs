using DataBaseLayout.Models;
using DataBaseLayout;
using Microsoft.EntityFrameworkCore;
using Perfume.Repositories.Interfaces;

namespace Perfume.Repositories;

public class ReviewRepository: IReviewRepository
{
        private readonly IContext _context;

        public ReviewRepository(IContext context)
        {
            _context = context;
        }
        public async Task<List<Review>> GetReviewsAsync()
        {
            var review = await _context.Reviews
                .Include(x=>x.User)
                .Include(x=>x.Perfume)
                .Include(x=>x.ReviewConversations)
                .ToListAsync();

            return review;
        }

        public async Task<Review> GetReviewAsync(Guid id)
        {
            var review = await _context.Reviews
                .Include(x => x.User)
                .Include(x => x.Perfume)
                .Include(x => x.ReviewConversations)
                .SingleAsync();
            return review;
        }

        public async Task CreateReviewAsync(Review model)
        {
            await _context.Reviews.AddAsync(model);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteReviewAsync(Guid id)
        {
            var review = await _context.Reviews.SingleAsync(scp => scp.Id == id);
            _context.Reviews.Remove(review);

            await _context.SaveChangesAsync();
        }
    }