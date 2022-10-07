using CapaEntidades.Models;
using CapaEntidades.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CapaEntidades.Helpers
{
    public class MailHelper
    {
        public static bool Email_comprobation(string email)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
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

        public string SendEmailFactura(string correo_destino, Ventas venta, List<Detalle_pedido> detalles, DataTable dtDetallePago)
        {
            string rpta = "OK";
            try
            {
                string emailFrom = ConfigEmail.Default.Email_reportes;
                string emailTo = correo_destino;
                string smtpServer = ConfigEmail.Default.Server_smtp_reportes;
                int smtpPort = Convert.ToInt32(ConfigEmail.Default.Port_server_reportes);
                string emailPass = ConfigEmail.Default.Password_email_reportes;
                string HTMLTemplateMail = this.templateEmail();
                string nameBusiness = "Chill Beer";
                string telBusiness = "3214632760";
                string direccionBusiness = "Milán";
                string cityCountry = "Manizales, Colombia";

                if (HTMLTemplateMail == null)
                {
                    throw new Exception("No se envió el correo, no se encontró la plantilla");
                }

                StringBuilder headerEmail = new StringBuilder();
                StringBuilder contentEmail = new StringBuilder();

                headerEmail.Append("<h4>");
                headerEmail.Append("Compra realizada en Chill Beer, Milán. A continuación se detalla la factura: ");
                headerEmail.Append("</h4>");

                contentEmail.Append("<table style='font-family: arial; font-size: 14px; border: 1px solid silver;' cellpadding='7' cellspacing='7'>");
                contentEmail.Append("<tbody>");

                contentEmail.Append("<tr>");
                contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'><strong>Documento equivalente</strong></td>");
                contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'>" + venta.Id_venta + "</td>");
                contentEmail.Append("</tr>");
                contentEmail.Append("<tr>");
                contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'><strong>Datos cliente</strong></td>");
                contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'>" + venta.Pedido.Cliente.Nombre_cliente + "</td>");
                contentEmail.Append("</tr>");              
                contentEmail.Append("<tr>");
                contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'><strong>Fecha</strong></td>");
                contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'>" + venta.Fecha_venta.ToLongDateString() + "</td>");
                contentEmail.Append("</tr>");
                contentEmail.Append("<tr>");
                contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'><strong>Hora</strong></td>");
                contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'>" + venta.Fecha_venta.Add(venta.Hora_venta).ToLongTimeString() + "</td>");
                contentEmail.Append("</tr>");

                if (venta.Total_parcial != 0)
                {
                    //contentEmail.Append("<tr>");
                    //contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'><strong>Propina</strong></td>");
                    //contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'>" + venta.Subtotal.ToString("C") + "</td>");
                    //contentEmail.Append("</tr>");
                }

                if (venta.Propina != 0)
                {
                    contentEmail.Append("<tr>");
                    contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'><strong>Propina</strong></td>");
                    contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'>" + venta.Propina.ToString("C") + "</td>");
                    contentEmail.Append("</tr>");
                }

                if (venta.Descuento != 0)
                {
                    contentEmail.Append("<tr>");
                    contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'><strong>Propina</strong></td>");
                    contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'>" + venta.Descuento.ToString("P") + "</td>");
                    contentEmail.Append("</tr>");
                }

                if (!string.IsNullOrEmpty(venta.Bono_cupon))
                {
                    contentEmail.Append("<tr>");
                    contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'><strong>Bono o cupón</strong></td>");
                    contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'>" + venta.Bono_cupon + "</td>");
                    contentEmail.Append("</tr>");
                }

                if (venta.Desechables != 0)
                {
                    contentEmail.Append("<tr>");
                    contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'><strong>Desechables</strong></td>");
                    contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'>" + venta.Desechables.ToString("C") + "</td>");
                    contentEmail.Append("</tr>");
                }

                if (venta.Domicilio != 0)
                {
                    contentEmail.Append("<tr>");
                    contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'><strong>Domicilio</strong></td>");
                    contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'>" + venta.Domicilio.ToString("C") + "</td>");
                    contentEmail.Append("</tr>");
                }

                if (venta.Subtotal != 0)
                {
                    //contentEmail.Append("<tr>");
                    //contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'><strong>Subtotal</strong></td>");
                    //contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'>" + venta.Subtotal.ToString("C") + "</td>");
                    //contentEmail.Append("</tr>");
                }

                if (venta.Total_final != 0)
                {
                    contentEmail.Append("<tr>");
                    contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'><strong>Total</strong></td>");
                    contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'>" + venta.Total_final.ToString("C") + "</td>");
                    contentEmail.Append("</tr>");
                }

                if (detalles != null)
                {
                    contentEmail.Append("<tr>");
                    contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'><strong>Cantidad de productos</strong></td>");
                    contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'>" + detalles.Count + "</td>");
                    contentEmail.Append("</tr>");
                }

                contentEmail.Append("</tbody>");
                contentEmail.Append("</table>");

                contentEmail.Append("<br />");
                contentEmail.Append("<br />");

                if (detalles != null)
                {
                    contentEmail.Append("<table style='font-family: arial; font-size: 12px; border: 1px solid silver;' cellpadding='7' cellspacing='7'>");
                    contentEmail.Append("<tbody>");
                    contentEmail.Append("<tr>");
                    contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'><strong>Nombre</strong></td>");
                    contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'><strong>Precio</strong></td>");
                    contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'><strong>Cantidad</strong></td>");
                    contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'><strong>Total</strong></td>");
                    contentEmail.Append("</tr>");

                    foreach (Detalle_pedido detalle in detalles)
                    {
                        contentEmail.Append("<tr>");
                        contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'>" + detalle.Producto.Nombre_producto + "</td>");
                        contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'>" + detalle.Precio.ToString("C") + "</td>");
                        contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'>" + detalle.Cantidad + "</td>");
                        contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'>" + detalle.Precio_total.ToString("C") + "</td>");
                        contentEmail.Append("</tr>");
                    }
                }

                //contentEmail.Append("<br />");
                //contentEmail.Append("<br />");

                //contentEmail.Append("<table style='font-family: arial; font-size: 12px; border: 1px solid silver;' cellpadding='7' cellspacing='7'>");
                //contentEmail.Append("<tbody>");
                //contentEmail.Append("<tr>");
                //contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'>Observaciones</td>");
                //contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'>" + observaciones + "</td>");
                //contentEmail.Append("</tr>");
                //contentEmail.Append("</tbody>");
                //contentEmail.Append("</table>");

                contentEmail.Append("<br />");
                contentEmail.Append("<br />");

                contentEmail.Append("<h4>");
                contentEmail.Append("Detalle de pago");
                contentEmail.Append("</h4>");

                contentEmail.Append("<br />");
                contentEmail.Append("<br />");

                if (dtDetallePago != null)
                {
                    contentEmail.Append("<table style='font-family: arial; font-size: 12px; border: 1px solid silver;' cellpadding='7' cellspacing='7'>");
                    contentEmail.Append("<tbody>");
                    contentEmail.Append("<tr>");
                    contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'>Método de pago</td>");
                    contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'>Valor</td>");
                    contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'>Observaciones</td>");
                    contentEmail.Append("</tr>");

                    foreach (DataRow row in dtDetallePago.Rows)
                    {
                        contentEmail.Append("<tr>");
                        contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'>" + row["Pago"] + "</td>");
                        contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'>" + row["Valor_pago"] + "</td>");
                        contentEmail.Append("   <td  style='border: 1px solid silver;text-align:center;'>" + row["Observaciones"] + "</td>");
                        contentEmail.Append("</tr>");
                    }
                    contentEmail.Append("</tbody>");
                    contentEmail.Append("</table>");
                }

                contentEmail.Append("</tbody>");
                contentEmail.Append("</table>");
                contentEmail.Append("<br />");
                contentEmail.Append("<br />");

                headerEmail.Append("<br />");
                headerEmail.Append("<br />");

                HTMLTemplateMail = concatTemplateEmailWithHeaderBody(HTMLTemplateMail, headerEmail.ToString(), contentEmail.ToString(),
                    nameBusiness, telBusiness, direccionBusiness, cityCountry);

                MailMessage mail = new MailMessage(emailFrom, correo_destino)
                {
                    From = new MailAddress(emailFrom, "Comprobante Chill Beer", Encoding.UTF8),
                    IsBodyHtml = true
                };
                string fecha = DateTime.Now.ToString("G");
                mail.Subject = "Comprobante de compra Chill Beer" + " | " + fecha;

                mail.Body = HTMLTemplateMail;
                //mail.Bcc.Add(ConfigurationManager.AppSettings["eMailRetail"].ToString());

                SmtpClient client = new SmtpClient(smtpServer);
                client.Credentials = new System.Net.NetworkCredential(emailFrom, emailPass);
                client.Port = smtpPort;
                client.EnableSsl = true;
                client.Send(mail);
                return rpta;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                return rpta;
            }
        }

        private string concatTemplateEmailWithHeaderBody(string HTMLTemplate, string header, string body,
            string name_business, string tel_business, string direccion_business, string city_country)
        {
            try
            {
                HTMLTemplate = HTMLTemplate.Replace(@"#_HEADER_MAIL", header);
                HTMLTemplate = HTMLTemplate.Replace(@"#_BODY_MAIL", body);
                HTMLTemplate = HTMLTemplate.Replace(@"#_NAME_BUSINESS", name_business);
                HTMLTemplate = HTMLTemplate.Replace(@"#_TEL_BUSINESS", tel_business);
                HTMLTemplate = HTMLTemplate.Replace(@"#_DIRECCION_BUSINESS", direccion_business);
                HTMLTemplate = HTMLTemplate.Replace(@"#_CITY_COUNTRY", city_country);
            }
            catch (Exception)
            {
                return HTMLTemplate;
            }
            return HTMLTemplate;
        }

        private string templateEmail()
        {
            return Resources.templateMail;
        }
    }
}
