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
                                cmd.Parameters.AddWithValue("@OrderNo", dr["orderNo"].ToString());
                                cmd.Parameters.AddWithValue("@OrderQty", dr["orderQty"].ToString());
                                cmd.Parameters.AddWithValue("@ShipmentDate", dr["shipmentDate"].ToString());
                                cmd.Parameters.AddWithValue("@UnitOfMeasure", dr["unitOfMeasure"].ToString());
                                cmd.Parameters.AddWithValue("@Customer", dr["customer"].ToString());
                                cmd.Parameters.AddWithValue("@Spalva", dr["Spalva"].ToString());
                                cmd.Parameters.AddWithValue("@Spyna", dr["Spyna"].ToString());
                                cmd.Parameters.AddWithValue("@Vyris", dr["Vyris"].ToString());
                                cmd.Parameters.AddWithValue("@Plotis", dr["Plotis"].ToString());
                                cmd.Parameters.AddWithValue("@GaminioTipas", dr["Gaminio_Tipas"].ToString());
                                cmd.Parameters.AddWithValue("@EXTRA1", dr["EXTRA_1"].ToString());
                                cmd.Parameters.AddWithValue("@EXTRA2", dr["EXTRA_2"].ToString());
                                cmd.Parameters.AddWithValue("@EXTRA3", dr["EXTRA_3"].ToString());
                                cmd.Parameters.AddWithValue("@EXTRA4", dr["EXTRA_4"].ToString());
                                cmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
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
    }
}