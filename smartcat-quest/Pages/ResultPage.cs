
namespace smartcat_quest
{
    using OpenQA.Selenium;
    using SeleniumExtras.PageObjects;
    using JetBrains.Annotations;

    public class ResultPage : AbstractPage
    { 
        public ResultPage (IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.CssSelector, Using = ".SearchTitle>span>h1>span")]
        private IWebElement Header { get; [UsedImplicitly] set; }

        public string HeaderText => Header?.Text;

        [FindsBy(How = How.CssSelector, Using= "span.SearchTitle__subtitle")]
        private IWebElement DateSubtitle { get; [UsedImplicitly] set; }

        public string Date => DateSubtitle?.Text;

    }
}
