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
                this.nick = nick;
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
            get { return nick; }
        }

        public String Password
        {
            set
            {
                if (value != null && value.Length!=0)
                {
                    password = value;
                }
                else
                {
                    throw new Exception("El password no es admisible");
                }
            }
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
                if (value != null)
                {
                    DateTime d = (DateTime)value;
                    if (Utilidad.compruebaFechaValida(d.Year, d.Month, d.Day))
                    {
                        fechaNacimiento = value;
                    }
                    else
                    {
                        throw new Exception("La fecha no es apropiada");
                    }
                }
                else
                {
                    fechaNacimiento = value;
                }
            }
        }

        public String Nombre
        {
            get { return nombre; }
            set
            {
                if (value != null)
                {
                    if (Utilidad.compruebaNombre(value))
                    {
                        nombre = value;
                    }
                    else
                    {
                        throw new Exception("El nombre es incorrecto");
                    }
                }
                else
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
                if (value != null)
                {
                    if (Utilidad.compruebaNombre(value))
                    {
                        apellido1 = value;
                    }
                    else
                    {
                        throw new Exception("El apellido 1 es incorrecto");
                    }
                }
                else
                {
                    nombre = value;
                }
            }
        }

        public String Apellido2
        {
            get { return apellido2; }
            set
            {
                if (value != null)
                {
                    if (Utilidad.compruebaNombre(value))
                    {
                        apellido2 = value;
                    }
                    else
                    {
                        throw new Exception("El apellido 2 es incorrecto");
                    }
                }
                else
                {
                    nombre = value;
                }
            }
        }
        //FIN GETTERS SETTERS

        public bool comparaPassword(String p)
        {
            return password.Equals(p);
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

            if (this.password != password)
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
