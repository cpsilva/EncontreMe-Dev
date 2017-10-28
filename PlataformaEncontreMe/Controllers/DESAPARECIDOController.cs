using PlataformaEncontreMe.Models;
using PlataformaEncontreMe.ViewModel;
using PlataformaEncontreMe.ViewModel.Map;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace PlataformaEncontreMe.Controllers
{
    public class DESAPARECIDOController : ApiController
    {
        private ENCONTREMEEntities db = new ENCONTREMEEntities();

        // GET: api/DESAPARECIDO
        public IQueryable<DESAPARECIDO> Get()
        {
            return db.DESAPARECIDO;
        }

        // GET: api/DESAPARECIDO/5
        [ResponseType(typeof(DESAPARECIDOViewModel))]
        public IHttpActionResult Get(int id)
        {
            DESAPARECIDO dESAPARECIDO = db.DESAPARECIDO.Find(id);
            if (dESAPARECIDO == null)
            {
                return NotFound();
            }

            return Ok(dESAPARECIDO.MapFromDb());
        }

        // PUT: api/DESAPARECIDO/5
        [ResponseType(typeof(DESAPARECIDOViewModel))]
        public IHttpActionResult Put(int id, DESAPARECIDOViewModel dESAPARECIDO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dESAPARECIDO.COD_DESAPARECIDO)
            {
                return BadRequest();
            }

            DESAPARECIDO desFromDb = db.DESAPARECIDO.Find(id);

            dESAPARECIDO.MaptoDb(desFromDb);

            db.Entry(desFromDb).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DESAPARECIDOExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/DESAPARECIDO
        [ResponseType(typeof(DESAPARECIDO))]
        public IHttpActionResult Post([FromBody] DESAPARECIDOViewModel dESAPARECIDO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.DESAPARECIDO.Add(dESAPARECIDO.Map());
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dESAPARECIDO.COD_DESAPARECIDO }, dESAPARECIDO);
        }

        // DELETE: api/DESAPARECIDO/5
        [ResponseType(typeof(DESAPARECIDOViewModel))]
        public IHttpActionResult Delete(int id)
        {
            DESAPARECIDO dESAPARECIDO = db.DESAPARECIDO.Find(id);
            if (dESAPARECIDO == null)
            {
                return NotFound();
            }

            db.DESAPARECIDO.Remove(dESAPARECIDO);
            db.SaveChanges();

            return Ok(dESAPARECIDO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DESAPARECIDOExists(int id)
        {
            return db.DESAPARECIDO.Count(e => e.COD_DESAPARECIDO == id) > 0;
        }

    }
}