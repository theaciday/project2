using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project2.Services
{
    public interface IUserService
    {
        string RollingUser7();
        TimeSpan[] GetLiveSpan();
    }
}
