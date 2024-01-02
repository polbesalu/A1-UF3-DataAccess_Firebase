using A1_UF3_DataAccess.DataAccess.Repositories;
using A1_UF3_DataAccess.Models;
using Firebase.Database;
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

namespace A1_UF3_DataAccess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FirebaseRepository firebaseRepository = FirebaseFactory.GetFirebaseRepository();
        public MainWindow()
        {
            InitializeComponent();
            cmbUpdate.ItemsSource = firebaseRepository.GetStudents().Result.Select(x => x.Object.FullName);
            cmbDelete.ItemsSource = firebaseRepository.GetStudents().Result.Select(x => x.Object.FullName);
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            firebaseRepository.AddStudent(new Student
            {
                FullName = tbName.Text,
                Id = Convert.ToInt32(tbId.Text),
                CurseCicle = new Cicle { Curs = Convert.ToInt32(tbCicle.Text) },
                Dual = tbDual.Text,
                Email = tbEmail.Text
            });
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            firebaseRepository.UpdateStudent(new Student
            {
                FullName = tbName.Text,
                Id = Convert.ToInt32(tbId.Text),
                CurseCicle = new Cicle { Curs = Convert.ToInt32(tbCicle.Text) },
                Dual = tbDual.Text,
                Email = tbEmail.Text
            });
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            firebaseRepository.RemoveStudent(cmbDelete.Text);
        }
    }
}
