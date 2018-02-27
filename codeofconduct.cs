using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SZAdminPanel.Common;

namespace SZAdminPanel.AdminMaster
{
    public partial class CodeofConduct : System.Web.UI.Page
    {
        public Int32 ForumId
        {
            get
            {
                if (ViewState["ForumId"] != null)
                    return (Int32)ViewState["ForumId"];
                else
                    return 0;
            }
            set
            {
                ViewState["ForumId"] = value;
            }

        }

        protected int COCId
        {
            get
            {
                if (ViewState["COCId"] == null)
                    return 0;
                else
                    return (int)ViewState["COCId"];
            }
            set
            {
                ViewState["COCId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    ForumId = Convert.ToInt32(Request.QueryString["Id"]);
                }
                if (ForumId != 0)
                {
                    GetForumList();
                    BindData();
                }
            }
        }

        protected void BindData()
        {
            UserBL objUserBL = new UserBL();
            DataTable dt = new DataTable();
            dt = GetCOC();
            if (dt != null && dt.Rows.Count > 0)
            {
                txtCodeOfconduct.Text = (DBNull.Value == dt.Rows[0]["CodeOfConduct"]) ? "" : dt.Rows[0]["CodeOfConduct"].ToString();
                chkIsActive.Checked = (DBNull.Value == dt.Rows[0]["Status"]) ? false : Convert.ToBoolean(dt.Rows[0]["Status"]);
            }
        }

        protected DataTable GetCOC()
        {
            try
            {
                DataTable dt = new DataTable();
                UserBL objUser = new UserBL();
                objUser.ForumId = ForumId;
                dt = objUser.GetCOC();
                return dt;
            }
            catch (Exception ex) { return null; }
        }

        protected void GetForumList()
        {
            UserBL objUser = new UserBL();
            DataTable ds = new DataTable();
            objUser.ForumId = ForumId;
            ds = objUser.GetForumDetails();
            if (ds != null && ds.Rows.Count > 0)
            {
                lblforumname.Text = ds.Rows[0]["ForumName"].ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            UserBL objUser = new UserBL();
            objUser.ForumId = ForumId;
            objUser.COC = txtCodeOfconduct.Text.Trim();
            objUser.IsActive = chkIsActive.Checked;
            int i = objUser.InsertUpdateCOC();
            if (i > 0)
            {
                clsCommon.PageAlert(Page, "Code of conduct added successfully.", "ViewForum.aspx");
            }
        }
    }
}
