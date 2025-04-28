using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Models;

namespace ToDoApi.Interfaces
{
    public interface IJWTServices
    {
        string CreateToken(AppUser user);
    }
}