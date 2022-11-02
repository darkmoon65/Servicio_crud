using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Oracle.ManagedDataAccess.Client;

namespace Servicio_crud
{
    public class Oracle_conn
    {
        OracleConnection oc;
        string oradb = "DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=demoprocesos; PASSWORD=Admin1234567"; // establece conexion con el servidor
        public Oracle_conn()
        {
        }

        public void EstablecerConnection()
        {
            oc = new OracleConnection(oradb);
            oc.Open();

        }

        public OracleConnection GetConexion()
        {
            return oc;
        }
    }
}
