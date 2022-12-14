using DAL.Interfaces;
using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Net.Mail;
using System.Net;
using Entities.Utilities;

namespace DAL.Implementations
{
    public class AlquilerDALImpl : IAlquilerDAL
    {
        rabdContext rabdContext;

        public AlquilerDALImpl()
        {
            rabdContext = new rabdContext();
        }

        public AlquilerDALImpl(rabdContext rabdContext)
        {
            this.rabdContext = rabdContext;
        }

        public bool Add(Alquiler entity)
        {
            throw new NotImplementedException();
        }

        public bool AddAlquilerEnvio(AlquilerEnvio entity)
        {
            try
            {
                string SQL = "[dbo].[SP_Agregar_Alquiler_Envio_Facturacion] @IDUsuario, @AlquilerEnvioXML";
                var param = new SqlParameter[]
                {
                        new SqlParameter()
                        {
                            ParameterName="@IDUsuario",
                            SqlDbType = System.Data.SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                            Value= entity.alquiler.IdUsuario
                        },
                        new SqlParameter("@AlquilerEnvioXML", SqlDbType.Xml)
                        {
                             Value = new SqlXml(new XmlTextReader(CrearXMLAlquier(entity).InnerXml,XmlNodeType.Document, null))
                        }

                };
                rabdContext.Database.ExecuteSqlRaw(SQL, param);
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddRange(IEnumerable<Alquiler> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Alquiler> Find(Expression<Func<Alquiler, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Alquiler Get(int id)
        {
            try
            {
                Alquiler alquiler;
                using (var unidad = new UnidadDeTrabajo<Alquiler>(rabdContext))
                {
                    alquiler = unidad.genericoDAL.Get(id);
                }

                return alquiler;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Alquiler> Get()
        {
            try
            {
                IEnumerable<Alquiler> alquileres;

                using (var unidad = new UnidadDeTrabajo<Alquiler>(rabdContext))
                {
                    alquileres = unidad.genericoDAL.GetAll();
                }
                return alquileres.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Alquiler> GetAll()
        {
            try
            {
                IEnumerable<Alquiler> alquileres;

                using (var unidad = new UnidadDeTrabajo<Alquiler>(rabdContext))
                {
                    alquileres = unidad.genericoDAL.GetAll();
                }

                return alquileres;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Alquiler entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Alquiler>(rabdContext);
                unidad.genericoDAL.Remove(entity);
                return unidad.Complete();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RemoveRange(IEnumerable<Alquiler> entities)
        {
            throw new NotImplementedException();
        }

        public Alquiler SingleOrDefault(Expression<Func<Alquiler, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Alquiler entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Alquiler>(rabdContext);
                unidad.genericoDAL.Update(entity);
                return unidad.Complete();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private XmlDocument CrearXMLAlquier(AlquilerEnvio? model)
        {
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                string difFechas = (model.alquiler.FechaDevolucion - model.alquiler.FechaAlquiler).Days.ToString();

                string montoAlquiler = (decimal.Parse(difFechas) * model.auto.PrecioDia).ToString();
                string montoPago = "";

                if (model.PrimerPago == 0)
                    montoPago = montoAlquiler;
                else
                    montoPago = model.PrimerPago.ToString();

                using (XmlWriter writer = xmlDocument.CreateNavigator().AppendChild())
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Alquileres");
                    writer.WriteStartElement("Alquiler");
                    writer.WriteElementString("FechaAlquiler", model.alquiler.FechaAlquiler.ToString("yyyy-MM-dd HH:mm:ss"));
                    writer.WriteElementString("FechaDevolucion", model.alquiler.FechaDevolucion.ToString("yyyy-MM-dd HH:mm:ss"));
                    writer.WriteElementString("IdAuto", model.auto.IdAuto.ToString());
                    writer.WriteElementString("DetalleDireccion", model.envio.DetalleDireccion.ToString());
                    writer.WriteElementString("PrecioBase", model.envio.PrecioBase.ToString());
                    writer.WriteElementString("IdConductor", "2");
                    writer.WriteElementString("MontoAlquiler", montoAlquiler.ToString());
                    writer.WriteElementString("MontoPago", montoPago.ToString());
                    writer.WriteEndElement();
                    writer.WriteEndDocument();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return xmlDocument;
        }

        public async Task<bool> EnviarCorreoFacturaAsync(AlquilerEnvio? model)
        {
            try
            {
                string difFechas = (model.alquiler.FechaDevolucion - model.alquiler.FechaAlquiler).Days.ToString();

                string montoAlquiler = (decimal.Parse(difFechas) * model.auto.PrecioDia).ToString();
                string montoPago = "";

                if (model.PrimerPago == 0)
                    montoPago = montoAlquiler;
                else
                    montoPago = model.PrimerPago.ToString();

                //SE DEBE OBTENER DE LAS VARIABLES DE SESIÓN Y NO DE ALQUILER
                //model.alquiler.IdUsuario = 2;

                UsuarioDALImpl usuarioDalImplAux = new UsuarioDALImpl();
                Usuario entUsuario = usuarioDalImplAux.Get(model.alquiler.IdUsuario);
                string body = string.Empty;
                using (var reader = new System.IO.StreamReader("C:\\_emailTemplate.cshtml"))
                {
                    string readFile = reader.ReadToEnd();
                    string StrContent = string.Empty;
                    StrContent = readFile;
                    StrContent = StrContent.Replace("{Nombre}", entUsuario.Nombre + " " + entUsuario.Apellido);
                    StrContent = StrContent.Replace("{Detalle_Direccion}", model.envio.DetalleDireccion.ToString());
                    StrContent = StrContent.Replace("{Fecha_Inicio}", model.alquiler.FechaAlquiler.ToString());
                    StrContent = StrContent.Replace("{Fecha_Devolucion}", model.alquiler.FechaDevolucion.ToString());
                    StrContent = StrContent.Replace("{Fecha_Envio}", model.alquiler.FechaAlquiler.AddHours(-3).ToString());
                    StrContent = StrContent.Replace("{Precio_Vehiculo}", "₡" + model.auto.PrecioDia.ToString());
                    StrContent = StrContent.Replace("{Vehículo}", model.auto.Marca + " " + model.auto.Modelo + " " + model.auto.Anno);
                    StrContent = StrContent.Replace("{Precio_Vehiculo}", model.auto.PrecioDia.ToString());
                    StrContent = StrContent.Replace("{Placa}", model.auto.Placa.ToString());
                    StrContent = StrContent.Replace("{TotalAlquiler}", "₡" + montoAlquiler.ToString());
                    StrContent = StrContent.Replace("{TotalCancelado}", "₡" + montoPago.ToString());

                    body = StrContent.ToString();
                }
                await SendEmailAsync(body, entUsuario.Correo.ToString());
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public Task SendEmailAsync(string body, string emailTo)
        {
            try
            {
                System.Net.Mail.SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(Util.UIDEmail, Util.PWDEmail);
                var mail = new System.Net.Mail.MailMessage(Util.UIDEmail, emailTo);

                mail.From = new MailAddress("no-reply-rawcr@gmail.com", "RAW Rent a Car Costa Rica"); //Set display name of the user
                mail.Subject = "RAW Rent a Car - Recibo de alquiler";
                mail.Body = body;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.Normal;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mail.ReplyToList.Add("no-reply-rawcr@gmail.com");

                return client.SendMailAsync(mail);

            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }
    }
}
