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
    public class DRol
    {
        public DRol()
        {
        }

        public DataTable ObtenerRoles()
        {
            Conexion Conexion = new Conexion();

            DataTable DtResultado = new DataTable("Roles");
            DtResultado = Conexion.RetornarTabla("CRAZYDRIVER.spObtenerRoles");

            return DtResultado;
        }

        public DataTable ObtenerRoles(int idUsuario)
        {
            Conexion Conexion = new Conexion();

            SqlParameter[] parametros = new SqlParameter[1];

            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@idUsuario";
            parametros[0].SqlDbType = SqlDbType.Int;
            parametros[0].Value = idUsuario;

            DataTable DtResultado = new DataTable("Roles");
            DtResultado = Conexion.RetornarTabla(parametros, "CRAZYDRIVER.spObtenerRolesPorUsuario");

            return DtResultado;
        }

        public DataTable ObtenerRol(string rolNombre)
        {
            Conexion Conexion = new Conexion();

            SqlParameter[] parametros = new SqlParameter[1];

            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@rolNombre";
            parametros[0].SqlDbType = SqlDbType.NVarChar;
            parametros[0].Size = 100;
            parametros[0].Value = rolNombre;

            DataTable DtResultado = new DataTable("Rol");
            DtResultado = Conexion.RetornarTabla(parametros, "CRAZYDRIVER.spObtenerRol");

            return DtResultado;
        }

        public DataTable buscarRoles(string rolNombre)
        {
            Conexion Conexion = new Conexion();

            SqlParameter[] parametros = new SqlParameter[1];

            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@rolNombre";
            parametros[0].SqlDbType = SqlDbType.NVarChar;
            parametros[0].Size = 100;
            parametros[0].Value = rolNombre;

            DataTable DtResultado = new DataTable("Roles");
            DtResultado = Conexion.RetornarTabla(parametros, "CRAZYDRIVER.spBuscarRoles");

            return DtResultado;
        }

        public DataTable ObtenerFuncionalidades()
        {
            Conexion Conexion = new Conexion();

            DataTable DtResultado = new DataTable("Funcionalidades");
            DtResultado = Conexion.RetornarTabla("CRAZYDRIVER.spObtenerFuncionalidades");

            return DtResultado;
        }

        public DataTable ObtenerFuncionalidades(int rolId)
        {
            Conexion Conexion = new Conexion();

            SqlParameter[] parametros = new SqlParameter[1];

            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@rolId";
            parametros[0].SqlDbType = SqlDbType.Int;
            parametros[0].Value = rolId;

            DataTable DtResultado = new DataTable("Funcionalidades");
            DtResultado = Conexion.RetornarTabla(parametros, "CRAZYDRIVER.spObtenerFuncionalidadesPorRol");

            return DtResultado;
        }

        public string AgregarRol(string rolNombre)
        {
            Conexion Conexion = new Conexion();

            SqlParameter[] parametros = new SqlParameter[2];

            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@idRol";
            parametros[0].SqlDbType = SqlDbType.Int;
            parametros[0].Direction = ParameterDirection.Output;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@rolNombre";
            parametros[1].SqlDbType = SqlDbType.NVarChar;
            parametros[1].Size = 100;
            parametros[1].Value = rolNombre;

            return Conexion.Ejecutar(parametros, "CRAZYDRIVER.spAgregarRol");
        }

        public string AgregarRolFuncionalidad(int idRol, int idFuncionalidad, int habilitado)
        {
            Conexion Conexion = new Conexion();

            SqlParameter[] parametros = new SqlParameter[3];

            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@idRol";
            parametros[0].SqlDbType = SqlDbType.Int;
            parametros[0].Value = idRol;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@idFuncionalidad";
            parametros[1].SqlDbType = SqlDbType.Int;
            parametros[1].Value = idFuncionalidad;

            parametros[2] = new SqlParameter();
            parametros[2].ParameterName = "@habilitado";
            parametros[2].SqlDbType = SqlDbType.Int;
            parametros[2].Value = habilitado;

            return Conexion.Ejecutar(parametros, "CRAZYDRIVER.spAgregarRolFuncionalidad");
        }

        public string ActualizarRol(Rol rol)
        {
            string respuesta = string.Empty;

            Conexion Conexion = new Conexion();
            SqlParameter[] parametros = new SqlParameter[3];

            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@idRol";
            parametros[0].SqlDbType = SqlDbType.Int;
            parametros[0].Value = rol.Id;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@rolNombre";
            parametros[1].SqlDbType = SqlDbType.NVarChar;
            parametros[1].Size = 100;
            parametros[1].Value = rol.Nombre;

            parametros[2] = new SqlParameter();
            parametros[2].ParameterName = "@habilitado";
            parametros[2].SqlDbType = SqlDbType.Int;
            parametros[2].Value = rol.Habilitado;

            return Conexion.Ejecutar(parametros, "CRAZYDRIVER.spActualizarRol");
        }

        public string ActualizarRolFuncionalidad(Rol rol, Funcionalidad funcionalidad)
        {
            Conexion Conexion = new Conexion();
            SqlParameter[] parametros = new SqlParameter[3];

            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@idRol";
            parametros[0].SqlDbType = SqlDbType.Int;
            parametros[0].Value = rol.Id;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@idFuncionalidad";
            parametros[1].SqlDbType = SqlDbType.Int;
            parametros[1].Value = funcionalidad.Id;

            parametros[2] = new SqlParameter();
            parametros[2].ParameterName = "@habilitado";
            parametros[2].SqlDbType = SqlDbType.Int;
            parametros[2].Value = funcionalidad.Habilitado;

            return Conexion.Ejecutar(parametros, "CRAZYDRIVER.spActualizarFuncionalidadPorRol");
        }
    }
}
