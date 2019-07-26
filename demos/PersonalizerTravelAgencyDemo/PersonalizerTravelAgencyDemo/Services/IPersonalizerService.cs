using Microsoft.Azure.CognitiveServices.Personalizer.Models;
using PersonalizerBusinessDemo.Models;
using System.Collections.Generic;

namespace PersonalizerBusinessDemo.Services
{
    public interface IPersonalizerService
    {
        RankResponse GetRecommendations(IList<object> context);
        IList<Article> GetRankedArticles(IList<object> context);
        void Reward(Reward reward);
    }
}
