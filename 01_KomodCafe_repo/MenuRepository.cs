using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodCafe_repo
{
    public class MenuRepository
    {
        public List<Menu> _menu = new List<Menu>();
        private int count = 1;

        // Create
        public bool AddMenuItem(Menu item)
        {
            int old = _menu.Count;
            item.Id = count;
            _menu.Add(item);
            if(_menu.Count > old)
            {
                count++;
                return true;
            }
            else
            {
                return false;
            }
        }

        // Read
        public Menu GetMenuItemById(int id)
        {
            foreach(Menu i in _menu)
            {
               if(i.Id == id)
                {
                    return i;
                }
            }
            return null;
        }

        public List<Menu> GetMenu()
        {
            return _menu;
        }

        // Delete
        public bool DeleteMenuItem(int id)
        {
            Menu item = GetMenuItemById(id);
            if(item == null)
            {
                return false;
            }
            return _menu.Remove(item);
        }
    }
}
