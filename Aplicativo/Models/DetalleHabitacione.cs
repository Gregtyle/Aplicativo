﻿using System;
using System.Collections.Generic;

namespace Aplicativo.Models;

public partial class DetalleHabitacione
{
    public int IdDetalleHabitacion { get; set; }

    public int IdReserva { get; set; }

    public int IdHabitacion { get; set; }

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    public bool Estado { get; set; }

    public virtual Habitacione IdHabitacionNavigation { get; set; } = null!;

    public virtual Reserva IdReservaNavigation { get; set; } = null!;
}
