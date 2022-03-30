using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Contactos
    {
        private CD_Contactos objetoCD = new CD_Contactos();

        public DataTable MostrarCont() {

            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public void InsertarCont (string name, string lastName, string address, string dateBirthday, string phoneNumber)
        {

            objetoCD.Insertar(name,lastName,address,dateBirthday,phoneNumber);
    }

        public void EditarCont(string name, string lastName, string address, string dateBirthday, string phoneNumber, string id)
        {
            objetoCD.Editar(name, lastName, address, dateBirthday, phoneNumber,Convert.ToInt32(id));
        }

        public void EliminarCont(string id) {

            objetoCD.Eliminar(Convert.ToInt32(id));
        }
    }
}
