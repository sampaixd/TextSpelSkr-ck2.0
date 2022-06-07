using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSpelSkräck2._0
{
    internal class Item
    {
        string name;
        string description;
        int id;
        bool pickedUp;
        bool used;

        public Item(string name, string description)
        {
            this.name = name;
            this.description = description;
            this.id = -1;
            this.pickedUp = false;
            this.used = false;
        }

        public string Name { get { return name; } }
        public string Description { get { return description; } set { description = value; } }
        public int Id { get { return id; } set { id = value; } }
        public bool PickedUp { get { return pickedUp; } set { pickedUp = value; } }
        public bool Used { get { return used; } set { used = value; } }
    }
}
