using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSpelSkräck2._0
{
    internal abstract class Room
    {
        protected string name;
        protected int id;
        public Room(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        public abstract void InsideRoom();

        protected abstract void LookAround();

        public int Id { get { return id; } }
    }
}
