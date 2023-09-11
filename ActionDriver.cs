using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TextCopy;
using WindowsInput.Native;
using WindowsInput;

namespace SeleniumTestProject.Utilities
{
	class ActionDriver
	{
		public readonly IWebDriver _driver;

		public ActionDriver(IWebDriver driver)
		{
			_driver = driver;
		}

		public void NavigateTo(string url, ExtentTest test)
		{
            ExtentTest subnode = test.CreateNode("NavigateTo :"+ url);
            try
            {
                _driver.Manage().Window.Maximize();                
                _driver.Navigate().GoToUrl(url);
                subnode.Log(Status.Pass, "Succesfully navigated to page");
            }
            catch (Exception)
            {
                subnode.Log(Status.Fail, "failed to navigated to page");
				throw;
            }
        }

        public void Refresh(ExtentTest test)
        {
            ExtentTest subnode = test.CreateNode("Refresh :");
            try
            {
                _driver.Navigate().Refresh();
                subnode.Log(Status.Pass, "Succesfully Refreshe");
            }
            catch (Exception)
            {
                subnode.Log(Status.Fail, "failed to Refresh");
                throw;
            }
        }

        public void SendText(By by, String name, String text, ExtentTest test)
		{
			ExtentTest subnode = test.CreateNode("SendText to element "+ name);
            try
			{
				WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
				w.Until(ExpectedConditions.ElementExists(by));
				IWebElement element = _driver.FindElement(by);
				element.Clear();
				element.SendKeys(text);
				subnode.Log(Status.Pass, "Succesfully SendText",ScreenShot.CaptureScreenShot(_driver));
			}
			catch (Exception)
			{
				subnode.Log(Status.Fail, "Failed to SendText", ScreenShot.CaptureScreenShot(_driver));
				throw;
			}            
        }

		public void Click(By by, String name, ExtentTest test)
		{
            ExtentTest subnode = test.CreateNode("clicked on element "+ name);
            try
            {
				WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
				w.Until(ExpectedConditions.ElementToBeClickable(by));
				IWebElement element = _driver.FindElement(by);
				element.Click();
                IsAlertPresent(subnode);
                subnode.Log(Status.Pass, "Succesfully clicked", ScreenShot.CaptureScreenShot(_driver));
            }
			catch (Exception ex)
            {
                IsAlertPresent(subnode);
                if (ex.Message.Contains("element click intercepted") || ex.Message.Contains("ElementClickInterceptedException"))
                {
                    JavascriptExecuterFunction(by);
                }
                else
                {
                    subnode.Log(Status.Fail, "Failed to click", ScreenShot.CaptureScreenShot(_driver));
                    throw new Exception("Click failed", ex);
                }
            }
        }

        public void Click(By [] locators, String name, ExtentTest test)
        {
            ExtentTest subnode = test.CreateNode("clicked on element " + name);
            try
            {
                IWebElement element = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(AnyElementExists(locators));
                element.Click();
                IsAlertPresent(subnode);
                subnode.Log(Status.Pass, "Succesfully clicked", ScreenShot.CaptureScreenShot(_driver));
            }
            catch (Exception ex)
            {
                IsAlertPresent(subnode);
                if (ex.Message.Contains("element click intercepted") || ex.Message.Contains("ElementClickInterceptedException"))
                {
                    JavascriptExecuterFunction(locators);
                }
                else
                {
                    subnode.Log(Status.Fail, "Failed to click", ScreenShot.CaptureScreenShot(_driver));
                    throw new Exception("Click failed", ex);
                }

            }
        }

        public Func<IWebDriver, IWebElement> AnyElementExists(By[] locators)
        {
            return (driver) =>
            {
                foreach (By locator in locators)
                {
                    IReadOnlyCollection<IWebElement> e = _driver.FindElements(locator);
                    if (e.Any())
                    {
                        return e.ElementAt(0);
                    }
                }

                return null;
            };
        }

        public void DropDownByText(By by, String name, String text, ExtentTest test)
		{
            ExtentTest subnode = test.CreateNode("select DropDownByText for element "+ name);
            try
            {
				WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(40));
				w.Until(ExpectedConditions.ElementExists(by));
				IWebElement element = _driver.FindElement(by);
				var selectElement = new SelectElement(element);
				selectElement.SelectByText(text);
				subnode.Log(Status.Pass, "Succesfully selected DropDownByText", ScreenShot.CaptureScreenShot(_driver));
			}
			catch (Exception) 
			{
                subnode.Log(Status.Fail, "Fail to selected DropDownByText", ScreenShot.CaptureScreenShot(_driver));
				throw;
			}
		}

