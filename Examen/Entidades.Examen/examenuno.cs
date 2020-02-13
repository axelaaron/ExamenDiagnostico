using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Examen
{
    public class examenuno
    {
        private int _Idproveedor;
        private string _nombre;
        private string _direccion;
        private string _telefono;

        public int Idproveedor { get => _Idproveedor; set => _Idproveedor = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
    }
}
