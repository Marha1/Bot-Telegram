using Microsoft.AspNetCore.Mvc;
using Quartz;
using WebApplication12.Dal.Interfaces;
using WebApplication12.Dal.Repository;
using WebApplication12.Models;

namespace WebApplication12.Jobs
{
    public class Postcard : IJob
    {
        private readonly IBaseRepository<Employee> _employeeRepository;

        public Postcard(IBaseRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var task = _employeeRepository.GetAll();

            if (task != null)
            {
                DateTime d2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 00);

                var employ = from items in task
                             where items.DateOfBirh.Month == d2.Month
                                && items.DateOfBirh.Day == d2.Day
                                && items.DateOfBirh.Hour == d2.Hour
                                && items.DateOfBirh.Minute == d2.Minute
                             select items;

                foreach (var item in employ)
                {
                    item.Age += 1;
                    TelegramBotHelper telegram = new TelegramBotHelper(token: "6698031818:AAG9R2Vb9g-G52p77mgJRMqsL3-P7jFdInA");
                    telegram.GetName(item.Name, item.Age);
                    telegram.GetUpdates();
                    _employeeRepository.Save();  // Используйте _employeeRepository вместо rep
                }
            }
        }
    }
}
