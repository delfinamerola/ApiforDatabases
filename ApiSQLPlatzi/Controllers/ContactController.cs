using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ApiSQLPlatzi.Models;
using System;




namespace ApiSQLPlatzi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : Controller
    {
        private ContactsContext contactsContext;

        public ContactController(ContactsContext context)
        {
            contactsContext = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contacts>> Get()
        {
            return contactsContext.ContactSet.ToList();
        }
        ~ContactController()
        {
            contactsContext.Dispose();
        }
         // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Contacts> Get(int id)
        {
            var selectedContact = (from c in contactsContext.ContactSet 
                                  where c.Identificador == id
                                  select c).FirstOrDefault();
            return selectedContact;
        }
    
    
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

    
        // POST api/values/5
        [HttpPost]
        public IActionResult Post([FromBody] Contacts value)
        {
            Contacts newContact = value;
            contactsContext.ContactSet.Add(newContact);
            contactsContext.SaveChanges();
            return Ok("Tu contacto ha sido agregado");
        }
    
        // DELETE api/values/5
        [HttpDelete("{id")]
        public void Delete(int id)
        {

        }
    }
}