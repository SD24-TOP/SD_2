using Ornytolog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ornytolog.Repository
{
    public class LocalOrnytologyRepository : IOrnytologyRepository
    {
        List<Bird> birds = [];

        public void AddBird(Bird bird)
        {
            Guid id = Guid.NewGuid();
            bird.Id = id;
            birds.Add(bird);
        }

        public bool Delete(Guid id)
        {
            Bird? bird = birds.FirstOrDefault(x => x.Id == id);
            if (bird == null) return false;
            birds.Remove(bird);
            return true;

        }

        public List<Bird> GetAll() => birds;

        public Bird? GetById(Guid id) => birds.FirstOrDefault(x => x.Id == id);

        public bool Update(Bird bird)
        {
            int first = birds.IndexOf(bird);
            if (first == -1) return false;
            birds[first] = bird;
            return true;
        }
    }
}
