using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Pages.Locators
{
    public class LetsTalkPageLocator
    {
        public By NameInput => By.CssSelector("#form_78ea690540a24bd8b9dcfbf99e999fea > div.form-body > div:nth-child(1) > input");
        public By EmailInput => By.CssSelector("#form_78ea690540a24bd8b9dcfbf99e999fea > div.form-body > div:nth-child(2) > input");
        public By SubjectInput => By.CssSelector("#form_78ea690540a24bd8b9dcfbf99e999fea > div.form-body > div:nth-child(3) > input");
        public By MessageInput => By.CssSelector("#form_78ea690540a24bd8b9dcfbf99e999fea > div.form-body > div:nth-child(4) > textarea");
        public By SubmitFeedback => By.CssSelector("#form_78ea690540a24bd8b9dcfbf99e999fea > div.form-body > div:nth-child(5) > input");

    }


}
