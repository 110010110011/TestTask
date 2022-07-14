namespace TestTaskYanenko.Models.Repository
{
    public interface ITimeTracker : IDataRepository<Activity>
    {
        List<Activity> GetActivityList(int id, DateTime date);
        List<Activity> GetActivityList(int id, int week);
    }
}
