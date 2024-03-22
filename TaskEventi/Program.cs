using Microsoft.EntityFrameworkCore;
using System;
using TaskEventi.Models;

namespace TaskEventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new TaskGestioneEventiContext())
            {
                #region Insert
                //Evento evUno = new Evento()
                //{
                //    NomeEvento = "Concerto yeee",
                //    DescrizioneEvento = "Bello",
                //    DataEvento = new DateTime(2024, 04, 29),
                //    LuogoEvento = "Roma",
                //    CapacitaMassima = 1000,
                //    PartecipanteRifs = ctx.Partecipantes.Where(s => s.PartecipanteId > 4).ToList()

                //};

                //ctx.Eventos.Add(evUno);
                //ICollection<Evento> eventi = ctx.Eventos.Where(s=>s.NomeEvento == evUno.NomeEvento).ToList();
                //Risorse risorUno = new Risorse()
                //{
                //    Tipo="Cibo",
                //    Quantita=1,
                //    Costo=2.5m,
                //    Fornitore="Pippo.spa"
                //};

                //ctx.Risorses.Add(risorUno);

                //Partecipante partUno = new Partecipante()
                //{
                //   Nominativo="Pippi",
                //   Telefono= "3472288839",
                //   Email="pipp@email.com",
                //   EventoRifs=eventi
                //};

                //ctx.Partecipantes.Add(partUno);
                #endregion
                #region Read
                //Metodo per controllare quali partecipanti partecipano all evento con id 1
                //Evento? eve = ctx.Eventos.Include(eventi => eventi.PartecipanteRifs).FirstOrDefault(eventi => eventi.EventoId == 1);

                //foreach(var partecipanti in eve.PartecipanteRifs)
                //{
                //    Console.WriteLine($"{partecipanti.Nominativo}");
                //}
                #endregion

                #region Update
                //var evento = ctx.Eventos.FirstOrDefault(e => e.EventoId == 3);

                //    if (evento != null)
                //    {
                //        evento.NomeEvento = "Pool party Titone";
                //        evento.DescrizioneEvento = "Festa Esclusiva";
                //        evento.DataEvento = DateTime.Now;
                //        evento.LuogoEvento = "Castelverde";
                //        evento.CapacitaMassima = 100;

                //        ctx.SaveChanges();

                //        Console.WriteLine("Evento aggiornato con successo.");
                //    }
                //    else
                //    {
                //        Console.WriteLine("Evento non trovato.");
                //    }

                #endregion

                #region Export
                
                    //var eventi = ctx.Eventos.ToList();


                    //string csvFilePath = "eventi.csv";


                    //using (var writer = new StreamWriter(csvFilePath))
                    //{
                    //    writer.WriteLine("EventoId,NomeEvento,DescrizioneEvento,DataEvento,LuogoEvento,CapacitaMassima");


                    //    foreach (var evento in eventi)
                    //    {
                    //        writer.WriteLine($"{evento.EventoId},{evento.NomeEvento},{evento.DescrizioneEvento},{evento.DataEvento},{evento.LuogoEvento},{evento.CapacitaMassima}");
                    //    }
                    //}

                    //Console.WriteLine($"Esportazione completata. Dati degli eventi sono stati scritti nel file '{csvFilePath}'.");
                

                #endregion
                ctx.SaveChanges();



              
                
               




            }
        }
    }
}
