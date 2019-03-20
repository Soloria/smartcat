namespace smartcat_quest
{
    using System;
    using System.Reflection;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;


    public static class SessionManager
    {
        private static IWebDriver _driver;

        public static void Open(string text)
        {
            Config.StartUp();
            _driver = new ChromeDriver(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            _driver.Url = text;
        }

        public static void Close() => _driver?.Quit();
        
        public static string Path = "https://yandex.ru/";

        public static IWebDriver getDriver() => _driver;
    }
}
