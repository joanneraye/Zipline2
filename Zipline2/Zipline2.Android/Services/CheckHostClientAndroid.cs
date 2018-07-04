using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Staunch.POS.Classes;
using Zipline2.ConnectedServices;
using Zipline2.ConnectedServices.CheckHostReference;

namespace Zipline2.Android.Services
{
    public class CheckHostClientAndroid : System.ServiceModel.ClientBase<ICheckHost>, ICheckHost
    {
        //Constructors
        public CheckHostClientAndroid()
        {
        }

        public CheckHostClientAndroid(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public CheckHostClientAndroid(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public CheckHostClientAndroid(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public CheckHostClientAndroid(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        //This is the critical part that makes connnecting with WCF service via iOS possible.
        protected override ICheckHost CreateChannel()
        {
            return new CheckHostChannel(this);
        }


        #region Methods
        public string CreateChecks(System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> CheckList, decimal UserID, bool forTakeout)
        {
            return Channel.CreateChecks(CheckList, UserID, forTakeout);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginCreateChecks(System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> CheckList, decimal UserID, bool forTakeout, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginCreateChecks(CheckList, UserID, forTakeout, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string EndCreateChecks(System.IAsyncResult result)
        {
            return Channel.EndCreateChecks(result);
        }

        private System.IAsyncResult OnBeginCreateChecks(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> CheckList = ((System.Collections.Generic.List<Staunch.POS.Classes.DBCheck>)(inValues[0]));
            decimal UserID = ((decimal)(inValues[1]));
            bool forTakeout = ((bool)(inValues[2]));
            return this.BeginCreateChecks(CheckList, UserID, forTakeout, callback, asyncState);
        }

        private object[] OnEndCreateChecks(System.IAsyncResult result)
        {
            string retVal = this.EndCreateChecks(result);
            return new object[] {
                retVal};
        }

        private void OnCreateChecksCompleted(object state)
        {
            if ((this.CreateChecksCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CreateChecksCompleted(this, new CreateChecksCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void CreateChecksAsync(System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> CheckList, decimal UserID, bool forTakeout)
        {
            this.CreateChecksAsync(CheckList, UserID, forTakeout, null);
        }

        public void CreateChecksAsync(System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> CheckList, decimal UserID, bool forTakeout, object userState)
        {
            if ((this.onBeginCreateChecksDelegate == null))
            {
                this.onBeginCreateChecksDelegate = new BeginOperationDelegate(this.OnBeginCreateChecks);
            }
            if ((this.onEndCreateChecksDelegate == null))
            {
                this.onEndCreateChecksDelegate = new EndOperationDelegate(this.OnEndCreateChecks);
            }
            if ((this.onCreateChecksCompletedDelegate == null))
            {
                this.onCreateChecksCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCreateChecksCompleted);
            }
            base.InvokeAsync(this.onBeginCreateChecksDelegate, new object[] {
                    CheckList,
                    UserID,
                    forTakeout}, this.onEndCreateChecksDelegate, this.onCreateChecksCompletedDelegate, userState);
        }

        public void UpdateCheckNotes(Staunch.POS.Classes.DBNotes Notes, decimal CheckID)
        {
            Channel.UpdateCheckNotes(Notes, CheckID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginUpdateCheckNotes(Staunch.POS.Classes.DBNotes Notes, decimal CheckID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginUpdateCheckNotes(Notes, CheckID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public void EndUpdateCheckNotes(System.IAsyncResult result)
        {
            Channel.EndUpdateCheckNotes(result);
        }

        private System.IAsyncResult OnBeginUpdateCheckNotes(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            Staunch.POS.Classes.DBNotes Notes = ((Staunch.POS.Classes.DBNotes)(inValues[0]));
            decimal CheckID = ((decimal)(inValues[1]));
            return this.BeginUpdateCheckNotes(Notes, CheckID, callback, asyncState);
        }

        private object[] OnEndUpdateCheckNotes(System.IAsyncResult result)
        {
            this.EndUpdateCheckNotes(result);
            return null;
        }

        private void OnUpdateCheckNotesCompleted(object state)
        {
            if ((this.UpdateCheckNotesCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.UpdateCheckNotesCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }

        public void UpdateCheckNotesAsync(Staunch.POS.Classes.DBNotes Notes, decimal CheckID)
        {
            this.UpdateCheckNotesAsync(Notes, CheckID, null);
        }

        public void UpdateCheckNotesAsync(Staunch.POS.Classes.DBNotes Notes, decimal CheckID, object userState)
        {
            if ((this.onBeginUpdateCheckNotesDelegate == null))
            {
                this.onBeginUpdateCheckNotesDelegate = new BeginOperationDelegate(this.OnBeginUpdateCheckNotes);
            }
            if ((this.onEndUpdateCheckNotesDelegate == null))
            {
                this.onEndUpdateCheckNotesDelegate = new EndOperationDelegate(this.OnEndUpdateCheckNotes);
            }
            if ((this.onUpdateCheckNotesCompletedDelegate == null))
            {
                this.onUpdateCheckNotesCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnUpdateCheckNotesCompleted);
            }
            base.InvokeAsync(this.onBeginUpdateCheckNotesDelegate, new object[] {
                    Notes,
                    CheckID}, this.onEndUpdateCheckNotesDelegate, this.onUpdateCheckNotesCompletedDelegate, userState);
        }

        public void UpdateOrderNotes(Staunch.POS.Classes.DBNotes Notes, decimal OrderID)
        {
            Channel.UpdateOrderNotes(Notes, OrderID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginUpdateOrderNotes(Staunch.POS.Classes.DBNotes Notes, decimal OrderID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginUpdateOrderNotes(Notes, OrderID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public void EndUpdateOrderNotes(System.IAsyncResult result)
        {
            Channel.EndUpdateOrderNotes(result);
        }

        private System.IAsyncResult OnBeginUpdateOrderNotes(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            Staunch.POS.Classes.DBNotes Notes = ((Staunch.POS.Classes.DBNotes)(inValues[0]));
            decimal OrderID = ((decimal)(inValues[1]));
            return this.BeginUpdateOrderNotes(Notes, OrderID, callback, asyncState);
        }

        private object[] OnEndUpdateOrderNotes(System.IAsyncResult result)
        {
            this.EndUpdateOrderNotes(result);
            return null;
        }

        private void OnUpdateOrderNotesCompleted(object state)
        {
            if ((this.UpdateOrderNotesCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.UpdateOrderNotesCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }

        public void UpdateOrderNotesAsync(Staunch.POS.Classes.DBNotes Notes, decimal OrderID)
        {
            this.UpdateOrderNotesAsync(Notes, OrderID, null);
        }

        public void UpdateOrderNotesAsync(Staunch.POS.Classes.DBNotes Notes, decimal OrderID, object userState)
        {
            if ((this.onBeginUpdateOrderNotesDelegate == null))
            {
                this.onBeginUpdateOrderNotesDelegate = new BeginOperationDelegate(this.OnBeginUpdateOrderNotes);
            }
            if ((this.onEndUpdateOrderNotesDelegate == null))
            {
                this.onEndUpdateOrderNotesDelegate = new EndOperationDelegate(this.OnEndUpdateOrderNotes);
            }
            if ((this.onUpdateOrderNotesCompletedDelegate == null))
            {
                this.onUpdateOrderNotesCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnUpdateOrderNotesCompleted);
            }
            base.InvokeAsync(this.onBeginUpdateOrderNotesDelegate, new object[] {
                    Notes,
                    OrderID}, this.onEndUpdateOrderNotesDelegate, this.onUpdateOrderNotesCompletedDelegate, userState);
        }

        public System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> GetOpenChecks(decimal TableID)
        {
            return Channel.GetOpenChecks(TableID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetOpenChecks(decimal TableID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetOpenChecks(TableID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> EndGetOpenChecks(System.IAsyncResult result)
        {
            return Channel.EndGetOpenChecks(result);
        }

        private System.IAsyncResult OnBeginGetOpenChecks(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            decimal TableID = ((decimal)(inValues[0]));
            return this.BeginGetOpenChecks(TableID, callback, asyncState);
        }

        private object[] OnEndGetOpenChecks(System.IAsyncResult result)
        {
            System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> retVal = this.EndGetOpenChecks(result);
            return new object[] {
                retVal};
        }

        private void OnGetOpenChecksCompleted(object state)
        {
            if ((this.GetOpenChecksCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetOpenChecksCompleted(this, new GetOpenChecksCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void GetOpenChecksAsync(decimal TableID)
        {
            this.GetOpenChecksAsync(TableID, null);
        }

        public void GetOpenChecksAsync(decimal TableID, object userState)
        {
            if ((this.onBeginGetOpenChecksDelegate == null))
            {
                this.onBeginGetOpenChecksDelegate = new BeginOperationDelegate(this.OnBeginGetOpenChecks);
            }
            if ((this.onEndGetOpenChecksDelegate == null))
            {
                this.onEndGetOpenChecksDelegate = new EndOperationDelegate(this.OnEndGetOpenChecks);
            }
            if ((this.onGetOpenChecksCompletedDelegate == null))
            {
                this.onGetOpenChecksCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetOpenChecksCompleted);
            }
            base.InvokeAsync(this.onBeginGetOpenChecksDelegate, new object[] {
                    TableID}, this.onEndGetOpenChecksDelegate, this.onGetOpenChecksCompletedDelegate, userState);
        }

        public System.Collections.Generic.List<decimal> GetChecksForOrder(decimal OrderID)
        {
            return Channel.GetChecksForOrder(OrderID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetChecksForOrder(decimal OrderID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetChecksForOrder(OrderID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.Collections.Generic.List<decimal> EndGetChecksForOrder(System.IAsyncResult result)
        {
            return Channel.EndGetChecksForOrder(result);
        }

        private System.IAsyncResult OnBeginGetChecksForOrder(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            decimal OrderID = ((decimal)(inValues[0]));
            return this.BeginGetChecksForOrder(OrderID, callback, asyncState);
        }

        private object[] OnEndGetChecksForOrder(System.IAsyncResult result)
        {
            System.Collections.Generic.List<decimal> retVal = this.EndGetChecksForOrder(result);
            return new object[] {
                retVal};
        }

        private void OnGetChecksForOrderCompleted(object state)
        {
            if ((this.GetChecksForOrderCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetChecksForOrderCompleted(this, new GetChecksForOrderCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void GetChecksForOrderAsync(decimal OrderID)
        {
            this.GetChecksForOrderAsync(OrderID, null);
        }

        public void GetChecksForOrderAsync(decimal OrderID, object userState)
        {
            if ((this.onBeginGetChecksForOrderDelegate == null))
            {
                this.onBeginGetChecksForOrderDelegate = new BeginOperationDelegate(this.OnBeginGetChecksForOrder);
            }
            if ((this.onEndGetChecksForOrderDelegate == null))
            {
                this.onEndGetChecksForOrderDelegate = new EndOperationDelegate(this.OnEndGetChecksForOrder);
            }
            if ((this.onGetChecksForOrderCompletedDelegate == null))
            {
                this.onGetChecksForOrderCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetChecksForOrderCompleted);
            }
            base.InvokeAsync(this.onBeginGetChecksForOrderDelegate, new object[] {
                    OrderID}, this.onEndGetChecksForOrderDelegate, this.onGetChecksForOrderCompletedDelegate, userState);
        }

        public int GetCheckCount(decimal OrderID)
        {
            return Channel.GetCheckCount(OrderID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetCheckCount(decimal OrderID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetCheckCount(OrderID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public int EndGetCheckCount(System.IAsyncResult result)
        {
            return Channel.EndGetCheckCount(result);
        }

        private System.IAsyncResult OnBeginGetCheckCount(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            decimal OrderID = ((decimal)(inValues[0]));
            return this.BeginGetCheckCount(OrderID, callback, asyncState);
        }

        private object[] OnEndGetCheckCount(System.IAsyncResult result)
        {
            int retVal = this.EndGetCheckCount(result);
            return new object[] {
                retVal};
        }

        private void OnGetCheckCountCompleted(object state)
        {
            if ((this.GetCheckCountCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetCheckCountCompleted(this, new GetCheckCountCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void GetCheckCountAsync(decimal OrderID)
        {
            this.GetCheckCountAsync(OrderID, null);
        }

        public void GetCheckCountAsync(decimal OrderID, object userState)
        {
            if ((this.onBeginGetCheckCountDelegate == null))
            {
                this.onBeginGetCheckCountDelegate = new BeginOperationDelegate(this.OnBeginGetCheckCount);
            }
            if ((this.onEndGetCheckCountDelegate == null))
            {
                this.onEndGetCheckCountDelegate = new EndOperationDelegate(this.OnEndGetCheckCount);
            }
            if ((this.onGetCheckCountCompletedDelegate == null))
            {
                this.onGetCheckCountCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetCheckCountCompleted);
            }
            base.InvokeAsync(this.onBeginGetCheckCountDelegate, new object[] {
                    OrderID}, this.onEndGetCheckCountDelegate, this.onGetCheckCountCompletedDelegate, userState);
        }

        public bool CombineChecks(decimal CheckID1, decimal CheckID2)
        {
            return Channel.CombineChecks(CheckID1, CheckID2);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginCombineChecks(decimal CheckID1, decimal CheckID2, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginCombineChecks(CheckID1, CheckID2, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndCombineChecks(System.IAsyncResult result)
        {
            return Channel.EndCombineChecks(result);
        }

        private System.IAsyncResult OnBeginCombineChecks(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            decimal CheckID1 = ((decimal)(inValues[0]));
            decimal CheckID2 = ((decimal)(inValues[1]));
            return this.BeginCombineChecks(CheckID1, CheckID2, callback, asyncState);
        }

        private object[] OnEndCombineChecks(System.IAsyncResult result)
        {
            bool retVal = this.EndCombineChecks(result);
            return new object[] {
                retVal};
        }

        private void OnCombineChecksCompleted(object state)
        {
            if ((this.CombineChecksCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CombineChecksCompleted(this, new CombineChecksCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void CombineChecksAsync(decimal CheckID1, decimal CheckID2)
        {
            this.CombineChecksAsync(CheckID1, CheckID2, null);
        }

        public void CombineChecksAsync(decimal CheckID1, decimal CheckID2, object userState)
        {
            if ((this.onBeginCombineChecksDelegate == null))
            {
                this.onBeginCombineChecksDelegate = new BeginOperationDelegate(this.OnBeginCombineChecks);
            }
            if ((this.onEndCombineChecksDelegate == null))
            {
                this.onEndCombineChecksDelegate = new EndOperationDelegate(this.OnEndCombineChecks);
            }
            if ((this.onCombineChecksCompletedDelegate == null))
            {
                this.onCombineChecksCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCombineChecksCompleted);
            }
            base.InvokeAsync(this.onBeginCombineChecksDelegate, new object[] {
                    CheckID1,
                    CheckID2}, this.onEndCombineChecksDelegate, this.onCombineChecksCompletedDelegate, userState);
        }

        public bool SplitItem(decimal OrderID, System.Collections.Generic.List<decimal> CheckIDs)
        {
            return Channel.SplitItem(OrderID, CheckIDs);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginSplitItem(decimal OrderID, System.Collections.Generic.List<decimal> CheckIDs, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginSplitItem(OrderID, CheckIDs, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndSplitItem(System.IAsyncResult result)
        {
            return Channel.EndSplitItem(result);
        }

        private System.IAsyncResult OnBeginSplitItem(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            decimal OrderID = ((decimal)(inValues[0]));
            System.Collections.Generic.List<decimal> CheckIDs = ((System.Collections.Generic.List<decimal>)(inValues[1]));
            return this.BeginSplitItem(OrderID, CheckIDs, callback, asyncState);
        }

        private object[] OnEndSplitItem(System.IAsyncResult result)
        {
            bool retVal = this.EndSplitItem(result);
            return new object[] {
                retVal};
        }

        private void OnSplitItemCompleted(object state)
        {
            if ((this.SplitItemCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SplitItemCompleted(this, new SplitItemCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void SplitItemAsync(decimal OrderID, System.Collections.Generic.List<decimal> CheckIDs)
        {
            this.SplitItemAsync(OrderID, CheckIDs, null);
        }

        public void SplitItemAsync(decimal OrderID, System.Collections.Generic.List<decimal> CheckIDs, object userState)
        {
            if ((this.onBeginSplitItemDelegate == null))
            {
                this.onBeginSplitItemDelegate = new BeginOperationDelegate(this.OnBeginSplitItem);
            }
            if ((this.onEndSplitItemDelegate == null))
            {
                this.onEndSplitItemDelegate = new EndOperationDelegate(this.OnEndSplitItem);
            }
            if ((this.onSplitItemCompletedDelegate == null))
            {
                this.onSplitItemCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSplitItemCompleted);
            }
            base.InvokeAsync(this.onBeginSplitItemDelegate, new object[] {
                    OrderID,
                    CheckIDs}, this.onEndSplitItemDelegate, this.onSplitItemCompletedDelegate, userState);
        }

        public bool UpdateChecks(System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> Checks, decimal UserID)
        {
            return Channel.UpdateChecks(Checks, UserID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginUpdateChecks(System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> Checks, decimal UserID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginUpdateChecks(Checks, UserID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndUpdateChecks(System.IAsyncResult result)
        {
            return Channel.EndUpdateChecks(result);
        }

        private System.IAsyncResult OnBeginUpdateChecks(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> Checks = ((System.Collections.Generic.List<Staunch.POS.Classes.DBCheck>)(inValues[0]));
            decimal UserID = ((decimal)(inValues[1]));
            return this.BeginUpdateChecks(Checks, UserID, callback, asyncState);
        }

        private object[] OnEndUpdateChecks(System.IAsyncResult result)
        {
            bool retVal = this.EndUpdateChecks(result);
            return new object[] {
                retVal};
        }

        private void OnUpdateChecksCompleted(object state)
        {
            if ((this.UpdateChecksCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.UpdateChecksCompleted(this, new UpdateChecksCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void UpdateChecksAsync(System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> Checks, decimal UserID)
        {
            this.UpdateChecksAsync(Checks, UserID, null);
        }

        public void UpdateChecksAsync(System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> Checks, decimal UserID, object userState)
        {
            if ((this.onBeginUpdateChecksDelegate == null))
            {
                this.onBeginUpdateChecksDelegate = new BeginOperationDelegate(this.OnBeginUpdateChecks);
            }
            if ((this.onEndUpdateChecksDelegate == null))
            {
                this.onEndUpdateChecksDelegate = new EndOperationDelegate(this.OnEndUpdateChecks);
            }
            if ((this.onUpdateChecksCompletedDelegate == null))
            {
                this.onUpdateChecksCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnUpdateChecksCompleted);
            }
            base.InvokeAsync(this.onBeginUpdateChecksDelegate, new object[] {
                    Checks,
                    UserID}, this.onEndUpdateChecksDelegate, this.onUpdateChecksCompletedDelegate, userState);
        }

        public bool MoveItems(System.Collections.Generic.Dictionary<decimal, System.Collections.Generic.List<decimal>> Items, decimal newCheckID)
        {
            return Channel.MoveItems(Items, newCheckID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginMoveItems(System.Collections.Generic.Dictionary<decimal, System.Collections.Generic.List<decimal>> Items, decimal newCheckID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginMoveItems(Items, newCheckID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndMoveItems(System.IAsyncResult result)
        {
            return Channel.EndMoveItems(result);
        }

        private System.IAsyncResult OnBeginMoveItems(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            System.Collections.Generic.Dictionary<decimal, System.Collections.Generic.List<decimal>> Items = ((System.Collections.Generic.Dictionary<decimal, System.Collections.Generic.List<decimal>>)(inValues[0]));
            decimal newCheckID = ((decimal)(inValues[1]));
            return this.BeginMoveItems(Items, newCheckID, callback, asyncState);
        }

        private object[] OnEndMoveItems(System.IAsyncResult result)
        {
            bool retVal = this.EndMoveItems(result);
            return new object[] {
                retVal};
        }

        private void OnMoveItemsCompleted(object state)
        {
            if ((this.MoveItemsCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.MoveItemsCompleted(this, new MoveItemsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void MoveItemsAsync(System.Collections.Generic.Dictionary<decimal, System.Collections.Generic.List<decimal>> Items, decimal newCheckID)
        {
            this.MoveItemsAsync(Items, newCheckID, null);
        }

        public void MoveItemsAsync(System.Collections.Generic.Dictionary<decimal, System.Collections.Generic.List<decimal>> Items, decimal newCheckID, object userState)
        {
            if ((this.onBeginMoveItemsDelegate == null))
            {
                this.onBeginMoveItemsDelegate = new BeginOperationDelegate(this.OnBeginMoveItems);
            }
            if ((this.onEndMoveItemsDelegate == null))
            {
                this.onEndMoveItemsDelegate = new EndOperationDelegate(this.OnEndMoveItems);
            }
            if ((this.onMoveItemsCompletedDelegate == null))
            {
                this.onMoveItemsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnMoveItemsCompleted);
            }
            base.InvokeAsync(this.onBeginMoveItemsDelegate, new object[] {
                    Items,
                    newCheckID}, this.onEndMoveItemsDelegate, this.onMoveItemsCompletedDelegate, userState);
        }

        public bool HasOpenChecks(decimal TableID)
        {
            return Channel.HasOpenChecks(TableID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginHasOpenChecks(decimal TableID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginHasOpenChecks(TableID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndHasOpenChecks(System.IAsyncResult result)
        {
            return Channel.EndHasOpenChecks(result);
        }

        private System.IAsyncResult OnBeginHasOpenChecks(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            decimal TableID = ((decimal)(inValues[0]));
            return this.BeginHasOpenChecks(TableID, callback, asyncState);
        }

        private object[] OnEndHasOpenChecks(System.IAsyncResult result)
        {
            bool retVal = this.EndHasOpenChecks(result);
            return new object[] {
                retVal};
        }

        private void OnHasOpenChecksCompleted(object state)
        {
            if ((this.HasOpenChecksCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.HasOpenChecksCompleted(this, new HasOpenChecksCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void HasOpenChecksAsync(decimal TableID)
        {
            this.HasOpenChecksAsync(TableID, null);
        }

        public void HasOpenChecksAsync(decimal TableID, object userState)
        {
            if ((this.onBeginHasOpenChecksDelegate == null))
            {
                this.onBeginHasOpenChecksDelegate = new BeginOperationDelegate(this.OnBeginHasOpenChecks);
            }
            if ((this.onEndHasOpenChecksDelegate == null))
            {
                this.onEndHasOpenChecksDelegate = new EndOperationDelegate(this.OnEndHasOpenChecks);
            }
            if ((this.onHasOpenChecksCompletedDelegate == null))
            {
                this.onHasOpenChecksCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnHasOpenChecksCompleted);
            }
            base.InvokeAsync(this.onBeginHasOpenChecksDelegate, new object[] {
                    TableID}, this.onEndHasOpenChecksDelegate, this.onHasOpenChecksCompletedDelegate, userState);
        }

        public bool AddPayment(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID)
        {
            return Channel.AddPayment(CheckID, PaymentOption, Amount, UserID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginAddPayment(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginAddPayment(CheckID, PaymentOption, Amount, UserID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndAddPayment(System.IAsyncResult result)
        {
            return Channel.EndAddPayment(result);
        }

        private System.IAsyncResult OnBeginAddPayment(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            decimal CheckID = ((decimal)(inValues[0]));
            string PaymentOption = ((string)(inValues[1]));
            decimal Amount = ((decimal)(inValues[2]));
            decimal UserID = ((decimal)(inValues[3]));
            return this.BeginAddPayment(CheckID, PaymentOption, Amount, UserID, callback, asyncState);
        }

        private object[] OnEndAddPayment(System.IAsyncResult result)
        {
            bool retVal = this.EndAddPayment(result);
            return new object[] {
                retVal};
        }

        private void OnAddPaymentCompleted(object state)
        {
            if ((this.AddPaymentCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.AddPaymentCompleted(this, new AddPaymentCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void AddPaymentAsync(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID)
        {
            this.AddPaymentAsync(CheckID, PaymentOption, Amount, UserID, null);
        }

        public void AddPaymentAsync(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID, object userState)
        {
            if ((this.onBeginAddPaymentDelegate == null))
            {
                this.onBeginAddPaymentDelegate = new BeginOperationDelegate(this.OnBeginAddPayment);
            }
            if ((this.onEndAddPaymentDelegate == null))
            {
                this.onEndAddPaymentDelegate = new EndOperationDelegate(this.OnEndAddPayment);
            }
            if ((this.onAddPaymentCompletedDelegate == null))
            {
                this.onAddPaymentCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnAddPaymentCompleted);
            }
            base.InvokeAsync(this.onBeginAddPaymentDelegate, new object[] {
                    CheckID,
                    PaymentOption,
                    Amount,
                    UserID}, this.onEndAddPaymentDelegate, this.onAddPaymentCompletedDelegate, userState);
        }

        public bool AddGratuity(decimal CheckID, decimal Amount, decimal UserID)
        {
            return Channel.AddGratuity(CheckID, Amount, UserID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginAddGratuity(decimal CheckID, decimal Amount, decimal UserID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginAddGratuity(CheckID, Amount, UserID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndAddGratuity(System.IAsyncResult result)
        {
            return Channel.EndAddGratuity(result);
        }

        private System.IAsyncResult OnBeginAddGratuity(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            decimal CheckID = ((decimal)(inValues[0]));
            decimal Amount = ((decimal)(inValues[1]));
            decimal UserID = ((decimal)(inValues[2]));
            return this.BeginAddGratuity(CheckID, Amount, UserID, callback, asyncState);
        }

        private object[] OnEndAddGratuity(System.IAsyncResult result)
        {
            bool retVal = this.EndAddGratuity(result);
            return new object[] {
                retVal};
        }

        private void OnAddGratuityCompleted(object state)
        {
            if ((this.AddGratuityCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.AddGratuityCompleted(this, new AddGratuityCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void AddGratuityAsync(decimal CheckID, decimal Amount, decimal UserID)
        {
            this.AddGratuityAsync(CheckID, Amount, UserID, null);
        }

        public void AddGratuityAsync(decimal CheckID, decimal Amount, decimal UserID, object userState)
        {
            if ((this.onBeginAddGratuityDelegate == null))
            {
                this.onBeginAddGratuityDelegate = new BeginOperationDelegate(this.OnBeginAddGratuity);
            }
            if ((this.onEndAddGratuityDelegate == null))
            {
                this.onEndAddGratuityDelegate = new EndOperationDelegate(this.OnEndAddGratuity);
            }
            if ((this.onAddGratuityCompletedDelegate == null))
            {
                this.onAddGratuityCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnAddGratuityCompleted);
            }
            base.InvokeAsync(this.onBeginAddGratuityDelegate, new object[] {
                    CheckID,
                    Amount,
                    UserID}, this.onEndAddGratuityDelegate, this.onAddGratuityCompletedDelegate, userState);
        }

        public bool PrintCheckforMoble(System.Collections.Generic.List<decimal> CheckIDs, decimal UserID, bool isReceipt)
        {
            return Channel.PrintCheckforMoble(CheckIDs, UserID, isReceipt);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginPrintCheckforMoble(System.Collections.Generic.List<decimal> CheckIDs, decimal UserID, bool isReceipt, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginPrintCheckforMoble(CheckIDs, UserID, isReceipt, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndPrintCheckforMoble(System.IAsyncResult result)
        {
            return Channel.EndPrintCheckforMoble(result);
        }

        private System.IAsyncResult OnBeginPrintCheckforMoble(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            System.Collections.Generic.List<decimal> CheckIDs = ((System.Collections.Generic.List<decimal>)(inValues[0]));
            decimal UserID = ((decimal)(inValues[1]));
            bool isReceipt = ((bool)(inValues[2]));
            return this.BeginPrintCheckforMoble(CheckIDs, UserID, isReceipt, callback, asyncState);
        }

        private object[] OnEndPrintCheckforMoble(System.IAsyncResult result)
        {
            bool retVal = this.EndPrintCheckforMoble(result);
            return new object[] {
                retVal};
        }

        private void OnPrintCheckforMobleCompleted(object state)
        {
            if ((this.PrintCheckforMobleCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.PrintCheckforMobleCompleted(this, new PrintCheckforMobleCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void PrintCheckforMobleAsync(System.Collections.Generic.List<decimal> CheckIDs, decimal UserID, bool isReceipt)
        {
            this.PrintCheckforMobleAsync(CheckIDs, UserID, isReceipt, null);
        }

        public void PrintCheckforMobleAsync(System.Collections.Generic.List<decimal> CheckIDs, decimal UserID, bool isReceipt, object userState)
        {
            if ((this.onBeginPrintCheckforMobleDelegate == null))
            {
                this.onBeginPrintCheckforMobleDelegate = new BeginOperationDelegate(this.OnBeginPrintCheckforMoble);
            }
            if ((this.onEndPrintCheckforMobleDelegate == null))
            {
                this.onEndPrintCheckforMobleDelegate = new EndOperationDelegate(this.OnEndPrintCheckforMoble);
            }
            if ((this.onPrintCheckforMobleCompletedDelegate == null))
            {
                this.onPrintCheckforMobleCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnPrintCheckforMobleCompleted);
            }
            base.InvokeAsync(this.onBeginPrintCheckforMobleDelegate, new object[] {
                    CheckIDs,
                    UserID,
                    isReceipt}, this.onEndPrintCheckforMobleDelegate, this.onPrintCheckforMobleCompletedDelegate, userState);
        }

        public bool PrintCheckforRegister(System.Collections.Generic.List<decimal> CheckIDs, decimal UserID, bool isReceipt, int copies, decimal actionID)
        {
            return Channel.PrintCheckforRegister(CheckIDs, UserID, isReceipt, copies, actionID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginPrintCheckforRegister(System.Collections.Generic.List<decimal> CheckIDs, decimal UserID, bool isReceipt, int copies, decimal actionID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginPrintCheckforRegister(CheckIDs, UserID, isReceipt, copies, actionID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndPrintCheckforRegister(System.IAsyncResult result)
        {
            return Channel.EndPrintCheckforRegister(result);
        }

        private System.IAsyncResult OnBeginPrintCheckforRegister(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            System.Collections.Generic.List<decimal> CheckIDs = ((System.Collections.Generic.List<decimal>)(inValues[0]));
            decimal UserID = ((decimal)(inValues[1]));
            bool isReceipt = ((bool)(inValues[2]));
            int copies = ((int)(inValues[3]));
            decimal actionID = ((decimal)(inValues[4]));
            return this.BeginPrintCheckforRegister(CheckIDs, UserID, isReceipt, copies, actionID, callback, asyncState);
        }

        private object[] OnEndPrintCheckforRegister(System.IAsyncResult result)
        {
            bool retVal = this.EndPrintCheckforRegister(result);
            return new object[] {
                retVal};
        }

        private void OnPrintCheckforRegisterCompleted(object state)
        {
            if ((this.PrintCheckforRegisterCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.PrintCheckforRegisterCompleted(this, new PrintCheckforRegisterCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void PrintCheckforRegisterAsync(System.Collections.Generic.List<decimal> CheckIDs, decimal UserID, bool isReceipt, int copies, decimal actionID)
        {
            this.PrintCheckforRegisterAsync(CheckIDs, UserID, isReceipt, copies, actionID, null);
        }

        public void PrintCheckforRegisterAsync(System.Collections.Generic.List<decimal> CheckIDs, decimal UserID, bool isReceipt, int copies, decimal actionID, object userState)
        {
            if ((this.onBeginPrintCheckforRegisterDelegate == null))
            {
                this.onBeginPrintCheckforRegisterDelegate = new BeginOperationDelegate(this.OnBeginPrintCheckforRegister);
            }
            if ((this.onEndPrintCheckforRegisterDelegate == null))
            {
                this.onEndPrintCheckforRegisterDelegate = new EndOperationDelegate(this.OnEndPrintCheckforRegister);
            }
            if ((this.onPrintCheckforRegisterCompletedDelegate == null))
            {
                this.onPrintCheckforRegisterCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnPrintCheckforRegisterCompleted);
            }
            base.InvokeAsync(this.onBeginPrintCheckforRegisterDelegate, new object[] {
                    CheckIDs,
                    UserID,
                    isReceipt,
                    copies,
                    actionID}, this.onEndPrintCheckforRegisterDelegate, this.onPrintCheckforRegisterCompletedDelegate, userState);
        }

        public bool ClearCheck(decimal CheckID)
        {
            return Channel.ClearCheck(CheckID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginClearCheck(decimal CheckID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginClearCheck(CheckID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndClearCheck(System.IAsyncResult result)
        {
            return Channel.EndClearCheck(result);
        }

        private System.IAsyncResult OnBeginClearCheck(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            decimal CheckID = ((decimal)(inValues[0]));
            return this.BeginClearCheck(CheckID, callback, asyncState);
        }

        private object[] OnEndClearCheck(System.IAsyncResult result)
        {
            bool retVal = this.EndClearCheck(result);
            return new object[] {
                retVal};
        }

        private void OnClearCheckCompleted(object state)
        {
            if ((this.ClearCheckCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.ClearCheckCompleted(this, new ClearCheckCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void ClearCheckAsync(decimal CheckID)
        {
            this.ClearCheckAsync(CheckID, null);
        }

        public void ClearCheckAsync(decimal CheckID, object userState)
        {
            if ((this.onBeginClearCheckDelegate == null))
            {
                this.onBeginClearCheckDelegate = new BeginOperationDelegate(this.OnBeginClearCheck);
            }
            if ((this.onEndClearCheckDelegate == null))
            {
                this.onEndClearCheckDelegate = new EndOperationDelegate(this.OnEndClearCheck);
            }
            if ((this.onClearCheckCompletedDelegate == null))
            {
                this.onClearCheckCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnClearCheckCompleted);
            }
            base.InvokeAsync(this.onBeginClearCheckDelegate, new object[] {
                    CheckID}, this.onEndClearCheckDelegate, this.onClearCheckCompletedDelegate, userState);
        }

        public Staunch.POS.Classes.DBCheck GetCheck(decimal CheckID)
        {
            return Channel.GetCheck(CheckID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetCheck(decimal CheckID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetCheck(CheckID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public Staunch.POS.Classes.DBCheck EndGetCheck(System.IAsyncResult result)
        {
            return Channel.EndGetCheck(result);
        }

        private System.IAsyncResult OnBeginGetCheck(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            decimal CheckID = ((decimal)(inValues[0]));
            return this.BeginGetCheck(CheckID, callback, asyncState);
        }

        private object[] OnEndGetCheck(System.IAsyncResult result)
        {
            Staunch.POS.Classes.DBCheck retVal = this.EndGetCheck(result);
            return new object[] {
                retVal};
        }

        private void OnGetCheckCompleted(object state)
        {
            if ((this.GetCheckCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetCheckCompleted(this, new GetCheckCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void GetCheckAsync(decimal CheckID)
        {
            this.GetCheckAsync(CheckID, null);
        }

        public void GetCheckAsync(decimal CheckID, object userState)
        {
            if ((this.onBeginGetCheckDelegate == null))
            {
                this.onBeginGetCheckDelegate = new BeginOperationDelegate(this.OnBeginGetCheck);
            }
            if ((this.onEndGetCheckDelegate == null))
            {
                this.onEndGetCheckDelegate = new EndOperationDelegate(this.OnEndGetCheck);
            }
            if ((this.onGetCheckCompletedDelegate == null))
            {
                this.onGetCheckCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetCheckCompleted);
            }
            base.InvokeAsync(this.onBeginGetCheckDelegate, new object[] {
                    CheckID}, this.onEndGetCheckDelegate, this.onGetCheckCompletedDelegate, userState);
        }

        public bool removeOrderFromCheck(decimal OrderID, decimal CheckID)
        {
            return Channel.removeOrderFromCheck(OrderID, CheckID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginremoveOrderFromCheck(decimal OrderID, decimal CheckID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginremoveOrderFromCheck(OrderID, CheckID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndremoveOrderFromCheck(System.IAsyncResult result)
        {
            return Channel.EndremoveOrderFromCheck(result);
        }

        private System.IAsyncResult OnBeginremoveOrderFromCheck(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            decimal OrderID = ((decimal)(inValues[0]));
            decimal CheckID = ((decimal)(inValues[1]));
            return this.BeginremoveOrderFromCheck(OrderID, CheckID, callback, asyncState);
        }

        private object[] OnEndremoveOrderFromCheck(System.IAsyncResult result)
        {
            bool retVal = this.EndremoveOrderFromCheck(result);
            return new object[] {
                retVal};
        }

        private void OnremoveOrderFromCheckCompleted(object state)
        {
            if ((this.removeOrderFromCheckCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.removeOrderFromCheckCompleted(this, new removeOrderFromCheckCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void removeOrderFromCheckAsync(decimal OrderID, decimal CheckID)
        {
            this.removeOrderFromCheckAsync(OrderID, CheckID, null);
        }

        public void removeOrderFromCheckAsync(decimal OrderID, decimal CheckID, object userState)
        {
            if ((this.onBeginremoveOrderFromCheckDelegate == null))
            {
                this.onBeginremoveOrderFromCheckDelegate = new BeginOperationDelegate(this.OnBeginremoveOrderFromCheck);
            }
            if ((this.onEndremoveOrderFromCheckDelegate == null))
            {
                this.onEndremoveOrderFromCheckDelegate = new EndOperationDelegate(this.OnEndremoveOrderFromCheck);
            }
            if ((this.onremoveOrderFromCheckCompletedDelegate == null))
            {
                this.onremoveOrderFromCheckCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnremoveOrderFromCheckCompleted);
            }
            base.InvokeAsync(this.onBeginremoveOrderFromCheckDelegate, new object[] {
                    OrderID,
                    CheckID}, this.onEndremoveOrderFromCheckDelegate, this.onremoveOrderFromCheckCompletedDelegate, userState);
        }

        public int Ping()
        {
            return Channel.Ping();
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginPing(System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginPing(callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public int EndPing(System.IAsyncResult result)
        {
            return Channel.EndPing(result);
        }

        private System.IAsyncResult OnBeginPing(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginPing(callback, asyncState);
        }

        private object[] OnEndPing(System.IAsyncResult result)
        {
            int retVal = this.EndPing(result);
            return new object[] {
                retVal};
        }

        private void OnPingCompleted(object state)
        {
            if ((this.PingCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.PingCompleted(this, new PingCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void PingAsync()
        {
            this.PingAsync(null);
        }

        public void PingAsync(object userState)
        {
            if ((this.onBeginPingDelegate == null))
            {
                this.onBeginPingDelegate = new BeginOperationDelegate(this.OnBeginPing);
            }
            if ((this.onEndPingDelegate == null))
            {
                this.onEndPingDelegate = new EndOperationDelegate(this.OnEndPing);
            }
            if ((this.onPingCompletedDelegate == null))
            {
                this.onPingCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnPingCompleted);
            }
            base.InvokeAsync(this.onBeginPingDelegate, null, this.onEndPingDelegate, this.onPingCompletedDelegate, userState);
        }

        public string OpenDrawer(decimal actionID)
        {
            return Channel.OpenDrawer(actionID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginOpenDrawer(decimal actionID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginOpenDrawer(actionID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string EndOpenDrawer(System.IAsyncResult result)
        {
            return Channel.EndOpenDrawer(result);
        }

        private System.IAsyncResult OnBeginOpenDrawer(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            decimal actionID = ((decimal)(inValues[0]));
            return this.BeginOpenDrawer(actionID, callback, asyncState);
        }

        private object[] OnEndOpenDrawer(System.IAsyncResult result)
        {
            string retVal = this.EndOpenDrawer(result);
            return new object[] {
                retVal};
        }

        private void OnOpenDrawerCompleted(object state)
        {
            if ((this.OpenDrawerCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenDrawerCompleted(this, new OpenDrawerCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void OpenDrawerAsync(decimal actionID)
        {
            this.OpenDrawerAsync(actionID, null);
        }

        public void OpenDrawerAsync(decimal actionID, object userState)
        {
            if ((this.onBeginOpenDrawerDelegate == null))
            {
                this.onBeginOpenDrawerDelegate = new BeginOperationDelegate(this.OnBeginOpenDrawer);
            }
            if ((this.onEndOpenDrawerDelegate == null))
            {
                this.onEndOpenDrawerDelegate = new EndOperationDelegate(this.OnEndOpenDrawer);
            }
            if ((this.onOpenDrawerCompletedDelegate == null))
            {
                this.onOpenDrawerCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenDrawerCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDrawerDelegate, new object[] {
                    actionID}, this.onEndOpenDrawerDelegate, this.onOpenDrawerCompletedDelegate, userState);
        }

        public string GetCashDrawerPort(decimal ActionID)
        {
            return Channel.GetCashDrawerPort(ActionID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetCashDrawerPort(decimal ActionID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetCashDrawerPort(ActionID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string EndGetCashDrawerPort(System.IAsyncResult result)
        {
            return Channel.EndGetCashDrawerPort(result);
        }

        private System.IAsyncResult OnBeginGetCashDrawerPort(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            decimal ActionID = ((decimal)(inValues[0]));
            return this.BeginGetCashDrawerPort(ActionID, callback, asyncState);
        }

        private object[] OnEndGetCashDrawerPort(System.IAsyncResult result)
        {
            string retVal = this.EndGetCashDrawerPort(result);
            return new object[] {
                retVal};
        }

        private void OnGetCashDrawerPortCompleted(object state)
        {
            if ((this.GetCashDrawerPortCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetCashDrawerPortCompleted(this, new GetCashDrawerPortCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void GetCashDrawerPortAsync(decimal ActionID)
        {
            this.GetCashDrawerPortAsync(ActionID, null);
        }

        public void GetCashDrawerPortAsync(decimal ActionID, object userState)
        {
            if ((this.onBeginGetCashDrawerPortDelegate == null))
            {
                this.onBeginGetCashDrawerPortDelegate = new BeginOperationDelegate(this.OnBeginGetCashDrawerPort);
            }
            if ((this.onEndGetCashDrawerPortDelegate == null))
            {
                this.onEndGetCashDrawerPortDelegate = new EndOperationDelegate(this.OnEndGetCashDrawerPort);
            }
            if ((this.onGetCashDrawerPortCompletedDelegate == null))
            {
                this.onGetCashDrawerPortCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetCashDrawerPortCompleted);
            }
            base.InvokeAsync(this.onBeginGetCashDrawerPortDelegate, new object[] {
                    ActionID}, this.onEndGetCashDrawerPortDelegate, this.onGetCashDrawerPortCompletedDelegate, userState);
        }

        public System.Collections.Generic.Dictionary<string, decimal> GetGrossSalesForToday()
        {
            return Channel.GetGrossSalesForToday();
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetGrossSalesForToday(System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetGrossSalesForToday(callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.Collections.Generic.Dictionary<string, decimal> EndGetGrossSalesForToday(System.IAsyncResult result)
        {
            return Channel.EndGetGrossSalesForToday(result);
        }

        private System.IAsyncResult OnBeginGetGrossSalesForToday(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginGetGrossSalesForToday(callback, asyncState);
        }

        private object[] OnEndGetGrossSalesForToday(System.IAsyncResult result)
        {
            System.Collections.Generic.Dictionary<string, decimal> retVal = this.EndGetGrossSalesForToday(result);
            return new object[] {
                retVal};
        }

        private void OnGetGrossSalesForTodayCompleted(object state)
        {
            if ((this.GetGrossSalesForTodayCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetGrossSalesForTodayCompleted(this, new GetGrossSalesForTodayCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void GetGrossSalesForTodayAsync()
        {
            this.GetGrossSalesForTodayAsync(null);
        }

        public void GetGrossSalesForTodayAsync(object userState)
        {
            if ((this.onBeginGetGrossSalesForTodayDelegate == null))
            {
                this.onBeginGetGrossSalesForTodayDelegate = new BeginOperationDelegate(this.OnBeginGetGrossSalesForToday);
            }
            if ((this.onEndGetGrossSalesForTodayDelegate == null))
            {
                this.onEndGetGrossSalesForTodayDelegate = new EndOperationDelegate(this.OnEndGetGrossSalesForToday);
            }
            if ((this.onGetGrossSalesForTodayCompletedDelegate == null))
            {
                this.onGetGrossSalesForTodayCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetGrossSalesForTodayCompleted);
            }
            base.InvokeAsync(this.onBeginGetGrossSalesForTodayDelegate, null, this.onEndGetGrossSalesForTodayDelegate, this.onGetGrossSalesForTodayCompletedDelegate, userState);
        }

        public System.Collections.Generic.Dictionary<string, decimal> GetGrossSalesFor(System.DateTime Start, System.DateTime End)
        {
            return Channel.GetGrossSalesFor(Start, End);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetGrossSalesFor(System.DateTime Start, System.DateTime End, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetGrossSalesFor(Start, End, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.Collections.Generic.Dictionary<string, decimal> EndGetGrossSalesFor(System.IAsyncResult result)
        {
            return Channel.EndGetGrossSalesFor(result);
        }

        private System.IAsyncResult OnBeginGetGrossSalesFor(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            System.DateTime Start = ((System.DateTime)(inValues[0]));
            System.DateTime End = ((System.DateTime)(inValues[1]));
            return this.BeginGetGrossSalesFor(Start, End, callback, asyncState);
        }

        private object[] OnEndGetGrossSalesFor(System.IAsyncResult result)
        {
            System.Collections.Generic.Dictionary<string, decimal> retVal = this.EndGetGrossSalesFor(result);
            return new object[] {
                retVal};
        }

        private void OnGetGrossSalesForCompleted(object state)
        {
            if ((this.GetGrossSalesForCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetGrossSalesForCompleted(this, new GetGrossSalesForCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void GetGrossSalesForAsync(System.DateTime Start, System.DateTime End)
        {
            this.GetGrossSalesForAsync(Start, End, null);
        }

        public void GetGrossSalesForAsync(System.DateTime Start, System.DateTime End, object userState)
        {
            if ((this.onBeginGetGrossSalesForDelegate == null))
            {
                this.onBeginGetGrossSalesForDelegate = new BeginOperationDelegate(this.OnBeginGetGrossSalesFor);
            }
            if ((this.onEndGetGrossSalesForDelegate == null))
            {
                this.onEndGetGrossSalesForDelegate = new EndOperationDelegate(this.OnEndGetGrossSalesFor);
            }
            if ((this.onGetGrossSalesForCompletedDelegate == null))
            {
                this.onGetGrossSalesForCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetGrossSalesForCompleted);
            }
            base.InvokeAsync(this.onBeginGetGrossSalesForDelegate, new object[] {
                    Start,
                    End}, this.onEndGetGrossSalesForDelegate, this.onGetGrossSalesForCompletedDelegate, userState);
        }

        public decimal GetTaxFor(System.DateTime Start, System.DateTime End)
        {
            return Channel.GetTaxFor(Start, End);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetTaxFor(System.DateTime Start, System.DateTime End, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetTaxFor(Start, End, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public decimal EndGetTaxFor(System.IAsyncResult result)
        {
            return Channel.EndGetTaxFor(result);
        }

        private System.IAsyncResult OnBeginGetTaxFor(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            System.DateTime Start = ((System.DateTime)(inValues[0]));
            System.DateTime End = ((System.DateTime)(inValues[1]));
            return this.BeginGetTaxFor(Start, End, callback, asyncState);
        }

        private object[] OnEndGetTaxFor(System.IAsyncResult result)
        {
            decimal retVal = this.EndGetTaxFor(result);
            return new object[] {
                retVal};
        }

        private void OnGetTaxForCompleted(object state)
        {
            if ((this.GetTaxForCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetTaxForCompleted(this, new GetTaxForCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void GetTaxForAsync(System.DateTime Start, System.DateTime End)
        {
            this.GetTaxForAsync(Start, End, null);
        }

        public void GetTaxForAsync(System.DateTime Start, System.DateTime End, object userState)
        {
            if ((this.onBeginGetTaxForDelegate == null))
            {
                this.onBeginGetTaxForDelegate = new BeginOperationDelegate(this.OnBeginGetTaxFor);
            }
            if ((this.onEndGetTaxForDelegate == null))
            {
                this.onEndGetTaxForDelegate = new EndOperationDelegate(this.OnEndGetTaxFor);
            }
            if ((this.onGetTaxForCompletedDelegate == null))
            {
                this.onGetTaxForCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetTaxForCompleted);
            }
            base.InvokeAsync(this.onBeginGetTaxForDelegate, new object[] {
                    Start,
                    End}, this.onEndGetTaxForDelegate, this.onGetTaxForCompletedDelegate, userState);
        }

        public decimal GetTaxForToday()
        {
            return Channel.GetTaxForToday();
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetTaxForToday(System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetTaxForToday(callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public decimal EndGetTaxForToday(System.IAsyncResult result)
        {
            return Channel.EndGetTaxForToday(result);
        }

        private System.IAsyncResult OnBeginGetTaxForToday(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginGetTaxForToday(callback, asyncState);
        }

        private object[] OnEndGetTaxForToday(System.IAsyncResult result)
        {
            decimal retVal = this.EndGetTaxForToday(result);
            return new object[] {
                retVal};
        }

        private void OnGetTaxForTodayCompleted(object state)
        {
            if ((this.GetTaxForTodayCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetTaxForTodayCompleted(this, new GetTaxForTodayCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void GetTaxForTodayAsync()
        {
            this.GetTaxForTodayAsync(null);
        }

        public void GetTaxForTodayAsync(object userState)
        {
            if ((this.onBeginGetTaxForTodayDelegate == null))
            {
                this.onBeginGetTaxForTodayDelegate = new BeginOperationDelegate(this.OnBeginGetTaxForToday);
            }
            if ((this.onEndGetTaxForTodayDelegate == null))
            {
                this.onEndGetTaxForTodayDelegate = new EndOperationDelegate(this.OnEndGetTaxForToday);
            }
            if ((this.onGetTaxForTodayCompletedDelegate == null))
            {
                this.onGetTaxForTodayCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetTaxForTodayCompleted);
            }
            base.InvokeAsync(this.onBeginGetTaxForTodayDelegate, null, this.onEndGetTaxForTodayDelegate, this.onGetTaxForTodayCompletedDelegate, userState);
        }

        public decimal GetGratuityFor(System.DateTime Start, System.DateTime End)
        {
            return Channel.GetGratuityFor(Start, End);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetGratuityFor(System.DateTime Start, System.DateTime End, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetGratuityFor(Start, End, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public decimal EndGetGratuityFor(System.IAsyncResult result)
        {
            return Channel.EndGetGratuityFor(result);
        }

        private System.IAsyncResult OnBeginGetGratuityFor(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            System.DateTime Start = ((System.DateTime)(inValues[0]));
            System.DateTime End = ((System.DateTime)(inValues[1]));
            return this.BeginGetGratuityFor(Start, End, callback, asyncState);
        }

        private object[] OnEndGetGratuityFor(System.IAsyncResult result)
        {
            decimal retVal = this.EndGetGratuityFor(result);
            return new object[] {
                retVal};
        }

        private void OnGetGratuityForCompleted(object state)
        {
            if ((this.GetGratuityForCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetGratuityForCompleted(this, new GetGratuityForCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void GetGratuityForAsync(System.DateTime Start, System.DateTime End)
        {
            this.GetGratuityForAsync(Start, End, null);
        }

        public void GetGratuityForAsync(System.DateTime Start, System.DateTime End, object userState)
        {
            if ((this.onBeginGetGratuityForDelegate == null))
            {
                this.onBeginGetGratuityForDelegate = new BeginOperationDelegate(this.OnBeginGetGratuityFor);
            }
            if ((this.onEndGetGratuityForDelegate == null))
            {
                this.onEndGetGratuityForDelegate = new EndOperationDelegate(this.OnEndGetGratuityFor);
            }
            if ((this.onGetGratuityForCompletedDelegate == null))
            {
                this.onGetGratuityForCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetGratuityForCompleted);
            }
            base.InvokeAsync(this.onBeginGetGratuityForDelegate, new object[] {
                    Start,
                    End}, this.onEndGetGratuityForDelegate, this.onGetGratuityForCompletedDelegate, userState);
        }

        public decimal GetGratuityForToday()
        {
            return Channel.GetGratuityForToday();
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetGratuityForToday(System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetGratuityForToday(callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public decimal EndGetGratuityForToday(System.IAsyncResult result)
        {
            return Channel.EndGetGratuityForToday(result);
        }

        private System.IAsyncResult OnBeginGetGratuityForToday(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginGetGratuityForToday(callback, asyncState);
        }

        private object[] OnEndGetGratuityForToday(System.IAsyncResult result)
        {
            decimal retVal = this.EndGetGratuityForToday(result);
            return new object[] {
                retVal};
        }

        private void OnGetGratuityForTodayCompleted(object state)
        {
            if ((this.GetGratuityForTodayCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetGratuityForTodayCompleted(this, new GetGratuityForTodayCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void GetGratuityForTodayAsync()
        {
            this.GetGratuityForTodayAsync(null);
        }

        public void GetGratuityForTodayAsync(object userState)
        {
            if ((this.onBeginGetGratuityForTodayDelegate == null))
            {
                this.onBeginGetGratuityForTodayDelegate = new BeginOperationDelegate(this.OnBeginGetGratuityForToday);
            }
            if ((this.onEndGetGratuityForTodayDelegate == null))
            {
                this.onEndGetGratuityForTodayDelegate = new EndOperationDelegate(this.OnEndGetGratuityForToday);
            }
            if ((this.onGetGratuityForTodayCompletedDelegate == null))
            {
                this.onGetGratuityForTodayCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetGratuityForTodayCompleted);
            }
            base.InvokeAsync(this.onBeginGetGratuityForTodayDelegate, null, this.onEndGetGratuityForTodayDelegate, this.onGetGratuityForTodayCompletedDelegate, userState);
        }

        public decimal GetDiscountsFor(System.DateTime Start, System.DateTime End)
        {
            return Channel.GetDiscountsFor(Start, End);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetDiscountsFor(System.DateTime Start, System.DateTime End, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetDiscountsFor(Start, End, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public decimal EndGetDiscountsFor(System.IAsyncResult result)
        {
            return Channel.EndGetDiscountsFor(result);
        }

        private System.IAsyncResult OnBeginGetDiscountsFor(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            System.DateTime Start = ((System.DateTime)(inValues[0]));
            System.DateTime End = ((System.DateTime)(inValues[1]));
            return this.BeginGetDiscountsFor(Start, End, callback, asyncState);
        }

        private object[] OnEndGetDiscountsFor(System.IAsyncResult result)
        {
            decimal retVal = this.EndGetDiscountsFor(result);
            return new object[] {
                retVal};
        }

        private void OnGetDiscountsForCompleted(object state)
        {
            if ((this.GetDiscountsForCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetDiscountsForCompleted(this, new GetDiscountsForCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void GetDiscountsForAsync(System.DateTime Start, System.DateTime End)
        {
            this.GetDiscountsForAsync(Start, End, null);
        }

        public void GetDiscountsForAsync(System.DateTime Start, System.DateTime End, object userState)
        {
            if ((this.onBeginGetDiscountsForDelegate == null))
            {
                this.onBeginGetDiscountsForDelegate = new BeginOperationDelegate(this.OnBeginGetDiscountsFor);
            }
            if ((this.onEndGetDiscountsForDelegate == null))
            {
                this.onEndGetDiscountsForDelegate = new EndOperationDelegate(this.OnEndGetDiscountsFor);
            }
            if ((this.onGetDiscountsForCompletedDelegate == null))
            {
                this.onGetDiscountsForCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetDiscountsForCompleted);
            }
            base.InvokeAsync(this.onBeginGetDiscountsForDelegate, new object[] {
                    Start,
                    End}, this.onEndGetDiscountsForDelegate, this.onGetDiscountsForCompletedDelegate, userState);
        }

        public System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> GetChecksWithPayments(System.DateTime start, System.DateTime end)
        {
            return Channel.GetChecksWithPayments(start, end);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetChecksWithPayments(System.DateTime start, System.DateTime end, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetChecksWithPayments(start, end, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> EndGetChecksWithPayments(System.IAsyncResult result)
        {
            return Channel.EndGetChecksWithPayments(result);
        }

        private System.IAsyncResult OnBeginGetChecksWithPayments(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            System.DateTime start = ((System.DateTime)(inValues[0]));
            System.DateTime end = ((System.DateTime)(inValues[1]));
            return this.BeginGetChecksWithPayments(start, end, callback, asyncState);
        }

        private object[] OnEndGetChecksWithPayments(System.IAsyncResult result)
        {
            System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> retVal = this.EndGetChecksWithPayments(result);
            return new object[] {
                retVal};
        }

        private void OnGetChecksWithPaymentsCompleted(object state)
        {
            if ((this.GetChecksWithPaymentsCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetChecksWithPaymentsCompleted(this, new GetChecksWithPaymentsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void GetChecksWithPaymentsAsync(System.DateTime start, System.DateTime end)
        {
            this.GetChecksWithPaymentsAsync(start, end, null);
        }

        public void GetChecksWithPaymentsAsync(System.DateTime start, System.DateTime end, object userState)
        {
            if ((this.onBeginGetChecksWithPaymentsDelegate == null))
            {
                this.onBeginGetChecksWithPaymentsDelegate = new BeginOperationDelegate(this.OnBeginGetChecksWithPayments);
            }
            if ((this.onEndGetChecksWithPaymentsDelegate == null))
            {
                this.onEndGetChecksWithPaymentsDelegate = new EndOperationDelegate(this.OnEndGetChecksWithPayments);
            }
            if ((this.onGetChecksWithPaymentsCompletedDelegate == null))
            {
                this.onGetChecksWithPaymentsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetChecksWithPaymentsCompleted);
            }
            base.InvokeAsync(this.onBeginGetChecksWithPaymentsDelegate, new object[] {
                    start,
                    end}, this.onEndGetChecksWithPaymentsDelegate, this.onGetChecksWithPaymentsCompletedDelegate, userState);
        }

        public string PrintZReport(decimal UserID, System.DateTime start, System.DateTime end)
        {
            return Channel.PrintZReport(UserID, start, end);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginPrintZReport(decimal UserID, System.DateTime start, System.DateTime end, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginPrintZReport(UserID, start, end, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string EndPrintZReport(System.IAsyncResult result)
        {
            return Channel.EndPrintZReport(result);
        }

        private System.IAsyncResult OnBeginPrintZReport(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            decimal UserID = ((decimal)(inValues[0]));
            System.DateTime start = ((System.DateTime)(inValues[1]));
            System.DateTime end = ((System.DateTime)(inValues[2]));
            return this.BeginPrintZReport(UserID, start, end, callback, asyncState);
        }

        private object[] OnEndPrintZReport(System.IAsyncResult result)
        {
            string retVal = this.EndPrintZReport(result);
            return new object[] {
                retVal};
        }

        private void OnPrintZReportCompleted(object state)
        {
            if ((this.PrintZReportCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.PrintZReportCompleted(this, new PrintZReportCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void PrintZReportAsync(decimal UserID, System.DateTime start, System.DateTime end)
        {
            this.PrintZReportAsync(UserID, start, end, null);
        }

        public void PrintZReportAsync(decimal UserID, System.DateTime start, System.DateTime end, object userState)
        {
            if ((this.onBeginPrintZReportDelegate == null))
            {
                this.onBeginPrintZReportDelegate = new BeginOperationDelegate(this.OnBeginPrintZReport);
            }
            if ((this.onEndPrintZReportDelegate == null))
            {
                this.onEndPrintZReportDelegate = new EndOperationDelegate(this.OnEndPrintZReport);
            }
            if ((this.onPrintZReportCompletedDelegate == null))
            {
                this.onPrintZReportCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnPrintZReportCompleted);
            }
            base.InvokeAsync(this.onBeginPrintZReportDelegate, new object[] {
                    UserID,
                    start,
                    end}, this.onEndPrintZReportDelegate, this.onPrintZReportCompletedDelegate, userState);
        }

        public System.Collections.Generic.Dictionary<string, decimal> GetSalesReport(System.DateTime start, System.DateTime end)
        {
            return Channel.GetSalesReport(start, end);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetSalesReport(System.DateTime start, System.DateTime end, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetSalesReport(start, end, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.Collections.Generic.Dictionary<string, decimal> EndGetSalesReport(System.IAsyncResult result)
        {
            return Channel.EndGetSalesReport(result);
        }

        private System.IAsyncResult OnBeginGetSalesReport(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            System.DateTime start = ((System.DateTime)(inValues[0]));
            System.DateTime end = ((System.DateTime)(inValues[1]));
            return this.BeginGetSalesReport(start, end, callback, asyncState);
        }

        private object[] OnEndGetSalesReport(System.IAsyncResult result)
        {
            System.Collections.Generic.Dictionary<string, decimal> retVal = this.EndGetSalesReport(result);
            return new object[] {
                retVal};
        }

        private void OnGetSalesReportCompleted(object state)
        {
            if ((this.GetSalesReportCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetSalesReportCompleted(this, new GetSalesReportCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void GetSalesReportAsync(System.DateTime start, System.DateTime end)
        {
            this.GetSalesReportAsync(start, end, null);
        }

        public void GetSalesReportAsync(System.DateTime start, System.DateTime end, object userState)
        {
            if ((this.onBeginGetSalesReportDelegate == null))
            {
                this.onBeginGetSalesReportDelegate = new BeginOperationDelegate(this.OnBeginGetSalesReport);
            }
            if ((this.onEndGetSalesReportDelegate == null))
            {
                this.onEndGetSalesReportDelegate = new EndOperationDelegate(this.OnEndGetSalesReport);
            }
            if ((this.onGetSalesReportCompletedDelegate == null))
            {
                this.onGetSalesReportCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetSalesReportCompleted);
            }
            base.InvokeAsync(this.onBeginGetSalesReportDelegate, new object[] {
                    start,
                    end}, this.onEndGetSalesReportDelegate, this.onGetSalesReportCompletedDelegate, userState);
        }

        public string PrintSalesReport(decimal UserID, System.DateTime start, System.DateTime end)
        {
            return Channel.PrintSalesReport(UserID, start, end);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginPrintSalesReport(decimal UserID, System.DateTime start, System.DateTime end, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginPrintSalesReport(UserID, start, end, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string EndPrintSalesReport(System.IAsyncResult result)
        {
            return Channel.EndPrintSalesReport(result);
        }

        private System.IAsyncResult OnBeginPrintSalesReport(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            decimal UserID = ((decimal)(inValues[0]));
            System.DateTime start = ((System.DateTime)(inValues[1]));
            System.DateTime end = ((System.DateTime)(inValues[2]));
            return this.BeginPrintSalesReport(UserID, start, end, callback, asyncState);
        }

        private object[] OnEndPrintSalesReport(System.IAsyncResult result)
        {
            string retVal = this.EndPrintSalesReport(result);
            return new object[] {
                retVal};
        }

        private void OnPrintSalesReportCompleted(object state)
        {
            if ((this.PrintSalesReportCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.PrintSalesReportCompleted(this, new PrintSalesReportCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void PrintSalesReportAsync(decimal UserID, System.DateTime start, System.DateTime end)
        {
            this.PrintSalesReportAsync(UserID, start, end, null);
        }

        public void PrintSalesReportAsync(decimal UserID, System.DateTime start, System.DateTime end, object userState)
        {
            if ((this.onBeginPrintSalesReportDelegate == null))
            {
                this.onBeginPrintSalesReportDelegate = new BeginOperationDelegate(this.OnBeginPrintSalesReport);
            }
            if ((this.onEndPrintSalesReportDelegate == null))
            {
                this.onEndPrintSalesReportDelegate = new EndOperationDelegate(this.OnEndPrintSalesReport);
            }
            if ((this.onPrintSalesReportCompletedDelegate == null))
            {
                this.onPrintSalesReportCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnPrintSalesReportCompleted);
            }
            base.InvokeAsync(this.onBeginPrintSalesReportDelegate, new object[] {
                    UserID,
                    start,
                    end}, this.onEndPrintSalesReportDelegate, this.onPrintSalesReportCompletedDelegate, userState);
        }

        public bool ReopenCheck(decimal CheckID)
        {
            return Channel.ReopenCheck(CheckID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginReopenCheck(decimal CheckID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginReopenCheck(CheckID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndReopenCheck(System.IAsyncResult result)
        {
            return Channel.EndReopenCheck(result);
        }

        private System.IAsyncResult OnBeginReopenCheck(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            decimal CheckID = ((decimal)(inValues[0]));
            return this.BeginReopenCheck(CheckID, callback, asyncState);
        }

        private object[] OnEndReopenCheck(System.IAsyncResult result)
        {
            bool retVal = this.EndReopenCheck(result);
            return new object[] {
                retVal};
        }

        private void OnReopenCheckCompleted(object state)
        {
            if ((this.ReopenCheckCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.ReopenCheckCompleted(this, new ReopenCheckCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void ReopenCheckAsync(decimal CheckID)
        {
            this.ReopenCheckAsync(CheckID, null);
        }

        public void ReopenCheckAsync(decimal CheckID, object userState)
        {
            if ((this.onBeginReopenCheckDelegate == null))
            {
                this.onBeginReopenCheckDelegate = new BeginOperationDelegate(this.OnBeginReopenCheck);
            }
            if ((this.onEndReopenCheckDelegate == null))
            {
                this.onEndReopenCheckDelegate = new EndOperationDelegate(this.OnEndReopenCheck);
            }
            if ((this.onReopenCheckCompletedDelegate == null))
            {
                this.onReopenCheckCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnReopenCheckCompleted);
            }
            base.InvokeAsync(this.onBeginReopenCheckDelegate, new object[] {
                    CheckID}, this.onEndReopenCheckDelegate, this.onReopenCheckCompletedDelegate, userState);
        }

        public string DeleteCheck(Staunch.POS.Classes.DBCheck CheckToDelete)
        {
            return Channel.DeleteCheck(CheckToDelete);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginDeleteCheck(Staunch.POS.Classes.DBCheck CheckToDelete, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginDeleteCheck(CheckToDelete, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string EndDeleteCheck(System.IAsyncResult result)
        {
            return Channel.EndDeleteCheck(result);
        }

        private System.IAsyncResult OnBeginDeleteCheck(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            Staunch.POS.Classes.DBCheck CheckToDelete = ((Staunch.POS.Classes.DBCheck)(inValues[0]));
            return this.BeginDeleteCheck(CheckToDelete, callback, asyncState);
        }

        private object[] OnEndDeleteCheck(System.IAsyncResult result)
        {
            string retVal = this.EndDeleteCheck(result);
            return new object[] {
                retVal};
        }

        private void OnDeleteCheckCompleted(object state)
        {
            if ((this.DeleteCheckCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.DeleteCheckCompleted(this, new DeleteCheckCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void DeleteCheckAsync(Staunch.POS.Classes.DBCheck CheckToDelete)
        {
            this.DeleteCheckAsync(CheckToDelete, null);
        }

        public void DeleteCheckAsync(Staunch.POS.Classes.DBCheck CheckToDelete, object userState)
        {
            if ((this.onBeginDeleteCheckDelegate == null))
            {
                this.onBeginDeleteCheckDelegate = new BeginOperationDelegate(this.OnBeginDeleteCheck);
            }
            if ((this.onEndDeleteCheckDelegate == null))
            {
                this.onEndDeleteCheckDelegate = new EndOperationDelegate(this.OnEndDeleteCheck);
            }
            if ((this.onDeleteCheckCompletedDelegate == null))
            {
                this.onDeleteCheckCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnDeleteCheckCompleted);
            }
            base.InvokeAsync(this.onBeginDeleteCheckDelegate, new object[] {
                    CheckToDelete}, this.onEndDeleteCheckDelegate, this.onDeleteCheckCompletedDelegate, userState);
        }

        public bool RemoveOrderFromClosedCheck(decimal OrderID, decimal CheckID)
        {
            return Channel.RemoveOrderFromClosedCheck(OrderID, CheckID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginRemoveOrderFromClosedCheck(decimal OrderID, decimal CheckID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginRemoveOrderFromClosedCheck(OrderID, CheckID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndRemoveOrderFromClosedCheck(System.IAsyncResult result)
        {
            return Channel.EndRemoveOrderFromClosedCheck(result);
        }

        private System.IAsyncResult OnBeginRemoveOrderFromClosedCheck(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            decimal OrderID = ((decimal)(inValues[0]));
            decimal CheckID = ((decimal)(inValues[1]));
            return this.BeginRemoveOrderFromClosedCheck(OrderID, CheckID, callback, asyncState);
        }

        private object[] OnEndRemoveOrderFromClosedCheck(System.IAsyncResult result)
        {
            bool retVal = this.EndRemoveOrderFromClosedCheck(result);
            return new object[] {
                retVal};
        }

        private void OnRemoveOrderFromClosedCheckCompleted(object state)
        {
            if ((this.RemoveOrderFromClosedCheckCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.RemoveOrderFromClosedCheckCompleted(this, new RemoveOrderFromClosedCheckCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void RemoveOrderFromClosedCheckAsync(decimal OrderID, decimal CheckID)
        {
            this.RemoveOrderFromClosedCheckAsync(OrderID, CheckID, null);
        }

        public void RemoveOrderFromClosedCheckAsync(decimal OrderID, decimal CheckID, object userState)
        {
            if ((this.onBeginRemoveOrderFromClosedCheckDelegate == null))
            {
                this.onBeginRemoveOrderFromClosedCheckDelegate = new BeginOperationDelegate(this.OnBeginRemoveOrderFromClosedCheck);
            }
            if ((this.onEndRemoveOrderFromClosedCheckDelegate == null))
            {
                this.onEndRemoveOrderFromClosedCheckDelegate = new EndOperationDelegate(this.OnEndRemoveOrderFromClosedCheck);
            }
            if ((this.onRemoveOrderFromClosedCheckCompletedDelegate == null))
            {
                this.onRemoveOrderFromClosedCheckCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnRemoveOrderFromClosedCheckCompleted);
            }
            base.InvokeAsync(this.onBeginRemoveOrderFromClosedCheckDelegate, new object[] {
                    OrderID,
                    CheckID}, this.onEndRemoveOrderFromClosedCheckDelegate, this.onRemoveOrderFromClosedCheckCompletedDelegate, userState);
        }

        public bool MoveCheck(decimal CheckID, decimal NewTableID)
        {
            return Channel.MoveCheck(CheckID, NewTableID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginMoveCheck(decimal CheckID, decimal NewTableID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginMoveCheck(CheckID, NewTableID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndMoveCheck(System.IAsyncResult result)
        {
            return Channel.EndMoveCheck(result);
        }

        private System.IAsyncResult OnBeginMoveCheck(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            decimal CheckID = ((decimal)(inValues[0]));
            decimal NewTableID = ((decimal)(inValues[1]));
            return this.BeginMoveCheck(CheckID, NewTableID, callback, asyncState);
        }

        private object[] OnEndMoveCheck(System.IAsyncResult result)
        {
            bool retVal = this.EndMoveCheck(result);
            return new object[] {
                retVal};
        }

        private void OnMoveCheckCompleted(object state)
        {
            if ((this.MoveCheckCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.MoveCheckCompleted(this, new MoveCheckCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void MoveCheckAsync(decimal CheckID, decimal NewTableID)
        {
            this.MoveCheckAsync(CheckID, NewTableID, null);
        }

        public void MoveCheckAsync(decimal CheckID, decimal NewTableID, object userState)
        {
            if ((this.onBeginMoveCheckDelegate == null))
            {
                this.onBeginMoveCheckDelegate = new BeginOperationDelegate(this.OnBeginMoveCheck);
            }
            if ((this.onEndMoveCheckDelegate == null))
            {
                this.onEndMoveCheckDelegate = new EndOperationDelegate(this.OnEndMoveCheck);
            }
            if ((this.onMoveCheckCompletedDelegate == null))
            {
                this.onMoveCheckCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnMoveCheckCompleted);
            }
            base.InvokeAsync(this.onBeginMoveCheckDelegate, new object[] {
                    CheckID,
                    NewTableID}, this.onEndMoveCheckDelegate, this.onMoveCheckCompletedDelegate, userState);
        }

        public void ExportReports(System.DateTime start, System.DateTime end)
        {
            Channel.ExportReports(start, end);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginExportReports(System.DateTime start, System.DateTime end, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginExportReports(start, end, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public void EndExportReports(System.IAsyncResult result)
        {
            Channel.EndExportReports(result);
        }

        private System.IAsyncResult OnBeginExportReports(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            System.DateTime start = ((System.DateTime)(inValues[0]));
            System.DateTime end = ((System.DateTime)(inValues[1]));
            return this.BeginExportReports(start, end, callback, asyncState);
        }

        private object[] OnEndExportReports(System.IAsyncResult result)
        {
            this.EndExportReports(result);
            return null;
        }

        private void OnExportReportsCompleted(object state)
        {
            if ((this.ExportReportsCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.ExportReportsCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }

        public void ExportReportsAsync(System.DateTime start, System.DateTime end)
        {
            this.ExportReportsAsync(start, end, null);
        }

        public void ExportReportsAsync(System.DateTime start, System.DateTime end, object userState)
        {
            if ((this.onBeginExportReportsDelegate == null))
            {
                this.onBeginExportReportsDelegate = new BeginOperationDelegate(this.OnBeginExportReports);
            }
            if ((this.onEndExportReportsDelegate == null))
            {
                this.onEndExportReportsDelegate = new EndOperationDelegate(this.OnEndExportReports);
            }
            if ((this.onExportReportsCompletedDelegate == null))
            {
                this.onExportReportsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnExportReportsCompleted);
            }
            base.InvokeAsync(this.onBeginExportReportsDelegate, new object[] {
                    start,
                    end}, this.onEndExportReportsDelegate, this.onExportReportsCompletedDelegate, userState);
        }

        public bool UpdateTakeoutCheck(Staunch.POS.Classes.DBCheck check, decimal UserID)
        {
            return Channel.UpdateTakeoutCheck(check, UserID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginUpdateTakeoutCheck(Staunch.POS.Classes.DBCheck check, decimal UserID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginUpdateTakeoutCheck(check, UserID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndUpdateTakeoutCheck(System.IAsyncResult result)
        {
            return Channel.EndUpdateTakeoutCheck(result);
        }

        private System.IAsyncResult OnBeginUpdateTakeoutCheck(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            Staunch.POS.Classes.DBCheck check = ((Staunch.POS.Classes.DBCheck)(inValues[0]));
            decimal UserID = ((decimal)(inValues[1]));
            return this.BeginUpdateTakeoutCheck(check, UserID, callback, asyncState);
        }

        private object[] OnEndUpdateTakeoutCheck(System.IAsyncResult result)
        {
            bool retVal = this.EndUpdateTakeoutCheck(result);
            return new object[] {
                retVal};
        }

        private void OnUpdateTakeoutCheckCompleted(object state)
        {
            if ((this.UpdateTakeoutCheckCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.UpdateTakeoutCheckCompleted(this, new UpdateTakeoutCheckCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void UpdateTakeoutCheckAsync(Staunch.POS.Classes.DBCheck check, decimal UserID)
        {
            this.UpdateTakeoutCheckAsync(check, UserID, null);
        }

        public void UpdateTakeoutCheckAsync(Staunch.POS.Classes.DBCheck check, decimal UserID, object userState)
        {
            if ((this.onBeginUpdateTakeoutCheckDelegate == null))
            {
                this.onBeginUpdateTakeoutCheckDelegate = new BeginOperationDelegate(this.OnBeginUpdateTakeoutCheck);
            }
            if ((this.onEndUpdateTakeoutCheckDelegate == null))
            {
                this.onEndUpdateTakeoutCheckDelegate = new EndOperationDelegate(this.OnEndUpdateTakeoutCheck);
            }
            if ((this.onUpdateTakeoutCheckCompletedDelegate == null))
            {
                this.onUpdateTakeoutCheckCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnUpdateTakeoutCheckCompleted);
            }
            base.InvokeAsync(this.onBeginUpdateTakeoutCheckDelegate, new object[] {
                    check,
                    UserID}, this.onEndUpdateTakeoutCheckDelegate, this.onUpdateTakeoutCheckCompletedDelegate, userState);
        }

        public string UpdateCheckDiscounts(System.Collections.Generic.List<Staunch.POS.Classes.OrderDiscount> discounts, bool taxable)
        {
            return Channel.UpdateCheckDiscounts(discounts, taxable);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginUpdateCheckDiscounts(System.Collections.Generic.List<Staunch.POS.Classes.OrderDiscount> discounts, bool taxable, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginUpdateCheckDiscounts(discounts, taxable, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string EndUpdateCheckDiscounts(System.IAsyncResult result)
        {
            return Channel.EndUpdateCheckDiscounts(result);
        }

        private System.IAsyncResult OnBeginUpdateCheckDiscounts(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            System.Collections.Generic.List<Staunch.POS.Classes.OrderDiscount> discounts = ((System.Collections.Generic.List<Staunch.POS.Classes.OrderDiscount>)(inValues[0]));
            bool taxable = ((bool)(inValues[1]));
            return this.BeginUpdateCheckDiscounts(discounts, taxable, callback, asyncState);
        }

        private object[] OnEndUpdateCheckDiscounts(System.IAsyncResult result)
        {
            string retVal = this.EndUpdateCheckDiscounts(result);
            return new object[] {
                retVal};
        }

        private void OnUpdateCheckDiscountsCompleted(object state)
        {
            if ((this.UpdateCheckDiscountsCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.UpdateCheckDiscountsCompleted(this, new UpdateCheckDiscountsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void UpdateCheckDiscountsAsync(System.Collections.Generic.List<Staunch.POS.Classes.OrderDiscount> discounts, bool taxable)
        {
            this.UpdateCheckDiscountsAsync(discounts, taxable, null);
        }

        public void UpdateCheckDiscountsAsync(System.Collections.Generic.List<Staunch.POS.Classes.OrderDiscount> discounts, bool taxable, object userState)
        {
            if ((this.onBeginUpdateCheckDiscountsDelegate == null))
            {
                this.onBeginUpdateCheckDiscountsDelegate = new BeginOperationDelegate(this.OnBeginUpdateCheckDiscounts);
            }
            if ((this.onEndUpdateCheckDiscountsDelegate == null))
            {
                this.onEndUpdateCheckDiscountsDelegate = new EndOperationDelegate(this.OnEndUpdateCheckDiscounts);
            }
            if ((this.onUpdateCheckDiscountsCompletedDelegate == null))
            {
                this.onUpdateCheckDiscountsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnUpdateCheckDiscountsCompleted);
            }
            base.InvokeAsync(this.onBeginUpdateCheckDiscountsDelegate, new object[] {
                    discounts,
                    taxable}, this.onEndUpdateCheckDiscountsDelegate, this.onUpdateCheckDiscountsCompletedDelegate, userState);
        }

        public string Checkout(decimal checkId, System.Collections.Generic.List<decimal> guestIds, decimal tableId)
        {
            return Channel.Checkout(checkId, guestIds, tableId);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginCheckout(decimal checkId, System.Collections.Generic.List<decimal> guestIds, decimal tableId, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginCheckout(checkId, guestIds, tableId, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string EndCheckout(System.IAsyncResult result)
        {
            return Channel.EndCheckout(result);
        }

        private System.IAsyncResult OnBeginCheckout(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            decimal checkId = ((decimal)(inValues[0]));
            System.Collections.Generic.List<decimal> guestIds = ((System.Collections.Generic.List<decimal>)(inValues[1]));
            decimal tableId = ((decimal)(inValues[2]));
            return this.BeginCheckout(checkId, guestIds, tableId, callback, asyncState);
        }

        private object[] OnEndCheckout(System.IAsyncResult result)
        {
            string retVal = this.EndCheckout(result);
            return new object[] {
                retVal};
        }

        private void OnCheckoutCompleted(object state)
        {
            if ((this.CheckoutCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CheckoutCompleted(this, new CheckoutCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void CheckoutAsync(decimal checkId, System.Collections.Generic.List<decimal> guestIds, decimal tableId)
        {
            this.CheckoutAsync(checkId, guestIds, tableId, null);
        }

        public void CheckoutAsync(decimal checkId, System.Collections.Generic.List<decimal> guestIds, decimal tableId, object userState)
        {
            if ((this.onBeginCheckoutDelegate == null))
            {
                this.onBeginCheckoutDelegate = new BeginOperationDelegate(this.OnBeginCheckout);
            }
            if ((this.onEndCheckoutDelegate == null))
            {
                this.onEndCheckoutDelegate = new EndOperationDelegate(this.OnEndCheckout);
            }
            if ((this.onCheckoutCompletedDelegate == null))
            {
                this.onCheckoutCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCheckoutCompleted);
            }
            base.InvokeAsync(this.onBeginCheckoutDelegate, new object[] {
                    checkId,
                    guestIds,
                    tableId}, this.onEndCheckoutDelegate, this.onCheckoutCompletedDelegate, userState);
        }

        public System.Collections.Generic.List<System.Collections.Generic.List<string>> GetReportForDates(System.DateTime start, System.DateTime end)
        {
            return Channel.GetReportForDates(start, end);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetReportForDates(System.DateTime start, System.DateTime end, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetReportForDates(start, end, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.Collections.Generic.List<System.Collections.Generic.List<string>> EndGetReportForDates(System.IAsyncResult result)
        {
            return Channel.EndGetReportForDates(result);
        }

        private System.IAsyncResult OnBeginGetReportForDates(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            System.DateTime start = ((System.DateTime)(inValues[0]));
            System.DateTime end = ((System.DateTime)(inValues[1]));
            return this.BeginGetReportForDates(start, end, callback, asyncState);
        }

        private object[] OnEndGetReportForDates(System.IAsyncResult result)
        {
            System.Collections.Generic.List<System.Collections.Generic.List<string>> retVal = this.EndGetReportForDates(result);
            return new object[] {
                retVal};
        }

        private void OnGetReportForDatesCompleted(object state)
        {
            if ((this.GetReportForDatesCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetReportForDatesCompleted(this, new GetReportForDatesCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void GetReportForDatesAsync(System.DateTime start, System.DateTime end)
        {
            this.GetReportForDatesAsync(start, end, null);
        }

        public void GetReportForDatesAsync(System.DateTime start, System.DateTime end, object userState)
        {
            if ((this.onBeginGetReportForDatesDelegate == null))
            {
                this.onBeginGetReportForDatesDelegate = new BeginOperationDelegate(this.OnBeginGetReportForDates);
            }
            if ((this.onEndGetReportForDatesDelegate == null))
            {
                this.onEndGetReportForDatesDelegate = new EndOperationDelegate(this.OnEndGetReportForDates);
            }
            if ((this.onGetReportForDatesCompletedDelegate == null))
            {
                this.onGetReportForDatesCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetReportForDatesCompleted);
            }
            base.InvokeAsync(this.onBeginGetReportForDatesDelegate, new object[] {
                    start,
                    end}, this.onEndGetReportForDatesDelegate, this.onGetReportForDatesCompletedDelegate, userState);
        }

        public string RemoveTax(decimal CheckID)
        {
            return Channel.RemoveTax(CheckID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginRemoveTax(decimal CheckID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginRemoveTax(CheckID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string EndRemoveTax(System.IAsyncResult result)
        {
            return Channel.EndRemoveTax(result);
        }

        private System.IAsyncResult OnBeginRemoveTax(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            decimal CheckID = ((decimal)(inValues[0]));
            return this.BeginRemoveTax(CheckID, callback, asyncState);
        }

        private object[] OnEndRemoveTax(System.IAsyncResult result)
        {
            string retVal = this.EndRemoveTax(result);
            return new object[] {
                retVal};
        }

        private void OnRemoveTaxCompleted(object state)
        {
            if ((this.RemoveTaxCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.RemoveTaxCompleted(this, new RemoveTaxCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void RemoveTaxAsync(decimal CheckID)
        {
            this.RemoveTaxAsync(CheckID, null);
        }

        public void RemoveTaxAsync(decimal CheckID, object userState)
        {
            if ((this.onBeginRemoveTaxDelegate == null))
            {
                this.onBeginRemoveTaxDelegate = new BeginOperationDelegate(this.OnBeginRemoveTax);
            }
            if ((this.onEndRemoveTaxDelegate == null))
            {
                this.onEndRemoveTaxDelegate = new EndOperationDelegate(this.OnEndRemoveTax);
            }
            if ((this.onRemoveTaxCompletedDelegate == null))
            {
                this.onRemoveTaxCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnRemoveTaxCompleted);
            }
            base.InvokeAsync(this.onBeginRemoveTaxDelegate, new object[] {
                    CheckID}, this.onEndRemoveTaxDelegate, this.onRemoveTaxCompletedDelegate, userState);
        }

        public System.Collections.Generic.List<decimal> CreateLSEChecks(System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> CheckList, decimal UserID)
        {
            return Channel.CreateLSEChecks(CheckList, UserID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginCreateLSEChecks(System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> CheckList, decimal UserID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginCreateLSEChecks(CheckList, UserID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.Collections.Generic.List<decimal> EndCreateLSEChecks(System.IAsyncResult result)
        {
            return Channel.EndCreateLSEChecks(result);
        }

        private System.IAsyncResult OnBeginCreateLSEChecks(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> CheckList = ((System.Collections.Generic.List<Staunch.POS.Classes.DBCheck>)(inValues[0]));
            decimal UserID = ((decimal)(inValues[1]));
            return this.BeginCreateLSEChecks(CheckList, UserID, callback, asyncState);
        }

        private object[] OnEndCreateLSEChecks(System.IAsyncResult result)
        {
            System.Collections.Generic.List<decimal> retVal = this.EndCreateLSEChecks(result);
            return new object[] {
                retVal};
        }

        private void OnCreateLSEChecksCompleted(object state)
        {
            if ((this.CreateLSEChecksCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CreateLSEChecksCompleted(this, new CreateLSEChecksCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void CreateLSEChecksAsync(System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> CheckList, decimal UserID)
        {
            this.CreateLSEChecksAsync(CheckList, UserID, null);
        }

        public void CreateLSEChecksAsync(System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> CheckList, decimal UserID, object userState)
        {
            if ((this.onBeginCreateLSEChecksDelegate == null))
            {
                this.onBeginCreateLSEChecksDelegate = new BeginOperationDelegate(this.OnBeginCreateLSEChecks);
            }
            if ((this.onEndCreateLSEChecksDelegate == null))
            {
                this.onEndCreateLSEChecksDelegate = new EndOperationDelegate(this.OnEndCreateLSEChecks);
            }
            if ((this.onCreateLSEChecksCompletedDelegate == null))
            {
                this.onCreateLSEChecksCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCreateLSEChecksCompleted);
            }
            base.InvokeAsync(this.onBeginCreateLSEChecksDelegate, new object[] {
                    CheckList,
                    UserID}, this.onEndCreateLSEChecksDelegate, this.onCreateLSEChecksCompletedDelegate, userState);
        }

        public bool AddLSEPayment(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID)
        {
            return Channel.AddLSEPayment(CheckID, PaymentOption, Amount, UserID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginAddLSEPayment(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginAddLSEPayment(CheckID, PaymentOption, Amount, UserID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndAddLSEPayment(System.IAsyncResult result)
        {
            return Channel.EndAddLSEPayment(result);
        }

        private System.IAsyncResult OnBeginAddLSEPayment(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            decimal CheckID = ((decimal)(inValues[0]));
            string PaymentOption = ((string)(inValues[1]));
            decimal Amount = ((decimal)(inValues[2]));
            decimal UserID = ((decimal)(inValues[3]));
            return this.BeginAddLSEPayment(CheckID, PaymentOption, Amount, UserID, callback, asyncState);
        }

        private object[] OnEndAddLSEPayment(System.IAsyncResult result)
        {
            bool retVal = this.EndAddLSEPayment(result);
            return new object[] {
                retVal};
        }

        private void OnAddLSEPaymentCompleted(object state)
        {
            if ((this.AddLSEPaymentCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.AddLSEPaymentCompleted(this, new AddLSEPaymentCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void AddLSEPaymentAsync(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID)
        {
            this.AddLSEPaymentAsync(CheckID, PaymentOption, Amount, UserID, null);
        }

        public void AddLSEPaymentAsync(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID, object userState)
        {
            if ((this.onBeginAddLSEPaymentDelegate == null))
            {
                this.onBeginAddLSEPaymentDelegate = new BeginOperationDelegate(this.OnBeginAddLSEPayment);
            }
            if ((this.onEndAddLSEPaymentDelegate == null))
            {
                this.onEndAddLSEPaymentDelegate = new EndOperationDelegate(this.OnEndAddLSEPayment);
            }
            if ((this.onAddLSEPaymentCompletedDelegate == null))
            {
                this.onAddLSEPaymentCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnAddLSEPaymentCompleted);
            }
            base.InvokeAsync(this.onBeginAddLSEPaymentDelegate, new object[] {
                    CheckID,
                    PaymentOption,
                    Amount,
                    UserID}, this.onEndAddLSEPaymentDelegate, this.onAddLSEPaymentCompletedDelegate, userState);
        }

        public System.Collections.Generic.List<System.Collections.Generic.List<string>> GetLSEReportForDates(System.DateTime start, System.DateTime end)
        {
            return Channel.GetLSEReportForDates(start, end);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetLSEReportForDates(System.DateTime start, System.DateTime end, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetLSEReportForDates(start, end, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.Collections.Generic.List<System.Collections.Generic.List<string>> EndGetLSEReportForDates(System.IAsyncResult result)
        {
            return Channel.EndGetLSEReportForDates(result);
        }

        private System.IAsyncResult OnBeginGetLSEReportForDates(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            System.DateTime start = ((System.DateTime)(inValues[0]));
            System.DateTime end = ((System.DateTime)(inValues[1]));
            return this.BeginGetLSEReportForDates(start, end, callback, asyncState);
        }

        private object[] OnEndGetLSEReportForDates(System.IAsyncResult result)
        {
            System.Collections.Generic.List<System.Collections.Generic.List<string>> retVal = this.EndGetLSEReportForDates(result);
            return new object[] {
                retVal};
        }

        private void OnGetLSEReportForDatesCompleted(object state)
        {
            if ((this.GetLSEReportForDatesCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetLSEReportForDatesCompleted(this, new GetLSEReportForDatesCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void GetLSEReportForDatesAsync(System.DateTime start, System.DateTime end)
        {
            this.GetLSEReportForDatesAsync(start, end, null);
        }

        public void GetLSEReportForDatesAsync(System.DateTime start, System.DateTime end, object userState)
        {
            if ((this.onBeginGetLSEReportForDatesDelegate == null))
            {
                this.onBeginGetLSEReportForDatesDelegate = new BeginOperationDelegate(this.OnBeginGetLSEReportForDates);
            }
            if ((this.onEndGetLSEReportForDatesDelegate == null))
            {
                this.onEndGetLSEReportForDatesDelegate = new EndOperationDelegate(this.OnEndGetLSEReportForDates);
            }
            if ((this.onGetLSEReportForDatesCompletedDelegate == null))
            {
                this.onGetLSEReportForDatesCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetLSEReportForDatesCompleted);
            }
            base.InvokeAsync(this.onBeginGetLSEReportForDatesDelegate, new object[] {
                    start,
                    end}, this.onEndGetLSEReportForDatesDelegate, this.onGetLSEReportForDatesCompletedDelegate, userState);
        }

        public System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> GetLSEChecksWithPayments(System.DateTime start, System.DateTime end)
        {
            return Channel.GetLSEChecksWithPayments(start, end);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetLSEChecksWithPayments(System.DateTime start, System.DateTime end, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetLSEChecksWithPayments(start, end, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> EndGetLSEChecksWithPayments(System.IAsyncResult result)
        {
            return Channel.EndGetLSEChecksWithPayments(result);
        }

        private System.IAsyncResult OnBeginGetLSEChecksWithPayments(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            System.DateTime start = ((System.DateTime)(inValues[0]));
            System.DateTime end = ((System.DateTime)(inValues[1]));
            return this.BeginGetLSEChecksWithPayments(start, end, callback, asyncState);
        }

        private object[] OnEndGetLSEChecksWithPayments(System.IAsyncResult result)
        {
            System.Collections.Generic.List<Staunch.POS.Classes.DBCheck> retVal = this.EndGetLSEChecksWithPayments(result);
            return new object[] {
                retVal};
        }

        private void OnGetLSEChecksWithPaymentsCompleted(object state)
        {
            if ((this.GetLSEChecksWithPaymentsCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetLSEChecksWithPaymentsCompleted(this, new GetLSEChecksWithPaymentsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void GetLSEChecksWithPaymentsAsync(System.DateTime start, System.DateTime end)
        {
            this.GetLSEChecksWithPaymentsAsync(start, end, null);
        }

        public void GetLSEChecksWithPaymentsAsync(System.DateTime start, System.DateTime end, object userState)
        {
            if ((this.onBeginGetLSEChecksWithPaymentsDelegate == null))
            {
                this.onBeginGetLSEChecksWithPaymentsDelegate = new BeginOperationDelegate(this.OnBeginGetLSEChecksWithPayments);
            }
            if ((this.onEndGetLSEChecksWithPaymentsDelegate == null))
            {
                this.onEndGetLSEChecksWithPaymentsDelegate = new EndOperationDelegate(this.OnEndGetLSEChecksWithPayments);
            }
            if ((this.onGetLSEChecksWithPaymentsCompletedDelegate == null))
            {
                this.onGetLSEChecksWithPaymentsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetLSEChecksWithPaymentsCompleted);
            }
            base.InvokeAsync(this.onBeginGetLSEChecksWithPaymentsDelegate, new object[] {
                    start,
                    end}, this.onEndGetLSEChecksWithPaymentsDelegate, this.onGetLSEChecksWithPaymentsCompletedDelegate, userState);
        }

        public string UpdateCheckOrderItem(Staunch.POS.Classes.GuestItem order)
        {
            return Channel.UpdateCheckOrderItem(order);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginUpdateCheckOrderItem(Staunch.POS.Classes.GuestItem order, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginUpdateCheckOrderItem(order, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string EndUpdateCheckOrderItem(System.IAsyncResult result)
        {
            return Channel.EndUpdateCheckOrderItem(result);
        }

        private System.IAsyncResult OnBeginUpdateCheckOrderItem(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            Staunch.POS.Classes.GuestItem order = ((Staunch.POS.Classes.GuestItem)(inValues[0]));
            return this.BeginUpdateCheckOrderItem(order, callback, asyncState);
        }

        private object[] OnEndUpdateCheckOrderItem(System.IAsyncResult result)
        {
            string retVal = this.EndUpdateCheckOrderItem(result);
            return new object[] {
                retVal};
        }

        private void OnUpdateCheckOrderItemCompleted(object state)
        {
            if ((this.UpdateCheckOrderItemCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.UpdateCheckOrderItemCompleted(this, new UpdateCheckOrderItemCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void UpdateCheckOrderItemAsync(Staunch.POS.Classes.GuestItem order)
        {
            this.UpdateCheckOrderItemAsync(order, null);
        }

        public void UpdateCheckOrderItemAsync(Staunch.POS.Classes.GuestItem order, object userState)
        {
            if ((this.onBeginUpdateCheckOrderItemDelegate == null))
            {
                this.onBeginUpdateCheckOrderItemDelegate = new BeginOperationDelegate(this.OnBeginUpdateCheckOrderItem);
            }
            if ((this.onEndUpdateCheckOrderItemDelegate == null))
            {
                this.onEndUpdateCheckOrderItemDelegate = new EndOperationDelegate(this.OnEndUpdateCheckOrderItem);
            }
            if ((this.onUpdateCheckOrderItemCompletedDelegate == null))
            {
                this.onUpdateCheckOrderItemCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnUpdateCheckOrderItemCompleted);
            }
            base.InvokeAsync(this.onBeginUpdateCheckOrderItemDelegate, new object[] {
                    order}, this.onEndUpdateCheckOrderItemDelegate, this.onUpdateCheckOrderItemCompletedDelegate, userState);
        }

        public string InsertVoid(decimal checkID, string user, string manager, string reason)
        {
            return Channel.InsertVoid(checkID, user, manager, reason);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginInsertVoid(decimal checkID, string user, string manager, string reason, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginInsertVoid(checkID, user, manager, reason, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string EndInsertVoid(System.IAsyncResult result)
        {
            return Channel.EndInsertVoid(result);
        }

        private System.IAsyncResult OnBeginInsertVoid(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            decimal checkID = ((decimal)(inValues[0]));
            string user = ((string)(inValues[1]));
            string manager = ((string)(inValues[2]));
            string reason = ((string)(inValues[3]));
            return this.BeginInsertVoid(checkID, user, manager, reason, callback, asyncState);
        }

        private object[] OnEndInsertVoid(System.IAsyncResult result)
        {
            string retVal = this.EndInsertVoid(result);
            return new object[] {
                retVal};
        }

        private void OnInsertVoidCompleted(object state)
        {
            if ((this.InsertVoidCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.InsertVoidCompleted(this, new InsertVoidCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void InsertVoidAsync(decimal checkID, string user, string manager, string reason)
        {
            this.InsertVoidAsync(checkID, user, manager, reason, null);
        }

        public void InsertVoidAsync(decimal checkID, string user, string manager, string reason, object userState)
        {
            if ((this.onBeginInsertVoidDelegate == null))
            {
                this.onBeginInsertVoidDelegate = new BeginOperationDelegate(this.OnBeginInsertVoid);
            }
            if ((this.onEndInsertVoidDelegate == null))
            {
                this.onEndInsertVoidDelegate = new EndOperationDelegate(this.OnEndInsertVoid);
            }
            if ((this.onInsertVoidCompletedDelegate == null))
            {
                this.onInsertVoidCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnInsertVoidCompleted);
            }
            base.InvokeAsync(this.onBeginInsertVoidDelegate, new object[] {
                    checkID,
                    user,
                    manager,
                    reason}, this.onEndInsertVoidDelegate, this.onInsertVoidCompletedDelegate, userState);
        }

        public System.Collections.Generic.List<string> GetVoidsForDates(System.DateTime start, System.DateTime end)
        {
            return Channel.GetVoidsForDates(start, end);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetVoidsForDates(System.DateTime start, System.DateTime end, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginGetVoidsForDates(start, end, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.Collections.Generic.List<string> EndGetVoidsForDates(System.IAsyncResult result)
        {
            return Channel.EndGetVoidsForDates(result);
        }

        private System.IAsyncResult OnBeginGetVoidsForDates(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            System.DateTime start = ((System.DateTime)(inValues[0]));
            System.DateTime end = ((System.DateTime)(inValues[1]));
            return this.BeginGetVoidsForDates(start, end, callback, asyncState);
        }

        private object[] OnEndGetVoidsForDates(System.IAsyncResult result)
        {
            System.Collections.Generic.List<string> retVal = this.EndGetVoidsForDates(result);
            return new object[] {
                retVal};
        }

        private void OnGetVoidsForDatesCompleted(object state)
        {
            if ((this.GetVoidsForDatesCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetVoidsForDatesCompleted(this, new GetVoidsForDatesCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void GetVoidsForDatesAsync(System.DateTime start, System.DateTime end)
        {
            this.GetVoidsForDatesAsync(start, end, null);
        }

        public void GetVoidsForDatesAsync(System.DateTime start, System.DateTime end, object userState)
        {
            if ((this.onBeginGetVoidsForDatesDelegate == null))
            {
                this.onBeginGetVoidsForDatesDelegate = new BeginOperationDelegate(this.OnBeginGetVoidsForDates);
            }
            if ((this.onEndGetVoidsForDatesDelegate == null))
            {
                this.onEndGetVoidsForDatesDelegate = new EndOperationDelegate(this.OnEndGetVoidsForDates);
            }
            if ((this.onGetVoidsForDatesCompletedDelegate == null))
            {
                this.onGetVoidsForDatesCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetVoidsForDatesCompleted);
            }
            base.InvokeAsync(this.onBeginGetVoidsForDatesDelegate, new object[] {
                    start,
                    end}, this.onEndGetVoidsForDatesDelegate, this.onGetVoidsForDatesCompletedDelegate, userState);
        }

        public string AddCreditPayment(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID)
        {
            return Channel.AddCreditPayment(CheckID, PaymentOption, Amount, UserID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginAddCreditPayment(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginAddCreditPayment(CheckID, PaymentOption, Amount, UserID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string EndAddCreditPayment(System.IAsyncResult result)
        {
            return Channel.EndAddCreditPayment(result);
        }

        private System.IAsyncResult OnBeginAddCreditPayment(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            decimal CheckID = ((decimal)(inValues[0]));
            string PaymentOption = ((string)(inValues[1]));
            decimal Amount = ((decimal)(inValues[2]));
            decimal UserID = ((decimal)(inValues[3]));
            return this.BeginAddCreditPayment(CheckID, PaymentOption, Amount, UserID, callback, asyncState);
        }

        private object[] OnEndAddCreditPayment(System.IAsyncResult result)
        {
            string retVal = this.EndAddCreditPayment(result);
            return new object[] {
                retVal};
        }

        private void OnAddCreditPaymentCompleted(object state)
        {
            if ((this.AddCreditPaymentCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.AddCreditPaymentCompleted(this, new AddCreditPaymentCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void AddCreditPaymentAsync(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID)
        {
            this.AddCreditPaymentAsync(CheckID, PaymentOption, Amount, UserID, null);
        }

        public void AddCreditPaymentAsync(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID, object userState)
        {
            if ((this.onBeginAddCreditPaymentDelegate == null))
            {
                this.onBeginAddCreditPaymentDelegate = new BeginOperationDelegate(this.OnBeginAddCreditPayment);
            }
            if ((this.onEndAddCreditPaymentDelegate == null))
            {
                this.onEndAddCreditPaymentDelegate = new EndOperationDelegate(this.OnEndAddCreditPayment);
            }
            if ((this.onAddCreditPaymentCompletedDelegate == null))
            {
                this.onAddCreditPaymentCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnAddCreditPaymentCompleted);
            }
            base.InvokeAsync(this.onBeginAddCreditPaymentDelegate, new object[] {
                    CheckID,
                    PaymentOption,
                    Amount,
                    UserID}, this.onEndAddCreditPaymentDelegate, this.onAddCreditPaymentCompletedDelegate, userState);
        }

        public void PrintCateringReceipt(int CateringID)
        {
            Channel.PrintCateringReceipt(CateringID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginPrintCateringReceipt(int CateringID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginPrintCateringReceipt(CateringID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public void EndPrintCateringReceipt(System.IAsyncResult result)
        {
            Channel.EndPrintCateringReceipt(result);
        }

        private System.IAsyncResult OnBeginPrintCateringReceipt(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            int CateringID = ((int)(inValues[0]));
            return this.BeginPrintCateringReceipt(CateringID, callback, asyncState);
        }

        private object[] OnEndPrintCateringReceipt(System.IAsyncResult result)
        {
            this.EndPrintCateringReceipt(result);
            return null;
        }

        private void OnPrintCateringReceiptCompleted(object state)
        {
            if ((this.PrintCateringReceiptCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.PrintCateringReceiptCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }

        public void PrintCateringReceiptAsync(int CateringID)
        {
            this.PrintCateringReceiptAsync(CateringID, null);
        }

        public void PrintCateringReceiptAsync(int CateringID, object userState)
        {
            if ((this.onBeginPrintCateringReceiptDelegate == null))
            {
                this.onBeginPrintCateringReceiptDelegate = new BeginOperationDelegate(this.OnBeginPrintCateringReceipt);
            }
            if ((this.onEndPrintCateringReceiptDelegate == null))
            {
                this.onEndPrintCateringReceiptDelegate = new EndOperationDelegate(this.OnEndPrintCateringReceipt);
            }
            if ((this.onPrintCateringReceiptCompletedDelegate == null))
            {
                this.onPrintCateringReceiptCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnPrintCateringReceiptCompleted);
            }
            base.InvokeAsync(this.onBeginPrintCateringReceiptDelegate, new object[] {
                    CateringID}, this.onEndPrintCateringReceiptDelegate, this.onPrintCateringReceiptCompletedDelegate, userState);
        }

        public bool ClearDiscounts(decimal CheckID)
        {
            return Channel.ClearDiscounts(CheckID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginClearDiscounts(decimal CheckID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginClearDiscounts(CheckID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndClearDiscounts(System.IAsyncResult result)
        {
            return Channel.EndClearDiscounts(result);
        }

        private System.IAsyncResult OnBeginClearDiscounts(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            decimal CheckID = ((decimal)(inValues[0]));
            return this.BeginClearDiscounts(CheckID, callback, asyncState);
        }

        private object[] OnEndClearDiscounts(System.IAsyncResult result)
        {
            bool retVal = this.EndClearDiscounts(result);
            return new object[] {
                retVal};
        }

        private void OnClearDiscountsCompleted(object state)
        {
            if ((this.ClearDiscountsCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.ClearDiscountsCompleted(this, new ClearDiscountsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void ClearDiscountsAsync(decimal CheckID)
        {
            this.ClearDiscountsAsync(CheckID, null);
        }

        public void ClearDiscountsAsync(decimal CheckID, object userState)
        {
            if ((this.onBeginClearDiscountsDelegate == null))
            {
                this.onBeginClearDiscountsDelegate = new BeginOperationDelegate(this.OnBeginClearDiscounts);
            }
            if ((this.onEndClearDiscountsDelegate == null))
            {
                this.onEndClearDiscountsDelegate = new EndOperationDelegate(this.OnEndClearDiscounts);
            }
            if ((this.onClearDiscountsCompletedDelegate == null))
            {
                this.onClearDiscountsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnClearDiscountsCompleted);
            }
            base.InvokeAsync(this.onBeginClearDiscountsDelegate, new object[] {
                    CheckID}, this.onEndClearDiscountsDelegate, this.onClearDiscountsCompletedDelegate, userState);
        }

        public bool AddCateringPayment(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID)
        {
            return Channel.AddCateringPayment(CheckID, PaymentOption, Amount, UserID);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginAddCateringPayment(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginAddCateringPayment(CheckID, PaymentOption, Amount, UserID, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndAddCateringPayment(System.IAsyncResult result)
        {
            return Channel.EndAddCateringPayment(result);
        }

        private System.IAsyncResult OnBeginAddCateringPayment(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            decimal CheckID = ((decimal)(inValues[0]));
            string PaymentOption = ((string)(inValues[1]));
            decimal Amount = ((decimal)(inValues[2]));
            decimal UserID = ((decimal)(inValues[3]));
            return this.BeginAddCateringPayment(CheckID, PaymentOption, Amount, UserID, callback, asyncState);
        }

        private object[] OnEndAddCateringPayment(System.IAsyncResult result)
        {
            bool retVal = this.EndAddCateringPayment(result);
            return new object[] {
                retVal};
        }

        private void OnAddCateringPaymentCompleted(object state)
        {
            if ((this.AddCateringPaymentCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.AddCateringPaymentCompleted(this, new AddCateringPaymentCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void AddCateringPaymentAsync(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID)
        {
            this.AddCateringPaymentAsync(CheckID, PaymentOption, Amount, UserID, null);
        }

        public void AddCateringPaymentAsync(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID, object userState)
        {
            if ((this.onBeginAddCateringPaymentDelegate == null))
            {
                this.onBeginAddCateringPaymentDelegate = new BeginOperationDelegate(this.OnBeginAddCateringPayment);
            }
            if ((this.onEndAddCateringPaymentDelegate == null))
            {
                this.onEndAddCateringPaymentDelegate = new EndOperationDelegate(this.OnEndAddCateringPayment);
            }
            if ((this.onAddCateringPaymentCompletedDelegate == null))
            {
                this.onAddCateringPaymentCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnAddCateringPaymentCompleted);
            }
            base.InvokeAsync(this.onBeginAddCateringPaymentDelegate, new object[] {
                    CheckID,
                    PaymentOption,
                    Amount,
                    UserID}, this.onEndAddCateringPaymentDelegate, this.onAddCateringPaymentCompletedDelegate, userState);
        }

        public Staunch.POS.Classes.GuestItem PriceOrder(Staunch.POS.Classes.GuestItem item)
        {
            return Channel.PriceOrder(item);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginPriceOrder(Staunch.POS.Classes.GuestItem item, System.AsyncCallback callback, object asyncState)
        {
            return Channel.BeginPriceOrder(item, callback, asyncState);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public Staunch.POS.Classes.GuestItem EndPriceOrder(System.IAsyncResult result)
        {
            return Channel.EndPriceOrder(result);
        }

        private System.IAsyncResult OnBeginPriceOrder(object[] inValues, System.AsyncCallback callback, object asyncState)
        {
            Staunch.POS.Classes.GuestItem item = ((Staunch.POS.Classes.GuestItem)(inValues[0]));
            return this.BeginPriceOrder(item, callback, asyncState);
        }

        private object[] OnEndPriceOrder(System.IAsyncResult result)
        {
            Staunch.POS.Classes.GuestItem retVal = this.EndPriceOrder(result);
            return new object[] {
                retVal};
        }

        private void OnPriceOrderCompleted(object state)
        {
            if ((this.PriceOrderCompleted != null))
            {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.PriceOrderCompleted(this, new PriceOrderCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void PriceOrderAsync(Staunch.POS.Classes.GuestItem item)
        {
            this.PriceOrderAsync(item, null);
        }

        public void PriceOrderAsync(Staunch.POS.Classes.GuestItem item, object userState)
        {
            if ((this.onBeginPriceOrderDelegate == null))
            {
                this.onBeginPriceOrderDelegate = new BeginOperationDelegate(this.OnBeginPriceOrder);
            }
            if ((this.onEndPriceOrderDelegate == null))
            {
                this.onEndPriceOrderDelegate = new EndOperationDelegate(this.OnEndPriceOrder);
            }
            if ((this.onPriceOrderCompletedDelegate == null))
            {
                this.onPriceOrderCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnPriceOrderCompleted);
            }
            base.InvokeAsync(this.onBeginPriceOrderDelegate, new object[] {
                    item}, this.onEndPriceOrderDelegate, this.onPriceOrderCompletedDelegate, userState);
        }
        #endregion

        #region Delegates & Callbacks
        private BeginOperationDelegate onBeginCreateChecksDelegate;

        private EndOperationDelegate onEndCreateChecksDelegate;

        private System.Threading.SendOrPostCallback onCreateChecksCompletedDelegate;

        private BeginOperationDelegate onBeginUpdateCheckNotesDelegate;

        private EndOperationDelegate onEndUpdateCheckNotesDelegate;

        private System.Threading.SendOrPostCallback onUpdateCheckNotesCompletedDelegate;

        private BeginOperationDelegate onBeginUpdateOrderNotesDelegate;

        private EndOperationDelegate onEndUpdateOrderNotesDelegate;

        private System.Threading.SendOrPostCallback onUpdateOrderNotesCompletedDelegate;

        private BeginOperationDelegate onBeginGetOpenChecksDelegate;

        private EndOperationDelegate onEndGetOpenChecksDelegate;

        private System.Threading.SendOrPostCallback onGetOpenChecksCompletedDelegate;

        private BeginOperationDelegate onBeginGetChecksForOrderDelegate;

        private EndOperationDelegate onEndGetChecksForOrderDelegate;

        private System.Threading.SendOrPostCallback onGetChecksForOrderCompletedDelegate;

        private BeginOperationDelegate onBeginGetCheckCountDelegate;

        private EndOperationDelegate onEndGetCheckCountDelegate;

        private System.Threading.SendOrPostCallback onGetCheckCountCompletedDelegate;

        private BeginOperationDelegate onBeginCombineChecksDelegate;

        private EndOperationDelegate onEndCombineChecksDelegate;

        private System.Threading.SendOrPostCallback onCombineChecksCompletedDelegate;

        private BeginOperationDelegate onBeginSplitItemDelegate;

        private EndOperationDelegate onEndSplitItemDelegate;

        private System.Threading.SendOrPostCallback onSplitItemCompletedDelegate;

        private BeginOperationDelegate onBeginUpdateChecksDelegate;

        private EndOperationDelegate onEndUpdateChecksDelegate;

        private System.Threading.SendOrPostCallback onUpdateChecksCompletedDelegate;

        private BeginOperationDelegate onBeginMoveItemsDelegate;

        private EndOperationDelegate onEndMoveItemsDelegate;

        private System.Threading.SendOrPostCallback onMoveItemsCompletedDelegate;

        private BeginOperationDelegate onBeginHasOpenChecksDelegate;

        private EndOperationDelegate onEndHasOpenChecksDelegate;

        private System.Threading.SendOrPostCallback onHasOpenChecksCompletedDelegate;

        private BeginOperationDelegate onBeginAddPaymentDelegate;

        private EndOperationDelegate onEndAddPaymentDelegate;

        private System.Threading.SendOrPostCallback onAddPaymentCompletedDelegate;

        private BeginOperationDelegate onBeginAddGratuityDelegate;

        private EndOperationDelegate onEndAddGratuityDelegate;

        private System.Threading.SendOrPostCallback onAddGratuityCompletedDelegate;

        private BeginOperationDelegate onBeginPrintCheckforMobleDelegate;

        private EndOperationDelegate onEndPrintCheckforMobleDelegate;

        private System.Threading.SendOrPostCallback onPrintCheckforMobleCompletedDelegate;

        private BeginOperationDelegate onBeginPrintCheckforRegisterDelegate;

        private EndOperationDelegate onEndPrintCheckforRegisterDelegate;

        private System.Threading.SendOrPostCallback onPrintCheckforRegisterCompletedDelegate;

        private BeginOperationDelegate onBeginClearCheckDelegate;

        private EndOperationDelegate onEndClearCheckDelegate;

        private System.Threading.SendOrPostCallback onClearCheckCompletedDelegate;

        private BeginOperationDelegate onBeginGetCheckDelegate;

        private EndOperationDelegate onEndGetCheckDelegate;

        private System.Threading.SendOrPostCallback onGetCheckCompletedDelegate;

        private BeginOperationDelegate onBeginremoveOrderFromCheckDelegate;

        private EndOperationDelegate onEndremoveOrderFromCheckDelegate;

        private System.Threading.SendOrPostCallback onremoveOrderFromCheckCompletedDelegate;

        private BeginOperationDelegate onBeginPingDelegate;

        private EndOperationDelegate onEndPingDelegate;

        private System.Threading.SendOrPostCallback onPingCompletedDelegate;

        private BeginOperationDelegate onBeginOpenDrawerDelegate;

        private EndOperationDelegate onEndOpenDrawerDelegate;

        private System.Threading.SendOrPostCallback onOpenDrawerCompletedDelegate;

        private BeginOperationDelegate onBeginGetCashDrawerPortDelegate;

        private EndOperationDelegate onEndGetCashDrawerPortDelegate;

        private System.Threading.SendOrPostCallback onGetCashDrawerPortCompletedDelegate;

        private BeginOperationDelegate onBeginGetGrossSalesForTodayDelegate;

        private EndOperationDelegate onEndGetGrossSalesForTodayDelegate;

        private System.Threading.SendOrPostCallback onGetGrossSalesForTodayCompletedDelegate;

        private BeginOperationDelegate onBeginGetGrossSalesForDelegate;

        private EndOperationDelegate onEndGetGrossSalesForDelegate;

        private System.Threading.SendOrPostCallback onGetGrossSalesForCompletedDelegate;

        private BeginOperationDelegate onBeginGetTaxForDelegate;

        private EndOperationDelegate onEndGetTaxForDelegate;

        private System.Threading.SendOrPostCallback onGetTaxForCompletedDelegate;

        private BeginOperationDelegate onBeginGetTaxForTodayDelegate;

        private EndOperationDelegate onEndGetTaxForTodayDelegate;

        private System.Threading.SendOrPostCallback onGetTaxForTodayCompletedDelegate;

        private BeginOperationDelegate onBeginGetGratuityForDelegate;

        private EndOperationDelegate onEndGetGratuityForDelegate;

        private System.Threading.SendOrPostCallback onGetGratuityForCompletedDelegate;

        private BeginOperationDelegate onBeginGetGratuityForTodayDelegate;

        private EndOperationDelegate onEndGetGratuityForTodayDelegate;

        private System.Threading.SendOrPostCallback onGetGratuityForTodayCompletedDelegate;

        private BeginOperationDelegate onBeginGetDiscountsForDelegate;

        private EndOperationDelegate onEndGetDiscountsForDelegate;

        private System.Threading.SendOrPostCallback onGetDiscountsForCompletedDelegate;

        private BeginOperationDelegate onBeginGetChecksWithPaymentsDelegate;

        private EndOperationDelegate onEndGetChecksWithPaymentsDelegate;

        private System.Threading.SendOrPostCallback onGetChecksWithPaymentsCompletedDelegate;

        private BeginOperationDelegate onBeginPrintZReportDelegate;

        private EndOperationDelegate onEndPrintZReportDelegate;

        private System.Threading.SendOrPostCallback onPrintZReportCompletedDelegate;

        private BeginOperationDelegate onBeginGetSalesReportDelegate;

        private EndOperationDelegate onEndGetSalesReportDelegate;

        private System.Threading.SendOrPostCallback onGetSalesReportCompletedDelegate;

        private BeginOperationDelegate onBeginPrintSalesReportDelegate;

        private EndOperationDelegate onEndPrintSalesReportDelegate;

        private System.Threading.SendOrPostCallback onPrintSalesReportCompletedDelegate;

        private BeginOperationDelegate onBeginReopenCheckDelegate;

        private EndOperationDelegate onEndReopenCheckDelegate;

        private System.Threading.SendOrPostCallback onReopenCheckCompletedDelegate;

        private BeginOperationDelegate onBeginDeleteCheckDelegate;

        private EndOperationDelegate onEndDeleteCheckDelegate;

        private System.Threading.SendOrPostCallback onDeleteCheckCompletedDelegate;

        private BeginOperationDelegate onBeginRemoveOrderFromClosedCheckDelegate;

        private EndOperationDelegate onEndRemoveOrderFromClosedCheckDelegate;

        private System.Threading.SendOrPostCallback onRemoveOrderFromClosedCheckCompletedDelegate;

        private BeginOperationDelegate onBeginMoveCheckDelegate;

        private EndOperationDelegate onEndMoveCheckDelegate;

        private System.Threading.SendOrPostCallback onMoveCheckCompletedDelegate;

        private BeginOperationDelegate onBeginExportReportsDelegate;

        private EndOperationDelegate onEndExportReportsDelegate;

        private System.Threading.SendOrPostCallback onExportReportsCompletedDelegate;

        private BeginOperationDelegate onBeginUpdateTakeoutCheckDelegate;

        private EndOperationDelegate onEndUpdateTakeoutCheckDelegate;

        private System.Threading.SendOrPostCallback onUpdateTakeoutCheckCompletedDelegate;

        private BeginOperationDelegate onBeginUpdateCheckDiscountsDelegate;

        private EndOperationDelegate onEndUpdateCheckDiscountsDelegate;

        private System.Threading.SendOrPostCallback onUpdateCheckDiscountsCompletedDelegate;

        private BeginOperationDelegate onBeginCheckoutDelegate;

        private EndOperationDelegate onEndCheckoutDelegate;

        private System.Threading.SendOrPostCallback onCheckoutCompletedDelegate;

        private BeginOperationDelegate onBeginGetReportForDatesDelegate;

        private EndOperationDelegate onEndGetReportForDatesDelegate;

        private System.Threading.SendOrPostCallback onGetReportForDatesCompletedDelegate;

        private BeginOperationDelegate onBeginRemoveTaxDelegate;

        private EndOperationDelegate onEndRemoveTaxDelegate;

        private System.Threading.SendOrPostCallback onRemoveTaxCompletedDelegate;

        private BeginOperationDelegate onBeginCreateLSEChecksDelegate;

        private EndOperationDelegate onEndCreateLSEChecksDelegate;

        private System.Threading.SendOrPostCallback onCreateLSEChecksCompletedDelegate;

        private BeginOperationDelegate onBeginAddLSEPaymentDelegate;

        private EndOperationDelegate onEndAddLSEPaymentDelegate;

        private System.Threading.SendOrPostCallback onAddLSEPaymentCompletedDelegate;

        private BeginOperationDelegate onBeginGetLSEReportForDatesDelegate;

        private EndOperationDelegate onEndGetLSEReportForDatesDelegate;

        private System.Threading.SendOrPostCallback onGetLSEReportForDatesCompletedDelegate;

        private BeginOperationDelegate onBeginGetLSEChecksWithPaymentsDelegate;

        private EndOperationDelegate onEndGetLSEChecksWithPaymentsDelegate;

        private System.Threading.SendOrPostCallback onGetLSEChecksWithPaymentsCompletedDelegate;

        private BeginOperationDelegate onBeginUpdateCheckOrderItemDelegate;

        private EndOperationDelegate onEndUpdateCheckOrderItemDelegate;

        private System.Threading.SendOrPostCallback onUpdateCheckOrderItemCompletedDelegate;

        private BeginOperationDelegate onBeginInsertVoidDelegate;

        private EndOperationDelegate onEndInsertVoidDelegate;

        private System.Threading.SendOrPostCallback onInsertVoidCompletedDelegate;

        private BeginOperationDelegate onBeginGetVoidsForDatesDelegate;

        private EndOperationDelegate onEndGetVoidsForDatesDelegate;

        private System.Threading.SendOrPostCallback onGetVoidsForDatesCompletedDelegate;

        private BeginOperationDelegate onBeginAddCreditPaymentDelegate;

        private EndOperationDelegate onEndAddCreditPaymentDelegate;

        private System.Threading.SendOrPostCallback onAddCreditPaymentCompletedDelegate;

        private BeginOperationDelegate onBeginPrintCateringReceiptDelegate;

        private EndOperationDelegate onEndPrintCateringReceiptDelegate;

        private System.Threading.SendOrPostCallback onPrintCateringReceiptCompletedDelegate;

        private BeginOperationDelegate onBeginClearDiscountsDelegate;

        private EndOperationDelegate onEndClearDiscountsDelegate;

        private System.Threading.SendOrPostCallback onClearDiscountsCompletedDelegate;

        private BeginOperationDelegate onBeginAddCateringPaymentDelegate;

        private EndOperationDelegate onEndAddCateringPaymentDelegate;

        private System.Threading.SendOrPostCallback onAddCateringPaymentCompletedDelegate;

        private BeginOperationDelegate onBeginPriceOrderDelegate;

        private EndOperationDelegate onEndPriceOrderDelegate;

        private System.Threading.SendOrPostCallback onPriceOrderCompletedDelegate;
        #endregion

        #region EventHandlers
        public event System.EventHandler<CreateChecksCompletedEventArgs> CreateChecksCompleted;

        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> UpdateCheckNotesCompleted;

        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> UpdateOrderNotesCompleted;

        public event System.EventHandler<GetOpenChecksCompletedEventArgs> GetOpenChecksCompleted;

        public event System.EventHandler<GetChecksForOrderCompletedEventArgs> GetChecksForOrderCompleted;

        public event System.EventHandler<GetCheckCountCompletedEventArgs> GetCheckCountCompleted;

        public event System.EventHandler<CombineChecksCompletedEventArgs> CombineChecksCompleted;

        public event System.EventHandler<SplitItemCompletedEventArgs> SplitItemCompleted;

        public event System.EventHandler<UpdateChecksCompletedEventArgs> UpdateChecksCompleted;

        public event System.EventHandler<MoveItemsCompletedEventArgs> MoveItemsCompleted;

        public event System.EventHandler<HasOpenChecksCompletedEventArgs> HasOpenChecksCompleted;

        public event System.EventHandler<AddPaymentCompletedEventArgs> AddPaymentCompleted;

        public event System.EventHandler<AddGratuityCompletedEventArgs> AddGratuityCompleted;

        public event System.EventHandler<PrintCheckforMobleCompletedEventArgs> PrintCheckforMobleCompleted;

        public event System.EventHandler<PrintCheckforRegisterCompletedEventArgs> PrintCheckforRegisterCompleted;

        public event System.EventHandler<ClearCheckCompletedEventArgs> ClearCheckCompleted;

        public event System.EventHandler<GetCheckCompletedEventArgs> GetCheckCompleted;

        public event System.EventHandler<removeOrderFromCheckCompletedEventArgs> removeOrderFromCheckCompleted;

        public event System.EventHandler<PingCompletedEventArgs> PingCompleted;

        public event System.EventHandler<OpenDrawerCompletedEventArgs> OpenDrawerCompleted;

        public event System.EventHandler<GetCashDrawerPortCompletedEventArgs> GetCashDrawerPortCompleted;

        public event System.EventHandler<GetGrossSalesForTodayCompletedEventArgs> GetGrossSalesForTodayCompleted;

        public event System.EventHandler<GetGrossSalesForCompletedEventArgs> GetGrossSalesForCompleted;

        public event System.EventHandler<GetTaxForCompletedEventArgs> GetTaxForCompleted;

        public event System.EventHandler<GetTaxForTodayCompletedEventArgs> GetTaxForTodayCompleted;

        public event System.EventHandler<GetGratuityForCompletedEventArgs> GetGratuityForCompleted;

        public event System.EventHandler<GetGratuityForTodayCompletedEventArgs> GetGratuityForTodayCompleted;

        public event System.EventHandler<GetDiscountsForCompletedEventArgs> GetDiscountsForCompleted;

        public event System.EventHandler<GetChecksWithPaymentsCompletedEventArgs> GetChecksWithPaymentsCompleted;

        public event System.EventHandler<PrintZReportCompletedEventArgs> PrintZReportCompleted;

        public event System.EventHandler<GetSalesReportCompletedEventArgs> GetSalesReportCompleted;

        public event System.EventHandler<PrintSalesReportCompletedEventArgs> PrintSalesReportCompleted;

        public event System.EventHandler<ReopenCheckCompletedEventArgs> ReopenCheckCompleted;

        public event System.EventHandler<DeleteCheckCompletedEventArgs> DeleteCheckCompleted;

        public event System.EventHandler<RemoveOrderFromClosedCheckCompletedEventArgs> RemoveOrderFromClosedCheckCompleted;

        public event System.EventHandler<MoveCheckCompletedEventArgs> MoveCheckCompleted;

        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> ExportReportsCompleted;

        public event System.EventHandler<UpdateTakeoutCheckCompletedEventArgs> UpdateTakeoutCheckCompleted;

        public event System.EventHandler<UpdateCheckDiscountsCompletedEventArgs> UpdateCheckDiscountsCompleted;

        public event System.EventHandler<CheckoutCompletedEventArgs> CheckoutCompleted;

        public event System.EventHandler<GetReportForDatesCompletedEventArgs> GetReportForDatesCompleted;

        public event System.EventHandler<RemoveTaxCompletedEventArgs> RemoveTaxCompleted;

        public event System.EventHandler<CreateLSEChecksCompletedEventArgs> CreateLSEChecksCompleted;

        public event System.EventHandler<AddLSEPaymentCompletedEventArgs> AddLSEPaymentCompleted;

        public event System.EventHandler<GetLSEReportForDatesCompletedEventArgs> GetLSEReportForDatesCompleted;

        public event System.EventHandler<GetLSEChecksWithPaymentsCompletedEventArgs> GetLSEChecksWithPaymentsCompleted;

        public event System.EventHandler<UpdateCheckOrderItemCompletedEventArgs> UpdateCheckOrderItemCompleted;

        public event System.EventHandler<InsertVoidCompletedEventArgs> InsertVoidCompleted;

        public event System.EventHandler<GetVoidsForDatesCompletedEventArgs> GetVoidsForDatesCompleted;

        public event System.EventHandler<AddCreditPaymentCompletedEventArgs> AddCreditPaymentCompleted;

        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> PrintCateringReceiptCompleted;

        public event System.EventHandler<ClearDiscountsCompletedEventArgs> ClearDiscountsCompleted;

        public event System.EventHandler<AddCateringPaymentCompletedEventArgs> AddCateringPaymentCompleted;

        public event System.EventHandler<PriceOrderCompletedEventArgs> PriceOrderCompleted;
        #endregion

        //********************************************************************************************************************

        private class CheckHostChannel : ChannelBase<ICheckHost>, ICheckHost
        {

            public CheckHostChannel(System.ServiceModel.ClientBase<ICheckHost> client) : base(client)
            {

            }

            public string CreateChecks(List<DBCheck> CheckList, decimal UserID, bool forTakeout)
            {
                object[] args = new object[3];
                args[0] = CheckList;
                args[1] = UserID;
                args[2] = forTakeout;
                return (string)base.Invoke("CreateChecks", args);
            }

            public IAsyncResult BeginCreateChecks(List<DBCheck> CheckList, decimal UserID, bool forTakeout, AsyncCallback callback, object asyncState)
            {
                object[] args = new object[3];
                args[0] = CheckList;
                args[1] = UserID;
                args[2] = forTakeout;
                return (IAsyncResult)base.BeginInvoke("CreateChecks", args, callback, asyncState);
            }

            public string EndCreateChecks(IAsyncResult result)
            {
                object[] args = new object[0];
                return (string)base.EndInvoke("CreateChecks", args, result);
            }

            public List<DBCheck> GetOpenChecks(decimal TableID)
            {
                object[] args = new object[1];
                args[0] = TableID;
              
                return (List<DBCheck>)base.Invoke("GetOpenChecks", args);
            }

            public IAsyncResult BeginGetOpenChecks(decimal TableID, AsyncCallback callback, object asyncState)
            {
                object[] args = new object[1];
                args[0] = TableID;
                return (IAsyncResult)base.BeginInvoke("GetOpenChecks", args, callback, asyncState);
            }

            public List<DBCheck> EndGetOpenChecks(IAsyncResult result)
            {
                object[] args = new object[0];
                return (List<DBCheck>)base.EndInvoke("GetOpenChecks", args, result);
            }

            public bool HasOpenChecks(decimal TableID)
            {
                object[] args = new object[1];
                args[0] = TableID;

                return (bool)base.Invoke("HasOpenChecks", args);
            }

            public IAsyncResult BeginHasOpenChecks(decimal TableID, AsyncCallback callback, object asyncState)
            {
                object[] args = new object[1];
                args[0] = TableID;

                return (IAsyncResult)base.BeginInvoke("HasOpenChecks", args, callback, asyncState);
            }

            public bool EndHasOpenChecks(IAsyncResult result)
            {
                object[] args = new object[0];
                return (bool)base.EndInvoke("HasOpenChecks", args, result);
            }

            public GuestItem PriceOrder(GuestItem item)
            {
                object[] args = new object[1];
                args[0] = item;

                return (GuestItem)base.Invoke("PriceOrder", args);
            }

            public IAsyncResult BeginPriceOrder(GuestItem item, AsyncCallback callback, object asyncState)
            {
                object[] args = new object[1];
                args[0] = item;

                return (IAsyncResult)base.BeginInvoke("PriceOrder", args, callback, asyncState);
            }

            public GuestItem EndPriceOrder(IAsyncResult result)
            {
                object[] args = new object[0];
                return (GuestItem)base.EndInvoke("PriceOrder", args, result);
            }

            //***********************************************************************************************************
            #region Not Implemented
            public bool AddCateringPayment(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID)
            {
                throw new NotImplementedException();
            }

            public string AddCreditPayment(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID)
            {
                throw new NotImplementedException();
            }

            public bool AddGratuity(decimal CheckID, decimal Amount, decimal UserID)
            {
                throw new NotImplementedException();
            }

            public bool AddLSEPayment(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID)
            {
                throw new NotImplementedException();
            }

            public bool AddPayment(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginAddCateringPayment(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginAddCreditPayment(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginAddGratuity(decimal CheckID, decimal Amount, decimal UserID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginAddLSEPayment(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginAddPayment(decimal CheckID, string PaymentOption, decimal Amount, decimal UserID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginCheckout(decimal checkId, List<decimal> guestIds, decimal tableId, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginClearCheck(decimal CheckID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginClearDiscounts(decimal CheckID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginCombineChecks(decimal CheckID1, decimal CheckID2, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            
            public IAsyncResult BeginCreateLSEChecks(List<DBCheck> CheckList, decimal UserID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginDeleteCheck(DBCheck CheckToDelete, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginExportReports(DateTime start, DateTime end, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetCashDrawerPort(decimal ActionID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetCheck(decimal CheckID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetCheckCount(decimal OrderID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetChecksForOrder(decimal OrderID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetChecksWithPayments(DateTime start, DateTime end, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetDiscountsFor(DateTime Start, DateTime End, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetGratuityFor(DateTime Start, DateTime End, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetGratuityForToday(AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetGrossSalesFor(DateTime Start, DateTime End, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetGrossSalesForToday(AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetLSEChecksWithPayments(DateTime start, DateTime end, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetLSEReportForDates(DateTime start, DateTime end, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

          
            public IAsyncResult BeginGetReportForDates(DateTime start, DateTime end, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetSalesReport(DateTime start, DateTime end, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetTaxFor(DateTime Start, DateTime End, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetTaxForToday(AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginGetVoidsForDates(DateTime start, DateTime end, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            
            public IAsyncResult BeginInsertVoid(decimal checkID, string user, string manager, string reason, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginMoveCheck(decimal CheckID, decimal NewTableID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginMoveItems(Dictionary<decimal, List<decimal>> Items, decimal newCheckID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginOpenDrawer(decimal actionID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginPing(AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }


            public IAsyncResult BeginPrintCateringReceipt(int CateringID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginPrintCheckforMoble(List<decimal> CheckIDs, decimal UserID, bool isReceipt, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginPrintCheckforRegister(List<decimal> CheckIDs, decimal UserID, bool isReceipt, int copies, decimal actionID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginPrintSalesReport(decimal UserID, DateTime start, DateTime end, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginPrintZReport(decimal UserID, DateTime start, DateTime end, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginremoveOrderFromCheck(decimal OrderID, decimal CheckID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginRemoveOrderFromClosedCheck(decimal OrderID, decimal CheckID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginRemoveTax(decimal CheckID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginReopenCheck(decimal CheckID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginSplitItem(decimal OrderID, List<decimal> CheckIDs, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginUpdateCheckDiscounts(List<OrderDiscount> discounts, bool taxable, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginUpdateCheckNotes(DBNotes Notes, decimal CheckID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginUpdateCheckOrderItem(GuestItem order, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginUpdateChecks(List<DBCheck> Checks, decimal UserID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginUpdateOrderNotes(DBNotes Notes, decimal OrderID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public IAsyncResult BeginUpdateTakeoutCheck(DBCheck check, decimal UserID, AsyncCallback callback, object asyncState)
            {
                throw new NotImplementedException();
            }

            public string Checkout(decimal checkId, List<decimal> guestIds, decimal tableId)
            {
                throw new NotImplementedException();
            }

            public bool ClearCheck(decimal CheckID)
            {
                throw new NotImplementedException();
            }

            public bool ClearDiscounts(decimal CheckID)
            {
                throw new NotImplementedException();
            }

            public bool CombineChecks(decimal CheckID1, decimal CheckID2)
            {
                throw new NotImplementedException();
            }

           
            public List<decimal> CreateLSEChecks(List<DBCheck> CheckList, decimal UserID)
            {
                throw new NotImplementedException();
            }

            public string DeleteCheck(DBCheck CheckToDelete)
            {
                throw new NotImplementedException();
            }

            public bool EndAddCateringPayment(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public string EndAddCreditPayment(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool EndAddGratuity(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool EndAddLSEPayment(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool EndAddPayment(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public string EndCheckout(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool EndClearCheck(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool EndClearDiscounts(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool EndCombineChecks(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

           

            public List<decimal> EndCreateLSEChecks(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public string EndDeleteCheck(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public void EndExportReports(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public string EndGetCashDrawerPort(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public DBCheck EndGetCheck(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public int EndGetCheckCount(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public List<decimal> EndGetChecksForOrder(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public List<DBCheck> EndGetChecksWithPayments(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public decimal EndGetDiscountsFor(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public decimal EndGetGratuityFor(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public decimal EndGetGratuityForToday(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public Dictionary<string, decimal> EndGetGrossSalesFor(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public Dictionary<string, decimal> EndGetGrossSalesForToday(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public List<DBCheck> EndGetLSEChecksWithPayments(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public List<List<string>> EndGetLSEReportForDates(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            
            public List<List<string>> EndGetReportForDates(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public Dictionary<string, decimal> EndGetSalesReport(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public decimal EndGetTaxFor(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public decimal EndGetTaxForToday(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public List<string> EndGetVoidsForDates(IAsyncResult result)
            {
                throw new NotImplementedException();
            }


            public string EndInsertVoid(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool EndMoveCheck(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool EndMoveItems(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public string EndOpenDrawer(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public int EndPing(IAsyncResult result)
            {
                throw new NotImplementedException();
            }


            public void EndPrintCateringReceipt(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool EndPrintCheckforMoble(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool EndPrintCheckforRegister(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public string EndPrintSalesReport(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public string EndPrintZReport(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool EndremoveOrderFromCheck(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool EndRemoveOrderFromClosedCheck(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public string EndRemoveTax(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool EndReopenCheck(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool EndSplitItem(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public string EndUpdateCheckDiscounts(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public void EndUpdateCheckNotes(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public string EndUpdateCheckOrderItem(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool EndUpdateChecks(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public void EndUpdateOrderNotes(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public bool EndUpdateTakeoutCheck(IAsyncResult result)
            {
                throw new NotImplementedException();
            }

            public void ExportReports(DateTime start, DateTime end)
            {
                throw new NotImplementedException();
            }

            public string GetCashDrawerPort(decimal ActionID)
            {
                throw new NotImplementedException();
            }

            public DBCheck GetCheck(decimal CheckID)
            {
                throw new NotImplementedException();
            }

            public int GetCheckCount(decimal OrderID)
            {
                throw new NotImplementedException();
            }

            public List<decimal> GetChecksForOrder(decimal OrderID)
            {
                throw new NotImplementedException();
            }

            public List<DBCheck> GetChecksWithPayments(DateTime start, DateTime end)
            {
                throw new NotImplementedException();
            }

            public decimal GetDiscountsFor(DateTime Start, DateTime End)
            {
                throw new NotImplementedException();
            }

            public decimal GetGratuityFor(DateTime Start, DateTime End)
            {
                throw new NotImplementedException();
            }

            public decimal GetGratuityForToday()
            {
                throw new NotImplementedException();
            }

            public Dictionary<string, decimal> GetGrossSalesFor(DateTime Start, DateTime End)
            {
                throw new NotImplementedException();
            }

            public Dictionary<string, decimal> GetGrossSalesForToday()
            {
                throw new NotImplementedException();
            }

            public List<DBCheck> GetLSEChecksWithPayments(DateTime start, DateTime end)
            {
                throw new NotImplementedException();
            }

            public List<List<string>> GetLSEReportForDates(DateTime start, DateTime end)
            {
                throw new NotImplementedException();
            }

           

            public List<List<string>> GetReportForDates(DateTime start, DateTime end)
            {
                throw new NotImplementedException();
            }

            public Dictionary<string, decimal> GetSalesReport(DateTime start, DateTime end)
            {
                throw new NotImplementedException();
            }

            public decimal GetTaxFor(DateTime Start, DateTime End)
            {
                throw new NotImplementedException();
            }

            public decimal GetTaxForToday()
            {
                throw new NotImplementedException();
            }

            public List<string> GetVoidsForDates(DateTime start, DateTime end)
            {
                throw new NotImplementedException();
            }


            public string InsertVoid(decimal checkID, string user, string manager, string reason)
            {
                throw new NotImplementedException();
            }

            public bool MoveCheck(decimal CheckID, decimal NewTableID)
            {
                throw new NotImplementedException();
            }

            public bool MoveItems(Dictionary<decimal, List<decimal>> Items, decimal newCheckID)
            {
                throw new NotImplementedException();
            }

            public string OpenDrawer(decimal actionID)
            {
                throw new NotImplementedException();
            }

            public int Ping()
            {
                throw new NotImplementedException();
            }


            public void PrintCateringReceipt(int CateringID)
            {
                throw new NotImplementedException();
            }

            public bool PrintCheckforMoble(List<decimal> CheckIDs, decimal UserID, bool isReceipt)
            {
                throw new NotImplementedException();
            }

            public bool PrintCheckforRegister(List<decimal> CheckIDs, decimal UserID, bool isReceipt, int copies, decimal actionID)
            {
                throw new NotImplementedException();
            }

            public string PrintSalesReport(decimal UserID, DateTime start, DateTime end)
            {
                throw new NotImplementedException();
            }

            public string PrintZReport(decimal UserID, DateTime start, DateTime end)
            {
                throw new NotImplementedException();
            }

            public bool removeOrderFromCheck(decimal OrderID, decimal CheckID)
            {
                throw new NotImplementedException();
            }

            public bool RemoveOrderFromClosedCheck(decimal OrderID, decimal CheckID)
            {
                throw new NotImplementedException();
            }

            public string RemoveTax(decimal CheckID)
            {
                throw new NotImplementedException();
            }

            public bool ReopenCheck(decimal CheckID)
            {
                throw new NotImplementedException();
            }

            public bool SplitItem(decimal OrderID, List<decimal> CheckIDs)
            {
                throw new NotImplementedException();
            }

            public string UpdateCheckDiscounts(List<OrderDiscount> discounts, bool taxable)
            {
                throw new NotImplementedException();
            }

            public void UpdateCheckNotes(DBNotes Notes, decimal CheckID)
            {
                throw new NotImplementedException();
            }

            public string UpdateCheckOrderItem(GuestItem order)
            {
                throw new NotImplementedException();
            }

            public bool UpdateChecks(List<DBCheck> Checks, decimal UserID)
            {
                throw new NotImplementedException();
            }

            public void UpdateOrderNotes(DBNotes Notes, decimal OrderID)
            {
                throw new NotImplementedException();
            }

            public bool UpdateTakeoutCheck(DBCheck check, decimal UserID)
            {
                throw new NotImplementedException();
            }
            #endregion
        }

    }
}