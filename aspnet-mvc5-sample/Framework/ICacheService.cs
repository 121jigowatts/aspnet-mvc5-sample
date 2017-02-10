using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnet_mvc5_sample.Framework
{
    public interface ICacheService
    {
        Object Get(String key);
        void Set(String key, Object data);
        Object this[String key] { get; set; }
    }
}
