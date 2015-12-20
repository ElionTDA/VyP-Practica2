using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Logica
{
    public class Utilidad
    {
        /// <summary>
        /// Comprueba que los nicks tienen lógica.
        /// </summary>
        /// <param name="nick">Nick a comprobar.</param>
        /// <returns>True o false, en función de si cumple o no.</returns>
        public static bool compruebaNick(String nick)
        {
            bool flag = false;
            if (nick != null && nick.Length > 2 && nick.Length <= 20)
            {
                Regex val = new Regex(@"^[a-zA-Z][a-zA-Z\s0-9[-]]*");
                flag = val.IsMatch(nick);
            }

            return flag;
        }

        /// <summary>
        /// Comprueba que los nombres tienen lógica.
        /// </summary>
        /// <param name="nombre">Nombre a comprobar.</param>
        /// <returns>True o false, en función de si cumple o no.</returns>
        public static bool compruebaNombre(String nombre)
        {
            bool flag = false;
            if (nombre != null && nombre.Length > 2 && nombre.Length <= 20)
            {
                Regex val = new Regex(@"^[a-zA-Z][a-zA-ZñÑ\s]*");
                flag = val.IsMatch(nombre);
            }

            return flag;
        }

        /// <summary>
        /// Valida la fecha 
        /// </summary>
        /// <param name="fecha">Fecha a validar</param>
        /// <returns>True o false, en función de la validación</returns>
        public static bool compruebaFechaValida(int year, int month, int day)
        {
            try
            {
                DateTime hoy = DateTime.Now.Date;
                DateTime fec = new DateTime(year, month, day);


                if (DateTime.Compare(hoy, fec) > 0)
                {
                    if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8
                        || month == 10 || month == 12)
                    {
                        if (day < 32 && day > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (month == 4 || month == 6 || month == 9 || month == 11)
                    {
                        if (day < 31 && day > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (month == 2)
                    {
                        if (day < 29 && day > 0)
                        {
                            return true;
                        }
                        else if (day == 29 && ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                return false;
            }
        }

        public static String cifrar(String password)
        {
            HashAlgorithm hashValue = new
            SHA1CryptoServiceProvider();

            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password);

            byte[] byteHash = hashValue.ComputeHash(bytes);

            hashValue.Clear();

            return (Convert.ToBase64String(byteHash));
        }

    }// fin clase
}
