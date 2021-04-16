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
        private Action a;
        private Compte c;
        private Utilisateur u;
        private Connexion con;

        private string name;
        private static string _selectDay;

        protected void Page_Load(object sender, EventArgs e)
        {
            u = new Utilisateur();
            con = new Connexion();

            if (u.ID != null)
            {

            }
            else if (Request.Cookies["logIn"] != null)
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
            if (_selectDay == null)
            {
                calDay.SelectedDate = DateTime.Today;
            }
            else
            {
                calDay.SelectedDate = DateTime.Parse(_selectDay);
            }
            SponingEvents();
            
        }
        
        void SponeNewEvent(string lbName, string cont, string htmlString,string monSfx)
        {
            var Tname = new Label();
            Tname.Text = cont + monSfx;
            if(lbName == "prixLabel")
            {
                if (cont.Contains("-"))
                {
                    Tname.ForeColor = Color.Red;
                }
                else
                {
                    Tname.ForeColor = Color.CadetBlue;
                }
            }

            timeText.Visible = true;
            timeText.Controls.Add(Tname);
            timeText.Controls.Add(new LiteralControl(htmlString));          

        }

        void SponeNewButton(string btnName, string c_id, string a_id)
        {
            var modButton = new Button();
            modButton.Text = btnName;
            if (btnName == "X")
            {
                modButton.BackColor = Color.Red;
            }
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
            con = new Connexion();
            c = new Compte();

            int index = 0;
            DataTable actionTable = ActionTable();

            foreach (DataRow dataRow in actionTable.Rows)
            {
                
                string _date = dataRow["Time"].ToString().Split(' ')[0];
                _selectDay = calDay.SelectedDate.ToShortDateString();
                
                if (_date == _selectDay)
                {
                    timeText.Controls.Add(new LiteralControl("<div class=" + "Event" + ">"));

                    string _time = DateTime.Parse(dataRow["Time"].ToString()).ToString("HH:mm tt");
                    

                    SponeNewEvent("prixLabel", dataRow["Prix"].ToString(), " ", " DH");
                    SponeNewEvent("timeLabel", _time, " ", "");
                    SponeNewEvent("acountLabel", c.ComptId(dataRow["C_id"].ToString()), "</br>", "");
                    SponeNewEvent("desLabel", dataRow["Designation"].ToString(), "</br></br>", "");

                    string a_id = dataRow[0].ToString();
                    string c_id = dataRow[4].ToString();

                    SponeNewButton("Modifier", c_id, a_id);
                    SponeNewButton("X", c_id, a_id);

                    
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