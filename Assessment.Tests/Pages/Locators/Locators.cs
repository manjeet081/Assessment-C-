using OpenQA.Selenium;

namespace Assessment.Pages.Locators
{
    public class Locators
    {
        public By GreenTeaButton => By.Id("wsb-button-00000000-0000-0000-0000-000451955160");
        public By OolongTeaTeaButton => By.Id("wsb-button-00000000-0000-0000-0000-000451961556");
        public By LetsTalkButton => By.XPath("//a[@href='let-s-talk-tea.html']");

    }
}
