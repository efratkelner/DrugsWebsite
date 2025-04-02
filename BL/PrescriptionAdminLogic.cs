using BE;
using DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BL
{
    public class PrescriptionAdminLogic
    {
        ReadWriteDrugs dal4 = new ReadWriteDrugs();
        ReadWritePrescription dal1 = new ReadWritePrescription();
        public string AddPrescription(string medicine, string notes, long doctor, long patient, DateTime start, DateTime end)
        {

            ReadWritePatient dal2 = new ReadWritePatient();
            ReadWriteDoctors dal3 = new ReadWriteDoctors();
            string result = string.Empty;
           if ((from x in dal2.PatientList() where x.IdP == patient select x).FirstOrDefault() == null)
                throw new Exception("The ID number of the patient dosn't exist in the system");
            if ((from x in dal3.DoctorsList() where x.IdP == doctor select x).FirstOrDefault() == null)
                throw new Exception("The ID number of the doctor dosn't exist in the system");
            if ((from x in dal4.medicineList() where x.Name == medicine select x).FirstOrDefault() == null)
                throw new Exception("The is no such medicine in the system");
            if (start > end)
                throw new Exception("Start date should be before end date");
            if (start < DateTime.Now && (start.Day != DateTime.Now.Day))
                throw new Exception("not correct date");
            try
            {
                result = checkDrugs(medicine, patient, start, end);
            }
            catch
            {
                throw new Exception("The severity is high" + result);
            }

            dal1.AddPrescription(medicine, notes, doctor, patient, start, end);
            return result;
        }

        public List<Prescription> listPrescription()
        {
            return dal1.PrescriptionList();
        }


        private string checkDrugs(string medicine, long id, DateTime start, DateTime end)
        {

            string ndc = (from x in dal4.medicineList() where x.Name == medicine select x.Ndc).FirstOrDefault();
            string siteContent = string.Empty;
            string url = "https://rxnav.nlm.nih.gov/REST/rxcui?idtype=NDC&id=" + ndc;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())  // Go query google
            using (Stream responseStream = response.GetResponseStream())               // Load the response stream
            using (StreamReader streamReader = new StreamReader(responseStream))       // Load the stream reader to read the response
            {
                siteContent = streamReader.ReadToEnd(); // Read the entire response and store it in the siteContent variable
            }
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(siteContent);
            XmlNodeList xnList = doc.SelectNodes("/rxnormdata/idGroup");
            string rxcui = string.Empty;
            string tmp2 = string.Empty;
            if (xnList[0]["rxnormId"] != null)//the drug has rxcui code
            {
                rxcui = xnList[0]["rxnormId"].InnerText;
                //find all the other drugs the patient use
                List<string> rxcuis = new List<string>();
                List<Prescription> allPrescription = (from x in dal1.PrescriptionList() where x.patientId == id select x).ToList();
                foreach (Prescription p in allPrescription)
                {
                    if (!((p.Start < start && p.End < start) || (p.Start > end)))//משתמש בתרופה אחרת במקביל לתרופה החדשה
                    {
                        Medicine m = (from x in dal4.medicineList() where x.Name == p.medicineName select x).First();
                        url = "https://rxnav.nlm.nih.gov/REST/rxcui?idtype=NDC&id=" + m.Ndc;
                        request = (HttpWebRequest)WebRequest.Create(url);
                        request.AutomaticDecompression = DecompressionMethods.GZip;

                        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())  // Go query google
                        using (Stream responseStream = response.GetResponseStream())               // Load the response stream
                        using (StreamReader streamReader = new StreamReader(responseStream))       // Load the stream reader to read the response
                        {
                            siteContent = streamReader.ReadToEnd();
                        }
                        doc.LoadXml(siteContent);
                        xnList = doc.SelectNodes("/rxnormdata/idGroup");
                        if (xnList[0]["rxnormId"] != null)
                            rxcuis.Add(xnList[0]["rxnormId"].InnerText);

                    }
                }
                string tmp = string.Empty;
                if(rxcuis.Count>0)
                {
                    for (int i = 0; i < rxcuis.Count; i++)
                        tmp = tmp + "+" + rxcuis[i];
                    url = "https://rxnav.nlm.nih.gov/REST/interaction/list.json?rxcuis=" + rxcui + tmp;
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.AutomaticDecompression = DecompressionMethods.GZip;
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())  // Go query google
                    using (Stream responseStream = response.GetResponseStream())               // Load the response stream
                    using (StreamReader streamReader = new StreamReader(responseStream))       // Load the stream reader to read the response
                    {
                       siteContent = streamReader.ReadToEnd();
                    }

                    Root DetailsTree = JsonConvert.DeserializeObject<Root>(siteContent);
                    foreach (FullInteractionType fullI in DetailsTree.fullInteractionTypeGroup[0].fullInteractionType)
                    {
                       tmp2 = tmp2 + fullI.interactionPair[0].description + "\n";
                    }

                    foreach (FullInteractionType fullI in DetailsTree.fullInteractionTypeGroup[0].fullInteractionType)
                    {
                        if (fullI.interactionPair[0].severity == "high")
                           throw new Exception("The severity is high to use the new medicine with the old:" + tmp2);
                    }
                }
            }
            return tmp2;
        }
    }
}
