using Assessment.Core.Extensions;
using Assessment.Models.Objects;
using Assessment.Pages.Locators;

namespace Assessment.Pages.Executors
{
    public class CheckOutPage : CheckOutPageLocators
    {
        public void FillCheckoutFormAndSubmit(CheckOutFormModel model)
        {
            EmailInput.SendKeysWithWait(model.Email);
            NameInput.SendKeysWithWait(model.Name);
            AddressInput.SendKeysWithWait(model.Address);
            CardTypeDropdown.SelectText(model.CardsType);
            CardNumberInput.SendKeysWithWait(model.CardNumber);
            CardholderNameInput.SendKeysWithWait(model.CardholderName);
            VerificationCodeInput.SendKeysWithWait(model.VerificationCode);

            PlaceOrder.ClickWithWait();
        }
    }
}
