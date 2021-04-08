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
            this._name = lbName;

            var Tname = new Label();
            Tname.Text = cont + monSfx;

            timeText.Visible = true;
            timeText.Controls.Add(Tname);
            timeText.Controls.Add(new LiteralControl(htmlString));          

        }

        private DataTable ActionTable()
        {
            con = new Connexion(); 

            DataTable _cTable = con.showParamDataTable("dbo.Get_Comptes_from_ID_Utili");

            DataTable _table = new DataTable();

            foreach (DataRow cRaw in _cTable.Rows)
            {
                _table.Merge(con.showDataTable("select * from dbo.action" +" where C_id = '" + cRaw["ID"] + "'")); 
            }

            /*DateTime previewTime= DateTime.Now;
            foreach (DataRow cRaw in _cTable.Rows)
            {
                var time = DateTime.Parse(cRaw["Time"].ToString());
                
                if (previewTime > time)
                {
                    DataRow row = cRaw;
                    cRaw[previewTime.ToString()] = cRaw[time.ToString()];
                    cRaw[time.ToString()] = row;
                }
                previewTime = time;

            }
            */

            _table.DefaultView.Sort = "Time DESC";
            
            return _table.DefaultView.ToTable(); 
        }

        private void SponingEvents()
        {
            con = new Connexion();
            DataTable _table = ActionTable();

            foreach (DataRow dataRow in _table.Rows)
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