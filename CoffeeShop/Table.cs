using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeShop
{
    class TableList
    {
        public List<Table> Tables = new List<Table>();

        public Table Findtable(int tablenum)
        {
            return this.Tables.Find(
                delegate (Table item)
                {
                    return item.tableNumber == tablenum;
                }
                );
        }
    }
    class Table
    {
        public int tableNumber { get; set; }
        public bool checkUse = true;
        public List<Drink> drinkList = new List<Drink>();
        public Table(int num)
        {
            this.tableNumber = num;
        }
        public Table()
        {

        }

        public void Adddrink(Drink drink)
        {
            drinkList.Add(drink);
        }
    }
}
