using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BE;
using BL;
using GUI.Data;
using GUI.Models;

namespace GUI.Controllers
{
    public class PrescriptionController : Controller
    {
        private GUIContext db = new GUIContext();


        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PD pd = new PD();
            PatientModel patientModel = new PatientModel();
            pd.patients = patientModel.GetPatients();

            DoctorAdminLogic bl = new DoctorAdminLogic();
            int IdD = (from x in bl.listDoctors() where x.IdP == id select x.Id).FirstOrDefault();
            DoctorModel doctor = new DoctorModel();
            pd.doctor = doctor.GetDoctor(IdD);
            return View(pd);
        }
        public ActionResult Note()
        {
            Note n = new Note();
            n.notice = "You did it";
            return View(n);
        }

        public ActionResult PatientHistory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PDP patientPrescription = new PDP();
            PatientModel patient = new PatientModel();
            patientPrescription.patient = patient.GetPatient((int)id);
            PrescriptionAdminLogic bl = new PrescriptionAdminLogic();
            PatientAdminLogic bl2 = new PatientAdminLogic();
            long idp = (from x in bl2.listPatient() where x.Id == id select x.IdP).FirstOrDefault();
            List<Prescription> list = (from x in bl.listPrescription() where x.patientId == idp select x).ToList();
            patientPrescription.prescriptionList = list;
            return View(patientPrescription);
        }

        // GET: Prescription/Create
        public ActionResult Create(int? id, int? idD)
        {
            if (id == null || idD == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrescriptionD pd = new PrescriptionD();
            PatientModel p = new PatientModel();
            DoctorModel d = new DoctorModel();
            pd.patient = p.GetPatient((int)id);
            pd.doctor = d.GetDoctor((int)idD);
            if (pd == null)
            {
                return HttpNotFound();
            }
            return View(pd);
        }

        // POST: Prescription/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,patientId,doctorId,medicineName,Start,End,notes")] PrescriptionViewModel prescriptionViewModel)
        {
            if (ModelState.IsValid)
            {
                db.PrescriptionViewModels.Add(prescriptionViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prescriptionViewModel);
        }
    }
}
