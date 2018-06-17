namespace valueEditor
{
    partial class CstRichTextBox
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CstRichTextBox
            // 
            this.AcceptsTab = true;
            this.AutoWordSelection = true;
            this.EnableAutoDragDrop = true;
            this.HideSelection = false;
            this.SelectionChanged += new System.EventHandler(this.CstRichTextBox_SelectionChanged);
            this.Enter += new System.EventHandler(this.CstRichTextBox_Enter);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CstRichTextBox_KeyPress);
            this.Leave += new System.EventHandler(this.CstRichTextBox_Leave);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
