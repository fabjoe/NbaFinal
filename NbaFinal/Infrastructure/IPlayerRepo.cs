using NbaFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbaFinal.Infrastructure
{
    public interface IPlayerRepo
    {
        IEnumerable<Player> GetAll();
    }
}
