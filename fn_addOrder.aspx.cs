using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using OfficeOpenXml;

namespace POQualityCheck
{
    public partial class fn_addOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadDRBSupplier();
            }

            if (IsPostBack && fu_upload.HasFile)
            {
                if (Path.GetExtension(fu_upload.FileName).Equals(".xlsx"))
                {

                    var excel = new ExcelPackage(fu_upload.FileContent);
                    var dt = excel.ToDataTable();

                    string constr = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
                    using (var con = new SqlConnection(constr))
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            using (SqlCommand cmd = new SqlCommand("sp_import_order"))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@ORDERNO", txt_orderNo.Text);
                                cmd.Parameters.AddWithValue("@INVOICENO", txt_invoiceNo.Text);
                                cmd.Parameters.AddWithValue("@DATE", txt_date.Text);
                                cmd.Parameters.AddWithValue("@SUPPLIER", drb_supplier.SelectedValue.ToString());
                                cmd.Parameters.AddWithValue("@ITEMNO", dr["Item number"].ToString());
                                cmd.Parameters.AddWithValue("@NAME", dr["Name"].ToString());
                                cmd.Parameters.AddWithValue("@ORDERQTY", dr["Order qty"].ToString());
                                cmd.Parameters.AddWithValue("@UM", dr["U/M"].ToString());
                                cmd.Parameters.AddWithValue("@DESCRIPTION", dr["Description 2"].ToString());
                                cmd.Connection = con;
                                con.Open();
                                SqlDataReader reader = cmd.ExecuteReader();
                                reader.Close();
                                con.Close();
                            }
                        }
                    }
                }
            }
        }

        private void LoadDRBSupplier()
        {
            string constr = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
            DataTable dt_supplier = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT ID, Name FROM TBL_SUPPLIER", con);
                    sda.Fill(dt_supplier);
                    drb_supplier.DataSource = dt_supplier;
                    drb_supplier.DataValueField = "ID";
                    drb_supplier.DataTextField = "Name";
                    drb_supplier.DataBind();
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }
            }
        }

        protected void btn_getDate_Click(object sender, EventArgs e)
        {
            txt_date.Text = DateTime.Today.ToString().Substring(0,10);
        }
    }
}