using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades.Examen;
using LogicaNegocio.Examen;

namespace Examen
{
    public partial class Examenuno : Form
    {
        private examenManejador _examenManejador;
        private examenuno _proveedores;
        public Examenuno()
        {
            InitializeComponent();
            _examenManejador = new examenManejador();
            _proveedores = new examenuno();
           
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarProductos(txtBuscar.Text);
        }
        private void BuscarProductos(string filtro)
        {
            dtgProveedor.DataSource = _examenManejador.GetProveedor(filtro);
        }
        private void eliminar()
        {
            var Idproducto = dtgProveedor.CurrentRow.Cells["Idproveedor"].Value;
            _examenManejador.Eliminar(Convert.ToInt32(Idproducto));
        }
        private void Modificar()
        {
            controlcajas(true);
            controlbotones(false, true, true, false);
            lblId.Text = dtgProveedor.CurrentRow.Cells["Idproveedor"].Value.ToString();
            txtNombre.Text = dtgProveedor.CurrentRow.Cells["nombre"].Value.ToString();
            txtDireccion.Text = dtgProveedor.CurrentRow.Cells["direccion"].Value.ToString();
            txtTelefono.Text = dtgProveedor.CurrentRow.Cells["telefono"].Value.ToString();
        }

        private void dtgProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Modificar();
                BuscarProductos("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de eliminar este registro?", "Eliminar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    eliminar();
                    BuscarProductos("");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void cargarproducto()
        {
            _proveedores.Idproveedor = Convert.ToInt32(lblId.Text);
            _proveedores.Nombre = txtNombre.Text;
            _proveedores.Direccion = txtDireccion.Text;
            _proveedores.Telefono = txtTelefono.Text;
        }
        private void guardarproducto()
        {
            _examenManejador.Guardar(_proveedores);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cargarproducto();
            controlbotones(true, false, false, true);
            controlcajas(false);
            //para guardar
            try
            {
                guardarproducto();
                BuscarProductos("");
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dtgProveedor.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void controlbotones(bool nuevo, bool guardar, bool cancelar, bool eliminar)
        {
            btnNuevo.Enabled = nuevo;
            btnGuardar.Enabled = guardar;
            btnCancelar.Enabled = cancelar;
            btnEliminar.Enabled = eliminar;
        }
        private void controlcajas(bool activar)
        {
            txtNombre.Enabled = activar;
            txtDireccion.Enabled = activar;
            txtTelefono.Enabled = activar;

        }
        private void limpiar()
        {
            txtNombre.Text = "";
            txtDireccion.Text = "";
            lblId.Text = "0";
            txtTelefono.Text = "";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            controlbotones(false, true, true, true);
            controlcajas(true);
            txtNombre.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            controlbotones(true, false, false, true);
            controlcajas(false);
            limpiar();
        }

        private void Examenuno_Load(object sender, EventArgs e)
        {
            BuscarProductos("");
            controlbotones(true, false, false, true);
            controlcajas(false);
            limpiar();
            dtgProveedor.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
