using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Assessment.Pages.Locators
{
    public class CheckOutPageLocators
    {
        public By EmailInput => By.Id("email");

        public By NameInput => By.Id("name");

        public By AddressInput => By.Id("address");

        public By CardTypeDropdown => By.Id("card_type");

        public By CardNumberInput => By.Id("card_number");

        public By CardholderNameInput => By.Id("cardholder_name");

        public By VerificationCodeInput => By.Id("verification_code");

        public By PlaceOrder => By.ClassName("btn-primary");
    }
}
