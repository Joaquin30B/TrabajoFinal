using Hotel.Dominio;
using Hotel.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelApp.Win
{
    public partial class frmClienteEdit : Form
    {
        Cliente cliente;
        public frmClienteEdit(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
        }

        private void IniciarFormulario(object sender, EventArgs e)
        {
            cargarDatos();
            asignarControl();
        }

        private void cargarDatos()
        {
            //Listar lo Nacionalidad
            cboNacionalida.DataSource = NacinalidaBL.Listar();
            cboNacionalida.DisplayMember = "nacionalidad";
            cboNacionalida.ValueMember = "IdNacionalida";

            //Listar lo Habitacion
            cboHabitacion.DataSource = HabitacionBLcs.Listar();
            cboHabitacion.DisplayMember = "Descripcion";
            cboHabitacion.ValueMember = "IdHabitacion";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            asignarObjeto();
            this.DialogResult = DialogResult.OK;
        }


        private void asignarObjeto()
        {
            this.cliente.IdCliente = int.Parse(txtID.Text);
            this.cliente.Nombre = txtNombre.Text;
            this.cliente.Direccion = txtDirec.Text;
            this.cliente.DNI = int.Parse(txtDNI.Text);
            this.cliente.Telefono = txtTelefono.Text;


        }

        private void asignarControl()
        {
            txtID.Text = cliente.IdCliente.ToString();
            txtNombre.Text = cliente.Nombre;
            txtDirec.Text = cliente.Direccion;
            txtDNI.Text = cliente.DNI.ToString();
            txtTelefono.Text = cliente.Telefono;
        }
    }
}
