using System;
using System.Collections.Generic;

namespace Aplicativo.Models;

public partial class DetallePaquete
{
    public int IdDetallePaquete { get; set; }

    public int IdReserva { get; set; }

    public int IdPaquete { get; set; }

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    public bool Estado { get; set; }

    public virtual PaquetesHospedaje IdPaqueteNavigation { get; set; } = null!;

    public virtual Reserva IdReservaNavigation { get; set; } = null!;
}
