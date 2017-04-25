using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using DigiRazor.PasswordValidation.Model;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DigiRazor.PasswordValidation.UnitTests.Model
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class PasswordTest
    {
        [TestCategory("Unit")]
        [TestCategory("Unit-Models")]
        [TestMethod]
        public void Test_PasswordService_SetHistory()
        {
            var model = new Password();

            var result = new Action(() =>
            {
                model.SetHistory(new List<string> { "$sG96r#X", "3g9m&9W7" });

            });

            result.ShouldNotThrow<ArgumentException>();
        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Models")]
        [TestMethod]
        public void Test_PasswordService_SetHistory_Null_Parameter()
        {
            var model = new Password();

            var result = new Action(() =>
            {
                model.SetHistory(null);

            });

            result.ShouldThrow<ArgumentNullException>();
        }
    }
}
