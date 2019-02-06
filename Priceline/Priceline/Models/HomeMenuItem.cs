using System;
using System.Collections.Generic;
using System.Text;

namespace Priceline.Models
{
    public enum MenuItemType
    {
        Home,
        About,
        Account
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
