using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Test.Models;

namespace Test.DataAdapters;

public abstract class Adapter<T> where T : class
{
    protected IConfiguration _configuration;

    public Adapter(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public abstract List<T> GetDataSet();
    public abstract User AddData(T data);
    public abstract DbSet<T> UpdateData(T data);
    public abstract DbSet<T> DeleteData(T data);
}