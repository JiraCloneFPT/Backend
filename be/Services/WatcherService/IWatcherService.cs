namespace be.Services.WatcherService
{
    public interface IWatcherService
    {
        #region HuyNG5 - Code bổ sung
        public void StartWatcherIssue(int? userId, int? issuesId);
        public void StopWatcherIssue(int? userId, int? issuesId);

        public int CountWatcher(int issuesId);

        public bool CheckWatcher(int? userId, int? issueId);
        #endregion

        public List<int> getListWatcher(int issueId);

    }
}
