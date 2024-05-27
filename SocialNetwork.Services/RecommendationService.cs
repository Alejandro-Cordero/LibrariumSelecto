using SocialNetwork.Core;
using SocialNetwork.Core.Models;
using SocialNetwork.Core.Services;

namespace SocialNetwork.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RecommendationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Recommendation> CreateRecommendation(Recommendation recommendation)
        {
            await _unitOfWork.RecomendRepo.AddAsync(recommendation);
            await _unitOfWork.CommitAsync();
            return recommendation;
        }

        public async Task DeleteRecommendation(Recommendation recommendation)
        {
            _unitOfWork.RecomendRepo.Remove(recommendation);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Recommendation>> GetAll()
        {
            return await _unitOfWork.RecomendRepo.GetAllWithUserAsync();
        }



        public async Task<Recommendation> GetRecommendationById(int id)
        {
            return await _unitOfWork.RecomendRepo.GetWithUserByIdAsync(id);
        }


    }
}