using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutingsClasses
{
    public class OutingRepo
    {
        protected readonly List<Outing> _outingList = new List<Outing>();
        //CRUD
        //CREATE
        public bool CreateOuting(Outing outing)
        {
            int initialList = _outingList.Count();
            _outingList.Add(outing);

            bool createdOuting = _outingList.Count > initialList ? true : false;
            return createdOuting;
        }
        //READ
        public List<Outing> ListOutings()
        {
            return _outingList;
        }
        //UPDATE
        //DELETE
        //HELPER
        public Outing RetrieveByEventType(EventType eventType)
        {
            foreach(Outing outing in _outingList)
            {
                if(outing.EventType == eventType)
                {
                    return outing;
                }
            }
            return null;
        }
    }
}
