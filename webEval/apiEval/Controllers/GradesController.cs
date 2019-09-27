using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using apiEval.Models;

namespace apiEval.Controllers
{
    public class GradesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Grades
        public IQueryable<Grade> GetGrades()
        {
            return db.Grades;
        }

        // GET: api/Grades/5
        [ResponseType(typeof(Grade))]
        public IHttpActionResult GetGrade(string id)
        {
            Grade grade = db.Grades.Find(id);
            if (grade == null)
            {
                return NotFound();
            }

            return Ok(grade);
        }

        // PUT: api/Grades/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGrade(string id, Grade grade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grade.Subject)
            {
                return BadRequest();
            }

            db.Entry(grade).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeExists(id))
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

        // POST: api/Grades
        [ResponseType(typeof(Grade))]
        public IHttpActionResult PostGrade(Grade grade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Grades.Add(grade);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GradeExists(grade.Subject))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = grade.Subject }, grade);
        }

        // DELETE: api/Grades/5
        [ResponseType(typeof(Grade))]
        public IHttpActionResult DeleteGrade(string id)
        {
            Grade grade = db.Grades.Find(id);
            if (grade == null)
            {
                return NotFound();
            }

            db.Grades.Remove(grade);
            db.SaveChanges();

            return Ok(grade);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GradeExists(string id)
        {
            return db.Grades.Count(e => e.Subject == id) > 0;
        }
    }
}