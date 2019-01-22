using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using System.Threading;
using System.Drawing;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Appium.Android;

namespace MobileTestUsingAppium
{
    public class AppiumTest
    {

        [TestFixture]
        public class Class1
        {
            public AppiumDriver<IWebElement> driver;
            DesiredCapabilities capabilities;

            public Class1()
            {

                //ChromeOptions optoins = new ChromeOptions();
                
                Console.WriteLine("Connecting to Appium server");
                capabilities = new DesiredCapabilities();


                //For connecting to Real Device
                //capabilities.SetCapability(CapabilityType.PlatformName, "Android");
                //capabilities.SetCapability(CapabilityType.Version, "7.0");
                //capabilities.SetCapability("deviceName", "SAMSUNG-SM-G930V");

                //For connecting to Emulator
                capabilities.SetCapability(CapabilityType.PlatformName, "Android");
                capabilities.SetCapability(CapabilityType.Version, "7.1.1");
                capabilities.SetCapability("deviceName", "Galaxy_Nexus_API_25");

                //For connecting to Chrome browser
                capabilities.SetCapability(CapabilityType.BrowserName, "Chrome");

                //Generic Capabilities for AA Traveller Test
                //capabilities.SetCapability("appPackage", "com.appnivity.aatraveller.test");
                //capabilities.SetCapability("appActivity", "com.appnivity.aatraveller.test.MainActivity");


                //Connecting to Amazon Application
                //capabilities.SetCapability("appPackage", "com.amazon.mShop.splashscreen");
                //capabilities.SetCapability("appActivity", "com.amazon.mShop.splashscreen.StartupActivity");

                try
                {
                    driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                driver.Navigate().GoToUrl("https://servicebookingtest181.z26.web.core.windows.net/?d=8&cno=ABCD21Jan191&vno=TST222");

                driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/main[1]/a[1]")).Click();

            }

          
            [Test]
            public void login()
            {

                //driver.FindElement(By.Name("Country")).Click();
                //Your further code as per the application.



            }
        }
    }
}
