using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using WindowsCEConsentForms.ConsentFormsService;

namespace WindowsCEConsentForms
{
    public partial class Consent : System.Web.UI.UserControl
    {
        public ConsentType ConsentType;

        public string ConsentFolder;

        public string Heading;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                bool isItNewSession;
                try
                {
                    isItNewSession = (bool)Session["NewSessionFor" + ConsentType.ToString()];
                }
                catch (Exception)
                {
                    isItNewSession = true;
                }

                for (int i = 0; i < 7; i++)
                    ViewState["Signature" + i] = string.Empty;

                var formHandlerServiceClient = new FormHandlerServiceClient();
                string patientId;
                try
                {
                    patientId = Session["PatientID"].ToString();
                }
                catch (Exception)
                {
                    try
                    {
                        patientId = Request.QueryString["PatientId"];
                    }
                    catch (Exception)
                    {
                        patientId = string.Empty;
                    }
                }
                if (!isItNewSession)
                {
                    // Loading Signatures based on the selected patient
                    ViewState["Signature1"] = formHandlerServiceClient.GetPatientSignature(patientId, ConsentType.ToString(), "signature1");
                    ViewState["Signature2"] = formHandlerServiceClient.GetPatientSignature(patientId, ConsentType.ToString(), "signature2");
                    ViewState["Signature3"] = formHandlerServiceClient.GetPatientSignature(patientId, ConsentType.ToString(), "signature3");
                    ViewState["Signature4"] = formHandlerServiceClient.GetPatientSignature(patientId, ConsentType.ToString(), "signature4");
                    ViewState["Signature5"] = formHandlerServiceClient.GetPatientSignature(patientId, ConsentType.ToString(), "signature5");
                }
            }
            catch (Exception)
            {
                Response.Redirect("/PatientConsent.aspx");
            }
        }

        protected void BtnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("/PatientConsent.aspx");
            }
            catch (Exception)
            {
                return;
            }
        }

        protected void BtnNext_Click(object sender, EventArgs e)
        {
            // need to save signatures here
            try
            {
                if (DoctorsAndProcedures1.DdlPrimaryDoctors.SelectedIndex == 0) // || DdlAssociatedDoctors.SelectedIndex == 0)
                {
                    LblError.Text = "Please select primary and associated doctor";
                    return;
                }

                if (string.IsNullOrEmpty(DoctorsAndProcedures1.HdnSelectedProcedures.Value))
                {
                    LblError.Text = "Please select the procedures and then go next.";
                    return;
                }

                if (string.IsNullOrEmpty(Request.Form["HdnImage1"]) || string.IsNullOrEmpty(Request.Form["HdnImage2"]) || string.IsNullOrEmpty(Request.Form["HdnImage3"]) || string.IsNullOrEmpty(Request.Form["HdnImage4"]) || string.IsNullOrEmpty(Request.Form["HdnImage5"]))
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

                string selectedProcedurenames = string.Empty;

                // validation for other procedure
                foreach (string procedurename in DoctorsAndProcedures1.HdnSelectedProcedures.Value.Split('#'))
                {
                    if (!string.IsNullOrEmpty(procedurename))
                    {
                        if (procedurename.Trim().ToLower() == "other")
                        {
                            if (string.IsNullOrEmpty(DoctorsAndProcedures1.TxtOtherProcedure.Text))
                            {
                                LblError.Text = "Please input your signatures in all the fields";
                                return;
                            }
                            selectedProcedurenames += DoctorsAndProcedures1.TxtOtherProcedure.Text;
                        }
                        else
                            selectedProcedurenames += procedurename + "#";
                    }
                }

                var formHandlerServiceClient = new FormHandlerServiceClient();

                //formHandlerServiceClient.UpdateDoctorAssociation(patientId, DdlPrimaryDoctors.SelectedValue, DdlAssociatedDoctors.SelectedValue);
                formHandlerServiceClient.UpdateDoctorAssociation(patientId, DoctorsAndProcedures1.DdlPrimaryDoctors.SelectedValue, "0");

                formHandlerServiceClient.UpdatePatientProcedures(patientId, selectedProcedurenames);

                // updating signature1
                var bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage1"]);
                bool result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), ConsentType.ToString(), "signature1");

                // updating signature2
                bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage2"]);
                result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), ConsentType.ToString(), "signature2");

                // updating signature3
                bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage3"]);
                result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), ConsentType.ToString(), "signature3");

                // updating signature4
                bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage4"]);
                result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), ConsentType.ToString(), "signature4");

                // updating signature4
                bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage5"]);
                result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), ConsentType.ToString(), "signature5");

                Session["NewSessionFor" + ConsentType.ToString()] = false;

                Response.Redirect("/" + ConsentFolder + "/ConsentDeclaration.aspx");
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}