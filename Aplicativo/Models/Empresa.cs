using System;
using System.Collections.Generic;

namespace Aplicativo.Models;

public partial class Empresa
{
    public string Nit { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string RepresentanteLegal { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
