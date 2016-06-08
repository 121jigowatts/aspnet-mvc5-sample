using aspnet_mvc5_sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnet_mvc5_sample.Services.Abstractions
{
    public interface IHomeService
    {
        IEnumerable<Person> GetPeopleByName(String name);
    }
}
