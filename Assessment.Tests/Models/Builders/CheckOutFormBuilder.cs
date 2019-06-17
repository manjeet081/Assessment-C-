using System;
using System.Text;
using Assessment.Enums;
using Assessment.Models.Objects;

namespace Assessment.Models.Builders
{
    public class CheckOutFormBuilder
    {
        public static CheckOutFormModel BuildCheckOutDetails(string cardType)
        {
           string CardsType= cardTypes(cardType);
            var model = new CheckOutFormModel()
            {
                Email = "test@test.com",
                Name = "Test name",
                Address = "Never Land",
                CardsType = CardsType,
                CardNumber = "4111111111111111",
                CardholderName = "John Smith",
                VerificationCode = "000"
            };

            return model;
        }
        private static string cardTypes(string cardType)
        {
            if(cardType=="Visa")
            {
                cardType = CardType.Visa.ToString();
            }
            else cardType = CardType.Mastercard.ToString();

            return cardType;
        }


    }
}
