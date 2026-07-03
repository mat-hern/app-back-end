using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Test.DataAdapters;
using Test.Models;

namespace Test.Controllers;

[ApiController]
[Route("[controller]")]
public class DeviceController: ControllerBase
{
    private Adapter<Test.Models.Device> adapter;
    
    public DeviceController(IConfiguration config)
    {
      this.adapter = new DeviceAdpater(config);
    }
    [HttpGet]
    public IActionResult Get()
    {
        var data = adapter.GetDataSet();
            
      return Ok(data);
    }
}

public record Device(string Id, string Name);