using TestTaskYanenko.Models.Repository;

namespace TestTaskYanenko.Models.DataManager
{
    public class ActivityTypeManager : IDataRepository<ActivityType>
    {
        readonly Context _context;

        public ActivityTypeManager(Context context)
        {
            _context = context;
        }

        public void Add(ActivityType entity)
        {
            _context.ActivityType.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(ActivityType entity)
        {
            _context.ActivityType.Remove(entity);
            _context.SaveChanges();
        }

        public ActivityType Get(long id)
        {
            return _context.ActivityType.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ActivityType> GetAll()
        {
            return _context.ActivityType;
        }

        public void Update(ActivityType dbEntity, ActivityType entity)
        {
            dbEntity.ActivityTypeName = entity.ActivityTypeName;
        }
    }
}
