using Hotel.Dominio;
using Hotel.Logic;
using System;
using System.Windows.Forms;

namespace HotelApp.Win
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void IniciarFormulario(object sender, EventArgs e)
        {
            cargarDatos();
        }
        private void cargarDatos()
        {
            var listado = ClienteBL.Listar();
            dgvListado.Rows.Clear();
            foreach (var cliente in listado)
            {
                dgvListado.Rows.Add(cliente.IdCliente, cliente.Nombre, cliente.Direccion, cliente.DNI,cliente.Telefono);
            }

        }
        private void nuevoRegistro(object sender, EventArgs e)
        {
            var nuevoCliente = new Cliente();
            var frm = new frmClienteEdit(nuevoCliente);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var exito = ClienteBL.Insertar(nuevoCliente);
                if (exito)
                {
                    MessageBox.Show("El cliente ha sido registrado", "SISTEMA HOTEL",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
                }
                else
                {
                    MessageBox.Show("No se ha podido registrar el cliente", "SISTEMA HOTEL",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void editarRegistro(object sender, EventArgs e)
        {
            if (dgvListado.Rows.Count > 0)
            {
                int filaActual = dgvListado.CurrentRow.Index;
                var idcliente = int.Parse(dgvListado.Rows[filaActual].Cells[0].Value.ToString());
                var ClienteEditar = ClienteBL.BuscarPorId(idcliente);
                var frm = new frmClienteEdit(ClienteEditar);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var exito = ClienteBL.Actualizar(ClienteEditar);
                    if (exito)
                    {
                        MessageBox.Show("El cliente ha sido actualizado", "SISTEMA HOTEL",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido actualizar", "SISTEMA HOTEL",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void eliminarRegistro(object sender, EventArgs e)
        {
            if (dgvListado.Rows.Count > 0)
            {
                int filaActual = dgvListado.CurrentRow.Index;
                var idcliente = int.Parse(dgvListado.Rows[filaActual].Cells[0].Value.ToString());
                var nombreCliente = dgvListado.Rows[filaActual].Cells[1].Value.ToString();
                var rpta = MessageBox.Show("¿Realmente desea eliminar el cliente " + nombreCliente + " ?",
                    "SISTEMA HOTEL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rpta == DialogResult.Yes)
                {
                    var exito = ClienteBL.Eliminar(idcliente);
                    if (exito)
                    {
                        MessageBox.Show("El cliente ha sido eliminado.", "SISTEMA HOTEL",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido eliminar el cliente", "SISTEMA HOTEL",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
