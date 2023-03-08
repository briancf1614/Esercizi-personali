using System;
using System.Collections.Generic;

namespace TestDatabaseFirst.Models;

public partial class Pianeti
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Descrizione { get; set; } = null!;

    public virtual ICollection<Persone> Persones { get; } = new List<Persone>();
}
