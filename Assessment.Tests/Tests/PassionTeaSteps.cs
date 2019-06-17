using System.Configuration;
using Assessment.Core.Utilities;
using Assessment.Models.Builders;
using Assessment.Pages.Executors;
using FluentAssertions;
using TechTalk.SpecFlow;


namespace Assessment.Tests
{
    [Binding]
    public class PassionTeaSteps
    {
        private readonly MenuPage menuPage;
        readonly WelcomePage welcomePage;
        readonly CheckOutPage checkoutPage;
        readonly Let_sTalkTeaPage let_sTalkTeaPage;


        public PassionTeaSteps(MenuPage menuPage,
            WelcomePage welcomePage,
            CheckOutPage checkoutPage,
            Let_sTalkTeaPage let_sTalkTeaPage
            )
        {
            this.menuPage = menuPage;
            this.welcomePage = welcomePage;
            this.checkoutPage = checkoutPage;
            this.let_sTalkTeaPage = let_sTalkTeaPage;
        }

        [Given(@"I go to Passion Tea website")]
        public void GivenIGoToPassionTeaWebsite()
        {
            Browser.GoToUrl(ConfigurationManager.AppSettings["PassionTea"]);
        }

        [StepDefinition(@"I open Herbal tea collection")]
        public void GivenIOpenHerbalTeaCollection()
        {
            this.welcomePage.ClickHerbalTeaButton();
        }

        [When(@"I select Green tea and place the order")]
        public void WhenISelectGreenTeaAndPlaceTheOrder()
        {
            this.menuPage.ClickGreenTeaButton();
            const string cards = "Visa";
            var checkoutDetails = CheckOutFormBuilder.BuildCheckOutDetails(cards);
            checkoutPage.FillCheckoutFormAndSubmit(checkoutDetails);
        }

        [Then(@"I see a confirmation page")]
        public void ThenISeeAConfirmationPage()
        {
            const string expectedMessage = "Thanks for your order!";
            expectedMessage.Should().NotBeNullOrEmpty();
        }
        [When(@"I select Oolong tea and place the order with Mastercard")]
        public void WhenISelectOolongTeaAndPlaceTheOrderWithMastercard()
        {
            this.menuPage.ClickOolongTeaButton();
            const string cards = "Mastercard";
            var checkoutDetails = CheckOutFormBuilder.BuildCheckOutDetails(cards);
            checkoutPage.FillCheckoutFormAndSubmit(checkoutDetails);
        }
        [StepDefinition(@"I go to Let's Talk Tea page")]
        public void GivenIGoToLetSTalkTeaPage()
        {
            this.menuPage.ClickLetsTalkButton();
            
        }
        [StepDefinition(@"I fill feedback form")]
        public void WhenIFillFeedbackForm()
        {
            var letstalkdetaild = LetsTalkFormBuilder.LetsTalkFormModel();
            let_sTalkTeaPage.FillCheckoutFormAndSubmit(letstalkdetaild);
        }
        [Then(@"I can submit the form and get a confirmation")]
        public void ThenICanSubmitTheFormAndGetAConfirmation()
        {
            let_sTalkTeaPage.ClickfeedbackSubmitBTn();
            const string expectedMessage = "Thanks for Your Feedback!";
            expectedMessage.Should().BeSameAs("Thanks for Your Feedback!");
        }



    }
}
