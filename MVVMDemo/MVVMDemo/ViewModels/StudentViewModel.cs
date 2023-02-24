using MVVMDemo.Models;
using MVVMDemo.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

namespace MVVMDemo.ViewModels
{
    public class StudentViewModel : BaseViewModel
    {


        public ICommand Submitdata { get; set; }
        public ICommand Delete_Clicked { get; set; }
        public ICommand Update_Clicked { get; set; }


        private StudentModel _studentModel;

        public StudentModel Student
        {
            get { return _studentModel; }
            set { _studentModel = value; OnPropertyChanged(); }
        }
         private ObservableCollection<StudentModel> _students;
        public ObservableCollection<StudentModel> Students
        {
            get { return _students; }
            set { _students = value; }
        }
        public StudentViewModel()
        {

            Submitdata = new Command(DataSubmit);
            Delete_Clicked = new Command(DeleteClicked);
            Update_Clicked = new Command(UpdateClicked);
            Student = new StudentModel();
            Students = new ObservableCollection<StudentModel>();
            LoadApplication();

        }

        private void UpdateClicked(object obj)
        {
            var data = obj as StudentModel;
            Student = data;
            Submitdata = new Command(DataSubmit);
        }

        private async void DeleteClicked(object obj)
        {
            var data = obj as StudentModel;
            await App.StudentRepository.DeleteStudent(data.Id);
            LoadApplication();
        }

        private async void LoadApplication()
        {
            Students.Clear();
            var StdData = await App.StudentRepository.GetStudents();
            foreach (var student in StdData)
            {
                Students.Add(student);
            }
        }

        private async void DataSubmit(object obj)
        {

            if (Validations())
            {
                try
                {
                    await App.StudentRepository.Addstudent(Student);
                    Student = new StudentModel();
                    Student.Address = null;
                    Student.RollNumber = 0;
                    Student.Gender = null;
                    Student.Name = null;
                    await Application.Current.MainPage.DisplayAlert("Alert", "Data successfully Added", "OK");
                    LoadApplication();
                }
                catch (Exception ex)
                {

                    
                }
                
               
               // await Application.Current.MainPage.Navigation.PushAsync(new StudentView());
               
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "Please Enter Valid Data", "OK");
            }

        }

        private bool Validations()
        {
            if (string.IsNullOrEmpty(Student.Name) || string.IsNullOrEmpty(Student.RollNumber.ToString()) || string.IsNullOrEmpty(Student.Gender) || string.IsNullOrEmpty(Student.Address))
            {
                return false;
            }
            return true;
        }
    }
}
