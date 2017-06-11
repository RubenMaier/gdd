﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.AbmAuto
{
    public partial class Alta : Form
    {
        #region Atributos

        public int idChofer;

        #endregion

        public Alta()
        {
            InitializeComponent();
            CapaInterfaz.Decoracion.Reorganizar(this);
        }

        #region Acciones/Eventos

            private void BtnAlta_Click(object sender, EventArgs e)
            {
                int marca = Decimal.ToInt32(numMarca.Value);
                int modelo = Decimal.ToInt32(numModelo.Value);
                if ( CapaInterfaz.IAuto.ChequearItemSeleccionado(this.tablaTurno))
                {
                    string respuesta = CapaInterfaz.IAuto.alta(marca, modelo, TxtPatente.Text, this.tablaTurno, idChofer);
                    CapaInterfaz.Decoracion.mostrarInfo(respuesta);
                    this.Close();
                }
                else
                    CapaInterfaz.Decoracion.mostrarInfo("Debe seleccionar al menos un turno");
            }

            private void Alta_Load(object sender, EventArgs e)
            {
                CapaInterfaz.IAuto.CargarTurnos(this.tablaTurno);
                CapaInterfaz.IAuto.CargarChoferes(this.tablaChofer);
                CapaInterfaz.IAuto.OcultarColumnas(this.tablaTurno, 1);
                CapaInterfaz.IAuto.OcultarColumnas(this.tablaChofer, 0);
            }

            private void btnVolver_Click(object sender, EventArgs e)
            {
                this.Close();
            }

        #endregion

            private void numMarca_ValueChanged(object sender, EventArgs e)
            {

            }

            private void tablaTurno_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
            {
                if (e.ColumnIndex == tablaTurno.Columns["Elegir"].Index)
                {
                    DataGridViewCheckBoxCell chkElegir = (DataGridViewCheckBoxCell)tablaTurno.Rows[e.RowIndex].Cells["Elegir"];
                    chkElegir.Value = !Convert.ToBoolean(chkElegir.Value);
                }
            }

            private void tablaChofer_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex > -1)
                {
                    System.Windows.Forms.DataGridViewCell selectedCell = this.tablaChofer[0, e.RowIndex];
                    idChofer = Convert.ToInt32(selectedCell.FormattedValue);
                }
            }

    }
}
