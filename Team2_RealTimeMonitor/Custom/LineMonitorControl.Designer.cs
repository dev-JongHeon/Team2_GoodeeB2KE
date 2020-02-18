namespace Team2_RealTimeMonitor
{
    partial class LineMonitorControl
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.splitBody = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.circleProgress = new Team2_RealTimeMonitor.CircleProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblState = new System.Windows.Forms.Label();
            this.splitRightContent = new System.Windows.Forms.SplitContainer();
            this.lblLineName = new System.Windows.Forms.Label();
            this.splitTable = new System.Windows.Forms.SplitContainer();
            this.splitLeftTable = new System.Windows.Forms.SplitContainer();
            this.panelProduceQty = new System.Windows.Forms.Panel();
            this.lblProduce = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelRequestQty = new System.Windows.Forms.Panel();
            this.lblRequest = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.splitRightTable = new System.Windows.Forms.SplitContainer();
            this.panelDefective = new System.Windows.Forms.Panel();
            this.lblDefective = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelImport = new System.Windows.Forms.Panel();
            this.lblImport = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitBody)).BeginInit();
            this.splitBody.Panel1.SuspendLayout();
            this.splitBody.Panel2.SuspendLayout();
            this.splitBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitRightContent)).BeginInit();
            this.splitRightContent.Panel1.SuspendLayout();
            this.splitRightContent.Panel2.SuspendLayout();
            this.splitRightContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitTable)).BeginInit();
            this.splitTable.Panel1.SuspendLayout();
            this.splitTable.Panel2.SuspendLayout();
            this.splitTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitLeftTable)).BeginInit();
            this.splitLeftTable.Panel1.SuspendLayout();
            this.splitLeftTable.Panel2.SuspendLayout();
            this.splitLeftTable.SuspendLayout();
            this.panelProduceQty.SuspendLayout();
            this.panelRequestQty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitRightTable)).BeginInit();
            this.splitRightTable.Panel1.SuspendLayout();
            this.splitRightTable.Panel2.SuspendLayout();
            this.splitRightTable.SuspendLayout();
            this.panelDefective.SuspendLayout();
            this.panelImport.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.panelContent);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(516, 270);
            this.panelMain.TabIndex = 2;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.splitBody);
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(516, 260);
            this.panelContent.TabIndex = 0;
            // 
            // splitBody
            // 
            this.splitBody.BackColor = System.Drawing.Color.White;
            this.splitBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitBody.Location = new System.Drawing.Point(0, 0);
            this.splitBody.Name = "splitBody";
            // 
            // splitBody.Panel1
            // 
            this.splitBody.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitBody.Panel2
            // 
            this.splitBody.Panel2.Controls.Add(this.splitRightContent);
            this.splitBody.Size = new System.Drawing.Size(516, 260);
            this.splitBody.SplitterDistance = 171;
            this.splitBody.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(171, 260);
            this.splitContainer1.SplitterDistance = 151;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.circleProgress);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(171, 151);
            this.panel2.TabIndex = 0;
            // 
            // circleProgress
            // 
            this.circleProgress.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.circleProgress.Location = new System.Drawing.Point(19, 12);
            this.circleProgress.Maximum = ((long)(100));
            this.circleProgress.Name = "circleProgress";
            this.circleProgress.ProgressColor1 = System.Drawing.Color.Silver;
            this.circleProgress.ProgressColor2 = System.Drawing.Color.Silver;
            this.circleProgress.ProgressColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.circleProgress.ProgressColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.circleProgress.ProgressShape = Team2_RealTimeMonitor.CircleProgressBar._ProgressShape.Flat;
            this.circleProgress.Size = new System.Drawing.Size(126, 126);
            this.circleProgress.TabIndex = 3;
            this.circleProgress.Text = "circleProgressBar1";
            this.circleProgress.Value = ((long)(0));
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblState);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(171, 104);
            this.panel1.TabIndex = 0;
            // 
            // lblState
            // 
            this.lblState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(64)))));
            this.lblState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblState.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblState.ForeColor = System.Drawing.Color.White;
            this.lblState.Location = new System.Drawing.Point(0, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(171, 104);
            this.lblState.TabIndex = 2;
            this.lblState.Text = "생산 대기";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitRightContent
            // 
            this.splitRightContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitRightContent.Location = new System.Drawing.Point(0, 0);
            this.splitRightContent.Name = "splitRightContent";
            this.splitRightContent.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitRightContent.Panel1
            // 
            this.splitRightContent.Panel1.Controls.Add(this.lblLineName);
            // 
            // splitRightContent.Panel2
            // 
            this.splitRightContent.Panel2.Controls.Add(this.splitTable);
            this.splitRightContent.Size = new System.Drawing.Size(341, 260);
            this.splitRightContent.SplitterDistance = 40;
            this.splitRightContent.SplitterWidth = 5;
            this.splitRightContent.TabIndex = 0;
            // 
            // lblLineName
            // 
            this.lblLineName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(64)))));
            this.lblLineName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLineName.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLineName.ForeColor = System.Drawing.Color.White;
            this.lblLineName.Location = new System.Drawing.Point(0, 0);
            this.lblLineName.Name = "lblLineName";
            this.lblLineName.Size = new System.Drawing.Size(341, 40);
            this.lblLineName.TabIndex = 1;
            this.lblLineName.Text = "반제품 구동부 공정";
            this.lblLineName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitTable
            // 
            this.splitTable.BackColor = System.Drawing.Color.White;
            this.splitTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitTable.Location = new System.Drawing.Point(0, 0);
            this.splitTable.Name = "splitTable";
            // 
            // splitTable.Panel1
            // 
            this.splitTable.Panel1.Controls.Add(this.splitLeftTable);
            // 
            // splitTable.Panel2
            // 
            this.splitTable.Panel2.Controls.Add(this.splitRightTable);
            this.splitTable.Size = new System.Drawing.Size(341, 215);
            this.splitTable.SplitterDistance = 164;
            this.splitTable.TabIndex = 0;
            // 
            // splitLeftTable
            // 
            this.splitLeftTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitLeftTable.Location = new System.Drawing.Point(0, 0);
            this.splitLeftTable.Name = "splitLeftTable";
            this.splitLeftTable.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitLeftTable.Panel1
            // 
            this.splitLeftTable.Panel1.Controls.Add(this.panelProduceQty);
            // 
            // splitLeftTable.Panel2
            // 
            this.splitLeftTable.Panel2.Controls.Add(this.panelRequestQty);
            this.splitLeftTable.Size = new System.Drawing.Size(164, 215);
            this.splitLeftTable.SplitterDistance = 106;
            this.splitLeftTable.SplitterWidth = 5;
            this.splitLeftTable.TabIndex = 0;
            // 
            // panelProduceQty
            // 
            this.panelProduceQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(64)))));
            this.panelProduceQty.Controls.Add(this.lblProduce);
            this.panelProduceQty.Controls.Add(this.label2);
            this.panelProduceQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProduceQty.Location = new System.Drawing.Point(0, 0);
            this.panelProduceQty.Name = "panelProduceQty";
            this.panelProduceQty.Size = new System.Drawing.Size(164, 106);
            this.panelProduceQty.TabIndex = 0;
            // 
            // lblProduce
            // 
            this.lblProduce.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblProduce.ForeColor = System.Drawing.Color.White;
            this.lblProduce.Location = new System.Drawing.Point(2, 70);
            this.lblProduce.Name = "lblProduce";
            this.lblProduce.Size = new System.Drawing.Size(160, 38);
            this.lblProduce.TabIndex = 1;
            this.lblProduce.Text = "0";
            this.lblProduce.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 41);
            this.label2.TabIndex = 0;
            this.label2.Text = "생산 진행 수량";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelRequestQty
            // 
            this.panelRequestQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(64)))));
            this.panelRequestQty.Controls.Add(this.lblRequest);
            this.panelRequestQty.Controls.Add(this.label4);
            this.panelRequestQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRequestQty.Location = new System.Drawing.Point(0, 0);
            this.panelRequestQty.Name = "panelRequestQty";
            this.panelRequestQty.Size = new System.Drawing.Size(164, 104);
            this.panelRequestQty.TabIndex = 0;
            // 
            // lblRequest
            // 
            this.lblRequest.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRequest.ForeColor = System.Drawing.Color.White;
            this.lblRequest.Location = new System.Drawing.Point(3, 66);
            this.lblRequest.Name = "lblRequest";
            this.lblRequest.Size = new System.Drawing.Size(159, 38);
            this.lblRequest.TabIndex = 3;
            this.lblRequest.Text = "0";
            this.lblRequest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 41);
            this.label4.TabIndex = 2;
            this.label4.Text = "생산 요청 수량";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitRightTable
            // 
            this.splitRightTable.BackColor = System.Drawing.Color.White;
            this.splitRightTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitRightTable.Location = new System.Drawing.Point(0, 0);
            this.splitRightTable.Name = "splitRightTable";
            this.splitRightTable.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitRightTable.Panel1
            // 
            this.splitRightTable.Panel1.Controls.Add(this.panelDefective);
            // 
            // splitRightTable.Panel2
            // 
            this.splitRightTable.Panel2.Controls.Add(this.panelImport);
            this.splitRightTable.Size = new System.Drawing.Size(173, 215);
            this.splitRightTable.SplitterDistance = 106;
            this.splitRightTable.SplitterWidth = 5;
            this.splitRightTable.TabIndex = 0;
            // 
            // panelDefective
            // 
            this.panelDefective.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(64)))));
            this.panelDefective.Controls.Add(this.lblDefective);
            this.panelDefective.Controls.Add(this.label3);
            this.panelDefective.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDefective.Location = new System.Drawing.Point(0, 0);
            this.panelDefective.Name = "panelDefective";
            this.panelDefective.Size = new System.Drawing.Size(173, 106);
            this.panelDefective.TabIndex = 0;
            // 
            // lblDefective
            // 
            this.lblDefective.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDefective.ForeColor = System.Drawing.Color.White;
            this.lblDefective.Location = new System.Drawing.Point(4, 70);
            this.lblDefective.Name = "lblDefective";
            this.lblDefective.Size = new System.Drawing.Size(164, 38);
            this.lblDefective.TabIndex = 2;
            this.lblDefective.Text = "0";
            this.lblDefective.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(4, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 41);
            this.label3.TabIndex = 1;
            this.label3.Text = "불량 발생 개수";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelImport
            // 
            this.panelImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(64)))));
            this.panelImport.Controls.Add(this.lblImport);
            this.panelImport.Controls.Add(this.label5);
            this.panelImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelImport.Location = new System.Drawing.Point(0, 0);
            this.panelImport.Name = "panelImport";
            this.panelImport.Size = new System.Drawing.Size(173, 104);
            this.panelImport.TabIndex = 0;
            // 
            // lblImport
            // 
            this.lblImport.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblImport.ForeColor = System.Drawing.Color.White;
            this.lblImport.Location = new System.Drawing.Point(2, 66);
            this.lblImport.Name = "lblImport";
            this.lblImport.Size = new System.Drawing.Size(166, 38);
            this.lblImport.TabIndex = 4;
            this.lblImport.Text = "0";
            this.lblImport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(4, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 38);
            this.label5.TabIndex = 3;
            this.label5.Text = "생산 투입 개수";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LineMonitorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "LineMonitorControl";
            this.Size = new System.Drawing.Size(516, 270);
            this.panelMain.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.splitBody.Panel1.ResumeLayout(false);
            this.splitBody.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitBody)).EndInit();
            this.splitBody.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitRightContent.Panel1.ResumeLayout(false);
            this.splitRightContent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitRightContent)).EndInit();
            this.splitRightContent.ResumeLayout(false);
            this.splitTable.Panel1.ResumeLayout(false);
            this.splitTable.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitTable)).EndInit();
            this.splitTable.ResumeLayout(false);
            this.splitLeftTable.Panel1.ResumeLayout(false);
            this.splitLeftTable.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitLeftTable)).EndInit();
            this.splitLeftTable.ResumeLayout(false);
            this.panelProduceQty.ResumeLayout(false);
            this.panelRequestQty.ResumeLayout(false);
            this.splitRightTable.Panel1.ResumeLayout(false);
            this.splitRightTable.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitRightTable)).EndInit();
            this.splitRightTable.ResumeLayout(false);
            this.panelDefective.ResumeLayout(false);
            this.panelImport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.SplitContainer splitBody;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.SplitContainer splitRightContent;
        private System.Windows.Forms.SplitContainer splitTable;
        private System.Windows.Forms.SplitContainer splitLeftTable;
        private System.Windows.Forms.Panel panelProduceQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelRequestQty;
        private System.Windows.Forms.Label lblRequest;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SplitContainer splitRightTable;
        private System.Windows.Forms.Panel panelDefective;
        private System.Windows.Forms.Label lblDefective;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelImport;
        private System.Windows.Forms.Label lblImport;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label lblProduce;
        private System.Windows.Forms.Label lblLineName;
        private CircleProgressBar circleProgress;
        public System.Windows.Forms.Panel panel2;
    }
}
