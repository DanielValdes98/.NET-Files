using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using static Google.Apis.Gmail.v1.GmailService;
using ProjectDemo.Models;
using System.Security.Cryptography;

namespace ProjectDemo.Controllers
{
    public class GmailController : Controller
    {
        // GET: Gmail
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarThreads()
        {
            Response<ListThreadsResponse> response = new Response<ListThreadsResponse>();

            AuthorizationResult gmailService = Authorization.GetGmailService();

            if (gmailService.service != null)
            {
                var userId = "me";

                // Ejemplo de parámetros para el método ListThreads
                ListThreadsResponse responseThreads = gmailService.service.Users.Threads.List(userId).Execute();

                response.status = true;
                response.value = responseThreads;
                response.msg = "Threads List success";
            }
            else
            {
                response.status = false;
                response.value = null;
                response.msg = "Gmail service not available.";
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }

    public class Authorization
    {
        // Crea y retorna un servicio de Gmail autorizado usando las credenciales de usuario
        public static AuthorizationResult GetGmailService()
        {
            var result = new AuthorizationResult();

            try
            {
                UserCredential credential;

                // Se lee el archivo client_secrets.json con las credenciales de la aplicación
                string path = HttpContext.Current.Server.MapPath("~/App_Data/client_secrets.json");

                // Se crea el flujo de autorización
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read)) 
                {
                    var clientsecrets = GoogleClientSecrets.FromStream(stream).Secrets; // Accede a la propiedad Secrets del objeto GoogleClientSecrets
                    var scope = new[] { Scope.GmailReadonly }; // Se define el alcance de la aplicación (solo lectura)

                    // El archivo tokens.json almacena los tokens de acceso y actualización del usuario.
                    // Se crea automáticamente cuando el flujo de autorización se completa por primera vez
                    string credPath = HttpContext.Current.Server.MapPath("~/App_Data/tokens.json");

                    // Obtiene la ruta al archivo que contiene los tokens de acceso almacenados
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                       clientsecrets,
                       scope,
                       "user", // Definir el usuario (no aplica en la mayoría de los casos)
                       CancellationToken.None,// No se utiliza ningún token de cancelación
                       new FileDataStore(credPath, true)) // Utiliza un almacén de datos de archivos para tokens persistentes
                        .Result; // Espera a que se complete la operación asincrónica y obtiene las credenciales del usuario
                }

                // Crea el servicio de Gmail 
                var service = new GmailService(new BaseClientService.Initializer() // Crea el objeto
                {
                    HttpClientInitializer = credential, // Utiliza las credenciales de usuario obtenidas para la autenticación
                    ApplicationName = "Threads API Sample", // Nombre de la aplicación para su identificación
                });

                result.service = service;
                result.Message = "Gmail service available.";
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

    }
}