using System;
using System.Net;
using System.Net.Mail;

namespace template01
{
    public class Smtp : IDisposable
    {
        private string _servidor;
        private string _usuario;
        private string _contraseña;
        private int _puerto;

        private string _errores;
        public string Errores { get { return _errores; } }

        public bool ActivarSsl { get; set; }
        public bool UsarCredencialesDefecto { get; set; }

        public Smtp(string servidor, string usuario, string contraseña, int puerto)
        {
            _servidor = servidor;
            _usuario = usuario;
            _contraseña = contraseña;
            _puerto = puerto;


            _errores = null;
        }

        public bool Enviar(string destinatarios, string asunto, string mensaje, string datosAdjuntos)
        {
            bool resultado = false;
            SmtpClient cliente = new SmtpClient();
            MailMessage email = new MailMessage();

            try
            {
                ValidaCadena(destinatarios, "Destinatarios");
                ValidaCadena(asunto, "Asunto");
                ValidaCadena(mensaje, "Mensaje");

                string[] destinatariosLista = destinatarios.Replace(";", ",").Split(',');
                foreach (string destinatario in destinatariosLista)
                    email.To.Add(destinatario);

                email.From = new MailAddress(_usuario);
                email.Subject = asunto;
                email.Body =mensaje;
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;

                cliente.Host =_servidor;
                cliente.Port = _puerto;
                cliente.EnableSsl = ActivarSsl;
                cliente.UseDefaultCredentials = UsarCredencialesDefecto;
                cliente.Credentials = new NetworkCredential(_usuario,_contraseña);
                cliente.Send(email);                

                resultado = true;
                _errores = string.Empty;
            }
            catch (Exception ex)
            {
                _errores = ex.ToString();
            }
            finally
            {
                LiberarSmtp(cliente, email);
            }
            return resultado;
        }
      
        private void ValidaCadena(string cadena, string campoNombre)
        {
            if (string.IsNullOrWhiteSpace(cadena))
                throw new Exception($"El parámetro {campoNombre} no es válido para el proceso.");
        }

        private void LiberarSmtp(SmtpClient cliente, MailMessage email)
        {
            if (email != null)
            {
                email.Dispose();
                email = null;
            }
            if (cliente != null)
            {
                cliente.Dispose();
                cliente = null;
            }
        }

        public void Dispose()
        {
            _servidor = null;
            _usuario = null;
            _contraseña = null;
            _puerto = 0;
            _errores = null;
        }
    }
}
