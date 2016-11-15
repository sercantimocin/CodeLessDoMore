using NUnit.Framework;
using CommonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Tests
{
    using System.Diagnostics;

    [TestFixture()]
    public class ExceptionHandlerTests
    {
        [Test()]
        public void DivisionByZero()
        {
            int number1 = 5;
            int number2 = 0;

            CustomResult<int> result = ExceptionHandler.ExecuteFunction<int>(() => number1 / number2);

            Debug.WriteLine(result.ToJson());

            Assert.IsNotNullOrEmpty(result.ErrorMessage);
        }

        [Test]
        public void ReturnErrorMessage()
        {
            string errorMessage = string.Empty;
            List<int> list = new List<int>();

            var result = ExceptionHandler.ExecuteFunction(
                () =>
                    {
                        if (list.Count == 0)
                        {
                            errorMessage = "Error list is empty";
                            return 0;
                        }
                        /// if list is not empty , method will do flow
                        return 2 + 4;
                    },
                ref errorMessage);

            Debug.WriteLine(result.ToJson());
            Assert.That(result.ErrorMessage, Is.EqualTo("Error list is empty"));
            Assert.That(result.IsSuccessful, Is.EqualTo(false));
        }


        public void Division()
        {
            try
            {
                int number1 = 5;
                int number2 = 0;

                int result = number1 / number2;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}