using CSharpConsole.Samples.Class;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsole.Exercises.Solutions
{
    internal class LinqEx
    {
        private bool ValidateIfActive(Exercises.User u)
        {
            return u.IsActive;
        }

        private bool ValidateIfIsActive(Exercises.User u) => u.IsActive;

        public void Sample()
        {
            var users = CreateCollection.GetUsers().ToArray();

            Func<Exercises.User, bool> whereDel = ValidateIfActive;

            var aun = users
                .Where(ValidateIfActive)
                //.Where(u => 
                //{ 
                //    return u.IsActive; 
                //})
                .Select(u => u.Name).ToArray();


            var myList = new List<Car>();

            myList.Add(new Car(3));
           // myList.Add("Pawel");

            var activeUserNames = new List<string>();
            foreach (var user in users)
            {
                if(user.IsActive) 
                {
                    activeUserNames.Add(user.Name);
                }
            }

        } 

        public void ExerciseTest()
        { 
            var users = CreateCollection.GetUsers()
                .Where(user => user is not null).ToArray();


            var hasAnyElement = users.Any();

            var hasAnyActiveUser = users.Any(user => user.IsActive);

            var countNonNullElements = users.Count(user => user is not null);

            var usersWithM = users.Where(user => user.Name.StartsWith("M"));

            var sortedUsers = users.OrderBy(user => user.Name).Take(5);

            var second5users = users.Skip(5).Take(5);

            var distinNames = users.Select(user => user.Name).Distinct(); // Equals() => ?? "Mark".Equals("Mark")
                                                                          //distinNames = users.Distinct().Select(user => user.Name);   // (new User{ Name = "Mark"}).Equals(new User{Name ="Mark"}))

            var duplicatedNames = users.GroupBy(user => user.Name)
                .Where(gr => gr.Count() > 1)
                .Select(gr => gr.Key);

            var superUsers = users.OfType<SuperUser>();

            var activeSuperUsers = users.OfType<SuperUser>().Where(su => 
            {
                Console.WriteLine(su.Name);
                return su.IsAdmin; 
            });
            
            var admin = users.OfType<SuperUser>().FirstOrDefault(su => su.IsAdmin);

            var usersWithCount = users.GroupBy(user => user.Name)
                .ToDictionary(gr => gr.Key, gr => gr.Count());
            var johnsCount = usersWithCount["John"];


            var usersByName = users.GroupBy(user => user.Name)
                .ToDictionary(gr => gr.Key, gr => gr.ToArray());

            johnsCount = usersByName["John"].Count();

            var activeJohns = usersByName["John"].Where(u => u.IsActive);


            var userIdAndNamesWithClass = users.Select(u => new UserDetails { Id = u.Id, Name = u.Name }).ToArray();
            var userIdAndNames = users.Select(u => new { Id = u.Id, Name = u.Name }).ToArray();
        }

        class UserDetails
        {
            public string Name { get; set; }
            public int Id { get; set; }   
        }
    }
}
