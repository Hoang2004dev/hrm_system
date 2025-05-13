using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.Interfaces.Services
{
    public interface IPasswordHasher
    {
        string Hash(string password);

        bool Verify(string hash, string password);
    }
}
