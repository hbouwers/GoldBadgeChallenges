using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoInsurance_repo
{
    public class BadgeRepo
    {
        Dictionary<int, Badge> _badgeDictionary = new Dictionary<int, Badge>();

        // Create
        public bool AddBadge(int badgeId, Badge badge)
        {
            int startLength = _badgeDictionary.Count;
            _badgeDictionary.Add(badgeId, badge);
            return startLength < _badgeDictionary.Count ? true : false;
        }

        // Read
        public Badge GetBadgeByKey(int key)
        {
            if (_badgeDictionary.ContainsKey(key))
            {
                return _badgeDictionary[key];
            }
            return null;
        }

        public Dictionary<int, Badge> GetBadges()
        {
            return _badgeDictionary;
        }

        // Update
        public string UpdateBadge(int key, Badge badge)
        {
            if(_badgeDictionary[key] == null)
            {
                return "No Badge By That ID";
            }
            else
            {
                _badgeDictionary[key] = badge;
                return "Badge Updated";
            }
        }

        public bool RemoveDoor(int key, string door)
        {
            return _badgeDictionary[key].DoorNames.Remove(door);
        }

        // Delete
        public bool DeleteDoors(int key)
        {
            if(_badgeDictionary[key] == null)
            {
                return false;
            }
            _badgeDictionary[key].DoorNames.Clear();
            return true;
        }

    }
}
