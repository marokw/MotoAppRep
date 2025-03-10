﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MotoApp;
using MotoApp.Components.CsvReader;
using MotoApp.Data;
using MotoApp.Data.Entities;
using MotoApp.Data.Repositories;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Employee>, ListRepository<Employee>>();
//servivces.AddSingleton<IRepository<Employee>, SqlRepository<Employee>>();
services.AddSingleton<IRepository<Car>, ListRepository<Car>>();

services.AddSingleton<ICsvReader, CsvReader>();

services.AddDbContext<MotoAppDbContext>(options => options.UseSqlServer("Data Source=DESKTOP-DPHMGLJ\\SQLEXPRESS;Initial Catalog=MotoAppStorage;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>()!;
app.Run();





/*
using MotoApp.Repositories;
using MotoApp.Repositories.Extensions;
using MotoApp.Entities;
using MotoApp.Data;
using Microsoft.EntityFrameworkCore;

var sqlRepository = new SqlRepository<Employee>(new MotoAppDbContext());
sqlRepository.ItemAdded += EmployeeAdded;

AddEmployees(sqlRepository);
WriteAllToConsole(sqlRepository);

static void EmployeeAdded(object? sender, Employee e)
{
    Console.WriteLine($"{e.FirstName} added");
}

static void AddEmployees(IRepository<Employee> employeeRepository)
{
    var employees = new[]    
    {
        new Employee { FirstName = "Adam" },
        new Employee { FirstName = "Piotr" },
        new Employee { FirstName = "Zuzia"}
    };

    employeeRepository.AddBatch(employees);
}


static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

static void AddManagers(IWriteRepository<Manager> managerRepository)
{
    managerRepository.Add(new Manager { FirstName = "Przemek" });
    managerRepository.Add(new Manager { FirstName = "Tomek" });
    managerRepository.Save();
}
*/