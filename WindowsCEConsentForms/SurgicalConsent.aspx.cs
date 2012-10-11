using System;
using System.Text;
using WindowsCEConsentForms.ConsentFormsService;
using System.Data;

namespace WindowsCEConsentForms
{
    public partial class SurgicalConsent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < 7; i++)
                    ViewState["Signature" + i] = string.Empty;
                var formHandlerServiceClient = new FormHandlerServiceClient();
                if (!IsPostBack)
                {
                    DdLProcedures.Items.Clear();
                    DdLProcedures.Items.Add("-----Select Procedure-----");
                    foreach (string procedureName in formHandlerServiceClient.GetProcedurenameList())
                        DdLProcedures.Items.Add(procedureName);
                }
                string patientId = string.Empty;
                try
                {
                    patientId = Session["PatientID"].ToString();
                }
                catch (Exception)
                {
                    try
                    {
                        patientId = Request.QueryString["PatientId"].ToString();
                    }
                    catch (Exception) {
                       // Response.Redirect("/PatientConsent.aspx");
                    }
                }
                if (!IsPostBack)
                {
                    DdlPrimaryDoctors.Items.Add("----Select Primary Doctor----");
                    var physicians = formHandlerServiceClient.GetPrimaryPhysiciansList();
                    if (physicians != null)
                    {
                        foreach (DataRow row in physicians.Rows)
                        {
                            DdlPrimaryDoctors.Items.Add(new System.Web.UI.WebControls.ListItem(row["Lname"].ToString() + ", " + row["Fname"].ToString(), row["PhysicianId"].ToString()));
                        }
                    }
                    var patientDetail = formHandlerServiceClient.GetPatientDetail(patientId);
                    if (patientDetail != null)
                    {
                        LblPatientName.Text = patientDetail.name;
                        LblDate.Text = patientDetail.AdmDate.ToString("MMM dd yyyy");
                        LblPatientId.Text = patientId;
                        LblTime.Text = DateTime.Now.ToShortTimeString();
                        //var primaryDoctor = formHandlerServiceClient.GetPrimaryDoctorDetail(patientDetail.PrimaryDoctorId);
                        //DdlPrimaryDoctors.SelectedValue = primaryDoctor.Lname + ", " + primaryDoctor.Fname;
                        LoadAssociatedDoctors(patientDetail.AssociatedDoctorId);
                        //var associatedDoctor = formHandlerServiceClient.GetAssociateDoctorDetail(patientDetail.AssociatedDoctorId);
                       // DdlAssociatedDoctors.SelectedValue = associatedDoctor.Lname + ", " + associatedDoctor.Fname;
                        DdlPrimaryDoctors.Items.FindByValue(patientDetail.PrimaryDoctorId).Selected = true;
                        DdlAssociatedDoctors.Items.FindByValue(patientDetail.AssociatedDoctorId).Selected = true;
                        if(!string.IsNullOrEmpty(patientDetail.ProcedureName))
                            DdLProcedures.Items.FindByText(patientDetail.ProcedureName).Selected = true;
                    }
                    else 
                        DdlPrimaryDoctors.SelectedIndex = 0;
                }
                // Loading Signatures based on the selected patient
                ViewState["Signature1"] = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent", "signature1");
                ViewState["Signature2"] = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent", "signature2");
                ViewState["Signature3"] = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent", "signature3");
                ViewState["Signature4"] = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent", "signature4");
                ViewState["Signature5"] = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent", "signature5");
            }
            catch (Exception ex)
            {
                Response.Redirect("/PatientConsent.aspx");
            }
        }

        protected void DdlPrimaryDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            // load all the fields here
            try
            {
                // loading select form type box and patient details
                if (DdlPrimaryDoctors.SelectedIndex > 0)
                {
                    LoadAssociatedDoctors(DdlPrimaryDoctors.SelectedValue);
                    DdlAssociatedDoctors.SelectedIndex = 0;
                }
                else
                {
                    LblError.Text = "Please select primary doctor";
                    DdlAssociatedDoctors.Items.Clear();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void LoadAssociatedDoctors( string PrimaryDoctorId)
        {
            DdlAssociatedDoctors.Items.Clear();
            var formHandlerServiceClient = new FormHandlerServiceClient();
            var associatedDoctors = formHandlerServiceClient.GetAssociatedPhysiciansList(PrimaryDoctorId);
            DdlAssociatedDoctors.Items.Add("----Select Associated Doctor----");
            if (associatedDoctors != null)
            {
                foreach (DataRow row in associatedDoctors.Rows)
                {
                    DdlAssociatedDoctors.Items.Add(new System.Web.UI.WebControls.ListItem(row["Lname"].ToString() + ", " + row["Fname"].ToString(), row["Id"].ToString()));
                }
            }
            else
            {
                LblError.Text = "Associted doctors list not available.";
            }
        }

        protected void BtnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("/PatientConsent.aspx");
            }
            catch (Exception ex)
            {
            }
        }

        protected void BtnNext_Click(object sender, EventArgs e)
        {
            // need to save signatures here
            try
            {
                if (DdlPrimaryDoctors.SelectedIndex == 0 || DdlAssociatedDoctors.SelectedIndex == 0)
                {
                    LblError.Text = "Please select primary and associated doctor";
                    return;
                }

                if (DdLProcedures.SelectedIndex == 0)
                {
                    LblError.Text = "Please select the procedure and then go next.";
                    return;
                }

                if (string.IsNullOrEmpty(Request.Form["HdnImage1"]) || string.IsNullOrEmpty(Request.Form["HdnImage2"]) || string.IsNullOrEmpty(Request.Form["HdnImage3"]) || string.IsNullOrEmpty(Request.Form["HdnImage4"]) || string.IsNullOrEmpty(Request.Form["HdnImage5"]))
                //if (true)
                {
                    LblError.Text = "Please input your signatures in all the fields";
                    return;
                }

                string patientId = string.Empty;
                try
                {
                    patientId = Session["PatientID"].ToString();
                }
                catch (Exception)
                {
                    Response.Redirect("/PatientConsent.aspx");
                }

                var formHandlerServiceClient = new FormHandlerServiceClient();

                formHandlerServiceClient.UpdateDoctorAssociation(patientId, DdlPrimaryDoctors.SelectedValue, DdlAssociatedDoctors.SelectedValue);
                formHandlerServiceClient.UpdatePatientProcedure(patientId, DdLProcedures.SelectedValue);

                // updating signature1
                var bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage1"]);
                bool result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), "SurgicalConsent", "signature1");

                // updating signature2
                bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage2"]);
                result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), "SurgicalConsent", "signature2");

                // updating signature3
                bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage3"]);
                result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), "SurgicalConsent", "signature3");

                // updating signature4
                bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage4"]);
                result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), "SurgicalConsent", "signature4");

                // updating signature4
                bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage5"]);
                result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), "SurgicalConsent", "signature5");
                

                //var document = new Document();
                try
                {
                    //string tempPath = Path.GetTempPath() + "\\" + patientId + "Consent2.pdf";

                    //string tempPath = GetTempFilename() + "\\Consent2.pdf";
                    //if (File.Exists(tempPath))
                    //File.Delete(tempPath);

                    //PdfWriter.GetInstance(document, new FileStream(tempPath, FileMode.OpenOrCreate));
                    //document.Open();

                    //var bytes = Encoding.ASCII.GetBytes(HdnImage1.Value);
                    //var bytes = Encoding.ASCII.GetBytes(Uri.EscapeUriString(HdnImage1.Value));

                    //var bytes = ASCIIEncoding.ASCII.GetBytes(HdnImage1.Value);
                    //var bytes = ASCIIEncoding.ASCII.GetBytes(Uri.EscapeUriString(HdnImage1.Value));

                    //var bytes = Convert.FromBase64String(Uri.EscapeUriString(HdnImage1.Value));
                    //var bytes = Convert.FromBase64String(HdnImage1.Value);
                    //var ms = new MemoryStream(bytes);

                    //Image img = new ImgWMF(bytes);

                    //document.Add(img);

                    //System.Drawing.Image image1 = System.Drawing.Image.FromStream(ms);

                    //string tempImagePath = GetTempFilename();
                    //image1.Save(tempImagePath);
                    //document.Add(Image.GetInstance(tempImagePath));

                    /*
                    bytes = Encoding.ASCII.GetBytes(HdnImage2.Value);
                    image1 = Image.GetInstance(bytes);
                    document.Add(image1);

                    bytes = Encoding.ASCII.GetBytes(HdnImage3.Value);
                    image1 = Image.GetInstance(bytes);
                    document.Add(image1);

                    bytes = Encoding.ASCII.GetBytes(HdnImage4.Value);
                    image1 = Image.GetInstance(bytes);
                    document.Add(image1);

                    bytes = Encoding.ASCII.GetBytes(HdnImage5.Value);
                    image1 = Image.GetInstance(bytes);
                    document.Add(image1); */

                    //document.Close();

                    Response.Redirect("/SurgicalConsentDeclaration.aspx");
                }
                catch (Exception ex)
                {
                }
            }
            catch (Exception ex)
            {
            }
        }
       
    }
}