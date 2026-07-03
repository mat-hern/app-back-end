using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Crypto;
using Test.Helpers;
using Test.Models;

namespace Test.DataAdapters;

public class UserAdapter: Adapter<User>
{
    public UserAdapter(IConfiguration configuration) : base(configuration)
    {
    }

    public override List<User> GetDataSet()
    {
        throw new System.NotImplementedException();
    }

    public override User AddData(User data)
    {
        using var context = new ApplicationContext(this._configuration);
        string hashedPassword = PasswordHasher.HashPassword(data.Password);
        User newUser = new User
        {
            Username = data.Username,
            Password = hashedPassword,
        };
        context.Users.Add(newUser);
        context.SaveChanges();
        return newUser;
    }

    public User GetUser(string email)
    {
        using var context = new ApplicationContext(this._configuration);
        User u = context.Users.FirstOrDefault(u => u.Username == email);
        return u;
    }
    public override DbSet<User> UpdateData(User data)
    {
        throw new System.NotImplementedException();
    }

    public override DbSet<User> DeleteData(User data)
    {
        throw new System.NotImplementedException();
    }
}