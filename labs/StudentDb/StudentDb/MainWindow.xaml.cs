using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentDb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //DisplayAllStudents();
            DisplayContactInfo();
        }

        private void DisplayContactInfo()
        {
            try
            {
                using (CollegeDbEntities db = new CollegeDbEntities())
                {
                    StringBuilder builder = new StringBuilder();
                    var students = from s in db.Students 
                                   select new {s.FirstName, s.LastName, s.PhoneNumber, s.Email };
                    foreach(var el in students)
                    {
                        builder.Append(string.Format("{0,-9} {1,-9} {2,-11} {3,-9}"
                            ,el.FirstName, el.LastName, el.PhoneNumber, el.Email))
                            .Append(Environment.NewLine);
                    }
                    DisplayTb.Text = builder.ToString();
                }
            }
            catch (Exception ex)
            {
                DisplayTb.Text = "Unable to retrieve database " + ex.Message;
            }            
        }

        private void DisplayAllStudents()
        {
            try
            {
                using(CollegeDbEntities db = new CollegeDbEntities())
                {
                    StringBuilder builder = new StringBuilder();
                    foreach(Student s in db.Students)
                    {
                        builder.Append(s).Append(Environment.NewLine);
                    }
                    DisplayTb.Text = builder.ToString();
                }
            }
            catch(Exception ex)
            {
                DisplayTb.Text = "Unable to retrieve database " + ex.Message;
            }
        }
    }
}
