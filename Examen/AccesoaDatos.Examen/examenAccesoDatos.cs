using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Examen;
using System.Data;

namespace AccesoaDatos.Examen
{
    public class examenAccesoDatos
    {
        coneccionAccesoDatos conexion;
        public examenAccesoDatos()
        {
            conexion = new coneccionAccesoDatos("localhost", "root", "", "abarrotespueblito", 3306);
        }
        public void Guardar(examenuno proveedor)
        {
            if (proveedor.Idproveedor == 0)
            {
                //insertar
                string consulta = string.Format("insert into provedor values(null,'{0}','{1}','{2}')",
                proveedor.Nombre, proveedor.Direccion, proveedor.Telefono);
                conexion.Ejecutarconsulta(consulta);
            }
            else
            {
                //update o que lo modifique
                string consulta = string.Format("Update provedor set nombrep = '{0}', direccion = '{1}', telefono = '{2}' where idprovedor = {3}",
                proveedor.Nombre, proveedor.Direccion, proveedor.Telefono, proveedor.Idproveedor);
                conexion.Ejecutarconsulta(consulta);
            }
        }
        public void Eliminar(int Idproveedor)
        {
            //eliminar
            string consulta = string.Format("delete from provedor where idprovedor = {0}", Idproveedor);
            conexion.Ejecutarconsulta(consulta);
        }
        public List<examenuno> GetProveedor(string filtro)
        {
            //List<Usuario> listusuario = new List<Usuario>();
            var listproveedor = new List<examenuno>(); //la variable var es generica
            var ds = new DataSet();
            string consulta = "Select * from provedor where nombrep like '%" + filtro + "%'";
            ds = conexion.Obtenerdatos(consulta, "provedor");
            var dt = new DataTable();
            dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                var provedor = new examenuno
                {
                    Idproveedor = Convert.ToInt32(row["idprovedor"]),
                    Nombre = row["nombrep"].ToString(),
                    Direccion = row["direccion"].ToString(),
                    Telefono = row["telefono"].ToString(),
                };
                listproveedor.Add(provedor);
            }
            //HardCodear
            //lenar lista
            return listproveedor;
        }
    }
}
