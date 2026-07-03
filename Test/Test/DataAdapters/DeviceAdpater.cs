using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Test.Models;

namespace Test.DataAdapters;

public class DeviceAdpater : Adapter<Device>
{
    public DeviceAdpater(IConfiguration configuration): base(configuration){}

    public override List<Device> GetDataSet()
    {
        using var context = new ApplicationContext(this._configuration);
        context.Database.EnsureCreated();
        
        return  context.Devices.ToList();
    }

    public override User AddData(Device data)
    {
        using var context = new ApplicationContext(this._configuration);
        context.Database.EnsureCreated();
        DbSet<Device> dataSet = context.Devices;
        dataSet.Add(data);
        context.SaveChanges();
        throw new System.NotImplementedException();

    }

    public override DbSet<Device> DeleteData(Device data)
    {
        throw new System.NotImplementedException();
    }
    
    public override DbSet<Device> UpdateData(Device data)
    {
        throw new System.NotImplementedException();
    }
}