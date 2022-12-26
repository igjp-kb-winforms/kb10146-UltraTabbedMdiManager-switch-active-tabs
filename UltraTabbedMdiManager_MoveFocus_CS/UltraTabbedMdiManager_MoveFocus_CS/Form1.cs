using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UltraTabbedMdiManager_MoveFocus_CS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MDI 子フォームのコンテナーとするプロパティ設定
            this.IsMdiContainer = true;
            //フォームでキーイベントを捕捉するためのプロパティ設定
            this.KeyPreview = true;

            for (int i = 1; i <= 5; i++)
            {
                var myForm = new SampleChildForm();
                myForm.MdiParent = this;
                myForm.Text = "Child Form" + i.ToString();
                myForm.Show();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            var tabs = this.ultraTabbedMdiManager1.TabGroups[0].Tabs;
            var activeTab = this.ultraTabbedMdiManager1.ActiveTab;

            //Home 押下時に、先頭タブをアクティブ化する。
            if (e.KeyData == Keys.Home)
            {
                tabs[0].Activate();
            }

            //End 押下時に、最終タブをアクティブ化する。
            if (e.KeyData == Keys.End)
            {
                tabs[tabs.Count - 1].Activate();
            }

            //PageUp 押下時に、アクティブタブを次に移動する。
            if (e.KeyData == Keys.PageUp)
            {
                //最終タブがアクティブタブの場合、先頭タブをアクティブ化する。
                if (activeTab.Index == tabs.Count - 1)
                {
                    tabs[0].Activate();
                }
                else
                {
                    tabs[activeTab.Index + 1].Activate();
                }
            }

            //PageDown 押下時に、アクティブタブを前に移動する。
            if (e.KeyData == Keys.PageDown)
            {
                //先頭タブがアクティブタブの場合、最終タブをアクティブ化する。
                if (activeTab.Index == 0)
                {
                    tabs[tabs.Count - 1].Activate();
                }
                else
                {
                    tabs[activeTab.Index - 1].Activate();
                }
            }
        }
    }
}
