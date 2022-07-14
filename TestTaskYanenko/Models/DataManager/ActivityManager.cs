using TestTaskYanenko.Models.Repository;
using System.Globalization;

namespace TestTaskYanenko.Models.DataManager
{
    public class ActivityManager : ITimeTracker
    {
        readonly Context _context;

        public ActivityManager(Context context)
        {
            _context = context;
        }

        public void Add(Activity entity)
        {
            _context.Activity.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Activity entity)
        {
            _context.Activity.Remove(entity);
            _context.SaveChanges();
        }

        public Activity Get(long id)
        {
            return _context.Activity.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Activity> GetAll()
        {
            return _context.Activity;
        }

        public void Update(Activity dbEntity, Activity entity)
        {
            dbEntity.Employee = entity.Employee;
            dbEntity.Role = entity.Role;
            dbEntity.Project = entity.Project;
            dbEntity.ActivityType = entity.ActivityType;
        }

        public List<Activity> GetActivityList(int id, DateTime date)
        {
            return _context.Activity.Where(x => 
            (x.Employee.Id == id) && (x.Project.EndDate >= date) && (x.Project.StartDate <= date)).ToList();
        }

        public List<Activity> GetActivityList(int id, int week)
        {
            return _context.Activity.Where(x =>
            (x.Employee.Id == id) && (ISOWeek.GetWeekOfYear(x.Project.EndDate) >= week) && (ISOWeek.GetWeekOfYear(x.Project.StartDate) <= week)).ToList();
        }
    }
}
