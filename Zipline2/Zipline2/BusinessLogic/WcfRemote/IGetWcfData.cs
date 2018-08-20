using Staunch.POS.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Zipline2.BusinessLogic.WcfRemote
{
    interface IGetWcfData
    {
        List<DBModGroup> GetPizzaToppings();
        Task<List<DBModGroup>> GetPizzaToppingsAsync();

        List<DBModGroup> GetSaladToppings();
        Task<List<DBModGroup>> GetSaladToppingsAsync();

        DBTable GetTable(int tableNum);
        Task<DBTable> GetTableAsync(int tableNum);

        void GetTables();
        Task GetTablesAsync();

        Task<List<DBTable>> GetTablesForSectionAsync(decimal sectionID);

        void GetMenu();
        Task GetMenuAsync();

        decimal GetNextGuestId();
        Task<decimal> GetNextGuestIdAsync();

        List<decimal> GetGuestIds(decimal tableId);
        Task<List<decimal>> GetGuestIdsAsync(decimal tableId);

        List<DBTable> GetTableInfo();
        Task<List<DBTable>> GetTableInfoAsync();

        DBUser GetUser(string pin);
        Task<DBUser> GetUserAsync(string pin);

        Task<List<DBCheck>> GetOpenChecksAsync(decimal tableId);

        Task<bool> HasOpenChecksAsync(decimal tableId);
    }
}
