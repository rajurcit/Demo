using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class Registration : System.Web.UI.Page
{
    blCoupon objCoupon = new blCoupon();
    blRegistration objRegistration = new blRegistration();
    string sInterest, sName, sEmail, sCompany, sPhone, sTwitterLink, sLinkedLink, RegistrationNo, ToEmailString;
    public string PayeeName, PayeeEmail, PayeePhone;
    private Random random = new Random();
    blCoupon objCoupon1 = new blCoupon();
    string[] aEarlyBirdDate; string[] aRegularDate;

    protected override void OnInit(EventArgs e)
    {
        //base.OnInit(e);
        base.OnLoadComplete(e);
        
        int ListNo = Convert.ToInt32(Request.Params["ctl00$ContentPlaceHolder1$ddldelegates"]);
        int Paymentoption = Convert.ToInt32(Request.Params["ctl00$ContentPlaceHolder1$rdoPaymentoption"]); // Convert.ToInt32(Request.Form["ctl00$ContentPlaceHolder1$rdoPaymentoption"]);
        GenerateRandomDelegateList(ListNo, Paymentoption);
    }

    //protected   void Page_itComplete(object sender, EventArgs e)
    //{
    //    base.OnLoadComplete(e);

    //    int ListNo = Convert.ToInt32(ddldelegates.SelectedValue);// Convert.ToInt32(Request.Form["ddldelegates"]);
    //    int Paymentoption = Convert.ToInt32(Request.Form["ContentPlaceHolder1_rdoPaymentoption"]);
    //    GenerateRandomDelegateList(ListNo, Paymentoption);
    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            dt = objCoupon1.GetFeeDetail();
            //iCount = dt.Rows.Count;
            if (dt.Rows.Count > 0)
            {
                ltrEarlyBirdA.Text = dt.Rows[0]["EarlyBirdFee"].ToString(); //dt.Rows[0].ItemArray[1].ToString();
                ltrAdvanceA.Text = dt.Rows[0]["RegularFee"].ToString(); //dt.Rows[0].ItemArray[2].ToString();
                ltrRegularA.Text = dt.Rows[0]["OnSpotFee"].ToString();
                aEarlyBirdDate = dt.Rows[0]["EarlyBirdDate"].ToString().Split('-');
                aRegularDate = dt.Rows[0]["RegularDate"].ToString().Split('-');
            }
            MVRegistration.ActiveViewIndex = 1;
            this.Session["CaptchaImageText"] = GenerateRandomCode();


            DateTime EarlyBirdDate = new DateTime(Convert.ToInt32(aEarlyBirdDate[0]), Convert.ToInt32(aEarlyBirdDate[1]), Convert.ToInt32(aEarlyBirdDate[2]));
            DateTime RegularDate = new DateTime(Convert.ToInt32(aRegularDate[0]), Convert.ToInt32(aRegularDate[1]), Convert.ToInt32(aRegularDate[2]));

            LitearlyBirddate.Text = EarlyBirdDate.ToString("MMM dd, yyyy");
            litDate.Text = (EarlyBirdDate.AddDays(1)).ToString("MMM dd, yyyy") + " - " + (RegularDate.AddDays(-1)).ToString("MMM dd, yyyy");
            if (DateTime.Now.Date <= EarlyBirdDate)
            {
                SpanA1.Attributes["class"] = "black24 black18";
                SpanA2.Attributes["class"] = "size14 black14";
                SpanA3.Attributes["class"] = "black34 conference";
                SpanA4.Attributes["class"] = "black34 brdRN conference";

                SpanC1.Attributes["class"] = "black24 lgrey black18";
                SpanC2.Attributes["class"] = "size14 black14 lgrey";
                SpanC3.Attributes["class"] = "";
                SpanC4.Attributes["class"] = "brdRN ";



                rdoEarlyBirdA.Visible = true;
                rdoEarlyBirdB.Visible = true;

                rdoAdvanceA.Visible = false;
                rdoAdvanceB.Visible = false;

                rdoRegularA.Visible = false;
                rdoRegularB.Visible = false;

            }

            else if (DateTime.Now.Date >= EarlyBirdDate.AddDays(1) && DateTime.Now.Date <= RegularDate.AddDays(-1))
            {
                SpanA1.Attributes["class"] = "black24 lgrey black18";
                SpanA2.Attributes["class"] = "size14 black14 lgrey";
                SpanA3.Attributes["class"] = "";
                SpanA4.Attributes["class"] = "brdRN";

                SpanC1.Attributes["class"] = "black24 black18";
                SpanC2.Attributes["class"] = "size14 black14";
                SpanC3.Attributes["class"] = "black34 conference";
                SpanC4.Attributes["class"] = "black34 brdRN conference";

                rdoEarlyBirdA.Visible = false;
                rdoEarlyBirdB.Visible = false;

                rdoRegularA.Visible = false;
                rdoRegularB.Visible = false;


                rdoAdvanceA.Visible = true;
                rdoAdvanceB.Visible = true;


            }

            else
            {

                SpanB1.Attributes["class"] = "black24 black18";
                SpanB2.Attributes["class"] = "size14 black14";
                SpanB3.Attributes["class"] = "black34 conference";
                SpanB4.Attributes["class"] = "black34 brdRN conference";

                SpanA1.Attributes["class"] = "black24 lgrey black18";
                SpanA2.Attributes["class"] = "size14 black14 lgrey";
                SpanA3.Attributes["class"] = "";
                SpanA4.Attributes["class"] = "brdRN ";

                SpanC1.Attributes["class"] = "black24 lgrey black18";
                SpanC2.Attributes["class"] = "size14 black14 lgrey";
                SpanC3.Attributes["class"] = "";
                SpanC4.Attributes["class"] = "brdRN ";

                rdoRegularA.Visible = true;
                rdoRegularB.Visible = true;

                rdoEarlyBirdA.Visible = false;
                rdoEarlyBirdB.Visible = false;

                rdoAdvanceA.Visible = false;
                rdoAdvanceB.Visible = false;


            }
        }

    }

    private string GenerateRandomCode()
    {

        string s = "";
        for (int i = 0; i < 6; i++)
            s = String.Concat(s, this.random.Next(10).ToString());
        return s;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string sUserType = string.Empty;
        blContact objContact = new blContact();
        Regex regex = new Regex(@"(?:\s+|)((0|(?:(\+|)91))(?:\s|-)*(?:(?:\d(?:\s|-)*\d{9})|(?:\d{2}(?:\s|-)*\d{8})|(?:\d{3}(?:\s|-)*\d{7}))|\d{10})(?:\s+|)");
        // Regex regex = new Regex("");
        if (regex.IsMatch(txtPhone.Text))
        {
            if ((CaptchaTextBox.Text == this.Session["CaptchaImageText"].ToString()) && Page.IsValid)
            {
                if (rdoUserType.SelectedValue.ToString().Trim() == "Speaker") { sUserType = "Speaker"; }
                if (rdoUserType.SelectedValue.ToString().Trim() == "Sponsor") { sUserType = "Sponsor"; }
                if (rdoUserType.SelectedValue.ToString().Trim() == "Press") { sUserType = "Press"; }
                if (rdoUserType.SelectedValue.ToString().Trim() == "Trainer") { sUserType = "Trainer"; }

                objContact.Name = txtName.Text.Trim();
                objContact.Email = txtEmail.Text.Trim();
                objContact.Company = txtCompany.Text.Trim();
                objContact.Mobile = txtPhone.Text.Trim();
                objContact.TwitterLink = txtTwitterLink.Text.Trim();
                objContact.LinkedLink = txtLinkedLink.Text.Trim();
                objContact.UserType = rdoUserType.SelectedValue.ToString();

                int Count = objContact.AddContact();
                if (Count > 0)
                {
                    SendMail();
                    Response.Redirect("thankyou.html");
                }
            }
            else
            {
                Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Please enter correct captcha code');</SCRIPT>");
                CaptchaTextBox.Text = "";
                this.Session["CaptchaImageText"] = GenerateRandomCode();
            }
        }
        else
        {
            Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Please enter correct Mobile/phone No.');</SCRIPT>");

        }
    }


    protected void rdoUserType_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (rdoUserType.SelectedIndex == 0)
            MVRegistration.ActiveViewIndex = 1;
        else
            MVRegistration.ActiveViewIndex = 0;

        if (rdoUserType.SelectedIndex == 1 || rdoUserType.SelectedIndex == 4)
            divMedia.Visible = true;
        else
            divMedia.Visible = false;

        txtName.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtCompany.Text = string.Empty;
        txtPhone.Text = string.Empty;
        txtTwitterLink.Text = string.Empty;
        txtLinkedLink.Text = string.Empty;
        CaptchaTextBox.Text = string.Empty;
        CaptchaTextBox2.Text = string.Empty;
    }
    protected void GenerateRandomDelegateList(int ListNo, int Paymentoption)
    {
        ListNo = Convert.ToInt32(ddldelegates.SelectedValue);
        // ListNo = Convert.ToInt32(hdnDelegate.Value);
        //  Paymentoption = Convert.ToInt32(hdnDelegate.Value);


        if (ListNo > 0 && Paymentoption > 0)
        {
            for (int i = 1; i <= ListNo; i++)
            {
                PHDelegate.Controls.Add(new LiteralControl("<div><h1 class='grey24'>Delegate No." + i.ToString()));


                if (Paymentoption == 1 && ListNo > 1)
                {
                    PHDelegate.Controls.Add(new LiteralControl("<label class='checkbox-inline'>"));
                    RadioButton Payee = new RadioButton();
                    Payee.ID = "rbtnPayee" + i.ToString();
                    Payee.GroupName = "Payee";
                    Payee.CssClass = "mRgt5 rB";
                    PHDelegate.Controls.Add(Payee);
                    PHDelegate.Controls.Add(new LiteralControl("<span class='size14'>Payee</span> </label>"));
                }

                PHDelegate.Controls.Add(new LiteralControl("</h1>"));
                PHDelegate.Controls.Add(new LiteralControl("<div class='row'>"));
                PHDelegate.Controls.Add(new LiteralControl("<div class='col-md-6'>"));
                PHDelegate.Controls.Add(new LiteralControl("<div class='form-group'>"));
                            


                TextBox Name = new TextBox();
                Name.Attributes["class"] = "form-control inpt1";
                Name.Attributes["placeholder"] = "Name";
                Name.ID = "txtName" + i.ToString();
                 PHDelegate.Controls.Add(Name);

                


                RequiredFieldValidator RFVDName = new RequiredFieldValidator();//Validator Name
                RFVDName.ID = "RFVDName" + i.ToString();
                RFVDName.ErrorMessage = "Please enter the Name for Delegate No. " + i.ToString().Trim() + ".";
                RFVDName.ControlToValidate = Name.ID;// "txtName" + i.ToString();
                RFVDName.ValidationGroup = "Register";// "Delegate";
                //RFVDName.Attributes["style"] = "visibility:show;color:Red;display:block;";
                RFVDName.Display = 0;
                PHDelegate.Controls.Add(RFVDName);
                //RFVName.Display =0;
                RegularExpressionValidator REEVName = new RegularExpressionValidator();//Email-Validation
                REEVName.ID = "REEVDName" + i.ToString();
                REEVName.ErrorMessage = "Please enter proper name for Delegate No. " + i.ToString().Trim() + ".";
                REEVName.ControlToValidate = Name.ID;
                REEVName.ValidationExpression = "[a-zA-Z' ']{3,}";
                REEVName.ValidationGroup = "Register";
                REEVName.Display = 0;
                PHDelegate.Controls.Add(REEVName);
                //PHDelegate.Controls.Add(new LiteralControl("</div>"));
                //PHDelegate.Controls.Add(new LiteralControl("</div>"));
                //PHDelegate.Controls.Add(new LiteralControl("<div class='col-md-6'>"));
                //PHDelegate.Controls.Add(new LiteralControl("<div class='form-group'>"));



                PHDelegate.Controls.Add(new LiteralControl("</div>"));
                PHDelegate.Controls.Add(new LiteralControl("<div class='form-group'>"));
                TextBox Email = new TextBox();
                Email.Attributes["class"] = "form-control inpt1";
                Email.Attributes["placeholder"] = "Email Id";
                Email.ID = "txtEmail" + i.ToString();
                PHDelegate.Controls.Add(Email);
                RequiredFieldValidator RFVDEmail = new RequiredFieldValidator();//Validator Email
                RFVDEmail.ID = "RFVDEmail" + i.ToString();
                RFVDEmail.ErrorMessage = "Please enter the Email id for Delegate No. " + i.ToString().Trim() + ".";
                RFVDEmail.ControlToValidate = Email.ID;// "txtName" + i.ToString();
                RFVDEmail.ValidationGroup = "Register";// "Delegate";
                RFVDEmail.Display = 0;
                PHDelegate.Controls.Add(RFVDEmail);

                RegularExpressionValidator REEVDEmail = new RegularExpressionValidator();//Email-Validation
                REEVDEmail.ID = "REEVDEmail" + i.ToString();
                REEVDEmail.ErrorMessage = "Please enter valid Email id for Delegate No. " + i.ToString().Trim() + ".";
                REEVDEmail.ControlToValidate = Email.ID;
                REEVDEmail.ValidationExpression = @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";
                REEVDEmail.ValidationGroup = "Register";
                REEVDEmail.Display = 0;
                PHDelegate.Controls.Add(REEVDEmail);

                PHDelegate.Controls.Add(new LiteralControl("</div>"));
                PHDelegate.Controls.Add(new LiteralControl("</div>"));
                PHDelegate.Controls.Add(new LiteralControl("<div class='col-md-6'>"));
                PHDelegate.Controls.Add(new LiteralControl("<div class='form-group'>"));
                TextBox Company = new TextBox();
                Company.Attributes["class"] = "form-control inpt1";
                Company.Attributes["placeholder"] = "Company";
                Company.ID = "txtCompany" + i.ToString();


                RequiredFieldValidator RFVDCompany = new RequiredFieldValidator();//Validator Company
                RFVDCompany.ID = "RFVDCompany" + i.ToString();
                RFVDCompany.ErrorMessage = "Please enter the Company Name for Delegate No. " + i.ToString().Trim() + ".";
                RFVDCompany.ControlToValidate = Company.ID;// "txtName" + i.ToString();
                RFVDCompany.ValidationGroup = "Delegate";// "Delegate";
                //RFVDCompany.Display = 0;
                //PHDelegate.Controls.Add(RFVDCompany);

                PHDelegate.Controls.Add(Company);
                PHDelegate.Controls.Add(new LiteralControl("</div>"));
                PHDelegate.Controls.Add(new LiteralControl("<div class='form-group'>"));
                TextBox Phone = new TextBox();
                Phone.Attributes["class"] = "form-control inpt1";
                Phone.Attributes["placeholder"] = "Phone / Mobile";
                Phone.ID = "txtPhone" + i.ToString();
                Phone.Attributes["onkeypress"] = "return isNumberKey(event)";
                Phone.Attributes["MaxLength"] = "15";

                RequiredFieldValidator RFVDPhone = new RequiredFieldValidator();//Validator Phone
                RFVDPhone.ID = "RFVDPhone" + i.ToString();
                RFVDPhone.ErrorMessage = "Please enter the Phone / Mobile No. for Delegate No. " + i.ToString().Trim() + ".";
                RFVDPhone.ControlToValidate = Phone.ID;// "txtName" + i.ToString();
                RFVDPhone.ValidationGroup = "Delegate";// "Delegate";
                //RFVDPhone.Display = 0;
                //PHDelegate.Controls.Add(RFVDPhone);

                PHDelegate.Controls.Add(Phone);
                PHDelegate.Controls.Add(new LiteralControl("</div>"));
                PHDelegate.Controls.Add(new LiteralControl("</div>"));
                PHDelegate.Controls.Add(new LiteralControl("</div></div>"));
            }
            // tnc.Style["display"] = "block";

        }

    }

    protected void RBPlan_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton SelectedPlan = (RadioButton)sender;
        ViewState["SelectedPlanPrice"] = ltrRegularA.Text;// Convert.ToInt32(((Literal)Page.FindControl(SelectedPlan.ID.Replace("rdo", "ltr"))).Text);
        PriceUpdate();
    }
    protected void PriceUpdate()
    {
        decimal noofdelegates = 0, total = 0, groupdiscount = 0, grossamount = 0, coupondiscount = 0, netamount = 0, servicetax = 0, grandtotal = 0;
        int SelectedPlanPrice = Convert.ToInt32(ViewState["SelectedPlanPrice"]);
        noofdelegates = Convert.ToInt32(ddldelegates.SelectedValue);
        total = SelectedPlanPrice * noofdelegates;

        if (noofdelegates > 2 && noofdelegates < 5)
            groupdiscount = Math.Round(total * 10 / 100);
        else if (noofdelegates >= 5)
            groupdiscount = Math.Round(total * 15 / 100);


        grossamount = total - groupdiscount;

        if (txtDiscount.Text.Trim() == "")
            coupondiscount = 0;
        else
            coupondiscount = Math.Round(Convert.ToDecimal(txtDiscount.Text.Trim()));

        netamount = Math.Round(grossamount - coupondiscount);

        servicetax = Math.Round(netamount * 1500 / 10000);
        servicetax = 0;

        grandtotal = Math.Round(netamount + servicetax);

        txtTotal.Text = total.ToString().Trim();
        txtGroupDiscount.Text = groupdiscount.ToString().Trim();

        txtGross.Text = grossamount.ToString().Trim();
        txtNetAmount.Text = netamount.ToString().Trim();

        txtServiceTax.Text = servicetax.ToString().Trim();
        txtGrandTotal.Text = grandtotal.ToString().Trim();
    }
    protected void btnSubmit1_Click(object sender, EventArgs e)
    {
        bool validated = false;

        if ((CaptchaTextBox2.Text == this.Session["CaptchaImageText"].ToString()) && Page.IsValid)
        {
            //  int NoofParticipants = Convert.ToInt32(ddldelegates.SelectedValue);
            if (rdoEarlyBirdA.Checked == false && rdoEarlyBirdB.Checked == false && rdoRegularA.Checked == false && rdoRegularB.Checked == false
                    && rdoAdvanceA.Checked == false && rdoAdvanceB.Checked == false)
            {
                clsCommon.PageAlert(Page, "Please select Payment Plan!!!");
                return;
            }
            int NoofParticipants = Convert.ToInt32(ddldelegates.SelectedValue);
            if (NoofParticipants > 0)
            {
                for (int i = 1; i <= NoofParticipants; i++)
                {
                    //Regex regex = new Regex(@"(?:\s+|)((0|(?:(\+|)91))(?:\s|-)*(?:(?:\d(?:\s|-)*\d{9})|(?:\d{2}(?:\s|-)*\d{8})|(?:\d{3}(?:\s|-)*\d{7}))|\d{10})(?:\s+|)");

                    //if (!regex.IsMatch(((TextBox)PHDelegate.FindControl("txtPhone" + i.ToString())).Text))
                    //{

                    //    clsCommon.PageAlert(Page, "Please enter the correct Phone / Mobile no for Delegate No. " + i);
                    //    return;
                    //    break;
                    //}
                }
            }
            if (rdoPaymentoption.SelectedIndex == 0)
            {

                if (NoofParticipants > 1)
                {
                    for (int i = 1; i <= NoofParticipants; i++)
                    {
                        string Payee = "rbtnPayee" + i.ToString();
                        if (((RadioButton)PHDelegate.FindControl(Payee)).Checked == true)
                        {
                            string NameId = "txtName" + i.ToString();
                            string EmailId = "txtEmail" + i.ToString();
                            string CompanyName = "txtCompany" + i.ToString();
                            string PhoneId = "txtPhone" + i.ToString();
                            PayeeName = ((TextBox)PHDelegate.FindControl(NameId)).Text;
                            PayeeEmail = ((TextBox)PHDelegate.FindControl(EmailId)).Text;
                            PayeePhone = ((TextBox)PHDelegate.FindControl(PhoneId)).Text;

                            ViewState["PayeeName"] = PayeeName;
                            ViewState["PayeeEmail"] = PayeeEmail;
                            ViewState["PayeePhone"] = PayeePhone;

                            validated = true;

                            break;
                        }
                    }

                    if (validated == false)
                    {
                        clsCommon.PageAlert(Page, "Please select Payee.");
                        return;
                    }
                }
                else
                {
                  
                    PayeeName = ((TextBox)PHDelegate.FindControl("txtName1")).Text;
                    PayeeEmail = ((TextBox)PHDelegate.FindControl("txtEmail1")).Text;
                    PayeePhone = ((TextBox)PHDelegate.FindControl("txtPhone1")).Text;

                    ViewState["PayeeName"] = PayeeName;
                    ViewState["PayeeEmail"] = PayeeEmail;
                    ViewState["PayeePhone"] = PayeePhone;
                }


            }

            sInterest = rdoUserType.SelectedValue.ToString().Trim();
            if (rdoPaymentoption.SelectedValue == "1")
                RegistrationNo = "CMS-" + rdoUserType.SelectedValue.ToString().Trim() + "-O-";
            else if (rdoPaymentoption.SelectedValue == "2")
                RegistrationNo = "CMS-" + rdoUserType.SelectedValue.ToString().Trim() + "-C-";
            else if (rdoPaymentoption.SelectedValue == "3")
                RegistrationNo = "CMS-" + rdoUserType.SelectedValue.ToString().Trim() + "-B-";

            objRegistration.UserType = rdoUserType.SelectedValue.ToString();
            objRegistration.PaymentMode = rdoPaymentoption.SelectedValue.ToString();
            objRegistration.Amount = txtTotal.Text.Trim();
            objRegistration.Discount = txtGroupDiscount.Text.Trim();
            objRegistration.NetAmount = txtNetAmount.Text.Trim();
            objRegistration.ServiceTax = txtServiceTax.Text.Trim();
            objRegistration.GrandTotal = txtGrandTotal.Text.Trim();
            objRegistration.RegistrationNo = RegistrationNo;
            objRegistration.CouponCode = txtCoupon.Text.Trim();
            if (txtDiscount.Text != "")
                objRegistration.CouponDiscount = Convert.ToInt32(txtDiscount.Text.Trim());
            else
                objRegistration.CouponDiscount = 0;
            if (txtGross.Text != "")
                objRegistration.GrossAmount = Convert.ToInt32(txtGross.Text.Trim());
            else
                objRegistration.GrossAmount = 0;
            int RegistrationId = objRegistration.Register_Insert1();


            if (RegistrationId > 0)
            {
                int stratindex = Convert.ToInt32(ConfigurationSettings.AppSettings["stratindex"]);
                RegistrationNo += (stratindex + RegistrationId).ToString();
                Context.Items.Add("RegistrationId", RegistrationNo);
                string NameId;
                string EmailId;
                string CompanyId;
                string PhoneId;
                string Payee;
                for (int i = 1; i <= NoofParticipants; i++)
                {
                    NameId = "txtName" + i.ToString();
                    sName = ((TextBox)PHDelegate.FindControl(NameId)).Text;
                    EmailId = "txtEmail" + i.ToString();
                    sEmail = ((TextBox)PHDelegate.FindControl(EmailId)).Text;
                    CompanyId = "txtCompany" + i.ToString();
                    sCompany = ((TextBox)PHDelegate.FindControl(CompanyId)).Text;
                    PhoneId = "txtPhone" + i.ToString();
                    sPhone = ((TextBox)PHDelegate.FindControl(PhoneId)).Text;

                    objRegistration.Name = sName;
                    objRegistration.Email = sEmail;
                    objRegistration.Company = sCompany;
                    objRegistration.Phone = sPhone;
                    objRegistration.RegistrationId = RegistrationId;
                    objRegistration.IsActive = 0;

                    objRegistration.Participant_Insert(objRegistration.RegistrationId);

                    ////Participant_Insert(RegistrationId);
                    ToEmailString += sEmail + ",";

                }
                Context.Items.Add("PayeeName", Convert.ToString(ViewState["PayeeName"]));
                Context.Items.Add("PayeeEmail", Convert.ToString(ViewState["PayeeEmail"]));
                Context.Items.Add("PayeePhone", Convert.ToString(ViewState["PayeePhone"]));
                ToEmailString = ToEmailString.Substring(0, ToEmailString.Length - 1);
                Session["ToEmailString"] = ToEmailString;

            }
            if (rdoPaymentoption.SelectedValue == "1")
            {
                Session["NetAmount"] = txtGrandTotal.Text;                
                Server.Transfer("PaypalProcessing.aspx");
            }
            else if (rdoPaymentoption.SelectedValue == "2")
            {
                SendEmailForChequePayment();
                Response.Redirect("thankyou_cheque.html");
            }
            else if (rdoPaymentoption.SelectedValue == "3")
            {
                SendEmailForBankTransferPayment();
                Response.Redirect("thankyou_BankTransfer.html");
            }
        }
        else
        {
            Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Please enter the correct Captcha Code.');</SCRIPT>");
            CaptchaTextBox.Text = "";
            this.Session["CaptchaImageText"] = GenerateRandomCode();
        }
    }

    protected void SendEmailForChequePayment()
    {
        string mailbody = string.Empty;
        string url = Request.Url.ToString().Substring(0, Request.Url.ToString().LastIndexOf("/"));
        string bodyhtml = clsCommon.ReadFile("mailer_cheque.html");
        //string logo = url + "/img/CMS-logo.jpg";
        string logo = ConfigurationSettings.AppSettings["Mailer_Image"].ToString(); //url + "/img/CMS-logo.jpg";

        bodyhtml = bodyhtml.Replace("#logo#", logo);
        //bodyhtml = bodyhtml.Replace("#membername#", PayeeName);
        bodyhtml = bodyhtml.Replace("#registrationno#", RegistrationNo.ToString().Trim());


        //string Frommail = clsMails.MailFrom;
        //string ToMail = clsMails.MailTo;
        //string subject = "Contact Us queries/suggestions information.";
        //clsMails.SendWebMail(ToMail, Frommail, subject, bodyhtml);
        string subject = "Content Marketing Summit Asia";
        //string subject = "Content Marketing Summit Asia 2015";


        try
        {

            clsCommon.SendMail(Session["ToEmailString"].ToString(), bodyhtml.ToString(), subject);

            clsCommon.PageAlert(Page, "Thank you for contacting us! We will get back soon.", "Registration.aspx");

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }

    protected void SendEmailForBankTransferPayment()
    {
        string mailbody = string.Empty;
        string url = Request.Url.ToString().Substring(0, Request.Url.ToString().LastIndexOf("/"));
        string bodyhtml = clsCommon.ReadFile("mailer_BankTransfer.html");
        //string logo = url + "/img/CMS-logo.jpg";
        string logo = ConfigurationSettings.AppSettings["Mailer_Image"].ToString(); //url + "/img/CMS-logo.jpg";

        bodyhtml = bodyhtml.Replace("#logo#", logo);
        //bodyhtml = bodyhtml.Replace("#membername#", PayeeName);
        bodyhtml = bodyhtml.Replace("#registrationno#", RegistrationNo.ToString().Trim());


        //string Frommail = clsMails.MailFrom;
        //string ToMail = clsMails.MailTo;
        //string subject = "Contact Us queries/suggestions information.";
        //clsMails.SendWebMail(ToMail, Frommail, subject, bodyhtml);

        //string subject = "Content Marketing Summit Asia 2015";
        string subject = "Content Marketing Summit Asia";


        try
        {

            clsCommon.SendMail(Session["ToEmailString"].ToString(), bodyhtml.ToString(), subject);

            clsCommon.PageAlert(Page, "Thank you for contacting us! We will get back soon.", "Registration.aspx");

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }

    protected void SendMail()
    {
        string mailbody = string.Empty;
        //string url = Request.Url.ToString().Substring(0, Request.Url.ToString().LastIndexOf("/"));
        string bodyhtml = clsCommon.ReadFile("mailer_registration.html");
        string logo = ConfigurationSettings.AppSettings["Mailer_Image"].ToString(); //url + "/img/CMS-logo.jpg";

        bodyhtml = bodyhtml.Replace("#logo#", logo);
        bodyhtml = bodyhtml.Replace("#membername#", txtName.Text.Trim());
        bodyhtml = bodyhtml.Replace("#email#", txtEmail.Text.Trim());
        bodyhtml = bodyhtml.Replace("#phone#", txtPhone.Text.Trim());

        //string Frommail = clsMails.MailFrom;
        //string ToMail = clsMails.MailTo;
        //string subject = "Contact Us queries/suggestions information.";
        //clsMails.SendWebMail(ToMail, Frommail, subject, bodyhtml);
        string subject = "Content Marketing Summit Asia";
        //string subject = "Content Marketing Summit Asia 2015";


        try
        {

            clsCommon.SendMail(bodyhtml.ToString(), subject);

            clsCommon.PageAlert(Page, "Thank you for contacting us! We will get back soon.", "Registration.aspx");

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }

    protected void rdoPaymentoption_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Session["ListNo"] = Convert.ToInt32(ddldelegates.SelectedItem.Value);
        int ListNo = Convert.ToInt32(ddldelegates.SelectedItem.Value);
        //PHDelegate.Controls.Clear();
        //GenerateRandomDelegateList(ListNo);

        txtTotal.Text = "";
        txtGroupDiscount.Text = "";
        txtGross.Text = "";
        txtNetAmount.Text = "";
        txtServiceTax.Text = "";
        txtGrandTotal.Text = "";

        rdoEarlyBirdA.Checked = false;
        rdoEarlyBirdB.Checked = false;
        rdoAdvanceA.Checked = false;
        rdoAdvanceB.Checked = false;
        rdoRegularA.Checked = false;
        rdoRegularB.Checked = false;
    }
    protected void ddldelegates_SelectedIndexChanged(object sender, EventArgs e)
    {
        int ListNo = Convert.ToInt32(ddldelegates.SelectedValue); //Convert.ToInt32(Request.Form["ContentPlaceHolder1_ddldelegates"]);
        int Paymentoption = Convert.ToInt32(rdoPaymentoption.Text);// Convert.ToInt32(Request.Form["ContentPlaceHolder1_rdoPaymentoption"]);
        GenerateRandomDelegateList(ListNo, Paymentoption);

        //   int ListNo = Convert.ToInt32(ddldelegates.SelectedItem.Value);

        if (ListNo > 2)
        {
            trGD.Visible = true;
            trtot.Visible = true;
        }
        else
        {
            trGD.Visible = false;
            trtot.Visible = false;
        }
        txtDiscount.Text = "0";
        txtCoupon.Text = string.Empty;
        PriceUpdate();
    }

    protected void btnApply_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ddldelegates.SelectedItem.Value) > 0)
        {
            objCoupon.CoupanCode = txtCoupon.Text.Trim();
            decimal CouponValue = objCoupon.GetCoupanValue();
            if (CouponValue > 0)
            {
                divCoupon.Visible = true;

                txtDiscount.Text = Convert.ToString(Math.Round((Convert.ToDecimal(txtGross.Text.Trim()) * CouponValue) / 100));
                lblCouponMsg.Text = "";
            }
            else
            {
                txtDiscount.Text = "0";
                divCoupon.Visible = false;
                txtCoupon.Text = string.Empty;
                txtDiscount.Text = "0";
                txtNetAmount.Text = Convert.ToString(Convert.ToInt32(txtGross.Text) - Convert.ToInt32(txtDiscount.Text));
                txtServiceTax.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtNetAmount.Text) * 1500 / 10000));
                txtServiceTax.Text = "0";
                txtGrandTotal.Text = Convert.ToString(Convert.ToInt32(txtNetAmount.Text) + Convert.ToInt32(txtServiceTax.Text));
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SCRIPT", "alert('Invalid Coupon')", true);
                return;
                // lblCouponMsg.Text = "Invalid Coupon";
                // lblCouponMsg.ForeColor = System.Drawing.Color.Red;
            }

            txtNetAmount.Text = Convert.ToString(Convert.ToInt32(txtGross.Text) - Convert.ToInt32(txtDiscount.Text));
            txtServiceTax.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtNetAmount.Text) * 1500 / 10000));
            txtServiceTax.Text = "0";
            txtGrandTotal.Text = Convert.ToString(Convert.ToInt32(txtNetAmount.Text) + Convert.ToInt32(txtServiceTax.Text));
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SCRIPT", "alert('Please select No. of Delegates')", true);
            return;
        }

    }
}