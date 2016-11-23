using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pacman.Data;

namespace Pacman.Forms
{
    public partial class Register : Form
    {
        private PacmanContext context = new PacmanContext();
        public Register()
        {
            InitializeComponent();
        }

        private void Pacman_Load(object sender, EventArgs e)
        {
            var countries = DataBridge.GetAllCountriesName().ToArray();
            this.Countries.Items.AddRange(countries);
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Countries_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void Countries_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cities.Items.Clear();
            this.Cities.Text = "";

            var getCities = DataBridge.GetCitiesByCountryName(this.Countries.Text);
            this.Cities.Items.AddRange(getCities.Select(c=>c.Name).ToArray());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Anecdote.Text = DataBridge.GetRandomeAnecdote().AnecdoteNote;
            var anecdoteLetters = this.Anecdote.Text.Length;

            this.AnecdoteTimer.Interval=anecdoteLetters*60;

        }

        private void Anecdote_MouseHover(object sender, EventArgs e)
        {
            this.AnecdoteTimer.Stop();
        }

        private void Anecdote_MouseLeave(object sender, EventArgs e)
        {
            this.AnecdoteTimer.Start();
        }

    }
}
