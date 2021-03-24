using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Repository
{
    public interface IDataAcessRepository
    {
        List<Person> ReadInfo();
    }
}
