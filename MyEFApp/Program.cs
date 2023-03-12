using Microsoft.EntityFrameworkCore;
using MyEFApp.Exercises.Model;
using System.Diagnostics;

using (var ctx = new EftestDbContext())
{
    var activeUsers = ctx.Users.Where(u => u.IsActive);

	//var firstUser = activeUsers.FirstOrDefault();
	//if(firstUser != null)
	//{
	//	ctx.Users.Remove(firstUser); 

	//	ctx.SaveChanges();
	//}

	foreach (var user in activeUsers)
	{
		Console.WriteLine($"{user.Id} {user.Name}");
	}

	//Add new Group
	if (!ctx.Groups.Any(gr => gr.Name == "tutajnazwagrupy"))
	{
		var newGroup = new Group { Name = "tutajnazwagrupy" };
		ctx.Groups.Add(newGroup);
	}

    Console.WriteLine();
    //Remove inactive users
    var inactiveUsers = ctx.Users.Where(u => !u.IsActive).Include(u => u.UserGroups).ToArray();
	foreach (var user in inactiveUsers)
	{
		var userGroups = ctx.UserGroups.Where(gr => gr.UserId == user.Id);
		ctx.UserGroups.RemoveRange(userGroups);

		ctx.Users.RemoveRange(user);
	}


	Console.WriteLine();
	//Print users with groups
	var usersWithGroups = ctx.Users
		.Select(u => new { UserName = u.Name, UserGroupNames = u.UserGroups.Select(ug => ug.Group.Name).ToArray() })
		.ToArray();
	foreach (var user in usersWithGroups)
	{
		foreach (var groupName in user.UserGroupNames)
		{
			Console.WriteLine($"{user.UserName} {groupName}");
		}
	}

    Console.WriteLine();
    var usersWithGroupsArray = ctx.Users
       .SelectMany(u => u.UserGroups.Select(ug => new { UserName = u.Name, GroupName = ug.Group.Name }))
	   .ToArray();
    foreach (var userwithGroup in usersWithGroupsArray)
    {
        Console.WriteLine($"{userwithGroup.UserName} {userwithGroup.GroupName}");
    }

    ctx.SaveChanges();
}


