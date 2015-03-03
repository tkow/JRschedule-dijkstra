namespace schedulejr
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.search = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.destinationtext = new System.Windows.Forms.TextBox();
            this.departuretext = new System.Windows.Forms.TextBox();
            this.departurelist = new System.Windows.Forms.ListBox();
            this.destinationlist = new System.Windows.Forms.ListBox();
            this.schedule = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LineSelect = new System.Windows.Forms.ComboBox();
            this.Name_Line = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dlineselect = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(63, 540);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(145, 38);
            this.search.TabIndex = 0;
            this.search.Text = "search";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.destinationtext);
            this.groupBox1.Controls.Add(this.departuretext);
            this.groupBox1.Location = new System.Drawing.Point(348, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 106);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "区間";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(317, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "目的地";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "出発地";
            // 
            // destinationtext
            // 
            this.destinationtext.Location = new System.Drawing.Point(319, 53);
            this.destinationtext.Name = "destinationtext";
            this.destinationtext.Size = new System.Drawing.Size(100, 19);
            this.destinationtext.TabIndex = 1;
            // 
            // departuretext
            // 
            this.departuretext.Location = new System.Drawing.Point(72, 53);
            this.departuretext.Name = "departuretext";
            this.departuretext.Size = new System.Drawing.Size(100, 19);
            this.departuretext.TabIndex = 0;
            // 
            // departurelist
            // 
            this.departurelist.FormattingEnabled = true;
            this.departurelist.ItemHeight = 12;
            this.departurelist.Location = new System.Drawing.Point(374, 232);
            this.departurelist.Name = "departurelist";
            this.departurelist.Size = new System.Drawing.Size(186, 280);
            this.departurelist.TabIndex = 2;
            this.departurelist.SelectedValueChanged += new System.EventHandler(this.departurelist_SelectedValueChanged);
            // 
            // destinationlist
            // 
            this.destinationlist.FormattingEnabled = true;
            this.destinationlist.ItemHeight = 12;
            this.destinationlist.Location = new System.Drawing.Point(616, 232);
            this.destinationlist.Name = "destinationlist";
            this.destinationlist.Size = new System.Drawing.Size(186, 280);
            this.destinationlist.TabIndex = 3;
            this.destinationlist.SelectedIndexChanged += new System.EventHandler(this.destinationlist_SelectedIndexChanged);
            // 
            // schedule
            // 
            this.schedule.FormattingEnabled = true;
            this.schedule.ItemHeight = 12;
            this.schedule.Location = new System.Drawing.Point(47, 79);
            this.schedule.Name = "schedule";
            this.schedule.Size = new System.Drawing.Size(198, 400);
            this.schedule.TabIndex = 4;
            this.schedule.SelectedIndexChanged += new System.EventHandler(this.schedule_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "時刻表";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(379, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "出発地";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(614, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "目的地";
            // 
            // LineSelect
            // 
            this.LineSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LineSelect.FormattingEnabled = true;
            this.LineSelect.Location = new System.Drawing.Point(381, 164);
            this.LineSelect.Name = "LineSelect";
            this.LineSelect.Size = new System.Drawing.Size(179, 20);
            this.LineSelect.TabIndex = 8;
            this.LineSelect.SelectedIndexChanged += new System.EventHandler(this.LineSelect_SelectedIndexChanged);
            // 
            // Name_Line
            // 
            this.Name_Line.AutoSize = true;
            this.Name_Line.Location = new System.Drawing.Point(379, 149);
            this.Name_Line.Name = "Name_Line";
            this.Name_Line.Size = new System.Drawing.Size(53, 12);
            this.Name_Line.TabIndex = 9;
            this.Name_Line.Text = "路線選択";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(614, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "路線選択";
            // 
            // dlineselect
            // 
            this.dlineselect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dlineselect.FormattingEnabled = true;
            this.dlineselect.Location = new System.Drawing.Point(616, 164);
            this.dlineselect.Name = "dlineselect";
            this.dlineselect.Size = new System.Drawing.Size(179, 20);
            this.dlineselect.TabIndex = 11;
            this.dlineselect.SelectedIndexChanged += new System.EventHandler(this.dlineselect_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 619);
            this.Controls.Add(this.dlineselect);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Name_Line);
            this.Controls.Add(this.LineSelect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.schedule);
            this.Controls.Add(this.destinationlist);
            this.Controls.Add(this.departurelist);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.search);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button search;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox destinationtext;
        private System.Windows.Forms.TextBox departuretext;
        private System.Windows.Forms.ListBox departurelist;
        private System.Windows.Forms.ListBox destinationlist;
        private System.Windows.Forms.ListBox schedule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.ComboBox LineSelect;
        private System.Windows.Forms.Label Name_Line;
        private System.Windows.Forms.Label label6;
        protected System.Windows.Forms.ComboBox dlineselect;
    }
}

