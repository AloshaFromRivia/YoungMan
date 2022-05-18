using System;
using System.Collections.Generic;
using System.Linq;

namespace YoungMan.Models
{
    public class PaginatedList<T>
    {
        private IEnumerable<T> _itemsList;

        public int ItemsPerPage { get; set; }
        
        public PaginatedList(IEnumerable<T> items)
        {
            _itemsList = items;
        }

        public IEnumerable<T> GetItemsByPage(int page) => _itemsList.Skip(ItemsPerPage*page).Take(ItemsPerPage);
    }
}