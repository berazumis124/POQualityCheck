using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace POQualityCheck
{
    public partial class fn_orderline : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string orderNo = Request.QueryString["id"];
                if (orderNo != null)
                {
                    fillPlaceHolder(orderNo);
                    Session["orderno"] = orderNo;
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
            
        }

        private DataTable getData(string orderNo)
        {
            string constr = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT L.ID, L.ItemNumber, L.Name, L.OrderQty, L.UnitOfMeasure, L.isChecked FROM tbl_OrderLine L, tbl_OrderHeader H WHERE L.OrderHeaderID = H.ID and H.OrderNo = '"+ orderNo +"'", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        private void fillPlaceHolder(string orderNo)
        {
            DataTable dt = getData(orderNo);
            StringBuilder html = new StringBuilder();

            //html.Append("<table class='table'>");
            //html.Append("<tr>");

            //foreach (DataColumn column in dt.Columns)
            //{
            //    html.Append("<th>");
            //    html.Append(column.ColumnName);
            //    html.Append("</th>");
            //}
            //html.Append("</tr>");

            //foreach (DataRow row in dt.Rows)
            //{
            //    if (row["isChecked"].ToString() == "0")
            //    {
            //        html.Append("<tr class='notChecked'>");
            //    } else
            //    {
            //        html.Append("<tr class='isChecked'>");
            //    }
                
            //    foreach (DataColumn column in dt.Columns)
            //    {
            //        html.Append("<td><a href=fn_processQty.aspx?LID=" + row["ID"] + "&type=0>");
            //        html.Append(row[column.ColumnName]);
            //        html.Append("</a></td>");
            //    }
            //    html.Append("</tr>");
            //}
            //html.Append("</table>");
            foreach (DataRow row in dt.Rows)
            {
                if (row["isChecked"].ToString() == "0")
                {
                    html.Append("<a href=fn_processQty.aspx?LID=" + row["ID"] + "&type=0><div class='orderline_notChecked'>");
                } else
                {
                    html.Append("<a href=fn_processQty.aspx?LID=" + row["ID"] + "&type=0><div class='orderline_isChecked'>");
                }

                foreach (DataColumn column  in dt.Columns)
                {
                    html.Append("<span class='orderlineelement'>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</span>");
                }
                html.Append("</div></a>");
            }
            ph_orderlines.Controls.Add(new Literal { Text = html.ToString() });
        }

        protected void btn_finish_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
            using (var con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_order_checked"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ORDERNO", Session["orderno"].ToString());
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    con.Close();
                    Response.Redirect("Default.aspx");
                }
            }
        }
    }
}