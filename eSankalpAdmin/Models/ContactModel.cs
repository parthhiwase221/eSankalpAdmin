using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eSankalpAdmin.Data;

namespace eSankalpAdmin.Models
{
    public class ContactModel
    {

        public int Id { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string mob { get; set; }
        public string msg { get; set; }


        public List<ContactModel> GetContactlist()
        {
            esankal1_esankalpEntities db = new esankal1_esankalpEntities();
            List<ContactModel> LstCategory = new List<ContactModel>();
            var Demosd = db.contacts.ToList();
            if (Demosd != null)
            {
                foreach (var Category in Demosd)
                {
                    LstCategory.Add(new ContactModel()
                    {
                        Id = Category.Id,
                        fullname = Category.fullname,
                        email = Category.email,
                        mob = Category.mob,
                        msg = Category.msg,
                      
                    });


                }
            }
            return LstCategory;
        }


        public string deletereg(int ID)
        {
            string Message = "";
            esankal1_esankalpEntities db = new esankal1_esankalpEntities();
            var deleteRecord = db.contacts.Where(p => p.Id == ID).FirstOrDefault();
            if (deleteRecord != null)
            {
                db.contacts.Remove(deleteRecord);
                Message = "successfully Deleted";
            }
            else
            {
                Message = "Record Not Found";
            }
            db.SaveChanges();
            return Message;
        }
    }
}