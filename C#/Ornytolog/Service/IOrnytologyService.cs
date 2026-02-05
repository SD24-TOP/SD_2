using Ornytolog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ornytolog.Service
{
    public interface IOrnytologyService
    {
        void AddBird(Bird bird);
        List<Bird> GetAll();
        Bird? GetById(Guid id);
        bool Update(Bird bird);
        bool Delete(Guid id);
    }
}
