using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POQualityCheck
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txt_orderno.Focus();
        }

        protected void btn_orderlines_Click(object sender, EventArgs e)
        {
            if (txt_orderno.Text != "")
            {
                Response.Redirect("fn_orderline.aspx?id=" + txt_orderno.Text);
            }
        }
    }
}