using Assessment.Models.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Models.Builders
{
   public  class LetsTalkFormBuilder
    {
        public static LetsTalkFormModel LetsTalkFormModel()
        {
            var model = new LetsTalkFormModel()
            {
                Name = "Test name",
                Email = "test@test.com",
                Subject = "Test",
                Message = "Home Delivery Avaiable",
            };

            return model;
        }
    }
}
