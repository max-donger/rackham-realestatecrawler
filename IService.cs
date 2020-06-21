using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronCgi.DotNet;

namespace Rackham
{
    public interface IService
    {
        Task<bool> GetConnectionStatus(Connection connection);
    }
}