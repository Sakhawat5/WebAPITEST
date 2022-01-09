using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class EmpDb
    {
        SqlConnection conn = new SqlConnection("Data Source=SADMAN-PC;Initial Catalog=HRMS;Trusted_Connection=True;MultipleActiveResultSets=true");

        public string EmployeeDetails(Employees emp)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand aCommand = new SqlCommand("tbl_Employees", conn);
                aCommand.CommandType = CommandType.StoredProcedure;
                aCommand.Parameters.AddWithValue("@ID", emp.ID);
                aCommand.Parameters.AddWithValue("@Email", emp.Email);
                aCommand.Parameters.AddWithValue("@Emp_Name", emp.Emp_Name);
                aCommand.Parameters.AddWithValue("@Designation", emp.Designation);
                aCommand.Parameters.AddWithValue("@type", emp.type);
                conn.Open();
                aCommand.ExecuteNonQuery();
                conn.Close();
                msg = "Successfully";
            }
            catch (Exception ex)
            {

                msg = ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return msg;
        }

        //Get Recoard
        public DataSet EmployeeDetailsGet(Employees emp, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand aCommand = new SqlCommand("tbl_Employees", conn);
                aCommand.CommandType = CommandType.StoredProcedure;
                //aCommand.Parameters.AddWithValue("@EmpCode", emp.EmpName);
                aCommand.Parameters.AddWithValue("@ID", emp.ID);
                aCommand.Parameters.AddWithValue("@Email", emp.Email);
                aCommand.Parameters.AddWithValue("@Emp_Name", emp.Emp_Name);
                aCommand.Parameters.AddWithValue("@Designation", emp.Designation);
                aCommand.Parameters.AddWithValue("@type", emp.type);
                SqlDataAdapter da = new SqlDataAdapter(aCommand);
                da.SelectCommand = aCommand;
                da.Fill(ds);
                msg = "Successfully";
            }
            catch (global::System.Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
    }
}
