using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Challenge_Repository
{
    public class OutingRepository
    {
        List<Outing> _outingList = new List<Outing>();

        public void AddToList(Outing outing)
        {
            _outingList.Add(outing);
        }

        public List<Outing> GetOutingList()
        {
            return _outingList;
        }

        public void SeedList()
        {
            Outing outing = new Outing(EventCategory.Bowling, 20, new DateTime(2019, 9, 7), 480.00m);
            Outing outingTwo = new Outing(EventCategory.Golf, 12, new DateTime(2019, 8, 15), 600.00m);

            AddToList(outing);
            AddToList(outingTwo);
        }
    }
}