using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MortgageCalculator.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MortgageCalculator.Web.Controllers;

namespace MortgageCalculator.UnitTests
{
    [TestClass()]
    public class UT
    {
        [TestMethod()]
        public void getPercentageTest()
        {
            //Arrange
            double i = 12;

            //Act
            MortgageController m = new MortgageController();

            double result = m.getPercentage(i);

            //Assert
            Assert.AreEqual(0.01, result);
        }

        [TestMethod()]
        [Ignore]
        public void getTermsTest()
        {
            //Arrange
            int i = 1;

            //Act
            MortgageController m = new MortgageController();
            
            double result = m.getTerms(i);

            //Assert
            Assert.AreEqual(12, result);
        }

        [TestMethod()]
        //[Ignore]
        public void Formula()
        {
            //Arrange
            double i = 1;
            int j = 2;

            //Act
            MortgageController m = new MortgageController();
            
            double result = m.Formula(i, j);

            //Assert
            Assert.AreEqual(4, result);
        }

        [TestMethod()]
        //[Ignore]
        public void calculateMortgage()
        {
            //Arrange
            double i = 100000;
            double j = 12;
            int k = 1;

            //Act
            MortgageController m = new MortgageController();
            
            double intr = m.getPercentage(j);
            int term = m.getTerms(k);

            double result = m.calculateMortgage(i, intr, term);

            //Assert
            Assert.AreEqual(8884.88, Math.Round(result, 2));
        }
    }
}