		public void DropDownByIndex(By by, String name, int ind, ExtentTest test)
		{
            ExtentTest subnode = test.CreateNode("select DropDownByIndex for element " + name);
            try
			{
				WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(40));
				w.Until(ExpectedConditions.ElementExists(by));
				IWebElement element = _driver.FindElement(by);
				var selectElement = new SelectElement(element);
				selectElement.SelectByIndex(ind);
				subnode.Log(Status.Pass, "Succesfully selected DropDownByIndex", ScreenShot.CaptureScreenShot(_driver));
			}
			catch (Exception) {
                subnode.Log(Status.Fail, "Fail to selected DropDownByIndex", ScreenShot.CaptureScreenShot(_driver));
				throw;
			}
        }

        public String GetDropDownValueAtOption(By by, String name, int ind, ExtentTest test)
        {
            ExtentTest subnode = test.CreateNode("select DropDownByIndex for element " + name);
            try
			{
				WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(40));
				w.Until(ExpectedConditions.ElementExists(by));
				IWebElement element = _driver.FindElement(by);
				SelectElement selectElement = new SelectElement(element);
				IList<IWebElement> els = selectElement.Options;

                if (ind >= 0 && ind < els.Count)
                {
                    var returnIndex = els[ind].Text;
                    return returnIndex;
                }
                else
                {
					subnode.Log(Status.Fail, "Fail to select DropDownByIndex - Index out of range", ScreenShot.CaptureScreenShot(_driver));
					throw new ArgumentOutOfRangeException(nameof(ind), "Index is out of range.");
				}
			}
			catch (ArgumentNullException)
            {
                subnode.Log(Status.Fail, "Fail to selected DropDownByIndex", ScreenShot.CaptureScreenShot(_driver));
                throw;
            }
			catch (ArgumentOutOfRangeException)
			{
				subnode.Log(Status.Fail, "Fail to selected DropDownByIndex", ScreenShot.CaptureScreenShot(_driver));
				throw;
			}
		}
       
        public Boolean IsAlertPresent(ExtentTest test)
		{
            try
			{
				_driver.SwitchTo().Alert().Accept();
                return true;
			}
			catch (NoAlertPresentException)
			{
				return false;
			}
		}

		public Boolean ElementDisplayed(By firstAddSuggest,ExtentTest test)
		{
            ExtentTest subnode = test.CreateNode("elementDisplayed");
			System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> eles = _driver.FindElements(firstAddSuggest);
            if (eles.Count > 0)
            {
                subnode.Log(Status.Pass, "element is Displayed", ScreenShot.CaptureScreenShot(_driver));
                return true;
            }
            else
            {
                subnode.Log(Status.Pass, "element is not Displayed", ScreenShot.CaptureScreenShot(_driver));
                return false;
            }
        }

        public void WaitForElementValueToShow(By by, ExtentTest test)
        {
            ExtentTest subnode = test.CreateNode("WaitForElementValueToShow");
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
                wait.Until(d => Convert.ToInt32(_driver.FindElement(by).GetAttribute("value").Split(".")[0]) > 0);
                subnode.Log(Status.Pass, "Element value showing", ScreenShot.CaptureScreenShot(_driver));
            }
            catch (WebDriverTimeoutException ex) {
                subnode.Log(Status.Fail, "Element value not showing", ScreenShot.CaptureScreenShot(_driver));
                throw new Exception("Click failed", ex);
            }
        }

        public void WaitForBusyElementToGo()
        {
            By BusyWait = By.XPath("//*[contains(text(), 'Busy' )]");
            By ProcessingWait = By.XPath("//*[contains(text(), 'Processing' )]");
            By LoggingInWait = By.XPath("//img[contains(@src,'busy')]");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(d => Convert.ToInt32(_driver.FindElements(BusyWait).Count) == 0 & Convert.ToInt32(_driver.FindElements(ProcessingWait).Count) == 0 & Convert.ToInt32(_driver.FindElements(LoggingInWait).Count) == 0);
        }
        public void JavascriptExecuterFunction(By by)
        {
            try
            {
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
                jsExecutor.ExecuteScript("arguments[0].click();", _driver.FindElements(by));
            }catch(JavaScriptException ex) {
                Console.WriteLine(ex.Message);   
            }
        }
        public void JavascriptExecuterFunction(By [] locators)
        {
            try
            {
                IWebElement element = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(AnyElementExists(locators));
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
                jsExecutor.ExecuteScript("arguments[0].click();", element);
            }
            catch (JavaScriptException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void FluentWaitMethod(By by, String name)
		{
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(60);
            fluentWait.PollingInterval = TimeSpan.FromSeconds(2);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }
        public void ExplicitWait(By by)
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
            w.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        internal void NavigateTo(object value)
        {
            throw new NotImplementedException();
        }

        public String GetText(By objLocator, String sLocatorName, ExtentTest test)
        {
            ExtentTest subnode = test.CreateNode("get text from element:" + sLocatorName);
            String text = "";
            try
            {
                WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
                w.Until(ExpectedConditions.ElementExists(objLocator));
                IWebElement element = _driver.FindElement(objLocator);
                text = element.Text;
                subnode.Log(Status.Pass, "successfully get text from element");
            }
            catch (Exception)
            {
                subnode.Log(Status.Pass, "failed to get text from element");
                throw new Exception("GetText failed");
            }
            return text;
        }

        public String GetElementAttribute(By objLocator, String sLocatorName, String attributeName, ExtentTest test)
        {
            ExtentTest subnode = test.CreateNode("get text from element:" + sLocatorName);
            String text = "";
            try
            {
                WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
                w.Until(ExpectedConditions.ElementExists(objLocator));
                IWebElement element = _driver.FindElement(objLocator);
                text = element.GetAttribute(attributeName);
                subnode.Log(Status.Pass, "successfully get attribute from element");
            }
            catch (Exception)
            {
                subnode.Log(Status.Pass, "failed to get attribute from element");
                throw new Exception("GetText failed");
            }
            return text;
        }

        public void TextVerificationEqual(By objLocator, String sLocatorName, String expectedText, ExtentTest node)
        {
            ExtentTest subnode = node.CreateNode("TextVerificationEqual:" + sLocatorName);
            String actualText = GetText(objLocator, sLocatorName, subnode);
		    if(actualText.Equals(expectedText)){
                subnode.Log(Status.Pass,"Expected Text:"+expectedText+", is same as Actual text:"+actualText+",on element:"+sLocatorName);
		    }else{
                subnode.Log(Status.Fail,"Expected Text:"+expectedText+", is not the same as Actual text:"+actualText+",on element:"+sLocatorName);
		    }
	    }

        public void TextVerificationContains(By objLocator, String sLocatorName, String expectedText, ExtentTest node)
        {
            ExtentTest subnode = node.CreateNode("TextVerificationEqual:" + sLocatorName);
            String actualText = GetText(objLocator, sLocatorName, subnode);
            if (actualText.Contains(expectedText))
            {
                subnode.Log(Status.Pass, "Expected Text:" + expectedText + ", contain Actual text:" + actualText + ",on element:" + sLocatorName);
            }
            else
            {
                subnode.Log(Status.Fail, "Expected Text:" + expectedText + ", not contain as Actual text:" + actualText + ",on element:" + sLocatorName);
            }
        }

        public static void PastFilePathAndEnter(String path) {
            ClipboardService.SetText(path);
            var sim = new InputSimulator();
            sim.Keyboard.KeyDown(VirtualKeyCode.CONTROL).Sleep(1000).KeyPress(VirtualKeyCode.VK_V).Sleep(1000).KeyUp(VirtualKeyCode.CONTROL).Sleep(1000).KeyPress(VirtualKeyCode.RETURN);
        }

        public void ScrollTo(By by, ExtentTest test)
        {

            var e = _driver.FindElement(by);
            // JavaScript Executor to scroll to element
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", e);
            Console.WriteLine(e.Text);
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                _driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public Boolean IsSelected(By by, ExtentTest test)
        {
            var e = _driver.FindElement(by);
            if (e.Selected)
            {  
                return true;
            }
            else
            { 
                return false;
            }
        }
        public void FluentWaitForBusyElement()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driver);
            By BusyWait = By.XPath("//*[@class = 'ember-view komodo-busy']");
            fluentWait.Timeout = TimeSpan.FromSeconds(120);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(2000);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Until(x => Convert.ToInt32(_driver.FindElements(BusyWait).Count) == 0);
        }
    }
}
