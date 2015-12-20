using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Log
    {
        private TipoUsuario tipo;
        private DateTime fecha;
        private TipoSeccion seccion;
        private Usuario user;

        public Log(Usuario user, TipoUsuario tipo, TipoSeccion seccion, DateTime fecha)
        {
            this.user = user;
            this.tipo = tipo;
            this.seccion = seccion;
            this.fecha = fecha;
        }

        public String stringInforme()
        {
            if (tipo == TipoUsuario.ADMINISTRADOR)
            {
                return tipo.ToString() + " " + user.Nick + " realizó " + seccion.ToString() +
                    " a las " + fecha.Hour.ToString() + ":" + fecha.Minute.ToString() + ":" + fecha.Second.ToString() +
                    " el " + fecha.Day.ToString() + "/" + fecha.Month.ToString() + "/" + fecha.Year.ToString();
            }
            else
            {
                return user.Nick + " realizó " + seccion.ToString() + " a las " + fecha.Hour.ToString() +
                   ":" + fecha.Minute.ToString() + ":" + fecha.Second.ToString() + " el " +
                   fecha.Day.ToString() + "/" + fecha.Month.ToString() + "/" + fecha.Year.ToString();
            }
        }
    }
}
