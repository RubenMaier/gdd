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
    public class IAuto
    {
        public static string alta(int marca, int modelo, string patente, DataGridView tablaTurno, int chofer)
        {
            int turno = 0;
            //int chofer = 0;

            foreach (DataGridViewRow row in tablaTurno.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value)) 
                {
                    turno = System.Convert.ToInt32(row.Cells[1].Value);
                }
            }

            string respuesta = CapaNegocio.NAuto.alta(marca, modelo, patente, turno, chofer);
            //Hardcodeo
            //string respuesta = CapaNegocio.NAuto.alta(marca, modelo, patente, turno, 10);
            return respuesta;
        }

        public static bool ChequearItemSeleccionado(DataGridView tabla)
        {
            bool resultado;
            resultado = false;
            foreach (DataGridViewRow row in tabla.Rows)
            {
                DataGridViewCheckBoxCell cellSelecion = row.Cells["Elegir"] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(cellSelecion.Value))
                    resultado = true;
            }
            return resultado;
        }

        public static void CargarTurnos(System.Windows.Forms.DataGridView tablaTurno)
        {
            tablaTurno.DataSource = CapaNegocio.NAuto.ObtenerTurnos();
        }

        public static void CargarChoferes(System.Windows.Forms.DataGridView tablaChofer)
        {
            tablaChofer.DataSource = CapaNegocio.NAuto.ObtenerChoferes();
        }

        public static void OcultarColumnas(DataGridView dataGridView, int nroColumn)
        {
            dataGridView.Columns[nroColumn].Visible = false; // oculto la columna del id
        }


    }
}