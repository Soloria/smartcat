namespace smartcat_quest
{
    using OpenQA.Selenium;
    using SeleniumExtras.PageObjects;
    using JetBrains.Annotations;
    using System.Collections.Generic;
    using System.Linq;

    public class MainPage : AbstractPage
    {
        public MainPage(IWebDriver driver): base(driver) { }

        [FindsBy(How = How.CssSelector, Using = "ul.list.widget__content>li")]
        private IList <IWebElement> Links { get; [UsedImplicitly] set; }

        public IWebElement Link(string name) =>
            Links?.FirstOrDefault(x => x.Text.Contains(name))?.FindElement(By.CssSelector("a"));

        public SchedulesPage GoToLink(string name)
        {
            Link(name).Click();
            return new SchedulesPage(getDriver());
        }

    }
}
