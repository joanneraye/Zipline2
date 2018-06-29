using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Text;

using Foundation;
using Staunch.POS.Classes;
using UIKit;
using Zipline2.Connected_Services;
using Zipline2.ConnectedServices;
using Zipline2.iOS.Services;

[assembly: Dependency (typeof(PosServiceClientIos))]
namespace Zipline2.iOS.Services
{
    
   
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]

        public class PosServiceClientIos : System.ServiceModel.ClientBase<IPosService>, IPosService
        {

            protected override IPosService CreateChannel()
            {
                return new PosServiceChannel(this);
            }

            public PosServiceClientIos()
            {
            }

            public PosServiceClientIos(string endpointConfigurationName) :
                    base(endpointConfigurationName)
            {
            }

            public PosServiceClientIos(string endpointConfigurationName, string remoteAddress) :
                    base(endpointConfigurationName, remoteAddress)
            {
            }

            public PosServiceClientIos(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                    base(endpointConfigurationName, remoteAddress)
            {
            }

            public PosServiceClientIos(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                    base(binding, remoteAddress)
            {
            }

            #region Delegates
            private BeginOperationDelegate onBeginGetTableDelegate;

            private EndOperationDelegate onEndGetTableDelegate;

            private System.Threading.SendOrPostCallback onGetTableCompletedDelegate;

            private BeginOperationDelegate onBeginValidateUserDelegate;

            private EndOperationDelegate onEndValidateUserDelegate;

            private System.Threading.SendOrPostCallback onValidateUserCompletedDelegate;

            private BeginOperationDelegate onBeginGetTableInfoDelegate;

            private EndOperationDelegate onEndGetTableInfoDelegate;

            private System.Threading.SendOrPostCallback onGetTableInfoCompletedDelegate;

            private BeginOperationDelegate onBeginFillTablesDelegate;

            private EndOperationDelegate onEndFillTablesDelegate;

            private System.Threading.SendOrPostCallback onFillTablesCompletedDelegate;

            private BeginOperationDelegate onBeginGetMenuDelegate;

            private EndOperationDelegate onEndGetMenuDelegate;

            private System.Threading.SendOrPostCallback onGetMenuCompletedDelegate;

            private BeginOperationDelegate onBeginGetModifiersDelegate;

            private EndOperationDelegate onEndGetModifiersDelegate;

            private System.Threading.SendOrPostCallback onGetModifiersCompletedDelegate;

            private BeginOperationDelegate onBeginGetAvailablePaymentOptionsDelegate;

            private EndOperationDelegate onEndGetAvailablePaymentOptionsDelegate;

            private System.Threading.SendOrPostCallback onGetAvailablePaymentOptionsCompletedDelegate;

            private BeginOperationDelegate onBeginUpdateTablesDelegate;

            private EndOperationDelegate onEndUpdateTablesDelegate;

            private System.Threading.SendOrPostCallback onUpdateTablesCompletedDelegate;

            private BeginOperationDelegate onBeginGetGratuityLimitDelegate;

            private EndOperationDelegate onEndGetGratuityLimitDelegate;

            private System.Threading.SendOrPostCallback onGetGratuityLimitCompletedDelegate;

            private BeginOperationDelegate onBeginGetTaxRateDelegate;

            private EndOperationDelegate onEndGetTaxRateDelegate;

            private System.Threading.SendOrPostCallback onGetTaxRateCompletedDelegate;

            private BeginOperationDelegate onBeginGetGratuityRateDelegate;

            private EndOperationDelegate onEndGetGratuityRateDelegate;

            private System.Threading.SendOrPostCallback onGetGratuityRateCompletedDelegate;

            private BeginOperationDelegate onBeginDoAutoGratuityDelegate;

            private EndOperationDelegate onEndDoAutoGratuityDelegate;

            private System.Threading.SendOrPostCallback onDoAutoGratuityCompletedDelegate;

            private BeginOperationDelegate onBeginGetCategoryNamesDelegate;

            private EndOperationDelegate onEndGetCategoryNamesDelegate;

            private System.Threading.SendOrPostCallback onGetCategoryNamesCompletedDelegate;

            private BeginOperationDelegate onBeginGetNextGuestIDsDelegate;

            private EndOperationDelegate onEndGetNextGuestIDsDelegate;

            private System.Threading.SendOrPostCallback onGetNextGuestIDsCompletedDelegate;

            private BeginOperationDelegate onBeginRemoveGuestDelegate;

            private EndOperationDelegate onEndRemoveGuestDelegate;

            private System.Threading.SendOrPostCallback onRemoveGuestCompletedDelegate;

            private BeginOperationDelegate onBeginRemoveItemDelegate;

            private EndOperationDelegate onEndRemoveItemDelegate;

            private System.Threading.SendOrPostCallback onRemoveItemCompletedDelegate;

            private BeginOperationDelegate onBeginGetItemInfoDelegate;

            private EndOperationDelegate onEndGetItemInfoDelegate;

            private System.Threading.SendOrPostCallback onGetItemInfoCompletedDelegate;

            private BeginOperationDelegate onBeginGetThumbnailsDelegate;

            private EndOperationDelegate onEndGetThumbnailsDelegate;

            private System.Threading.SendOrPostCallback onGetThumbnailsCompletedDelegate;

            private BeginOperationDelegate onBeginGetOrdersDelegate;

            private EndOperationDelegate onEndGetOrdersDelegate;

            private System.Threading.SendOrPostCallback onGetOrdersCompletedDelegate;

            private BeginOperationDelegate onBeginSendOrdersDelegate;

            private EndOperationDelegate onEndSendOrdersDelegate;

            private System.Threading.SendOrPostCallback onSendOrdersCompletedDelegate;

            private BeginOperationDelegate onBeginRemoveSentOrderDelegate;

            private EndOperationDelegate onEndRemoveSentOrderDelegate;

            private System.Threading.SendOrPostCallback onRemoveSentOrderCompletedDelegate;

            private BeginOperationDelegate onBeginSaveUserSettingsDelegate;

            private EndOperationDelegate onEndSaveUserSettingsDelegate;

            private System.Threading.SendOrPostCallback onSaveUserSettingsCompletedDelegate;

            private BeginOperationDelegate onBeginMoveGuestsDelegate;

            private EndOperationDelegate onEndMoveGuestsDelegate;

            private System.Threading.SendOrPostCallback onMoveGuestsCompletedDelegate;

            private BeginOperationDelegate onBeginSplitTableDelegate;

            private EndOperationDelegate onEndSplitTableDelegate;

            private System.Threading.SendOrPostCallback onSplitTableCompletedDelegate;

            private BeginOperationDelegate onBeginHasUnsentOrdersDelegate;

            private EndOperationDelegate onEndHasUnsentOrdersDelegate;

            private System.Threading.SendOrPostCallback onHasUnsentOrdersCompletedDelegate;

            private BeginOperationDelegate onBeginGetManagerSettingsDelegate;

            private EndOperationDelegate onEndGetManagerSettingsDelegate;

            private System.Threading.SendOrPostCallback onGetManagerSettingsCompletedDelegate;

            private BeginOperationDelegate onBeginLogoutDelegate;

            private EndOperationDelegate onEndLogoutDelegate;

            private System.Threading.SendOrPostCallback onLogoutCompletedDelegate;

            private BeginOperationDelegate onBeginPingDelegate;

            private EndOperationDelegate onEndPingDelegate;

            private System.Threading.SendOrPostCallback onPingCompletedDelegate;

            private BeginOperationDelegate onBeginGetRequiredModsDelegate;

            private EndOperationDelegate onEndGetRequiredModsDelegate;

            private System.Threading.SendOrPostCallback onGetRequiredModsCompletedDelegate;

            private BeginOperationDelegate onBeginGetAllModsDelegate;

            private EndOperationDelegate onEndGetAllModsDelegate;

            private System.Threading.SendOrPostCallback onGetAllModsCompletedDelegate;

            private BeginOperationDelegate onBeginGetComboMenuDelegate;

            private EndOperationDelegate onEndGetComboMenuDelegate;

            private System.Threading.SendOrPostCallback onGetComboMenuCompletedDelegate;

            private BeginOperationDelegate onBeginRemoveGuestComboDelegate;

            private EndOperationDelegate onEndRemoveGuestComboDelegate;

            private System.Threading.SendOrPostCallback onRemoveGuestComboCompletedDelegate;

            private BeginOperationDelegate onBeginCombineOrdersDelegate;

            private EndOperationDelegate onEndCombineOrdersDelegate;

            private System.Threading.SendOrPostCallback onCombineOrdersCompletedDelegate;

            private BeginOperationDelegate onBeginClearTableDelegate;

            private EndOperationDelegate onEndClearTableDelegate;

            private System.Threading.SendOrPostCallback onClearTableCompletedDelegate;

            private BeginOperationDelegate onBeginSubmitTakeoutDelegate;

            private EndOperationDelegate onEndSubmitTakeoutDelegate;

            private System.Threading.SendOrPostCallback onSubmitTakeoutCompletedDelegate;

            private BeginOperationDelegate onBeginGetTakeoutOrdersDelegate;

            private EndOperationDelegate onEndGetTakeoutOrdersDelegate;

            private System.Threading.SendOrPostCallback onGetTakeoutOrdersCompletedDelegate;

            private BeginOperationDelegate onBeginGetTakeoutOrderDelegate;

            private EndOperationDelegate onEndGetTakeoutOrderDelegate;

            private System.Threading.SendOrPostCallback onGetTakeoutOrderCompletedDelegate;

            private BeginOperationDelegate onBeginSendTakeoutDelegate;

            private EndOperationDelegate onEndSendTakeoutDelegate;

            private System.Threading.SendOrPostCallback onSendTakeoutCompletedDelegate;

            private BeginOperationDelegate onBeginClearTakeoutOrderDelegate;

            private EndOperationDelegate onEndClearTakeoutOrderDelegate;

            private System.Threading.SendOrPostCallback onClearTakeoutOrderCompletedDelegate;

            private BeginOperationDelegate onBeginListUnsentOrdersDelegate;

            private EndOperationDelegate onEndListUnsentOrdersDelegate;

            private System.Threading.SendOrPostCallback onListUnsentOrdersCompletedDelegate;

            private BeginOperationDelegate onBeginPrintMoveNoticeDelegate;

            private EndOperationDelegate onEndPrintMoveNoticeDelegate;

            private System.Threading.SendOrPostCallback onPrintMoveNoticeCompletedDelegate;

            private BeginOperationDelegate onBeginGetModsForAllItemsDelegate;

            private EndOperationDelegate onEndGetModsForAllItemsDelegate;

            private System.Threading.SendOrPostCallback onGetModsForAllItemsCompletedDelegate;

            private BeginOperationDelegate onBeginGetSpecialItemsDelegate;

            private EndOperationDelegate onEndGetSpecialItemsDelegate;

            private System.Threading.SendOrPostCallback onGetSpecialItemsCompletedDelegate;

            private BeginOperationDelegate onBeginGetTablesForSectionDelegate;

            private EndOperationDelegate onEndGetTablesForSectionDelegate;

            private System.Threading.SendOrPostCallback onGetTablesForSectionCompletedDelegate;

            private BeginOperationDelegate onBeginChangeItemSizeDelegate;

            private EndOperationDelegate onEndChangeItemSizeDelegate;

            private System.Threading.SendOrPostCallback onChangeItemSizeCompletedDelegate;

            private BeginOperationDelegate onBeginGetUserDelegate;

            private EndOperationDelegate onEndGetUserDelegate;

            private System.Threading.SendOrPostCallback onGetUserCompletedDelegate;

            private BeginOperationDelegate onBeginCancelTakeoutDelegate;

            private EndOperationDelegate onEndCancelTakeoutDelegate;

            private System.Threading.SendOrPostCallback onCancelTakeoutCompletedDelegate;

            private BeginOperationDelegate onBeginGetLSEOrdersDelegate;

            private EndOperationDelegate onEndGetLSEOrdersDelegate;

            private System.Threading.SendOrPostCallback onGetLSEOrdersCompletedDelegate;

            private BeginOperationDelegate onBeginSubmitLSETakeoutDelegate;

            private EndOperationDelegate onEndSubmitLSETakeoutDelegate;

            private System.Threading.SendOrPostCallback onSubmitLSETakeoutCompletedDelegate;

            private BeginOperationDelegate onBeginPriceOrderDelegate;

            private EndOperationDelegate onEndPriceOrderDelegate;

            private System.Threading.SendOrPostCallback onPriceOrderCompletedDelegate;

            private BeginOperationDelegate onBeginPrintKitchenNoteDelegate;

            private EndOperationDelegate onEndPrintKitchenNoteDelegate;

            private System.Threading.SendOrPostCallback onPrintKitchenNoteCompletedDelegate;

            private BeginOperationDelegate onBeginRemoveOrderFromPlateDelegate;

            private EndOperationDelegate onEndRemoveOrderFromPlateDelegate;

            private System.Threading.SendOrPostCallback onRemoveOrderFromPlateCompletedDelegate;

            private BeginOperationDelegate onBeginAddOrderToPlateDelegate;

            private EndOperationDelegate onEndAddOrderToPlateDelegate;

            private System.Threading.SendOrPostCallback onAddOrderToPlateCompletedDelegate;

            private BeginOperationDelegate onBeginAddOrdersToPlateDelegate;

            private EndOperationDelegate onEndAddOrdersToPlateDelegate;

            private System.Threading.SendOrPostCallback onAddOrdersToPlateCompletedDelegate;

            private BeginOperationDelegate onBeginRemoveMultipleFromPlateDelegate;

            private EndOperationDelegate onEndRemoveMultipleFromPlateDelegate;

            private System.Threading.SendOrPostCallback onRemoveMultipleFromPlateCompletedDelegate;

            private BeginOperationDelegate onBeginSubmitCateringDelegate;

            private EndOperationDelegate onEndSubmitCateringDelegate;

            private System.Threading.SendOrPostCallback onSubmitCateringCompletedDelegate;

            private BeginOperationDelegate onBeginGetCateringTakeoutsDelegate;

            private EndOperationDelegate onEndGetCateringTakeoutsDelegate;

            private System.Threading.SendOrPostCallback onGetCateringTakeoutsCompletedDelegate;

            private BeginOperationDelegate onBeginGetCateringOrderDelegate;

            private EndOperationDelegate onEndGetCateringOrderDelegate;

            private System.Threading.SendOrPostCallback onGetCateringOrderCompletedDelegate;

            private BeginOperationDelegate onBeginGetAllCateringOrdersInfoDelegate;

            private EndOperationDelegate onEndGetAllCateringOrdersInfoDelegate;

            private System.Threading.SendOrPostCallback onGetAllCateringOrdersInfoCompletedDelegate;

            private BeginOperationDelegate onBeginSendCateringTakeoutDelegate;

            private EndOperationDelegate onEndSendCateringTakeoutDelegate;

            private System.Threading.SendOrPostCallback onSendCateringTakeoutCompletedDelegate;

            private BeginOperationDelegate onBeginGetTableSummaryDelegate;

            private EndOperationDelegate onEndGetTableSummaryDelegate;

            private System.Threading.SendOrPostCallback onGetTableSummaryCompletedDelegate;

            private BeginOperationDelegate onBeginPrintCateringOrderDelegate;

            private EndOperationDelegate onEndPrintCateringOrderDelegate;

            private System.Threading.SendOrPostCallback onPrintCateringOrderCompletedDelegate;

            #endregion

            #region Event Handlers

            public event System.EventHandler<GetTableCompletedEventArgs> GetTableCompleted;

            public event System.EventHandler<ValidateUserCompletedEventArgs> ValidateUserCompleted;

            public event System.EventHandler<GetTableInfoCompletedEventArgs> GetTableInfoCompleted;

            public event System.EventHandler<FillTablesCompletedEventArgs> FillTablesCompleted;

            public event System.EventHandler<GetMenuCompletedEventArgs> GetMenuCompleted;

            public event System.EventHandler<GetModifiersCompletedEventArgs> GetModifiersCompleted;

            public event System.EventHandler<GetAvailablePaymentOptionsCompletedEventArgs> GetAvailablePaymentOptionsCompleted;

            public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> UpdateTablesCompleted;

            public event System.EventHandler<GetGratuityLimitCompletedEventArgs> GetGratuityLimitCompleted;

            public event System.EventHandler<GetTaxRateCompletedEventArgs> GetTaxRateCompleted;

            public event System.EventHandler<GetGratuityRateCompletedEventArgs> GetGratuityRateCompleted;

            public event System.EventHandler<DoAutoGratuityCompletedEventArgs> DoAutoGratuityCompleted;

            public event System.EventHandler<GetCategoryNamesCompletedEventArgs> GetCategoryNamesCompleted;

            public event System.EventHandler<GetNextGuestIDsCompletedEventArgs> GetNextGuestIDsCompleted;

            public event System.EventHandler<RemoveGuestCompletedEventArgs> RemoveGuestCompleted;

            public event System.EventHandler<RemoveItemCompletedEventArgs> RemoveItemCompleted;

            public event System.EventHandler<GetItemInfoCompletedEventArgs> GetItemInfoCompleted;

            public event System.EventHandler<GetThumbnailsCompletedEventArgs> GetThumbnailsCompleted;

            public event System.EventHandler<GetOrdersCompletedEventArgs> GetOrdersCompleted;

            public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> SendOrdersCompleted;

            public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> RemoveSentOrderCompleted;

            public event System.EventHandler<SaveUserSettingsCompletedEventArgs> SaveUserSettingsCompleted;

            public event System.EventHandler<MoveGuestsCompletedEventArgs> MoveGuestsCompleted;

            public event System.EventHandler<SplitTableCompletedEventArgs> SplitTableCompleted;

            public event System.EventHandler<HasUnsentOrdersCompletedEventArgs> HasUnsentOrdersCompleted;

            public event System.EventHandler<GetManagerSettingsCompletedEventArgs> GetManagerSettingsCompleted;

            public event System.EventHandler<LogoutCompletedEventArgs> LogoutCompleted;

            //public event System.EventHandler<PingCompletedEventArgs> PingCompleted;

            public event System.EventHandler<GetRequiredModsCompletedEventArgs> GetRequiredModsCompleted;

            public event System.EventHandler<GetAllModsCompletedEventArgs> GetAllModsCompleted;

            public event System.EventHandler<GetComboMenuCompletedEventArgs> GetComboMenuCompleted;

            public event System.EventHandler<RemoveGuestComboCompletedEventArgs> RemoveGuestComboCompleted;

            public event System.EventHandler<CombineOrdersCompletedEventArgs> CombineOrdersCompleted;

            public event System.EventHandler<ClearTableCompletedEventArgs> ClearTableCompleted;

            public event System.EventHandler<SubmitTakeoutCompletedEventArgs> SubmitTakeoutCompleted;

            public event System.EventHandler<GetTakeoutOrdersCompletedEventArgs> GetTakeoutOrdersCompleted;

            public event System.EventHandler<GetTakeoutOrderCompletedEventArgs> GetTakeoutOrderCompleted;

            public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> SendTakeoutCompleted;

            public event System.EventHandler<ClearTakeoutOrderCompletedEventArgs> ClearTakeoutOrderCompleted;

            public event System.EventHandler<ListUnsentOrdersCompletedEventArgs> ListUnsentOrdersCompleted;

            public event System.EventHandler<PrintMoveNoticeCompletedEventArgs> PrintMoveNoticeCompleted;

            public event System.EventHandler<GetModsForAllItemsCompletedEventArgs> GetModsForAllItemsCompleted;

            public event System.EventHandler<GetSpecialItemsCompletedEventArgs> GetSpecialItemsCompleted;

            public event System.EventHandler<GetTablesForSectionCompletedEventArgs> GetTablesForSectionCompleted;

            public event System.EventHandler<ChangeItemSizeCompletedEventArgs> ChangeItemSizeCompleted;

            public event System.EventHandler<GetUserCompletedEventArgs> GetUserCompleted;

            public event System.EventHandler<CancelTakeoutCompletedEventArgs> CancelTakeoutCompleted;

            public event System.EventHandler<GetLSEOrdersCompletedEventArgs> GetLSEOrdersCompleted;

            public event System.EventHandler<SubmitLSETakeoutCompletedEventArgs> SubmitLSETakeoutCompleted;

            //public event System.EventHandler<PriceOrderCompletedEventArgs> PriceOrderCompleted;

            public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> PrintKitchenNoteCompleted;

            public event System.EventHandler<RemoveOrderFromPlateCompletedEventArgs> RemoveOrderFromPlateCompleted;

            public event System.EventHandler<AddOrderToPlateCompletedEventArgs> AddOrderToPlateCompleted;

            public event System.EventHandler<AddOrdersToPlateCompletedEventArgs> AddOrdersToPlateCompleted;

            public event System.EventHandler<RemoveMultipleFromPlateCompletedEventArgs> RemoveMultipleFromPlateCompleted;

            public event System.EventHandler<SubmitCateringCompletedEventArgs> SubmitCateringCompleted;

            public event System.EventHandler<GetCateringTakeoutsCompletedEventArgs> GetCateringTakeoutsCompleted;

            public event System.EventHandler<GetCateringOrderCompletedEventArgs> GetCateringOrderCompleted;

            public event System.EventHandler<GetAllCateringOrdersInfoCompletedEventArgs> GetAllCateringOrdersInfoCompleted;

            public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> SendCateringTakeoutCompleted;

            //public event System.EventHandler<GetTableSummaryCompletedEventArgs> GetTableSummaryCompleted;

            public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> PrintCateringOrderCompleted;

            #endregion


            //***********************************METHODS***********************************************************************************
            #region Methods Implemented

            public DBTable GetTable(int tableNum)
            {
                return Channel.GetTable(tableNum);
            }

            public List<DBTable> GetTablesForSection(decimal sectionID)
            {
                return Channel.GetTablesForSection(sectionID);
            }

            public System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<Staunch.POS.Classes.DBItem>> GetMenu()
            {
                return Channel.GetMenu();
            }

            public System.Collections.Generic.List<Staunch.POS.Classes.DBModGroup> GetAllMods(decimal ItemID, decimal SizeID)
            {
                return Channel.GetAllMods(ItemID, SizeID);
            }

            #endregion
            #region Methods To Implement

            public IAsyncResult BeginGetTable(int tableNum, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public DBTable EndGetTable(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public DBUser ValidateUser(decimal AuthenticationID, string UserName, string Pin)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginValidateUser(decimal AuthenticationID, string UserName, string Pin, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public DBUser EndValidateUser(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public List<DBTable> GetTableInfo()
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetTableInfo(AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public List<DBTable> EndGetTableInfo(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public List<DBTable> FillTables(decimal userID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginFillTables(decimal userID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public List<DBTable> EndFillTables(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetMenu(AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public Dictionary<string, List<DBItem>> EndGetMenu(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public List<DBModGroup> GetModifiers()
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetModifiers(AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public List<DBModGroup> EndGetModifiers(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public List<string> GetAvailablePaymentOptions()
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetAvailablePaymentOptions(AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public List<string> EndGetAvailablePaymentOptions(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public void UpdateTables(List<DBTable> updatedTables, decimal userID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginUpdateTables(List<DBTable> updatedTables, decimal userID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public void EndUpdateTables(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public int GetGratuityLimit()
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetGratuityLimit(AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public int EndGetGratuityLimit(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public decimal GetTaxRate()
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetTaxRate(AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public decimal EndGetTaxRate(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public decimal GetGratuityRate()
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetGratuityRate(AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public decimal EndGetGratuityRate(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool DoAutoGratuity()
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginDoAutoGratuity(AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public bool EndDoAutoGratuity(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public List<string> GetCategoryNames()
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetCategoryNames(AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public List<string> EndGetCategoryNames(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public List<decimal> GetNextGuestIDs(int num, decimal userID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetNextGuestIDs(int num, decimal userID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public List<decimal> EndGetNextGuestIDs(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool RemoveGuest(decimal GuestID, bool RemoveOrder)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginRemoveGuest(decimal GuestID, bool RemoveOrder, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public bool EndRemoveGuest(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool RemoveItem(decimal GuestID, decimal OrderID, decimal UserID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginRemoveItem(decimal GuestID, decimal OrderID, decimal UserID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public bool EndRemoveItem(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public ItemInfo GetItemInfo(decimal ItemID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetItemInfo(decimal ItemID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public ItemInfo EndGetItemInfo(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public Dictionary<decimal, PictureFile> GetThumbnails(List<decimal> ItemIDs)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetThumbnails(List<decimal> ItemIDs, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public Dictionary<decimal, PictureFile> EndGetThumbnails(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public List<GuestItem> GetOrders(decimal TableID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetOrders(decimal TableID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public List<GuestItem> EndGetOrders(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public void SendOrders(List<decimal> OrderIDs, decimal UserID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginSendOrders(List<decimal> OrderIDs, decimal UserID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public void EndSendOrders(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public void RemoveSentOrder(List<decimal> OrderIDs, decimal UserID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginRemoveSentOrder(List<decimal> OrderIDs, decimal UserID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public void EndRemoveSentOrder(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool SaveUserSettings(DBUser user)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginSaveUserSettings(DBUser user, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public bool EndSaveUserSettings(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool MoveGuests(List<decimal> GuestIDs, decimal NewTableID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginMoveGuests(List<decimal> GuestIDs, decimal NewTableID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public bool EndMoveGuests(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool SplitTable(decimal TableID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginSplitTable(decimal TableID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public bool EndSplitTable(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool HasUnsentOrders(decimal TableID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginHasUnsentOrders(decimal TableID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public bool EndHasUnsentOrders(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public ManagerSettings GetManagerSettings()
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetManagerSettings(AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public ManagerSettings EndGetManagerSettings(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool Logout(decimal UserID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginLogout(decimal UserID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public bool EndLogout(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public int Ping(int Delay)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginPing(int Delay, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public int EndPing(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public List<DBModGroup> GetRequiredMods(decimal ItemID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetRequiredMods(decimal ItemID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public List<DBModGroup> EndGetRequiredMods(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetAllMods(decimal ItemID, decimal SizeID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public List<DBModGroup> EndGetAllMods(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public List<ComboItem> GetComboMenu()
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetComboMenu(AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public List<ComboItem> EndGetComboMenu(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool RemoveGuestCombo(decimal GuestID, decimal OrderComboID, decimal UserID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginRemoveGuestCombo(decimal GuestID, decimal OrderComboID, decimal UserID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public bool EndRemoveGuestCombo(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool CombineOrders(decimal DestinationGuestID, List<decimal> GuestsToMoveIDs, bool RemoveAfterCombine)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginCombineOrders(decimal DestinationGuestID, List<decimal> GuestsToMoveIDs, bool RemoveAfterCombine, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public bool EndCombineOrders(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool ClearTable(decimal TableID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginClearTable(decimal TableID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public bool EndClearTable(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public TakeoutOrder SubmitTakeout(TakeoutOrder TakeoutGuest, decimal UserID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginSubmitTakeout(TakeoutOrder TakeoutGuest, decimal UserID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public TakeoutOrder EndSubmitTakeout(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public List<TakeoutOrder> GetTakeoutOrders()
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetTakeoutOrders(AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public List<TakeoutOrder> EndGetTakeoutOrders(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public TakeoutOrder GetTakeoutOrder(decimal GuestID, decimal CheckID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetTakeoutOrder(decimal GuestID, decimal CheckID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public TakeoutOrder EndGetTakeoutOrder(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public void SendTakeout(TakeoutOrder TakeoutGuest, decimal UserID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginSendTakeout(TakeoutOrder TakeoutGuest, decimal UserID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public void EndSendTakeout(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool ClearTakeoutOrder(decimal TakeoutID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginClearTakeoutOrder(decimal TakeoutID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public bool EndClearTakeoutOrder(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public List<decimal> ListUnsentOrders(List<decimal> TableIDList)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginListUnsentOrders(List<decimal> TableIDList, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public List<decimal> EndListUnsentOrders(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool PrintMoveNotice(List<decimal> orderIDs, decimal fromTableID, decimal toTableID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginPrintMoveNotice(List<decimal> orderIDs, decimal fromTableID, decimal toTableID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public bool EndPrintMoveNotice(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public Dictionary<decimal, Dictionary<decimal, List<DBModGroup>>> GetModsForAllItems()
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetModsForAllItems(AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public Dictionary<decimal, Dictionary<decimal, List<DBModGroup>>> EndGetModsForAllItems(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public List<DBItem> GetSpecialItems()
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetSpecialItems(AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public List<DBItem> EndGetSpecialItems(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetTablesForSection(decimal sectionID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public List<DBTable> EndGetTablesForSection(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool ChangeItemSize(decimal orderID, decimal newSizeID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginChangeItemSize(decimal orderID, decimal newSizeID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public bool EndChangeItemSize(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public DBUser GetUser(string pin)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetUser(string pin, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public DBUser EndGetUser(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool CancelTakeout(decimal TakeoutGuestID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginCancelTakeout(decimal TakeoutGuestID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public bool EndCancelTakeout(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public List<TakeoutOrder> GetLSEOrders()
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetLSEOrders(AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public List<TakeoutOrder> EndGetLSEOrders(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public TakeoutOrder SubmitLSETakeout(TakeoutOrder TakeoutGuest, decimal UserID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginSubmitLSETakeout(TakeoutOrder TakeoutGuest, decimal UserID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public TakeoutOrder EndSubmitLSETakeout(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public Guest_DB PriceOrder(Guest_DB guest)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginPriceOrder(Guest_DB guest, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public Guest_DB EndPriceOrder(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public void PrintKitchenNote(string note)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginPrintKitchenNote(string note, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public void EndPrintKitchenNote(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool RemoveOrderFromPlate(decimal OrderID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginRemoveOrderFromPlate(decimal OrderID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public bool EndRemoveOrderFromPlate(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool AddOrderToPlate(decimal OrderID, decimal PlateID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginAddOrderToPlate(decimal OrderID, decimal PlateID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public bool EndAddOrderToPlate(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool AddOrdersToPlate(List<decimal> orderIds, decimal plateId)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginAddOrdersToPlate(List<decimal> orderIds, decimal plateId, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public bool EndAddOrdersToPlate(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool RemoveMultipleFromPlate(List<decimal> orderIDs)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginRemoveMultipleFromPlate(List<decimal> orderIDs, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public bool EndRemoveMultipleFromPlate(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public CateringOrder SubmitCatering(CateringOrder catering, decimal UserID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginSubmitCatering(CateringOrder catering, decimal UserID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public CateringOrder EndSubmitCatering(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public List<TakeoutOrder> GetCateringTakeouts()
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetCateringTakeouts(AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public List<TakeoutOrder> EndGetCateringTakeouts(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public CateringOrder GetCateringOrder(decimal TakeoutID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetCateringOrder(decimal TakeoutID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public CateringOrder EndGetCateringOrder(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public List<CateringOrder> GetAllCateringOrdersInfo()
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetAllCateringOrdersInfo(AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public List<CateringOrder> EndGetAllCateringOrdersInfo(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public void SendCateringTakeout(TakeoutOrder TakeoutGuest, decimal UserID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginSendCateringTakeout(TakeoutOrder TakeoutGuest, decimal UserID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public void EndSendCateringTakeout(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public List<DBTable> GetTableSummary()
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetTableSummary(AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public List<DBTable> EndGetTableSummary(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public void PrintCateringOrder(CateringOrder catering, decimal UserID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginPrintCateringOrder(CateringOrder catering, decimal UserID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public void EndPrintCateringOrder(IAsyncResult result)
            {
                throw new NotImplementedException();
            }
#endregion

            //*********************************METHODS***********************************************************************************
            //      ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

            private class PosServiceChannel : ChannelBase<IPosService>, IPosService
            {

                public PosServiceChannel(System.ServiceModel.ClientBase<IPosService> client) : base(client)
                {

                }

               

                #region PosServiceChannel Methods

                public DBTable GetTable(int tableNum)
                {
                    object[] _args = new object[1];
                    _args[0] = tableNum;
                    return (DBTable)base.Invoke("GetTable", _args);
                }

                public System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<Staunch.POS.Classes.DBItem>> GetMenu()
                {
                  
                    return (System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<Staunch.POS.Classes.DBItem>>)base.Invoke("GetMenu", null);
                }

                public List<DBTable> GetTablesForSection(decimal sectionID)
                {
                    object[] args = new object[1];
                    args[0] = sectionID;
                    return (List<DBTable>)base.Invoke("GetTablesForSection", args);
                }

                public System.Collections.Generic.List<Staunch.POS.Classes.DBModGroup> GetAllMods(decimal itemId, decimal sizeId)
                {
                    object[] args = new object[2];
                    args[0] = itemId;
                    args[1] = sizeId;
                    return (List<DBModGroup>)base.Invoke("GetAllMods", args);
                }

                public IAsyncResult BeginGetTable(int tableNum, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public DBTable EndGetTable(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public DBUser ValidateUser(decimal AuthenticationID, string UserName, string Pin)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginValidateUser(decimal AuthenticationID, string UserName, string Pin, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public DBUser EndValidateUser(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public List<DBTable> GetTableInfo()
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginGetTableInfo(AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public List<DBTable> EndGetTableInfo(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public List<DBTable> FillTables(decimal userID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginFillTables(decimal userID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public List<DBTable> EndFillTables(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginGetMenu(AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public Dictionary<string, List<DBItem>> EndGetMenu(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public List<DBModGroup> GetModifiers()
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginGetModifiers(AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public List<DBModGroup> EndGetModifiers(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public List<string> GetAvailablePaymentOptions()
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginGetAvailablePaymentOptions(AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public List<string> EndGetAvailablePaymentOptions(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public void UpdateTables(List<DBTable> updatedTables, decimal userID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginUpdateTables(List<DBTable> updatedTables, decimal userID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public void EndUpdateTables(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public int GetGratuityLimit()
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginGetGratuityLimit(AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public int EndGetGratuityLimit(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public decimal GetTaxRate()
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginGetTaxRate(AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public decimal EndGetTaxRate(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public decimal GetGratuityRate()
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginGetGratuityRate(AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public decimal EndGetGratuityRate(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public bool DoAutoGratuity()
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginDoAutoGratuity(AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public bool EndDoAutoGratuity(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public List<string> GetCategoryNames()
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginGetCategoryNames(AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public List<string> EndGetCategoryNames(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public List<decimal> GetNextGuestIDs(int num, decimal userID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginGetNextGuestIDs(int num, decimal userID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public List<decimal> EndGetNextGuestIDs(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public bool RemoveGuest(decimal GuestID, bool RemoveOrder)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginRemoveGuest(decimal GuestID, bool RemoveOrder, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public bool EndRemoveGuest(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public bool RemoveItem(decimal GuestID, decimal OrderID, decimal UserID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginRemoveItem(decimal GuestID, decimal OrderID, decimal UserID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public bool EndRemoveItem(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public ItemInfo GetItemInfo(decimal ItemID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginGetItemInfo(decimal ItemID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public ItemInfo EndGetItemInfo(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public Dictionary<decimal, PictureFile> GetThumbnails(List<decimal> ItemIDs)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginGetThumbnails(List<decimal> ItemIDs, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public Dictionary<decimal, PictureFile> EndGetThumbnails(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public List<GuestItem> GetOrders(decimal TableID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginGetOrders(decimal TableID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public List<GuestItem> EndGetOrders(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public void SendOrders(List<decimal> OrderIDs, decimal UserID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginSendOrders(List<decimal> OrderIDs, decimal UserID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public void EndSendOrders(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public void RemoveSentOrder(List<decimal> OrderIDs, decimal UserID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginRemoveSentOrder(List<decimal> OrderIDs, decimal UserID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public void EndRemoveSentOrder(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public bool SaveUserSettings(DBUser user)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginSaveUserSettings(DBUser user, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public bool EndSaveUserSettings(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public bool MoveGuests(List<decimal> GuestIDs, decimal NewTableID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginMoveGuests(List<decimal> GuestIDs, decimal NewTableID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public bool EndMoveGuests(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public bool SplitTable(decimal TableID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginSplitTable(decimal TableID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public bool EndSplitTable(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public bool HasUnsentOrders(decimal TableID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginHasUnsentOrders(decimal TableID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public bool EndHasUnsentOrders(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public ManagerSettings GetManagerSettings()
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginGetManagerSettings(AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public ManagerSettings EndGetManagerSettings(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public bool Logout(decimal UserID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginLogout(decimal UserID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public bool EndLogout(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public int Ping(int Delay)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginPing(int Delay, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public int EndPing(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public List<DBModGroup> GetRequiredMods(decimal ItemID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginGetRequiredMods(decimal ItemID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public List<DBModGroup> EndGetRequiredMods(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginGetAllMods(decimal ItemID, decimal SizeID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public List<DBModGroup> EndGetAllMods(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public List<ComboItem> GetComboMenu()
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginGetComboMenu(AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public List<ComboItem> EndGetComboMenu(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public bool RemoveGuestCombo(decimal GuestID, decimal OrderComboID, decimal UserID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginRemoveGuestCombo(decimal GuestID, decimal OrderComboID, decimal UserID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public bool EndRemoveGuestCombo(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public bool CombineOrders(decimal DestinationGuestID, List<decimal> GuestsToMoveIDs, bool RemoveAfterCombine)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginCombineOrders(decimal DestinationGuestID, List<decimal> GuestsToMoveIDs, bool RemoveAfterCombine, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public bool EndCombineOrders(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public bool ClearTable(decimal TableID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginClearTable(decimal TableID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public bool EndClearTable(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public TakeoutOrder SubmitTakeout(TakeoutOrder TakeoutGuest, decimal UserID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginSubmitTakeout(TakeoutOrder TakeoutGuest, decimal UserID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public TakeoutOrder EndSubmitTakeout(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public List<TakeoutOrder> GetTakeoutOrders()
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginGetTakeoutOrders(AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public List<TakeoutOrder> EndGetTakeoutOrders(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public TakeoutOrder GetTakeoutOrder(decimal GuestID, decimal CheckID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginGetTakeoutOrder(decimal GuestID, decimal CheckID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public TakeoutOrder EndGetTakeoutOrder(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public void SendTakeout(TakeoutOrder TakeoutGuest, decimal UserID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginSendTakeout(TakeoutOrder TakeoutGuest, decimal UserID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public void EndSendTakeout(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public bool ClearTakeoutOrder(decimal TakeoutID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginClearTakeoutOrder(decimal TakeoutID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public bool EndClearTakeoutOrder(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public List<decimal> ListUnsentOrders(List<decimal> TableIDList)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginListUnsentOrders(List<decimal> TableIDList, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public List<decimal> EndListUnsentOrders(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public bool PrintMoveNotice(List<decimal> orderIDs, decimal fromTableID, decimal toTableID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginPrintMoveNotice(List<decimal> orderIDs, decimal fromTableID, decimal toTableID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public bool EndPrintMoveNotice(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public Dictionary<decimal, Dictionary<decimal, List<DBModGroup>>> GetModsForAllItems()
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginGetModsForAllItems(AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public Dictionary<decimal, Dictionary<decimal, List<DBModGroup>>> EndGetModsForAllItems(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public List<DBItem> GetSpecialItems()
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginGetSpecialItems(AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public List<DBItem> EndGetSpecialItems(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginGetTablesForSection(decimal sectionID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public List<DBTable> EndGetTablesForSection(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public bool ChangeItemSize(decimal orderID, decimal newSizeID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginChangeItemSize(decimal orderID, decimal newSizeID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public bool EndChangeItemSize(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public DBUser GetUser(string pin)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginGetUser(string pin, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public DBUser EndGetUser(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public bool CancelTakeout(decimal TakeoutGuestID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginCancelTakeout(decimal TakeoutGuestID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public bool EndCancelTakeout(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public List<TakeoutOrder> GetLSEOrders()
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginGetLSEOrders(AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public List<TakeoutOrder> EndGetLSEOrders(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public TakeoutOrder SubmitLSETakeout(TakeoutOrder TakeoutGuest, decimal UserID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginSubmitLSETakeout(TakeoutOrder TakeoutGuest, decimal UserID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public TakeoutOrder EndSubmitLSETakeout(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public Guest_DB PriceOrder(Guest_DB guest)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginPriceOrder(Guest_DB guest, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public Guest_DB EndPriceOrder(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public void PrintKitchenNote(string note)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginPrintKitchenNote(string note, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public void EndPrintKitchenNote(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public bool RemoveOrderFromPlate(decimal OrderID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginRemoveOrderFromPlate(decimal OrderID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public bool EndRemoveOrderFromPlate(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public bool AddOrderToPlate(decimal OrderID, decimal PlateID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginAddOrderToPlate(decimal OrderID, decimal PlateID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public bool EndAddOrderToPlate(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public bool AddOrdersToPlate(List<decimal> orderIds, decimal plateId)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginAddOrdersToPlate(List<decimal> orderIds, decimal plateId, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public bool EndAddOrdersToPlate(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public bool RemoveMultipleFromPlate(List<decimal> orderIDs)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginRemoveMultipleFromPlate(List<decimal> orderIDs, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public bool EndRemoveMultipleFromPlate(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public CateringOrder SubmitCatering(CateringOrder catering, decimal UserID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginSubmitCatering(CateringOrder catering, decimal UserID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public CateringOrder EndSubmitCatering(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public List<TakeoutOrder> GetCateringTakeouts()
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginGetCateringTakeouts(AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public List<TakeoutOrder> EndGetCateringTakeouts(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public CateringOrder GetCateringOrder(decimal TakeoutID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginGetCateringOrder(decimal TakeoutID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public CateringOrder EndGetCateringOrder(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public List<CateringOrder> GetAllCateringOrdersInfo()
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginGetAllCateringOrdersInfo(AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public List<CateringOrder> EndGetAllCateringOrdersInfo(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public void SendCateringTakeout(TakeoutOrder TakeoutGuest, decimal UserID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginSendCateringTakeout(TakeoutOrder TakeoutGuest, decimal UserID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public void EndSendCateringTakeout(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public List<DBTable> GetTableSummary()
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginGetTableSummary(AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public List<DBTable> EndGetTableSummary(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }

                public void PrintCateringOrder(CateringOrder catering, decimal UserID)
                {
                    throw new NotImplementedException();
                }

                public IAsyncResult BeginPrintCateringOrder(CateringOrder catering, decimal UserID, AsyncCallback callback, object asyncState)
                {
                    throw new NotImplementedException();
                }

                public void EndPrintCateringOrder(IAsyncResult result)
                {
                    throw new NotImplementedException();
                }
            }  //PosServiceChannel

            #endregion

            #region Methods used for Zipline2 (including Android)
            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginGetTable(int tableNum, System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginGetTable(tableNum, callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public Staunch.POS.Classes.DBTable EndGetTable(System.IAsyncResult result)
            //{
            //    return base.Channel.EndGetTable(result);
            //}

            //private System.IAsyncResult OnBeginGetTable(object[] inValues, System.AsyncCallback callback, object asyncState)
            //{
            //    int tableNum = ((int)(inValues[0]));
            //    return this.BeginGetTable(tableNum, callback, asyncState);
            //}

            //private object[] OnEndGetTable(System.IAsyncResult result)
            //{
            //    Staunch.POS.Classes.DBTable retVal = this.EndGetTable(result);
            //    return new object[] {
            //retVal};
            //}

            //private void OnGetTableCompleted(object state)
            //{
            //    if ((this.GetTableCompleted != null))
            //    {
            //        InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //        this.GetTableCompleted(this, new GetTableCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //    }
            //}

            //public void GetTableAsync(int tableNum)
            //{
            //    this.GetTableAsync(tableNum, null);
            //}

            //public void GetTableAsync(int tableNum, object userState)
            //{
            //    if ((this.onBeginGetTableDelegate == null))
            //    {
            //        this.onBeginGetTableDelegate = new BeginOperationDelegate(this.OnBeginGetTable);
            //    }
            //    if ((this.onEndGetTableDelegate == null))
            //    {
            //        this.onEndGetTableDelegate = new EndOperationDelegate(this.OnEndGetTable);
            //    }
            //    if ((this.onGetTableCompletedDelegate == null))
            //    {
            //        this.onGetTableCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetTableCompleted);
            //    }
            //    base.InvokeAsync(this.onBeginGetTableDelegate, new object[] {
            //    tableNum}, this.onEndGetTableDelegate, this.onGetTableCompletedDelegate, userState);
            //}

            //public Staunch.POS.Classes.DBUser ValidateUser(decimal AuthenticationID, string UserName, string Pin)
            //{
            //    return base.Channel.ValidateUser(AuthenticationID, UserName, Pin);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginValidateUser(decimal AuthenticationID, string UserName, string Pin, System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginValidateUser(AuthenticationID, UserName, Pin, callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public Staunch.POS.Classes.DBUser EndValidateUser(System.IAsyncResult result)
            //{
            //    return base.Channel.EndValidateUser(result);
            //}

            //private System.IAsyncResult OnBeginValidateUser(object[] inValues, System.AsyncCallback callback, object asyncState)
            //{
            //    decimal AuthenticationID = ((decimal)(inValues[0]));
            //    string UserName = ((string)(inValues[1]));
            //    string Pin = ((string)(inValues[2]));
            //    return this.BeginValidateUser(AuthenticationID, UserName, Pin, callback, asyncState);
            //}

            //private object[] OnEndValidateUser(System.IAsyncResult result)
            //{
            //    Staunch.POS.Classes.DBUser retVal = this.EndValidateUser(result);
            //    return new object[] {
            //retVal};
            //}

            //private void OnValidateUserCompleted(object state)
            //{
            //    if ((this.ValidateUserCompleted != null))
            //    {
            //        InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //        this.ValidateUserCompleted(this, new ValidateUserCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //    }
            //}

            //public void ValidateUserAsync(decimal AuthenticationID, string UserName, string Pin)
            //{
            //    this.ValidateUserAsync(AuthenticationID, UserName, Pin, null);
            //}

            //public void ValidateUserAsync(decimal AuthenticationID, string UserName, string Pin, object userState)
            //{
            //    if ((this.onBeginValidateUserDelegate == null))
            //    {
            //        this.onBeginValidateUserDelegate = new BeginOperationDelegate(this.OnBeginValidateUser);
            //    }
            //    if ((this.onEndValidateUserDelegate == null))
            //    {
            //        this.onEndValidateUserDelegate = new EndOperationDelegate(this.OnEndValidateUser);
            //    }
            //    if ((this.onValidateUserCompletedDelegate == null))
            //    {
            //        this.onValidateUserCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnValidateUserCompleted);
            //    }
            //    base.InvokeAsync(this.onBeginValidateUserDelegate, new object[] {
            //    AuthenticationID,
            //    UserName,
            //    Pin}, this.onEndValidateUserDelegate, this.onValidateUserCompletedDelegate, userState);
            //}

            //public System.Collections.Generic.List<Staunch.POS.Classes.DBTable> GetTableInfo()
            //{
            //    return base.Channel.GetTableInfo();
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginGetTableInfo(System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginGetTableInfo(callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.Collections.Generic.List<Staunch.POS.Classes.DBTable> EndGetTableInfo(System.IAsyncResult result)
            //{
            //    return base.Channel.EndGetTableInfo(result);
            //}

            //private System.IAsyncResult OnBeginGetTableInfo(object[] inValues, System.AsyncCallback callback, object asyncState)
            //{
            //    return this.BeginGetTableInfo(callback, asyncState);
            //}

            //private object[] OnEndGetTableInfo(System.IAsyncResult result)
            //{
            //    System.Collections.Generic.List<Staunch.POS.Classes.DBTable> retVal = this.EndGetTableInfo(result);
            //    return new object[] {
            //retVal};
            //}

            //private void OnGetTableInfoCompleted(object state)
            //{
            //    if ((this.GetTableInfoCompleted != null))
            //    {
            //        InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //        this.GetTableInfoCompleted(this, new GetTableInfoCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //    }
            //}

            //public void GetTableInfoAsync()
            //{
            //    this.GetTableInfoAsync(null);
            //}

            //public void GetTableInfoAsync(object userState)
            //{
            //    if ((this.onBeginGetTableInfoDelegate == null))
            //    {
            //        this.onBeginGetTableInfoDelegate = new BeginOperationDelegate(this.OnBeginGetTableInfo);
            //    }
            //    if ((this.onEndGetTableInfoDelegate == null))
            //    {
            //        this.onEndGetTableInfoDelegate = new EndOperationDelegate(this.OnEndGetTableInfo);
            //    }
            //    if ((this.onGetTableInfoCompletedDelegate == null))
            //    {
            //        this.onGetTableInfoCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetTableInfoCompleted);
            //    }
            //    base.InvokeAsync(this.onBeginGetTableInfoDelegate, null, this.onEndGetTableInfoDelegate, this.onGetTableInfoCompletedDelegate, userState);
            //}

            //public System.Collections.Generic.List<Staunch.POS.Classes.DBTable> FillTables(decimal userID)
            //{
            //    return base.Channel.FillTables(userID);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginFillTables(decimal userID, System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginFillTables(userID, callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.Collections.Generic.List<Staunch.POS.Classes.DBTable> EndFillTables(System.IAsyncResult result)
            //{
            //    return base.Channel.EndFillTables(result);
            //}

            //private System.IAsyncResult OnBeginFillTables(object[] inValues, System.AsyncCallback callback, object asyncState)
            //{
            //    decimal userID = ((decimal)(inValues[0]));
            //    return this.BeginFillTables(userID, callback, asyncState);
            //}

            //private object[] OnEndFillTables(System.IAsyncResult result)
            //{
            //    System.Collections.Generic.List<Staunch.POS.Classes.DBTable> retVal = this.EndFillTables(result);
            //    return new object[] {
            //retVal};
            //}

            //private void OnFillTablesCompleted(object state)
            //{
            //    if ((this.FillTablesCompleted != null))
            //    {
            //        InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //        this.FillTablesCompleted(this, new FillTablesCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //    }
            //}

            //public void FillTablesAsync(decimal userID)
            //{
            //    this.FillTablesAsync(userID, null);
            //}

            //public void FillTablesAsync(decimal userID, object userState)
            //{
            //    if ((this.onBeginFillTablesDelegate == null))
            //    {
            //        this.onBeginFillTablesDelegate = new BeginOperationDelegate(this.OnBeginFillTables);
            //    }
            //    if ((this.onEndFillTablesDelegate == null))
            //    {
            //        this.onEndFillTablesDelegate = new EndOperationDelegate(this.OnEndFillTables);
            //    }
            //    if ((this.onFillTablesCompletedDelegate == null))
            //    {
            //        this.onFillTablesCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnFillTablesCompleted);
            //    }
            //    base.InvokeAsync(this.onBeginFillTablesDelegate, new object[] {
            //    userID}, this.onEndFillTablesDelegate, this.onFillTablesCompletedDelegate, userState);
            //}

            //public System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<Staunch.POS.Classes.DBItem>> GetMenu()
            //{
            //    return base.Channel.GetMenu();
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginGetMenu(System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginGetMenu(callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<Staunch.POS.Classes.DBItem>> EndGetMenu(System.IAsyncResult result)
            //{
            //    return base.Channel.EndGetMenu(result);
            //}

            //private System.IAsyncResult OnBeginGetMenu(object[] inValues, System.AsyncCallback callback, object asyncState)
            //{
            //    return this.BeginGetMenu(callback, asyncState);
            //}

            //private object[] OnEndGetMenu(System.IAsyncResult result)
            //{
            //    System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<Staunch.POS.Classes.DBItem>> retVal = this.EndGetMenu(result);
            //    return new object[] {
            //retVal};
            //}

            //private void OnGetMenuCompleted(object state)
            //{
            //    if ((this.GetMenuCompleted != null))
            //    {
            //        InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //        this.GetMenuCompleted(this, new GetMenuCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //    }
            //}

            //public void GetMenuAsync()
            //{
            //    this.GetMenuAsync(null);
            //}

            //public void GetMenuAsync(object userState)
            //{
            //    if ((this.onBeginGetMenuDelegate == null))
            //    {
            //        this.onBeginGetMenuDelegate = new BeginOperationDelegate(this.OnBeginGetMenu);
            //    }
            //    if ((this.onEndGetMenuDelegate == null))
            //    {
            //        this.onEndGetMenuDelegate = new EndOperationDelegate(this.OnEndGetMenu);
            //    }
            //    if ((this.onGetMenuCompletedDelegate == null))
            //    {
            //        this.onGetMenuCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetMenuCompleted);
            //    }
            //    base.InvokeAsync(this.onBeginGetMenuDelegate, null, this.onEndGetMenuDelegate, this.onGetMenuCompletedDelegate, userState);
            //}

            //public System.Collections.Generic.List<Staunch.POS.Classes.DBModGroup> GetModifiers()
            //{
            //    return base.Channel.GetModifiers();
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginGetModifiers(System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginGetModifiers(callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.Collections.Generic.List<Staunch.POS.Classes.DBModGroup> EndGetModifiers(System.IAsyncResult result)
            //{
            //    return base.Channel.EndGetModifiers(result);
            //}

            //private System.IAsyncResult OnBeginGetModifiers(object[] inValues, System.AsyncCallback callback, object asyncState)
            //{
            //    return this.BeginGetModifiers(callback, asyncState);
            //}

            //private object[] OnEndGetModifiers(System.IAsyncResult result)
            //{
            //    System.Collections.Generic.List<Staunch.POS.Classes.DBModGroup> retVal = this.EndGetModifiers(result);
            //    return new object[] {
            //retVal};
            //}

            //private void OnGetModifiersCompleted(object state)
            //{
            //    if ((this.GetModifiersCompleted != null))
            //    {
            //        InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //        this.GetModifiersCompleted(this, new GetModifiersCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //    }
            //}

            //public void GetModifiersAsync()
            //{
            //    this.GetModifiersAsync(null);
            //}

            //public void GetModifiersAsync(object userState)
            //{
            //    if ((this.onBeginGetModifiersDelegate == null))
            //    {
            //        this.onBeginGetModifiersDelegate = new BeginOperationDelegate(this.OnBeginGetModifiers);
            //    }
            //    if ((this.onEndGetModifiersDelegate == null))
            //    {
            //        this.onEndGetModifiersDelegate = new EndOperationDelegate(this.OnEndGetModifiers);
            //    }
            //    if ((this.onGetModifiersCompletedDelegate == null))
            //    {
            //        this.onGetModifiersCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetModifiersCompleted);
            //    }
            //    base.InvokeAsync(this.onBeginGetModifiersDelegate, null, this.onEndGetModifiersDelegate, this.onGetModifiersCompletedDelegate, userState);
            //}

            //public System.Collections.Generic.List<string> GetAvailablePaymentOptions()
            //{
            //    return base.Channel.GetAvailablePaymentOptions();
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginGetAvailablePaymentOptions(System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginGetAvailablePaymentOptions(callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.Collections.Generic.List<string> EndGetAvailablePaymentOptions(System.IAsyncResult result)
            //{
            //    return base.Channel.EndGetAvailablePaymentOptions(result);
            //}

            //private System.IAsyncResult OnBeginGetAvailablePaymentOptions(object[] inValues, System.AsyncCallback callback, object asyncState)
            //{
            //    return this.BeginGetAvailablePaymentOptions(callback, asyncState);
            //}

            //private object[] OnEndGetAvailablePaymentOptions(System.IAsyncResult result)
            //{
            //    System.Collections.Generic.List<string> retVal = this.EndGetAvailablePaymentOptions(result);
            //    return new object[] {
            //retVal};
            //}

            //private void OnGetAvailablePaymentOptionsCompleted(object state)
            //{
            //    if ((this.GetAvailablePaymentOptionsCompleted != null))
            //    {
            //        InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //        this.GetAvailablePaymentOptionsCompleted(this, new GetAvailablePaymentOptionsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //    }
            //}

            //public void GetAvailablePaymentOptionsAsync()
            //{
            //    this.GetAvailablePaymentOptionsAsync(null);
            //}

            //public void GetAvailablePaymentOptionsAsync(object userState)
            //{
            //    if ((this.onBeginGetAvailablePaymentOptionsDelegate == null))
            //    {
            //        this.onBeginGetAvailablePaymentOptionsDelegate = new BeginOperationDelegate(this.OnBeginGetAvailablePaymentOptions);
            //    }
            //    if ((this.onEndGetAvailablePaymentOptionsDelegate == null))
            //    {
            //        this.onEndGetAvailablePaymentOptionsDelegate = new EndOperationDelegate(this.OnEndGetAvailablePaymentOptions);
            //    }
            //    if ((this.onGetAvailablePaymentOptionsCompletedDelegate == null))
            //    {
            //        this.onGetAvailablePaymentOptionsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetAvailablePaymentOptionsCompleted);
            //    }
            //    base.InvokeAsync(this.onBeginGetAvailablePaymentOptionsDelegate, null, this.onEndGetAvailablePaymentOptionsDelegate, this.onGetAvailablePaymentOptionsCompletedDelegate, userState);
            //}

            //public void UpdateTables(System.Collections.Generic.List<Staunch.POS.Classes.DBTable> updatedTables, decimal userID)
            //{
            //    base.Channel.UpdateTables(updatedTables, userID);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginUpdateTables(System.Collections.Generic.List<Staunch.POS.Classes.DBTable> updatedTables, decimal userID, System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginUpdateTables(updatedTables, userID, callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public void EndUpdateTables(System.IAsyncResult result)
            //{
            //    base.Channel.EndUpdateTables(result);
            //}

            //private System.IAsyncResult OnBeginUpdateTables(object[] inValues, System.AsyncCallback callback, object asyncState)
            //{
            //    System.Collections.Generic.List<Staunch.POS.Classes.DBTable> updatedTables = ((System.Collections.Generic.List<Staunch.POS.Classes.DBTable>)(inValues[0]));
            //    decimal userID = ((decimal)(inValues[1]));
            //    return this.BeginUpdateTables(updatedTables, userID, callback, asyncState);
            //}

            //private object[] OnEndUpdateTables(System.IAsyncResult result)
            //{
            //    this.EndUpdateTables(result);
            //    return null;
            //}

            //private void OnUpdateTablesCompleted(object state)
            //{
            //    if ((this.UpdateTablesCompleted != null))
            //    {
            //        InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //        this.UpdateTablesCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            //    }
            //}

            //public void UpdateTablesAsync(System.Collections.Generic.List<Staunch.POS.Classes.DBTable> updatedTables, decimal userID)
            //{
            //    this.UpdateTablesAsync(updatedTables, userID, null);
            //}

            //public void UpdateTablesAsync(System.Collections.Generic.List<Staunch.POS.Classes.DBTable> updatedTables, decimal userID, object userState)
            //{
            //    if ((this.onBeginUpdateTablesDelegate == null))
            //    {
            //        this.onBeginUpdateTablesDelegate = new BeginOperationDelegate(this.OnBeginUpdateTables);
            //    }
            //    if ((this.onEndUpdateTablesDelegate == null))
            //    {
            //        this.onEndUpdateTablesDelegate = new EndOperationDelegate(this.OnEndUpdateTables);
            //    }
            //    if ((this.onUpdateTablesCompletedDelegate == null))
            //    {
            //        this.onUpdateTablesCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnUpdateTablesCompleted);
            //    }
            //    base.InvokeAsync(this.onBeginUpdateTablesDelegate, new object[] {
            //    updatedTables,
            //    userID}, this.onEndUpdateTablesDelegate, this.onUpdateTablesCompletedDelegate, userState);
            //}

            //public int GetGratuityLimit()
            //{
            //    return base.Channel.GetGratuityLimit();
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginGetGratuityLimit(System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginGetGratuityLimit(callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public int EndGetGratuityLimit(System.IAsyncResult result)
            //{
            //    return base.Channel.EndGetGratuityLimit(result);
            //}

            //private System.IAsyncResult OnBeginGetGratuityLimit(object[] inValues, System.AsyncCallback callback, object asyncState)
            //{
            //    return this.BeginGetGratuityLimit(callback, asyncState);
            //}

            //private object[] OnEndGetGratuityLimit(System.IAsyncResult result)
            //{
            //    int retVal = this.EndGetGratuityLimit(result);
            //    return new object[] {
            //retVal};
            //}

            //private void OnGetGratuityLimitCompleted(object state)
            //{
            //    if ((this.GetGratuityLimitCompleted != null))
            //    {
            //        InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //        this.GetGratuityLimitCompleted(this, new GetGratuityLimitCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //    }
            //}

            //public void GetGratuityLimitAsync()
            //{
            //    this.GetGratuityLimitAsync(null);
            //}

            //public void GetGratuityLimitAsync(object userState)
            //{
            //    if ((this.onBeginGetGratuityLimitDelegate == null))
            //    {
            //        this.onBeginGetGratuityLimitDelegate = new BeginOperationDelegate(this.OnBeginGetGratuityLimit);
            //    }
            //    if ((this.onEndGetGratuityLimitDelegate == null))
            //    {
            //        this.onEndGetGratuityLimitDelegate = new EndOperationDelegate(this.OnEndGetGratuityLimit);
            //    }
            //    if ((this.onGetGratuityLimitCompletedDelegate == null))
            //    {
            //        this.onGetGratuityLimitCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetGratuityLimitCompleted);
            //    }
            //    base.InvokeAsync(this.onBeginGetGratuityLimitDelegate, null, this.onEndGetGratuityLimitDelegate, this.onGetGratuityLimitCompletedDelegate, userState);
            //}

            //public decimal GetTaxRate()
            //{
            //    return base.Channel.GetTaxRate();
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginGetTaxRate(System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginGetTaxRate(callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public decimal EndGetTaxRate(System.IAsyncResult result)
            //{
            //    return base.Channel.EndGetTaxRate(result);
            //}

            //private System.IAsyncResult OnBeginGetTaxRate(object[] inValues, System.AsyncCallback callback, object asyncState)
            //{
            //    return this.BeginGetTaxRate(callback, asyncState);
            //}

            //private object[] OnEndGetTaxRate(System.IAsyncResult result)
            //{
            //    decimal retVal = this.EndGetTaxRate(result);
            //    return new object[] {
            //retVal};
            //}

            //private void OnGetTaxRateCompleted(object state)
            //{
            //    if ((this.GetTaxRateCompleted != null))
            //    {
            //        InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //        this.GetTaxRateCompleted(this, new GetTaxRateCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //    }
            //}

            //public void GetTaxRateAsync()
            //{
            //    this.GetTaxRateAsync(null);
            //}

            //public void GetTaxRateAsync(object userState)
            //{
            //    if ((this.onBeginGetTaxRateDelegate == null))
            //    {
            //        this.onBeginGetTaxRateDelegate = new BeginOperationDelegate(this.OnBeginGetTaxRate);
            //    }
            //    if ((this.onEndGetTaxRateDelegate == null))
            //    {
            //        this.onEndGetTaxRateDelegate = new EndOperationDelegate(this.OnEndGetTaxRate);
            //    }
            //    if ((this.onGetTaxRateCompletedDelegate == null))
            //    {
            //        this.onGetTaxRateCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetTaxRateCompleted);
            //    }
            //    base.InvokeAsync(this.onBeginGetTaxRateDelegate, null, this.onEndGetTaxRateDelegate, this.onGetTaxRateCompletedDelegate, userState);
            //}

            //public decimal GetGratuityRate()
            //{
            //    return base.Channel.GetGratuityRate();
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginGetGratuityRate(System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginGetGratuityRate(callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public decimal EndGetGratuityRate(System.IAsyncResult result)
            //{
            //    return base.Channel.EndGetGratuityRate(result);
            //}

            //private System.IAsyncResult OnBeginGetGratuityRate(object[] inValues, System.AsyncCallback callback, object asyncState)
            //{
            //    return this.BeginGetGratuityRate(callback, asyncState);
            //}

            //private object[] OnEndGetGratuityRate(System.IAsyncResult result)
            //{
            //    decimal retVal = this.EndGetGratuityRate(result);
            //    return new object[] {
            //retVal};
            //}

            //private void OnGetGratuityRateCompleted(object state)
            //{
            //    if ((this.GetGratuityRateCompleted != null))
            //    {
            //        InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //        this.GetGratuityRateCompleted(this, new GetGratuityRateCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //    }
            //}

            //public void GetGratuityRateAsync()
            //{
            //    this.GetGratuityRateAsync(null);
            //}

            //public void GetGratuityRateAsync(object userState)
            //{
            //    if ((this.onBeginGetGratuityRateDelegate == null))
            //    {
            //        this.onBeginGetGratuityRateDelegate = new BeginOperationDelegate(this.OnBeginGetGratuityRate);
            //    }
            //    if ((this.onEndGetGratuityRateDelegate == null))
            //    {
            //        this.onEndGetGratuityRateDelegate = new EndOperationDelegate(this.OnEndGetGratuityRate);
            //    }
            //    if ((this.onGetGratuityRateCompletedDelegate == null))
            //    {
            //        this.onGetGratuityRateCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetGratuityRateCompleted);
            //    }
            //    base.InvokeAsync(this.onBeginGetGratuityRateDelegate, null, this.onEndGetGratuityRateDelegate, this.onGetGratuityRateCompletedDelegate, userState);
            //}

            //public bool DoAutoGratuity()
            //{
            //    return base.Channel.DoAutoGratuity();
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginDoAutoGratuity(System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginDoAutoGratuity(callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public bool EndDoAutoGratuity(System.IAsyncResult result)
            //{
            //    return base.Channel.EndDoAutoGratuity(result);
            //}

            //private System.IAsyncResult OnBeginDoAutoGratuity(object[] inValues, System.AsyncCallback callback, object asyncState)
            //{
            //    return this.BeginDoAutoGratuity(callback, asyncState);
            //}

            //private object[] OnEndDoAutoGratuity(System.IAsyncResult result)
            //{
            //    bool retVal = this.EndDoAutoGratuity(result);
            //    return new object[] {
            //retVal};
            //}

            //private void OnDoAutoGratuityCompleted(object state)
            //{
            //    if ((this.DoAutoGratuityCompleted != null))
            //    {
            //        InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //        this.DoAutoGratuityCompleted(this, new DoAutoGratuityCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //    }
            //}

            //public void DoAutoGratuityAsync()
            //{
            //    this.DoAutoGratuityAsync(null);
            //}

            //public void DoAutoGratuityAsync(object userState)
            //{
            //    if ((this.onBeginDoAutoGratuityDelegate == null))
            //    {
            //        this.onBeginDoAutoGratuityDelegate = new BeginOperationDelegate(this.OnBeginDoAutoGratuity);
            //    }
            //    if ((this.onEndDoAutoGratuityDelegate == null))
            //    {
            //        this.onEndDoAutoGratuityDelegate = new EndOperationDelegate(this.OnEndDoAutoGratuity);
            //    }
            //    if ((this.onDoAutoGratuityCompletedDelegate == null))
            //    {
            //        this.onDoAutoGratuityCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnDoAutoGratuityCompleted);
            //    }
            //    base.InvokeAsync(this.onBeginDoAutoGratuityDelegate, null, this.onEndDoAutoGratuityDelegate, this.onDoAutoGratuityCompletedDelegate, userState);
            //}

            //public System.Collections.Generic.List<string> GetCategoryNames()
            //{
            //    return base.Channel.GetCategoryNames();
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginGetCategoryNames(System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginGetCategoryNames(callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.Collections.Generic.List<string> EndGetCategoryNames(System.IAsyncResult result)
            //{
            //    return base.Channel.EndGetCategoryNames(result);
            //}

            //private System.IAsyncResult OnBeginGetCategoryNames(object[] inValues, System.AsyncCallback callback, object asyncState)
            //{
            //    return this.BeginGetCategoryNames(callback, asyncState);
            //}

            //private object[] OnEndGetCategoryNames(System.IAsyncResult result)
            //{
            //    System.Collections.Generic.List<string> retVal = this.EndGetCategoryNames(result);
            //    return new object[] {
            //retVal};
            //}

            //private void OnGetCategoryNamesCompleted(object state)
            //{
            //    if ((this.GetCategoryNamesCompleted != null))
            //    {
            //        InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //        this.GetCategoryNamesCompleted(this, new GetCategoryNamesCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //    }
            //}

            //public void GetCategoryNamesAsync()
            //{
            //    this.GetCategoryNamesAsync(null);
            //}

            //public void GetCategoryNamesAsync(object userState)
            //{
            //    if ((this.onBeginGetCategoryNamesDelegate == null))
            //    {
            //        this.onBeginGetCategoryNamesDelegate = new BeginOperationDelegate(this.OnBeginGetCategoryNames);
            //    }
            //    if ((this.onEndGetCategoryNamesDelegate == null))
            //    {
            //        this.onEndGetCategoryNamesDelegate = new EndOperationDelegate(this.OnEndGetCategoryNames);
            //    }
            //    if ((this.onGetCategoryNamesCompletedDelegate == null))
            //    {
            //        this.onGetCategoryNamesCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetCategoryNamesCompleted);
            //    }
            //    base.InvokeAsync(this.onBeginGetCategoryNamesDelegate, null, this.onEndGetCategoryNamesDelegate, this.onGetCategoryNamesCompletedDelegate, userState);
            //}

            //public System.Collections.Generic.List<decimal> GetNextGuestIDs(int num, decimal userID)
            //{
            //    return base.Channel.GetNextGuestIDs(num, userID);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginGetNextGuestIDs(int num, decimal userID, System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginGetNextGuestIDs(num, userID, callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.Collections.Generic.List<decimal> EndGetNextGuestIDs(System.IAsyncResult result)
            //{
            //    return base.Channel.EndGetNextGuestIDs(result);
            //}

            //private System.IAsyncResult OnBeginGetNextGuestIDs(object[] inValues, System.AsyncCallback callback, object asyncState)
            //{
            //    int num = ((int)(inValues[0]));
            //    decimal userID = ((decimal)(inValues[1]));
            //    return this.BeginGetNextGuestIDs(num, userID, callback, asyncState);
            //}

            //private object[] OnEndGetNextGuestIDs(System.IAsyncResult result)
            //{
            //    System.Collections.Generic.List<decimal> retVal = this.EndGetNextGuestIDs(result);
            //    return new object[] {
            //retVal};
            //}

            //private void OnGetNextGuestIDsCompleted(object state)
            //{
            //    if ((this.GetNextGuestIDsCompleted != null))
            //    {
            //        InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //        this.GetNextGuestIDsCompleted(this, new GetNextGuestIDsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //    }
            //}

            //public void GetNextGuestIDsAsync(int num, decimal userID)
            //{
            //    this.GetNextGuestIDsAsync(num, userID, null);
            //}

            //public void GetNextGuestIDsAsync(int num, decimal userID, object userState)
            //{
            //    if ((this.onBeginGetNextGuestIDsDelegate == null))
            //    {
            //        this.onBeginGetNextGuestIDsDelegate = new BeginOperationDelegate(this.OnBeginGetNextGuestIDs);
            //    }
            //    if ((this.onEndGetNextGuestIDsDelegate == null))
            //    {
            //        this.onEndGetNextGuestIDsDelegate = new EndOperationDelegate(this.OnEndGetNextGuestIDs);
            //    }
            //    if ((this.onGetNextGuestIDsCompletedDelegate == null))
            //    {
            //        this.onGetNextGuestIDsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetNextGuestIDsCompleted);
            //    }
            //    base.InvokeAsync(this.onBeginGetNextGuestIDsDelegate, new object[] {
            //    num,
            //    userID}, this.onEndGetNextGuestIDsDelegate, this.onGetNextGuestIDsCompletedDelegate, userState);
            //}

            //public bool RemoveGuest(decimal GuestID, bool RemoveOrder)
            //{
            //    return base.Channel.RemoveGuest(GuestID, RemoveOrder);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginRemoveGuest(decimal GuestID, bool RemoveOrder, System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginRemoveGuest(GuestID, RemoveOrder, callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public bool EndRemoveGuest(System.IAsyncResult result)
            //{
            //    return base.Channel.EndRemoveGuest(result);
            //}

            //private System.IAsyncResult OnBeginRemoveGuest(object[] inValues, System.AsyncCallback callback, object asyncState)
            //{
            //    decimal GuestID = ((decimal)(inValues[0]));
            //    bool RemoveOrder = ((bool)(inValues[1]));
            //    return this.BeginRemoveGuest(GuestID, RemoveOrder, callback, asyncState);
            //}

            //private object[] OnEndRemoveGuest(System.IAsyncResult result)
            //{
            //    bool retVal = this.EndRemoveGuest(result);
            //    return new object[] {
            //retVal};
            //}

            //private void OnRemoveGuestCompleted(object state)
            //{
            //    if ((this.RemoveGuestCompleted != null))
            //    {
            //        InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //        this.RemoveGuestCompleted(this, new RemoveGuestCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //    }
            //}

            //public void RemoveGuestAsync(decimal GuestID, bool RemoveOrder)
            //{
            //    this.RemoveGuestAsync(GuestID, RemoveOrder, null);
            //}

            //public void RemoveGuestAsync(decimal GuestID, bool RemoveOrder, object userState)
            //{
            //    if ((this.onBeginRemoveGuestDelegate == null))
            //    {
            //        this.onBeginRemoveGuestDelegate = new BeginOperationDelegate(this.OnBeginRemoveGuest);
            //    }
            //    if ((this.onEndRemoveGuestDelegate == null))
            //    {
            //        this.onEndRemoveGuestDelegate = new EndOperationDelegate(this.OnEndRemoveGuest);
            //    }
            //    if ((this.onRemoveGuestCompletedDelegate == null))
            //    {
            //        this.onRemoveGuestCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnRemoveGuestCompleted);
            //    }
            //    base.InvokeAsync(this.onBeginRemoveGuestDelegate, new object[] {
            //    GuestID,
            //    RemoveOrder}, this.onEndRemoveGuestDelegate, this.onRemoveGuestCompletedDelegate, userState);
            //}

            //public bool RemoveItem(decimal GuestID, decimal OrderID, decimal UserID)
            //{
            //    return base.Channel.RemoveItem(GuestID, OrderID, UserID);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginRemoveItem(decimal GuestID, decimal OrderID, decimal UserID, System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginRemoveItem(GuestID, OrderID, UserID, callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public bool EndRemoveItem(System.IAsyncResult result)
            //{
            //    return base.Channel.EndRemoveItem(result);
            //}

            //private System.IAsyncResult OnBeginRemoveItem(object[] inValues, System.AsyncCallback callback, object asyncState)
            //{
            //    decimal GuestID = ((decimal)(inValues[0]));
            //    decimal OrderID = ((decimal)(inValues[1]));
            //    decimal UserID = ((decimal)(inValues[2]));
            //    return this.BeginRemoveItem(GuestID, OrderID, UserID, callback, asyncState);
            //}

            //private object[] OnEndRemoveItem(System.IAsyncResult result)
            //{
            //    bool retVal = this.EndRemoveItem(result);
            //    return new object[] {
            //retVal};
            //}

            //private void OnRemoveItemCompleted(object state)
            //{
            //    if ((this.RemoveItemCompleted != null))
            //    {
            //        InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //        this.RemoveItemCompleted(this, new RemoveItemCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //    }
            //}

            //public void RemoveItemAsync(decimal GuestID, decimal OrderID, decimal UserID)
            //{
            //    this.RemoveItemAsync(GuestID, OrderID, UserID, null);
            //}

            //public void RemoveItemAsync(decimal GuestID, decimal OrderID, decimal UserID, object userState)
            //{
            //    if ((this.onBeginRemoveItemDelegate == null))
            //    {
            //        this.onBeginRemoveItemDelegate = new BeginOperationDelegate(this.OnBeginRemoveItem);
            //    }
            //    if ((this.onEndRemoveItemDelegate == null))
            //    {
            //        this.onEndRemoveItemDelegate = new EndOperationDelegate(this.OnEndRemoveItem);
            //    }
            //    if ((this.onRemoveItemCompletedDelegate == null))
            //    {
            //        this.onRemoveItemCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnRemoveItemCompleted);
            //    }
            //    base.InvokeAsync(this.onBeginRemoveItemDelegate, new object[] {
            //    GuestID,
            //    OrderID,
            //    UserID}, this.onEndRemoveItemDelegate, this.onRemoveItemCompletedDelegate, userState);
            //}

            //public Staunch.POS.Classes.ItemInfo GetItemInfo(decimal ItemID)
            //{
            //    return base.Channel.GetItemInfo(ItemID);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginGetItemInfo(decimal ItemID, System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginGetItemInfo(ItemID, callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public Staunch.POS.Classes.ItemInfo EndGetItemInfo(System.IAsyncResult result)
            //{
            //    return base.Channel.EndGetItemInfo(result);
            //}

            //private System.IAsyncResult OnBeginGetItemInfo(object[] inValues, System.AsyncCallback callback, object asyncState)
            //{
            //    decimal ItemID = ((decimal)(inValues[0]));
            //    return this.BeginGetItemInfo(ItemID, callback, asyncState);
            //}

            //private object[] OnEndGetItemInfo(System.IAsyncResult result)
            //{
            //    Staunch.POS.Classes.ItemInfo retVal = this.EndGetItemInfo(result);
            //    return new object[] {
            //retVal};
            //}

            //private void OnGetItemInfoCompleted(object state)
            //{
            //    if ((this.GetItemInfoCompleted != null))
            //    {
            //        InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //        this.GetItemInfoCompleted(this, new GetItemInfoCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //    }
            //}

            //public void GetItemInfoAsync(decimal ItemID)
            //{
            //    this.GetItemInfoAsync(ItemID, null);
            //}

            //public void GetItemInfoAsync(decimal ItemID, object userState)
            //{
            //    if ((this.onBeginGetItemInfoDelegate == null))
            //    {
            //        this.onBeginGetItemInfoDelegate = new BeginOperationDelegate(this.OnBeginGetItemInfo);
            //    }
            //    if ((this.onEndGetItemInfoDelegate == null))
            //    {
            //        this.onEndGetItemInfoDelegate = new EndOperationDelegate(this.OnEndGetItemInfo);
            //    }
            //    if ((this.onGetItemInfoCompletedDelegate == null))
            //    {
            //        this.onGetItemInfoCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetItemInfoCompleted);
            //    }
            //    base.InvokeAsync(this.onBeginGetItemInfoDelegate, new object[] {
            //    ItemID}, this.onEndGetItemInfoDelegate, this.onGetItemInfoCompletedDelegate, userState);
            //}

            //public System.Collections.Generic.Dictionary<decimal, Staunch.POS.Classes.PictureFile> GetThumbnails(System.Collections.Generic.List<decimal> ItemIDs)
            //{
            //    return base.Channel.GetThumbnails(ItemIDs);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginGetThumbnails(System.Collections.Generic.List<decimal> ItemIDs, System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginGetThumbnails(ItemIDs, callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.Collections.Generic.Dictionary<decimal, Staunch.POS.Classes.PictureFile> EndGetThumbnails(System.IAsyncResult result)
            //{
            //    return base.Channel.EndGetThumbnails(result);
            //}

            //private System.IAsyncResult OnBeginGetThumbnails(object[] inValues, System.AsyncCallback callback, object asyncState)
            //{
            //    System.Collections.Generic.List<decimal> ItemIDs = ((System.Collections.Generic.List<decimal>)(inValues[0]));
            //    return this.BeginGetThumbnails(ItemIDs, callback, asyncState);
            //}

            //private object[] OnEndGetThumbnails(System.IAsyncResult result)
            //{
            //    System.Collections.Generic.Dictionary<decimal, Staunch.POS.Classes.PictureFile> retVal = this.EndGetThumbnails(result);
            //    return new object[] {
            //retVal};
            //}

            //private void OnGetThumbnailsCompleted(object state)
            //{
            //    if ((this.GetThumbnailsCompleted != null))
            //    {
            //        InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //        this.GetThumbnailsCompleted(this, new GetThumbnailsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //    }
            //}

            //public void GetThumbnailsAsync(System.Collections.Generic.List<decimal> ItemIDs)
            //{
            //    this.GetThumbnailsAsync(ItemIDs, null);
            //}

            //public void GetThumbnailsAsync(System.Collections.Generic.List<decimal> ItemIDs, object userState)
            //{
            //    if ((this.onBeginGetThumbnailsDelegate == null))
            //    {
            //        this.onBeginGetThumbnailsDelegate = new BeginOperationDelegate(this.OnBeginGetThumbnails);
            //    }
            //    if ((this.onEndGetThumbnailsDelegate == null))
            //    {
            //        this.onEndGetThumbnailsDelegate = new EndOperationDelegate(this.OnEndGetThumbnails);
            //    }
            //    if ((this.onGetThumbnailsCompletedDelegate == null))
            //    {
            //        this.onGetThumbnailsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetThumbnailsCompleted);
            //    }
            //    base.InvokeAsync(this.onBeginGetThumbnailsDelegate, new object[] {
            //    ItemIDs}, this.onEndGetThumbnailsDelegate, this.onGetThumbnailsCompletedDelegate, userState);
            //}

            //public System.Collections.Generic.List<Staunch.POS.Classes.GuestItem> GetOrders(decimal TableID)
            //{
            //    return base.Channel.GetOrders(TableID);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginGetOrders(decimal TableID, System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginGetOrders(TableID, callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.Collections.Generic.List<Staunch.POS.Classes.GuestItem> EndGetOrders(System.IAsyncResult result)
            //{
            //    return base.Channel.EndGetOrders(result);
            //}

            //private System.IAsyncResult OnBeginGetOrders(object[] inValues, System.AsyncCallback callback, object asyncState)
            //{
            //    decimal TableID = ((decimal)(inValues[0]));
            //    return this.BeginGetOrders(TableID, callback, asyncState);
            //}

            //private object[] OnEndGetOrders(System.IAsyncResult result)
            //{
            //    System.Collections.Generic.List<Staunch.POS.Classes.GuestItem> retVal = this.EndGetOrders(result);
            //    return new object[] {
            //retVal};
            //}

            //private void OnGetOrdersCompleted(object state)
            //{
            //    if ((this.GetOrdersCompleted != null))
            //    {
            //        InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //        this.GetOrdersCompleted(this, new GetOrdersCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //    }
            //}

            //public void GetOrdersAsync(decimal TableID)
            //{
            //    this.GetOrdersAsync(TableID, null);
            //}

            //public void GetOrdersAsync(decimal TableID, object userState)
            //{
            //    if ((this.onBeginGetOrdersDelegate == null))
            //    {
            //        this.onBeginGetOrdersDelegate = new BeginOperationDelegate(this.OnBeginGetOrders);
            //    }
            //    if ((this.onEndGetOrdersDelegate == null))
            //    {
            //        this.onEndGetOrdersDelegate = new EndOperationDelegate(this.OnEndGetOrders);
            //    }
            //    if ((this.onGetOrdersCompletedDelegate == null))
            //    {
            //        this.onGetOrdersCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetOrdersCompleted);
            //    }
            //    base.InvokeAsync(this.onBeginGetOrdersDelegate, new object[] {
            //    TableID}, this.onEndGetOrdersDelegate, this.onGetOrdersCompletedDelegate, userState);
            //}

            //public void SendOrders(System.Collections.Generic.List<decimal> OrderIDs, decimal UserID)
            //{
            //    base.Channel.SendOrders(OrderIDs, UserID);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginSendOrders(System.Collections.Generic.List<decimal> OrderIDs, decimal UserID, System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginSendOrders(OrderIDs, UserID, callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public void EndSendOrders(System.IAsyncResult result)
            //{
            //    base.Channel.EndSendOrders(result);
            //}

            //private System.IAsyncResult OnBeginSendOrders(object[] inValues, System.AsyncCallback callback, object asyncState)
            //{
            //    System.Collections.Generic.List<decimal> OrderIDs = ((System.Collections.Generic.List<decimal>)(inValues[0]));
            //    decimal UserID = ((decimal)(inValues[1]));
            //    return this.BeginSendOrders(OrderIDs, UserID, callback, asyncState);
            //}

            //private object[] OnEndSendOrders(System.IAsyncResult result)
            //{
            //    this.EndSendOrders(result);
            //    return null;
            //}

            //private void OnSendOrdersCompleted(object state)
            //{
            //    if ((this.SendOrdersCompleted != null))
            //    {
            //        InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //        this.SendOrdersCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            //    }
            //}

            //public void SendOrdersAsync(System.Collections.Generic.List<decimal> OrderIDs, decimal UserID)
            //{
            //    this.SendOrdersAsync(OrderIDs, UserID, null);
            //}

            //public void SendOrdersAsync(System.Collections.Generic.List<decimal> OrderIDs, decimal UserID, object userState)
            //{
            //    if ((this.onBeginSendOrdersDelegate == null))
            //    {
            //        this.onBeginSendOrdersDelegate = new BeginOperationDelegate(this.OnBeginSendOrders);
            //    }
            //    if ((this.onEndSendOrdersDelegate == null))
            //    {
            //        this.onEndSendOrdersDelegate = new EndOperationDelegate(this.OnEndSendOrders);
            //    }
            //    if ((this.onSendOrdersCompletedDelegate == null))
            //    {
            //        this.onSendOrdersCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSendOrdersCompleted);
            //    }
            //    base.InvokeAsync(this.onBeginSendOrdersDelegate, new object[] {
            //    OrderIDs,
            //    UserID}, this.onEndSendOrdersDelegate, this.onSendOrdersCompletedDelegate, userState);
            //}

            //public void RemoveSentOrder(System.Collections.Generic.List<decimal> OrderIDs, decimal UserID)
            //{
            //    base.Channel.RemoveSentOrder(OrderIDs, UserID);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginRemoveSentOrder(System.Collections.Generic.List<decimal> OrderIDs, decimal UserID, System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginRemoveSentOrder(OrderIDs, UserID, callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public void EndRemoveSentOrder(System.IAsyncResult result)
            //{
            //    base.Channel.EndRemoveSentOrder(result);
            //}

            //private System.IAsyncResult OnBeginRemoveSentOrder(object[] inValues, System.AsyncCallback callback, object asyncState)
            //{
            //    System.Collections.Generic.List<decimal> OrderIDs = ((System.Collections.Generic.List<decimal>)(inValues[0]));
            //    decimal UserID = ((decimal)(inValues[1]));
            //    return this.BeginRemoveSentOrder(OrderIDs, UserID, callback, asyncState);
            //}

            //private object[] OnEndRemoveSentOrder(System.IAsyncResult result)
            //{
            //    this.EndRemoveSentOrder(result);
            //    return null;
            //}

            //private void OnRemoveSentOrderCompleted(object state)
            //{
            //    if ((this.RemoveSentOrderCompleted != null))
            //    {
            //        InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //        this.RemoveSentOrderCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            //    }
            //}

            //public void RemoveSentOrderAsync(System.Collections.Generic.List<decimal> OrderIDs, decimal UserID)
            //{
            //    this.RemoveSentOrderAsync(OrderIDs, UserID, null);
            //}

            //public void RemoveSentOrderAsync(System.Collections.Generic.List<decimal> OrderIDs, decimal UserID, object userState)
            //{
            //    if ((this.onBeginRemoveSentOrderDelegate == null))
            //    {
            //        this.onBeginRemoveSentOrderDelegate = new BeginOperationDelegate(this.OnBeginRemoveSentOrder);
            //    }
            //    if ((this.onEndRemoveSentOrderDelegate == null))
            //    {
            //        this.onEndRemoveSentOrderDelegate = new EndOperationDelegate(this.OnEndRemoveSentOrder);
            //    }
            //    if ((this.onRemoveSentOrderCompletedDelegate == null))
            //    {
            //        this.onRemoveSentOrderCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnRemoveSentOrderCompleted);
            //    }
            //    base.InvokeAsync(this.onBeginRemoveSentOrderDelegate, new object[] {
            //    OrderIDs,
            //    UserID}, this.onEndRemoveSentOrderDelegate, this.onRemoveSentOrderCompletedDelegate, userState);
            //}

            //public bool SaveUserSettings(Staunch.POS.Classes.DBUser user)
            //{
            //    return base.Channel.SaveUserSettings(user);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginSaveUserSettings(Staunch.POS.Classes.DBUser user, System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginSaveUserSettings(user, callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public bool EndSaveUserSettings(System.IAsyncResult result)
            //{
            //    return base.Channel.EndSaveUserSettings(result);
            //}

            //private System.IAsyncResult OnBeginSaveUserSettings(object[] inValues, System.AsyncCallback callback, object asyncState)
            //{
            //    Staunch.POS.Classes.DBUser user = ((Staunch.POS.Classes.DBUser)(inValues[0]));
            //    return this.BeginSaveUserSettings(user, callback, asyncState);
            //}

            //private object[] OnEndSaveUserSettings(System.IAsyncResult result)
            //{
            //    bool retVal = this.EndSaveUserSettings(result);
            //    return new object[] {
            //retVal};
            //}

            //private void OnSaveUserSettingsCompleted(object state)
            //{
            //    if ((this.SaveUserSettingsCompleted != null))
            //    {
            //        InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //        this.SaveUserSettingsCompleted(this, new SaveUserSettingsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //    }
            //}

            //public void SaveUserSettingsAsync(Staunch.POS.Classes.DBUser user)
            //{
            //    this.SaveUserSettingsAsync(user, null);
            //}

            //public void SaveUserSettingsAsync(Staunch.POS.Classes.DBUser user, object userState)
            //{
            //    if ((this.onBeginSaveUserSettingsDelegate == null))
            //    {
            //        this.onBeginSaveUserSettingsDelegate = new BeginOperationDelegate(this.OnBeginSaveUserSettings);
            //    }
            //    if ((this.onEndSaveUserSettingsDelegate == null))
            //    {
            //        this.onEndSaveUserSettingsDelegate = new EndOperationDelegate(this.OnEndSaveUserSettings);
            //    }
            //    if ((this.onSaveUserSettingsCompletedDelegate == null))
            //    {
            //        this.onSaveUserSettingsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSaveUserSettingsCompleted);
            //    }
            //    base.InvokeAsync(this.onBeginSaveUserSettingsDelegate, new object[] {
            //    user}, this.onEndSaveUserSettingsDelegate, this.onSaveUserSettingsCompletedDelegate, userState);
            //}

            //public bool MoveGuests(System.Collections.Generic.List<decimal> GuestIDs, decimal NewTableID)
            //{
            //    return base.Channel.MoveGuests(GuestIDs, NewTableID);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginMoveGuests(System.Collections.Generic.List<decimal> GuestIDs, decimal NewTableID, System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginMoveGuests(GuestIDs, NewTableID, callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public bool EndMoveGuests(System.IAsyncResult result)
            //{
            //    return base.Channel.EndMoveGuests(result);
            //}

            //private System.IAsyncResult OnBeginMoveGuests(object[] inValues, System.AsyncCallback callback, object asyncState)
            //{
            //    System.Collections.Generic.List<decimal> GuestIDs = ((System.Collections.Generic.List<decimal>)(inValues[0]));
            //    decimal NewTableID = ((decimal)(inValues[1]));
            //    return this.BeginMoveGuests(GuestIDs, NewTableID, callback, asyncState);
            //}

            //private object[] OnEndMoveGuests(System.IAsyncResult result)
            //{
            //    bool retVal = this.EndMoveGuests(result);
            //    return new object[] {
            //retVal};
            //}

            //private void OnMoveGuestsCompleted(object state)
            //{
            //    if ((this.MoveGuestsCompleted != null))
            //    {
            //        InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //        this.MoveGuestsCompleted(this, new MoveGuestsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //    }
            //}

            //public void MoveGuestsAsync(System.Collections.Generic.List<decimal> GuestIDs, decimal NewTableID)
            //{
            //    this.MoveGuestsAsync(GuestIDs, NewTableID, null);
            //}

            //public void MoveGuestsAsync(System.Collections.Generic.List<decimal> GuestIDs, decimal NewTableID, object userState)
            //{
            //    if ((this.onBeginMoveGuestsDelegate == null))
            //    {
            //        this.onBeginMoveGuestsDelegate = new BeginOperationDelegate(this.OnBeginMoveGuests);
            //    }
            //    if ((this.onEndMoveGuestsDelegate == null))
            //    {
            //        this.onEndMoveGuestsDelegate = new EndOperationDelegate(this.OnEndMoveGuests);
            //    }
            //    if ((this.onMoveGuestsCompletedDelegate == null))
            //    {
            //        this.onMoveGuestsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnMoveGuestsCompleted);
            //    }
            //    base.InvokeAsync(this.onBeginMoveGuestsDelegate, new object[] {
            //    GuestIDs,
            //    NewTableID}, this.onEndMoveGuestsDelegate, this.onMoveGuestsCompletedDelegate, userState);
            //}

            //public bool SplitTable(decimal TableID)
            //{
            //    return base.Channel.SplitTable(TableID);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginSplitTable(decimal TableID, System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginSplitTable(TableID, callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public bool EndSplitTable(System.IAsyncResult result)
            //{
            //    return base.Channel.EndSplitTable(result);
            //}

            //private System.IAsyncResult OnBeginSplitTable(object[] inValues, System.AsyncCallback callback, object asyncState)
            //{
            //    decimal TableID = ((decimal)(inValues[0]));
            //    return this.BeginSplitTable(TableID, callback, asyncState);
            //}

            //private object[] OnEndSplitTable(System.IAsyncResult result)
            //{
            //    bool retVal = this.EndSplitTable(result);
            //    return new object[] {
            //retVal};
            //}

            //private void OnSplitTableCompleted(object state)
            //{
            //    if ((this.SplitTableCompleted != null))
            //    {
            //        InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //        this.SplitTableCompleted(this, new SplitTableCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //    }
            //}

            //public void SplitTableAsync(decimal TableID)
            //{
            //    this.SplitTableAsync(TableID, null);
            //}

            //public void SplitTableAsync(decimal TableID, object userState)
            //{
            //    if ((this.onBeginSplitTableDelegate == null))
            //    {
            //        this.onBeginSplitTableDelegate = new BeginOperationDelegate(this.OnBeginSplitTable);
            //    }
            //    if ((this.onEndSplitTableDelegate == null))
            //    {
            //        this.onEndSplitTableDelegate = new EndOperationDelegate(this.OnEndSplitTable);
            //    }
            //    if ((this.onSplitTableCompletedDelegate == null))
            //    {
            //        this.onSplitTableCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSplitTableCompleted);
            //    }
            //    base.InvokeAsync(this.onBeginSplitTableDelegate, new object[] {
            //    TableID}, this.onEndSplitTableDelegate, this.onSplitTableCompletedDelegate, userState);
            //}

            //public bool HasUnsentOrders(decimal TableID)
            //{
            //    return base.Channel.HasUnsentOrders(TableID);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginHasUnsentOrders(decimal TableID, System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginHasUnsentOrders(TableID, callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public bool EndHasUnsentOrders(System.IAsyncResult result)
            //{
            //    return base.Channel.EndHasUnsentOrders(result);
            //}

            //private System.IAsyncResult OnBeginHasUnsentOrders(object[] inValues, System.AsyncCallback callback, object asyncState)
            //{
            //    decimal TableID = ((decimal)(inValues[0]));
            //    return this.BeginHasUnsentOrders(TableID, callback, asyncState);
            //}

            //private object[] OnEndHasUnsentOrders(System.IAsyncResult result)
            //{
            //    bool retVal = this.EndHasUnsentOrders(result);
            //    return new object[] {
            //retVal};
            //}

            //private void OnHasUnsentOrdersCompleted(object state)
            //{
            //    if ((this.HasUnsentOrdersCompleted != null))
            //    {
            //        InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //        this.HasUnsentOrdersCompleted(this, new HasUnsentOrdersCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //    }
            //}

            //public void HasUnsentOrdersAsync(decimal TableID)
            //{
            //    this.HasUnsentOrdersAsync(TableID, null);
            //}

            //public void HasUnsentOrdersAsync(decimal TableID, object userState)
            //{
            //    if ((this.onBeginHasUnsentOrdersDelegate == null))
            //    {
            //        this.onBeginHasUnsentOrdersDelegate = new BeginOperationDelegate(this.OnBeginHasUnsentOrders);
            //    }
            //    if ((this.onEndHasUnsentOrdersDelegate == null))
            //    {
            //        this.onEndHasUnsentOrdersDelegate = new EndOperationDelegate(this.OnEndHasUnsentOrders);
            //    }
            //    if ((this.onHasUnsentOrdersCompletedDelegate == null))
            //    {
            //        this.onHasUnsentOrdersCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnHasUnsentOrdersCompleted);
            //    }
            //    base.InvokeAsync(this.onBeginHasUnsentOrdersDelegate, new object[] {
            //    TableID}, this.onEndHasUnsentOrdersDelegate, this.onHasUnsentOrdersCompletedDelegate, userState);
            //}

            //public Staunch.POS.Classes.ManagerSettings GetManagerSettings()
            //{
            //    return base.Channel.GetManagerSettings();
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginGetManagerSettings(System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginGetManagerSettings(callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public Staunch.POS.Classes.ManagerSettings EndGetManagerSettings(System.IAsyncResult result)
            //{
            //    return base.Channel.EndGetManagerSettings(result);
            //}

            //private System.IAsyncResult OnBeginGetManagerSettings(object[] inValues, System.AsyncCallback callback, object asyncState)
            //{
            //    return this.BeginGetManagerSettings(callback, asyncState);
            //}

            //private object[] OnEndGetManagerSettings(System.IAsyncResult result)
            //{
            //    Staunch.POS.Classes.ManagerSettings retVal = this.EndGetManagerSettings(result);
            //    return new object[] {
            //retVal};
            //}

            //private void OnGetManagerSettingsCompleted(object state)
            //{
            //    if ((this.GetManagerSettingsCompleted != null))
            //    {
            //        InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //        this.GetManagerSettingsCompleted(this, new GetManagerSettingsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //    }
            //}

            //public void GetManagerSettingsAsync()
            //{
            //    this.GetManagerSettingsAsync(null);
            //}

            //public void GetManagerSettingsAsync(object userState)
            //{
            //    if ((this.onBeginGetManagerSettingsDelegate == null))
            //    {
            //        this.onBeginGetManagerSettingsDelegate = new BeginOperationDelegate(this.OnBeginGetManagerSettings);
            //    }
            //    if ((this.onEndGetManagerSettingsDelegate == null))
            //    {
            //        this.onEndGetManagerSettingsDelegate = new EndOperationDelegate(this.OnEndGetManagerSettings);
            //    }
            //    if ((this.onGetManagerSettingsCompletedDelegate == null))
            //    {
            //        this.onGetManagerSettingsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetManagerSettingsCompleted);
            //    }
            //    base.InvokeAsync(this.onBeginGetManagerSettingsDelegate, null, this.onEndGetManagerSettingsDelegate, this.onGetManagerSettingsCompletedDelegate, userState);
            //}

            //public bool Logout(decimal UserID)
            //{
            //    return base.Channel.Logout(UserID);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginLogout(decimal UserID, System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginLogout(UserID, callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public bool EndLogout(System.IAsyncResult result)
            //{
            //    return base.Channel.EndLogout(result);
            //}

            //private System.IAsyncResult OnBeginLogout(object[] inValues, System.AsyncCallback callback, object asyncState)
            //{
            //    decimal UserID = ((decimal)(inValues[0]));
            //    return this.BeginLogout(UserID, callback, asyncState);
            //}

            //private object[] OnEndLogout(System.IAsyncResult result)
            //{
            //    bool retVal = this.EndLogout(result);
            //    return new object[] {
            //retVal};
            //}

            //private void OnLogoutCompleted(object state)
            //{
            //    if ((this.LogoutCompleted != null))
            //    {
            //        InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //        this.LogoutCompleted(this, new LogoutCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //    }
            //}

            //public void LogoutAsync(decimal UserID)
            //{
            //    this.LogoutAsync(UserID, null);
            //}

            //public void LogoutAsync(decimal UserID, object userState)
            //{
            //    if ((this.onBeginLogoutDelegate == null))
            //    {
            //        this.onBeginLogoutDelegate = new BeginOperationDelegate(this.OnBeginLogout);
            //    }
            //    if ((this.onEndLogoutDelegate == null))
            //    {
            //        this.onEndLogoutDelegate = new EndOperationDelegate(this.OnEndLogout);
            //    }
            //    if ((this.onLogoutCompletedDelegate == null))
            //    {
            //        this.onLogoutCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnLogoutCompleted);
            //    }
            //    base.InvokeAsync(this.onBeginLogoutDelegate, new object[] {
            //    UserID}, this.onEndLogoutDelegate, this.onLogoutCompletedDelegate, userState);
            //}

            //public int Ping(int Delay)
            //{
            //    return base.Channel.Ping(Delay);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginPing(int Delay, System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginPing(Delay, callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public int EndPing(System.IAsyncResult result)
            //{
            //    return base.Channel.EndPing(result);
            //}

            //private System.IAsyncResult OnBeginPing(object[] inValues, System.AsyncCallback callback, object asyncState)
            //{
            //    int Delay = ((int)(inValues[0]));
            //    return this.BeginPing(Delay, callback, asyncState);
            //}

            //private object[] OnEndPing(System.IAsyncResult result)
            //{
            //    int retVal = this.EndPing(result);
            //    return new object[] {
            //retVal};
            //}

            //private void OnPingCompleted(object state)
            //{
            //    if ((this.PingCompleted != null))
            //    {
            //        InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //        this.PingCompleted(this, new PingCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //    }
            //}

            //public void PingAsync(int Delay)
            //{
            //    this.PingAsync(Delay, null);
            //}

            //public void PingAsync(int Delay, object userState)
            //{
            //    if ((this.onBeginPingDelegate == null))
            //    {
            //        this.onBeginPingDelegate = new BeginOperationDelegate(this.OnBeginPing);
            //    }
            //    if ((this.onEndPingDelegate == null))
            //    {
            //        this.onEndPingDelegate = new EndOperationDelegate(this.OnEndPing);
            //    }
            //    if ((this.onPingCompletedDelegate == null))
            //    {
            //        this.onPingCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnPingCompleted);
            //    }
            //    base.InvokeAsync(this.onBeginPingDelegate, new object[] {
            //    Delay}, this.onEndPingDelegate, this.onPingCompletedDelegate, userState);
            //}

            //public System.Collections.Generic.List<Staunch.POS.Classes.DBModGroup> GetRequiredMods(decimal ItemID)
            //{
            //    return base.Channel.GetRequiredMods(ItemID);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.IAsyncResult BeginGetRequiredMods(decimal ItemID, System.AsyncCallback callback, object asyncState)
            //{
            //    return base.Channel.BeginGetRequiredMods(ItemID, callback, asyncState);
            //}

            //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //public System.Collections.Generic.List<Staunch.POS.Classes.DBModGroup> EndGetRequiredMods(System.IAsyncResult result)
            //{
            //    return base.Channel.EndGetRequiredMods(result);
            //}

            //            private System.IAsyncResult OnBeginGetRequiredMods(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                decimal ItemID = ((decimal)(inValues[0]));
            //                return this.BeginGetRequiredMods(ItemID, callback, asyncState);
            //            }

            //            private object[] OnEndGetRequiredMods(System.IAsyncResult result)
            //            {
            //                System.Collections.Generic.List<Staunch.POS.Classes.DBModGroup> retVal = this.EndGetRequiredMods(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnGetRequiredModsCompleted(object state)
            //            {
            //                if ((this.GetRequiredModsCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.GetRequiredModsCompleted(this, new GetRequiredModsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void GetRequiredModsAsync(decimal ItemID)
            //            {
            //                this.GetRequiredModsAsync(ItemID, null);
            //            }

            //            public void GetRequiredModsAsync(decimal ItemID, object userState)
            //            {
            //                if ((this.onBeginGetRequiredModsDelegate == null))
            //                {
            //                    this.onBeginGetRequiredModsDelegate = new BeginOperationDelegate(this.OnBeginGetRequiredMods);
            //                }
            //                if ((this.onEndGetRequiredModsDelegate == null))
            //                {
            //                    this.onEndGetRequiredModsDelegate = new EndOperationDelegate(this.OnEndGetRequiredMods);
            //                }
            //                if ((this.onGetRequiredModsCompletedDelegate == null))
            //                {
            //                    this.onGetRequiredModsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetRequiredModsCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginGetRequiredModsDelegate, new object[] {
            //                ItemID}, this.onEndGetRequiredModsDelegate, this.onGetRequiredModsCompletedDelegate, userState);
            //            }

            //            public System.Collections.Generic.List<Staunch.POS.Classes.DBModGroup> GetAllMods(decimal ItemID, decimal SizeID)
            //            {
            //                return base.Channel.GetAllMods(ItemID, SizeID);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginGetAllMods(decimal ItemID, decimal SizeID, System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginGetAllMods(ItemID, SizeID, callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.Collections.Generic.List<Staunch.POS.Classes.DBModGroup> EndGetAllMods(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndGetAllMods(result);
            //            }

            //            private System.IAsyncResult OnBeginGetAllMods(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                decimal ItemID = ((decimal)(inValues[0]));
            //                decimal SizeID = ((decimal)(inValues[1]));
            //                return this.BeginGetAllMods(ItemID, SizeID, callback, asyncState);
            //            }

            //            private object[] OnEndGetAllMods(System.IAsyncResult result)
            //            {
            //                System.Collections.Generic.List<Staunch.POS.Classes.DBModGroup> retVal = this.EndGetAllMods(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnGetAllModsCompleted(object state)
            //            {
            //                if ((this.GetAllModsCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.GetAllModsCompleted(this, new GetAllModsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void GetAllModsAsync(decimal ItemID, decimal SizeID)
            //            {
            //                this.GetAllModsAsync(ItemID, SizeID, null);
            //            }

            //            public void GetAllModsAsync(decimal ItemID, decimal SizeID, object userState)
            //            {
            //                if ((this.onBeginGetAllModsDelegate == null))
            //                {
            //                    this.onBeginGetAllModsDelegate = new BeginOperationDelegate(this.OnBeginGetAllMods);
            //                }
            //                if ((this.onEndGetAllModsDelegate == null))
            //                {
            //                    this.onEndGetAllModsDelegate = new EndOperationDelegate(this.OnEndGetAllMods);
            //                }
            //                if ((this.onGetAllModsCompletedDelegate == null))
            //                {
            //                    this.onGetAllModsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetAllModsCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginGetAllModsDelegate, new object[] {
            //                ItemID,
            //                SizeID}, this.onEndGetAllModsDelegate, this.onGetAllModsCompletedDelegate, userState);
            //            }

            //            public System.Collections.Generic.List<Staunch.POS.Classes.ComboItem> GetComboMenu()
            //            {
            //                return base.Channel.GetComboMenu();
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginGetComboMenu(System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginGetComboMenu(callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.Collections.Generic.List<Staunch.POS.Classes.ComboItem> EndGetComboMenu(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndGetComboMenu(result);
            //            }

            //            private System.IAsyncResult OnBeginGetComboMenu(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                return this.BeginGetComboMenu(callback, asyncState);
            //            }

            //            private object[] OnEndGetComboMenu(System.IAsyncResult result)
            //            {
            //                System.Collections.Generic.List<Staunch.POS.Classes.ComboItem> retVal = this.EndGetComboMenu(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnGetComboMenuCompleted(object state)
            //            {
            //                if ((this.GetComboMenuCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.GetComboMenuCompleted(this, new GetComboMenuCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void GetComboMenuAsync()
            //            {
            //                this.GetComboMenuAsync(null);
            //            }

            //            public void GetComboMenuAsync(object userState)
            //            {
            //                if ((this.onBeginGetComboMenuDelegate == null))
            //                {
            //                    this.onBeginGetComboMenuDelegate = new BeginOperationDelegate(this.OnBeginGetComboMenu);
            //                }
            //                if ((this.onEndGetComboMenuDelegate == null))
            //                {
            //                    this.onEndGetComboMenuDelegate = new EndOperationDelegate(this.OnEndGetComboMenu);
            //                }
            //                if ((this.onGetComboMenuCompletedDelegate == null))
            //                {
            //                    this.onGetComboMenuCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetComboMenuCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginGetComboMenuDelegate, null, this.onEndGetComboMenuDelegate, this.onGetComboMenuCompletedDelegate, userState);
            //            }

            //            public bool RemoveGuestCombo(decimal GuestID, decimal OrderComboID, decimal UserID)
            //            {
            //                return base.Channel.RemoveGuestCombo(GuestID, OrderComboID, UserID);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginRemoveGuestCombo(decimal GuestID, decimal OrderComboID, decimal UserID, System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginRemoveGuestCombo(GuestID, OrderComboID, UserID, callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public bool EndRemoveGuestCombo(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndRemoveGuestCombo(result);
            //            }

            //            private System.IAsyncResult OnBeginRemoveGuestCombo(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                decimal GuestID = ((decimal)(inValues[0]));
            //                decimal OrderComboID = ((decimal)(inValues[1]));
            //                decimal UserID = ((decimal)(inValues[2]));
            //                return this.BeginRemoveGuestCombo(GuestID, OrderComboID, UserID, callback, asyncState);
            //            }

            //            private object[] OnEndRemoveGuestCombo(System.IAsyncResult result)
            //            {
            //                bool retVal = this.EndRemoveGuestCombo(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnRemoveGuestComboCompleted(object state)
            //            {
            //                if ((this.RemoveGuestComboCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.RemoveGuestComboCompleted(this, new RemoveGuestComboCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void RemoveGuestComboAsync(decimal GuestID, decimal OrderComboID, decimal UserID)
            //            {
            //                this.RemoveGuestComboAsync(GuestID, OrderComboID, UserID, null);
            //            }

            //            public void RemoveGuestComboAsync(decimal GuestID, decimal OrderComboID, decimal UserID, object userState)
            //            {
            //                if ((this.onBeginRemoveGuestComboDelegate == null))
            //                {
            //                    this.onBeginRemoveGuestComboDelegate = new BeginOperationDelegate(this.OnBeginRemoveGuestCombo);
            //                }
            //                if ((this.onEndRemoveGuestComboDelegate == null))
            //                {
            //                    this.onEndRemoveGuestComboDelegate = new EndOperationDelegate(this.OnEndRemoveGuestCombo);
            //                }
            //                if ((this.onRemoveGuestComboCompletedDelegate == null))
            //                {
            //                    this.onRemoveGuestComboCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnRemoveGuestComboCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginRemoveGuestComboDelegate, new object[] {
            //                GuestID,
            //                OrderComboID,
            //                UserID}, this.onEndRemoveGuestComboDelegate, this.onRemoveGuestComboCompletedDelegate, userState);
            //            }

            //            public bool CombineOrders(decimal DestinationGuestID, System.Collections.Generic.List<decimal> GuestsToMoveIDs, bool RemoveAfterCombine)
            //            {
            //                return base.Channel.CombineOrders(DestinationGuestID, GuestsToMoveIDs, RemoveAfterCombine);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginCombineOrders(decimal DestinationGuestID, System.Collections.Generic.List<decimal> GuestsToMoveIDs, bool RemoveAfterCombine, System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginCombineOrders(DestinationGuestID, GuestsToMoveIDs, RemoveAfterCombine, callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public bool EndCombineOrders(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndCombineOrders(result);
            //            }

            //            private System.IAsyncResult OnBeginCombineOrders(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                decimal DestinationGuestID = ((decimal)(inValues[0]));
            //                System.Collections.Generic.List<decimal> GuestsToMoveIDs = ((System.Collections.Generic.List<decimal>)(inValues[1]));
            //                bool RemoveAfterCombine = ((bool)(inValues[2]));
            //                return this.BeginCombineOrders(DestinationGuestID, GuestsToMoveIDs, RemoveAfterCombine, callback, asyncState);
            //            }

            //            private object[] OnEndCombineOrders(System.IAsyncResult result)
            //            {
            //                bool retVal = this.EndCombineOrders(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnCombineOrdersCompleted(object state)
            //            {
            //                if ((this.CombineOrdersCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.CombineOrdersCompleted(this, new CombineOrdersCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void CombineOrdersAsync(decimal DestinationGuestID, System.Collections.Generic.List<decimal> GuestsToMoveIDs, bool RemoveAfterCombine)
            //            {
            //                this.CombineOrdersAsync(DestinationGuestID, GuestsToMoveIDs, RemoveAfterCombine, null);
            //            }

            //            public void CombineOrdersAsync(decimal DestinationGuestID, System.Collections.Generic.List<decimal> GuestsToMoveIDs, bool RemoveAfterCombine, object userState)
            //            {
            //                if ((this.onBeginCombineOrdersDelegate == null))
            //                {
            //                    this.onBeginCombineOrdersDelegate = new BeginOperationDelegate(this.OnBeginCombineOrders);
            //                }
            //                if ((this.onEndCombineOrdersDelegate == null))
            //                {
            //                    this.onEndCombineOrdersDelegate = new EndOperationDelegate(this.OnEndCombineOrders);
            //                }
            //                if ((this.onCombineOrdersCompletedDelegate == null))
            //                {
            //                    this.onCombineOrdersCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCombineOrdersCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginCombineOrdersDelegate, new object[] {
            //                DestinationGuestID,
            //                GuestsToMoveIDs,
            //                RemoveAfterCombine}, this.onEndCombineOrdersDelegate, this.onCombineOrdersCompletedDelegate, userState);
            //            }

            //            public bool ClearTable(decimal TableID)
            //            {
            //                return base.Channel.ClearTable(TableID);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginClearTable(decimal TableID, System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginClearTable(TableID, callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public bool EndClearTable(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndClearTable(result);
            //            }

            //            private System.IAsyncResult OnBeginClearTable(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                decimal TableID = ((decimal)(inValues[0]));
            //                return this.BeginClearTable(TableID, callback, asyncState);
            //            }

            //            private object[] OnEndClearTable(System.IAsyncResult result)
            //            {
            //                bool retVal = this.EndClearTable(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnClearTableCompleted(object state)
            //            {
            //                if ((this.ClearTableCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.ClearTableCompleted(this, new ClearTableCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void ClearTableAsync(decimal TableID)
            //            {
            //                this.ClearTableAsync(TableID, null);
            //            }

            //            public void ClearTableAsync(decimal TableID, object userState)
            //            {
            //                if ((this.onBeginClearTableDelegate == null))
            //                {
            //                    this.onBeginClearTableDelegate = new BeginOperationDelegate(this.OnBeginClearTable);
            //                }
            //                if ((this.onEndClearTableDelegate == null))
            //                {
            //                    this.onEndClearTableDelegate = new EndOperationDelegate(this.OnEndClearTable);
            //                }
            //                if ((this.onClearTableCompletedDelegate == null))
            //                {
            //                    this.onClearTableCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnClearTableCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginClearTableDelegate, new object[] {
            //                TableID}, this.onEndClearTableDelegate, this.onClearTableCompletedDelegate, userState);
            //            }

            //            public Staunch.POS.Classes.TakeoutOrder SubmitTakeout(Staunch.POS.Classes.TakeoutOrder TakeoutGuest, decimal UserID)
            //            {
            //                return base.Channel.SubmitTakeout(TakeoutGuest, UserID);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginSubmitTakeout(Staunch.POS.Classes.TakeoutOrder TakeoutGuest, decimal UserID, System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginSubmitTakeout(TakeoutGuest, UserID, callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public Staunch.POS.Classes.TakeoutOrder EndSubmitTakeout(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndSubmitTakeout(result);
            //            }

            //            private System.IAsyncResult OnBeginSubmitTakeout(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                Staunch.POS.Classes.TakeoutOrder TakeoutGuest = ((Staunch.POS.Classes.TakeoutOrder)(inValues[0]));
            //                decimal UserID = ((decimal)(inValues[1]));
            //                return this.BeginSubmitTakeout(TakeoutGuest, UserID, callback, asyncState);
            //            }

            //            private object[] OnEndSubmitTakeout(System.IAsyncResult result)
            //            {
            //                Staunch.POS.Classes.TakeoutOrder retVal = this.EndSubmitTakeout(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnSubmitTakeoutCompleted(object state)
            //            {
            //                if ((this.SubmitTakeoutCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.SubmitTakeoutCompleted(this, new SubmitTakeoutCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void SubmitTakeoutAsync(Staunch.POS.Classes.TakeoutOrder TakeoutGuest, decimal UserID)
            //            {
            //                this.SubmitTakeoutAsync(TakeoutGuest, UserID, null);
            //            }

            //            public void SubmitTakeoutAsync(Staunch.POS.Classes.TakeoutOrder TakeoutGuest, decimal UserID, object userState)
            //            {
            //                if ((this.onBeginSubmitTakeoutDelegate == null))
            //                {
            //                    this.onBeginSubmitTakeoutDelegate = new BeginOperationDelegate(this.OnBeginSubmitTakeout);
            //                }
            //                if ((this.onEndSubmitTakeoutDelegate == null))
            //                {
            //                    this.onEndSubmitTakeoutDelegate = new EndOperationDelegate(this.OnEndSubmitTakeout);
            //                }
            //                if ((this.onSubmitTakeoutCompletedDelegate == null))
            //                {
            //                    this.onSubmitTakeoutCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSubmitTakeoutCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginSubmitTakeoutDelegate, new object[] {
            //                TakeoutGuest,
            //                UserID}, this.onEndSubmitTakeoutDelegate, this.onSubmitTakeoutCompletedDelegate, userState);
            //            }

            //            public System.Collections.Generic.List<Staunch.POS.Classes.TakeoutOrder> GetTakeoutOrders()
            //            {
            //                return base.Channel.GetTakeoutOrders();
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginGetTakeoutOrders(System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginGetTakeoutOrders(callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.Collections.Generic.List<Staunch.POS.Classes.TakeoutOrder> EndGetTakeoutOrders(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndGetTakeoutOrders(result);
            //            }

            //            private System.IAsyncResult OnBeginGetTakeoutOrders(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                return this.BeginGetTakeoutOrders(callback, asyncState);
            //            }

            //            private object[] OnEndGetTakeoutOrders(System.IAsyncResult result)
            //            {
            //                System.Collections.Generic.List<Staunch.POS.Classes.TakeoutOrder> retVal = this.EndGetTakeoutOrders(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnGetTakeoutOrdersCompleted(object state)
            //            {
            //                if ((this.GetTakeoutOrdersCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.GetTakeoutOrdersCompleted(this, new GetTakeoutOrdersCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void GetTakeoutOrdersAsync()
            //            {
            //                this.GetTakeoutOrdersAsync(null);
            //            }

            //            public void GetTakeoutOrdersAsync(object userState)
            //            {
            //                if ((this.onBeginGetTakeoutOrdersDelegate == null))
            //                {
            //                    this.onBeginGetTakeoutOrdersDelegate = new BeginOperationDelegate(this.OnBeginGetTakeoutOrders);
            //                }
            //                if ((this.onEndGetTakeoutOrdersDelegate == null))
            //                {
            //                    this.onEndGetTakeoutOrdersDelegate = new EndOperationDelegate(this.OnEndGetTakeoutOrders);
            //                }
            //                if ((this.onGetTakeoutOrdersCompletedDelegate == null))
            //                {
            //                    this.onGetTakeoutOrdersCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetTakeoutOrdersCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginGetTakeoutOrdersDelegate, null, this.onEndGetTakeoutOrdersDelegate, this.onGetTakeoutOrdersCompletedDelegate, userState);
            //            }

            //            public Staunch.POS.Classes.TakeoutOrder GetTakeoutOrder(decimal GuestID, decimal CheckID)
            //            {
            //                return base.Channel.GetTakeoutOrder(GuestID, CheckID);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginGetTakeoutOrder(decimal GuestID, decimal CheckID, System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginGetTakeoutOrder(GuestID, CheckID, callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public Staunch.POS.Classes.TakeoutOrder EndGetTakeoutOrder(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndGetTakeoutOrder(result);
            //            }

            //            private System.IAsyncResult OnBeginGetTakeoutOrder(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                decimal GuestID = ((decimal)(inValues[0]));
            //                decimal CheckID = ((decimal)(inValues[1]));
            //                return this.BeginGetTakeoutOrder(GuestID, CheckID, callback, asyncState);
            //            }

            //            private object[] OnEndGetTakeoutOrder(System.IAsyncResult result)
            //            {
            //                Staunch.POS.Classes.TakeoutOrder retVal = this.EndGetTakeoutOrder(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnGetTakeoutOrderCompleted(object state)
            //            {
            //                if ((this.GetTakeoutOrderCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.GetTakeoutOrderCompleted(this, new GetTakeoutOrderCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void GetTakeoutOrderAsync(decimal GuestID, decimal CheckID)
            //            {
            //                this.GetTakeoutOrderAsync(GuestID, CheckID, null);
            //            }

            //            public void GetTakeoutOrderAsync(decimal GuestID, decimal CheckID, object userState)
            //            {
            //                if ((this.onBeginGetTakeoutOrderDelegate == null))
            //                {
            //                    this.onBeginGetTakeoutOrderDelegate = new BeginOperationDelegate(this.OnBeginGetTakeoutOrder);
            //                }
            //                if ((this.onEndGetTakeoutOrderDelegate == null))
            //                {
            //                    this.onEndGetTakeoutOrderDelegate = new EndOperationDelegate(this.OnEndGetTakeoutOrder);
            //                }
            //                if ((this.onGetTakeoutOrderCompletedDelegate == null))
            //                {
            //                    this.onGetTakeoutOrderCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetTakeoutOrderCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginGetTakeoutOrderDelegate, new object[] {
            //                GuestID,
            //                CheckID}, this.onEndGetTakeoutOrderDelegate, this.onGetTakeoutOrderCompletedDelegate, userState);
            //            }

            //            public void SendTakeout(Staunch.POS.Classes.TakeoutOrder TakeoutGuest, decimal UserID)
            //            {
            //                base.Channel.SendTakeout(TakeoutGuest, UserID);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginSendTakeout(Staunch.POS.Classes.TakeoutOrder TakeoutGuest, decimal UserID, System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginSendTakeout(TakeoutGuest, UserID, callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public void EndSendTakeout(System.IAsyncResult result)
            //            {
            //                base.Channel.EndSendTakeout(result);
            //            }

            //            private System.IAsyncResult OnBeginSendTakeout(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                Staunch.POS.Classes.TakeoutOrder TakeoutGuest = ((Staunch.POS.Classes.TakeoutOrder)(inValues[0]));
            //                decimal UserID = ((decimal)(inValues[1]));
            //                return this.BeginSendTakeout(TakeoutGuest, UserID, callback, asyncState);
            //            }

            //            private object[] OnEndSendTakeout(System.IAsyncResult result)
            //            {
            //                this.EndSendTakeout(result);
            //                return null;
            //            }

            //            private void OnSendTakeoutCompleted(object state)
            //            {
            //                if ((this.SendTakeoutCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.SendTakeoutCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void SendTakeoutAsync(Staunch.POS.Classes.TakeoutOrder TakeoutGuest, decimal UserID)
            //            {
            //                this.SendTakeoutAsync(TakeoutGuest, UserID, null);
            //            }

            //            public void SendTakeoutAsync(Staunch.POS.Classes.TakeoutOrder TakeoutGuest, decimal UserID, object userState)
            //            {
            //                if ((this.onBeginSendTakeoutDelegate == null))
            //                {
            //                    this.onBeginSendTakeoutDelegate = new BeginOperationDelegate(this.OnBeginSendTakeout);
            //                }
            //                if ((this.onEndSendTakeoutDelegate == null))
            //                {
            //                    this.onEndSendTakeoutDelegate = new EndOperationDelegate(this.OnEndSendTakeout);
            //                }
            //                if ((this.onSendTakeoutCompletedDelegate == null))
            //                {
            //                    this.onSendTakeoutCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSendTakeoutCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginSendTakeoutDelegate, new object[] {
            //                TakeoutGuest,
            //                UserID}, this.onEndSendTakeoutDelegate, this.onSendTakeoutCompletedDelegate, userState);
            //            }

            //            public bool ClearTakeoutOrder(decimal TakeoutID)
            //            {
            //                return base.Channel.ClearTakeoutOrder(TakeoutID);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginClearTakeoutOrder(decimal TakeoutID, System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginClearTakeoutOrder(TakeoutID, callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public bool EndClearTakeoutOrder(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndClearTakeoutOrder(result);
            //            }

            //            private System.IAsyncResult OnBeginClearTakeoutOrder(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                decimal TakeoutID = ((decimal)(inValues[0]));
            //                return this.BeginClearTakeoutOrder(TakeoutID, callback, asyncState);
            //            }

            //            private object[] OnEndClearTakeoutOrder(System.IAsyncResult result)
            //            {
            //                bool retVal = this.EndClearTakeoutOrder(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnClearTakeoutOrderCompleted(object state)
            //            {
            //                if ((this.ClearTakeoutOrderCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.ClearTakeoutOrderCompleted(this, new ClearTakeoutOrderCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void ClearTakeoutOrderAsync(decimal TakeoutID)
            //            {
            //                this.ClearTakeoutOrderAsync(TakeoutID, null);
            //            }

            //            public void ClearTakeoutOrderAsync(decimal TakeoutID, object userState)
            //            {
            //                if ((this.onBeginClearTakeoutOrderDelegate == null))
            //                {
            //                    this.onBeginClearTakeoutOrderDelegate = new BeginOperationDelegate(this.OnBeginClearTakeoutOrder);
            //                }
            //                if ((this.onEndClearTakeoutOrderDelegate == null))
            //                {
            //                    this.onEndClearTakeoutOrderDelegate = new EndOperationDelegate(this.OnEndClearTakeoutOrder);
            //                }
            //                if ((this.onClearTakeoutOrderCompletedDelegate == null))
            //                {
            //                    this.onClearTakeoutOrderCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnClearTakeoutOrderCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginClearTakeoutOrderDelegate, new object[] {
            //                TakeoutID}, this.onEndClearTakeoutOrderDelegate, this.onClearTakeoutOrderCompletedDelegate, userState);
            //            }

            //            public System.Collections.Generic.List<decimal> ListUnsentOrders(System.Collections.Generic.List<decimal> TableIDList)
            //            {
            //                return base.Channel.ListUnsentOrders(TableIDList);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginListUnsentOrders(System.Collections.Generic.List<decimal> TableIDList, System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginListUnsentOrders(TableIDList, callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.Collections.Generic.List<decimal> EndListUnsentOrders(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndListUnsentOrders(result);
            //            }

            //            private System.IAsyncResult OnBeginListUnsentOrders(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                System.Collections.Generic.List<decimal> TableIDList = ((System.Collections.Generic.List<decimal>)(inValues[0]));
            //                return this.BeginListUnsentOrders(TableIDList, callback, asyncState);
            //            }

            //            private object[] OnEndListUnsentOrders(System.IAsyncResult result)
            //            {
            //                System.Collections.Generic.List<decimal> retVal = this.EndListUnsentOrders(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnListUnsentOrdersCompleted(object state)
            //            {
            //                if ((this.ListUnsentOrdersCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.ListUnsentOrdersCompleted(this, new ListUnsentOrdersCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void ListUnsentOrdersAsync(System.Collections.Generic.List<decimal> TableIDList)
            //            {
            //                this.ListUnsentOrdersAsync(TableIDList, null);
            //            }

            //            public void ListUnsentOrdersAsync(System.Collections.Generic.List<decimal> TableIDList, object userState)
            //            {
            //                if ((this.onBeginListUnsentOrdersDelegate == null))
            //                {
            //                    this.onBeginListUnsentOrdersDelegate = new BeginOperationDelegate(this.OnBeginListUnsentOrders);
            //                }
            //                if ((this.onEndListUnsentOrdersDelegate == null))
            //                {
            //                    this.onEndListUnsentOrdersDelegate = new EndOperationDelegate(this.OnEndListUnsentOrders);
            //                }
            //                if ((this.onListUnsentOrdersCompletedDelegate == null))
            //                {
            //                    this.onListUnsentOrdersCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnListUnsentOrdersCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginListUnsentOrdersDelegate, new object[] {
            //                TableIDList}, this.onEndListUnsentOrdersDelegate, this.onListUnsentOrdersCompletedDelegate, userState);
            //            }

            //            public bool PrintMoveNotice(System.Collections.Generic.List<decimal> orderIDs, decimal fromTableID, decimal toTableID)
            //            {
            //                return base.Channel.PrintMoveNotice(orderIDs, fromTableID, toTableID);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginPrintMoveNotice(System.Collections.Generic.List<decimal> orderIDs, decimal fromTableID, decimal toTableID, System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginPrintMoveNotice(orderIDs, fromTableID, toTableID, callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public bool EndPrintMoveNotice(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndPrintMoveNotice(result);
            //            }

            //            private System.IAsyncResult OnBeginPrintMoveNotice(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                System.Collections.Generic.List<decimal> orderIDs = ((System.Collections.Generic.List<decimal>)(inValues[0]));
            //                decimal fromTableID = ((decimal)(inValues[1]));
            //                decimal toTableID = ((decimal)(inValues[2]));
            //                return this.BeginPrintMoveNotice(orderIDs, fromTableID, toTableID, callback, asyncState);
            //            }

            //            private object[] OnEndPrintMoveNotice(System.IAsyncResult result)
            //            {
            //                bool retVal = this.EndPrintMoveNotice(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnPrintMoveNoticeCompleted(object state)
            //            {
            //                if ((this.PrintMoveNoticeCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.PrintMoveNoticeCompleted(this, new PrintMoveNoticeCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void PrintMoveNoticeAsync(System.Collections.Generic.List<decimal> orderIDs, decimal fromTableID, decimal toTableID)
            //            {
            //                this.PrintMoveNoticeAsync(orderIDs, fromTableID, toTableID, null);
            //            }

            //            public void PrintMoveNoticeAsync(System.Collections.Generic.List<decimal> orderIDs, decimal fromTableID, decimal toTableID, object userState)
            //            {
            //                if ((this.onBeginPrintMoveNoticeDelegate == null))
            //                {
            //                    this.onBeginPrintMoveNoticeDelegate = new BeginOperationDelegate(this.OnBeginPrintMoveNotice);
            //                }
            //                if ((this.onEndPrintMoveNoticeDelegate == null))
            //                {
            //                    this.onEndPrintMoveNoticeDelegate = new EndOperationDelegate(this.OnEndPrintMoveNotice);
            //                }
            //                if ((this.onPrintMoveNoticeCompletedDelegate == null))
            //                {
            //                    this.onPrintMoveNoticeCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnPrintMoveNoticeCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginPrintMoveNoticeDelegate, new object[] {
            //                orderIDs,
            //                fromTableID,
            //                toTableID}, this.onEndPrintMoveNoticeDelegate, this.onPrintMoveNoticeCompletedDelegate, userState);
            //            }

            //            public System.Collections.Generic.Dictionary<decimal, System.Collections.Generic.Dictionary<decimal, System.Collections.Generic.List<Staunch.POS.Classes.DBModGroup>>> GetModsForAllItems()
            //            {
            //                return base.Channel.GetModsForAllItems();
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginGetModsForAllItems(System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginGetModsForAllItems(callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.Collections.Generic.Dictionary<decimal, System.Collections.Generic.Dictionary<decimal, System.Collections.Generic.List<Staunch.POS.Classes.DBModGroup>>> EndGetModsForAllItems(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndGetModsForAllItems(result);
            //            }

            //            private System.IAsyncResult OnBeginGetModsForAllItems(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                return this.BeginGetModsForAllItems(callback, asyncState);
            //            }

            //            private object[] OnEndGetModsForAllItems(System.IAsyncResult result)
            //            {
            //                System.Collections.Generic.Dictionary<decimal, System.Collections.Generic.Dictionary<decimal, System.Collections.Generic.List<Staunch.POS.Classes.DBModGroup>>> retVal = this.EndGetModsForAllItems(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnGetModsForAllItemsCompleted(object state)
            //            {
            //                if ((this.GetModsForAllItemsCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.GetModsForAllItemsCompleted(this, new GetModsForAllItemsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void GetModsForAllItemsAsync()
            //            {
            //                this.GetModsForAllItemsAsync(null);
            //            }

            //            public void GetModsForAllItemsAsync(object userState)
            //            {
            //                if ((this.onBeginGetModsForAllItemsDelegate == null))
            //                {
            //                    this.onBeginGetModsForAllItemsDelegate = new BeginOperationDelegate(this.OnBeginGetModsForAllItems);
            //                }
            //                if ((this.onEndGetModsForAllItemsDelegate == null))
            //                {
            //                    this.onEndGetModsForAllItemsDelegate = new EndOperationDelegate(this.OnEndGetModsForAllItems);
            //                }
            //                if ((this.onGetModsForAllItemsCompletedDelegate == null))
            //                {
            //                    this.onGetModsForAllItemsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetModsForAllItemsCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginGetModsForAllItemsDelegate, null, this.onEndGetModsForAllItemsDelegate, this.onGetModsForAllItemsCompletedDelegate, userState);
            //            }

            //            public System.Collections.Generic.List<Staunch.POS.Classes.DBItem> GetSpecialItems()
            //            {
            //                return base.Channel.GetSpecialItems();
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginGetSpecialItems(System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginGetSpecialItems(callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.Collections.Generic.List<Staunch.POS.Classes.DBItem> EndGetSpecialItems(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndGetSpecialItems(result);
            //            }

            //            private System.IAsyncResult OnBeginGetSpecialItems(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                return this.BeginGetSpecialItems(callback, asyncState);
            //            }

            //            private object[] OnEndGetSpecialItems(System.IAsyncResult result)
            //            {
            //                System.Collections.Generic.List<Staunch.POS.Classes.DBItem> retVal = this.EndGetSpecialItems(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnGetSpecialItemsCompleted(object state)
            //            {
            //                if ((this.GetSpecialItemsCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.GetSpecialItemsCompleted(this, new GetSpecialItemsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void GetSpecialItemsAsync()
            //            {
            //                this.GetSpecialItemsAsync(null);
            //            }

            //            public void GetSpecialItemsAsync(object userState)
            //            {
            //                if ((this.onBeginGetSpecialItemsDelegate == null))
            //                {
            //                    this.onBeginGetSpecialItemsDelegate = new BeginOperationDelegate(this.OnBeginGetSpecialItems);
            //                }
            //                if ((this.onEndGetSpecialItemsDelegate == null))
            //                {
            //                    this.onEndGetSpecialItemsDelegate = new EndOperationDelegate(this.OnEndGetSpecialItems);
            //                }
            //                if ((this.onGetSpecialItemsCompletedDelegate == null))
            //                {
            //                    this.onGetSpecialItemsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetSpecialItemsCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginGetSpecialItemsDelegate, null, this.onEndGetSpecialItemsDelegate, this.onGetSpecialItemsCompletedDelegate, userState);
            //            }

            //            public System.Collections.Generic.List<Staunch.POS.Classes.DBTable> GetTablesForSection(decimal sectionID)
            //            {
            //                return base.Channel.GetTablesForSection(sectionID);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginGetTablesForSection(decimal sectionID, System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginGetTablesForSection(sectionID, callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.Collections.Generic.List<Staunch.POS.Classes.DBTable> EndGetTablesForSection(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndGetTablesForSection(result);
            //            }

            //            private System.IAsyncResult OnBeginGetTablesForSection(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                decimal sectionID = ((decimal)(inValues[0]));
            //                return this.BeginGetTablesForSection(sectionID, callback, asyncState);
            //            }

            //            private object[] OnEndGetTablesForSection(System.IAsyncResult result)
            //            {
            //                System.Collections.Generic.List<Staunch.POS.Classes.DBTable> retVal = this.EndGetTablesForSection(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnGetTablesForSectionCompleted(object state)
            //            {
            //                if ((this.GetTablesForSectionCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.GetTablesForSectionCompleted(this, new GetTablesForSectionCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void GetTablesForSectionAsync(decimal sectionID)
            //            {
            //                this.GetTablesForSectionAsync(sectionID, null);
            //            }

            //            public void GetTablesForSectionAsync(decimal sectionID, object userState)
            //            {
            //                if ((this.onBeginGetTablesForSectionDelegate == null))
            //                {
            //                    this.onBeginGetTablesForSectionDelegate = new BeginOperationDelegate(this.OnBeginGetTablesForSection);
            //                }
            //                if ((this.onEndGetTablesForSectionDelegate == null))
            //                {
            //                    this.onEndGetTablesForSectionDelegate = new EndOperationDelegate(this.OnEndGetTablesForSection);
            //                }
            //                if ((this.onGetTablesForSectionCompletedDelegate == null))
            //                {
            //                    this.onGetTablesForSectionCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetTablesForSectionCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginGetTablesForSectionDelegate, new object[] {
            //                sectionID}, this.onEndGetTablesForSectionDelegate, this.onGetTablesForSectionCompletedDelegate, userState);
            //            }

            //            public bool ChangeItemSize(decimal orderID, decimal newSizeID)
            //            {
            //                return base.Channel.ChangeItemSize(orderID, newSizeID);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginChangeItemSize(decimal orderID, decimal newSizeID, System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginChangeItemSize(orderID, newSizeID, callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public bool EndChangeItemSize(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndChangeItemSize(result);
            //            }

            //            private System.IAsyncResult OnBeginChangeItemSize(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                decimal orderID = ((decimal)(inValues[0]));
            //                decimal newSizeID = ((decimal)(inValues[1]));
            //                return this.BeginChangeItemSize(orderID, newSizeID, callback, asyncState);
            //            }

            //            private object[] OnEndChangeItemSize(System.IAsyncResult result)
            //            {
            //                bool retVal = this.EndChangeItemSize(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnChangeItemSizeCompleted(object state)
            //            {
            //                if ((this.ChangeItemSizeCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.ChangeItemSizeCompleted(this, new ChangeItemSizeCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void ChangeItemSizeAsync(decimal orderID, decimal newSizeID)
            //            {
            //                this.ChangeItemSizeAsync(orderID, newSizeID, null);
            //            }

            //            public void ChangeItemSizeAsync(decimal orderID, decimal newSizeID, object userState)
            //            {
            //                if ((this.onBeginChangeItemSizeDelegate == null))
            //                {
            //                    this.onBeginChangeItemSizeDelegate = new BeginOperationDelegate(this.OnBeginChangeItemSize);
            //                }
            //                if ((this.onEndChangeItemSizeDelegate == null))
            //                {
            //                    this.onEndChangeItemSizeDelegate = new EndOperationDelegate(this.OnEndChangeItemSize);
            //                }
            //                if ((this.onChangeItemSizeCompletedDelegate == null))
            //                {
            //                    this.onChangeItemSizeCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnChangeItemSizeCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginChangeItemSizeDelegate, new object[] {
            //                orderID,
            //                newSizeID}, this.onEndChangeItemSizeDelegate, this.onChangeItemSizeCompletedDelegate, userState);
            //            }

            //            public Staunch.POS.Classes.DBUser GetUser(string pin)
            //            {
            //                return base.Channel.GetUser(pin);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginGetUser(string pin, System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginGetUser(pin, callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public Staunch.POS.Classes.DBUser EndGetUser(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndGetUser(result);
            //            }

            //            private System.IAsyncResult OnBeginGetUser(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                string pin = ((string)(inValues[0]));
            //                return this.BeginGetUser(pin, callback, asyncState);
            //            }

            //            private object[] OnEndGetUser(System.IAsyncResult result)
            //            {
            //                Staunch.POS.Classes.DBUser retVal = this.EndGetUser(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnGetUserCompleted(object state)
            //            {
            //                if ((this.GetUserCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.GetUserCompleted(this, new GetUserCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void GetUserAsync(string pin)
            //            {
            //                this.GetUserAsync(pin, null);
            //            }

            //            public void GetUserAsync(string pin, object userState)
            //            {
            //                if ((this.onBeginGetUserDelegate == null))
            //                {
            //                    this.onBeginGetUserDelegate = new BeginOperationDelegate(this.OnBeginGetUser);
            //                }
            //                if ((this.onEndGetUserDelegate == null))
            //                {
            //                    this.onEndGetUserDelegate = new EndOperationDelegate(this.OnEndGetUser);
            //                }
            //                if ((this.onGetUserCompletedDelegate == null))
            //                {
            //                    this.onGetUserCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetUserCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginGetUserDelegate, new object[] {
            //                pin}, this.onEndGetUserDelegate, this.onGetUserCompletedDelegate, userState);
            //            }

            //            public bool CancelTakeout(decimal TakeoutGuestID)
            //            {
            //                return base.Channel.CancelTakeout(TakeoutGuestID);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginCancelTakeout(decimal TakeoutGuestID, System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginCancelTakeout(TakeoutGuestID, callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public bool EndCancelTakeout(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndCancelTakeout(result);
            //            }

            //            private System.IAsyncResult OnBeginCancelTakeout(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                decimal TakeoutGuestID = ((decimal)(inValues[0]));
            //                return this.BeginCancelTakeout(TakeoutGuestID, callback, asyncState);
            //            }

            //            private object[] OnEndCancelTakeout(System.IAsyncResult result)
            //            {
            //                bool retVal = this.EndCancelTakeout(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnCancelTakeoutCompleted(object state)
            //            {
            //                if ((this.CancelTakeoutCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.CancelTakeoutCompleted(this, new CancelTakeoutCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void CancelTakeoutAsync(decimal TakeoutGuestID)
            //            {
            //                this.CancelTakeoutAsync(TakeoutGuestID, null);
            //            }

            //            public void CancelTakeoutAsync(decimal TakeoutGuestID, object userState)
            //            {
            //                if ((this.onBeginCancelTakeoutDelegate == null))
            //                {
            //                    this.onBeginCancelTakeoutDelegate = new BeginOperationDelegate(this.OnBeginCancelTakeout);
            //                }
            //                if ((this.onEndCancelTakeoutDelegate == null))
            //                {
            //                    this.onEndCancelTakeoutDelegate = new EndOperationDelegate(this.OnEndCancelTakeout);
            //                }
            //                if ((this.onCancelTakeoutCompletedDelegate == null))
            //                {
            //                    this.onCancelTakeoutCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCancelTakeoutCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginCancelTakeoutDelegate, new object[] {
            //                TakeoutGuestID}, this.onEndCancelTakeoutDelegate, this.onCancelTakeoutCompletedDelegate, userState);
            //            }

            //            public System.Collections.Generic.List<Staunch.POS.Classes.TakeoutOrder> GetLSEOrders()
            //            {
            //                return base.Channel.GetLSEOrders();
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginGetLSEOrders(System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginGetLSEOrders(callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.Collections.Generic.List<Staunch.POS.Classes.TakeoutOrder> EndGetLSEOrders(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndGetLSEOrders(result);
            //            }

            //            private System.IAsyncResult OnBeginGetLSEOrders(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                return this.BeginGetLSEOrders(callback, asyncState);
            //            }

            //            private object[] OnEndGetLSEOrders(System.IAsyncResult result)
            //            {
            //                System.Collections.Generic.List<Staunch.POS.Classes.TakeoutOrder> retVal = this.EndGetLSEOrders(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnGetLSEOrdersCompleted(object state)
            //            {
            //                if ((this.GetLSEOrdersCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.GetLSEOrdersCompleted(this, new GetLSEOrdersCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void GetLSEOrdersAsync()
            //            {
            //                this.GetLSEOrdersAsync(null);
            //            }

            //            public void GetLSEOrdersAsync(object userState)
            //            {
            //                if ((this.onBeginGetLSEOrdersDelegate == null))
            //                {
            //                    this.onBeginGetLSEOrdersDelegate = new BeginOperationDelegate(this.OnBeginGetLSEOrders);
            //                }
            //                if ((this.onEndGetLSEOrdersDelegate == null))
            //                {
            //                    this.onEndGetLSEOrdersDelegate = new EndOperationDelegate(this.OnEndGetLSEOrders);
            //                }
            //                if ((this.onGetLSEOrdersCompletedDelegate == null))
            //                {
            //                    this.onGetLSEOrdersCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetLSEOrdersCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginGetLSEOrdersDelegate, null, this.onEndGetLSEOrdersDelegate, this.onGetLSEOrdersCompletedDelegate, userState);
            //            }

            //            public Staunch.POS.Classes.TakeoutOrder SubmitLSETakeout(Staunch.POS.Classes.TakeoutOrder TakeoutGuest, decimal UserID)
            //            {
            //                return base.Channel.SubmitLSETakeout(TakeoutGuest, UserID);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginSubmitLSETakeout(Staunch.POS.Classes.TakeoutOrder TakeoutGuest, decimal UserID, System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginSubmitLSETakeout(TakeoutGuest, UserID, callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public Staunch.POS.Classes.TakeoutOrder EndSubmitLSETakeout(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndSubmitLSETakeout(result);
            //            }

            //            private System.IAsyncResult OnBeginSubmitLSETakeout(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                Staunch.POS.Classes.TakeoutOrder TakeoutGuest = ((Staunch.POS.Classes.TakeoutOrder)(inValues[0]));
            //                decimal UserID = ((decimal)(inValues[1]));
            //                return this.BeginSubmitLSETakeout(TakeoutGuest, UserID, callback, asyncState);
            //            }

            //            private object[] OnEndSubmitLSETakeout(System.IAsyncResult result)
            //            {
            //                Staunch.POS.Classes.TakeoutOrder retVal = this.EndSubmitLSETakeout(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnSubmitLSETakeoutCompleted(object state)
            //            {
            //                if ((this.SubmitLSETakeoutCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.SubmitLSETakeoutCompleted(this, new SubmitLSETakeoutCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void SubmitLSETakeoutAsync(Staunch.POS.Classes.TakeoutOrder TakeoutGuest, decimal UserID)
            //            {
            //                this.SubmitLSETakeoutAsync(TakeoutGuest, UserID, null);
            //            }

            //            public void SubmitLSETakeoutAsync(Staunch.POS.Classes.TakeoutOrder TakeoutGuest, decimal UserID, object userState)
            //            {
            //                if ((this.onBeginSubmitLSETakeoutDelegate == null))
            //                {
            //                    this.onBeginSubmitLSETakeoutDelegate = new BeginOperationDelegate(this.OnBeginSubmitLSETakeout);
            //                }
            //                if ((this.onEndSubmitLSETakeoutDelegate == null))
            //                {
            //                    this.onEndSubmitLSETakeoutDelegate = new EndOperationDelegate(this.OnEndSubmitLSETakeout);
            //                }
            //                if ((this.onSubmitLSETakeoutCompletedDelegate == null))
            //                {
            //                    this.onSubmitLSETakeoutCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSubmitLSETakeoutCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginSubmitLSETakeoutDelegate, new object[] {
            //                TakeoutGuest,
            //                UserID}, this.onEndSubmitLSETakeoutDelegate, this.onSubmitLSETakeoutCompletedDelegate, userState);
            //            }

            //            public Staunch.POS.Classes.Guest_DB PriceOrder(Staunch.POS.Classes.Guest_DB guest)
            //            {
            //                return base.Channel.PriceOrder(guest);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginPriceOrder(Staunch.POS.Classes.Guest_DB guest, System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginPriceOrder(guest, callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public Staunch.POS.Classes.Guest_DB EndPriceOrder(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndPriceOrder(result);
            //            }

            //            private System.IAsyncResult OnBeginPriceOrder(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                Staunch.POS.Classes.Guest_DB guest = ((Staunch.POS.Classes.Guest_DB)(inValues[0]));
            //                return this.BeginPriceOrder(guest, callback, asyncState);
            //            }

            //            private object[] OnEndPriceOrder(System.IAsyncResult result)
            //            {
            //                Staunch.POS.Classes.Guest_DB retVal = this.EndPriceOrder(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnPriceOrderCompleted(object state)
            //            {
            //                if ((this.PriceOrderCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.PriceOrderCompleted(this, new PriceOrderCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void PriceOrderAsync(Staunch.POS.Classes.Guest_DB guest)
            //            {
            //                this.PriceOrderAsync(guest, null);
            //            }

            //            public void PriceOrderAsync(Staunch.POS.Classes.Guest_DB guest, object userState)
            //            {
            //                if ((this.onBeginPriceOrderDelegate == null))
            //                {
            //                    this.onBeginPriceOrderDelegate = new BeginOperationDelegate(this.OnBeginPriceOrder);
            //                }
            //                if ((this.onEndPriceOrderDelegate == null))
            //                {
            //                    this.onEndPriceOrderDelegate = new EndOperationDelegate(this.OnEndPriceOrder);
            //                }
            //                if ((this.onPriceOrderCompletedDelegate == null))
            //                {
            //                    this.onPriceOrderCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnPriceOrderCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginPriceOrderDelegate, new object[] {
            //                guest}, this.onEndPriceOrderDelegate, this.onPriceOrderCompletedDelegate, userState);
            //            }

            //            public void PrintKitchenNote(string note)
            //            {
            //                base.Channel.PrintKitchenNote(note);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginPrintKitchenNote(string note, System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginPrintKitchenNote(note, callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public void EndPrintKitchenNote(System.IAsyncResult result)
            //            {
            //                base.Channel.EndPrintKitchenNote(result);
            //            }

            //            private System.IAsyncResult OnBeginPrintKitchenNote(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                string note = ((string)(inValues[0]));
            //                return this.BeginPrintKitchenNote(note, callback, asyncState);
            //            }

            //            private object[] OnEndPrintKitchenNote(System.IAsyncResult result)
            //            {
            //                this.EndPrintKitchenNote(result);
            //                return null;
            //            }

            //            private void OnPrintKitchenNoteCompleted(object state)
            //            {
            //                if ((this.PrintKitchenNoteCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.PrintKitchenNoteCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void PrintKitchenNoteAsync(string note)
            //            {
            //                this.PrintKitchenNoteAsync(note, null);
            //            }

            //            public void PrintKitchenNoteAsync(string note, object userState)
            //            {
            //                if ((this.onBeginPrintKitchenNoteDelegate == null))
            //                {
            //                    this.onBeginPrintKitchenNoteDelegate = new BeginOperationDelegate(this.OnBeginPrintKitchenNote);
            //                }
            //                if ((this.onEndPrintKitchenNoteDelegate == null))
            //                {
            //                    this.onEndPrintKitchenNoteDelegate = new EndOperationDelegate(this.OnEndPrintKitchenNote);
            //                }
            //                if ((this.onPrintKitchenNoteCompletedDelegate == null))
            //                {
            //                    this.onPrintKitchenNoteCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnPrintKitchenNoteCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginPrintKitchenNoteDelegate, new object[] {
            //                note}, this.onEndPrintKitchenNoteDelegate, this.onPrintKitchenNoteCompletedDelegate, userState);
            //            }

            //            public bool RemoveOrderFromPlate(decimal OrderID)
            //            {
            //                return base.Channel.RemoveOrderFromPlate(OrderID);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginRemoveOrderFromPlate(decimal OrderID, System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginRemoveOrderFromPlate(OrderID, callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public bool EndRemoveOrderFromPlate(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndRemoveOrderFromPlate(result);
            //            }

            //            private System.IAsyncResult OnBeginRemoveOrderFromPlate(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                decimal OrderID = ((decimal)(inValues[0]));
            //                return this.BeginRemoveOrderFromPlate(OrderID, callback, asyncState);
            //            }

            //            private object[] OnEndRemoveOrderFromPlate(System.IAsyncResult result)
            //            {
            //                bool retVal = this.EndRemoveOrderFromPlate(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnRemoveOrderFromPlateCompleted(object state)
            //            {
            //                if ((this.RemoveOrderFromPlateCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.RemoveOrderFromPlateCompleted(this, new RemoveOrderFromPlateCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void RemoveOrderFromPlateAsync(decimal OrderID)
            //            {
            //                this.RemoveOrderFromPlateAsync(OrderID, null);
            //            }

            //            public void RemoveOrderFromPlateAsync(decimal OrderID, object userState)
            //            {
            //                if ((this.onBeginRemoveOrderFromPlateDelegate == null))
            //                {
            //                    this.onBeginRemoveOrderFromPlateDelegate = new BeginOperationDelegate(this.OnBeginRemoveOrderFromPlate);
            //                }
            //                if ((this.onEndRemoveOrderFromPlateDelegate == null))
            //                {
            //                    this.onEndRemoveOrderFromPlateDelegate = new EndOperationDelegate(this.OnEndRemoveOrderFromPlate);
            //                }
            //                if ((this.onRemoveOrderFromPlateCompletedDelegate == null))
            //                {
            //                    this.onRemoveOrderFromPlateCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnRemoveOrderFromPlateCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginRemoveOrderFromPlateDelegate, new object[] {
            //                OrderID}, this.onEndRemoveOrderFromPlateDelegate, this.onRemoveOrderFromPlateCompletedDelegate, userState);
            //            }

            //            public bool AddOrderToPlate(decimal OrderID, decimal PlateID)
            //            {
            //                return base.Channel.AddOrderToPlate(OrderID, PlateID);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginAddOrderToPlate(decimal OrderID, decimal PlateID, System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginAddOrderToPlate(OrderID, PlateID, callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public bool EndAddOrderToPlate(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndAddOrderToPlate(result);
            //            }

            //            private System.IAsyncResult OnBeginAddOrderToPlate(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                decimal OrderID = ((decimal)(inValues[0]));
            //                decimal PlateID = ((decimal)(inValues[1]));
            //                return this.BeginAddOrderToPlate(OrderID, PlateID, callback, asyncState);
            //            }

            //            private object[] OnEndAddOrderToPlate(System.IAsyncResult result)
            //            {
            //                bool retVal = this.EndAddOrderToPlate(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnAddOrderToPlateCompleted(object state)
            //            {
            //                if ((this.AddOrderToPlateCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.AddOrderToPlateCompleted(this, new AddOrderToPlateCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void AddOrderToPlateAsync(decimal OrderID, decimal PlateID)
            //            {
            //                this.AddOrderToPlateAsync(OrderID, PlateID, null);
            //            }

            //            public void AddOrderToPlateAsync(decimal OrderID, decimal PlateID, object userState)
            //            {
            //                if ((this.onBeginAddOrderToPlateDelegate == null))
            //                {
            //                    this.onBeginAddOrderToPlateDelegate = new BeginOperationDelegate(this.OnBeginAddOrderToPlate);
            //                }
            //                if ((this.onEndAddOrderToPlateDelegate == null))
            //                {
            //                    this.onEndAddOrderToPlateDelegate = new EndOperationDelegate(this.OnEndAddOrderToPlate);
            //                }
            //                if ((this.onAddOrderToPlateCompletedDelegate == null))
            //                {
            //                    this.onAddOrderToPlateCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnAddOrderToPlateCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginAddOrderToPlateDelegate, new object[] {
            //                OrderID,
            //                PlateID}, this.onEndAddOrderToPlateDelegate, this.onAddOrderToPlateCompletedDelegate, userState);
            //            }

            //            public bool AddOrdersToPlate(System.Collections.Generic.List<decimal> orderIds, decimal plateId)
            //            {
            //                return base.Channel.AddOrdersToPlate(orderIds, plateId);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginAddOrdersToPlate(System.Collections.Generic.List<decimal> orderIds, decimal plateId, System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginAddOrdersToPlate(orderIds, plateId, callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public bool EndAddOrdersToPlate(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndAddOrdersToPlate(result);
            //            }

            //            private System.IAsyncResult OnBeginAddOrdersToPlate(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                System.Collections.Generic.List<decimal> orderIds = ((System.Collections.Generic.List<decimal>)(inValues[0]));
            //                decimal plateId = ((decimal)(inValues[1]));
            //                return this.BeginAddOrdersToPlate(orderIds, plateId, callback, asyncState);
            //            }

            //            private object[] OnEndAddOrdersToPlate(System.IAsyncResult result)
            //            {
            //                bool retVal = this.EndAddOrdersToPlate(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnAddOrdersToPlateCompleted(object state)
            //            {
            //                if ((this.AddOrdersToPlateCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.AddOrdersToPlateCompleted(this, new AddOrdersToPlateCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void AddOrdersToPlateAsync(System.Collections.Generic.List<decimal> orderIds, decimal plateId)
            //            {
            //                this.AddOrdersToPlateAsync(orderIds, plateId, null);
            //            }

            //            public void AddOrdersToPlateAsync(System.Collections.Generic.List<decimal> orderIds, decimal plateId, object userState)
            //            {
            //                if ((this.onBeginAddOrdersToPlateDelegate == null))
            //                {
            //                    this.onBeginAddOrdersToPlateDelegate = new BeginOperationDelegate(this.OnBeginAddOrdersToPlate);
            //                }
            //                if ((this.onEndAddOrdersToPlateDelegate == null))
            //                {
            //                    this.onEndAddOrdersToPlateDelegate = new EndOperationDelegate(this.OnEndAddOrdersToPlate);
            //                }
            //                if ((this.onAddOrdersToPlateCompletedDelegate == null))
            //                {
            //                    this.onAddOrdersToPlateCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnAddOrdersToPlateCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginAddOrdersToPlateDelegate, new object[] {
            //                orderIds,
            //                plateId}, this.onEndAddOrdersToPlateDelegate, this.onAddOrdersToPlateCompletedDelegate, userState);
            //            }

            //            public bool RemoveMultipleFromPlate(System.Collections.Generic.List<decimal> orderIDs)
            //            {
            //                return base.Channel.RemoveMultipleFromPlate(orderIDs);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginRemoveMultipleFromPlate(System.Collections.Generic.List<decimal> orderIDs, System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginRemoveMultipleFromPlate(orderIDs, callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public bool EndRemoveMultipleFromPlate(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndRemoveMultipleFromPlate(result);
            //            }

            //            private System.IAsyncResult OnBeginRemoveMultipleFromPlate(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                System.Collections.Generic.List<decimal> orderIDs = ((System.Collections.Generic.List<decimal>)(inValues[0]));
            //                return this.BeginRemoveMultipleFromPlate(orderIDs, callback, asyncState);
            //            }

            //            private object[] OnEndRemoveMultipleFromPlate(System.IAsyncResult result)
            //            {
            //                bool retVal = this.EndRemoveMultipleFromPlate(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnRemoveMultipleFromPlateCompleted(object state)
            //            {
            //                if ((this.RemoveMultipleFromPlateCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.RemoveMultipleFromPlateCompleted(this, new RemoveMultipleFromPlateCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void RemoveMultipleFromPlateAsync(System.Collections.Generic.List<decimal> orderIDs)
            //            {
            //                this.RemoveMultipleFromPlateAsync(orderIDs, null);
            //            }

            //            public void RemoveMultipleFromPlateAsync(System.Collections.Generic.List<decimal> orderIDs, object userState)
            //            {
            //                if ((this.onBeginRemoveMultipleFromPlateDelegate == null))
            //                {
            //                    this.onBeginRemoveMultipleFromPlateDelegate = new BeginOperationDelegate(this.OnBeginRemoveMultipleFromPlate);
            //                }
            //                if ((this.onEndRemoveMultipleFromPlateDelegate == null))
            //                {
            //                    this.onEndRemoveMultipleFromPlateDelegate = new EndOperationDelegate(this.OnEndRemoveMultipleFromPlate);
            //                }
            //                if ((this.onRemoveMultipleFromPlateCompletedDelegate == null))
            //                {
            //                    this.onRemoveMultipleFromPlateCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnRemoveMultipleFromPlateCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginRemoveMultipleFromPlateDelegate, new object[] {
            //                orderIDs}, this.onEndRemoveMultipleFromPlateDelegate, this.onRemoveMultipleFromPlateCompletedDelegate, userState);
            //            }

            //            public Staunch.POS.Classes.CateringOrder SubmitCatering(Staunch.POS.Classes.CateringOrder catering, decimal UserID)
            //            {
            //                return base.Channel.SubmitCatering(catering, UserID);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginSubmitCatering(Staunch.POS.Classes.CateringOrder catering, decimal UserID, System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginSubmitCatering(catering, UserID, callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public Staunch.POS.Classes.CateringOrder EndSubmitCatering(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndSubmitCatering(result);
            //            }

            //            private System.IAsyncResult OnBeginSubmitCatering(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                Staunch.POS.Classes.CateringOrder catering = ((Staunch.POS.Classes.CateringOrder)(inValues[0]));
            //                decimal UserID = ((decimal)(inValues[1]));
            //                return this.BeginSubmitCatering(catering, UserID, callback, asyncState);
            //            }

            //            private object[] OnEndSubmitCatering(System.IAsyncResult result)
            //            {
            //                Staunch.POS.Classes.CateringOrder retVal = this.EndSubmitCatering(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnSubmitCateringCompleted(object state)
            //            {
            //                if ((this.SubmitCateringCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.SubmitCateringCompleted(this, new SubmitCateringCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void SubmitCateringAsync(Staunch.POS.Classes.CateringOrder catering, decimal UserID)
            //            {
            //                this.SubmitCateringAsync(catering, UserID, null);
            //            }

            //            public void SubmitCateringAsync(Staunch.POS.Classes.CateringOrder catering, decimal UserID, object userState)
            //            {
            //                if ((this.onBeginSubmitCateringDelegate == null))
            //                {
            //                    this.onBeginSubmitCateringDelegate = new BeginOperationDelegate(this.OnBeginSubmitCatering);
            //                }
            //                if ((this.onEndSubmitCateringDelegate == null))
            //                {
            //                    this.onEndSubmitCateringDelegate = new EndOperationDelegate(this.OnEndSubmitCatering);
            //                }
            //                if ((this.onSubmitCateringCompletedDelegate == null))
            //                {
            //                    this.onSubmitCateringCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSubmitCateringCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginSubmitCateringDelegate, new object[] {
            //                catering,
            //                UserID}, this.onEndSubmitCateringDelegate, this.onSubmitCateringCompletedDelegate, userState);
            //            }

            //            public System.Collections.Generic.List<Staunch.POS.Classes.TakeoutOrder> GetCateringTakeouts()
            //            {
            //                return base.Channel.GetCateringTakeouts();
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginGetCateringTakeouts(System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginGetCateringTakeouts(callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.Collections.Generic.List<Staunch.POS.Classes.TakeoutOrder> EndGetCateringTakeouts(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndGetCateringTakeouts(result);
            //            }

            //            private System.IAsyncResult OnBeginGetCateringTakeouts(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                return this.BeginGetCateringTakeouts(callback, asyncState);
            //            }

            //            private object[] OnEndGetCateringTakeouts(System.IAsyncResult result)
            //            {
            //                System.Collections.Generic.List<Staunch.POS.Classes.TakeoutOrder> retVal = this.EndGetCateringTakeouts(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnGetCateringTakeoutsCompleted(object state)
            //            {
            //                if ((this.GetCateringTakeoutsCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.GetCateringTakeoutsCompleted(this, new GetCateringTakeoutsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void GetCateringTakeoutsAsync()
            //            {
            //                this.GetCateringTakeoutsAsync(null);
            //            }

            //            public void GetCateringTakeoutsAsync(object userState)
            //            {
            //                if ((this.onBeginGetCateringTakeoutsDelegate == null))
            //                {
            //                    this.onBeginGetCateringTakeoutsDelegate = new BeginOperationDelegate(this.OnBeginGetCateringTakeouts);
            //                }
            //                if ((this.onEndGetCateringTakeoutsDelegate == null))
            //                {
            //                    this.onEndGetCateringTakeoutsDelegate = new EndOperationDelegate(this.OnEndGetCateringTakeouts);
            //                }
            //                if ((this.onGetCateringTakeoutsCompletedDelegate == null))
            //                {
            //                    this.onGetCateringTakeoutsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetCateringTakeoutsCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginGetCateringTakeoutsDelegate, null, this.onEndGetCateringTakeoutsDelegate, this.onGetCateringTakeoutsCompletedDelegate, userState);
            //            }

            //            public Staunch.POS.Classes.CateringOrder GetCateringOrder(decimal TakeoutID)
            //            {
            //                return base.Channel.GetCateringOrder(TakeoutID);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginGetCateringOrder(decimal TakeoutID, System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginGetCateringOrder(TakeoutID, callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public Staunch.POS.Classes.CateringOrder EndGetCateringOrder(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndGetCateringOrder(result);
            //            }

            //            private System.IAsyncResult OnBeginGetCateringOrder(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                decimal TakeoutID = ((decimal)(inValues[0]));
            //                return this.BeginGetCateringOrder(TakeoutID, callback, asyncState);
            //            }

            //            private object[] OnEndGetCateringOrder(System.IAsyncResult result)
            //            {
            //                Staunch.POS.Classes.CateringOrder retVal = this.EndGetCateringOrder(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnGetCateringOrderCompleted(object state)
            //            {
            //                if ((this.GetCateringOrderCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.GetCateringOrderCompleted(this, new GetCateringOrderCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void GetCateringOrderAsync(decimal TakeoutID)
            //            {
            //                this.GetCateringOrderAsync(TakeoutID, null);
            //            }

            //            public void GetCateringOrderAsync(decimal TakeoutID, object userState)
            //            {
            //                if ((this.onBeginGetCateringOrderDelegate == null))
            //                {
            //                    this.onBeginGetCateringOrderDelegate = new BeginOperationDelegate(this.OnBeginGetCateringOrder);
            //                }
            //                if ((this.onEndGetCateringOrderDelegate == null))
            //                {
            //                    this.onEndGetCateringOrderDelegate = new EndOperationDelegate(this.OnEndGetCateringOrder);
            //                }
            //                if ((this.onGetCateringOrderCompletedDelegate == null))
            //                {
            //                    this.onGetCateringOrderCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetCateringOrderCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginGetCateringOrderDelegate, new object[] {
            //                TakeoutID}, this.onEndGetCateringOrderDelegate, this.onGetCateringOrderCompletedDelegate, userState);
            //            }

            //            public System.Collections.Generic.List<Staunch.POS.Classes.CateringOrder> GetAllCateringOrdersInfo()
            //            {
            //                return base.Channel.GetAllCateringOrdersInfo();
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginGetAllCateringOrdersInfo(System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginGetAllCateringOrdersInfo(callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.Collections.Generic.List<Staunch.POS.Classes.CateringOrder> EndGetAllCateringOrdersInfo(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndGetAllCateringOrdersInfo(result);
            //            }

            //            private System.IAsyncResult OnBeginGetAllCateringOrdersInfo(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                return this.BeginGetAllCateringOrdersInfo(callback, asyncState);
            //            }

            //            private object[] OnEndGetAllCateringOrdersInfo(System.IAsyncResult result)
            //            {
            //                System.Collections.Generic.List<Staunch.POS.Classes.CateringOrder> retVal = this.EndGetAllCateringOrdersInfo(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnGetAllCateringOrdersInfoCompleted(object state)
            //            {
            //                if ((this.GetAllCateringOrdersInfoCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.GetAllCateringOrdersInfoCompleted(this, new GetAllCateringOrdersInfoCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void GetAllCateringOrdersInfoAsync()
            //            {
            //                this.GetAllCateringOrdersInfoAsync(null);
            //            }

            //            public void GetAllCateringOrdersInfoAsync(object userState)
            //            {
            //                if ((this.onBeginGetAllCateringOrdersInfoDelegate == null))
            //                {
            //                    this.onBeginGetAllCateringOrdersInfoDelegate = new BeginOperationDelegate(this.OnBeginGetAllCateringOrdersInfo);
            //                }
            //                if ((this.onEndGetAllCateringOrdersInfoDelegate == null))
            //                {
            //                    this.onEndGetAllCateringOrdersInfoDelegate = new EndOperationDelegate(this.OnEndGetAllCateringOrdersInfo);
            //                }
            //                if ((this.onGetAllCateringOrdersInfoCompletedDelegate == null))
            //                {
            //                    this.onGetAllCateringOrdersInfoCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetAllCateringOrdersInfoCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginGetAllCateringOrdersInfoDelegate, null, this.onEndGetAllCateringOrdersInfoDelegate, this.onGetAllCateringOrdersInfoCompletedDelegate, userState);
            //            }

            //            public void SendCateringTakeout(Staunch.POS.Classes.TakeoutOrder TakeoutGuest, decimal UserID)
            //            {
            //                base.Channel.SendCateringTakeout(TakeoutGuest, UserID);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginSendCateringTakeout(Staunch.POS.Classes.TakeoutOrder TakeoutGuest, decimal UserID, System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginSendCateringTakeout(TakeoutGuest, UserID, callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public void EndSendCateringTakeout(System.IAsyncResult result)
            //            {
            //                base.Channel.EndSendCateringTakeout(result);
            //            }

            //            private System.IAsyncResult OnBeginSendCateringTakeout(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                Staunch.POS.Classes.TakeoutOrder TakeoutGuest = ((Staunch.POS.Classes.TakeoutOrder)(inValues[0]));
            //                decimal UserID = ((decimal)(inValues[1]));
            //                return this.BeginSendCateringTakeout(TakeoutGuest, UserID, callback, asyncState);
            //            }

            //            private object[] OnEndSendCateringTakeout(System.IAsyncResult result)
            //            {
            //                this.EndSendCateringTakeout(result);
            //                return null;
            //            }

            //            private void OnSendCateringTakeoutCompleted(object state)
            //            {
            //                if ((this.SendCateringTakeoutCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.SendCateringTakeoutCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void SendCateringTakeoutAsync(Staunch.POS.Classes.TakeoutOrder TakeoutGuest, decimal UserID)
            //            {
            //                this.SendCateringTakeoutAsync(TakeoutGuest, UserID, null);
            //            }

            //            public void SendCateringTakeoutAsync(Staunch.POS.Classes.TakeoutOrder TakeoutGuest, decimal UserID, object userState)
            //            {
            //                if ((this.onBeginSendCateringTakeoutDelegate == null))
            //                {
            //                    this.onBeginSendCateringTakeoutDelegate = new BeginOperationDelegate(this.OnBeginSendCateringTakeout);
            //                }
            //                if ((this.onEndSendCateringTakeoutDelegate == null))
            //                {
            //                    this.onEndSendCateringTakeoutDelegate = new EndOperationDelegate(this.OnEndSendCateringTakeout);
            //                }
            //                if ((this.onSendCateringTakeoutCompletedDelegate == null))
            //                {
            //                    this.onSendCateringTakeoutCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSendCateringTakeoutCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginSendCateringTakeoutDelegate, new object[] {
            //                TakeoutGuest,
            //                UserID}, this.onEndSendCateringTakeoutDelegate, this.onSendCateringTakeoutCompletedDelegate, userState);
            //            }

            //            public System.Collections.Generic.List<Staunch.POS.Classes.DBTable> GetTableSummary()
            //            {
            //                return base.Channel.GetTableSummary();
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginGetTableSummary(System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginGetTableSummary(callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.Collections.Generic.List<Staunch.POS.Classes.DBTable> EndGetTableSummary(System.IAsyncResult result)
            //            {
            //                return base.Channel.EndGetTableSummary(result);
            //            }

            //            private System.IAsyncResult OnBeginGetTableSummary(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                return this.BeginGetTableSummary(callback, asyncState);
            //            }

            //            private object[] OnEndGetTableSummary(System.IAsyncResult result)
            //            {
            //                System.Collections.Generic.List<Staunch.POS.Classes.DBTable> retVal = this.EndGetTableSummary(result);
            //                return new object[] {
            //            retVal};
            //            }

            //            private void OnGetTableSummaryCompleted(object state)
            //            {
            //                if ((this.GetTableSummaryCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.GetTableSummaryCompleted(this, new GetTableSummaryCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void GetTableSummaryAsync()
            //            {
            //                this.GetTableSummaryAsync(null);
            //            }

            //            public void GetTableSummaryAsync(object userState)
            //            {
            //                if ((this.onBeginGetTableSummaryDelegate == null))
            //                {
            //                    this.onBeginGetTableSummaryDelegate = new BeginOperationDelegate(this.OnBeginGetTableSummary);
            //                }
            //                if ((this.onEndGetTableSummaryDelegate == null))
            //                {
            //                    this.onEndGetTableSummaryDelegate = new EndOperationDelegate(this.OnEndGetTableSummary);
            //                }
            //                if ((this.onGetTableSummaryCompletedDelegate == null))
            //                {
            //                    this.onGetTableSummaryCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetTableSummaryCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginGetTableSummaryDelegate, null, this.onEndGetTableSummaryDelegate, this.onGetTableSummaryCompletedDelegate, userState);
            //            }

            //            public void PrintCateringOrder(Staunch.POS.Classes.CateringOrder catering, decimal UserID)
            //            {
            //                base.Channel.PrintCateringOrder(catering, UserID);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public System.IAsyncResult BeginPrintCateringOrder(Staunch.POS.Classes.CateringOrder catering, decimal UserID, System.AsyncCallback callback, object asyncState)
            //            {
            //                return base.Channel.BeginPrintCateringOrder(catering, UserID, callback, asyncState);
            //            }

            //            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            //            public void EndPrintCateringOrder(System.IAsyncResult result)
            //            {
            //                base.Channel.EndPrintCateringOrder(result);
            //            }

            //            private System.IAsyncResult OnBeginPrintCateringOrder(object[] inValues, System.AsyncCallback callback, object asyncState)
            //            {
            //                Staunch.POS.Classes.CateringOrder catering = ((Staunch.POS.Classes.CateringOrder)(inValues[0]));
            //                decimal UserID = ((decimal)(inValues[1]));
            //                return this.BeginPrintCateringOrder(catering, UserID, callback, asyncState);
            //            }

            //            private object[] OnEndPrintCateringOrder(System.IAsyncResult result)
            //            {
            //                this.EndPrintCateringOrder(result);
            //                return null;
            //            }

            //            private void OnPrintCateringOrderCompleted(object state)
            //            {
            //                if ((this.PrintCateringOrderCompleted != null))
            //                {
            //                    InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
            //                    this.PrintCateringOrderCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            //                }
            //            }

            //            public void PrintCateringOrderAsync(Staunch.POS.Classes.CateringOrder catering, decimal UserID)
            //            {
            //                this.PrintCateringOrderAsync(catering, UserID, null);
            //            }

            //            public void PrintCateringOrderAsync(Staunch.POS.Classes.CateringOrder catering, decimal UserID, object userState)
            //            {
            //                if ((this.onBeginPrintCateringOrderDelegate == null))
            //                {
            //                    this.onBeginPrintCateringOrderDelegate = new BeginOperationDelegate(this.OnBeginPrintCateringOrder);
            //                }
            //                if ((this.onEndPrintCateringOrderDelegate == null))
            //                {
            //                    this.onEndPrintCateringOrderDelegate = new EndOperationDelegate(this.OnEndPrintCateringOrder);
            //                }
            //                if ((this.onPrintCateringOrderCompletedDelegate == null))
            //                {
            //                    this.onPrintCateringOrderCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnPrintCateringOrderCompleted);
            //                }
            //                base.InvokeAsync(this.onBeginPrintCateringOrderDelegate, new object[] {
            //                catering,
            //                UserID}, this.onEndPrintCateringOrderDelegate, this.onPrintCateringOrderCompletedDelegate, userState);
            //            }
            //        }
            //    }
            #endregion

        }   //PosServiceClient class
}  //Zipline2.iOS namespace