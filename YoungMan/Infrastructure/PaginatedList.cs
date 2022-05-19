using System;
using System.Collections.Generic;
using System.Linq;

namespace YoungMan.Infrastructure
{
    public class PaginatedList<T>
    {
        private IEnumerable<T> _itemsList;

        public int ItemsPerPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)_itemsList.Count() / ItemsPerPage);
        
        public PaginatedList(IEnumerable<T> items)
        {
            _itemsList = items;
        }

        public IEnumerable<T> GetItemsByPage(int page) => _itemsList.Skip(ItemsPerPage*page).Take(ItemsPerPage);
    }
}