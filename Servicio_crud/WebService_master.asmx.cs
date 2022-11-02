using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Servicio_crud
{
    /// <summary>
    /// Descripción breve de WebService_master
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService_master : System.Web.Services.WebService
    {


        /*METODOS ACTOR*/

        [WebMethod]
        public string Actor_Select()
        {
            Oracle_conn conn = new Oracle_conn();
            conn.EstablecerConnection();

            Procedimientos pc = new Procedimientos();

            return pc.Actores_Select_Pro(conn);

        }

        [WebMethod]
        public string Actores_New(string id, string nombre, string nacionalidad, string roles)
        {
            Oracle_conn conn = new Oracle_conn();
            conn.EstablecerConnection();

            Procedimientos pc = new Procedimientos();

            return pc.Actores_New_Pro(conn.GetConexion(), id, nombre, nacionalidad, roles);
        }

        [WebMethod]
        public string Actores_Update(string id, string nombre)
        {
            Oracle_conn conn = new Oracle_conn();
            conn.EstablecerConnection();

            Procedimientos pc = new Procedimientos();
            return pc.Actores_Update_Pro(conn.GetConexion(), id, nombre);
        }

        [WebMethod]
        public string Actores_Drop(string id)
        {
            Oracle_conn conn = new Oracle_conn();
            conn.EstablecerConnection();

            Procedimientos pc = new Procedimientos();

            return pc.Actores_Drop_Pro(conn.GetConexion(), id);
        }
    }
}
