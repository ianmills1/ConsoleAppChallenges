using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge_Repository
{
    public class ClaimRepository
    {
        Queue<Claim> _claimQueue = new Queue<Claim>();

        public void AddToQueue(Claim incident)
        {
            _claimQueue.Enqueue(incident);
        }

        public Queue<Claim> GetClaimQueue()
        {
            return _claimQueue;
        }

        public void SeedList()
        {
            Claim incident = new Claim(1, ClaimCategory.Car, "Broken rim", 1600.00f, new DateTime(2019, 8, 15), new DateTime(2019, 9, 17));
            Claim incidentTwo = new Claim(2, ClaimCategory.Home, "Flooded basement", 5400.00f, new DateTime(2019, 8, 29), new DateTime(2019, 9, 3));
            Claim incidentThree = new Claim(3, ClaimCategory.Theft, "Stolen electronics", 1350.00f, new DateTime(2019, 9, 15), new DateTime(2019, 9, 16));

            AddToQueue(incident);
            AddToQueue(incidentTwo);
            AddToQueue(incidentThree);
        }
    }
}