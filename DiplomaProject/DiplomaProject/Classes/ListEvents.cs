using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject.Classes
{
    internal class ListEvents
    {
        public static bool incidentResult;

        public int SetListContentSize(int size)
        {
            if (PageEvents.pageState == 2)
            {
                return size = 12;
            }
            else
            {
                return size = 6;
            }
        }
    }
}
