using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Examen;
using AccesoaDatos.Examen;

namespace LogicaNegocio.Examen
{
    public class examenManejador
    {
        private examenAccesoDatos _examenAccesoDatos = new examenAccesoDatos();
        public void Guardar(examenuno proveedor)
        {
            _examenAccesoDatos.Guardar(proveedor);
        }
        public void Eliminar(int Idproveedor)
        {
            //eliminar
            _examenAccesoDatos.Eliminar(Idproveedor);
        }
        public List<examenuno> GetProveedor(string filtro)
        {
            var listproveedor = _examenAccesoDatos.GetProveedor(filtro);
            //lenar lista
            return listproveedor;
        }
    }
}
