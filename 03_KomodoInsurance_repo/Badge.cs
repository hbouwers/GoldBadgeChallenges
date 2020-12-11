using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoInsurance_repo
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; }
        public Badge() { }
        public Badge(int badgeId, List<string> doorNames)
        {
            BadgeID = badgeId;
            DoorNames = doorNames;
        }
    }
}
