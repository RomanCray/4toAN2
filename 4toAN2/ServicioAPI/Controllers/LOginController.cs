using ServicioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ServicioAPI.Controllers
{
    public class LOginController : ApiController
    {
        private Base_Matriculacion_VehiculosEntities db = new Base_Matriculacion_VehiculosEntities();

        // GET: api/USUARIOs/5
     //   [ResponseType(typeof(Login))]
     [HttpPost]
        public IHttpActionResult loginXUser(Login login)
        {
            USUARIO uSUARIO = db.USUARIO.Where(data => data.us_estatus.Equals("A")
                                && data.us_correo.Equals(login.Username)
                                && data.us_password.Equals(login.Password)).FirstOrDefault();
            if (uSUARIO == null)
            {
                return NotFound();
            }

            return Ok(uSUARIO);
        }
    }
}
