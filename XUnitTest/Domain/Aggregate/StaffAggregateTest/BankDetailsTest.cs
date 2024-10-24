﻿using Domain.Aggreagtes.StaffAggregate;
using Xunit;
namespace XUnitTest.DomainTest.StaffAggregateTest
{
    public class BankDetailsTest
    {
        [Fact]
        public void Should_CreateBankDetails_When_ValidParameters()
        {
            string bankName = "Bank";
            string accountNumber = "1234567890";
            string branch = "Main Branch";

            var bankDetails = new BankDetails(bankName, accountNumber, branch);

            Assert.Equal(bankName, bankDetails.BankName);
            Assert.Equal(accountNumber, bankDetails.AccountNumber);
            Assert.Equal(branch, bankDetails.BranchName);
        }
    }
}

