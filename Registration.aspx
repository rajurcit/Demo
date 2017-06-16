<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta name="description" content="Register for Asia’s Largest Content Marketing Summit Asia. Attractive prices. Group Discounts Available." />
<meta name="keywords" content="CMS Asia tickets, CMS Asia Registration, Content Marketing Summit Asia tickets." />

    <link href="css/register.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">   
    <div class="inner-contact">
  <section>
        <div class="container">
               <div class="row">
                    <div class="col-md-12">
                                <h1><span>Register </span></h1>
                                <p>Please fill in the details below to start your registration process.</p>
                     </div>
              </div> 
               <div class="row form-contact">
                    <div class="row">
                    <asp:ValidationSummary ID="WritersValidationSummary" ValidationGroup="Register" runat="server" Style="color: red;"></asp:ValidationSummary>
                    <asp:ValidationSummary ID="DelegateSummary" ValidationGroup="VGDelegate" runat="server" Style="color: red;"></asp:ValidationSummary>
                     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                   </div>
                      <div class="row" style="display:none;">
                        <div class="col-md-12">                      
                       <p><strong>I'm interested as:</strong></p>
                       <asp:RadioButtonList ID="rdoUserType" runat="server" RepeatColumns="5"
                                CellPadding="0" CellSpacing="0" CssClass="interested pull-left"
                                OnSelectedIndexChanged="rdoUserType_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="DELEGATE" Selected="True" Value="Delegate"></asp:ListItem>                               
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="REFV1" runat="server" ControlToValidate="rdoUserType" Display="None" ValidationGroup="Register" ErrorMessage="Please Select Any Interest Group"></asp:RequiredFieldValidator>

                        </div> 

                      </div> 
                      <div class="row">
                         <div class="col-md-12">
                                <asp:MultiView ID="MVRegistration" runat="server">
                                    <asp:View ID="ViewOthers" runat="server">                                            
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                            <asp:TextBox ID="txtName" runat="server" type="name" class="form-control inpt1" placeholder="Name"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="REV" ValidationExpression="[a-zA-Z' ']{5,}" runat="server"
                                            ErrorMessage="Please enter your Name" ControlToValidate="txtName" Display="Dynamic"  ValidationGroup="Register">
                                            </asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RFVName" runat="server" ErrorMessage="Please enter your Name" ControlToValidate="txtName" Display="Dynamic" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtEmail" runat="server" type="email" class="form-control inpt1" placeholder="Email Id"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFVEmail" runat="server" ControlToValidate="txtEmail" Display="None" ErrorMessage="Please enter your Email Id" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RFVEmail1" runat="server" ErrorMessage="Please enter correct Email Id" ControlToValidate="txtEmail" Display="None" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Register"></asp:RegularExpressionValidator>
                                        </div>
                                      </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtCompany" runat="server" type="name" class="form-control inpt1" placeholder="Company"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RFVCompany" runat="server" ErrorMessage="Please enter your Company" ControlToValidate="txtCompany" Display="None" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtPhone" runat="server" type="Num" class="form-control inpt1" placeholder="Phone / Mobile" MaxLength="15" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RFVPhone" runat="server" ErrorMessage="Please enter your Phone" ControlToValidate="txtPhone" Display="None" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                      
                                    </div>
                                </div>
                            </div>
                            <div id="divMedia" runat="server" class="row mtop20">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="black18">Your social media links</label>
                                        <asp:TextBox ID="txtTwitterLink" runat="server" class="form-control inpt1" placeholder="Twitter Link" MaxLength="150"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RFVTwitter" runat="server" ErrorMessage="Please enter twitter link" ControlToValidate="txtTwitterLink" Display="None" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="REV1" runat="server"
                                            ControlToValidate="txtTwitterLink" ErrorMessage="Please enter correct twitter link"
                                            ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?" Display="None" ValidationGroup="Register"></asp:RegularExpressionValidator>

                                        (Ex: http://www.twitter.com)
                                    </div>
                                </div>
                                <div class="col-md-6 mtN30">
                                    <div class="form-group">
                                        <label class="black18">&nbsp;</label>
                                        <asp:TextBox ID="txtLinkedLink" runat="server" class="form-control inpt1" placeholder="LinkedIn Link" MaxLength="150"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RFVLinkedin" runat="server" ErrorMessage="Please enter linkedin link" ControlToValidate="txtLinkedLink" Display="None" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="REV2" runat="server"
                                            ControlToValidate="txtLinkedLink" ErrorMessage="Please enter correct linkedin link"
                                            ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?" Display="None" ValidationGroup="Register"></asp:RegularExpressionValidator>
                                        (Ex: http://www.linkedin.com)
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="inputEmail1" class="col-md-6 control-label black18 L0">
                                            Enter the code  in the box</label>
                                        <div class="col-md-3 p0">
                                            <img src="Includes/JpegImage.aspx" style="height: 34px" /></div>
                                        <div class="col-md-3 p0">
                                            <asp:TextBox ID="CaptchaTextBox" autocomplete="off" MaxLength="6" BackColor="Transparent" BorderWidth="1" ForeColor="black" runat="server" class="form-control inpt1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFVCaptcha" runat="server" ControlToValidate="CaptchaTextBox" Display="None" ErrorMessage="Please enter captcha code" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </div>

                             <div class="row">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary btn-lg register button2" OnClick="btnSubmit_Click" ValidationGroup="Register"></asp:Button>

                            </div>
                            <div class="row mtop40">
                                <div class="col-md-4">
                                    <address class="black16">
                                        <div><strong class="black18">Address</strong></div>
                                        A 12/3, 1<sup>st</sup> Floor, Phase -I, Naraina Industrial Area,<br />
                                        New Delhi 110028, INDIA<br>

                                        <address>     </address>

                                        <address></address>

                                        <address>             </address>

                                        <address>   </address>

                                    </address>
                                </div>
                                <div class="col-md-4">
                                    <aside class="black16">
                                        <strong class="black18">Phone:</strong><br />
                                        <%-- +91-11-45768112 (8 Lines)</aside></div>--%>
                                        <span itemprop="telephone">+91-11-49194919</span>
                                        <br />
                                        +91-96541 48471
                                    </aside>
                                </div>
                                <div class="col-md-4">
                                    <aside class="black16">
                                        <strong class="black18">Email:</strong><br />
                                        Nalini Kher<br />
                                        <a href="mailto:admin@contentmarketingsummit.org" class="black16"><span itemprop="email">admin@contentmarketingsummit.org</span></a><br />
                                    </aside>
                                </div>
                            </div>
                        </asp:View>

                                    <asp:View ID="ViewDelegates" runat="server">                                    
                                            <div class="row">
                                                <div class="col-md-2"><span class="black18 mRgt10 block">No. of Delegates</span></div>
                                                <div class="col-md-2">
                                                    <asp:DropDownList ID="ddldelegates" runat="server" CssClass="form-control sel"
                                                        OnSelectedIndexChanged="ddldelegates_SelectedIndexChanged" AutoPostBack="true">
                                                        <asp:ListItem Text="Please Select" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                        <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                                        <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                                        <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RFVNoOfDelegate" runat="server" InitialValue="0" ControlToValidate="ddldelegates" Display="Dynamic" ErrorMessage="Please select No. of Delegates" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-3" style="display:none;">
                                                    <span class="black18 mRgt10 block">Payment Options</span>
                                                    <asp:RadioButtonList ID="rdoPaymentoption" runat="server" CssClass="interested"
                                                        OnSelectedIndexChanged="rdoPaymentoption_SelectedIndexChanged" AutoPostBack="true" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Credit Card / Net Banking" Value="1" Selected="True"></asp:ListItem>
                                                        <%-- <asp:ListItem Text="Cheque / DD" Value="2"></asp:ListItem>--%>
                                                        <%--<asp:ListItem Text="Bank Transfer" Value="3"></asp:ListItem>--%>
                                                    </asp:RadioButtonList>
                                                    <asp:RequiredFieldValidator ID="RFVNoOfPaymentOptions" runat="server" ControlToValidate="rdoPaymentoption" Display="None" ErrorMessage="Please select Payment Options" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                                </div>
                                               <%-- <div class="col-md-5">
                                                    <div class="row discountrow">
                                                        <div class="col-xs-6 text-center"><span class="discountspn1"><u><a href="student-registration.aspx" style="text-decoration: none;">50% Student Discount
                                                            <br />
                                                            Click here</a></u></span></div>
                                                        <div class="col-xs-6 text-center"><span class="discountspn2"><a href="offline-payment.aspx" style="text-decoration: none;"><u>Offline Payment?
                                                            <br />
                                                            Click here</u></a></span> </div>
                                                    </div>
                                                </div>--%>
                                            </div>  
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <div class="mtop40">
                                                    <table class="table size34 cbrd">
                                                        <thead>
                                                            <tr>
                                                                <td><strong><span id="SpanA1" runat="server" class="black24 black18"><%--Early Bird--%> Special Startup Discount</span><br />
                                                                    <span id="SpanA2" runat="server" class="size14 black14">Till
                                                                        <asp:Literal runat="server" ID="LitearlyBirddate"></asp:Literal>
                                                                        (For startups not older than 3 years as of 30 April 2017) </span></strong></td>
                                                                <td align="center" id="SpanA3" runat="server" class="black34 conference">
                                                                    <div class="psRel">
                                                                        <div class="chead black14 size11">
                                                                            <strong>Registration Fee</strong>
                                                                        </div>
                                                                    </div>
                                                                    <asp:RadioButton ID="rdoEarlyBirdA" GroupName="Plan" runat="server" OnCheckedChanged="RBPlan_CheckedChanged" AutoPostBack="true" ValidationGroup="Plan" />
                                                                    <span >$</span><asp:Literal ID="ltrEarlyBirdA" runat="server"></asp:Literal></td>

                                                                <td style="display: none;" align="center" id="SpanA4" runat="server" class="black34  conference">
                                                                    <div class="psRel">
                                                                        <div class="chead black14 chead2 size11">
                                                                            <strong>Full Conference</strong>
                                                                        </div>
                                                                    </div>
                                                                    <asp:RadioButton ID="rdoEarlyBirdB" GroupName="Plan" runat="server" OnCheckedChanged="RBPlan_CheckedChanged" AutoPostBack="true" ValidationGroup="Plan" />
                                                                    <span >$</span><asp:Literal ID="ltrEarlyBirdB" runat="server"></asp:Literal></td>
                                                            </tr>

                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td><strong><span id="SpanC1" runat="server" class="black24 lgrey black18">Special Price</span><br />
                                                                    <span id="SpanC2" runat="server" class="size14 black14 lgrey">
                                                                      <asp:Literal runat="server" ID="litDate"></asp:Literal>
                                                                    </span></strong></td>
                                                                <td id="SpanC3" runat="server" align="center">
                                                                    <asp:RadioButton ID="rdoAdvanceA" GroupName="Plan" runat="server" OnCheckedChanged="RBPlan_CheckedChanged" AutoPostBack="true" ValidationGroup="Plan" />
                                                                    <span >$</span><asp:Literal ID="ltrAdvanceA" runat="server"></asp:Literal></td>
                                                                <td style="display: none;" id="SpanC4" runat="server" align="center" class="brdRN">
                                                                    <asp:RadioButton ID="rdoAdvanceB" GroupName="Plan" runat="server" OnCheckedChanged="RBPlan_CheckedChanged" AutoPostBack="true" ValidationGroup="Plan" />
                                                                    <span class="rupee">$</span><asp:Literal ID="ltrAdvanceB" runat="server"></asp:Literal></td>

                                                                <tr>
                                                                    <td><strong><span id="SpanB1" runat="server" class="black24 lgrey black18">On Spot</span><br />
                                                                        <span id="SpanB2" runat="server" class="size14 black14 lgrey">
                                                                            <%--From Sep. 1, 2016--%></span></strong></td>
                                                                    <td id="SpanB3" runat="server" align="center">
                                                                        <asp:RadioButton ID="rdoRegularA" GroupName="Plan" runat="server" OnCheckedChanged="RBPlan_CheckedChanged" AutoPostBack="true" ValidationGroup="Plan" />
                                                                        <span >$</span><asp:Literal ID="ltrRegularA" runat="server"></asp:Literal></td>
                                                                    <td style="display: none;" id="SpanB4" runat="server" align="center" class="brdRN">
                                                                        <asp:RadioButton ID="rdoRegularB" GroupName="Plan" runat="server" OnCheckedChanged="RBPlan_CheckedChanged" AutoPostBack="true" ValidationGroup="Plan" />
                                                                        <span class="rupee" style="display: none;">`</span><asp:Literal ID="ltrRegularB" runat="server"></asp:Literal></td>
                                                                </tr>                                                            
                                                        </tbody>
                                                    </table>
                                                </div>
                                                <div class="mtop20 LH24 row">
                                                    <div class="col-md-8">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td colspan="2"  align="left" valign="top"><strong>Group Booking Discount</strong><br />
                                                                    10% Discount on 3 or 4 members(No Coupon Code Required)<br />
                                                                    15% Discount on 5 or more members(No Coupon Code Required) </td>

                                                            </tr>
                                                            <tr>
                                                                <td >
                                                                    <strong>Coupon Code</strong> &nbsp;&nbsp;
                                                                    <asp:TextBox ID="txtCoupon" runat="server" MaxLength="10" CssClass="inpt1"></asp:TextBox>                                                                    <%--&nbsp;&nbsp; --%>
                                                                     <br />(Only one discount option would be applicable)                                                                   
                                                                </td>
                                                                <td align="left">
                                                                     <asp:Button ID="btnApply" runat="server" Text="Apply"  ValidationGroup="Coupon" CssClass="btn reg" OnClick="btnApply_Click"></asp:Button>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                     <asp:Label ID="lblCouponMsg" runat="server" Text=""></asp:Label>
                                                                    <asp:RequiredFieldValidator ID="RFVCoupon" runat="server" ControlToValidate="txtCoupon" Display="Dynamic" ErrorMessage="Enter coupon code" ValidationGroup="Coupon"></asp:RequiredFieldValidator>
                                                                
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <table cellspacing="0" cellpadding="0" class="total" align="right">
                                                            <tr runat="server" id="trtot">
                                                                <td valign="top" align="right"><b>Total</b></td>
                                                                <td valign="top" align="right">
                                                                    <asp:TextBox ID="txtTotal" runat="server" Enabled="false" Style="text-align: right" class="inpt1"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" id="trGD">
                                                                <td valign="top" align="right"><b>
                                                                    <asp:Label ID="lblGDiscount" runat="server" Text="Group Discount"></asp:Label></b></td>
                                                                <td valign="top" align="right">
                                                                    <asp:TextBox ID="txtGroupDiscount" runat="server" Enabled="false" Style="text-align: right" class="inpt1"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <div id="divCoupon" runat="server" visible="false">
                                                                <tr runat="server" id="tr1">
                                                                    <td valign="top" align="right"><b>
                                                                        <asp:Label ID="lblGross" runat="server" Text="Gross"></asp:Label></b></td>
                                                                    <td valign="top" align="right">
                                                                        <asp:TextBox ID="txtGross" runat="server" Enabled="false" Style="text-align: right" class="inpt1"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr runat="server" id="tr2">
                                                                    <td valign="top" align="right"><b>
                                                                        <asp:Label ID="lblDiscount" runat="server" Text="Discount"></asp:Label></b></td>
                                                                    <td valign="top" align="right">
                                                                        <asp:TextBox ID="txtDiscount" runat="server" Enabled="false" Style="text-align: right" class="inpt1"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </div>
                                                            <tr>
                                                                <td valign="top" align="right"><b>Net</b></td>
                                                                <td valign="top" align="right">
                                                                    <asp:TextBox ID="txtNetAmount" runat="server" Enabled="false" Style="text-align: right" class="inpt1"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr style="display: none;">
                                                                <td valign="top" align="right"><b>Service Tax @ 15.00%</b></td>
                                                                <td valign="top" align="right">
                                                                    <asp:TextBox ID="txtServiceTax" runat="server" Enabled="false" Style="text-align: right" class="inpt1"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" align="right"><b>Grand Total</b></td>
                                                                <td valign="top" align="right">
                                                                    <asp:TextBox ID="txtGrandTotal" runat="server" Enabled="false" Style="text-align: right" class="inpt1"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        
                                        <asp:PlaceHolder ID="PHDelegate" runat="server"></asp:PlaceHolder>                        

                                            <div class="row">
                                                        <div class="col-md-4 regcapcha">
                                                            <p><strong>Enter the code in the box</strong><img src="Includes/JpegImage.aspx" style="height: 34px" /> </p>
                                                        </div>                                                  
                                                   <div class="col-md-8"> <asp:TextBox ID="CaptchaTextBox2"  autocomplete="off" MaxLength="6" Width="110px" BackColor="Transparent" BorderWidth="1" ForeColor="black" runat="server" class="form-control regcapcha-text" ></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RFVCaptcha2" runat="server" ControlToValidate="CaptchaTextBox2" Display="Dynamic" ErrorMessage="Please enter captcha code" ValidationGroup="Register" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>                                           
                                                    </div>  
                                            <div class="row"> 
                                            <div class="col-md-12" >
                                                <div class="checkbox">
                                                    <label>
                                                        <asp:CheckBox ID="chktnc" Checked="true" Enabled="false" runat="server"></asp:CheckBox>
                                                        I agree with the <a href="tc.aspx" target="_blank" class="black14">Terms and Conditions</a>.                 
                                                    </label>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="mtop20" style="align:left;">
                                            <asp:Button ID="btnSubmit1" runat="server" Text="Submit" 
                                                 ValidationGroup="Register" CssClass="btn submit"
                                                OnClick="btnSubmit1_Click"></asp:Button>

                                        </div>
                                    </asp:View>
                                </asp:MultiView>
          </div> 
                          </div> 
              </div> 
        </div>

</section> 
                </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cntBdyscrip" Runat="Server">
      

     <script language="javascript" type="text/javascript">

         function changeCursor(ddl) {
             $("#hdnDelegate").val(ddl.selectedIndex);
             
         }

        function CheckAgeGroup(sender, args) {
            var options = document.getElementById('chkAutomotive').getElementsByTagName('input');
            var ischecked = false;
            args.IsValid = false;
            for (i = 0; i < options.length; i++) {
                var opt = options[i];
                if (opt.type == "checkbox") {
                    if (opt.checked) {
                        ischecked = true;
                        args.IsValid = true;
                    }
                }
            }
        }
    </script>

    <script type="text/javascript">
        window.scrollTo = function (x, y) {
            return true;
        }
    </script>

    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
      m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-45124687-1', 'contentmarketingsummit.org');
        ga('send', 'pageview');

    </script>
    <script type="text/javascript">

            debugger;
            // Get id of dropdownlist
            var parm = document.getElementById("ContentPlaceHolder1_ddldelegates");
            // Get Dropdownlist selected item text

            var a = parm.options[parm.selectedIndex].value;
            if (a <= 0) {
                $("#tnc").hide();

            }
            else {
                $("#tnc").show();
            }

        </script>
</asp:Content>
