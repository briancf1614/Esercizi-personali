using System;
using System.Collections.Generic;

namespace TestDatabaseFirst.Models;

public partial class Persone
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Anni { get; set; }

    public int PianetaId { get; set; }

    public virtual Identificazione? Identificazione { get; set; }

    public virtual Pianeti Pianeta { get; set; } = null!;
}
