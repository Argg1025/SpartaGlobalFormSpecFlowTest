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
            _spartaFormPage.ClickRadioGender(Faker.Boolean.Random());
            _spartaFormPage.Degree = Name.First();
            _spartaFormPage.Address = Address.StreetAddress();
            _spartaFormPage.City = Address.City();
            _spartaFormPage.Postcode = Address.UkPostCode();
            _spartaFormPage.EmailAddress = Name.Last() + "@spartaglobal.com";
            _spartaFormPage.PhoneNumber = Phone.Number();
            _spartaFormPage.ClickRadioStream(Faker.Boolean.Random());
            _spartaFormPage.ClickTerms();
        }
        
        [When(@"I press sign in")]
        public void WhenIPressSignIn()
        {
            _spartaFormPage.ClickSigninButtton();
        }
        
        [Then(@"I should be on the appropriate page")]
        public void ThenIShouldBeOnTheAppropriatePage()
        {
            ScenarioContext.Current.Pending();
        }

        //[AfterScenario]
        //public void DisposeWebDriver()
        //{
        //    _driver.Dispose();
        //}
    }
}
