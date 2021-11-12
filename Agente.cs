using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polizia
{
    public class Agente: Persona
    {
        public string AreaGeografica { get; set; }
        public int AnnoInizio { get; set; }
        
        public Agente(string nome,string cognome,string codiceFiscale,string areaGeografica,int annoInizio) : base(nome,cognome,codiceFiscale)
        {
            AreaGeografica = areaGeografica;
            AnnoInizio = annoInizio;
        }
        public Agente()
        {

        }

        public int CalcolaAnniServizio()
        {
            return (DateTime.Now.Year - AnnoInizio);
        }
        public override bool Equals(object obj) //come stabilisco se due agenti sono uguali
        {
            
            Agente a = (Agente)obj;
            if (a == null)
            {
                return false;
            }
            return CodiceFiscale==a.CodiceFiscale;
        }
        public override string ToString()
        {
            return $"CF: {CodiceFiscale} -Nome: {Nome} -Cognome: {Cognome} -Anni di servizio:{CalcolaAnniServizio()}";
        }
    }
}
