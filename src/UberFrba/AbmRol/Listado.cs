﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Entidades;

namespace UberFrba.AbmRol
{
    public partial class Listado : Form
    {
        public Listado()
        {
            InitializeComponent();
            CapaInterfaz.Decoracion.Reorganizar(this);
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            CapaInterfaz.IRol.CargarRoles(this.tablaRoles);
            CapaInterfaz.IRol.OcultarColumnasRoles(this.tablaRoles);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CapaInterfaz.IRol.BuscarRolPorNombre(this.tablaRoles, this.txRolNombre.Text);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txRolNombre.Text = String.Empty;
            CapaInterfaz.IRol.CargarRoles(this.tablaRoles);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txRolNombre_TextChanged(object sender, EventArgs e)
        {
            if (this.txRolNombre.Text.Equals(string.Empty))
                CapaInterfaz.IRol.CargarRoles(this.tablaRoles);
            else
                CapaInterfaz.IRol.BuscarRolPorNombre(this.tablaRoles, this.txRolNombre.Text);
        }

        private void tablaRoles_DoubleClick(object sender, EventArgs e)
        {
            Rol rol = new Rol();
            rol.Id = Convert.ToInt32(this.tablaRoles.CurrentRow.Cells["id_rol"].Value);
            rol.Nombre = this.tablaRoles.CurrentRow.Cells["nombre"].Value.ToString();
            rol.Estado = this.tablaRoles.CurrentRow.Cells["estado"].Value.ToString();

            Edicion ventana = new Edicion(rol);
            ventana.ShowDialog(this);
        }
    }
}
