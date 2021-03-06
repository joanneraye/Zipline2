﻿using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.Models;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Pages;
using Staunch.POS.Classes;
using Zipline2.BusinessLogic.WcfRemote;

namespace Zipline2.BusinessLogic
{
    /// <summary>
    /// Instantiates objects derrived from OrderItems.
    /// </summary>
    public sealed class OrderItemFactory
    {
        public OrderItemFactory()
        {

        }

        public static OrderItem GetBaseOrderItem(OrderItem noToppingsOrderItem)
        {
            noToppingsOrderItem.PopulateDisplayName();
            noToppingsOrderItem.PopulateBasePrice();
            noToppingsOrderItem.PopulatePricePerItem();
            //noToppingsOrderItem.UpdateItemTotal();
            return noToppingsOrderItem;
        }

        //public static OrderItem GetOrderItem(OrderItem partialOrderItem)
        //{

        //    //SHOULD BE ABLE TO CALL METHODS ON OrderItem passed in...
        //    partialOrderItem.PopulateDisplayName();
        //    //partialOrderItem.PopulatePricePerItem();  not yet???
        //    //populate base price???
        //    if (partialOrderItem is Pizza)
        //    {
        //        return CreatePizza(partialOrderItem);
        //    }
        //    else if (partialOrderItem is Drink)
        //    {
        //        return CreateDrink(partialOrderItem);
        //    }
        //    else if (partialOrderItem is Salad)
        //    {
        //        return CreateSalad(partialOrderItem);
        //    }
        //    return null;
           
        //}

        

        


        //private static OrderItem CreatePizza(OrderItem partialDataItem)
        //{
        //    var newPizza = partialDataItem as Pizza;
        //    newPizza.PopulateDisplayName();
        //    newPizza.PopulatePricePerItem();
        //    newPizza.UpdateItemTotal();
        //    return newPizza;
        //}
        //private static OrderItem CreateDrink(OrderItem partialDataItem)
        //{
        //    var newDrink = partialDataItem as Drink;
        //    newDrink.CompleteOrderItem();
        //    return newDrink;
        //}

        //private static OrderItem CreateSalad(OrderItem partialDataItem)
        //{
        //    var newSalad = partialDataItem as Salad;
        //    return newSalad;
        //}
        //private static OrderItem CreateDessert(CustomerSelection guiData)
        //{
        //    return new Dessert(guiData);
        //}
        //private static OrderItem CreateLunchSpecial(CustomerSelection guiData)
        //{
        //    return new LunchSpecial(guiData);
        //}
        //private static OrderItem CreateMerchandise(CustomerSelection guiData)
        //{
        //    return new Merchandise(guiData);
        //}
    }
}
