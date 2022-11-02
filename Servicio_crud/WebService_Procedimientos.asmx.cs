using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Servicio_crud
{
    public class Procedimientos
    {

        public Procedimientos()
        {
            
        }

        public string Actores_Select_Pro(Oracle_conn conn)
        {

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn.GetConexion();
            cmd.CommandText = "SELECT * FROM ACTORES";
            cmd.CommandType = System.Data.CommandType.Text;


            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(ds);

            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }
        public string Actores_New_Pro(OracleConnection conn, string id, string nombre, string nacionalidad, string roles)
        {


            OracleParameter param_id = new OracleParameter();
            param_id.OracleDbType = OracleDbType.Varchar2;
            param_id.Value = id;

            OracleParameter param_nombre = new OracleParameter();
            param_nombre.OracleDbType = OracleDbType.Varchar2;
            param_nombre.Value = nombre;

            OracleParameter param_nacionalidad = new OracleParameter();
            param_nacionalidad.OracleDbType = OracleDbType.Varchar2;
            param_nacionalidad.Value = nacionalidad;

            OracleParameter param_roles = new OracleParameter();
            param_roles.OracleDbType = OracleDbType.Varchar2;
            param_roles.Value = roles;


            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERTAR_ACTOR";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("PV1", OracleDbType.Varchar2).Value = param_id.Value;
            cmd.Parameters.Add("PV2", OracleDbType.Varchar2).Value = param_nombre.Value;
            cmd.Parameters.Add("PV3", OracleDbType.Varchar2).Value = param_nacionalidad.Value;
            cmd.Parameters.Add("PV4", OracleDbType.Varchar2).Value = param_roles.Value;
            cmd.ExecuteNonQuery();

            string respuesta = "Actor insertado";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }

        public string Actores_Update_Pro(OracleConnection conn, string id, string nombre)
        {


            OracleParameter param_id = new OracleParameter();
            param_id.OracleDbType = OracleDbType.Varchar2;
            param_id.Value = id;

            OracleParameter param_nombre = new OracleParameter();
            param_nombre.OracleDbType = OracleDbType.Varchar2;
            param_nombre.Value = nombre;


            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "ACTORES_UPDATE";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("PV1", OracleDbType.Varchar2).Value = param_id.Value;
            cmd.Parameters.Add("PV2", OracleDbType.Varchar2).Value = param_nombre.Value;
            cmd.ExecuteNonQuery();

            string respuesta = "Nombre de actor actualizado";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }

        public string Actores_Drop_Pro(OracleConnection conn, string id)
        {

            OracleParameter param_id = new OracleParameter();
            param_id.OracleDbType = OracleDbType.Varchar2;
            param_id.Value = id;


            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "ACTORES_DROP";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("PV1", OracleDbType.Varchar2).Value = param_id.Value;
            cmd.ExecuteNonQuery();

            string respuesta = "Actor eliminado";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }
    }
}
