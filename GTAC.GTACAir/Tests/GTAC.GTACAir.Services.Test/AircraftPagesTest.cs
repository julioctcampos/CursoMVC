using GTAC.GTACAir.Domain;
using GTAC.GTACAir.Repository.Entity.Impl.v1;
using GTAC.Repository.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GTAC.GTACAir.Services.Test
{
    public class AircraftPagesTest : IDisposable
    {
        IWebDriver _driver;

        public AircraftPagesTest()
        {
            _driver = new ChromeDriver();
        }
        
        [Fact]
        public void TestIfAllAircraftsWareShowed()
        {
            _driver.Navigate().GoToUrl("http://localhost:8080/Aircraft");
            IGTACGenericRepository<Aircraft, int> aircraftRepository = new AircraftRepository();
            int quantity = aircraftRepository.SelectAll().Count;
            int lines = _driver.FindElements(By.XPath("//table[@id='tblAircrafts']/tbody/tr")).Count;
            Assert.Equal(quantity, lines);
        }

        [Fact]
        public void TestIfSearchIsOk()
        {
            _driver.Navigate().GoToUrl("http://localhost:8080/Aircraft");
            string search = "a";
            IGTACGenericRepository<Aircraft, int> aircraftRepository = new AircraftRepository();
            int quantity = aircraftRepository.SelectAll().Where(a => a.Model.ToLower().Contains(search.ToLower())).Count();
            
            IWebElement input = _driver.FindElement(By.Id("aircraftModel"));
            input.SendKeys(search);

            IWebElement btnPesquisar = _driver.FindElement(By.Id("btnPesquisar"));
            btnPesquisar.Click();
            Thread.Sleep(3000);

            int lines = _driver.FindElements(By.XPath("//table[@id='tblAircrafts']/tbody/tr")).Count;
            Assert.Equal(quantity, lines);
        }

        public void Dispose()
        {
            _driver.Dispose();
        }
    }
}
