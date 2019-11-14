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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Courses course = new Courses();
            course.Credit = txtCredit.Text;
            course.Quota = txtQuota.Text;

            CetDb1 db1 = new CetDb1();
            db1.Course.Add(course);

            db1.SaveChanges();
            MessageBox.Show("Ders Kaydedildi.");
            lblCourseId.Content = "";
            txtCode.Text = "";
            txtCredit.Text = "";
            txtQuota.Text = "";

            LoadCourses();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCourses();
        }

        private void LoadCourses()
        {
            CetDb1 db1 = new CetDb1();
            List<Course> course = db1.Course.ToList();
            dgCourse.ItemsSource = course;
        }

        private void dgCourse_Selected(object sender, RoutedEventArgs e)
        {

        }


        private void btnOpenStudents_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgCourses_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }
    }
}
