﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StagPj
{
    public partial class HomePage : System.Web.UI.Page
    {
        private Action A;
        private string _name;

        void SponeNewEvent(string lbName, string cont, string htmlString,string monSfx)
        {
            this._name = lbName;

            var Tname = new Label();
            Tname.Text = cont + monSfx;

            timeText.Visible = true;
            timeText.Controls.Add(Tname);
            timeText.Controls.Add(new LiteralControl(htmlString));          

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            A = new Action();
            if (!(A.ModifID == ""))
            {
                A.ModifID = "";
            }

            dayText.Text = DateTime.Now.ToString("dd");
            monthText.Text = DateTime.Now.Date.ToString("MMMM");
            Label3.Text = "Today";
            Label4.Text = "1" + "Event";

            timeText.Visible = false;

            new Connexion();
            Connexion.Con.Open();

            System.Data.SqlClient.SqlCommand cmd = new SqlCommand("select * from dbo.action" +
                                                                  " where C_id = 'F7C64F98-2495-4DAE-9387-3F2E9E9A7BB6'",
                Connexion.Con);
            System.Data.SqlClient.SqlDataReader rd;
            rd = cmd.ExecuteReader();

            
            while (rd.Read())
            {
                timeText.Controls.Add(new LiteralControl("<div class=" + "Event" + ">"));
                string _time;
                SponeNewEvent("prixLabel", rd["Prix"].ToString(), " "," DH");

                _time = rd["Time"].ToString().Split(' ')[1];

                int i = 0;
                int k = 0;

                foreach(char c in _time)
                {
                    if(c == ':')
                        k += 1;                                      

                    i++;

                    if (k == 2)
                        break;                    
                }                
                                                  
                SponeNewEvent("timeLabel", _time.Substring(0, (i - 1)), "</br>", "");
                SponeNewEvent("desLabel", rd["Designation"].ToString(), "</br></br>", "");
                
                var modButton = new Button();
                modButton.Text = "Modifier";
                string _id = rd[0].ToString();;
                modButton.Click += (s, ef) =>
                {
                    A = new Action();
                    A.ModifID = _id;
                    Response.Redirect("NewEventPage.aspx");
                };
                timeText.Visible = true;
                timeText.Controls.Add(modButton);
                timeText.Controls.Add(new LiteralControl(""));
                timeText.Controls.Add(new LiteralControl("</div>"));
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewEventPage.aspx");
        }
    }
}