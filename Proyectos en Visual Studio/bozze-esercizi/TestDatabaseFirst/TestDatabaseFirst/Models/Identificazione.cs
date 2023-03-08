using System;
using System.Collections.Generic;

namespace TestDatabaseFirst.Models;

public partial class Identificazione
{
    public int Id { get; set; }

    public string Città { get; set; } = null!;

    public DateTime DataNascita { get; set; }

    public int PersonaId { get; set; }

    public virtual Persone Persona { get; set; } = null!;
}
