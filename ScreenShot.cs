using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumTestProject.Models;

namespace SeleniumTestProject.Utilities
{
    public static class ScreenShot
    {
        public static string ProjectDirectory;

		public static MediaEntityModelProvider CaptureScreenShot(IWebDriver driver)
        {
            string screenShotName = CLDate.GenerateTodayDateWithFormat("ddMMyyyyhhmmssFFF");
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(ProjectDirectory+"/ScreenShot/" + screenShotName+".png", ScreenshotImageFormat.Png);
            return MediaEntityBuilder.CreateScreenCaptureFromPath("ScreenShot/" + screenShotName + ".png").Build();
        }
    }
}