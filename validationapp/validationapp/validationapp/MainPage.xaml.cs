using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using validationapp.validator;
using validationapp.validator.Rules;
using Xamarin.Forms;

namespace validationapp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new validationmodel();
        }
    }
    public class validationmodel: INotifyPropertyChanged
    {
        public ValidatableObject<string> FirstName { get; set; } = new ValidatableObject<string>();
        public ValidatableObject<string> LastName { get; set; } = new ValidatableObject<string>();
        public ValidatableObject<DateTime> BirthDay { get; set; } = new ValidatableObject<DateTime>() { Value = DateTime.Now };
        public validationmodel()
        {

            FirstName.Value = null;
            
            
            AddValidationRules();
            AreFieldsValid();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void AddValidationRules()
        {
            FirstName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "First Name Required" });
            LastName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Last Name Required" });
            BirthDay.Validations.Add(new HasValidAgeRule<DateTime> { ValidationMessage = "You must be 18 years of age or older" });
        }

        bool AreFieldsValid()
        {
            bool isFirstNameValid = FirstName.Validate();
            bool isLastNameValid = LastName.Validate();
            bool isBirthDayValid = BirthDay.Validate();
            return isFirstNameValid && isLastNameValid && isBirthDayValid;
        }



     }
}
