﻿namespace be.Repositories.WatcherRepository
{
    public interface IWatcherRepository
    {
        #region HuyNG5 - Code bổ sung
        public void StartWatcherIssue(int? userId, int? issuesId);
        public void StopWatcherIssue(int? userId, int? issuesId);

        public int CountWatcher(int issuesId);

        public bool CheckWatcher(int? issueId, int? userId);
        #endregion
        #region PhuNV17
        public List<int> getListWatcher(int issueId);

        #endregion
    }
}
