﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NAuto
    {


        public static string alta(string marca, string modelo, string patente, int turno, int chofer)
        {
            CapaDatos.DAuto objeto = new CapaDatos.DAuto();
            return objeto.AgregarAuto(marca, modelo, patente, turno, chofer);
        }


        public static object ObtenerTurnos()
        {
            return new CapaDatos.DAuto().ObtenerTurnos();
        }

        public static object ObtenerChoferes()
        {
            return new CapaDatos.DAuto().ObtenerChoferes();
        }
    }
}
