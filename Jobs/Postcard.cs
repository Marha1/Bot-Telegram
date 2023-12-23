using Microsoft.AspNetCore.Mvc;
using Quartz;
using WebApplication12.Models;

namespace WebApplication12.Jobs
{
    public class Postcard : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
           
                using (AplicationContext db = new AplicationContext())
                {


                        var task = db.Employees.ToList(); 
                    if (task != null)
                    {
                        DateTime d2 = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,DateTime.Now.Hour, DateTime.Now.Minute,00);
                        foreach (var item in task)
                        {
                           
                            if (item.DateOfBirh.Month == d2.Month&&item.DateOfBirh.Day==d2.Day&&item.DateOfBirh.Hour==d2.Hour&& item.DateOfBirh.Minute == d2.Minute)
                            {
                        
                                    item.Age += 1;
                                    TelegramBotHelper telegram = new TelegramBotHelper(token: "6698031818:AAG9R2Vb9g-G52p77mgJRMqsL3-P7jFdInA");
                                    telegram.GetName(item.Name, item.Age);
                                    telegram.GetUpdates();
                                db.SaveChanges();
                            }
                        }
                    }
                }
            
        }
    }
}

