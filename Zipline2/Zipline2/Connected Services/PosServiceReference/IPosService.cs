using System;
using System.Collections.Generic;
using System.Text;

namespace Zipline2.Connected_Services
{
 
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "IPosService")]
    public interface IPosService
    {
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/GetTable", ReplyAction = "http://tempuri.org/IPosService/GetTableResponse")]
        Staunch.POS.Classes.DBTable GetTable(int tableNum);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/GetTable", ReplyAction = "http://tempuri.org/IPosService/GetTableResponse")]
        System.IAsyncResult BeginGetTable(int tableNum, System.AsyncCallback callback, object asyncState);

        Staunch.POS.Classes.DBTable EndGetTable(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/ValidateUser", ReplyAction = "http://tempuri.org/IPosService/ValidateUserResponse")]
        Staunch.POS.Classes.DBUser ValidateUser(decimal AuthenticationID, string UserName, string Pin);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/ValidateUser", ReplyAction = "http://tempuri.org/IPosService/ValidateUserResponse")]
        System.IAsyncResult BeginValidateUser(decimal AuthenticationID, string UserName, string Pin, System.AsyncCallback callback, object asyncState);

        Staunch.POS.Classes.DBUser EndValidateUser(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/GetTableInfo", ReplyAction = "http://tempuri.org/IPosService/GetTableInfoResponse")]
        System.Collections.Generic.List<Staunch.POS.Classes.DBTable> GetTableInfo();

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/GetTableInfo", ReplyAction = "http://tempuri.org/IPosService/GetTableInfoResponse")]
        System.IAsyncResult BeginGetTableInfo(System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.List<Staunch.POS.Classes.DBTable> EndGetTableInfo(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/FillTables", ReplyAction = "http://tempuri.org/IPosService/FillTablesResponse")]
        System.Collections.Generic.List<Staunch.POS.Classes.DBTable> FillTables(decimal userID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/FillTables", ReplyAction = "http://tempuri.org/IPosService/FillTablesResponse")]
        System.IAsyncResult BeginFillTables(decimal userID, System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.List<Staunch.POS.Classes.DBTable> EndFillTables(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/GetMenu", ReplyAction = "http://tempuri.org/IPosService/GetMenuResponse")]
        System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<Staunch.POS.Classes.DBItem>> GetMenu();

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/GetMenu", ReplyAction = "http://tempuri.org/IPosService/GetMenuResponse")]
        System.IAsyncResult BeginGetMenu(System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<Staunch.POS.Classes.DBItem>> EndGetMenu(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/GetModifiers", ReplyAction = "http://tempuri.org/IPosService/GetModifiersResponse")]
        System.Collections.Generic.List<Staunch.POS.Classes.DBModGroup> GetModifiers();

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/GetModifiers", ReplyAction = "http://tempuri.org/IPosService/GetModifiersResponse")]
        System.IAsyncResult BeginGetModifiers(System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.List<Staunch.POS.Classes.DBModGroup> EndGetModifiers(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/GetAvailablePaymentOptions", ReplyAction = "http://tempuri.org/IPosService/GetAvailablePaymentOptionsResponse")]
        System.Collections.Generic.List<string> GetAvailablePaymentOptions();

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/GetAvailablePaymentOptions", ReplyAction = "http://tempuri.org/IPosService/GetAvailablePaymentOptionsResponse")]
        System.IAsyncResult BeginGetAvailablePaymentOptions(System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.List<string> EndGetAvailablePaymentOptions(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/UpdateTables", ReplyAction = "http://tempuri.org/IPosService/UpdateTablesResponse")]
        void UpdateTables(System.Collections.Generic.List<Staunch.POS.Classes.DBTable> updatedTables, decimal userID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/UpdateTables", ReplyAction = "http://tempuri.org/IPosService/UpdateTablesResponse")]
        System.IAsyncResult BeginUpdateTables(System.Collections.Generic.List<Staunch.POS.Classes.DBTable> updatedTables, decimal userID, System.AsyncCallback callback, object asyncState);

        void EndUpdateTables(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/GetGratuityLimit", ReplyAction = "http://tempuri.org/IPosService/GetGratuityLimitResponse")]
        int GetGratuityLimit();

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/GetGratuityLimit", ReplyAction = "http://tempuri.org/IPosService/GetGratuityLimitResponse")]
        System.IAsyncResult BeginGetGratuityLimit(System.AsyncCallback callback, object asyncState);

        int EndGetGratuityLimit(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/GetTaxRate", ReplyAction = "http://tempuri.org/IPosService/GetTaxRateResponse")]
        decimal GetTaxRate();

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/GetTaxRate", ReplyAction = "http://tempuri.org/IPosService/GetTaxRateResponse")]
        System.IAsyncResult BeginGetTaxRate(System.AsyncCallback callback, object asyncState);

        decimal EndGetTaxRate(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/GetGratuityRate", ReplyAction = "http://tempuri.org/IPosService/GetGratuityRateResponse")]
        decimal GetGratuityRate();

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/GetGratuityRate", ReplyAction = "http://tempuri.org/IPosService/GetGratuityRateResponse")]
        System.IAsyncResult BeginGetGratuityRate(System.AsyncCallback callback, object asyncState);

        decimal EndGetGratuityRate(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/DoAutoGratuity", ReplyAction = "http://tempuri.org/IPosService/DoAutoGratuityResponse")]
        bool DoAutoGratuity();

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/DoAutoGratuity", ReplyAction = "http://tempuri.org/IPosService/DoAutoGratuityResponse")]
        System.IAsyncResult BeginDoAutoGratuity(System.AsyncCallback callback, object asyncState);

        bool EndDoAutoGratuity(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/GetCategoryNames", ReplyAction = "http://tempuri.org/IPosService/GetCategoryNamesResponse")]
        System.Collections.Generic.List<string> GetCategoryNames();

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/GetCategoryNames", ReplyAction = "http://tempuri.org/IPosService/GetCategoryNamesResponse")]
        System.IAsyncResult BeginGetCategoryNames(System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.List<string> EndGetCategoryNames(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/GetNextGuestIDs", ReplyAction = "http://tempuri.org/IPosService/GetNextGuestIDsResponse")]
        System.Collections.Generic.List<decimal> GetNextGuestIDs(int num, decimal userID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/GetNextGuestIDs", ReplyAction = "http://tempuri.org/IPosService/GetNextGuestIDsResponse")]
        System.IAsyncResult BeginGetNextGuestIDs(int num, decimal userID, System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.List<decimal> EndGetNextGuestIDs(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/RemoveGuest", ReplyAction = "http://tempuri.org/IPosService/RemoveGuestResponse")]
        bool RemoveGuest(decimal GuestID, bool RemoveOrder);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/RemoveGuest", ReplyAction = "http://tempuri.org/IPosService/RemoveGuestResponse")]
        System.IAsyncResult BeginRemoveGuest(decimal GuestID, bool RemoveOrder, System.AsyncCallback callback, object asyncState);

        bool EndRemoveGuest(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/RemoveItem", ReplyAction = "http://tempuri.org/IPosService/RemoveItemResponse")]
        bool RemoveItem(decimal GuestID, decimal OrderID, decimal UserID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/RemoveItem", ReplyAction = "http://tempuri.org/IPosService/RemoveItemResponse")]
        System.IAsyncResult BeginRemoveItem(decimal GuestID, decimal OrderID, decimal UserID, System.AsyncCallback callback, object asyncState);

        bool EndRemoveItem(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/GetItemInfo", ReplyAction = "http://tempuri.org/IPosService/GetItemInfoResponse")]
        Staunch.POS.Classes.ItemInfo GetItemInfo(decimal ItemID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/GetItemInfo", ReplyAction = "http://tempuri.org/IPosService/GetItemInfoResponse")]
        System.IAsyncResult BeginGetItemInfo(decimal ItemID, System.AsyncCallback callback, object asyncState);

        Staunch.POS.Classes.ItemInfo EndGetItemInfo(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/GetThumbnails", ReplyAction = "http://tempuri.org/IPosService/GetThumbnailsResponse")]
        System.Collections.Generic.Dictionary<decimal, Staunch.POS.Classes.PictureFile> GetThumbnails(System.Collections.Generic.List<decimal> ItemIDs);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/GetThumbnails", ReplyAction = "http://tempuri.org/IPosService/GetThumbnailsResponse")]
        System.IAsyncResult BeginGetThumbnails(System.Collections.Generic.List<decimal> ItemIDs, System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.Dictionary<decimal, Staunch.POS.Classes.PictureFile> EndGetThumbnails(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/GetOrders", ReplyAction = "http://tempuri.org/IPosService/GetOrdersResponse")]
        System.Collections.Generic.List<Staunch.POS.Classes.GuestItem> GetOrders(decimal TableID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/GetOrders", ReplyAction = "http://tempuri.org/IPosService/GetOrdersResponse")]
        System.IAsyncResult BeginGetOrders(decimal TableID, System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.List<Staunch.POS.Classes.GuestItem> EndGetOrders(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/SendOrders", ReplyAction = "http://tempuri.org/IPosService/SendOrdersResponse")]
        void SendOrders(System.Collections.Generic.List<decimal> OrderIDs, decimal UserID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/SendOrders", ReplyAction = "http://tempuri.org/IPosService/SendOrdersResponse")]
        System.IAsyncResult BeginSendOrders(System.Collections.Generic.List<decimal> OrderIDs, decimal UserID, System.AsyncCallback callback, object asyncState);

        void EndSendOrders(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/RemoveSentOrder", ReplyAction = "http://tempuri.org/IPosService/RemoveSentOrderResponse")]
        void RemoveSentOrder(System.Collections.Generic.List<decimal> OrderIDs, decimal UserID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/RemoveSentOrder", ReplyAction = "http://tempuri.org/IPosService/RemoveSentOrderResponse")]
        System.IAsyncResult BeginRemoveSentOrder(System.Collections.Generic.List<decimal> OrderIDs, decimal UserID, System.AsyncCallback callback, object asyncState);

        void EndRemoveSentOrder(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/SaveUserSettings", ReplyAction = "http://tempuri.org/IPosService/SaveUserSettingsResponse")]
        bool SaveUserSettings(Staunch.POS.Classes.DBUser user);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/SaveUserSettings", ReplyAction = "http://tempuri.org/IPosService/SaveUserSettingsResponse")]
        System.IAsyncResult BeginSaveUserSettings(Staunch.POS.Classes.DBUser user, System.AsyncCallback callback, object asyncState);

        bool EndSaveUserSettings(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/MoveGuests", ReplyAction = "http://tempuri.org/IPosService/MoveGuestsResponse")]
        bool MoveGuests(System.Collections.Generic.List<decimal> GuestIDs, decimal NewTableID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/MoveGuests", ReplyAction = "http://tempuri.org/IPosService/MoveGuestsResponse")]
        System.IAsyncResult BeginMoveGuests(System.Collections.Generic.List<decimal> GuestIDs, decimal NewTableID, System.AsyncCallback callback, object asyncState);

        bool EndMoveGuests(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/SplitTable", ReplyAction = "http://tempuri.org/IPosService/SplitTableResponse")]
        bool SplitTable(decimal TableID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/SplitTable", ReplyAction = "http://tempuri.org/IPosService/SplitTableResponse")]
        System.IAsyncResult BeginSplitTable(decimal TableID, System.AsyncCallback callback, object asyncState);

        bool EndSplitTable(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/HasUnsentOrders", ReplyAction = "http://tempuri.org/IPosService/HasUnsentOrdersResponse")]
        bool HasUnsentOrders(decimal TableID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/HasUnsentOrders", ReplyAction = "http://tempuri.org/IPosService/HasUnsentOrdersResponse")]
        System.IAsyncResult BeginHasUnsentOrders(decimal TableID, System.AsyncCallback callback, object asyncState);

        bool EndHasUnsentOrders(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/GetManagerSettings", ReplyAction = "http://tempuri.org/IPosService/GetManagerSettingsResponse")]
        Staunch.POS.Classes.ManagerSettings GetManagerSettings();

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/GetManagerSettings", ReplyAction = "http://tempuri.org/IPosService/GetManagerSettingsResponse")]
        System.IAsyncResult BeginGetManagerSettings(System.AsyncCallback callback, object asyncState);

        Staunch.POS.Classes.ManagerSettings EndGetManagerSettings(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/Logout", ReplyAction = "http://tempuri.org/IPosService/LogoutResponse")]
        bool Logout(decimal UserID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/Logout", ReplyAction = "http://tempuri.org/IPosService/LogoutResponse")]
        System.IAsyncResult BeginLogout(decimal UserID, System.AsyncCallback callback, object asyncState);

        bool EndLogout(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/Ping", ReplyAction = "http://tempuri.org/IPosService/PingResponse")]
        int Ping(int Delay);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/Ping", ReplyAction = "http://tempuri.org/IPosService/PingResponse")]
        System.IAsyncResult BeginPing(int Delay, System.AsyncCallback callback, object asyncState);

        int EndPing(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/GetRequiredMods", ReplyAction = "http://tempuri.org/IPosService/GetRequiredModsResponse")]
        System.Collections.Generic.List<Staunch.POS.Classes.DBModGroup> GetRequiredMods(decimal ItemID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/GetRequiredMods", ReplyAction = "http://tempuri.org/IPosService/GetRequiredModsResponse")]
        System.IAsyncResult BeginGetRequiredMods(decimal ItemID, System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.List<Staunch.POS.Classes.DBModGroup> EndGetRequiredMods(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/GetAllMods", ReplyAction = "http://tempuri.org/IPosService/GetAllModsResponse")]
        System.Collections.Generic.List<Staunch.POS.Classes.DBModGroup> GetAllMods(decimal ItemID, decimal SizeID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/GetAllMods", ReplyAction = "http://tempuri.org/IPosService/GetAllModsResponse")]
        System.IAsyncResult BeginGetAllMods(decimal ItemID, decimal SizeID, System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.List<Staunch.POS.Classes.DBModGroup> EndGetAllMods(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/GetComboMenu", ReplyAction = "http://tempuri.org/IPosService/GetComboMenuResponse")]
        System.Collections.Generic.List<Staunch.POS.Classes.ComboItem> GetComboMenu();

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/GetComboMenu", ReplyAction = "http://tempuri.org/IPosService/GetComboMenuResponse")]
        System.IAsyncResult BeginGetComboMenu(System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.List<Staunch.POS.Classes.ComboItem> EndGetComboMenu(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/RemoveGuestCombo", ReplyAction = "http://tempuri.org/IPosService/RemoveGuestComboResponse")]
        bool RemoveGuestCombo(decimal GuestID, decimal OrderComboID, decimal UserID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/RemoveGuestCombo", ReplyAction = "http://tempuri.org/IPosService/RemoveGuestComboResponse")]
        System.IAsyncResult BeginRemoveGuestCombo(decimal GuestID, decimal OrderComboID, decimal UserID, System.AsyncCallback callback, object asyncState);

        bool EndRemoveGuestCombo(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/CombineOrders", ReplyAction = "http://tempuri.org/IPosService/CombineOrdersResponse")]
        bool CombineOrders(decimal DestinationGuestID, System.Collections.Generic.List<decimal> GuestsToMoveIDs, bool RemoveAfterCombine);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/CombineOrders", ReplyAction = "http://tempuri.org/IPosService/CombineOrdersResponse")]
        System.IAsyncResult BeginCombineOrders(decimal DestinationGuestID, System.Collections.Generic.List<decimal> GuestsToMoveIDs, bool RemoveAfterCombine, System.AsyncCallback callback, object asyncState);

        bool EndCombineOrders(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/ClearTable", ReplyAction = "http://tempuri.org/IPosService/ClearTableResponse")]
        bool ClearTable(decimal TableID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/ClearTable", ReplyAction = "http://tempuri.org/IPosService/ClearTableResponse")]
        System.IAsyncResult BeginClearTable(decimal TableID, System.AsyncCallback callback, object asyncState);

        bool EndClearTable(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/SubmitTakeout", ReplyAction = "http://tempuri.org/IPosService/SubmitTakeoutResponse")]
        Staunch.POS.Classes.TakeoutOrder SubmitTakeout(Staunch.POS.Classes.TakeoutOrder TakeoutGuest, decimal UserID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/SubmitTakeout", ReplyAction = "http://tempuri.org/IPosService/SubmitTakeoutResponse")]
        System.IAsyncResult BeginSubmitTakeout(Staunch.POS.Classes.TakeoutOrder TakeoutGuest, decimal UserID, System.AsyncCallback callback, object asyncState);

        Staunch.POS.Classes.TakeoutOrder EndSubmitTakeout(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/GetTakeoutOrders", ReplyAction = "http://tempuri.org/IPosService/GetTakeoutOrdersResponse")]
        System.Collections.Generic.List<Staunch.POS.Classes.TakeoutOrder> GetTakeoutOrders();

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/GetTakeoutOrders", ReplyAction = "http://tempuri.org/IPosService/GetTakeoutOrdersResponse")]
        System.IAsyncResult BeginGetTakeoutOrders(System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.List<Staunch.POS.Classes.TakeoutOrder> EndGetTakeoutOrders(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/GetTakeoutOrder", ReplyAction = "http://tempuri.org/IPosService/GetTakeoutOrderResponse")]
        Staunch.POS.Classes.TakeoutOrder GetTakeoutOrder(decimal GuestID, decimal CheckID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/GetTakeoutOrder", ReplyAction = "http://tempuri.org/IPosService/GetTakeoutOrderResponse")]
        System.IAsyncResult BeginGetTakeoutOrder(decimal GuestID, decimal CheckID, System.AsyncCallback callback, object asyncState);

        Staunch.POS.Classes.TakeoutOrder EndGetTakeoutOrder(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/SendTakeout", ReplyAction = "http://tempuri.org/IPosService/SendTakeoutResponse")]
        void SendTakeout(Staunch.POS.Classes.TakeoutOrder TakeoutGuest, decimal UserID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/SendTakeout", ReplyAction = "http://tempuri.org/IPosService/SendTakeoutResponse")]
        System.IAsyncResult BeginSendTakeout(Staunch.POS.Classes.TakeoutOrder TakeoutGuest, decimal UserID, System.AsyncCallback callback, object asyncState);

        void EndSendTakeout(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/ClearTakeoutOrder", ReplyAction = "http://tempuri.org/IPosService/ClearTakeoutOrderResponse")]
        bool ClearTakeoutOrder(decimal TakeoutID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/ClearTakeoutOrder", ReplyAction = "http://tempuri.org/IPosService/ClearTakeoutOrderResponse")]
        System.IAsyncResult BeginClearTakeoutOrder(decimal TakeoutID, System.AsyncCallback callback, object asyncState);

        bool EndClearTakeoutOrder(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/ListUnsentOrders", ReplyAction = "http://tempuri.org/IPosService/ListUnsentOrdersResponse")]
        System.Collections.Generic.List<decimal> ListUnsentOrders(System.Collections.Generic.List<decimal> TableIDList);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/ListUnsentOrders", ReplyAction = "http://tempuri.org/IPosService/ListUnsentOrdersResponse")]
        System.IAsyncResult BeginListUnsentOrders(System.Collections.Generic.List<decimal> TableIDList, System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.List<decimal> EndListUnsentOrders(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/PrintMoveNotice", ReplyAction = "http://tempuri.org/IPosService/PrintMoveNoticeResponse")]
        bool PrintMoveNotice(System.Collections.Generic.List<decimal> orderIDs, decimal fromTableID, decimal toTableID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/PrintMoveNotice", ReplyAction = "http://tempuri.org/IPosService/PrintMoveNoticeResponse")]
        System.IAsyncResult BeginPrintMoveNotice(System.Collections.Generic.List<decimal> orderIDs, decimal fromTableID, decimal toTableID, System.AsyncCallback callback, object asyncState);

        bool EndPrintMoveNotice(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/GetModsForAllItems", ReplyAction = "http://tempuri.org/IPosService/GetModsForAllItemsResponse")]
        System.Collections.Generic.Dictionary<decimal, System.Collections.Generic.Dictionary<decimal, System.Collections.Generic.List<Staunch.POS.Classes.DBModGroup>>> GetModsForAllItems();

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/GetModsForAllItems", ReplyAction = "http://tempuri.org/IPosService/GetModsForAllItemsResponse")]
        System.IAsyncResult BeginGetModsForAllItems(System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.Dictionary<decimal, System.Collections.Generic.Dictionary<decimal, System.Collections.Generic.List<Staunch.POS.Classes.DBModGroup>>> EndGetModsForAllItems(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/GetSpecialItems", ReplyAction = "http://tempuri.org/IPosService/GetSpecialItemsResponse")]
        System.Collections.Generic.List<Staunch.POS.Classes.DBItem> GetSpecialItems();

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/GetSpecialItems", ReplyAction = "http://tempuri.org/IPosService/GetSpecialItemsResponse")]
        System.IAsyncResult BeginGetSpecialItems(System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.List<Staunch.POS.Classes.DBItem> EndGetSpecialItems(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/GetTablesForSection", ReplyAction = "http://tempuri.org/IPosService/GetTablesForSectionResponse")]
        System.Collections.Generic.List<Staunch.POS.Classes.DBTable> GetTablesForSection(decimal sectionID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/GetTablesForSection", ReplyAction = "http://tempuri.org/IPosService/GetTablesForSectionResponse")]
        System.IAsyncResult BeginGetTablesForSection(decimal sectionID, System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.List<Staunch.POS.Classes.DBTable> EndGetTablesForSection(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/ChangeItemSize", ReplyAction = "http://tempuri.org/IPosService/ChangeItemSizeResponse")]
        bool ChangeItemSize(decimal orderID, decimal newSizeID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/ChangeItemSize", ReplyAction = "http://tempuri.org/IPosService/ChangeItemSizeResponse")]
        System.IAsyncResult BeginChangeItemSize(decimal orderID, decimal newSizeID, System.AsyncCallback callback, object asyncState);

        bool EndChangeItemSize(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/GetUser", ReplyAction = "http://tempuri.org/IPosService/GetUserResponse")]
        Staunch.POS.Classes.DBUser GetUser(string pin);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/GetUser", ReplyAction = "http://tempuri.org/IPosService/GetUserResponse")]
        System.IAsyncResult BeginGetUser(string pin, System.AsyncCallback callback, object asyncState);

        Staunch.POS.Classes.DBUser EndGetUser(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/CancelTakeout", ReplyAction = "http://tempuri.org/IPosService/CancelTakeoutResponse")]
        bool CancelTakeout(decimal TakeoutGuestID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/CancelTakeout", ReplyAction = "http://tempuri.org/IPosService/CancelTakeoutResponse")]
        System.IAsyncResult BeginCancelTakeout(decimal TakeoutGuestID, System.AsyncCallback callback, object asyncState);

        bool EndCancelTakeout(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/GetLSEOrders", ReplyAction = "http://tempuri.org/IPosService/GetLSEOrdersResponse")]
        System.Collections.Generic.List<Staunch.POS.Classes.TakeoutOrder> GetLSEOrders();

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/GetLSEOrders", ReplyAction = "http://tempuri.org/IPosService/GetLSEOrdersResponse")]
        System.IAsyncResult BeginGetLSEOrders(System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.List<Staunch.POS.Classes.TakeoutOrder> EndGetLSEOrders(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/SubmitLSETakeout", ReplyAction = "http://tempuri.org/IPosService/SubmitLSETakeoutResponse")]
        Staunch.POS.Classes.TakeoutOrder SubmitLSETakeout(Staunch.POS.Classes.TakeoutOrder TakeoutGuest, decimal UserID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/SubmitLSETakeout", ReplyAction = "http://tempuri.org/IPosService/SubmitLSETakeoutResponse")]
        System.IAsyncResult BeginSubmitLSETakeout(Staunch.POS.Classes.TakeoutOrder TakeoutGuest, decimal UserID, System.AsyncCallback callback, object asyncState);

        Staunch.POS.Classes.TakeoutOrder EndSubmitLSETakeout(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/PriceOrder", ReplyAction = "http://tempuri.org/IPosService/PriceOrderResponse")]
        Staunch.POS.Classes.Guest_DB PriceOrder(Staunch.POS.Classes.Guest_DB guest);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/PriceOrder", ReplyAction = "http://tempuri.org/IPosService/PriceOrderResponse")]
        System.IAsyncResult BeginPriceOrder(Staunch.POS.Classes.Guest_DB guest, System.AsyncCallback callback, object asyncState);

        Staunch.POS.Classes.Guest_DB EndPriceOrder(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/PrintKitchenNote", ReplyAction = "http://tempuri.org/IPosService/PrintKitchenNoteResponse")]
        void PrintKitchenNote(string note);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/PrintKitchenNote", ReplyAction = "http://tempuri.org/IPosService/PrintKitchenNoteResponse")]
        System.IAsyncResult BeginPrintKitchenNote(string note, System.AsyncCallback callback, object asyncState);

        void EndPrintKitchenNote(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/RemoveOrderFromPlate", ReplyAction = "http://tempuri.org/IPosService/RemoveOrderFromPlateResponse")]
        bool RemoveOrderFromPlate(decimal OrderID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/RemoveOrderFromPlate", ReplyAction = "http://tempuri.org/IPosService/RemoveOrderFromPlateResponse")]
        System.IAsyncResult BeginRemoveOrderFromPlate(decimal OrderID, System.AsyncCallback callback, object asyncState);

        bool EndRemoveOrderFromPlate(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/AddOrderToPlate", ReplyAction = "http://tempuri.org/IPosService/AddOrderToPlateResponse")]
        bool AddOrderToPlate(decimal OrderID, decimal PlateID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/AddOrderToPlate", ReplyAction = "http://tempuri.org/IPosService/AddOrderToPlateResponse")]
        System.IAsyncResult BeginAddOrderToPlate(decimal OrderID, decimal PlateID, System.AsyncCallback callback, object asyncState);

        bool EndAddOrderToPlate(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/AddOrdersToPlate", ReplyAction = "http://tempuri.org/IPosService/AddOrdersToPlateResponse")]
        bool AddOrdersToPlate(System.Collections.Generic.List<decimal> orderIds, decimal plateId);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/AddOrdersToPlate", ReplyAction = "http://tempuri.org/IPosService/AddOrdersToPlateResponse")]
        System.IAsyncResult BeginAddOrdersToPlate(System.Collections.Generic.List<decimal> orderIds, decimal plateId, System.AsyncCallback callback, object asyncState);

        bool EndAddOrdersToPlate(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/RemoveMultipleFromPlate", ReplyAction = "http://tempuri.org/IPosService/RemoveMultipleFromPlateResponse")]
        bool RemoveMultipleFromPlate(System.Collections.Generic.List<decimal> orderIDs);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/RemoveMultipleFromPlate", ReplyAction = "http://tempuri.org/IPosService/RemoveMultipleFromPlateResponse")]
        System.IAsyncResult BeginRemoveMultipleFromPlate(System.Collections.Generic.List<decimal> orderIDs, System.AsyncCallback callback, object asyncState);

        bool EndRemoveMultipleFromPlate(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/SubmitCatering", ReplyAction = "http://tempuri.org/IPosService/SubmitCateringResponse")]
        Staunch.POS.Classes.CateringOrder SubmitCatering(Staunch.POS.Classes.CateringOrder catering, decimal UserID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/SubmitCatering", ReplyAction = "http://tempuri.org/IPosService/SubmitCateringResponse")]
        System.IAsyncResult BeginSubmitCatering(Staunch.POS.Classes.CateringOrder catering, decimal UserID, System.AsyncCallback callback, object asyncState);

        Staunch.POS.Classes.CateringOrder EndSubmitCatering(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/GetCateringTakeouts", ReplyAction = "http://tempuri.org/IPosService/GetCateringTakeoutsResponse")]
        System.Collections.Generic.List<Staunch.POS.Classes.TakeoutOrder> GetCateringTakeouts();

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/GetCateringTakeouts", ReplyAction = "http://tempuri.org/IPosService/GetCateringTakeoutsResponse")]
        System.IAsyncResult BeginGetCateringTakeouts(System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.List<Staunch.POS.Classes.TakeoutOrder> EndGetCateringTakeouts(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/GetCateringOrder", ReplyAction = "http://tempuri.org/IPosService/GetCateringOrderResponse")]
        Staunch.POS.Classes.CateringOrder GetCateringOrder(decimal TakeoutID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/GetCateringOrder", ReplyAction = "http://tempuri.org/IPosService/GetCateringOrderResponse")]
        System.IAsyncResult BeginGetCateringOrder(decimal TakeoutID, System.AsyncCallback callback, object asyncState);

        Staunch.POS.Classes.CateringOrder EndGetCateringOrder(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/GetAllCateringOrdersInfo", ReplyAction = "http://tempuri.org/IPosService/GetAllCateringOrdersInfoResponse")]
        System.Collections.Generic.List<Staunch.POS.Classes.CateringOrder> GetAllCateringOrdersInfo();

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/GetAllCateringOrdersInfo", ReplyAction = "http://tempuri.org/IPosService/GetAllCateringOrdersInfoResponse")]
        System.IAsyncResult BeginGetAllCateringOrdersInfo(System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.List<Staunch.POS.Classes.CateringOrder> EndGetAllCateringOrdersInfo(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/SendCateringTakeout", ReplyAction = "http://tempuri.org/IPosService/SendCateringTakeoutResponse")]
        void SendCateringTakeout(Staunch.POS.Classes.TakeoutOrder TakeoutGuest, decimal UserID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/SendCateringTakeout", ReplyAction = "http://tempuri.org/IPosService/SendCateringTakeoutResponse")]
        System.IAsyncResult BeginSendCateringTakeout(Staunch.POS.Classes.TakeoutOrder TakeoutGuest, decimal UserID, System.AsyncCallback callback, object asyncState);

        void EndSendCateringTakeout(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/GetTableSummary", ReplyAction = "http://tempuri.org/IPosService/GetTableSummaryResponse")]
        System.Collections.Generic.List<Staunch.POS.Classes.DBTable> GetTableSummary();

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/GetTableSummary", ReplyAction = "http://tempuri.org/IPosService/GetTableSummaryResponse")]
        System.IAsyncResult BeginGetTableSummary(System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.List<Staunch.POS.Classes.DBTable> EndGetTableSummary(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IPosService/PrintCateringOrder", ReplyAction = "http://tempuri.org/IPosService/PrintCateringOrderResponse")]
        void PrintCateringOrder(Staunch.POS.Classes.CateringOrder catering, decimal UserID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IPosService/PrintCateringOrder", ReplyAction = "http://tempuri.org/IPosService/PrintCateringOrderResponse")]
        System.IAsyncResult BeginPrintCateringOrder(Staunch.POS.Classes.CateringOrder catering, decimal UserID, System.AsyncCallback callback, object asyncState);

        void EndPrintCateringOrder(System.IAsyncResult result);
    }
 }