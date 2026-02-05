using Ornytolog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ornytolog.Repository
{
    public interface IOrnytologyRepository
    {
        void AddBird(Bird bird);
        List<Bird> GetAll();
        Bird? GetById(Guid id);
        bool Update(Bird bird);
        bool Delete(Guid id);
    }
}
