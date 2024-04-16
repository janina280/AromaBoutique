using DataBaseLayout.Models;
using DataBaseLayout;
using Microsoft.EntityFrameworkCore;
using Perfume.Repositories.Interfaces;

namespace Perfume.Repositories;

public class ReviewConversationRepository: IReviewConversationRepository
{

    private readonly IContext _context;

    public ReviewConversationRepository(IContext context)
    {
        _context = context;
    }
    public async Task<List<ReviewConversation>> GetReviewConversationsAsync()
    {
        var reviewConversation = await _context.ReviewConversations.Include(x=>x.User).ToListAsync();

        return reviewConversation;
    }

    public async Task<ReviewConversation> GetReviewConversationAsync(Guid id)
    {
        var reviewConversation = await _context.ReviewConversations.Include(x => x.User).SingleAsync(rc => rc.Id == id);
        return reviewConversation;
    }

    public async Task CreateReviewConversationAsync(ReviewConversation model)
    {
        await _context.ReviewConversations.AddAsync(model);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteReviewConversationAsync(Guid id)
    {
        var reviewConversation = await _context.ReviewConversations.SingleAsync(scp => scp.Id == id);
        _context.ReviewConversations.Remove(reviewConversation);

        await _context.SaveChangesAsync();
    }
}