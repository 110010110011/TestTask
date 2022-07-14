using TestTaskYanenko.Models.Repository;

namespace TestTaskYanenko.Models.DataManager
{
    public class EmployeeManager : IDataRepository<Employee>
    {
        readonly Context _context;
        public EmployeeManager(Context context)
        {
            _context = context;
        }

        public void Add(Employee entity)
        {
            _context.Employee.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Employee entity)
        {
            _context.Employee.Remove(entity);
            _context.SaveChanges();
        }

        public Employee Get(long id)
        {
            return _context.Employee.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Employee> GetAll()
        {
            var a = _context.Employee;
            return a;
        }

        public void Update(Employee dbEntity, Employee entity)
        {
            dbEntity.Sex = entity.Sex;
            dbEntity.DateBirthday = entity.DateBirthday;
            dbEntity.Name = entity.Name;
            dbEntity.Activities = entity.Activities;
        }
    }
}
