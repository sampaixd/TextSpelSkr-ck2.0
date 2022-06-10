using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSpelSkräck2._0
{
    internal class Document : Item
    {
        string content;
        public Document(string name, string description, string content) : base(name, description)
        {
            this.content = content;
        }
    }
}
