using TestTaskYanenko.Models.Repository;

namespace TestTaskYanenko.Models.DataManager
{
    public class RoleManger : IDataRepository<Role>
    {
        readonly Context _context;

        public RoleManger(Context context)
        {
            _context = context;
        }

        public void Add(Role entity)
        {
            _context.Role.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Role entity)
        {
            _context.Role.Remove(entity);
            _context.SaveChanges();
        }

        public Role Get(long id)
        {
            return _context.Role.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Role;
        }

        public void Update(Role dbEntity, Role entity)
        {
            dbEntity.Name = entity.Name;
        }
    }
}
