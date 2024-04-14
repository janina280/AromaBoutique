using DataBaseLayout.Models;

namespace Perfume.Repositories.Interfaces;

public interface IReviewConversationRepository
{
    Task<List<ReviewConversation>> GetReviewConversationsAsync();
    Task CreateReviewConversationAsync(ReviewConversation model);
    Task DeleteReviewConversationAsync(Guid id);
}