using System;
using System.Collections.Generic;
using _02_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Challenge_Test
{
    [TestClass]
    public class ClaimRepositoryTests
    {
        [TestMethod]
        public void CreateClaimObjectTest()
        {
            Claim incident = new Claim();

            incident.ClaimID = 1;
            int expected = 1;
            Assert.AreEqual(expected, incident.ClaimID);

            Claim incidentTwo = new Claim(2, ClaimCategory.Home, "Thunderstorm damage", 5700.00f, new DateTime(2019, 9, 8), new DateTime(2019, 9, 9));

            incidentTwo.DateOfClaim = new DateTime(2019, 9, 9);
            DateTime expectedTwo = new DateTime(2019, 9, 9);
            Assert.AreEqual(expectedTwo, incidentTwo.DateOfClaim.Date);
        }

        [TestMethod]
        public void AddToQueueTest()
        {
            ClaimRepository claimRepo = new ClaimRepository();
            Queue<Claim> incident = claimRepo.GetClaimQueue();

            Claim incidentThree = new Claim(3, ClaimCategory.Theft, "Stolen tools", 1400.00f, new DateTime(2019, 9, 17), new DateTime(2019, 9, 20));
            Claim incidentFour = new Claim(4, ClaimCategory.Car, "Stolen car", 18000.00f, new DateTime(2019, 9, 21), new DateTime(2019, 9, 21));

            claimRepo.AddToQueue(incidentThree);
            claimRepo.AddToQueue(incidentFour);

            int actual = incident.Count;
            int expectedThree = 2;
            Assert.AreEqual(expectedThree, actual);
        }
    }
}