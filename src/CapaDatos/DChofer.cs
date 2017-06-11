﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace CapaDatos
{
    public class DChofer
    {

        public DChofer()
        {
        }

        public DataTable ObtenerChoferes(String turno)
        {
            Conexion Conexion = new Conexion();

            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@turno";
            parametros[0].SqlDbType = SqlDbType.Int;
            parametros[0].Value = Int32.Parse(turno);

            DataTable DtResultado = new DataTable("Chofer");
            DtResultado = Conexion.RetornarTabla(parametros, "CRAZYDRIVER.spObtenerChoferesPorTurno");
            return DtResultado;
        }

        public DataTable ObtenerChoferes()
        {
            Conexion Conexion = new Conexion();

            DataTable DtResultado = new DataTable("Choferes");
            DtResultado = Conexion.RetornarTabla("CRAZYDRIVER.spObtenerTodoChoferes");

            return DtResultado;
        }

        public DataTable ObtenerChoferEspecifico(string nombre, string apellido, string dni)
        {
            Conexion Conexion = new Conexion();

            SqlParameter[] parametros = new SqlParameter[3];

            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@choferNombre";
            parametros[0].SqlDbType = SqlDbType.NVarChar;
            parametros[0].Size = 255;
            parametros[0].Value = nombre;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@choferApellido";
            parametros[1].SqlDbType = SqlDbType.NVarChar;
            parametros[1].Size = 255;
            parametros[1].Value = apellido;

            parametros[2] = new SqlParameter();
            parametros[2].ParameterName = "@choferDni";
            parametros[2].SqlDbType = SqlDbType.NVarChar;
            parametros[2].Size = 18;
            parametros[2].Value = dni;

            DataTable DtResultado = new DataTable("Choferes");
            DtResultado = Conexion.RetornarTabla(parametros, "CRAZYDRIVER.spObtenerChoferEspecifico");

            return DtResultado;
        }

        public string actualizarChofer(Chofer chofer)
        {
            Conexion Conexion = new Conexion();

            SqlParameter[] parametros = new SqlParameter[13];

            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@choferId";
            parametros[0].SqlDbType = SqlDbType.Int;
            parametros[0].Value = chofer.Id;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@choferNombre";
            parametros[1].SqlDbType = SqlDbType.NVarChar;
            parametros[1].Size = 255;
            parametros[1].Value = chofer.Nombre;

            parametros[2] = new SqlParameter();
            parametros[2].ParameterName = "@choferApellido";
            parametros[2].SqlDbType = SqlDbType.NVarChar;
            parametros[2].Size = 255;
            parametros[2].Value = chofer.Apellido;

            parametros[3] = new SqlParameter();
            parametros[3].ParameterName = "@choferDni";
            parametros[3].SqlDbType = SqlDbType.NVarChar;
            parametros[3].Size = 18; // numeric 18,0 en realidad
            parametros[3].Value = chofer.Dni;

            parametros[4] = new SqlParameter();
            parametros[4].ParameterName = "@choferFechaNac";
            parametros[4].SqlDbType = SqlDbType.DateTime;
            parametros[4].Value = chofer.FechaNac;

            parametros[5] = new SqlParameter();
            parametros[5].ParameterName = "@choferTelefono";
            parametros[5].SqlDbType = SqlDbType.NVarChar;
            parametros[5].Size = 18; // numeric 18,0 en realidad
            parametros[5].Value = chofer.Telefono;

            parametros[6] = new SqlParameter();
            parametros[6].ParameterName = "@choferMail";
            parametros[6].SqlDbType = SqlDbType.NVarChar;
            parametros[6].Size = 255;
            parametros[6].Value = chofer.Mail;

            parametros[7] = new SqlParameter();
            parametros[7].ParameterName = "@choferDireccion";
            parametros[7].SqlDbType = SqlDbType.NVarChar;
            parametros[7].Size = 255;
            parametros[7].Value = chofer.Direccion;

            parametros[8] = new SqlParameter();
            parametros[8].ParameterName = "@choferLocalidad";
            parametros[8].SqlDbType = SqlDbType.NVarChar;
            parametros[8].Size = 255;
            parametros[8].Value = chofer.Localidad;

            parametros[9] = new SqlParameter();
            parametros[9].ParameterName = "@choferNroPiso";
            parametros[9].SqlDbType = SqlDbType.Int;
            parametros[9].Value = chofer.NroPiso;

            parametros[10] = new SqlParameter();
            parametros[10].ParameterName = "@choferDepto";
            parametros[10].SqlDbType = SqlDbType.Char;
            parametros[10].Size = 1;
            parametros[10].Value = chofer.Depto;

            parametros[11] = new SqlParameter();
            parametros[11].ParameterName = "@choferMail";
            parametros[11].SqlDbType = SqlDbType.NVarChar;
            parametros[11].Size = 255;
            parametros[11].Value = chofer.Mail;

            parametros[12] = new SqlParameter();
            parametros[12].ParameterName = "@habilitado";
            parametros[12].SqlDbType = SqlDbType.Int;
            parametros[12].Value = chofer.Habilitado;

            string resultado = Conexion.Ejecutar(parametros, "CRAZYDRIVER.spActualizarChofer");
            string respuesta = string.Empty;
            switch (resultado)
            {
                case "-1":
                    respuesta = "Se capturo un error al intentar modificar un chofer";
                    break;
                case "0":
                    respuesta = "No se logro modificar un chofer";
                    break;
                case "1":
                    respuesta = "Se modificar un chofer";
                    break;
            }
            return respuesta;
        }

    }
}
