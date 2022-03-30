using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        CN_Contactos objetoCN = new CN_Contactos();
        private string idProducto=null;
        private bool Editar = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarContactos();
        }

        private void MostrarContactos() {

            CN_Contactos objeto = new CN_Contactos();
            dataGridView1.DataSource = objeto.MostrarCont();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //INSERTAR
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarCont(txtName.Text, txtLastName.Text, txtAddress.Text, txtDate.Text, txtPhoneNumber.Text);
                    MessageBox.Show("Contacto Agregado exitosamente");
                    MostrarContactos();
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos por: " + ex);
                }
            }
            //EDITAR
            if (Editar == true) {

                try
                {
                    objetoCN.EditarCont(txtName.Text, txtLastName.Text, txtAddress.Text, txtDate.Text, txtPhoneNumber.Text,idProducto);
                    MessageBox.Show("Edictado correctamente");
                    MostrarContactos();
                    limpiarForm();
                    Editar = false;
                }
                catch (Exception ex) {
                    MessageBox.Show("No se pudo editar el contacto: " + ex);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtName.Text = dataGridView1.CurrentRow.Cells["Firt_Name"].Value.ToString();
                txtAddress.Text = dataGridView1.CurrentRow.Cells["Last_Name"].Value.ToString();
                txtLastName.Text = dataGridView1.CurrentRow.Cells["Firt_Address"].Value.ToString();
                txtDate.Text = dataGridView1.CurrentRow.Cells["Date_Birthday"].Value.ToString();
                txtPhoneNumber.Text = dataGridView1.CurrentRow.Cells["Phone_Number"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
                MessageBox.Show("Primero seleccione una fila");
        }

        private void limpiarForm() {
            txtLastName.Clear();
            txtAddress.Text = "";
            txtDate.Clear();
            txtPhoneNumber.Clear();
            txtName.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                objetoCN.EliminarCont(idProducto);
                MessageBox.Show("Contacto Eliminado");
                MostrarContactos();
            }
            else
                MessageBox.Show("Primero seleccione una fila");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

 
    }
    }

