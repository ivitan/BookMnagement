﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class addBook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] != null)
        {
            string _id = Session["user"].ToString();
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int i = -1;
        string str_connection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=";
        string str_sourcefile = MapPath("~/db/book.mdb");
        OleDbConnection cnn;
        OleDbCommand cmd;

        string str_conn = str_connection + str_sourcefile;
        cnn = new OleDbConnection(str_conn);



        string sql = "insert into 书籍表(书籍编号,书籍名称,书籍封面图,书籍价格,出版社,出版时间,主编作者,书籍类别) values('" + bh.Text + "','" + mc.Text + "','" + fm.Text + "','" + jg.Text + "','" + cbs.Text + "','" + date.Text + "','" + zz.Text + "','" + lb.Text + "')";

        Response.Write(sql);
        cnn.Open();
        cmd = new OleDbCommand(sql, cnn);

        try { i = cmd.ExecuteNonQuery(); }

        catch (OleDbException)
        {

        }

        cnn.Close();
        if (i == 1)
        {

            // but2.Visible = true; 
            Response.Write("<script>alert('添加书籍成功!')</script>");

            // Response.Redirect("denglu.aspx");
        }

        else if (i < 1)
        {
            Response.Write("<script>alert('出错啦，检查一下吧!')</script>");

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin.aspx");
    }
}