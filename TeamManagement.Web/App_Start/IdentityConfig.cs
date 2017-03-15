
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using TeamManagement.Web.Models;

namespace TeamManagement.Web
{
    // This is useful if you do not want to tear down the database each time you run the application.
    // You want to create a new database if the Model changes
    //// public class MyDbInitializer : DropCreateDatabaseIfModelChanges<MyDbContext>
    //public class MyDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    //{
    //    protected override void Seed(ApplicationDbContext context)
    //    {
    //        InitializeIdentityForEF(context);
    //        base.Seed(context);
    //    }

    //    private void InitializeIdentityForEF(ApplicationDbContext context)
    //    {
    //        var UserManager = new UserManager<AppUser>(new UserStore<AppUser>(context));
    //        var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
    //        var myinfo = new MyUserInfo() { FirstName = "Pranav", LastName = "Rastogi" };
    //        string name = "Admin";
    //        string password = "123456";
    //        string test = "test";

    //        //Create Role Test and User Test
    //        RoleManager.Create(new IdentityRole(test));
    //        UserManager.Create(new ApplicationUser() { UserName = test });

    //        //Create Role Admin if it does not exist
    //        if (!RoleManager.RoleExists(name))
    //        {
    //            var roleresult = RoleManager.Create(new IdentityRole(name));
    //        }

    //        //Create User=Admin with password=123456
    //        var user = new ApplicationUser();
    //        user.UserName = name;
    //        user.HomeTown = "Seattle";
    //        user.MyUserInfo = myinfo;
    //        var adminresult = UserManager.Create(user, password);

    //        //Add User Admin to Role Admin
    //        if (adminresult.Succeeded)
    //        {
    //            var result = UserManager.AddToRole(user.Id, name);
    //        }
    //    }
    //}
}