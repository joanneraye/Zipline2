using System;
using System.Collections.Generic;
using System.Text;

namespace Zipline2.ConnectedServices.CheckHostReference
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "ICheckHost")]
    public interface ICheckHost
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/CreateChecks", ReplyAction = "http://tempuri.org/ICheckHost/CreateChecksResponse")]
        string CreateChecks(System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> CheckList, decimal UserID, bool forTakeout);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/CreateChecks", ReplyAction = "http://tempuri.org/ICheckHost/CreateChecksResponse")]
        System.IAsyncResult BeginCreateChecks(System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> CheckList, decimal UserID, bool forTakeout, System.AsyncCallback callback, object asyncState);

        string EndCreateChecks(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/UpdateCheckNotes", ReplyAction = "http://tempuri.org/ICheckHost/UpdateCheckNotesResponse")]
        void UpdateCheckNotes(Staunch.POS.Classes.DBNotes Notes, decimal CheckID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/UpdateCheckNotes", ReplyAction = "http://tempuri.org/ICheckHost/UpdateCheckNotesResponse")]
        System.IAsyncResult BeginUpdateCheckNotes(Staunch.POS.Classes.DBNotes Notes, decimal CheckID, System.AsyncCallback callback, object asyncState);

        void EndUpdateCheckNotes(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/UpdateOrderNotes", ReplyAction = "http://tempuri.org/ICheckHost/UpdateOrderNotesResponse")]
        void UpdateOrderNotes(Staunch.POS.Classes.DBNotes Notes, decimal OrderID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/UpdateOrderNotes", ReplyAction = "http://tempuri.org/ICheckHost/UpdateOrderNotesResponse")]
        System.IAsyncResult BeginUpdateOrderNotes(Staunch.POS.Classes.DBNotes Notes, decimal OrderID, System.AsyncCallback callback, object asyncState);

        void EndUpdateOrderNotes(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/GetOpenChecks", ReplyAction = "http://tempuri.org/ICheckHost/GetOpenChecksResponse")]
        System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> GetOpenChecks(decimal TableID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/GetOpenChecks", ReplyAction = "http://tempuri.org/ICheckHost/GetOpenChecksResponse")]
        System.IAsyncResult BeginGetOpenChecks(decimal TableID, System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> EndGetOpenChecks(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/GetChecksForOrder", ReplyAction = "http://tempuri.org/ICheckHost/GetChecksForOrderResponse")]
        System.Collections.Generic.List<decimal> GetChecksForOrder(decimal OrderID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/GetChecksForOrder", ReplyAction = "http://tempuri.org/ICheckHost/GetChecksForOrderResponse")]
        System.IAsyncResult BeginGetChecksForOrder(decimal OrderID, System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.List<decimal> EndGetChecksForOrder(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/GetCheckCount", ReplyAction = "http://tempuri.org/ICheckHost/GetCheckCountResponse")]
        int GetCheckCount(decimal OrderID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/GetCheckCount", ReplyAction = "http://tempuri.org/ICheckHost/GetCheckCountResponse")]
        System.IAsyncResult BeginGetCheckCount(decimal OrderID, System.AsyncCallback callback, object asyncState);

        int EndGetCheckCount(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/CombineChecks", ReplyAction = "http://tempuri.org/ICheckHost/CombineChecksResponse")]
        bool CombineChecks(decimal CheckID1, decimal CheckID2);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/CombineChecks", ReplyAction = "http://tempuri.org/ICheckHost/CombineChecksResponse")]
        System.IAsyncResult BeginCombineChecks(decimal CheckID1, decimal CheckID2, System.AsyncCallback callback, object asyncState);

        bool EndCombineChecks(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/SplitItem", ReplyAction = "http://tempuri.org/ICheckHost/SplitItemResponse")]
        bool SplitItem(decimal OrderID, System.Collections.Generic.List<decimal> CheckIDs);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/SplitItem", ReplyAction = "http://tempuri.org/ICheckHost/SplitItemResponse")]
        System.IAsyncResult BeginSplitItem(decimal OrderID, System.Collections.Generic.List<decimal> CheckIDs, System.AsyncCallback callback, object asyncState);

        bool EndSplitItem(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/UpdateChecks", ReplyAction = "http://tempuri.org/ICheckHost/UpdateChecksResponse")]
        bool UpdateChecks(System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> Checks, decimal UserID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/UpdateChecks", ReplyAction = "http://tempuri.org/ICheckHost/UpdateChecksResponse")]
        System.IAsyncResult BeginUpdateChecks(System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> Checks, decimal UserID, System.AsyncCallback callback, object asyncState);

        bool EndUpdateChecks(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/MoveItems", ReplyAction = "http://tempuri.org/ICheckHost/MoveItemsResponse")]
        bool MoveItems(System.Collections.Generic.Dictionary<decimal, System.Collections.Generic.List<decimal>> Items, decimal newCheckID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/MoveItems", ReplyAction = "http://tempuri.org/ICheckHost/MoveItemsResponse")]
        System.IAsyncResult BeginMoveItems(System.Collections.Generic.Dictionary<decimal, System.Collections.Generic.List<decimal>> Items, decimal newCheckID, System.AsyncCallback callback, object asyncState);

        bool EndMoveItems(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/HasOpenChecks", ReplyAction = "http://tempuri.org/ICheckHost/HasOpenChecksResponse")]
        bool HasOpenChecks(decimal TableID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/HasOpenChecks", ReplyAction = "http://tempuri.org/ICheckHost/HasOpenChecksResponse")]
        System.IAsyncResult BeginHasOpenChecks(decimal TableID, System.AsyncCallback callback, object asyncState);

        bool EndHasOpenChecks(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/AddPayment", ReplyAction = "http://tempuri.org/ICheckHost/AddPaymentResponse")]
        bool AddPayment(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/AddPayment", ReplyAction = "http://tempuri.org/ICheckHost/AddPaymentResponse")]
        System.IAsyncResult BeginAddPayment(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID, System.AsyncCallback callback, object asyncState);

        bool EndAddPayment(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/AddGratuity", ReplyAction = "http://tempuri.org/ICheckHost/AddGratuityResponse")]
        bool AddGratuity(decimal CheckID, decimal Amount, decimal UserID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/AddGratuity", ReplyAction = "http://tempuri.org/ICheckHost/AddGratuityResponse")]
        System.IAsyncResult BeginAddGratuity(decimal CheckID, decimal Amount, decimal UserID, System.AsyncCallback callback, object asyncState);

        bool EndAddGratuity(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/PrintCheckforMoble", ReplyAction = "http://tempuri.org/ICheckHost/PrintCheckforMobleResponse")]
        bool PrintCheckforMoble(System.Collections.Generic.List<decimal> CheckIDs, decimal UserID, bool isReceipt);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/PrintCheckforMoble", ReplyAction = "http://tempuri.org/ICheckHost/PrintCheckforMobleResponse")]
        System.IAsyncResult BeginPrintCheckforMoble(System.Collections.Generic.List<decimal> CheckIDs, decimal UserID, bool isReceipt, System.AsyncCallback callback, object asyncState);

        bool EndPrintCheckforMoble(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/PrintCheckforRegister", ReplyAction = "http://tempuri.org/ICheckHost/PrintCheckforRegisterResponse")]
        bool PrintCheckforRegister(System.Collections.Generic.List<decimal> CheckIDs, decimal UserID, bool isReceipt, int copies, decimal actionID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/PrintCheckforRegister", ReplyAction = "http://tempuri.org/ICheckHost/PrintCheckforRegisterResponse")]
        System.IAsyncResult BeginPrintCheckforRegister(System.Collections.Generic.List<decimal> CheckIDs, decimal UserID, bool isReceipt, int copies, decimal actionID, System.AsyncCallback callback, object asyncState);

        bool EndPrintCheckforRegister(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/ClearCheck", ReplyAction = "http://tempuri.org/ICheckHost/ClearCheckResponse")]
        bool ClearCheck(decimal CheckID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/ClearCheck", ReplyAction = "http://tempuri.org/ICheckHost/ClearCheckResponse")]
        System.IAsyncResult BeginClearCheck(decimal CheckID, System.AsyncCallback callback, object asyncState);

        bool EndClearCheck(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/GetCheck", ReplyAction = "http://tempuri.org/ICheckHost/GetCheckResponse")]
        Staunch.POS.Classes.DBCheck GetCheck(decimal CheckID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/GetCheck", ReplyAction = "http://tempuri.org/ICheckHost/GetCheckResponse")]
        System.IAsyncResult BeginGetCheck(decimal CheckID, System.AsyncCallback callback, object asyncState);

        Staunch.POS.Classes.DBCheck EndGetCheck(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/removeOrderFromCheck", ReplyAction = "http://tempuri.org/ICheckHost/removeOrderFromCheckResponse")]
        bool removeOrderFromCheck(decimal OrderID, decimal CheckID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/removeOrderFromCheck", ReplyAction = "http://tempuri.org/ICheckHost/removeOrderFromCheckResponse")]
        System.IAsyncResult BeginremoveOrderFromCheck(decimal OrderID, decimal CheckID, System.AsyncCallback callback, object asyncState);

        bool EndremoveOrderFromCheck(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/Ping", ReplyAction = "http://tempuri.org/ICheckHost/PingResponse")]
        int Ping();

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/Ping", ReplyAction = "http://tempuri.org/ICheckHost/PingResponse")]
        System.IAsyncResult BeginPing(System.AsyncCallback callback, object asyncState);

        int EndPing(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/OpenDrawer", ReplyAction = "http://tempuri.org/ICheckHost/OpenDrawerResponse")]
        string OpenDrawer(decimal actionID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/OpenDrawer", ReplyAction = "http://tempuri.org/ICheckHost/OpenDrawerResponse")]
        System.IAsyncResult BeginOpenDrawer(decimal actionID, System.AsyncCallback callback, object asyncState);

        string EndOpenDrawer(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/GetCashDrawerPort", ReplyAction = "http://tempuri.org/ICheckHost/GetCashDrawerPortResponse")]
        string GetCashDrawerPort(decimal ActionID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/GetCashDrawerPort", ReplyAction = "http://tempuri.org/ICheckHost/GetCashDrawerPortResponse")]
        System.IAsyncResult BeginGetCashDrawerPort(decimal ActionID, System.AsyncCallback callback, object asyncState);

        string EndGetCashDrawerPort(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/GetGrossSalesForToday", ReplyAction = "http://tempuri.org/ICheckHost/GetGrossSalesForTodayResponse")]
        System.Collections.Generic.Dictionary<string, decimal> GetGrossSalesForToday();

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/GetGrossSalesForToday", ReplyAction = "http://tempuri.org/ICheckHost/GetGrossSalesForTodayResponse")]
        System.IAsyncResult BeginGetGrossSalesForToday(System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.Dictionary<string, decimal> EndGetGrossSalesForToday(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/GetGrossSalesFor", ReplyAction = "http://tempuri.org/ICheckHost/GetGrossSalesForResponse")]
        System.Collections.Generic.Dictionary<string, decimal> GetGrossSalesFor(System.DateTime Start, System.DateTime End);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/GetGrossSalesFor", ReplyAction = "http://tempuri.org/ICheckHost/GetGrossSalesForResponse")]
        System.IAsyncResult BeginGetGrossSalesFor(System.DateTime Start, System.DateTime End, System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.Dictionary<string, decimal> EndGetGrossSalesFor(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/GetTaxFor", ReplyAction = "http://tempuri.org/ICheckHost/GetTaxForResponse")]
        decimal GetTaxFor(System.DateTime Start, System.DateTime End);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/GetTaxFor", ReplyAction = "http://tempuri.org/ICheckHost/GetTaxForResponse")]
        System.IAsyncResult BeginGetTaxFor(System.DateTime Start, System.DateTime End, System.AsyncCallback callback, object asyncState);

        decimal EndGetTaxFor(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/GetTaxForToday", ReplyAction = "http://tempuri.org/ICheckHost/GetTaxForTodayResponse")]
        decimal GetTaxForToday();

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/GetTaxForToday", ReplyAction = "http://tempuri.org/ICheckHost/GetTaxForTodayResponse")]
        System.IAsyncResult BeginGetTaxForToday(System.AsyncCallback callback, object asyncState);

        decimal EndGetTaxForToday(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/GetGratuityFor", ReplyAction = "http://tempuri.org/ICheckHost/GetGratuityForResponse")]
        decimal GetGratuityFor(System.DateTime Start, System.DateTime End);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/GetGratuityFor", ReplyAction = "http://tempuri.org/ICheckHost/GetGratuityForResponse")]
        System.IAsyncResult BeginGetGratuityFor(System.DateTime Start, System.DateTime End, System.AsyncCallback callback, object asyncState);

        decimal EndGetGratuityFor(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/GetGratuityForToday", ReplyAction = "http://tempuri.org/ICheckHost/GetGratuityForTodayResponse")]
        decimal GetGratuityForToday();

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/GetGratuityForToday", ReplyAction = "http://tempuri.org/ICheckHost/GetGratuityForTodayResponse")]
        System.IAsyncResult BeginGetGratuityForToday(System.AsyncCallback callback, object asyncState);

        decimal EndGetGratuityForToday(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/GetDiscountsFor", ReplyAction = "http://tempuri.org/ICheckHost/GetDiscountsForResponse")]
        decimal GetDiscountsFor(System.DateTime Start, System.DateTime End);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/GetDiscountsFor", ReplyAction = "http://tempuri.org/ICheckHost/GetDiscountsForResponse")]
        System.IAsyncResult BeginGetDiscountsFor(System.DateTime Start, System.DateTime End, System.AsyncCallback callback, object asyncState);

        decimal EndGetDiscountsFor(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/GetChecksWithPayments", ReplyAction = "http://tempuri.org/ICheckHost/GetChecksWithPaymentsResponse")]
        System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> GetChecksWithPayments(System.DateTime start, System.DateTime end);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/GetChecksWithPayments", ReplyAction = "http://tempuri.org/ICheckHost/GetChecksWithPaymentsResponse")]
        System.IAsyncResult BeginGetChecksWithPayments(System.DateTime start, System.DateTime end, System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> EndGetChecksWithPayments(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/PrintZReport", ReplyAction = "http://tempuri.org/ICheckHost/PrintZReportResponse")]
        string PrintZReport(decimal UserID, System.DateTime start, System.DateTime end);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/PrintZReport", ReplyAction = "http://tempuri.org/ICheckHost/PrintZReportResponse")]
        System.IAsyncResult BeginPrintZReport(decimal UserID, System.DateTime start, System.DateTime end, System.AsyncCallback callback, object asyncState);

        string EndPrintZReport(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/GetSalesReport", ReplyAction = "http://tempuri.org/ICheckHost/GetSalesReportResponse")]
        System.Collections.Generic.Dictionary<string, decimal> GetSalesReport(System.DateTime start, System.DateTime end);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/GetSalesReport", ReplyAction = "http://tempuri.org/ICheckHost/GetSalesReportResponse")]
        System.IAsyncResult BeginGetSalesReport(System.DateTime start, System.DateTime end, System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.Dictionary<string, decimal> EndGetSalesReport(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/PrintSalesReport", ReplyAction = "http://tempuri.org/ICheckHost/PrintSalesReportResponse")]
        string PrintSalesReport(decimal UserID, System.DateTime start, System.DateTime end);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/PrintSalesReport", ReplyAction = "http://tempuri.org/ICheckHost/PrintSalesReportResponse")]
        System.IAsyncResult BeginPrintSalesReport(decimal UserID, System.DateTime start, System.DateTime end, System.AsyncCallback callback, object asyncState);

        string EndPrintSalesReport(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/ReopenCheck", ReplyAction = "http://tempuri.org/ICheckHost/ReopenCheckResponse")]
        bool ReopenCheck(decimal CheckID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/ReopenCheck", ReplyAction = "http://tempuri.org/ICheckHost/ReopenCheckResponse")]
        System.IAsyncResult BeginReopenCheck(decimal CheckID, System.AsyncCallback callback, object asyncState);

        bool EndReopenCheck(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/DeleteCheck", ReplyAction = "http://tempuri.org/ICheckHost/DeleteCheckResponse")]
        string DeleteCheck(Staunch.POS.Classes.DBCheck CheckToDelete);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/DeleteCheck", ReplyAction = "http://tempuri.org/ICheckHost/DeleteCheckResponse")]
        System.IAsyncResult BeginDeleteCheck(Staunch.POS.Classes.DBCheck CheckToDelete, System.AsyncCallback callback, object asyncState);

        string EndDeleteCheck(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/RemoveOrderFromClosedCheck", ReplyAction = "http://tempuri.org/ICheckHost/RemoveOrderFromClosedCheckResponse")]
        bool RemoveOrderFromClosedCheck(decimal OrderID, decimal CheckID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/RemoveOrderFromClosedCheck", ReplyAction = "http://tempuri.org/ICheckHost/RemoveOrderFromClosedCheckResponse")]
        System.IAsyncResult BeginRemoveOrderFromClosedCheck(decimal OrderID, decimal CheckID, System.AsyncCallback callback, object asyncState);

        bool EndRemoveOrderFromClosedCheck(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/MoveCheck", ReplyAction = "http://tempuri.org/ICheckHost/MoveCheckResponse")]
        bool MoveCheck(decimal CheckID, decimal NewTableID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/MoveCheck", ReplyAction = "http://tempuri.org/ICheckHost/MoveCheckResponse")]
        System.IAsyncResult BeginMoveCheck(decimal CheckID, decimal NewTableID, System.AsyncCallback callback, object asyncState);

        bool EndMoveCheck(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/ExportReports", ReplyAction = "http://tempuri.org/ICheckHost/ExportReportsResponse")]
        void ExportReports(System.DateTime start, System.DateTime end);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/ExportReports", ReplyAction = "http://tempuri.org/ICheckHost/ExportReportsResponse")]
        System.IAsyncResult BeginExportReports(System.DateTime start, System.DateTime end, System.AsyncCallback callback, object asyncState);

        void EndExportReports(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/UpdateTakeoutCheck", ReplyAction = "http://tempuri.org/ICheckHost/UpdateTakeoutCheckResponse")]
        bool UpdateTakeoutCheck(Staunch.POS.Classes.DBCheck check, decimal UserID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/UpdateTakeoutCheck", ReplyAction = "http://tempuri.org/ICheckHost/UpdateTakeoutCheckResponse")]
        System.IAsyncResult BeginUpdateTakeoutCheck(Staunch.POS.Classes.DBCheck check, decimal UserID, System.AsyncCallback callback, object asyncState);

        bool EndUpdateTakeoutCheck(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/UpdateCheckDiscounts", ReplyAction = "http://tempuri.org/ICheckHost/UpdateCheckDiscountsResponse")]
        string UpdateCheckDiscounts(System.Collections.Generic.List<Staunch.POS.Classes.OrderDiscount> discounts, bool taxable);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/UpdateCheckDiscounts", ReplyAction = "http://tempuri.org/ICheckHost/UpdateCheckDiscountsResponse")]
        System.IAsyncResult BeginUpdateCheckDiscounts(System.Collections.Generic.List<Staunch.POS.Classes.OrderDiscount> discounts, bool taxable, System.AsyncCallback callback, object asyncState);

        string EndUpdateCheckDiscounts(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/Checkout", ReplyAction = "http://tempuri.org/ICheckHost/CheckoutResponse")]
        string Checkout(decimal checkId, System.Collections.Generic.List<decimal> guestIds, decimal tableId);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/Checkout", ReplyAction = "http://tempuri.org/ICheckHost/CheckoutResponse")]
        System.IAsyncResult BeginCheckout(decimal checkId, System.Collections.Generic.List<decimal> guestIds, decimal tableId, System.AsyncCallback callback, object asyncState);

        string EndCheckout(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/GetReportForDates", ReplyAction = "http://tempuri.org/ICheckHost/GetReportForDatesResponse")]
        System.Collections.Generic.List<System.Collections.Generic.List<string>> GetReportForDates(System.DateTime start, System.DateTime end);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/GetReportForDates", ReplyAction = "http://tempuri.org/ICheckHost/GetReportForDatesResponse")]
        System.IAsyncResult BeginGetReportForDates(System.DateTime start, System.DateTime end, System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.List<System.Collections.Generic.List<string>> EndGetReportForDates(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/RemoveTax", ReplyAction = "http://tempuri.org/ICheckHost/RemoveTaxResponse")]
        string RemoveTax(decimal CheckID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/RemoveTax", ReplyAction = "http://tempuri.org/ICheckHost/RemoveTaxResponse")]
        System.IAsyncResult BeginRemoveTax(decimal CheckID, System.AsyncCallback callback, object asyncState);

        string EndRemoveTax(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/CreateLSEChecks", ReplyAction = "http://tempuri.org/ICheckHost/CreateLSEChecksResponse")]
        System.Collections.Generic.List<decimal> CreateLSEChecks(System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> CheckList, decimal UserID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/CreateLSEChecks", ReplyAction = "http://tempuri.org/ICheckHost/CreateLSEChecksResponse")]
        System.IAsyncResult BeginCreateLSEChecks(System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> CheckList, decimal UserID, System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.List<decimal> EndCreateLSEChecks(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/AddLSEPayment", ReplyAction = "http://tempuri.org/ICheckHost/AddLSEPaymentResponse")]
        bool AddLSEPayment(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/AddLSEPayment", ReplyAction = "http://tempuri.org/ICheckHost/AddLSEPaymentResponse")]
        System.IAsyncResult BeginAddLSEPayment(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID, System.AsyncCallback callback, object asyncState);

        bool EndAddLSEPayment(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/GetLSEReportForDates", ReplyAction = "http://tempuri.org/ICheckHost/GetLSEReportForDatesResponse")]
        System.Collections.Generic.List<System.Collections.Generic.List<string>> GetLSEReportForDates(System.DateTime start, System.DateTime end);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/GetLSEReportForDates", ReplyAction = "http://tempuri.org/ICheckHost/GetLSEReportForDatesResponse")]
        System.IAsyncResult BeginGetLSEReportForDates(System.DateTime start, System.DateTime end, System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.List<System.Collections.Generic.List<string>> EndGetLSEReportForDates(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/GetLSEChecksWithPayments", ReplyAction = "http://tempuri.org/ICheckHost/GetLSEChecksWithPaymentsResponse")]
        System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> GetLSEChecksWithPayments(System.DateTime start, System.DateTime end);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/GetLSEChecksWithPayments", ReplyAction = "http://tempuri.org/ICheckHost/GetLSEChecksWithPaymentsResponse")]
        System.IAsyncResult BeginGetLSEChecksWithPayments(System.DateTime start, System.DateTime end, System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> EndGetLSEChecksWithPayments(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/UpdateCheckOrderItem", ReplyAction = "http://tempuri.org/ICheckHost/UpdateCheckOrderItemResponse")]
        string UpdateCheckOrderItem(Staunch.POS.Classes.GuestItem order);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/UpdateCheckOrderItem", ReplyAction = "http://tempuri.org/ICheckHost/UpdateCheckOrderItemResponse")]
        System.IAsyncResult BeginUpdateCheckOrderItem(Staunch.POS.Classes.GuestItem order, System.AsyncCallback callback, object asyncState);

        string EndUpdateCheckOrderItem(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/InsertVoid", ReplyAction = "http://tempuri.org/ICheckHost/InsertVoidResponse")]
        string InsertVoid(decimal checkID, string user, string manager, string reason);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/InsertVoid", ReplyAction = "http://tempuri.org/ICheckHost/InsertVoidResponse")]
        System.IAsyncResult BeginInsertVoid(decimal checkID, string user, string manager, string reason, System.AsyncCallback callback, object asyncState);

        string EndInsertVoid(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/GetVoidsForDates", ReplyAction = "http://tempuri.org/ICheckHost/GetVoidsForDatesResponse")]
        System.Collections.Generic.List<string> GetVoidsForDates(System.DateTime start, System.DateTime end);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/GetVoidsForDates", ReplyAction = "http://tempuri.org/ICheckHost/GetVoidsForDatesResponse")]
        System.IAsyncResult BeginGetVoidsForDates(System.DateTime start, System.DateTime end, System.AsyncCallback callback, object asyncState);

        System.Collections.Generic.List<string> EndGetVoidsForDates(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/AddCreditPayment", ReplyAction = "http://tempuri.org/ICheckHost/AddCreditPaymentResponse")]
        string AddCreditPayment(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/AddCreditPayment", ReplyAction = "http://tempuri.org/ICheckHost/AddCreditPaymentResponse")]
        System.IAsyncResult BeginAddCreditPayment(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID, System.AsyncCallback callback, object asyncState);

        string EndAddCreditPayment(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/PrintCateringReceipt", ReplyAction = "http://tempuri.org/ICheckHost/PrintCateringReceiptResponse")]
        void PrintCateringReceipt(int CateringID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/PrintCateringReceipt", ReplyAction = "http://tempuri.org/ICheckHost/PrintCateringReceiptResponse")]
        System.IAsyncResult BeginPrintCateringReceipt(int CateringID, System.AsyncCallback callback, object asyncState);

        void EndPrintCateringReceipt(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/ClearDiscounts", ReplyAction = "http://tempuri.org/ICheckHost/ClearDiscountsResponse")]
        bool ClearDiscounts(decimal CheckID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/ClearDiscounts", ReplyAction = "http://tempuri.org/ICheckHost/ClearDiscountsResponse")]
        System.IAsyncResult BeginClearDiscounts(decimal CheckID, System.AsyncCallback callback, object asyncState);

        bool EndClearDiscounts(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/AddCateringPayment", ReplyAction = "http://tempuri.org/ICheckHost/AddCateringPaymentResponse")]
        bool AddCateringPayment(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/AddCateringPayment", ReplyAction = "http://tempuri.org/ICheckHost/AddCateringPaymentResponse")]
        System.IAsyncResult BeginAddCateringPayment(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID, System.AsyncCallback callback, object asyncState);

        bool EndAddCateringPayment(System.IAsyncResult result);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICheckHost/PriceOrder", ReplyAction = "http://tempuri.org/ICheckHost/PriceOrderResponse")]
        Staunch.POS.Classes.GuestItem PriceOrder(Staunch.POS.Classes.GuestItem item);

        [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/ICheckHost/PriceOrder", ReplyAction = "http://tempuri.org/ICheckHost/PriceOrderResponse")]
        System.IAsyncResult BeginPriceOrder(Staunch.POS.Classes.GuestItem item, System.AsyncCallback callback, object asyncState);

        Staunch.POS.Classes.GuestItem EndPriceOrder(System.IAsyncResult result);
    }
}
