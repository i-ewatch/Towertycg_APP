using DevExpress.Utils.Animation;
using DevExpress.XtraTab;
using System.Windows.Forms;

namespace Towertycg_APP.Methods
{
    public class XtraTabMethod
    {
        /// <summary>
        /// 將Tab物件轉換成Control
        /// </summary>
        private Control animatedControl;
        /// <summary>
        /// 換頁效果
        /// </summary>
        private TransitionManager transitionManager = new TransitionManager();
        /// <summary>
        /// 切換畫面使用
        /// </summary>
        /// <param name="xtraTabControl"></param>
        public void ScreenSwitching(XtraTabControl xtraTabControl)
        {
            if (animatedControl == null)
            {
                animatedControl = xtraTabControl;//Tab物件轉換成Control
                transitionManager.Transitions.Add(new Transition { Control = xtraTabControl });//將Tab匯入至換頁效果
                transitionManager.Transitions[animatedControl].ShowWaitingIndicator = DevExpress.Utils.DefaultBoolean.False;//不顯示等待迴圈
                transitionManager.Transitions[animatedControl].TransitionType = new FadeTransition();//切換類型
                transitionManager.FrameInterval = 5000;
                xtraTabControl.SelectedPageChanged += XtraTabControl_SelectedPageChanged;
                xtraTabControl.SelectedPageChanging += XtraTabControl_SelectedPageChanging;
            }
        }
        public void Close_ScreenSwitching()
        {
            transitionManager.Transitions.Clear();
            animatedControl = null;
        }
        private void XtraTabControl_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (animatedControl == null) return;
            transitionManager.StartTransition(animatedControl);
        }

        private void XtraTabControl_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            transitionManager.EndTransition();
        }
    }
}
