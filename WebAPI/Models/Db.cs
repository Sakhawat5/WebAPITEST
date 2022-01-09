using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ViewModel;

namespace WebAPI.Models
{
    public class Db
    {
        SqlConnection conn = new SqlConnection("Data Source=SADMAN-PC;Initial Catalog=HRMS;Trusted_Connection=True;MultipleActiveResultSets=true");
        

        public string EmployeeDetails(EmployeeDetails emp)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand aCommand = new SqlCommand("Sp_Employee", conn);
                aCommand.CommandType = CommandType.StoredProcedure;
                //aCommand.Parameters.AddWithValue("@EmpCode", emp.EmpName);
                aCommand.Parameters.AddWithValue("@EmpCode", emp.EmpCode);
                aCommand.Parameters.AddWithValue("@EmpName", emp.EmpName);
                aCommand.Parameters.AddWithValue("@Gender", emp.Gender);
                aCommand.Parameters.AddWithValue("@Mobile", emp.Mobile);
                aCommand.Parameters.AddWithValue("@DesignationId", emp.Name);
                aCommand.Parameters.AddWithValue("@SalaryId", emp.Amount);
                aCommand.Parameters.AddWithValue("@type", emp.Type);
                conn.Open();
                aCommand.ExecuteNonQuery();
                conn.Close();
                msg = "Successfully";
            }
            catch (global::System.Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if(conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return msg;
        }

        //Get Recoard
        public DataSet GetEmployee(Employee emp, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand aCommand = new SqlCommand("Sp_Employee", conn);
                aCommand.CommandType = CommandType.StoredProcedure;
                //aCommand.Parameters.AddWithValue("@EmpCode", emp.EmpName);
                aCommand.Parameters.AddWithValue("@EmpCode", emp.EmpCode);
                aCommand.Parameters.AddWithValue("@EmpName", emp.EmpName);
                aCommand.Parameters.AddWithValue("@Gender", emp.Gender);
                aCommand.Parameters.AddWithValue("@Mobile", emp.Mobile);
                aCommand.Parameters.AddWithValue("@DesignationId", emp.DesignationId);
                aCommand.Parameters.AddWithValue("@SalaryId", emp.SalaryId);
                aCommand.Parameters.AddWithValue("@type", emp.Type);
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
        //Get Recoard
        public DataSet GetEmployeeDetails(EmployeeDetails emp, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand aCommand = new SqlCommand("Sp_Employee", conn);
                aCommand.CommandType = CommandType.StoredProcedure;
                //aCommand.Parameters.AddWithValue("@EmpCode", emp.EmpName);
                aCommand.Parameters.AddWithValue("@EmpCode", emp.EmpCode);
                aCommand.Parameters.AddWithValue("@EmpName", emp.EmpName);
                aCommand.Parameters.AddWithValue("@Gender", emp.Gender);
                aCommand.Parameters.AddWithValue("@Mobile", emp.Mobile);
                aCommand.Parameters.AddWithValue("@DesignationId", emp.Name);
                aCommand.Parameters.AddWithValue("@SalaryId", emp.Amount);
                aCommand.Parameters.AddWithValue("@type", emp.Type);
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

        public DataTable SelectAll(string procName, SqlParameter[] para = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = conn)
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(procName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (para != null)
                            cmd.Parameters.AddRange(para);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {

                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception sqlEx)
            {
                Console.WriteLine(@"：Unable to establish a connection: {0}", sqlEx);
            }

            return dt;

        }
    }
}
