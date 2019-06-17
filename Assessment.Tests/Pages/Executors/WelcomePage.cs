using Assessment.Core.Extensions;
using Assessment.Pages.Locators;

namespace Assessment.Pages.Executors
{
    public class WelcomePage : WelcomePageLocators
    {
        public void ClickHerbalTeaButton()
        {
            HerbalTeaButton.ClickWithWait();
        }
    }
}
