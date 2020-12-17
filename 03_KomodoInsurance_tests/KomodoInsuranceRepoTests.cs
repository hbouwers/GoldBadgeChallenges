using System;
using System.Collections.Generic;
using _03_KomodoInsurance_repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_KomodoInsurance_tests
{
    [TestClass]
    public class KomodoInsuranceRepoTests
    {
        // Why don't we instanciate here instead of the Arrange method?
        private BadgeRepo _repo;
        private Badge _badge;

        [TestMethod]
        public void Arrange()
        {
            _repo = new BadgeRepo();
            _badge = new Badge(12345, new List<string> { "A7" });
            _repo.AddBadge(_badge.BadgeID, _badge);
        }

        [TestMethod]
        public void AddBadgeShouldReturnTrue()
        {
            // arrange
            Badge second = new Badge(22345, new List<string> { "A1", "A4", "B1", "B2" });

            // act/assert
            Assert.IsTrue(_repo.AddBadge(second.BadgeID, second));
        }

        [TestMethod]
        public void GetBadgeShouldReturnTypeBadge()
        {
            // act
            Badge expected = _badge;
            Badge actual = _repo.GetBadgeByKey(12345);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteDoorsShouldReturnTrue()
        {
            // assert
            Assert.IsTrue(_repo.RemoveDoor(_badge.BadgeID, "A7"));
        }
    }
}
