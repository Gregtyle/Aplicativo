﻿using System;
using System.Collections.Generic;

namespace Aplicativo.Models;

public partial class Habitacione
{
    public int IdHabitacion { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdTipoHabitacion { get; set; }

    public int Capacidad { get; set; }

    public bool Estado { get; set; }

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int IdInmueble { get; set; }

    public virtual ICollection<DetalleHabitacione> DetalleHabitaciones { get; set; } = new List<DetalleHabitacione>();

    public virtual ICollection<HabitacionesInmueble> HabitacionesInmuebles { get; set; } = new List<HabitacionesInmueble>();

    public virtual Inmueble IdInmuebleNavigation { get; set; } = null!;

    public virtual TipoHabitacione IdTipoHabitacionNavigation { get; set; } = null!;

    public virtual ICollection<PaquetesHabitacione> PaquetesHabitaciones { get; set; } = new List<PaquetesHabitacione>();
}
