using MotoApp.Repositories;
using MotoApp.Entities;
using MotoApp.Data;
using Microsoft.EntityFrameworkCore;


var sqlRepository = new SqlRepository<Employee>(new MotoAppDbContext());
AddEmployees(sqlRepository);
AddManagers(sqlRepository);
WriteAllToConsole(sqlRepository);

static void AddEmployees(IRepository<Employee> employeeRepository)
{
    employeeRepository.Add(new Employee { FirstName = "Adam" });
    employeeRepository.Add(new Employee { FirstName = "Piotr" });
    employeeRepository.Add(new Employee { FirstName = "Zuzia" });
    employeeRepository.Save();

}

static void WriteAllToConsole(IReadRepository<IEntity> repository) 
{
    var items = repository.GetAll();
    foreach( var item in items)
    {
        Console.WriteLine(  item);
    }
}

static void AddManagers(IWriteRepository<Manager> managerRepository)
{
    managerRepository.Add(new Manager { FirstName = "Przemek" });
    managerRepository.Add(new Manager { FirstName = "Tomek" });
    managerRepository.Save();
}
