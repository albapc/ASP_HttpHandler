using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JpegHandler.App_Code
{
    // Para evitar el Error 500.23 al ejecutar:
    // Cambiar el pipeline a modo clásico
    // Ver: https://stackoverflow.com/questions/5914744/force-iis-express-to-classic-pipeline-mode


    // URLs a ejecutar: 
    /* Para obtener la img del koala:
     * localhost:XXXX/Images/koala.jpg
     * 
     * Para obtener la img de la medusa:
     * localhost:XXXX/Images/jellyfish.jpg
     * 
     * Para lanzar el "not found":
     * localhost:XXXX/Images/XXXX.jpg (imagen que no esté almacenada en la carpeta Images)
     */

    public class JpegHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            // set the MIME type
            context.Response.ContentType = "image/jpeg";

            HttpRequest request = context.Request;
            HttpResponse response = context.Response;

            if(request.RawUrl.ToLower().Contains("jellyfish"))
            {
                response.TransmitFile(request.PhysicalApplicationPath + "/Images/Jellyfish.jpg");
            }
            else if (request.RawUrl.ToLower().Contains("koala"))
            {
                response.TransmitFile(request.PhysicalApplicationPath + "/Images/Koala.jpg");
            }
            else
            {
                response.Write("File not found");
            }


        }
    }
}
 