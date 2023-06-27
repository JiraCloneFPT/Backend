using be.Models;
using be.Repositories.WatcherRepository;

namespace be.Services.WatcherService
{
    public class WatcherService : IWatcherService
    {
        private readonly IWatcherRepository _watcherRepository;

        public WatcherService()
        {
            _watcherRepository = new WatcherRepository();
        }

        public bool CheckWatcher(int? issueId, int? userId)
        {
            return _watcherRepository.CheckWatcher(issueId, userId);
        }

        #region HuyNG5 - code bổ sung
        public int CountWatcher(int issuesId)
        {
            return _watcherRepository.CountWatcher(issuesId);
        }

        public void StartWatcherIssue(int? userId, int? issuesId)
        {
            _watcherRepository.StartWatcherIssue(userId, issuesId);
        }

        public void StopWatcherIssue(int? userId, int? issuesId)
        {
            _watcherRepository.StopWatcherIssue(userId, issuesId);
        }
        #endregion
    }
}
