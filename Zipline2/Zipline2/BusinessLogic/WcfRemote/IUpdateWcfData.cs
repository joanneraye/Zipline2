using Staunch.POS.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zipline2.Models;

namespace Zipline2.BusinessLogic.WcfRemote
{
    interface IUpdateWcfData
    {
        void UpdateTable(DBTable currentTable);
        Task UpdateTableAsync(DBTable currentTable);

        void UpdateOrder(Order orderToUpdate);
        Task UpdateOrderAsync(Order orderToUpdate);

        void SendOrders(List<decimal> orderIds, decimal userId);
        void SendOrdersAsync(List<decimal> orderIds, decimal userId);

        void CreateCheck(DBCheck dbCheck);
        Task CreateCheckAsync(DBCheck dbCheck);

        Task PrepareAndSendOrderAsync(Order orderToSend);

        
    }
}
