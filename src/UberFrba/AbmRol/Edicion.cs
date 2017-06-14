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
    public partial class Edicion : Form
    {
        private Rol rol;

        public Edicion(Rol rolRecibido)
        {
            InitializeComponent();
            CapaInterfaz.Decoracion.Reorganizar(this);
            rol = rolRecibido;
        }

        private void Edicion_Load(object sender, EventArgs e)
        {
            txtRolNombreViejo.Text = rol.Nombre;
            txtRolEstadoViejo.Text = rol.Estado;

            txtRolNombreNuevo.Text = rol.Nombre;
            cbxRolEstadoNuevo.Text = rol.Estado;
            CapaInterfaz.IRol.CargarFuncionalidades(tablaFuncionalidades, rol);

            CapaInterfaz.IRol.OcultarColumnasFuncionalidades(tablaFuncionalidades);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtRolNombreNuevo.Text = rol.Nombre;
            cbxRolEstadoNuevo.Text = rol.Estado;
            CapaInterfaz.IRol.CargarFuncionalidades(tablaFuncionalidades, rol);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            rol.Nombre = txtRolNombreNuevo.Text;
            rol.Estado = txtRolEstadoViejo.Text;
            string msj = CapaInterfaz.IRol.ActualizarRol(rol, tablaFuncionalidades);
            CapaInterfaz.Decoracion.mostrarInfo(msj);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
