using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Towertycg_APP.Methods;

namespace Towertycg_APP.Components
{
    public partial class APIComponent : Field4Component
    {
        public List<Field4Component> Field4Components { get; set; }
        private APIMethod APIMethod { get; set; }
        public APIComponent(List<Field4Component> field4Components, APIMethod aPIMethod)
        {
            InitializeComponent();
            Field4Components = field4Components;
            APIMethod = aPIMethod;
        }

        public APIComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        protected override void AfterMyWorkStateChanged(object sender, EventArgs e)
        {
            if (myWorkState)
            {
                ReadTime = DateTime.Now;
                ReadThread = new Thread(Analysis);
                ReadThread.Start();
            }
            else
            {
                if (ReadThread != null)
                {
                    ReadThread.Abort();
                }
            }
        }
        private void Analysis()
        {
            while (myWorkState)
            {
                TimeSpan ReadSpan = DateTime.Now.Subtract(ReadTime);
                if (ReadSpan.TotalMilliseconds >= 60000)
                {
                    try
                    {
                        if (Field4Components != null)
                        {
                            foreach (var item in Field4Components)
                            {
                                if (item.UpdateClass != null)
                                {
                                    if (myWorkState)
                                    {
                                        APIMethod.Post_Realtime_Data(item.UpdateClass);
                                        Thread.Sleep(10);
                                    }
                                    ReadTime = DateTime.Now;
                                }
                                else
                                {
                                    Thread.Sleep(80);
                                }
                            }
                        }
                    }
                    catch (ThreadAbortException) { }
                    catch (Exception ex)
                    {
                        Log.Error(ex, "API上傳失敗");
                    }
                }
                else
                {
                    Thread.Sleep(80);
                }
            }
        }
    }
}
