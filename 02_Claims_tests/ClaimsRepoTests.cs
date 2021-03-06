﻿using System;
using System.Collections.Generic;
using _02_Claims_repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Claims_tests
{
    [TestClass]
    public class ClaimsRepoTests
    {
        private ClaimRepo _repo;
        private Claim _claim;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimRepo();
            _claim = new Claim(TypeOfClaim.Car, "Car Accident on 465.", 400, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            _repo.AddClaim(_claim);
        }

        [TestMethod]
        public void AddItemShouldReturnTrue()
        {
            // Arrange
            Claim home = new Claim(TypeOfClaim.Home, "House fire in kitchen.", 4000, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12));

            // Act/Assert
            Assert.IsTrue(_repo.AddClaim(home));
        }

        [TestMethod]
        public void GetClaimShouldBeTypeClaim()
        {
            // Act
            Claim expected = _claim;
            Claim actual = _repo.GetClaimById(1);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetClaimsShouldNotBeNull()
        {
            // act
            Queue<Claim> claims = _repo.GetClaims();

            // assert
            Assert.IsNotNull(claims);
        }

        [TestMethod]
        public void RemoveClaimFromTopOfQueue_ShouldReturnTrue()
        {
            // Assert
            Assert.IsTrue(_repo.RemoveClaimFromTopOfQueue());
        }
    }
}
