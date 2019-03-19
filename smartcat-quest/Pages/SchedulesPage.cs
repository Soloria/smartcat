
namespace smartcat_quest
{
    using OpenQA.Selenium;
    using SeleniumExtras.PageObjects;
    using JetBrains.Annotations;
    using System.Collections.Generic;
    using System.Linq;

    public class SchedulesPage : AbstractPage
    {
        public SchedulesPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.CssSelector, Using = ".Slogan>h1")]
        private IWebElement Header { get; [UsedImplicitly] set; }

        public string HeaderText => Header?.Text;

        [FindsBy(How = How.Id, Using = "from")]
        private IWebElement From { get; [UsedImplicitly] set; }

        [FindsBy(How = How.Id, Using = "to")]
        private IWebElement To { get; [UsedImplicitly] set; }

        [FindsBy(How = How.Id, Using = "when")]
        private IWebElement Date { get; [UsedImplicitly] set; }

        [FindsBy(How = How.CssSelector, Using = ".SearchForm__submit")]
        private IWebElement SearchButton { get; [UsedImplicitly] set; }


        [FindsBy(How = How.CssSelector, Using = ".TransportSelector>span>label")]
        private IList<IWebElement> TransportButtons { get; [UsedImplicitly] set; }

        public IWebElement TransportButton(string type) =>
            TransportButtons?.FirstOrDefault(x => x.Text.Contains(type))?.FindElement(By.CssSelector("span"));

       

        public SchedulesPage DepartingFrom(string location)
        {
            From.Click();
            From.SendKeys(location);
            return this;
        }

        public SchedulesPage ArrivingIn(string location)
        {
            To.Click();
            To.SendKeys(location);
            return this;
        }

        public SchedulesPage DepartureDate(string date)
        {
            Date.Click();
            Date.SendKeys(date);
            return this;
        }
        

        public SchedulesPage ChooseTransportType(string type)
        {
            TransportButton(type).Click();
            return this;
        }

        public SchedulesPage ClickSearchButton()
        {
            SearchButton.Click();
            return this;
        }
    }
}
