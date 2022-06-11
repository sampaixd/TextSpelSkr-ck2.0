using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSpelSkräck2._0
{
    internal class Item
    {
        protected string name;
        protected string description;
        protected int id;
        protected bool isPickedUp;
        protected bool isConsumed;

        public Item(string name, string description)
        {
            this.name = name;
            this.description = description;
            this.id = -1;
            this.isPickedUp = false;
            this.isConsumed = false;
        }

        public string Name { get { return name; } }
        public string Description { get { return description; } set { description = value; } }
        public int Id { get { return id; } set { id = value; } }
        public bool IsPickedUp { get { return isPickedUp; } set { isPickedUp = value; } }
        public bool IsConsumed { get { return isConsumed; } set { isConsumed = value; } }
    }
}
