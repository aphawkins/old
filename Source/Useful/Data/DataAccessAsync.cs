// -----------------------------------------------------------------------
// <copyright file="AccessClass.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace BookMan.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Data;
    using System.Globalization;
    using System.Threading;

    //public delegate void GetPersonDatasetCompletedEventHandler(object sender, GetPersonDatasetEventArgs e);

    // This class implements the Event-based Asynchronous Pattern.
    // It asynchronously computes whether a number is prime or
    // composite (not prime).
    public partial class DataAccess
    {
        private delegate void WorkerEventHandler(int personId, AsyncOperation asyncOp);

        private SendOrPostCallback onCompletedDelegate;

        private HybridDictionary userStateToLifetime = new HybridDictionary();
        
        public event EventHandler<GetPersonDatasetEventArgs> GetPersonDatasetCompleted;

        private void InitializeAsync()
        {
            this.onCompletedDelegate = new SendOrPostCallback(CalculateCompleted);
        }

        // This method starts an asynchronous calculation. 
        // First, it checks the supplied task ID for uniqueness.
        // If taskId is unique, it creates a new WorkerEventHandler 
        // and calls its BeginInvoke method to start the calculation.
        public void GetPersonAsync(int personId, object taskId)
        {
            // Create an AsyncOperation for taskId.
            AsyncOperation asyncOp = AsyncOperationManager.CreateOperation(taskId);

            // Multiple threads will access the task dictionary,
            // so it must be locked to serialize access.
            lock (userStateToLifetime.SyncRoot)
            {
                if (userStateToLifetime.Contains(taskId))
                {
                    throw new ArgumentException("Task ID parameter must be unique", "taskId");
                }

                userStateToLifetime[taskId] = asyncOp;
            }

            // Start the asynchronous operation.
            WorkerEventHandler workerDelegate = new WorkerEventHandler(CalculateWorker);
            workerDelegate.BeginInvoke(personId, asyncOp, null, null);
        }
        
        // This method cancels a pending asynchronous operation.
        public void CancelAsync(object taskId)
        {
            AsyncOperation asyncOp = userStateToLifetime[taskId] as AsyncOperation;
            if (asyncOp == null)
            {
                return;
            }

            lock (userStateToLifetime.SyncRoot)
            {
                userStateToLifetime.Remove(taskId);
            }
        }

        // Utility method for determining if a 
        // task has been canceled.
        private bool TaskCanceled(object taskId)
        {
            return (userStateToLifetime[taskId] == null);
        }

        // This method performs the actual prime number computation.
        // It is executed on the worker thread.
        private void CalculateWorker(int personId, AsyncOperation asyncOp)
        {
            DataSet personDataset = null;
            Exception e = null;

            // Check that the task is still active.
            // The operation may have been canceled before
            // the thread was scheduled.
            if (!TaskCanceled(asyncOp.UserSuppliedState))
            {
                try
                {
                    personDataset = DataAccess.GetPerson(personId);
                }
                catch (Exception ex)
                {
                    e = ex;
                }
            }

            this.CompletionMethod(personId, personDataset, e, TaskCanceled(asyncOp.UserSuppliedState), asyncOp);
        }

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void CalculateCompleted(object operationState)
        {
            GetPersonDatasetEventArgs e = operationState as GetPersonDatasetEventArgs;

            OnGetPersonDatasetCompleted(e);
        }

        private void OnGetPersonDatasetCompleted(GetPersonDatasetEventArgs e)
        {
            if (GetPersonDatasetCompleted != null)
            {
                GetPersonDatasetCompleted(this, e);
            }
        }

        // This is the method that the underlying, free-threaded 
        // asynchronous behavior will invoke.  This will happen on
        // an arbitrary thread.
        private void CompletionMethod(int personId, DataSet personDataset, Exception exception, bool canceled, AsyncOperation asyncOp)
        {
            // If the task was not previously canceled,
            // remove the task from the lifetime collection.
            if (!canceled)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    if (asyncOp.UserSuppliedState != null)
                    {
                        userStateToLifetime.Remove(asyncOp.UserSuppliedState);
                    }
                }
            }

            // Package the results of the operation in a 
            // CalculatePrimeCompletedEventArgs.
            GetPersonDatasetEventArgs e = new GetPersonDatasetEventArgs(personId, personDataset, exception, canceled, asyncOp.UserSuppliedState);

            // End the task. The asyncOp object is responsible 
            // for marshaling the call.
            asyncOp.PostOperationCompleted(onCompletedDelegate, e);

            // Note that after the call to OperationCompleted, 
            // asyncOp is no longer usable, and any attempt to use it
            // will cause an exception to be thrown.
        }
    }

    public class GetPersonDatasetEventArgs : AsyncCompletedEventArgs
    {
        private int personIdValue = 0;
        private DataSet personDatasetValue = null;

        public GetPersonDatasetEventArgs(int personId, DataSet personDataset, Exception e, bool canceled, object state)
            : base(e, canceled, state)
        {
            this.personIdValue = personId;
            this.personDatasetValue = personDataset;
        }

        public int PersonId
        {
            get
            {
                // Raise an exception if the operation failed or was canceled.
                RaiseExceptionIfNecessary();

                // If the operation was successful, return the property value.
                return this.personIdValue;
            }
        }

        public DataSet PersonDataset
        {
            get
            {
                // Raise an exception if the operation failed or was canceled.
                RaiseExceptionIfNecessary();

                // If the operation was successful, return the property value.
                return this.personDatasetValue;
            }
        }
    }
}

