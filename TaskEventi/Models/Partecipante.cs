using System;
using System.Collections.Generic;

namespace TaskEventi.Models;

public partial class Partecipante
{
    public int PartecipanteId { get; set; }

    public string Nominativo { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string? Email { get; set; }

    public DateTime? Deleted { get; set; }

    public virtual ICollection<Evento> EventoRifs { get; set; } = new List<Evento>();
}
