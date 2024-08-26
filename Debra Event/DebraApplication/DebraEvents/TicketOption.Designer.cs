namespace DebraEvents
{
    partial class TicketOption
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicketOption));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnTDashboard = new System.Windows.Forms.Button();
            this.btnTSellTicket = new System.Windows.Forms.Button();
            this.btnTAdd = new System.Windows.Forms.Button();
            this.txtTDate = new System.Windows.Forms.TextBox();
            this.txtTIsSold = new System.Windows.Forms.TextBox();
            this.txtTPrice = new System.Windows.Forms.TextBox();
            this.txtTTitle = new System.Windows.Forms.TextBox();
            this.txtTID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvTicket = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTicket)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(43)))), ((int)(((byte)(104)))));
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox2);
            this.splitContainer1.Panel1.Controls.Add(this.btnTDashboard);
            this.splitContainer1.Panel1.Controls.Add(this.btnTSellTicket);
            this.splitContainer1.Panel1.Controls.Add(this.btnTAdd);
            this.splitContainer1.Panel1.Controls.Add(this.txtTDate);
            this.splitContainer1.Panel1.Controls.Add(this.txtTIsSold);
            this.splitContainer1.Panel1.Controls.Add(this.txtTPrice);
            this.splitContainer1.Panel1.Controls.Add(this.txtTTitle);
            this.splitContainer1.Panel1.Controls.Add(this.txtTID);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvTicket);
            this.splitContainer1.Size = new System.Drawing.Size(990, 466);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(45, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 57;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnTDashboard
            // 
            this.btnTDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnTDashboard.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnTDashboard.Location = new System.Drawing.Point(73, 420);
            this.btnTDashboard.Name = "btnTDashboard";
            this.btnTDashboard.Size = new System.Drawing.Size(166, 34);
            this.btnTDashboard.TabIndex = 53;
            this.btnTDashboard.Text = "Back to Dashboard";
            this.btnTDashboard.UseVisualStyleBackColor = false;
            this.btnTDashboard.Click += new System.EventHandler(this.btnTDashboard_Click);
            // 
            // btnTSellTicket
            // 
            this.btnTSellTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnTSellTicket.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnTSellTicket.Location = new System.Drawing.Point(88, 367);
            this.btnTSellTicket.Name = "btnTSellTicket";
            this.btnTSellTicket.Size = new System.Drawing.Size(137, 34);
            this.btnTSellTicket.TabIndex = 52;
            this.btnTSellTicket.Text = "Sell Ticket";
            this.btnTSellTicket.UseVisualStyleBackColor = false;
            this.btnTSellTicket.Click += new System.EventHandler(this.btnTSellTicket_Click);
            // 
            // btnTAdd
            // 
            this.btnTAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnTAdd.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnTAdd.ForeColor = System.Drawing.Color.DimGray;
            this.btnTAdd.Location = new System.Drawing.Point(166, 313);
            this.btnTAdd.Name = "btnTAdd";
            this.btnTAdd.Size = new System.Drawing.Size(123, 28);
            this.btnTAdd.TabIndex = 49;
            this.btnTAdd.Text = "Create Ticket";
            this.btnTAdd.UseVisualStyleBackColor = false;
            this.btnTAdd.Click += new System.EventHandler(this.btnTAdd_Click);
            // 
            // txtTDate
            // 
            this.txtTDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTDate.Location = new System.Drawing.Point(117, 246);
            this.txtTDate.Name = "txtTDate";
            this.txtTDate.Size = new System.Drawing.Size(159, 20);
            this.txtTDate.TabIndex = 48;
            // 
            // txtTIsSold
            // 
            this.txtTIsSold.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTIsSold.Location = new System.Drawing.Point(117, 205);
            this.txtTIsSold.Name = "txtTIsSold";
            this.txtTIsSold.Size = new System.Drawing.Size(159, 20);
            this.txtTIsSold.TabIndex = 46;
            // 
            // txtTPrice
            // 
            this.txtTPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTPrice.Location = new System.Drawing.Point(117, 168);
            this.txtTPrice.Name = "txtTPrice";
            this.txtTPrice.Size = new System.Drawing.Size(159, 20);
            this.txtTPrice.TabIndex = 45;
            // 
            // txtTTitle
            // 
            this.txtTTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTTitle.Location = new System.Drawing.Point(117, 130);
            this.txtTTitle.Name = "txtTTitle";
            this.txtTTitle.Size = new System.Drawing.Size(159, 20);
            this.txtTTitle.TabIndex = 44;
            // 
            // txtTID
            // 
            this.txtTID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTID.Location = new System.Drawing.Point(117, 95);
            this.txtTID.Name = "txtTID";
            this.txtTID.Size = new System.Drawing.Size(159, 20);
            this.txtTID.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(20, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 16);
            this.label7.TabIndex = 42;
            this.label7.Text = "Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(18, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 40;
            this.label5.Text = "IsSold";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(20, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 39;
            this.label4.Text = "Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(17, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 38;
            this.label3.Text = "Event Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(17, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 37;
            this.label2.Text = "Ticket ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(32, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 39);
            this.label1.TabIndex = 36;
            this.label1.Text = "Ticket Option";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 393);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(302, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 54;
            this.pictureBox1.TabStop = false;
            // 
            // dgvTicket
            // 
            this.dgvTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTicket.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dgvTicket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTicket.Location = new System.Drawing.Point(0, 0);
            this.dgvTicket.Name = "dgvTicket";
            this.dgvTicket.Size = new System.Drawing.Size(686, 466);
            this.dgvTicket.TabIndex = 0;
            this.dgvTicket.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTicket_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "View";
            this.Column1.Name = "Column1";
            // 
            // TicketOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 466);
            this.Controls.Add(this.splitContainer1);
            this.Name = "TicketOption";
            this.Text = "TicketOption";
            this.Load += new System.EventHandler(this.TicketOption_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTicket)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnTDashboard;
        private System.Windows.Forms.Button btnTSellTicket;
        private System.Windows.Forms.Button btnTAdd;
        private System.Windows.Forms.TextBox txtTDate;
        private System.Windows.Forms.TextBox txtTIsSold;
        private System.Windows.Forms.TextBox txtTPrice;
        private System.Windows.Forms.TextBox txtTTitle;
        private System.Windows.Forms.TextBox txtTID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTicket;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}