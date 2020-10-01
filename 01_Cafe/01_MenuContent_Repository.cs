using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class MenuContentRepository
    {
        protected readonly List<MenuContent> _menuDirectory = new List<MenuContent>();
        //CRD - no U needed
        public bool AddContentToDirectory(MenuContent content)
        {
            int startingCount = _menuDirectory.Count;
            _menuDirectory.Add(content);
            bool wasAdded = (_menuDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        //Read All
        public List<MenuContent> GetContents()
        {
            return _menuDirectory;
        }
        //Read One
        public MenuContent GetContentItemByMenuNumber(string menuNumber)
        {
            foreach(MenuContent singleContent in _menuDirectory)
            {
                if (singleContent.MenuNumber.ToLower() == menuNumber.ToLower())
                {
                    return singleContent;
                }
            }
            return null;
        }
        //delete
        public bool DeleteExistingContent (MenuContent existingContent)
        {
            bool deleteResult = _menuDirectory.Remove(existingContent);
            return deleteResult;
        }
    }
}
