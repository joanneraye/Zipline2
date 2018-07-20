using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Text;

using Foundation;
using Staunch.POS.Classes;
using Zipline2.ConnectedServices;
using Zipline2.ConnectedServices.PosServiceReference;

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

        public event System.EventHandler<PingCompletedEventArgs> PingCompleted;

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


        #region Methods Implemented

        public DBTable GetTable(int tableNum)
        {
            return Channel.GetTable(tableNum);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public IAsyncResult BeginGetTable(int tableNum, AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetTable(tableNum, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public DBTable EndGetTable(IAsyncResult result)
        {
            return Channel.EndGetTable(result);
        }

       
        public List<DBTable> GetTablesForSection(decimal sectionID)
        {
            return Channel.GetTablesForSection(sectionID);
        }

        
        public System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<Staunch.POS.Classes.DBItem>> GetMenu()
        {
            return Channel.GetMenu();
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public IAsyncResult BeginGetMenu(AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetMenu(callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public Dictionary<string, List<DBItem>> EndGetMenu(IAsyncResult result)
        {
            return Channel.EndGetMenu(result);
        }


        public System.Collections.Generic.List<Staunch.POS.Classes.DBModGroup> GetAllMods(decimal ItemID, decimal SizeID)
        {
            return Channel.GetAllMods(ItemID, SizeID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public IAsyncResult BeginGetAllMods(decimal ItemID, decimal SizeID, AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetAllMods(ItemID, SizeID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public List<DBModGroup> EndGetAllMods(IAsyncResult result)
        {
            return Channel.EndGetAllMods(result);
        }

        public List<DBModGroup> GetModifiers()
        {
            return Channel.GetModifiers();
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public IAsyncResult BeginGetModifiers(AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetModifiers(callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public List<DBModGroup> EndGetModifiers(IAsyncResult result)
        {
            return Channel.EndGetModifiers(result);
        }


        public List<DBTable> GetTableSummary()
        {
            return Channel.GetTableSummary();
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public IAsyncResult BeginGetTableSummary(AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetTableSummary(callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public List<DBTable> EndGetTableSummary(IAsyncResult result)
        {
            return Channel.EndGetTableSummary(result);
        }

        public DBUser ValidateUser(decimal AuthenticationID, string UserName, string Pin)
        {
            return Channel.ValidateUser(AuthenticationID, UserName, Pin);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public IAsyncResult BeginValidateUser(decimal AuthenticationID, string UserName, string Pin, AsyncCallback callback, object asyncState)
        {
            return Channel.BeginValidateUser(AuthenticationID, UserName, Pin, callback, asyncState);

        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public DBUser EndValidateUser(IAsyncResult result)
        {
            return Channel.EndValidateUser(result);
        }

        public List<DBTable> GetTableInfo()
        {
            return Channel.GetTableInfo();
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public IAsyncResult BeginGetTableInfo(AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetTableInfo(callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public List<DBTable> EndGetTableInfo(IAsyncResult result)
        {
            return Channel.EndGetTableInfo(result);
        }

        
        public List<DBTable> FillTables(decimal userID)
        {
            return Channel.FillTables(userID);
        }

        public IAsyncResult BeginFillTables(decimal userID, AsyncCallback callback, object asyncState)
        {
            return Channel.BeginFillTables(userID, callback, asyncState);
        }

        public List<DBTable> EndFillTables(IAsyncResult result)
        {
            return Channel.EndFillTables(result);
        }

        public List<string> GetAvailablePaymentOptions()
        {
            return Channel.GetAvailablePaymentOptions();
        }

        public IAsyncResult BeginGetAvailablePaymentOptions(AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetAvailablePaymentOptions(callback, asyncState);
        }

        public List<string> EndGetAvailablePaymentOptions(IAsyncResult result)
        {
            return Channel.EndGetAvailablePaymentOptions(result);
        }

        public void UpdateTables(List<DBTable> updatedTables, decimal userID)
        {
            Channel.UpdateTables(updatedTables, userID);
        }

        public IAsyncResult BeginUpdateTables(List<DBTable> updatedTables, decimal userID, AsyncCallback callback, object asyncState)
        {
            return Channel.BeginUpdateTables(updatedTables, userID, callback, asyncState);
        }

        public void EndUpdateTables(IAsyncResult result)
        {
            Channel.EndUpdateTables(result);
        }

        public int GetGratuityLimit()
        {
            return Channel.GetGratuityLimit();
        }

        public IAsyncResult BeginGetGratuityLimit(AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetGratuityLimit(callback, asyncState);
        }

        public int EndGetGratuityLimit(IAsyncResult result)
        {
            return Channel.EndGetGratuityLimit(result);
        }

        public decimal GetTaxRate()
        {
            return Channel.GetTaxRate();
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetTaxRate(System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetTaxRate(callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public decimal EndGetTaxRate(System.IAsyncResult result)
        {
            return Channel.EndGetTaxRate(result);
        }
        public decimal GetGratuityRate()
        {
            return Channel.GetGratuityRate();
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetGratuityRate(System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetGratuityRate(callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public decimal EndGetGratuityRate(System.IAsyncResult result)
        {
            return Channel.EndGetGratuityRate(result);
        }
        public bool DoAutoGratuity()
        {
            return Channel.DoAutoGratuity();
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginDoAutoGratuity(System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginDoAutoGratuity(callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndDoAutoGratuity(System.IAsyncResult result)
        {
            return Channel.EndDoAutoGratuity(result);
        }

        public System.Collections.Generic.List<string> GetCategoryNames()
        {
            return Channel.GetCategoryNames();
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetCategoryNames(System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetCategoryNames(callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.Collections.Generic.List<string> EndGetCategoryNames(System.IAsyncResult result)
        {
            return Channel.EndGetCategoryNames(result);
        }

        public System.Collections.Generic.List<decimal> GetNextGuestIDs(int num, decimal userID)
        {
            return Channel.GetNextGuestIDs(num, userID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetNextGuestIDs(int num, decimal userID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetNextGuestIDs(num, userID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.Collections.Generic.List<decimal> EndGetNextGuestIDs(System.IAsyncResult result)
        {
            return Channel.EndGetNextGuestIDs(result);
        }

        public bool RemoveGuest(decimal GuestID, bool RemoveOrder)
        {
            return Channel.RemoveGuest(GuestID, RemoveOrder);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginRemoveGuest(decimal GuestID, bool RemoveOrder, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginRemoveGuest(GuestID, RemoveOrder, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndRemoveGuest(System.IAsyncResult result)
        {
            return Channel.EndRemoveGuest(result);
        }

        public bool RemoveItem(decimal GuestID, decimal OrderID, decimal UserID)
        {
            return Channel.RemoveItem(GuestID, OrderID, UserID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginRemoveItem(decimal GuestID, decimal OrderID, decimal UserID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginRemoveItem(GuestID, OrderID, UserID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndRemoveItem(System.IAsyncResult result)
        {
            return Channel.EndRemoveItem(result);
        }

        public Staunch.POS.Classes.ItemInfo GetItemInfo(decimal ItemID)
        {
            return Channel.GetItemInfo(ItemID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetItemInfo(decimal ItemID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetItemInfo(ItemID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public Staunch.POS.Classes.ItemInfo EndGetItemInfo(System.IAsyncResult result)
        {
            return Channel.EndGetItemInfo(result);
        }

        public System.Collections.Generic.Dictionary<decimal, Staunch.POS.Classes.PictureFile> GetThumbnails(System.Collections.Generic.List<decimal> ItemIDs)
        {
            return Channel.GetThumbnails(ItemIDs);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetThumbnails(System.Collections.Generic.List<decimal> ItemIDs, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetThumbnails(ItemIDs, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.Collections.Generic.Dictionary<decimal, Staunch.POS.Classes.PictureFile> EndGetThumbnails(System.IAsyncResult result)
        {
            return Channel.EndGetThumbnails(result);
        }

        public System.Collections.Generic.List<Staunch.POS.Classes.GuestItem> GetOrders(decimal TableID)
        {
            return Channel.GetOrders(TableID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetOrders(decimal TableID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetOrders(TableID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.Collections.Generic.List<Staunch.POS.Classes.GuestItem> EndGetOrders(System.IAsyncResult result)
        {
            return Channel.EndGetOrders(result);
        }
        public void SendOrders(System.Collections.Generic.List<decimal> OrderIDs, decimal UserID)
        {
            Channel.SendOrders(OrderIDs, UserID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginSendOrders(System.Collections.Generic.List<decimal> OrderIDs, decimal UserID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginSendOrders(OrderIDs, UserID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public void EndSendOrders(System.IAsyncResult result)
        {
            Channel.EndSendOrders(result);
        }

        public void RemoveSentOrder(System.Collections.Generic.List<decimal> OrderIDs, decimal UserID)
        {
            Channel.RemoveSentOrder(OrderIDs, UserID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginRemoveSentOrder(System.Collections.Generic.List<decimal> OrderIDs, decimal UserID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginRemoveSentOrder(OrderIDs, UserID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public void EndRemoveSentOrder(System.IAsyncResult result)
        {
            Channel.EndRemoveSentOrder(result);
        }

        public bool SplitTable(decimal TableID)
        {
            return Channel.SplitTable(TableID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginSplitTable(decimal TableID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginSplitTable(TableID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndSplitTable(System.IAsyncResult result)
        {
            return Channel.EndSplitTable(result);
        }

        public bool HasUnsentOrders(decimal TableID)
        {
            return Channel.HasUnsentOrders(TableID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginHasUnsentOrders(decimal TableID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginHasUnsentOrders(TableID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndHasUnsentOrders(System.IAsyncResult result)
        {
            return Channel.EndHasUnsentOrders(result);
        }

        public bool Logout(decimal UserID)
        {
            return Channel.Logout(UserID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginLogout(decimal UserID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginLogout(UserID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndLogout(System.IAsyncResult result)
        {
            return Channel.EndLogout(result);
        }

        public Staunch.POS.Classes.TakeoutOrder SubmitTakeout(Staunch.POS.Classes.TakeoutOrder TakeoutGuest, decimal UserID)
        {
            return Channel.SubmitTakeout(TakeoutGuest, UserID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginSubmitTakeout(Staunch.POS.Classes.TakeoutOrder TakeoutGuest, decimal UserID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginSubmitTakeout(TakeoutGuest, UserID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public Staunch.POS.Classes.TakeoutOrder EndSubmitTakeout(System.IAsyncResult result)
        {
            return Channel.EndSubmitTakeout(result);
        }


        public System.Collections.Generic.List<Staunch.POS.Classes.TakeoutOrder> GetTakeoutOrders()
        {
            return Channel.GetTakeoutOrders();
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetTakeoutOrders(System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetTakeoutOrders(callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.Collections.Generic.List<Staunch.POS.Classes.TakeoutOrder> EndGetTakeoutOrders(System.IAsyncResult result)
        {
            return Channel.EndGetTakeoutOrders(result);
        }

        public Staunch.POS.Classes.TakeoutOrder GetTakeoutOrder(decimal GuestID, decimal CheckID)
        {
            return Channel.GetTakeoutOrder(GuestID, CheckID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetTakeoutOrder(decimal GuestID, decimal CheckID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetTakeoutOrder(GuestID, CheckID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public Staunch.POS.Classes.TakeoutOrder EndGetTakeoutOrder(System.IAsyncResult result)
        {
            return Channel.EndGetTakeoutOrder(result);
        }

        public void SendTakeout(Staunch.POS.Classes.TakeoutOrder TakeoutGuest, decimal UserID)
        {
            Channel.SendTakeout(TakeoutGuest, UserID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginSendTakeout(Staunch.POS.Classes.TakeoutOrder TakeoutGuest, decimal UserID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginSendTakeout(TakeoutGuest, UserID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public void EndSendTakeout(System.IAsyncResult result)
        {
            Channel.EndSendTakeout(result);
        }

        public bool ClearTakeoutOrder(decimal TakeoutID)
        {
            return Channel.ClearTakeoutOrder(TakeoutID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginClearTakeoutOrder(decimal TakeoutID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginClearTakeoutOrder(TakeoutID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndClearTakeoutOrder(System.IAsyncResult result)
        {
            return Channel.EndClearTakeoutOrder(result);
        }

        public Staunch.POS.Classes.DBUser GetUser(string pin)
        {
            return Channel.GetUser(pin);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetUser(string pin, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetUser(pin, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public Staunch.POS.Classes.DBUser EndGetUser(System.IAsyncResult result)
        {
            return Channel.EndGetUser(result);
        }

        public int Ping(int Delay)
        {
            return Channel.Ping(Delay);
        }



        #endregion

        #region Methods To Implement


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


          
            public IAsyncResult BeginPing(int Delay, AsyncCallback callback, object asyncState)
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

        public int EndPing(IAsyncResult result)
        {
            throw new NotImplementedException();
        }
        #endregion


        private class PosServiceChannel : ChannelBase<IPosService>, IPosService
        {

            public PosServiceChannel(System.ServiceModel.ClientBase<IPosService> client) : base(client)
            {

            }


            public DBTable GetTable(int tableNum)
            {
                object[] _args = new object[1];
                _args[0] = tableNum;
                return (DBTable)base.Invoke("GetTable", _args);
            }

            public IAsyncResult BeginGetTable(int tableNum, AsyncCallback callback, object asyncState)
            {
                object[] _args = new object[1];
                _args[0] = tableNum;
                return (IAsyncResult)base.BeginInvoke("GetTable", _args, callback, asyncState);
            }

            public DBTable EndGetTable(IAsyncResult result)
            {
                object[] _args = new object[0];
                return (DBTable)base.EndInvoke("GetTable", _args, result);
            }


            public System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<Staunch.POS.Classes.DBItem>> GetMenu()
            {
                object[] args = new object[0];
                return (System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<Staunch.POS.Classes.DBItem>>)base.Invoke("GetMenu", args);
            }

            public IAsyncResult BeginGetMenu(AsyncCallback callback, object asyncState)
            {
                object[] args = new object[0];
                return (IAsyncResult)base.BeginInvoke("GetMenu", args, callback, asyncState);
            }

            public Dictionary<string, List<DBItem>> EndGetMenu(IAsyncResult result)
            {
                object[] args = new object[0];
                return (Dictionary<string, List<DBItem>>)base.EndInvoke("GetMenu", args, result);
            }


            public List<DBTable> GetTablesForSection(decimal sectionID)
            {
                object[] args = new object[1];
                args[0] = sectionID;
                return (List<DBTable>)base.Invoke("GetTablesForSection", args);
            }

            public IAsyncResult BeginGetTablesForSection(decimal sectionID, AsyncCallback callback, object asyncState)
            {
                object[] args = new object[1];
                args[0] = sectionID;
                return (IAsyncResult)base.BeginInvoke("GetTablesForSection", args, callback, asyncState);
            }

            public List<DBTable> EndGetTablesForSection(IAsyncResult result)
            {
                object[] args = new object[0];
                return (List<DBTable>)base.EndInvoke("GetMenu", args, result);
            }

            public System.Collections.Generic.List<Staunch.POS.Classes.DBModGroup> GetAllMods(decimal itemId, decimal sizeId)
            {
                object[] args = new object[2];
                args[0] = itemId;
                args[1] = sizeId;
                return (List<DBModGroup>)base.Invoke("GetAllMods", args);
            }

            public IAsyncResult BeginGetAllMods(decimal itemId, decimal sizeId, AsyncCallback callback, object asyncState)
            {
                object[] args = new object[2];
                args[0] = itemId;
                args[1] = sizeId;
                return (IAsyncResult)base.BeginInvoke("GetAllMods", args, callback, asyncState);
            }

            public List<DBModGroup> EndGetAllMods(IAsyncResult result)
            {
                object[] args = new object[0];
                return (List<DBModGroup>)base.EndInvoke("GetAllMods", args, result);
            }

            public List<DBTable> GetTableSummary()
            {
                object[] args = new object[0];
                return (List<DBTable>)base.Invoke("GetTableSummary", args);
            }

            public IAsyncResult BeginGetTableSummary(AsyncCallback callback, object asyncState)
            {
                object[] args = new object[0];
                return (IAsyncResult)base.BeginInvoke("GetTableSummary", args, callback, asyncState);
            }

            public List<DBTable> EndGetTableSummary(IAsyncResult result)
            {
                object[] args = new object[0];
                return (List<DBTable>)base.EndInvoke("GetTableSummary", args, result);
            }


            public DBUser ValidateUser(decimal AuthenticationID, string UserName, string Pin)
            {
                object[] args = new object[2];
                args[0] = UserName;
                args[1] = Pin;
                return (DBUser)base.Invoke("ValidateUser", args);
            }

            public IAsyncResult BeginValidateUser(decimal AuthenticationID, string UserName, string Pin, AsyncCallback callback, object asyncState)
            {
                object[] args = new object[2];
                args[0] = UserName;
                args[1] = Pin;
                return (IAsyncResult)base.BeginInvoke("ValidateUser", args, callback, asyncState);
            }

            public DBUser EndValidateUser(IAsyncResult result)
            {
                object[] args = new object[0];
                return (DBUser)base.EndInvoke("ValidateUser", args, result);
            }

            public List<DBTable> GetTableInfo()
            {
                object[] args = new object[0];
                return (List<DBTable>)base.Invoke("GetTableInfo", null);
            }

            public IAsyncResult BeginGetTableInfo(AsyncCallback callback, object asyncState)
            {
                object[] args = new object[0];
                return (IAsyncResult)base.BeginInvoke("GetTableInfo", args, callback, asyncState);
            }

            public List<DBTable> EndGetTableInfo(IAsyncResult result)
            {
                object[] args = new object[0];
                return (List<DBTable>)base.EndInvoke("GetTableInfo", args, result);
            }

            public void UpdateTables(List<DBTable> updatedTables, decimal userID)
            {
                object[] args = new object[2];
                args[0] = updatedTables;
                args[1] = userID;
                base.Invoke("UpdateTables", args);
            }

            public IAsyncResult BeginUpdateTables(List<DBTable> updatedTables, decimal userID, AsyncCallback callback, object asyncState)
            {
                object[] args = new object[2];
                args[0] = updatedTables;
                args[1] = userID;
                return (IAsyncResult)base.BeginInvoke("UpdateTables", args, callback, asyncState);
            }

            public void EndUpdateTables(IAsyncResult result)
            {
                object[] args = new object[0];
                base.EndInvoke("UpdateTables", args, result);
            }


            public void SendOrders(List<decimal> OrderIDs, decimal UserID)
            {
                object[] args = new object[2];
                args[0] = OrderIDs;
                args[1] = UserID;
                base.Invoke("SendOrders", args);
            }

            public IAsyncResult BeginSendOrders(List<decimal> OrderIDs, decimal UserID, AsyncCallback callback, object asyncState)
            {
                object[] args = new object[2];
                args[0] = OrderIDs;
                args[1] = UserID;
                return (IAsyncResult)base.BeginInvoke("SendOrders", args, callback, asyncState);
            }

            public void EndSendOrders(IAsyncResult result)
            {
                object[] args = new object[0];
                base.EndInvoke("SendOrders", args, result);
            }


            public List<decimal> GetNextGuestIDs(int num, decimal userID)
            {
                object[] args = new object[2];
                args[0] = num;
                args[1] = userID;
                return (List<decimal>)base.Invoke("GetNextGuestIDs", args);
            }



            public IAsyncResult BeginGetNextGuestIDs(int num, decimal userID, AsyncCallback callback, object asyncState)
            {
                object[] args = new object[2];
                args[0] = num;
                args[1] = userID;
                return (IAsyncResult)base.BeginInvoke("GetNextGuestIDs", args, callback, asyncState);
            }

            public List<decimal> EndGetNextGuestIDs(IAsyncResult result)
            {
                object[] args = new object[0];
                return (List<decimal>)base.EndInvoke("GetNextGuestIDs", args, result);
            }

            public DBUser GetUser(string pin)
            {
                object[] args = new object[1];
                args[0] = pin;
                return (DBUser)base.Invoke("GetUser", args);
            }

            public IAsyncResult BeginGetUser(string pin, AsyncCallback callback, object asyncState)
            {
                object[] args = new object[1];
                args[0] = pin;
                return (IAsyncResult)base.BeginInvoke("GetUser", args, callback, asyncState);
            }

            public DBUser EndGetUser(IAsyncResult result)
            {
                object[] args = new object[0];
                return (DBUser)base.EndInvoke("GetUser", args, result);
            }


            public int Ping(int Delay)
            {

                object[] args = new object[1];
                args[0] = Delay;
                return (int)base.Invoke("Ping", args);
            }

            public Guest_DB PriceOrder(Guest_DB guest)
            {
                object[] args = new object[1];
                args[0] = guest;
                return (Guest_DB)base.Invoke("PriceOrder", args);
            }

            public IAsyncResult BeginPriceOrder(Guest_DB guest, AsyncCallback callback, object asyncState)
            {
                object[] args = new object[1];
                args[0] = guest;
                return (IAsyncResult)base.BeginInvoke("PriceOrder", args, callback, asyncState);
            }

            public Guest_DB EndPriceOrder(IAsyncResult result)
            {
                object[] args = new object[0];
                return (Guest_DB)base.EndInvoke("PriceOrder", args, result);
            }


            #region TODO: Implement following....


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
        }  //PosServiceChannel

    }   //PosServiceClient class
}  //Zipline2.iOS namespace