using Core.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Core.Models
{
    public class DataGenerator
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            TaskDataInitializer(serviceProvider);
        }

        private static void TaskDataInitializer(IServiceProvider serviceProvider)
        {
            using (var context = new TaskDBContext(
                            serviceProvider.GetRequiredService<DbContextOptions<TaskDBContext>>()))
            {
                if (context.TaskList.Any())
                {
                    return;
                }

                context.TaskList.AddRange(
                    new TaskListModel
                    {
                        ID = 101,
                        TaskDescription = "Created - Task Cloud Migration",
                        TaskHead = "Cloud Migration",
                        TaskUserId = 101,
                        UpdatedDate = DateTime.Now,
                        TaskChecked = false


                    }, new TaskListModel
                    {
                        ID = 102,
                        TaskDescription = "Created - Task SAAS Migration",
                        TaskHead = "SAAS Migration",
                        TaskUserId = 102,
                        UpdatedDate = DateTime.Now,
                        TaskChecked = false
                    }
                    );

                if (context.LogModel.Any())
                {
                    return;
                }

                context.LogModel.AddRange(
                    new LogModel
                    {
                        ID = 101,
                        UserName = "firstuser",
                        Password = "password1"

                    }, new LogModel
                    {
                        ID = 102,
                        UserName = "seconduser",
                        Password = "password2"
                    }
                    );


                context.SaveChanges();
            }
        }

    }
}
