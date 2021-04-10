﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
 using System.Drawing;
 using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 

namespace StagPj
{
    public partial class HomePage : System.Web.UI.Page
    {
        private Action a = new Action();
        private Compte c;
        private Utilisateur u;
        private Connexion con;

        private string name;
        private static string selectDay;

        protected void Page_Load(object sender, EventArgs e)
        {
            u = new Utilisateur();
            con = new Connexion();

            if (Request.Cookies["logIn"] != null)
            {
                u.Email = Request.Cookies["logIn"]["Email"];
                u.Password = Request.Cookies["logIn"]["Password"];
                u.LogIn();
            }
            else if (u.ID == null)
            {
                Response.Redirect("Login.aspx");
            }

            dayText.Text = DateTime.Now.ToString("dd");
            monthText.Text = DateTime.Now.Date.ToString("MMMM");
            Label3.Text = "Today";
            
            timeText.Visible = false;
            
            Color col = ColorTranslator.FromHtml("#FFC953");
            calDay.DayHeaderStyle.BackColor = Color.White;
            calDay.BackColor = Color.White;

            calDay.SelectedDayStyle.BackColor = col;
            if (selectDay == null)
            {
                calDay.SelectedDate = DateTime.Today;
            }
            else
            {
                calDay.SelectedDate = DateTime.Parse(selectDay);
            }
            SponingEvents();
            
        }
        
        void SponeNewEvent(string lbName, string cont, string htmlString,string monSfx)
        {
            name = lbName;

            var Tname = new Label();
            Tname.Text = cont + monSfx;

            timeText.Visible = true;
            timeText.Controls.Add(Tname);
            timeText.Controls.Add(new LiteralControl(htmlString));          

        }

        private DataTable ActionTable()
        {
            con = new Connexion(); 

            DataTable cTable = con.showParamDataTable("dbo.Get_Comptes_from_ID_Utili");

            DataTable table = new DataTable();

            foreach (DataRow cRaw in cTable.Rows)
            {
                table.Merge(con.showDataTable("select * from dbo.action" +" where C_id = '" + cRaw["ID"] + "'")); 
            }

            table.DefaultView.Sort = "Time DESC";
            
            return table.DefaultView.ToTable(); 
        }

        private void SponingEvents()
        {
            int index = 0;
            DataTable actionTable = ActionTable();

            foreach (DataRow dataRow in actionTable.Rows)
            {
                
                string _date = dataRow["Time"].ToString().Split(' ')[0];
                selectDay = calDay.SelectedDate.ToShortDateString();
                con = new Connexion();
                if (_date == selectDay)
                {
                    timeText.Controls.Add(new LiteralControl("<div class=" + "Event" + ">"));

                    string _time = DateTime.Parse(dataRow["Time"].ToString()).ToString("HH:mm tt");
                    

                    SponeNewEvent("prixLabel", dataRow["Prix"].ToString(), " ", " DH");
                    SponeNewEvent("timeLabel", _time, " ", "");
                    SponeNewEvent("acountLabel", con.ComptId(dataRow["C_id"].ToString()), "</br>", "");
                    SponeNewEvent("desLabel", dataRow["Designation"].ToString(), "</br></br>", "");

                    string a_id = dataRow[0].ToString();
                    string c_id = dataRow[4].ToString();


                    var modButton = new Button();
                    modButton.Text = "Modifier";
                    modButton.Click += (s, ef) =>
                    {
                        a = new Action();
                        c = new Compte();
                        c.ID = c_id;
                        a.ID = a_id;
                        Response.Redirect("NewEventPage.aspx");
                    };
                    timeText.Visible = true;
                    timeText.Controls.Add(modButton);
                    timeText.Controls.Add(new LiteralControl(" "));

                    var supButton = new Button();
                    supButton.Text = "X";
                    supButton.BackColor = Color.Red;
                    supButton.Click += (s, ef) =>
                    {
                        a = new Action();
                        c = new Compte();
                        c.ID = c_id;
                        a.ID = a_id;
                        a.Suppretion_Action();
                        Response.Redirect("HomePage.aspx");
                    };
                    timeText.Visible = true;
                    timeText.Controls.Add(supButton);

                    timeText.Controls.Add(new LiteralControl(" "));
                    timeText.Controls.Add(new LiteralControl("</div>"));
                    index++;
                }
                
            }
            Label4.Text = index + " Events";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewEventPage.aspx");
        }

        protected void calDay_SelectionChanged(object sender, EventArgs e)
        {
            SponingEvents();
            Response.Redirect("EventPage.aspx");
        }
    }
}