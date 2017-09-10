using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using CashBrain.Models;

namespace CashBrain.DAL
{
    public class DLL
    {
        string conn = ConfigurationManager.ConnectionStrings["Connections"].ToString();

        public int InsertQuestion(AdminQuestion ADQAnswer)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            
            SqlCommand cmd = new SqlCommand("InsertQ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Question", ADQAnswer.Question);
            cmd.Parameters.AddWithValue("@choice1", ADQAnswer.Choice1);
            cmd.Parameters.AddWithValue("@choice2", ADQAnswer.Choice2);
            cmd.Parameters.AddWithValue("@choice3", ADQAnswer.Choice3);
            cmd.Parameters.AddWithValue("@choice4", ADQAnswer.Choice4);
            cmd.Parameters.AddWithValue("@CorrectAnswer", ADQAnswer.CorrectAnswers);
            int exec = Convert.ToInt32(cmd.ExecuteScalar());
            // sda.SelectCommand = cmd;
            // sda.Fill(dt);
            con.Close();
            return exec;
        }

        public List<AdminQuestion> Selectalldata()
        {
            SqlConnection con = null;

            DataSet ds = null;
            List<AdminQuestion> custlist = null;
            try
            {
                con = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand("GetAllRecord", con);
                cmd.CommandType = CommandType.StoredProcedure;                
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                custlist = new List<AdminQuestion>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    AdminQuestion cobj = new AdminQuestion();
                    cobj.ID = Convert.ToString(ds.Tables[0].Rows[i]["id"].ToString());
                    cobj.Question = Convert.ToString(ds.Tables[0].Rows[i]["Question"].ToString());
                    cobj.Choice1 = Convert.ToString(ds.Tables[0].Rows[i]["Choice1"].ToString());
                    cobj.Choice2 = Convert.ToString(ds.Tables[0].Rows[i]["Choice2"].ToString());
                    cobj.Choice3 = Convert.ToString(ds.Tables[0].Rows[i]["Choice3"].ToString());
                    cobj.Choice4 = Convert.ToString(ds.Tables[0].Rows[i]["Choice4"].ToString());
                    cobj.CorrectAnswers = Convert.ToString(ds.Tables[0].Rows[i]["CorrectAnswer"].ToString());

                    custlist.Add(cobj);
                }
                return custlist;
            }
            catch
            {
                return custlist;
            }
            finally
            {
                con.Close();
            }
        }

    }
}