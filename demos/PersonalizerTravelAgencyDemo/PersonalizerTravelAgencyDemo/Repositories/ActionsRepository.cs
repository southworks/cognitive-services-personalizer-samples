using Microsoft.Azure.CognitiveServices.Personalizer.Models;
using PersonalizerBusinessDemo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalizerBusinessDemo.Repositories
{
    public class ActionsRepository : IActionsRepository
    {
        private IList<RankableActionWithMetadata> _actions = new List<RankableActionWithMetadata>();

        public ActionsRepository(IArticleRepository articleRepository)
        {
            var articles = articleRepository.GetArticles();

            CreateRankableActions(articles);
        }

        public IList<RankableAction> GetActions()
        {
            return _actions.Cast<RankableAction>().ToList();
        }

        public IList<RankableActionWithMetadata> GetActionsWithMetadata()
        {
            return _actions;
        }

        private void CreateRankableActions(IEnumerable<Article> articles)
        {
            foreach (var article in articles)
            {
                CreateRankableAction(article).Wait();
            }

            _actions = _actions.OrderBy(a => a.Id).ToList();
        }

        private async Task CreateRankableAction(Article article)
        {
            this._actions.Add(new RankableActionWithMetadata(article));
        }
    }
}