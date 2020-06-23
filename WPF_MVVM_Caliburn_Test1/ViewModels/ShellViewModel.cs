using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM_Caliburn_Test1.Models;

namespace WPF_MVVM_Caliburn_Test1.ViewModels
{
    //Screen类有很多包含“打开”和“关闭”的功能,但其功能只针对一个窗体。
    //Conductor类包含ActivateItem方法,使用ActivateItem最简单的方法就是传入一个object类型的
    //参数，这样便可以每次打开一个窗口
    class ShellViewModel:Conductor<object>
    {
        private string _firstName="Tim";

        public string FirstName
        {
            get { return _firstName; }
            set 
            { 
                _firstName = value;
                //使用Screen基类中预设的方法,当值发生改变的时候，更新UI
                NotifyOfPropertyChange(() => FirstName);
                //每次FirstName和LastName值更新，都去更新FullName
                NotifyOfPropertyChange(() => FullName);
            }
        }

        private string _lastName="Martha";

        public string LastName
        {
            get { return _lastName; }
            set 
            { 
                _lastName= value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        private BindableCollection<PersonModel> _people=new BindableCollection<PersonModel>();

        public BindableCollection<PersonModel> People
        {
            get { return _people; }
            set { _people = value; }
        }

        private PersonModel _selectedPerson;
        public PersonModel SelectedPerson
        {
            get { return _selectedPerson; }
            set 
            { 
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        //构造函数
        public ShellViewModel()
        {
            People.Add(new PersonModel { FirstName = "Tim", LastName = "Corey" });
            People.Add(new PersonModel { FirstName = "Bill", LastName = "Jones" });
            People.Add(new PersonModel { FirstName = "Lane", LastName = "Storm" });
            People.Add(new PersonModel { FirstName = "Sue", LastName = "Trim" });
        }

        //方法名也可以通过名称自动绑定
        //CanClearText的参数与ClearText的参数必须一致,类型，个数，参数名都要一致
        public void ClearText(string firstName,string lastName)
        {
            FirstName = string.Empty;
            LastName = string.Empty;
        }
        //自动绑定方法的CanExecute属性,CanClearText本身可以是一个方法也可以是一个属性
        //CanClearText的参数与ClearText的参数必须一致，类型，个数，参数名都要一致
        public bool CanClearText(string firstName,string lastName)
        {
            return !string.IsNullOrEmpty(firstName) || !string.IsNullOrEmpty(lastName);
        }

        public void LoadPageOne()
        {
            ActivateItem(new FirstChildViewModel());
        }

        public void LoadPageTwo()
        {
            ActivateItem(new SecondChildViewModel());
        }
    }
}

