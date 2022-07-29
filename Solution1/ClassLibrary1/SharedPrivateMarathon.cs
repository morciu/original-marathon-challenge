using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    internal class SharedPrivateMarathon : Marathon
    {
        public List<User> members;

        public override string ShowProgress()
        {
            return "Showing member's progress";
        }

        public override string ShowFinishers()
        {
            return "Showing finishers from members list";
        }
    }
}
