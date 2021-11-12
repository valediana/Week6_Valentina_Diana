using System;
using System.Collections.Generic;

/*Teoria:risposte
 1) a,e,g
 2) b,d
 3)c,b,f  */

namespace Polizia
{
    class Program
    {
        private static DBManager dbAgente = new DBManager();
        static void Main(string[] args)
        {

            Console.WriteLine("Benvenuto in Gestione Agenti di Polizia");
            bool mostra = true;
            while (mostra)
            {
                Console.WriteLine("****------MENU------****");
                Console.WriteLine("Digita 1 per visualizzare tutti gli agenti");
                Console.WriteLine("Digita 2 per visualizzare agenti dell'area geografica scelta");
                Console.WriteLine("Digita 3 per visualizzare agenti con anni di servizio maggiori o uguali a quelli scelti");
                Console.WriteLine("Digita 4 per aggiungere un nuovo agente ");
                Console.WriteLine("Digita 0 per uscire");

                int scelta;
                do
                {
                    Console.WriteLine("Scegli cosa fare:");
                } while (!(int.TryParse(Console.ReadLine(), out scelta) && (scelta >= 0 || scelta <= 4)));

                switch (scelta)
                {
                    case 1:
                        VisualizzaAgenti();
                        break;
                    case 2:
                        VediAgentiPerArea();
                        break;
                    case 3:
                        VediAgentiPerAnniServizio();
                        break;
                    case 4:
                        AggiungiAgente();
                        break;
                    case 0:
                        mostra = false;
                        break;
                }
            }
        }

        private static void AggiungiAgente()
        {
            Console.WriteLine("Inserisci dati agente");
            List<Agente> agentiEsistenti = dbAgente.GetAll();
            Console.WriteLine("Inserisci codice fiscale");
            string codFiscale = Console.ReadLine();
            while (!(dbAgente.GetByCodiceFiscale(codFiscale) == null))
            {
                Console.WriteLine("Formato errato e/o codice isbn già presente. Riprova");
            }
            Console.WriteLine("Inserisci nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci cognome");
            string cognome = Console.ReadLine();
            Console.WriteLine("Inserisci area geografica");
            string areaGeogr = Console.ReadLine();
            Console.WriteLine("Inserisci anno di inizio del servizio");
            int annoInizio;
            do 
            {
                Console.WriteLine("Inserisci valore maggiore di 1930");
            } while (!(int.TryParse(Console.ReadLine(), out annoInizio) && annoInizio>1930));

            Agente nuovoAgente = new Agente(nome, cognome, codFiscale, areaGeogr, annoInizio);

            bool esito = dbAgente.Add(nuovoAgente);
            if (esito)
            {
                Console.WriteLine("Agente aggiunto correttamente");
            }
            else
            {
                Console.WriteLine("Errore. Non è stato possibile aggiungere l'agente!");
            }
        }

        private static void VediAgentiPerAnniServizio()
        {
            Console.WriteLine("Inserisci anni di servizio minimi");
            int anniServizio;
            do
            {
                Console.WriteLine("Inserisci intero maggiore di zero");
            } while (!((int.TryParse(Console.ReadLine(), out anniServizio))&& anniServizio>0));

            List<Agente> agentiPerAnno = dbAgente.GetByAnniServizio(anniServizio);

            if (agentiPerAnno.Count == 0)
            {
                Console.WriteLine("Nessun agente trovato con queste caratteristiche");
            }
            else
            {
                foreach (var item in agentiPerAnno)
                {

                    Console.WriteLine($"{item.ToString()}");
                }
            }
        }

        private static void VediAgentiPerArea()
        {
            List<Agente> agenti = dbAgente.GetAll();
            List<string> areePresenti = new List<string>();
            foreach(var item in agenti)
            {
                if (!areePresenti.Contains(item.AreaGeografica))
                {
                    areePresenti.Add(item.AreaGeografica);
                }
            }

            Console.WriteLine("Le aree presenti sono:");
            foreach (var item in areePresenti)
            {
                Console.WriteLine($"* {item}");
            }

            Console.WriteLine("Inserisci area da cercare:");
            string areaGeografica = Console.ReadLine();
            List<Agente> agentiTrovati = dbAgente.GetByAreaGeografica(areaGeografica);
            if (agentiTrovati.Count == 0)
            {
                Console.WriteLine("Nessun agente trovato con queste caratteristiche");
            }
            else
            {
                foreach (var item in agentiTrovati)
                {

                    Console.WriteLine($"{item.ToString()}");
                }
            }
            
        }

        private static void VisualizzaAgenti()
        {
            List<Agente> agentiTotali = dbAgente.GetAll();
            foreach (var item in agentiTotali)
            {
                Console.WriteLine($"{ item.ToString()}");
            }

        }
    }
}
