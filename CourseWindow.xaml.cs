using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;

namespace CetStudents
{
    /// <summary>
    /// Interaction logic for CourseWindow.xaml
    /// </summary>
    public partial class CourseWindow : Window
    {
        public CourseWindow()
        {
            InitializeComponent();
        }

        private void btnOpenStudents_Click(object sender, RoutedEventArgs e)
        {
            MainWindow student = new MainWindow();
            student.Show();
        }

        private void dgCourses_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Course course = dgCourses.SelectedItem as Course;
            if (course != null)
            {
                lblCourseId.Content = course.Id;
                txtCourseCode.Text = course.Code;
                txtCourseCredit.Text = course.Credit.ToString();
                txtCourseQuota.Text = course.Quota.ToString();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Course course = new Course();
            course.Code = txtCourseCode.Text;
            course.Credit = Int32.Parse(txtCourseCredit.Text);
            course.Quota = Int32.Parse(txtCourseQuota.Text);

            CetDb db = new CetDb();
            db.Courses.Add(course);

            db.SaveChanges();
            MessageBox.Show("Ders Kaydedildi.");
            lblCourseId.Content = "";
            txtCourseCode.Text = "";
            txtCourseCredit.Text = "";
            txtCourseQuota.Text = "";
           
            LoadCourses();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCourses();
        }

        private void LoadCourses()
        {
            CetDb db = new CetDb();
            List<Course> course = db.Courses.ToList();  
            dgCourses.ItemsSource = course;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Course course = dgCourses.SelectedItem as Course;
            if (course != null)
            {
                CetDb db = new CetDb();
                var coursenew = db.Courses.Find(course.Id);
                coursenew.Code = txtCourseCode.Text;
                coursenew.Credit = Int32.Parse(txtCourseCredit.Text);
                coursenew.Quota = Int32.Parse(txtCourseQuota.Text);

                db.SaveChanges();
                LoadCourses();
                MessageBox.Show("Güncellendi.");
            }
            else
            {
                MessageBox.Show("güncellemek için dersi seçmelisin!");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Course course = dgCourses.SelectedItem as Course;
            if (course != null)
            {
                CetDb db = new CetDb();
                db.Courses.Remove(course);
                db.SaveChanges();
                MessageBox.Show("Ders Silindi!");
                LoadCourses();

            }
            else
            {
                MessageBox.Show("Silmek için ders seçmelisin!");
            }
        }
    }
}
