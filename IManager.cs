using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polizia
{
    public interface IManager
    {
        public List<Agente> GetAll();

        public List<Agente> GetByAreaGeografica(string areaGeografica);

        public bool Add(Agente item);

        public List<Agente> GetByAnniServizio(int anniServizio);

        public Agente GetByCodiceFiscale(string codiceFiscale);
        
    }
}
