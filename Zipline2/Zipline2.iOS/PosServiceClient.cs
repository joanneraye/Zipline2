using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

using Foundation;
using Staunch.POS.Classes;
using UIKit;
using Zipline2.ConnectedServices;

namespace Zipline2.iOS
{
    public partial class PosServiceClient
    {
       
        //private class ConsumerServiceClientChannel : System.ServiceModel.Channels.ChannelFactoryBase<IPosService>, IPosService
        //{
        //    private PosServiceClient posServiceClient;

        //    public ConsumerServiceClientChannel(PosServiceClient posServiceClient)
        //    {
        //        this.posServiceClient = posServiceClient;
        //    }

        //    protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    protected override IPosService OnCreateChannel(EndpointAddress address, Uri via)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    protected override void OnEndOpen(IAsyncResult result)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    protected override void OnOpen(TimeSpan timeout)
        //    {
        //        throw new NotImplementedException();
        //    }

            //    public bool AddOrdersToPlate(List<decimal> orderIds, decimal plateId)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool AddOrderToPlate(decimal OrderID, decimal PlateID)
            //    {

            //    }

            //    public IAsyncResult BeginAddOrdersToPlate(List<decimal> orderIds, decimal plateId, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginAddOrderToPlate(decimal OrderID, decimal PlateID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginCancelTakeout(decimal TakeoutGuestID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginChangeItemSize(decimal orderID, decimal newSizeID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginClearTable(decimal TableID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginClearTakeoutOrder(decimal TakeoutID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginCombineOrders(decimal DestinationGuestID, List<decimal> GuestsToMoveIDs, bool RemoveAfterCombine, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginDoAutoGratuity(AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginFillTables(decimal userID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginGetAllCateringOrdersInfo(AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginGetAllMods(decimal ItemID, decimal SizeID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginGetAvailablePaymentOptions(AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginGetCategoryNames(AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginGetCateringOrder(decimal TakeoutID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginGetCateringTakeouts(AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginGetComboMenu(AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginGetGratuityLimit(AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginGetGratuityRate(AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginGetItemInfo(decimal ItemID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginGetLSEOrders(AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginGetManagerSettings(AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginGetMenu(AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginGetModifiers(AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginGetModsForAllItems(AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginGetNextGuestIDs(int num, decimal userID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginGetOrders(decimal TableID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginGetRequiredMods(decimal ItemID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginGetSpecialItems(AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginGetTable(int tableNum, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginGetTableInfo(AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginGetTablesForSection(decimal sectionID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginGetTableSummary(AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginGetTakeoutOrder(decimal GuestID, decimal CheckID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginGetTakeoutOrders(AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginGetTaxRate(AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginGetThumbnails(List<decimal> ItemIDs, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginGetUser(string pin, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginHasUnsentOrders(decimal TableID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginListUnsentOrders(List<decimal> TableIDList, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginLogout(decimal UserID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginMoveGuests(List<decimal> GuestIDs, decimal NewTableID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginPing(int Delay, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginPriceOrder(Guest_DB guest, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginPrintCateringOrder(CateringOrder catering, decimal UserID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginPrintKitchenNote(string note, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginPrintMoveNotice(List<decimal> orderIDs, decimal fromTableID, decimal toTableID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginRemoveGuest(decimal GuestID, bool RemoveOrder, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginRemoveGuestCombo(decimal GuestID, decimal OrderComboID, decimal UserID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginRemoveItem(decimal GuestID, decimal OrderID, decimal UserID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginRemoveMultipleFromPlate(List<decimal> orderIDs, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginRemoveOrderFromPlate(decimal OrderID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginRemoveSentOrder(List<decimal> OrderIDs, decimal UserID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginSaveUserSettings(DBUser user, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginSendCateringTakeout(TakeoutOrder TakeoutGuest, decimal UserID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginSendOrders(List<decimal> OrderIDs, decimal UserID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginSendTakeout(TakeoutOrder TakeoutGuest, decimal UserID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginSplitTable(decimal TableID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginSubmitCatering(CateringOrder catering, decimal UserID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginSubmitLSETakeout(TakeoutOrder TakeoutGuest, decimal UserID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginSubmitTakeout(TakeoutOrder TakeoutGuest, decimal UserID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginUpdateTables(List<DBTable> updatedTables, decimal userID, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public IAsyncResult BeginValidateUser(decimal AuthenticationID, string UserName, string Pin, AsyncCallback callback, object asyncState)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool CancelTakeout(decimal TakeoutGuestID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool ChangeItemSize(decimal orderID, decimal newSizeID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool ClearTable(decimal TableID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool ClearTakeoutOrder(decimal TakeoutID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool CombineOrders(decimal DestinationGuestID, List<decimal> GuestsToMoveIDs, bool RemoveAfterCombine)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool DoAutoGratuity()
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool EndAddOrdersToPlate(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool EndAddOrderToPlate(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool EndCancelTakeout(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool EndChangeItemSize(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool EndClearTable(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool EndClearTakeoutOrder(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool EndCombineOrders(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool EndDoAutoGratuity(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<DBTable> EndFillTables(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<CateringOrder> EndGetAllCateringOrdersInfo(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<DBModGroup> EndGetAllMods(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<string> EndGetAvailablePaymentOptions(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<string> EndGetCategoryNames(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public CateringOrder EndGetCateringOrder(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<TakeoutOrder> EndGetCateringTakeouts(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<ComboItem> EndGetComboMenu(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public int EndGetGratuityLimit(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public decimal EndGetGratuityRate(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public ItemInfo EndGetItemInfo(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<TakeoutOrder> EndGetLSEOrders(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public ManagerSettings EndGetManagerSettings(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public Dictionary<string, List<DBItem>> EndGetMenu(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<DBModGroup> EndGetModifiers(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public Dictionary<decimal, Dictionary<decimal, List<DBModGroup>>> EndGetModsForAllItems(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<decimal> EndGetNextGuestIDs(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<GuestItem> EndGetOrders(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<DBModGroup> EndGetRequiredMods(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<DBItem> EndGetSpecialItems(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public DBTable EndGetTable(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<DBTable> EndGetTableInfo(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<DBTable> EndGetTablesForSection(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<DBTable> EndGetTableSummary(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public TakeoutOrder EndGetTakeoutOrder(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<TakeoutOrder> EndGetTakeoutOrders(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public decimal EndGetTaxRate(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public Dictionary<decimal, PictureFile> EndGetThumbnails(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public DBUser EndGetUser(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool EndHasUnsentOrders(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<decimal> EndListUnsentOrders(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool EndLogout(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool EndMoveGuests(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public int EndPing(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public Guest_DB EndPriceOrder(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public void EndPrintCateringOrder(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public void EndPrintKitchenNote(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool EndPrintMoveNotice(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool EndRemoveGuest(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool EndRemoveGuestCombo(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool EndRemoveItem(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool EndRemoveMultipleFromPlate(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool EndRemoveOrderFromPlate(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public void EndRemoveSentOrder(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool EndSaveUserSettings(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public void EndSendCateringTakeout(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public void EndSendOrders(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public void EndSendTakeout(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool EndSplitTable(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public CateringOrder EndSubmitCatering(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public TakeoutOrder EndSubmitLSETakeout(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public TakeoutOrder EndSubmitTakeout(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public void EndUpdateTables(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public DBUser EndValidateUser(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<DBTable> FillTables(decimal userID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<CateringOrder> GetAllCateringOrdersInfo()
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<DBModGroup> GetAllMods(decimal ItemID, decimal SizeID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<string> GetAvailablePaymentOptions()
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<string> GetCategoryNames()
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public CateringOrder GetCateringOrder(decimal TakeoutID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<TakeoutOrder> GetCateringTakeouts()
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<ComboItem> GetComboMenu()
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public int GetGratuityLimit()
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public decimal GetGratuityRate()
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public ItemInfo GetItemInfo(decimal ItemID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<TakeoutOrder> GetLSEOrders()
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public ManagerSettings GetManagerSettings()
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public Dictionary<string, List<DBItem>> GetMenu()
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<DBModGroup> GetModifiers()
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public Dictionary<decimal, Dictionary<decimal, List<DBModGroup>>> GetModsForAllItems()
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<decimal> GetNextGuestIDs(int num, decimal userID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<GuestItem> GetOrders(decimal TableID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<DBModGroup> GetRequiredMods(decimal ItemID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<DBItem> GetSpecialItems()
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public DBTable GetTable(int tableNum)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<DBTable> GetTableInfo()
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<DBTable> GetTablesForSection(decimal sectionID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<DBTable> GetTableSummary()
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public TakeoutOrder GetTakeoutOrder(decimal GuestID, decimal CheckID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<TakeoutOrder> GetTakeoutOrders()
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public decimal GetTaxRate()
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public Dictionary<decimal, PictureFile> GetThumbnails(List<decimal> ItemIDs)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public DBUser GetUser(string pin)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool HasUnsentOrders(decimal TableID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public List<decimal> ListUnsentOrders(List<decimal> TableIDList)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool Logout(decimal UserID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool MoveGuests(List<decimal> GuestIDs, decimal NewTableID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public int Ping(int Delay)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public Guest_DB PriceOrder(Guest_DB guest)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public void PrintCateringOrder(CateringOrder catering, decimal UserID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public void PrintKitchenNote(string note)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool PrintMoveNotice(List<decimal> orderIDs, decimal fromTableID, decimal toTableID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool RemoveGuest(decimal GuestID, bool RemoveOrder)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool RemoveGuestCombo(decimal GuestID, decimal OrderComboID, decimal UserID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool RemoveItem(decimal GuestID, decimal OrderID, decimal UserID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool RemoveMultipleFromPlate(List<decimal> orderIDs)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool RemoveOrderFromPlate(decimal OrderID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public void RemoveSentOrder(List<decimal> OrderIDs, decimal UserID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool SaveUserSettings(DBUser user)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public void SendCateringTakeout(TakeoutOrder TakeoutGuest, decimal UserID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public void SendOrders(List<decimal> OrderIDs, decimal UserID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public void SendTakeout(TakeoutOrder TakeoutGuest, decimal UserID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public bool SplitTable(decimal TableID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public CateringOrder SubmitCatering(CateringOrder catering, decimal UserID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public TakeoutOrder SubmitLSETakeout(TakeoutOrder TakeoutGuest, decimal UserID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public TakeoutOrder SubmitTakeout(TakeoutOrder TakeoutGuest, decimal UserID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public void UpdateTables(List<DBTable> updatedTables, decimal userID)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    public DBUser ValidateUser(decimal AuthenticationID, string UserName, string Pin)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    protected override void OnAbort()
            //    {
            //        throw new NotImplementedException();
            //    }

            //    protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    protected override void OnClose(TimeSpan timeout)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    protected override IPosService OnCreateChannel(EndpointAddress address, Uri via)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    protected override void OnEndClose(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    protected override void OnEndOpen(IAsyncResult result)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    protected override void OnOpen(TimeSpan timeout)
            //    {
            //        throw new NotImplementedException();
            //    }
            //}

        }
}