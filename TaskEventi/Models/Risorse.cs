using System;
using System.Collections.Generic;

namespace TaskEventi.Models;

public partial class Risorse
{
    public int RisorseId { get; set; }

    public int Quantita { get; set; }

    public decimal Costo { get; set; }

    public string Fornitore { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public DateTime? Deleted { get; set; }

    public int EventoRif { get; set; }

    public virtual Evento EventoRifNavigation { get; set; } = null!;
}
