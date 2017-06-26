using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

public partial class _Default : System.Web.UI.Page
{
    string cnstr = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                    "AttachDbFilename=|DataDirectory|LOLDB.mdf;" +
                    "Integrated Security=True";

    // 定義ShowData()方法將聯盟資料表對應的所有記錄顯示於flowLayoutPanel1上
    void ShowData(string selectCmd)
    {
        using (SqlConnection cn = new SqlConnection())
        {
            cn.ConnectionString = cnstr;
            cn.Open();  // 連接資料庫
                        // 建立SqlCommand物件cmd
            SqlCommand cmd = new SqlCommand(selectCmd, cn);
            // 傳回查詢結果的SqlDataRadedr物件dr
            SqlDataReader dr = cmd.ExecuteReader();
            int x = 30, y = 50;
            while (dr.Read())
            {
                string ENname = dr["英文名稱"].ToString();
                System.Web.UI.WebControls.ImageButton img;
                img = new System.Web.UI.WebControls.ImageButton();
                img.Height = 100;
                img.Width = 100;
                img.ID = ENname;
                img.ImageUrl = "~/LOL/" + ENname + ".png";
                img.Click += new ImageClickEventHandler(img_Click);
                Label lb = new Label();
                lb.Text = dr["英雄名稱"].ToString();
                Panel pl = new Panel();
                pl.Width = 101;
                pl.Height = 130;
                pl.Controls.Add(img);
                pl.Controls.Add(lb);
                pl.HorizontalAlign = HorizontalAlign.Center;
                pl.Attributes.Add("style", "position:absolute;left:" + x + "px;top:" + y + "px");
                Panel1.Controls.Add(pl);
                if (x < 1300) x = x + 120;
                else
                {
                    x = 30;
                    y = y + 140;
                }
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        using (SqlConnection cn = new SqlConnection())
        {
            cn.ConnectionString = cnstr;
            cn.Open();  // 連接資料庫

            string selectCmd = "SELECT * FROM 聯盟";

            Panel1.Controls.Clear();

            ShowData(selectCmd);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //flowLayoutPanel1.Controls.Clear();
        Panel1.Controls.Clear();

        using (SqlConnection cn = new SqlConnection())
        {
            cn.ConnectionString = cnstr;
            cn.Open();  // 連接資料庫
                        // 將輸入的姓名指定給searchName字串變數
            string searchName = textBox1.Text;
            // SELECT敘述的查詢條件為姓名等於searchName
            string selectCmd = "SELECT * FROM 聯盟 WHERE (英雄名稱 LIKE N'" + "%" + searchName + "%')";
            
            ShowData(selectCmd);
        }
    }

    protected void Check_Clicked(object sender, EventArgs e)
    {
        string chkStr = "";
        Panel1.Controls.Clear();
        //flowLayoutPanel1.Controls.Clear();

        if (chkAssassin.Checked) chkStr += chkAssassin.Text;
        if (chkTank.Checked) chkStr += chkTank.Text;
        if (chkMaster.Checked) chkStr += chkMaster.Text;
        if (chkAid.Checked) chkStr += chkAid.Text;
        if (chkFighters.Checked) chkStr += chkFighters.Text;
        if (chkArcher.Checked) chkStr += chkArcher.Text;

        using (SqlConnection cn = new SqlConnection())
        {
            cn.ConnectionString = cnstr;
            cn.Open();  // 連接資料庫
            string selectCmd = "SELECT * FROM 聯盟 WHERE (英雄類別 LIKE N'" + "%" + chkStr + "%')";
            
            ShowData(selectCmd);
        }
    }

    protected void img_Click(object sender, ImageClickEventArgs e)
    {
        // 將sender轉型成PictureBox
        ImageButton img = (ImageButton)sender;
        if (null == img) return;
        // 取出pictureBox的名稱
        string name = img.ID;
        // 以下就你讀取到的名稱去處理你要做的事情
        Response.Redirect("https://lol.garena.tw/game/champion/" + name);
    }
}