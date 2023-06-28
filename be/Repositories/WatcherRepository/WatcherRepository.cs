using be.Models;

namespace be.Repositories.WatcherRepository
{
    public class WatcherRepository : IWatcherRepository
    {
        private readonly DbJiraCloneContext _context;

        public WatcherRepository()
        {
            _context = new DbJiraCloneContext();
        }


        public bool CheckWatcher(int? issueId, int? userId)
        {
            // true: chưa watcher
            // false: đã watcher
            //var check = _context.Watchers.SingleOrDefault(x => x.IssueId == issueId && x.UserId == userId);
            var check = _context.Watchers.Where(x => x.IssueId == issueId && x.UserId == userId).FirstOrDefault();

            if (check == null)
            {
                return true;
            } else
            {
                return false;
            }
        }

        #region HuyNG5 - code bổ sung
        public int CountWatcher(int issuesId)
        {
            var watcherInIssue = _context.Watchers.Where(x => x.IssueId == issuesId).ToList();
            return watcherInIssue.Count;
        }

        public void StartWatcherIssue(int? userId, int? issuesId)
        {
            Watcher addwatcher = new Watcher();
            addwatcher.UserId = (int)userId;
            addwatcher.IssueId = (int)issuesId;
            _context.Watchers.Add(addwatcher);
            _context.SaveChanges();
        }

        public void StopWatcherIssue(int? userId, int? issuesId)
        {
            var deleteWatcher = _context.Watchers.SingleOrDefault(x => x.IssueId == issuesId && x.UserId == userId);
            
            _context.Watchers.Remove(deleteWatcher);
            _context.SaveChanges();
        }
        #endregion

        #region PhuNV17 
        public List<int> getListWatcher(int issueId)
        {
            return _context.Watchers.Where(x => x.IssueId == issueId).Select(x =>x.UserId).ToList();
        }

        #endregion
    }
}
