using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestAndMoqDemo.TestedClasses;

namespace MSTestAndMoqDemo
{
    [TestClass]
    public class BankAccountTest
    {
        //normal test
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act
            account.Debit(debitAmount);

            // assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        /*
         * !!!exception test
         * there are 2 ways to test exception (2nd one is preferred):
         *  > use "ExpectedException" annotation. 
         *      The drawback of this approach is that we just know exception is thrown, 
         *      but don't know which condition throws it
         *  
         *  > use "try/catch" in test method to catch exception
         *      assert exception under "catch" and return, assert fail after "catch"
         *      
         */
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act
            account.Debit(debitAmount);

            // assert is handled by ExpectedException
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act
            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert
                StringAssert.Contains(e.Message, "Debit amount exceeds balance");
                return;
            }

            Assert.Fail("No exception was thrown.");
        }
    }
}
