using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SpartaGlobalFormSpecFlowTest
{
    public class ConfirmationPage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.TagName, Using = "h3")]
        private IWebElement _confirmationMessage;

        public ConfirmationPage(IWebDriver driver)
        {
            _driver = driver;

            PageFactory.InitElements(_driver, this);
        }

        public string Confirmation => _confirmationMessage.Text;
    }
}
