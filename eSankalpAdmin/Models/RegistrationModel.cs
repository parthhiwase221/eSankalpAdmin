using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eSankalpAdmin.Data;

namespace eSankalpAdmin.Models
{
    public class RegistrationModel
    {
        public int RegId { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Education { get; set; }
        public decimal Percentage { get; set; }
        public string Service { get; set; }
        public string Technology { get; set; }
        public string Office { get; set; }
        public string College { get; set; }
        public string Address { get; set; }



        public string SaveRegistration(RegistrationModel model)
        {
            var Message = " Data Not Found";
            esankal1_esankalpEntities db = new esankal1_esankalpEntities();
            if (model.RegId == 0)
            {
                var data = new InternshipRegistration()
                {
                    RegId = model.RegId,
                    Name = model.Name,
                    MobileNo = model.MobileNo,
                    Email = model.Email,
                    Education = model.Education,
                    Percentage = model.Percentage,
                    Service = model.Service,
                    Technology = model.Technology,
                    Office = model.Office,
                    College = model.College,
                    Address = model.Address,
                };
                db.InternshipRegistrations.Add(data);
                db.SaveChanges();
                Message = "User Data Added Sucessfully";
            }
            else
            {
                var regdata = db.InternshipRegistrations.Where(r => r.RegId == model.RegId).FirstOrDefault();
                if(regdata != null)
                {
                    regdata.RegId = model.RegId;
                    regdata.Name = model.Name;
                    regdata.MobileNo = model.MobileNo;
                    regdata.Email = model.Email;
                    regdata.Education = model.Education;
                    regdata.Percentage = model.Percentage;
                    regdata.Service = model.Service;
                    regdata.Technology = model.Technology;
                    regdata.Office = model.Office;
                    regdata.College = model.College;
                    regdata.Address = model.Address;



                }
                db.SaveChanges();
                Message = "User Data Updated";
            }
            return Message;
        }


        public List<RegistrationModel> GetReglist()
        {
            esankal1_esankalpEntities db = new esankal1_esankalpEntities();
            List<RegistrationModel> LstCategory = new List<RegistrationModel>();
            var Demosd = db.InternshipRegistrations.ToList();
            if (Demosd != null)
            {
                foreach (var Category in Demosd)
                {
                    LstCategory.Add(new RegistrationModel()
                    {
                        RegId = Category.RegId,
                        Name = Category.Name,
                        MobileNo = Category.MobileNo,
                        Email = Category.Email,
                        Education = Category.Education,
                        Percentage = Category.Percentage,
                        Service = Category.Service,
                        Technology = Category.Technology,
                        Office = Category.Office,
                        College = Category.College,
                        Address = Category.Address,
                    });


                }
            }
            return LstCategory;
        }


        public string deletereg(int ID)
        {

            string Message = "";
            esankal1_esankalpEntities db = new esankal1_esankalpEntities();
            var deleteRecord = db.InternshipRegistrations.Where(p => p.RegId == ID).FirstOrDefault();
            if (deleteRecord != null)
            {
                db.InternshipRegistrations.Remove(deleteRecord);
                Message = "successfully Deleted";
            }
            else
            {
                Message = "Record Not Found";
            }
            db.SaveChanges();
            return Message;
        }

        public RegistrationModel Getdetails(int RegId)
        {

            esankal1_esankalpEntities db = new esankal1_esankalpEntities();
            RegistrationModel registrationModel = new RegistrationModel();
            var data = db.Registrations.Where(r => r.RegId == RegId).FirstOrDefault();

            if (data != null)
            {

                registrationModel.RegId = data.RegId;
                registrationModel.Name = data.Name;
                registrationModel.MobileNo = data.MobileNo;
                registrationModel.Email = data.Email;
                registrationModel.Education = data.Education;
                registrationModel.Percentage = data.Percentage;
                registrationModel.Service = data.Service;
                registrationModel.Technology = data.Technology;
                registrationModel.Office = data.Office;
                registrationModel.College = data.College;
                registrationModel.Address = data.Address;
            }

            return registrationModel;
        }
    }
}