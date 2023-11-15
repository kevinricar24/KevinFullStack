using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Kevin.Automation.UITests
{
    public class DashboardTests
    {
        private WebDriver driver;

        public DashboardTests()
        {
            var options = new ChromeOptions();
            options.BrowserVersion = "113";
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://kevinfullstackangular.azurewebsites.net/");
        }

        [Fact]
        public void CompareTitle_ShouldBeEquals()
        {
            //Arrange
            string titleExpected = "KevinAngular";
            string titleActual = string.Empty;

            //Act
            titleActual = driver.Title;

            //Assert
            Assert.Equal(titleExpected, titleActual);

            driver.Quit();
        }

        [Fact]
        public void CreateEmployee_ShouldBeOk()
        {
            //Arrange
            string titleExpected = "KevinAngular";
            string titleActual = string.Empty;

            //Act
            var buttonCreate = driver.FindElement(By.XPath("/html[1]/body[1]/app-root[1]/div[1]/button[1]/span[2]"));
            buttonCreate.Click();

            var fullNameField = driver.FindElement(By.Id(""));
            var departmentDropdown = driver.FindElement(By.Id(""));
            var salaryField = driver.FindElement(By.Id(""));
            var contractDateCalendar = driver.FindElement(By.Id(""));

            //Assert
            Assert.Equal(titleExpected, titleActual);

            driver.Quit();
        }


    }
}
