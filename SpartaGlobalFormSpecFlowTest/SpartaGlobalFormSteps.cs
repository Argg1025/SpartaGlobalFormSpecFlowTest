using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Faker.Extensions;
using Faker;

namespace SpartaGlobalFormSpecFlowTest
{
    [Binding]
    public class SpartaGlobalFormSteps
    {
        private IWebDriver _driver;
        private SpartaFormPage _spartaFormPage;
        private ConfirmationPage _confirmationPage;
        private int _ignore;

        [Given(@"I am on the registration page")]
        public void GivenIAmOnTheRegistrationPage()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _spartaFormPage = SpartaFormPage.NavigateTo(_driver);
        }
        
        [Given(@"I have entered the valid details in all the fields")]
        public void GivenIHaveEnteredTheValidDetailsInAllTheFields()
        {
            _spartaFormPage.Firstname = Name.First();
            _spartaFormPage.Lastname = Name.Last();
            _spartaFormPage.Age = RandomNumber.Next(99).ToString();
            _spartaFormPage.DOB(RandomNumber.Next(1,31), RandomNumber.Next(1,12), RandomNumber.Next(16,40));
            _spartaFormPage.ClickRadioGender(Faker.Boolean.Random());
            _spartaFormPage.Degree = Name.First();
            _spartaFormPage.UniversityButton(RandomNumber.Next(1, 4));
            _spartaFormPage.Address = Address.StreetAddress();
            _spartaFormPage.Address2 = Address.SecondaryAddress();
            _spartaFormPage.CountyButton(RandomNumber.Next(0,3));
            _spartaFormPage.City = Address.City();
            _spartaFormPage.Postcode = Address.UkPostCode();
            _spartaFormPage.EmailAddress = Internet.Email();
            _spartaFormPage.PhoneNumber = Phone.Number();
            _spartaFormPage.Skills = Lorem.Sentence();
            _spartaFormPage.Internet = "http://www." + Lorem.GetFirstWord() + ".com";
            _spartaFormPage.ClickRadioStream(Faker.Boolean.Random());
            _spartaFormPage.ClickTerms();

        }
        
        [When(@"I press sign in")]
        public void WhenIPressSignIn()
        {
            _spartaFormPage.ClickSigninButton();
        }
        
        [Then(@"I should be on the appropriate page")]
        public void ThenIShouldBeOnTheAppropriatePage()
        {
            _confirmationPage = new ConfirmationPage(_driver);
            Assert.AreEqual("You have successfully registered an account with Sparta Global!", _confirmationPage.Confirmation);
        }

        //---------------------- INVALID STEPS ----------------------
        [Given(@"I have entered (.*) invalid detail")]
        public void GivenIHaveEnteredInvalidDetail(int ignore)
        {
            _ignore = ignore -1;
            if(!(ignore == 1)) _spartaFormPage.Firstname = Name.First();
            if (!(ignore == 2)) _spartaFormPage.Lastname = Name.Last();
            if (!(ignore == 3)) _spartaFormPage.Age = RandomNumber.Next(99).ToString();
            if (!(ignore == 4)) _spartaFormPage.Address = Address.StreetAddress();
            if (!(ignore == 5)) _spartaFormPage.Postcode = Address.UkPostCode();
            if (!(ignore == 6)) _spartaFormPage.EmailAddress = Internet.Email();
            if (!(ignore == 7)) _spartaFormPage.PhoneNumber = Phone.Number();
            
        }

        [Given(@"I have entered all other details correctly")]
        public void GivenIHaveEnteredAllOtherDetailsCorrectly()
        {
            _spartaFormPage.DOB(RandomNumber.Next(1, 31), RandomNumber.Next(1, 12), RandomNumber.Next(16, 40));
            _spartaFormPage.ClickRadioGender(Faker.Boolean.Random());
            _spartaFormPage.Degree = Name.First();
            _spartaFormPage.UniversityButton(RandomNumber.Next(1, 4));

            _spartaFormPage.Address2 = Address.SecondaryAddress();
            _spartaFormPage.CountyButton(RandomNumber.Next(0, 3));
            _spartaFormPage.City = Address.City();

            _spartaFormPage.Skills = Lorem.Sentence();
            _spartaFormPage.Internet = "http://www." + Lorem.GetFirstWord() + ".com";
            _spartaFormPage.ClickRadioStream(Faker.Boolean.Random());
            _spartaFormPage.ClickTerms();
        }

        [Then(@"I should see the appropriate (.*)")]
        public void ThenIShouldSeeTheAppropriate(string error)
        {
            Assert.AreEqual(_spartaFormPage.ErrorList()[_ignore], error);
        }






        [AfterScenario]
        public void DisposeWebDriver()
        {
            _driver.Dispose();
        }
    }
}
