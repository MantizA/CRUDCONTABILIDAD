using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDCONTABILIDAD.Data
{
    public class Conexion
    {
        public static string cone = "metadata=res://*/ConexionSQL.csdl|res://*/ConexionSQL.ssdl|res://*/ConexionSQL.msl;provider=System.Data.SqlClient;provider connection string=\"data source=DESKTOP-UQBHU18\\SQLEXPRESS;initial catalog=CONTABILIDADDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework\"";
    }
}