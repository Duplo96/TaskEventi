using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskEventi.Models
{
    internal class Gestore
    {
        private static Gestore? istanza;
            public static Gestore getIstanza()
        {
            if (istanza == null)
                istanza = new Gestore();
            return istanza;
        }
        private Gestore() { }



        public void Menu()
        {
            bool active = true;
            while (active)
            {

                Console.WriteLine("1 Gestione eventi");
                Console.WriteLine("2 Gestione partecipanti");
                Console.WriteLine("3 Gestione risorse");
                Console.WriteLine("4 Esporta CSV");
                Console.WriteLine("Premi Q per uscire");

                string? scelta = Console.ReadLine();
                switch (scelta)
                {

                    case "1":
                        {
                            Console.WriteLine("1 Aggiungi evento");
                            Console.WriteLine("2 Modifica evento");
                            Console.WriteLine("3 Elimina evento");
                            

                            string? sceltaEvento = Console.ReadLine();
                            switch (sceltaEvento) {
                                case "1":
                            {
                                Console.WriteLine("aggiungi evento");
                                this.AggiungiEvento(scelta= "1");
                                        break;
                            }
                                case "2": 
                                    
                                {
                                        Console.WriteLine("Modifica Evento");
                                        this.ModificaEvento(scelta = "2");

                                        break;
                                    
                                }
                                case "3":
                                    {
                                        this.EliminaEvento(scelta = "3");
                                        break;

                                    }

                        }
                            break;

                        }
                    case "2": { break; }
                    case "3": { break; }
                    case "4": 
                        {

                            this.EsportaCSV(scelta ="4");
                            break;
                        }
                    case "Q":
                        {
                            
                            active = false;
                            break;
                        }

                }

            }


        }

        #region Eventi
        private List<Evento> GetListaEventi()
        {
            List<Evento> listaEventi = new List<Evento>();
            using (var ctx = new TaskGestioneEventiContext())
            {

                try
                {
                    listaEventi = ctx.Eventos.ToList();
                    return listaEventi;
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return listaEventi;

        }

        private void AggiungiEvento(string modalita)
        {
            
            string toAdd = "";

            if(modalita == "1")
            {

                using(var ctx=new  TaskGestioneEventiContext())
                {
                    try
                    {

                        Console.WriteLine($"{toAdd}Nome evento:");
                        string? nomeEvento = Console.ReadLine();
                        Console.WriteLine($"{toAdd}Descrizione evento:");
                        string? descrEvento = Console.ReadLine();
                        Console.WriteLine($"{toAdd}Data evento:");
                        string? dataEvento = Console.ReadLine();
                        DateTime convertedDate = Convert.ToDateTime(dataEvento);
                        Console.WriteLine($"{toAdd}Luogo evento:");
                        string? luogoEvento = Console.ReadLine();
                        Console.WriteLine($"{toAdd}capacità max evento:");
                        string? capEvento = Console.ReadLine();
                        int convertedCapEvento = Convert.ToInt32(capEvento);

                        Evento eventoDaAggiungere = new Evento()
                        {
                            NomeEvento = nomeEvento,
                            DescrizioneEvento = descrEvento,
                            DataEvento = convertedDate,
                            LuogoEvento = luogoEvento,
                            CapacitaMassima = convertedCapEvento
                        };
                        ctx.Eventos.Add(eventoDaAggiungere);
                        ctx.SaveChanges();
                        Console.WriteLine("Evento Inserito");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    


                }

            }

        }
        private void ModificaEvento(string modalita)
        {
            Evento eventoScelto = new Evento();
            int idEvento = 0;
            string toAdd = "";

            if (modalita == "2")
            {
                toAdd = "Modifica ";
                foreach (Evento evento in GetListaEventi())
                {
                    Console.WriteLine($"ID: {evento.EventoId}, NOME: {evento.NomeEvento}, LUOGO: {evento.LuogoEvento}, DATA: {evento.DataEvento}");
                }
                Console.WriteLine("Inserisci l'ID dell'evento da modificare");

            }
            using(var ctx = new TaskGestioneEventiContext())
            {
                string? idToFind = Console.ReadLine();
                idEvento = Convert.ToInt32(idToFind);
                eventoScelto = ctx.Eventos.Single(ev => ev.EventoId == idEvento);
                Console.WriteLine($"{toAdd}Nome evento:");
                string? nomeEvento = Console.ReadLine();
                Console.WriteLine($"{toAdd}Descrizione evento:");
                string? descrEvento = Console.ReadLine();
                Console.WriteLine($"{toAdd}Data evento:");
                string? dataEvento = Console.ReadLine();
                DateTime convertedDate = Convert.ToDateTime(dataEvento);
                Console.WriteLine($"{toAdd}Luogo evento:");
                string? luogoEvento = Console.ReadLine();
                Console.WriteLine($"{toAdd}capacità max evento:");
                string? capEvento = Console.ReadLine();
                int convertedCapEvento = Convert.ToInt32(capEvento);

                eventoScelto.NomeEvento = nomeEvento;
                eventoScelto.DescrizioneEvento = descrEvento;
                eventoScelto.DataEvento = convertedDate;
                eventoScelto.LuogoEvento = luogoEvento;
                eventoScelto.CapacitaMassima = convertedCapEvento;
                ctx.Entry(eventoScelto).State = EntityState.Modified;
                ctx.SaveChanges();
                Console.WriteLine("Evento Aggiornato");

            }

        }
        private void EliminaEvento(string modalita)
        {
            Console.WriteLine("Scegli l'evento da eliminare");
            if (GetListaEventi().Count > 0)
            {
                foreach (Evento evento in GetListaEventi())
                {
                    Console.WriteLine($"ID: {evento.EventoId}, NOME: {evento.NomeEvento}, LUOGO: {evento.LuogoEvento}, DATA: {evento.DataEvento}");
                }
                Console.WriteLine("Scegli l'ID");

                string? toDelete = Console.ReadLine();
                int idEvento = Convert.ToInt32(toDelete);
                using (var ctx = new TaskGestioneEventiContext())
                {
                    try
                    {
                        Evento evento = ctx.Eventos.Single(evento => evento.EventoId == idEvento);
                        ctx.Eventos.Remove(evento);
                        ctx.SaveChanges();
                        Console.WriteLine("Evento Rimosso");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

            }else
            {
                Console.WriteLine("Nessun evento trovato");
            }

        }

        #endregion
        #region Export CSV
        private void EsportaCSV(string modalita)
        {


            using (var ctx = new TaskGestioneEventiContext()) {

                var eventi = ctx.Eventos.ToList();
                var partecipanti = ctx.Partecipantes.ToList();
                var risorse = ctx.Risorses.ToList();


                string csvFilePath = "eventi.csv";


                using (var writer = new StreamWriter(csvFilePath))
                {
                    writer.WriteLine("EventoId,NomeEvento,DescrizioneEvento,DataEvento,LuogoEvento,CapacitaMassima");
                    foreach (var evento in eventi)
                    {
                        writer.WriteLine($"{evento.EventoId},{evento.NomeEvento},{evento.DescrizioneEvento},{evento.DataEvento},{evento.LuogoEvento},{evento.CapacitaMassima}");
                    }
                    writer.WriteLine("PartecipanteId,Nominativo,Telefono,Email,Deleted,EventoRifs");
                    foreach (var partecipante in partecipanti)
                    {
                        writer.WriteLine($"{partecipante.PartecipanteId},{partecipante.Nominativo},{partecipante.Telefono},{partecipante.Email},{partecipante.Deleted},{partecipante.EventoRifs}");
                    }
                    writer.WriteLine("RisorseId,Quantita,Costo,Fornitore,Tipo,Deleted,EventoRif");
                    foreach (var risorsa in risorse)
                    {
                        writer.WriteLine($"{risorsa.RisorseId},{risorsa.Quantita},{risorsa.Costo},{risorsa.Fornitore},{risorsa.Tipo},{risorsa.Deleted},{risorsa.EventoRif}");
                    }

                }

                Console.WriteLine($"Esportazione completata. Dati degli eventi sono stati scritti nel file '{csvFilePath}'.");

            }
        }
        #endregion
    }
}
