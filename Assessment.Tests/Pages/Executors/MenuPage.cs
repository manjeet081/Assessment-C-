using Assessment.Core;
using Assessment.Core.Extensions;
using FluentAssertions;
using NUnit.Framework;

namespace Assessment.Pages.Executors
{
    public class MenuPage : Locators.Locators
    {
        public void ClickGreenTeaButton()
        {
            GreenTeaButton.IsDisplayedAfterWait().Should().BeTrue();
            GreenTeaButton.ClickWithWait();
        }
        public void ClickOolongTeaButton()
        {
            //OolongTeaTeaButton.MoveToElement();
            OolongTeaTeaButton.IsDisplayedAfterWait().Should().BeTrue();
            OolongTeaTeaButton.ClickWithWait();
        }
        public void ClickLetsTalkButton()
        {
            LetsTalkButton.IsDisplayedAfterWait().Should().BeTrue();
            LetsTalkButton.ClickWithWait();
        }
    }
}
