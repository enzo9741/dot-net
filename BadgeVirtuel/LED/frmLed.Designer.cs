
namespace LED
{
    partial class FrmLed
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbLedSystem = new System.Windows.Forms.TabControl();
            this.tbLED = new System.Windows.Forms.TabPage();
            this.tbCfg = new System.Windows.Forms.TabPage();
            this.lstlog = new System.Windows.Forms.ListBox();
            this.cmdStart = new System.Windows.Forms.Button();
            this.txtPorts = new System.Windows.Forms.TextBox();
            this.lblPorts = new System.Windows.Forms.Label();
            this.tbLedSystem.SuspendLayout();
            this.tbCfg.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbLedSystem
            // 
            this.tbLedSystem.Controls.Add(this.tbLED);
            this.tbLedSystem.Controls.Add(this.tbCfg);
            this.tbLedSystem.Location = new System.Drawing.Point(22, 10);
            this.tbLedSystem.Name = "tbLedSystem";
            this.tbLedSystem.SelectedIndex = 0;
            this.tbLedSystem.Size = new System.Drawing.Size(482, 148);
            this.tbLedSystem.TabIndex = 0;
            // 
            // tbLED
            // 
            this.tbLED.Location = new System.Drawing.Point(4, 22);
            this.tbLED.Name = "tbLED";
            this.tbLED.Padding = new System.Windows.Forms.Padding(3);
            this.tbLED.Size = new System.Drawing.Size(1233, 122);
            this.tbLED.TabIndex = 0;
            this.tbLED.Text = "LED";
            this.tbLED.UseVisualStyleBackColor = true;
            // 
            // tbCfg
            // 
            this.tbCfg.Controls.Add(this.lstlog);
            this.tbCfg.Controls.Add(this.cmdStart);
            this.tbCfg.Controls.Add(this.txtPorts);
            this.tbCfg.Controls.Add(this.lblPorts);
            this.tbCfg.Location = new System.Drawing.Point(4, 22);
            this.tbCfg.Name = "tbCfg";
            this.tbCfg.Padding = new System.Windows.Forms.Padding(3);
            this.tbCfg.Size = new System.Drawing.Size(474, 122);
            this.tbCfg.TabIndex = 1;
            this.tbCfg.Text = "Configuration";
            this.tbCfg.UseVisualStyleBackColor = true;
            // 
            // lstlog
            // 
            this.lstlog.FormattingEnabled = true;
            this.lstlog.Location = new System.Drawing.Point(6, 44);
            this.lstlog.Name = "lstlog";
            this.lstlog.Size = new System.Drawing.Size(445, 69);
            this.lstlog.TabIndex = 3;
            // 
            // cmdStart
            // 
            this.cmdStart.Location = new System.Drawing.Point(336, 6);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(115, 28);
            this.cmdStart.TabIndex = 2;
            this.cmdStart.Text = "Start";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // txtPorts
            // 
            this.txtPorts.Location = new System.Drawing.Point(47, 11);
            this.txtPorts.Name = "txtPorts";
            this.txtPorts.Size = new System.Drawing.Size(100, 20);
            this.txtPorts.TabIndex = 1;
            this.txtPorts.Text = "1234";
            // 
            // lblPorts
            // 
            this.lblPorts.AutoSize = true;
            this.lblPorts.Location = new System.Drawing.Point(11, 14);
            this.lblPorts.Name = "lblPorts";
            this.lblPorts.Size = new System.Drawing.Size(31, 13);
            this.lblPorts.TabIndex = 0;
            this.lblPorts.Text = "Ports";
            // 
            // FrmLed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 181);
            this.Controls.Add(this.tbLedSystem);
            this.Name = "FrmLed";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LED - System";
            this.tbLedSystem.ResumeLayout(false);
            this.tbCfg.ResumeLayout(false);
            this.tbCfg.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbLedSystem;
        private System.Windows.Forms.TabPage tbLED;
        private System.Windows.Forms.TabPage tbCfg;
        private System.Windows.Forms.ListBox lstlog;
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.TextBox txtPorts;
        private System.Windows.Forms.Label lblPorts;
    }
}

