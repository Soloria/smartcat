namespace smartcat_quest
{
    using OpenQA.Selenium;
    using SeleniumExtras.PageObjects;

    public abstract class AbstractPage
    {
        private readonly IWebDriver driver;

        protected AbstractPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public IWebDriver getDriver() => driver;
    }
}
