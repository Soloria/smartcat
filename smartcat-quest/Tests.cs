namespace smartcat_quest
{
    using NUnit.Framework;

    public static class ConfigEx
    {
        public static T C<T>(this string s) => Config.GetValue<T>(s);
    }

    [TestFixture]
    public class YandexSchedules
    {
        [OneTimeSetUp]
        public static void Start() => SessionManager.Open(SessionManager.Path);

        [Test]
        [Order(order: 0)]
        public void ClickTheScheduleTab()
        {
            new MainPage(SessionManager.getDriver())
                .GoToLink("Расписания");
            Assert.AreEqual("Расписание пригородного и междугородного транспорта", new SchedulesPage(SessionManager.getDriver()).HeaderText);
        }

        [Test]
        [Order(order: 1)]
        public void SearchTransport()
        {
            
            new SchedulesPage(SessionManager.getDriver())
                .ChooseTransportType("schedules_page:transport_type".C<string>())
                .DepartingFrom("schedules_page:departure_location".C<string>())
                .ArrivingIn("schedules_page:arrivals_location".C<string>())
                .DepartureDate("schedules_page:departure_date".C<string>())
                .ClickSearchButton();

            Assert.That(new ResultPage(SessionManager.getDriver()).HeaderText, Contains
                .Substring("schedules_page:transport_type".C<string>().Remove("schedules_page:transport_type".C<string>().Length-2).ToLower())
                .With.Contains("schedules_page:departure_location".C<string>())
                .With.Contains("schedules_page:arrivals_location".C<string>()),
                "Transport not found or something else going wrong");

            Assert.That(new ResultPage(SessionManager.getDriver()).Date,
                Contains.Substring("schedules_page:departure_date".C<string>().ToLower()));
        }

        [OneTimeTearDown]
        public static void Clean() => SessionManager.Close();
    }
}
