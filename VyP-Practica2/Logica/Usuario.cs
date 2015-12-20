using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Usuario
    {
        private static int contadorId = 1;

        private int idUsuario;
        private String nick;
        private String password;
        private TipoUsuario tipo;
        private DateTime fechaRegistro;
        private DateTime fechaUltimaConexion;
        private DateTime? fechaNacimiento;
        private String nombre;
        private String apellido1;
        private String apellido2;
        private int nroIntentos;
        private bool bloqueado;


        public Usuario(String nick, String password, String nombre,
            String apellido1, String apellido2, DateTime? fechaNacimiento)
        {
            if (nick != null && password != null && Utilidad.compruebaNick(nick))
            {
                this.idUsuario = contadorId++;
                Nick = nick;
                Password = password;
                Nombre = nombre;
                Apellido1 = apellido1;
                Apellido2 = apellido2;
                FechaNacimiento = fechaNacimiento;

                fechaRegistro = DateTime.Now;
                tipo = TipoUsuario.NORMAL;
                nroIntentos = 0;
                bloqueado = false;
            }
        }

        // METODOS GETTER Y SETTER
        public int IdUsuario
        {
            get;
        }

        public String Nick
        {
            get;
        }

        public String Password
        {
            get;
            set;
        }

        public TipoUsuario Tipo
        {
            get;
            set;
        }

        public DateTime FechaRegistro
        {
            get;
        }

        public DateTime FechaUltimaConexion
        {
            get;
            set;
        }

        public DateTime? FechaNacimiento
        {
            get
            {
                return fechaNacimiento;
            }
            set
            {
                DateTime d = (DateTime)value;
                if (Utilidad.compruebaFechaValida(d.Year, d.Month, d.Day))
                {
                    fechaNacimiento = value;
                }
                else
                {
                    // Lanzar excepcion
                }
            }
        }

        public String Nombre
        {
            get { return nombre; }
            set
            {
                if (Utilidad.compruebaNombre(value))
                {
                    nombre = value;
                }
            }
        }

        public String Apellido1
        {
            get { return apellido1; }
            set
            {
                if (Utilidad.compruebaNombre(value))
                {
                    apellido1 = value;
                }
            }
        }

        public String Apellido2
        {
            get { return apellido2; }
            set
            {
                if (Utilidad.compruebaNombre(value))
                {
                    apellido2 = value;
                }
            }
        }
        //FIN GETTERS SETTERS

        public bool cambiarDatosUsuario(String nick, String password, String nombre,
            String apellido1, String apellido2, DateTime? fechaNacimiento)
        {
            bool flag = false;

            if (nick != null)
            {
                throw new Exception();
            }

            if (password != null)
            {
                Password = password;
                flag = true;
            }

            if (nombre != null && Utilidad.compruebaNombre(nombre))
            {
                Nombre = nombre;
                flag = true;
            }

            if (apellido1 != null && Utilidad.compruebaNombre(apellido1))
            {
                Apellido1 = apellido1;
                flag = true;
            }

            if (apellido2 != null && Utilidad.compruebaNombre(apellido2))
            {
                Apellido2 = apellido2;
                flag = true;
            }

            if (fechaNacimiento != null)
            {
                DateTime fecha = (DateTime)fechaNacimiento;
                if (Utilidad.compruebaFechaValida(fecha.Year,
                fecha.Month, fecha.Day))
                {
                    FechaNacimiento = fechaNacimiento;
                    flag = true;
                }
            }

            if (flag == false)
            {
                throw new Exception();
            }

            return flag;
        }

        public bool editTipo(TipoUsuario tipo)
        {
            bool flag = false;

            if (Tipo != tipo)
            {
                Tipo = tipo;
                flag = true;
            }

            return flag;
        }

        private bool aumentarNroIntentos()
        {
            bool flag = false;

            if (nroIntentos < 3)
            {
                nroIntentos++;
                flag = true;
            }

            return flag;
        }

        private void resetearNroIntentos()
        {
            nroIntentos = 0;
        }

        private bool bloquearUsuario()
        {
            bool flag = false;

            if (bloqueado == false)
            {
                bloqueado = true;
                flag = true;
            }

            return flag;
        }

        private bool desbloquearUsuario()
        {
            bool flag = false;

            if (bloqueado == true)
            {
                bloqueado = false;
                flag = true;
            }

            return flag;
        }

        public bool intentoLogin(String password)
        {
            bool flag = false;

            if (Password != password)
            {
                aumentarNroIntentos();
                if (nroIntentos == 3)
                {
                    bloquearUsuario();
                }
            }
            else
            {
                resetearNroIntentos();
                flag = true;
            }

            return flag;
        }


    }//fin clase
}
