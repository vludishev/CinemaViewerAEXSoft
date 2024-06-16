using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System.Collections.ObjectModel;

namespace UITests;

public abstract class BaseTest
{
    protected AppiumDriver App => AppiumSetup.App;

    protected AppiumElement FindUIElement(string id)
    {
        if (App is WindowsDriver)
        {
            return App.FindElement(MobileBy.AccessibilityId(id));
        }

        return App.FindElement(MobileBy.Id(id));
    }

    protected ReadOnlyCollection<AppiumElement> FindUIElements(string id)
    {
        return App.FindElements(MobileBy.Id(id));
    }

    protected void SearchBtnClick()
    {
        App.ExecuteScript("mobile: performEditorAction", new Dictionary<string, string> { { "action", "search" } });
    }
}