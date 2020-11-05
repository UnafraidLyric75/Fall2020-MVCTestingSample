using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCTestingSample.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCTestingSample.Models.Tests
{
    [TestClass()]
    public class ValidationHelperTests
    {
        // Wroks with US currency only
        [TestMethod()]
        [DataRow("9.99")]
        [DataRow("$20.00")]
        [DataRow("$.99")]
        [DataRow(".99")]
        [DataRow("$0.99")]
        [DataRow("0.99")]
        [DataRow("$0")]
        [DataRow("0")]
        public void IsValidPrice_ValidPrice_ReturnsTrue(string input)
        {
            bool result = ValidationHelper.IsValidPrice(input);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("   ")]
        [DataRow("Five")]
        [DataRow("3 and 5 cents")]
        [DataRow("5 Dollars")]
        [DataRow("$5.00$")]
        [DataRow("5..00")]
        [DataRow("5,000")]
        public void IsValidPrice_InValidPrice_ReturnFalse(string input)
        {
            bool result = ValidationHelper.IsValidPrice(input);
            Assert.IsFalse(result);
        }
    }
}