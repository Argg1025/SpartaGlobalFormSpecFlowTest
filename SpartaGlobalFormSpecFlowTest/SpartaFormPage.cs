using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SpartaGlobalFormSpecFlowTest
{
    public class SpartaFormPage
    {
        private readonly IWebDriver _driver;

        // PageFactory Objects
        [FindsBy(How = How.Id, Using = "firstName")]
        private IWebElement _firstName;
        [FindsBy(How = How.Id, Using = "lastName")]
        private IWebElement _lastName;
        [FindsBy(How = How.CssSelector, Using = "input[type = 'number']")]
        private IWebElement _age;
        [FindsBy(How = How.CssSelector, Using = "label[for = 'customRadioInline1']")]
        private IWebElement _male;
        [FindsBy(How = How.CssSelector, Using = "label[for = 'customRadioInline2']")]
        private IWebElement _female;
        [FindsBy(How = How.CssSelector, Using = "input[placeholder = 'Enter Degree']")]
        private IWebElement _degree;
        [FindsBy(How = How.Id, Using = "inputAddress")]
        private IWebElement _address;
        [FindsBy(How = How.Id, Using = "inputCity")]
        private IWebElement _city;
        [FindsBy(How = How.Id, Using = "inputPostcode")]
        private IWebElement _postcode;
        [FindsBy(How = How.Id, Using = "inputemailaddress")]
        private IWebElement _emailAddress;
        [FindsBy(How = How.Id, Using = "exampleFormControlInput1")]
        private IWebElement _phoneNumber;
        [FindsBy(How = How.CssSelector, Using = "label[for = 'streamRadioInline2']")]
        private IWebElement _stream1;
        [FindsBy(How = How.CssSelector, Using = "label[for = 'streamRadioInline2']")]
        private IWebElement _stream2;
        [FindsBy(How = How.Id, Using = "terms")]
        private IWebElement _terms;
        [FindsBy(How = How.ClassName, Using = "btn")]
        private IWebElement _signInButton;

        private const string PageUri = @"http://automation-form.spartaglobal.education/";

        public SpartaFormPage(IWebDriver driver)
        {
            _driver = driver;

            PageFactory.InitElements(_driver, this);
        }

        public static SpartaFormPage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageUri);

            return new SpartaFormPage(driver);
        }

        public string Firstname
        {
            set
            {
                _firstName.SendKeys(value);
            }
        }

        public string Lastname
        {
            set
            {
                _lastName.SendKeys(value);
            }
        }

        public string Age
        {
            set
            {
                _age.SendKeys(value);
            }
        }

        public void ClickSigninButtton()
        {
            _signInButton.Click();
        }

        public void ClickRadioGender(bool value)
        {
            if (value == true) _male.Click();
            else if (value == false) _female.Click();
        }

        public string Degree
        {
            set
            {
                _degree.SendKeys(value);
            }
        }

        public string Address
        {
            set
            {
                _address.SendKeys(value);
            }
        }

        public string City
        {
            set
            {
                _city.SendKeys(value);
            }
        }

        public string Postcode
        {
            set
            {
                _postcode.SendKeys(value);
            }
        }

        public string EmailAddress
        {
            set
            {
                _emailAddress.SendKeys(value);
            }
        }

        public string PhoneNumber
        {
            set
            {
                _phoneNumber.SendKeys(value);
            }
        }

        public void ClickRadioStream(bool value)
        {
            if (value == true) _stream1.Click();
            else if (value == false) _stream2.Click();
        }

        public void ClickTerms()
        {
            _terms.Click();
        }
    }
}
