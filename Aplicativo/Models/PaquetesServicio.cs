using System;
using System.Collections.Generic;

namespace Aplicativo.Models;

public partial class PaquetesServicio
{
    public int IdPaqueteServicio { get; set; }

    public int? IdPaquete { get; set; }

    public int? IdServicio { get; set; }

    public virtual PaquetesHospedaje? IdPaqueteNavigation { get; set; }

    public virtual Servicio? IdServicioNavigation { get; set; }
}
