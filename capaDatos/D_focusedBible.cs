using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using System.Configuration;

using capaEntidad;

namespace capaDatos
{
    public class D_focusedBible
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconex"].ConnectionString);
        E_focusedBible preg = new E_focusedBible();

        public DataTable D_listado(E_focusedBible preg)
        {
            SqlCommand cmd = new SqlCommand("sp_listar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codPreg", preg.codPreg);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public void D_insertar(E_focusedBible preg) //insertar Datos (recibe la clase E_Empleados como parametro)
        {
            SqlCommand cmd = new SqlCommand("sp_insert", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            //llenado de los parametros del procedimiento almacenado (estos se colocan con "@" 
            //y se llenan con el valor ingresado despues de la coma.  "@preg", preg.a
            cmd.Parameters.AddWithValue("@preg", preg.preg);
            cmd.Parameters.AddWithValue("@a", preg.a);
            cmd.Parameters.AddWithValue("@b", preg.b);
            cmd.Parameters.AddWithValue("@c", preg.c);
            cmd.Parameters.AddWithValue("@d", preg.d);
            cmd.Parameters.AddWithValue("@resp", preg.resp);

            if (cn.State == ConnectionState.Open) cn.Close();

            cn.Open();
            cmd.ExecuteNonQuery(); // Ejecutar la consulta en el procedimiento almacenado
            cn.Close();
        }


        public int D_NumFilas()
        {
            SqlCommand cmd = new SqlCommand("sp_listarTodo", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows.Count;//Devuelve el total de filas
        }


    }

    
}
