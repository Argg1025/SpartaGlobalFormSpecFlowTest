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

        //[AfterScenario]
        //public void DisposeWebDriver()
        //{
        //    _driver.Dispose();
        //}
    }
}
