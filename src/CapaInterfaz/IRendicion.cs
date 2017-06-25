﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaNegocio;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace CapaInterfaz
{
    public class IRendicion
    {

        public static void viajes(System.Windows.Forms.DataGridView tablaViajes, DateTime fecha, System.Windows.Forms.DataGridView tablaTurnos, int idChofer)
        {
            int turno = 0;

            foreach (DataGridViewRow row in tablaTurnos.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    turno = System.Convert.ToInt32(row.Cells[1].Value);
                }
            }
            
            tablaViajes.DataSource = CapaNegocio.NRendicion.ObtenerViajes(fecha, turno, idChofer);
        }

        public static int calcularImporte(DataGridView tablaViajes)
        {
            int importeTotal = 0;

            foreach (DataGridViewRow row in tablaViajes.Rows)
            {
                //en la columna de importe por viaje
                importeTotal += System.Convert.ToInt32(row.Cells[3].Value);

            }
            return importeTotal;

        }
    }
}
