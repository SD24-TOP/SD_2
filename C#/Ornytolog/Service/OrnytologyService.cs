using Ornytolog.Model;
using Ornytolog.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ornytolog.Service
{
    public class OrnytologyService(IOrnytologyRepository repository) : IOrnytologyService
    {
        private IOrnytologyRepository OrnytologyRepository = repository;
        
        public void AddBird(Bird bird)=> OrnytologyRepository.AddBird(bird);

        public bool Delete(Guid id) => OrnytologyRepository.Delete(id);

        public List<Bird> GetAll() => OrnytologyRepository.GetAll();

        public Bird? GetById(Guid id) => OrnytologyRepository.GetById(id);

        public bool Update(Bird bird) => OrnytologyRepository.Update(bird);
    }
}
