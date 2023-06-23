﻿using be.Models;

namespace be.Repositories.WatcherRepository
{
    public class WatcherRepository : IWatcherRepository
    {
        private readonly DbJiraCloneContext _context;

        public WatcherRepository()
        {
            _context = new DbJiraCloneContext();
        }


        public bool CheckWatcher(int? userId, int? issueId)
        {
            // true: chưa watcher
            // false: đã watcher
            var check = _context.Watchers.SingleOrDefault(x => x.IssueId == userId && x.UserId == userId);
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
            var deleteWatcher = _context.Watchers.SingleOrDefault(x => x.IssueId == userId && x.UserId == userId);
            _context.Watchers.Remove(deleteWatcher);
            _context.SaveChanges();
        }
        #endregion
    }
}