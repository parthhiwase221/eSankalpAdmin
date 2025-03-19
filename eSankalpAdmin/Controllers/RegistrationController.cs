using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eSankalpAdmin.Models;

namespace eSankalpAdmin.Controllers
{
    [Authorize]
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult detailIndex()
        {
            return View();
        }

        public ActionResult SaveRegistration(RegistrationModel model)
        {
            try
            {
                return Json(new { model = (new RegistrationModel().SaveRegistration(model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }
        public ActionResult GetReglist()
        {
            try
            {
                return Json(new { model = (new RegistrationModel().GetReglist()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }
        public ActionResult deletereg(int ID)
        {
            try
            {
                return Json(new { model = (new RegistrationModel().deletereg(ID)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }
        public ActionResult Getdetails(int RegId)
        {
            try
            {
                return Json(new { model = (new RegistrationModel().Getdetails(RegId)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}