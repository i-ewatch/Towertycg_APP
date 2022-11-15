using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using Serilog;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Towertycg_APP.Components;
using Towertycg_APP.Configuration;
using Towertycg_APP.Enums;
using Towertycg_APP.Methods;
using Towertycg_APP.Modules;
using Towertycg_APP.Protocols;
using Towertycg_APP.Views;

namespace Towertycg_APP
{
    public partial class Form1 : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        /// <summary>
        /// 彈跳視窗
        /// </summary>
        public FlyoutAction action = new FlyoutAction();
        /// <summary>
        /// 登入旗標
        /// </summary>
        public bool LoginFlag { get; set; }
        /// <summary>
        /// 設定登出時間(ms)
        /// </summary>
        private int LogoutTime { get; set; } = 100000;
        /// <summary>
        /// 登入時間
        /// </summary>
        private DateTime LoginTime { get; set; }
        #region 基本資訊
        /// <summary>
        /// 讀取系統資訊
        /// </summary>
        private SystemSetting SystemSetting { get; set; }
        /// <summary>
        /// 讀取API資訊
        /// </summary>
        private APISetting APISetting { get; set; }
        /// <summary>
        /// 讀取群組資訊
        /// </summary>
        private GroupSetting GroupSetting { get; set; }
        /// <summary>
        /// 推播資訊
        /// </summary>
        private List<NotifySetting> NotifySettings { get; set; }
        #endregion
        #region 方法
        /// <summary>
        /// Excel檔案匯入方法
        /// </summary>
        private ExcelMethod ExcelMethod = new ExcelMethod();
        /// <summary>
        /// API方法
        /// </summary>
        private APIMethod APIMethod { get; set; }
        /// <summary>
        /// 總上傳資訊
        /// </summary>
        private List<UpdateClass> UpdateClasses = new List<UpdateClass>();
        #endregion
        #region 通訊
        /// <summary>
        /// 總通訊物件
        /// </summary>
        private List<Field4Component> Field4Components { get; set; } = new List<Field4Component>();
        /// <summary>
        /// 總設備數值物件
        /// </summary>
        private List<AbsProtocol> AbsProtocols { get; set; } = new List<AbsProtocol>();
        /// <summary>
        /// API上傳物件
        /// </summary>
        private APIComponent APIComponent { get; set; }
        #endregion
        #region 畫面
        /// <summary>
        /// 總畫面物件
        /// </summary>
        List<Field4Control> Field4Controls { get; set; } = new List<Field4Control>();
        #endregion
        public Form1()
        {
            InitializeComponent();
            CloseBox = false;
            MaximizeBox = false;
            #region Serilog
            Log.Logger = new LoggerConfiguration()
                       .WriteTo.Console()
                       .WriteTo.File(path: $"{AppDomain.CurrentDomain.BaseDirectory}\\log\\log.txt",
                                     rollingInterval: RollingInterval.Day,
                                     outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                       .CreateLogger();        //宣告Serilog初始化
            #endregion
            SystemSetting = InitialMethod.System_Load();
            APISetting = InitialMethod.API_Load();
            GroupSetting = InitialMethod.Group_Load();
            NotifySettings = InitialMethod.Notify_Load();
            APIMethod = new APIMethod(APISetting.URL, "");
            #region 建立通訊
            if (SystemSetting != null)
            {
                foreach (var gatewayitem in SystemSetting.GatewaySettings)
                {
                    Gateway_Type type = (Gateway_Type)gatewayitem.Gateway_Type;
                    switch (type)
                    {
                        case Gateway_Type.SerialPort:
                            {
                                SerialPortComponent component = new SerialPortComponent(gatewayitem, gatewayitem.DeviceSettings, NotifySettings, GroupSetting);
                                component.MyWorkState = true;
                                Field4Components.Add(component);
                                AbsProtocols.AddRange(component.AbsProtocols);
                                UpdateClasses.Add(component.UpdateClass);
                            }
                            break;
                        case Gateway_Type.TCP:
                            {
                                TCPComponent component = new TCPComponent(gatewayitem, gatewayitem.DeviceSettings, NotifySettings, GroupSetting);
                                component.MyWorkState = true;
                                Field4Components.Add(component);
                                AbsProtocols.AddRange(component.AbsProtocols);
                                UpdateClasses.Add(component.UpdateClass);
                            }
                            break;
                    }
                }
            }
            APIComponent = new APIComponent(Field4Components, APIMethod);
            APIComponent.MyWorkState = APISetting.Flag;
            #endregion
            #region 建立畫面分頁
            if (SystemSetting != null)
            {
                xtcl_DeviceView.TabPages.Clear();
                foreach (var Gatewayitem in SystemSetting.GatewaySettings)
                {
                    XtraTabPage tabPage = new XtraTabPage();
                    tabPage.Text = $"{Gatewayitem.Gateway_Name}_{Gatewayitem.Gateway_Location}";
                    DeviceView deviceView = new DeviceView(GroupSetting, AbsProtocols) { Dock = DockStyle.Fill };
                    tabPage.Controls.Add(deviceView);
                    Field4Controls.Add(deviceView);
                    xtcl_DeviceView.TabPages.Add(tabPage);
                }
            }
            #endregion
            #region 登入按鈕
            bbtn_Login.ImageOptions.Image = imageCollection.Images["Login.png"];
            bbtn_Login.ItemClick += (s, e) =>
            {
                if (LoginFlag)
                {
                    bbtn_ImportExcel.Visibility = BarItemVisibility.Never;
                    LoginFlag = false;
                    bbtn_Login.ImageOptions.Image = imageCollection.Images["Login.png"];
                    bbtn_Login.Caption = "登入";
                }
                else
                {
                    UserControl control = new UserControl() { Padding = new Padding(0, 30, 0, 20), Size = new Size(400, 200) };
                    TextEdit textEdit = new TextEdit() { Dock = DockStyle.Top, Size = new Size(400, 40) };
                    textEdit.Properties.Appearance.FontSizeDelta = 12;
                    textEdit.Properties.Appearance.Options.UseFont = true;
                    textEdit.Properties.Appearance.Options.UseTextOptions = true;
                    textEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    textEdit.Parent = control;
                    textEdit.Properties.UseSystemPasswordChar = true;
                    LabelControl labelControl = new LabelControl() { Dock = DockStyle.Top, Size = new Size(400, 50) };
                    labelControl.Appearance.FontSizeDelta = 18;
                    labelControl.AutoSizeMode = LabelAutoSizeMode.None;
                    labelControl.Text = "請輸入登入密碼";
                    labelControl.Appearance.Options.UseFont = true;
                    labelControl.Appearance.Options.UseTextOptions = true;
                    labelControl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    labelControl.Parent = control;
                    SimpleButton okButton = new SimpleButton() { Dock = DockStyle.Bottom, Text = "確定", Size = new Size(400, 40) };
                    okButton.Appearance.BackColor = Color.FromArgb(80, 80, 80);
                    okButton.Appearance.FontSizeDelta = 12;
                    okButton.DialogResult = DialogResult.OK;
                    okButton.Parent = control;
                    if (FlyoutDialog.Show(FindForm(), control) == DialogResult.OK && (string.Compare(textEdit.Text, "d001007", true) == 0 || string.Compare(textEdit.Text, "Admin", true) == 0))
                    {
                        bbtn_ImportExcel.Visibility = BarItemVisibility.Always;
                        LoginFlag = true;
                        bbtn_Login.ImageOptions.Image = imageCollection.Images["Admin.png"];
                        bbtn_Login.Caption = "Admin";
                        LoginTime = DateTime.Now;
                    }
                }
            };
            #endregion
            #region Excel匯入按鈕
            bbtn_ImportExcel.Visibility = BarItemVisibility.Never;
            bbtn_ImportExcel.ItemClick += (s, e) =>
            {
                if (ExcelMethod.Excel_Load())
                {
                    foreach (var item in Field4Components)
                    {
                        item.MyWorkState = false;
                    }
                    APIComponent.MyWorkState = false;
                    timer.Enabled = false;
                    if (APISetting.Flag)
                    {
                        foreach (var item in ExcelMethod.UpdateClasses)
                        {
                            APIMethod.ResponseDataMessage = "";
                            APIMethod.Post_Setting(item);
                            if (APIMethod.statusCode == System.Net.HttpStatusCode.BadRequest)
                            {
                                break;
                            }
                        }
                        if (APIMethod.statusCode != System.Net.HttpStatusCode.BadRequest &APIMethod.ResponseErrorMessage != "工作已取消")
                        {
                            InitialMethod.Group_Save(ExcelMethod.GroupSetting);
                            InitialMethod.Notify_Save(ExcelMethod.NotifySettings);
                            InitialMethod.System_Save(ExcelMethod.SystemSetting);
                            action.Caption = "設備資料匯入";
                            action.Description = $"匯入完成，請重新啟動!! \r\n {APIMethod.ResponseDataMessage}";
                            action.Commands.Add(FlyoutCommand.OK);
                            FlyoutDialog.Show(FindForm(), action);
                            Application.ExitThread();
                        }
                        else
                        {
                            action.Caption = $"設備資料匯入";
                            action.Description = $"匯入失敗!!\r\n{APIMethod.ResponseErrorMessage}";
                            action.Commands.Add(FlyoutCommand.OK);
                            FlyoutDialog.Show(FindForm(), action);
                        }
                    }
                    else
                    {
                        InitialMethod.Group_Save(ExcelMethod.GroupSetting);
                        InitialMethod.Notify_Save(ExcelMethod.NotifySettings);
                        InitialMethod.System_Save(ExcelMethod.SystemSetting);
                        action.Caption = "設備資料匯入";
                        action.Description = $"匯入完成，請重新啟動!! \r\n {APIMethod.ResponseDataMessage}";
                        action.Commands.Add(FlyoutCommand.OK);
                        FlyoutDialog.Show(FindForm(), action);
                        Application.ExitThread();
                    }
                }
                else
                {
                    action.Caption = $"設備資料匯入";
                    action.Description = $"匯入失敗!!\r\n{ExcelMethod.ErrorStr}";
                    action.Commands.Add(FlyoutCommand.OK);
                    FlyoutDialog.Show(FindForm(), action);
                }
            };
            #endregion
            #region 最小化
            notifyIcon.MouseDoubleClick += (s, e) =>
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            };
            #endregion
            timer.Enabled = true;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            #region 登出時間
            TimeSpan LoginTimeSpan = DateTime.Now.Subtract(LoginTime);
            if (LoginTimeSpan.TotalMilliseconds >= LogoutTime && LoginFlag)
            {
                bbtn_ImportExcel.Visibility = BarItemVisibility.Never;
                LoginFlag = false;
                bbtn_Login.ImageOptions.Image = imageCollection.Images["Login.png"];
                bbtn_Login.Caption = "登入";
            }
            #endregion
            int PageIndex = xtcl_DeviceView.SelectedTabPageIndex;
            if (Field4Components.Count > 0)
            {
                if (Field4Components[PageIndex].UpdateClass != null)
                {
                    Field4Controls[PageIndex].SetDevice = Field4Components[PageIndex].UpdateClass.SetDevice;
                    Field4Controls[PageIndex].TextChange();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserControl control = new UserControl() { Padding = new Padding(0, 30, 0, 20), Size = new Size(400, 200) };
            TextEdit textEdit = new TextEdit() { Dock = DockStyle.Top, Size = new Size(400, 40) };
            textEdit.Properties.Appearance.FontSizeDelta = 12;
            textEdit.Properties.Appearance.Options.UseFont = true;
            textEdit.Properties.Appearance.Options.UseTextOptions = true;
            textEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            textEdit.Parent = control;
            textEdit.Properties.UseSystemPasswordChar = true;
            LabelControl labelControl = new LabelControl() { Dock = DockStyle.Top, Size = new Size(400, 50) };
            labelControl.Appearance.FontSizeDelta = 18;
            labelControl.AutoSizeMode = LabelAutoSizeMode.None;
            labelControl.Text = "請輸入關閉軟體密碼";
            labelControl.Appearance.Options.UseFont = true;
            labelControl.Appearance.Options.UseTextOptions = true;
            labelControl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            labelControl.Parent = control;
            SimpleButton okButton = new SimpleButton() { Dock = DockStyle.Bottom, Text = "確定", Size = new Size(400, 40) };
            okButton.Appearance.BackColor = Color.FromArgb(80, 80, 80);
            okButton.Appearance.FontSizeDelta = 12;
            okButton.DialogResult = DialogResult.OK;
            okButton.Parent = control;
            if (FlyoutDialog.Show(FindForm(), control) == DialogResult.OK && string.Compare(textEdit.Text, "qu!t", true) == 0)
            {
                foreach (var item in Field4Components)
                {
                    item.MyWorkState = false;
                }
                APIComponent.MyWorkState = false;
                timer.Enabled = false;
                Application.ExitThread();
                this.Dispose();
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIcon.Visible = true;
            }
            else
            {
                this.notifyIcon.Visible = false;
            }
        }
    }
}
