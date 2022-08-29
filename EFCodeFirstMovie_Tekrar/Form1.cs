using EFCodeFirstMovie_Tekrar.DesignPatterns.SingletonPattern;
using EFCodeFirstMovie_Tekrar.Models.Context;
using EFCodeFirstMovie_Tekrar.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFCodeFirstMovie_Tekrar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _db = DBTool.DBInstance;
        }
        MyContext _db;
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowActiveMovies();

            List<Director> directors = new List<Director>
            {
                new Director {Name = "Steven", Surname = "Spie"},
                new Director {Name = "Mark", Surname = "Cube"},
                new Director {Name = "Mick", Surname = "J"}
            };

            cmbCategories.DataSource = directors;
            cmbCategories.SelectedIndex = -1;
        }

        private void ShowAll()
        {
            lstResult.DataSource = _db.Movies.ToList();
        }
        private void ShowActiveMovies()
        {
            lstResult.DataSource = _db.Movies.Where(x => x.Status != Models.Enums.DataStatus.Deleted).ToList() ;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Movie m = new Movie();
            m.Title = txtTitle.Text;
            m.Director = cmbCategories.SelectedItem as Director;
            _db.Movies.Add(m);
            _db.SaveChanges();

            ShowActiveMovies();
        }
        Movie _selected;
        private void lstResult_MouseClick(object sender, MouseEventArgs e)
        {
            if(lstResult.SelectedIndex > -1)
            {
                _selected = lstResult.SelectedItem as Movie;
                txtTitle.Text = _selected.Title;
                
            }
        }

        private void lstResult_DoubleClick(object sender, EventArgs e)
        {
            _selected = null;
            txtTitle.Text = string.Empty;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selected is null)
            {
                MessageBox.Show("Lütfen bir film seçiniz");
                return;
            }

            _selected.Title = txtTitle.Text;
            _selected.Director = cmbCategories.SelectedItem as Director;
            _selected.Status = Models.Enums.DataStatus.Modified;
            _selected.ModifiedDate = DateTime.Now;
            _db.SaveChanges();
            _selected = null;

            ShowActiveMovies();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selected is null)
            {
                MessageBox.Show("Lütfen bir film seçiniz");
                return;
            }

            _selected.Status = Models.Enums.DataStatus.Deleted;
            _selected.DeletedDate = DateTime.Now;
            _db.SaveChanges();
            _selected = null;

            ShowActiveMovies();
        }

        private void lstResult_Format(object sender, ListControlConvertEventArgs e)
        {
            //string movieAndDirector = $"Film : {(e.ListItem as Movie).Title} Yönetmeni : {(e.ListItem as Movie).Director.Name} {(e.ListItem as Movie).Director.Surname}";
        }

        private void cmbCategories_Format(object sender, ListControlConvertEventArgs e)
        {
            string directors = $"{(e.ListItem as Director).Name} {(e.ListItem as Director).Surname}";

            e.Value = directors;
        }
    }
}
