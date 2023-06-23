namespace be.Repositories.WatcherRepository
{
    public interface IWatcherRepository
    {
        #region HuyNG5 - Code bổ sung
        public void StartWatcherIssue(int? userId, int? issuesId);
        public void StopWatcherIssue(int? userId, int? issuesId);

        public int CountWatcher(int issuesId);

        public bool CheckWatcher(int? userId, int? issueId);
        #endregion
    }
}
