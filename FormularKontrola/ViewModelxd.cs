using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.ObjectModel;

namespace FormularKontrola
{
    internal class ViewModelxd :  INotifyPropertyChanged
    {
        
        private bool _WrongName { get; set; }
        private bool _WrongSurname { get; set; }
        private bool _WrongAge { get; set; }
        private string _GetText { get; set; }
        private string _GetSurname { get; set; }
        private string _GetTextAge { get; set; }
        private string _ErrorAge { get; set; }
        private string _ErrorForename { get; set; }
        private string _Nevimm { get; set; }

        public string Nevimm
        {
            get => _Nevimm;
            set
            {
                _Nevimm = value;
                OnPropertyChanged("Nevimm");
            }
        }
        public string ErrorAge
        {
            get => _ErrorAge;
            set
            {
                _ErrorAge = value;
                OnPropertyChanged("ErrorAge");
            }
        }
        public string ErrorForename
        {
            get => _ErrorForename;
            set
            {
                _ErrorForename = value;
                OnPropertyChanged("ErrorForename");
            }
        }
        public string GetTextAge
        {
            get => _GetTextAge;
            set
            {
                _GetTextAge = value;
                OnPropertyChanged("GetTextAge");
                var isNumeric = int.TryParse(GetTextAge, out int n);
                ClickMethod();
                if(!isNumeric)
                {
                    ErrorAge = "Není to číslo";
                    _WrongAge = true;
                }
                else
                {
                    ErrorAge = "Dobry kámooo";
                    _WrongAge = false;
                }
            }
        }
        public string GetText
        {
            get => _GetText;
            set
            {
                _GetText = value;
                OnPropertyChanged("GetText");
                ClickMethod();
                if (string.IsNullOrEmpty(GetText))
                {
                    WrongName = true;
                    ErrorForename = "Vyplňte jméno";
                }
                else
                {
                    WrongName = false;
                    ErrorForename = "je to dobrý";
                }
            }
        }
        public string GetSurname
        {
            get => _GetSurname;
            set
            {
                _GetSurname = value;
                OnPropertyChanged("GetSurname");
                ClickMethod();
                if (string.IsNullOrEmpty(GetSurname))
                {
                    WrongSurname = true;
                }
                else
                {
                    WrongSurname = false;
                }
            }
        }
        public bool WrongSurname
        {
            get => _WrongSurname;
            set
            {
                _WrongSurname = value;
                OnPropertyChanged("WrongSurname");
            }
        }
        public bool WrongName
        {
            get => _WrongName;
            set
            {
                _WrongName = value;
                OnPropertyChanged("WrongName");
            }
        }
        public ViewModelxd()
        {
            ClickCommand = new RelayCommand(ClickMethod);
        }
        private void ClickMethod()
        {
            Customer customer = new Customer();
            customer.Forename = GetText;
            customer.Age = GetTextAge;
            customer.Surname = GetSurname;
            CustomerValidator validator = new CustomerValidator();
            ValidationResult results = validator.Validate(customer);

            bool validationSucceeded = results.IsValid;
            IList<ValidationFailure> failures = results.Errors;
            Nevimm = "";
            foreach (var item in failures)
            {
                Nevimm = Nevimm +item + "\n";
            }
        }
        public Style Newstyle
        {
            get { return (Style)App.Current.Resources["BadAnswer"]; }
        }

        public RelayCommand ClickCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }

    }
}
