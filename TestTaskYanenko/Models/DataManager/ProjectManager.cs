using TestTaskYanenko.Models.Repository;

namespace TestTaskYanenko.Models.DataManager
{
    public class ProjectManager : IDataRepository<Project>
    {
        readonly Context _context;

        public ProjectManager(Context context)
        {
            _context = context;
        }

        public void Add(Project entity)
        {
            _context.Project.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Project entity)
        {
            _context.Project.Remove(entity);
            _context.SaveChanges();
        }

        public Project Get(long id)
        {
            return _context.Project.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Project> GetAll()
        {
            return _context.Project;
        }

        public void Update(Project dbEntity, Project entity)
        {
            dbEntity.StartDate = entity.StartDate;
            dbEntity.EndDate = entity.EndDate;
            dbEntity.Name = entity.Name;
            _context.SaveChanges();
        }
    }
}
