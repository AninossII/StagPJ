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
        private Action A = new Action();
        private Utilisateur U;
        private string _name;
        private Connexion con;
        private static string _selectDay;

        protected void Page_Load(object sender, EventArgs e)
        {
            U = new Utilisateur();

            if (Request.Cookies["logIn"] != null)
            {
                Response.Write("Login with Cookies");
                U.Email = Request.Cookies["logIn"]["Email"];
                U.Password = Request.Cookies["logIn"]["Password"];
                U.LogIn();
            }
            else if (U.ID == null)
            {
                Response.Redirect("Login.aspx");
            }

            dayText.Text = DateTime.Now.ToString("dd");
            monthText.Text = DateTime.Now.Date.ToString("MMMM");
            Label3.Text = "Today";
            Label4.Text = "1" + "Event";

            timeText.Visible = false;
            
            System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#FFC953");
            calDay.DayHeaderStyle.BackColor = Color.White;
            calDay.BackColor = Color.White;

            if (_selectDay == null)
            {
                calDay.SelectedDate = DateTime.Today;
                calDay.SelectedDayStyle.BackColor = col;
            }
            else
            {
                calDay.SelectedDate = DateTime.Parse(_selectDay);
                calDay.SelectedDayStyle.BackColor = col;
            }
            SponingEvents();
            
        }
        
        void SponeNewEvent(string lbName, string cont, string htmlString,string monSfx)
        {
            this._name = lbName;

            var Tname = new Label();
            Tname.Text = cont + monSfx;

            timeText.Visible = true;
            timeText.Controls.Add(Tname);
            timeText.Controls.Add(new LiteralControl(htmlString));          

        }

        private void SponingEvents()
        {
            con = new Connexion();
            DataTable table = con.showDataTable("select * from dbo.action" +
                                                " where C_id = 'F7C64F98-2495-4DAE-9387-3F2E9E9A7BB6'");

            foreach (DataRow dataRow in table.Rows)
            {
                string _date = dataRow["Time"].ToString().Split(' ')[0];
                _selectDay = calDay.SelectedDate.ToShortDateString();

                if (_date == _selectDay)
                {
                    timeText.Controls.Add(new LiteralControl("<div class=" + "Event" + ">"));

                    // string _time = dataRow["Time"].ToString().Split(' ')[1];
                    string _time = dataRow["Time"].ToString();

                    /*int i = 0;
                    int k = 0;

                    foreach (char c in _time)
                    {
                        if (c == ':')
                            k += 1;

                        i++;

                        if (k == 2)
                            break;
                    }
                    */

                    SponeNewEvent("prixLabel", dataRow["Prix"].ToString(), " ", " DH");
                    SponeNewEvent("timeLabel", _time, "</br>", "");
                    SponeNewEvent("desLabel", dataRow["Designation"].ToString(), "</br></br>", "");

                    string _id = dataRow[0].ToString();


                    var modButton = new Button();
                    modButton.Text = "Modifier";
                    modButton.Click += (s, ef) =>
                    {
                        A = new Action();
                        A.ID = _id;
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
                        A = new Action();
                        A.ID = _id;
                        A.Suppretion_Action();
                        Response.Redirect("HomePage.aspx");
                    };
                    timeText.Visible = true;
                    timeText.Controls.Add(supButton);

                    timeText.Controls.Add(new LiteralControl(" "));
                    timeText.Controls.Add(new LiteralControl("</div>"));
                }
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewEventPage.aspx");
        }

        protected void calDay_SelectionChanged(object sender, EventArgs e)
        {
            SponingEvents();
            Response.Redirect("HomePage.aspx");
        }
    }
}