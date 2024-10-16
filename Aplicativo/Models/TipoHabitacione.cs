﻿using System;
using System.Collections.Generic;

namespace Aplicativo.Models;

public partial class TipoHabitacione
{
    public int IdTipoHabitacion { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int CapacidadMaxima { get; set; }

    public virtual ICollection<Habitacione> Habitaciones { get; set; } = new List<Habitacione>();
}
