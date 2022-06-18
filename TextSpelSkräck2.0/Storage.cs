using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSpelSkräck2._0
{
    internal class Storage : Room
    {
        public Storage() : base ("Storage", 7 ) 
        { }

        public override int InsideRoom()
        {
            if (!Map.DiscoveredStorage)
                FirstEntry();

            return base.InsideRoom();
        }
        protected override void FirstEntry()
        {
            throw new NotImplementedException();
        }

        protected override int GoToCommand(string room)
        {
            throw new NotImplementedException();
        }

        protected override void InspectCommand(string inspectedObject)
        {
            throw new NotImplementedException();
        }

        protected override void PickUpCommand(string item)
        {
            throw new NotImplementedException();
        }

        protected override void UseCommand(string item)
        {
            throw new NotImplementedException();
        }

        protected override void LookAround()
        {
            throw new NotImplementedException();
        }
    }
}
