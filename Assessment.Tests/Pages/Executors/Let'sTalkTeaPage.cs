using Assessment.Core.Extensions;
using Assessment.Models.Objects;
using Assessment.Pages.Locators;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Pages.Executors
{
    public class Let_sTalkTeaPage : LetsTalkPageLocator
    {
        public void FillCheckoutFormAndSubmit(LetsTalkFormModel model)
        {
            EmailInput.SendKeysWithWait(model.Email);
            NameInput.SendKeysWithWait(model.Name);
            SubjectInput.SendKeysWithWait(model.Subject);
            MessageInput.SendKeysWithWait(model.Message);
        }
        public void ClickfeedbackSubmitBTn()
        {
            SubmitFeedback.ClickWithWait();
        }

    }
}
