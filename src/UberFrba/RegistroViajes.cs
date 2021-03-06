﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaInterfaz;

namespace UberFrba
{
    public partial class RegistroViajes : Form
{
        public RegistroViajes()
        {
            InitializeComponent();
            CapaInterfaz.Decoracion.Reorganizar(this);
        }

        // verifica que los campos esten completos 
        private Boolean validarCampos()
        {
            return true;
        }

        // resetea valores a su default
        private void reset()
        {
            inputKms.Value = 1;
            txtCosto.Text = String.Empty;
            String turno = ITurno.getIdTurnoActual(cbxTurno.Text);
            if (turno != null)
            {
                CapaInterfaz.ITurno.CargarLimitesFechas(dateFrom, dateTo, turno, Properties.Settings.Default.FechaSistema);
                CapaInterfaz.IChofer.CargarChoferesPorTurno(cbxChofer, dateFrom.Value, dateTo.Value, turno);
                String idChofer = CapaInterfaz.IChofer.getIdChoferActual(cbxChofer.Text);
                if (idChofer == null) return;
                CapaInterfaz.IAuto.CargarAutoHabilitado(txtAuto, idChofer, turno);
            }
            CapaInterfaz.ICliente.CargarClientes(cbxCliente, dateFrom.Value, dateTo.Value);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void RegistroViajes_Load(object sender, EventArgs e)
        {
            CapaInterfaz.ITurno.CargarTurnos(cbxTurno);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            String idcliente = CapaInterfaz.ICliente.getIdClienteActual(cbxCliente.Text);
            if (idcliente == null) return;
            String idchofer = CapaInterfaz.IChofer.getIdChoferActual(cbxChofer.Text);
            if (idchofer == null) return;
            String turno = CapaInterfaz.ITurno.getIdTurnoActual(cbxTurno.Text);
            if (turno == null) return;
            String idauto = CapaInterfaz.IAuto.getIdAutoActual(txtAuto.Text);
            if (idauto == null) return;
            DateTime fechaDesde = dateFrom.Value;
            DateTime fechaHasta = dateTo.Value;
            int kms = Int32.Parse(inputKms.Value.ToString());
            CapaInterfaz.IViaje.AgregarViaje(idcliente, idchofer, turno, idauto, fechaDesde, fechaHasta, kms);
            reset();
            MessageBox.Show("Se ha registrado el viaje", "Registro viaje", MessageBoxButtons.OK);
            this.Close();
        }

        private void cbxTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            String turno = CapaInterfaz.ITurno.getIdTurnoActual(cbxTurno.Text);
            if (turno != null)
            {
                CapaInterfaz.ITurno.CargarLimitesFechas(dateFrom, dateTo, turno, Properties.Settings.Default.FechaSistema);
                CapaInterfaz.IChofer.CargarChoferesPorTurno(cbxChofer, dateFrom.Value, dateTo.Value, turno);
                String idChofer = CapaInterfaz.IChofer.getIdChoferActual(cbxChofer.Text);
                if (idChofer == null) return;
                CapaInterfaz.IAuto.CargarAutoHabilitado(txtAuto, idChofer, turno);
            }
            CapaInterfaz.ICliente.CargarClientes(cbxCliente, dateFrom.Value, dateTo.Value);
        }

        private void cbxChofer_SelectedIndexChanged(object sender, EventArgs e)
        {
            String idChofer = CapaInterfaz.IChofer.getIdChoferActual(cbxChofer.Text);
            if (idChofer == null) return;
            String turno = CapaInterfaz.ITurno.getIdTurnoActual(cbxTurno.Text);
            if (turno == null) return;
            CapaInterfaz.IAuto.CargarAutoHabilitado(txtAuto, idChofer, turno);
        }

        private void btnCalcularCosto_Click(object sender, EventArgs e)
        {
            int kms = Int32.Parse(inputKms.Value.ToString());
            String idturno = CapaInterfaz.ITurno.getIdTurnoActual(cbxTurno.Text);
            if (idturno == null) return;
            CapaInterfaz.ITurno.CargarValorTurno(txtCosto, kms, idturno);
        }

        private void dateFrom_ValueChanged(object sender, EventArgs e)
        {   
            DateTime now = Properties.Settings.Default.FechaSistema;
            dateTo.MinDate = new DateTime(now.Year, now.Month, now.Day, dateFrom.Value.Hour, dateFrom.Value.Minute, dateFrom.Value.Second);
            CapaInterfaz.ICliente.CargarClientes(cbxCliente, dateFrom.Value, dateTo.Value);
            String turno = CapaInterfaz.ITurno.getIdTurnoActual(cbxTurno.Text);
            if (turno == null) return;
            CapaInterfaz.IChofer.CargarChoferesPorTurno(cbxChofer, dateFrom.Value, dateTo.Value, turno);
        }

        private void dateTo_ValueChanged(object sender, EventArgs e)
        {
            DateTime now = Properties.Settings.Default.FechaSistema;
            dateFrom.MaxDate = new DateTime(now.Year, now.Month, now.Day, dateTo.Value.Hour, dateTo.Value.Minute, dateTo.Value.Second);
            CapaInterfaz.ICliente.CargarClientes(cbxCliente, dateFrom.Value, dateTo.Value);
            String turno = CapaInterfaz.ITurno.getIdTurnoActual(cbxTurno.Text);
            if (turno == null) return;
            CapaInterfaz.IChofer.CargarChoferesPorTurno(cbxChofer, dateFrom.Value, dateTo.Value, turno);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
