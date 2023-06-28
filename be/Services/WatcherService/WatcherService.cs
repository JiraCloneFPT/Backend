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

        public bool CheckWatcher(int? userId, int? issueId)
        {
            return _watcherRepository.CheckWatcher(userId, issueId);
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

        #region PhuNV17
        public List<int> getListWatcher(int issueId)
        {
            return _watcherRepository.getListWatcher(issueId);
        }

        #endregion
    }
}
