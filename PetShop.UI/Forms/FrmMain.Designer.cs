namespace PetShop.UI.Forms;

partial class FrmMain
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.pnlContent = new System.Windows.Forms.Panel();
        this.pnlHeader = new System.Windows.Forms.Panel();
        this.pnlSidebar = new System.Windows.Forms.Panel();
        this.SuspendLayout();
        // 
        // pnlContent
        // 
        this.pnlContent.AutoScroll = true;
        this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
        this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlContent.Location = new System.Drawing.Point(240, 65);
        this.pnlContent.Name = "pnlContent";
        this.pnlContent.Size = new System.Drawing.Size(1110, 664);
        this.pnlContent.TabIndex = 2;
        // 
        // pnlHeader
        // 
        this.pnlHeader.BackColor = System.Drawing.Color.White;
        this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlHeader.Location = new System.Drawing.Point(240, 0);
        this.pnlHeader.Name = "pnlHeader";
        this.pnlHeader.Size = new System.Drawing.Size(1110, 65);
        this.pnlHeader.TabIndex = 1;
        // 
        // pnlSidebar
        // 
        this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(26)))));
        this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
        this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
        this.pnlSidebar.Name = "pnlSidebar";
        this.pnlSidebar.Size = new System.Drawing.Size(240, 729);
        this.pnlSidebar.TabIndex = 0;
        // 
        // FrmMain
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
        this.ClientSize = new System.Drawing.Size(1350, 729);
        this.Controls.Add(this.pnlContent);
        this.Controls.Add(this.pnlHeader);
        this.Controls.Add(this.pnlSidebar);
        this.MinimumSize = new System.Drawing.Size(1100, 650);
        this.Name = "FrmMain";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "PetShop Manager - Sistema de Gestão Administrativa";
        this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.Panel pnlContent;
    private System.Windows.Forms.Panel pnlHeader;
    private System.Windows.Forms.Panel pnlSidebar;
}
