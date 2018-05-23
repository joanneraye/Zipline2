using Staunch.POS.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.Models;

namespace Zipline2.BusinessLogic.WcfRemote
{
    public static class ConvertObjects
    {

        public static Order ConvertDbCheckToOrder(DBCheck check, decimal tableId)
        {           
            var openOrder = new Order()
            {
                IsTakeout = false,
                TableId = tableId,
                SubTotal = check.SubTotal,
                Tax = check.Tax,
                Total = check.TotalPrice
            };
            foreach (var item in check.Items)
            {
                var openOrderItem = OrderItemFactory.GetOrderItem(item);
                openOrder.OrderItems.Add(openOrderItem);
            }
            return openOrder;
        }

        public static Table ConvertDbTableToTable(DBTable dbTable)
        {
            return new Table
            {
                IsOccupied = !(dbTable.IsClear),
                TableName = dbTable.Name,
                TableId = dbTable.ID
            };
        }
    }
}
