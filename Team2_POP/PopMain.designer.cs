namespace Team2_POP
{
    partial class PopMain
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cboLine = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboFactory = new System.Windows.Forms.ComboBox();
            this.btnLineSearch = new System.Windows.Forms.Button();
            this.lblState = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDownTime = new System.Windows.Forms.Button();
            this.btnNextDate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPreDate = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnDate = new System.Windows.Forms.Button();
            this.btnWorkStart = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dgvWork = new System.Windows.Forms.DataGridView();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.dgvProduce = new System.Windows.Forms.DataGridView();
            this.dgvPerformance = new System.Windows.Forms.DataGridView();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDefective = new System.Windows.Forms.Button();
            this.btnWorker = new System.Windows.Forms.Button();
            this.btnProduceStart = new System.Windows.Forms.Button();
            this.lblWorker = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerformance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1264, 961);
            this.splitContainer1.SplitterDistance = 48;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.cboLine, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cboFactory, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnLineSearch, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblState, 5, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("나눔고딕", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1264, 48);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // cboLine
            // 
            this.cboLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.cboLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboLine.FormattingEnabled = true;
            this.cboLine.Location = new System.Drawing.Point(507, 3);
            this.cboLine.Name = "cboLine";
            this.cboLine.Size = new System.Drawing.Size(246, 44);
            this.cboLine.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("나눔고딕", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(381, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 48);
            this.label2.TabIndex = 2;
            this.label2.Text = "공정";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "공장";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboFactory
            // 
            this.cboFactory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.cboFactory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboFactory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboFactory.FormattingEnabled = true;
            this.cboFactory.Location = new System.Drawing.Point(129, 3);
            this.cboFactory.Name = "cboFactory";
            this.cboFactory.Size = new System.Drawing.Size(246, 44);
            this.cboFactory.TabIndex = 1;
            this.cboFactory.SelectedIndexChanged += new System.EventHandler(this.cboFactory_SelectedIndexChanged);
            // 
            // btnLineSearch
            // 
            this.btnLineSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.btnLineSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLineSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLineSearch.Font = new System.Drawing.Font("나눔고딕", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLineSearch.Location = new System.Drawing.Point(759, 3);
            this.btnLineSearch.Name = "btnLineSearch";
            this.btnLineSearch.Size = new System.Drawing.Size(183, 42);
            this.btnLineSearch.TabIndex = 4;
            this.btnLineSearch.Text = "공정 조회";
            this.btnLineSearch.UseVisualStyleBackColor = false;
            this.btnLineSearch.Click += new System.EventHandler(this.btnLineSearch_Click);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.lblState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblState.ForeColor = System.Drawing.Color.Black;
            this.lblState.Location = new System.Drawing.Point(948, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(313, 48);
            this.lblState.TabIndex = 5;
            this.lblState.Text = "공정 상태 ex) 가동중";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1264, 909);
            this.splitContainer2.SplitterDistance = 76;
            this.splitContainer2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.01923F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.42308F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.63461F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.42308F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Controls.Add(this.btnDownTime, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNextDate, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPreDate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDate, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDate, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnWorkStart, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1264, 76);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnDownTime
            // 
            this.btnDownTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDownTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownTime.Font = new System.Drawing.Font("나눔고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDownTime.Location = new System.Drawing.Point(1107, 3);
            this.btnDownTime.Name = "btnDownTime";
            this.btnDownTime.Size = new System.Drawing.Size(154, 70);
            this.btnDownTime.TabIndex = 8;
            this.btnDownTime.Text = "비가동 전환";
            this.btnDownTime.UseVisualStyleBackColor = true;
            this.btnDownTime.Click += new System.EventHandler(this.btnDownTime_Click);
            // 
            // btnNextDate
            // 
            this.btnNextDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNextDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextDate.Image = global::Team2_POP.Properties.Resources.iconfinder_forward_126569__2_;
            this.btnNextDate.Location = new System.Drawing.Point(609, 3);
            this.btnNextDate.Name = "btnNextDate";
            this.btnNextDate.Size = new System.Drawing.Size(176, 70);
            this.btnNextDate.TabIndex = 3;
            this.btnNextDate.UseVisualStyleBackColor = true;
            this.btnNextDate.Click += new System.EventHandler(this.btnNextDate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("나눔고딕", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 76);
            this.label4.TabIndex = 0;
            this.label4.Text = "조회일자";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPreDate
            // 
            this.btnPreDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.btnPreDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPreDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPreDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPreDate.Image = global::Team2_POP.Properties.Resources.iconfinder_back_126585__2_;
            this.btnPreDate.Location = new System.Drawing.Point(154, 3);
            this.btnPreDate.Name = "btnPreDate";
            this.btnPreDate.Size = new System.Drawing.Size(176, 70);
            this.btnPreDate.TabIndex = 1;
            this.btnPreDate.UseVisualStyleBackColor = false;
            this.btnPreDate.Click += new System.EventHandler(this.btnPreDate_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDate.Font = new System.Drawing.Font("나눔고딕", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDate.Location = new System.Drawing.Point(336, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(267, 76);
            this.lblDate.TabIndex = 2;
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDate
            // 
            this.btnDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDate.Font = new System.Drawing.Font("나눔고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDate.Location = new System.Drawing.Point(791, 3);
            this.btnDate.Name = "btnDate";
            this.btnDate.Size = new System.Drawing.Size(152, 70);
            this.btnDate.TabIndex = 6;
            this.btnDate.Text = "날짜 조회";
            this.btnDate.UseVisualStyleBackColor = true;
            this.btnDate.Click += new System.EventHandler(this.btnDate_Click);
            // 
            // btnWorkStart
            // 
            this.btnWorkStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnWorkStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWorkStart.Font = new System.Drawing.Font("나눔고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnWorkStart.Location = new System.Drawing.Point(949, 3);
            this.btnWorkStart.Name = "btnWorkStart";
            this.btnWorkStart.Size = new System.Drawing.Size(152, 70);
            this.btnWorkStart.TabIndex = 7;
            this.btnWorkStart.Text = "작업시작";
            this.btnWorkStart.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dgvWork);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(1264, 829);
            this.splitContainer3.SplitterDistance = 249;
            this.splitContainer3.TabIndex = 0;
            // 
            // dgvWork
            // 
            this.dgvWork.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvWork.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWork.Location = new System.Drawing.Point(0, 0);
            this.dgvWork.Name = "dgvWork";
            this.dgvWork.RowTemplate.Height = 23;
            this.dgvWork.Size = new System.Drawing.Size(1264, 249);
            this.dgvWork.TabIndex = 2;
            this.dgvWork.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWork_CellClick);
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.splitContainer6);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer4.Size = new System.Drawing.Size(1264, 576);
            this.splitContainer4.SplitterDistance = 459;
            this.splitContainer4.TabIndex = 1;
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.dgvProduce);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.dgvPerformance);
            this.splitContainer6.Size = new System.Drawing.Size(1264, 459);
            this.splitContainer6.SplitterDistance = 683;
            this.splitContainer6.TabIndex = 0;
            // 
            // dgvProduce
            // 
            this.dgvProduce.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvProduce.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProduce.Location = new System.Drawing.Point(0, 0);
            this.dgvProduce.Name = "dgvProduce";
            this.dgvProduce.RowTemplate.Height = 23;
            this.dgvProduce.Size = new System.Drawing.Size(683, 459);
            this.dgvProduce.TabIndex = 2;
            this.dgvProduce.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduce_CellClick);
            // 
            // dgvPerformance
            // 
            this.dgvPerformance.BackgroundColor = System.Drawing.Color.White;
            this.dgvPerformance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerformance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPerformance.Location = new System.Drawing.Point(0, 0);
            this.dgvPerformance.Name = "dgvPerformance";
            this.dgvPerformance.RowTemplate.Height = 23;
            this.dgvPerformance.Size = new System.Drawing.Size(577, 459);
            this.dgvPerformance.TabIndex = 0;
            this.dgvPerformance.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPerformance_CellClick);
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.tableLayoutPanel3);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.lblWorker);
            this.splitContainer5.Size = new System.Drawing.Size(1264, 113);
            this.splitContainer5.SplitterDistance = 83;
            this.splitContainer5.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.btnDefective, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnWorker, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnProduceStart, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1264, 83);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // btnDefective
            // 
            this.btnDefective.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDefective.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDefective.Font = new System.Drawing.Font("나눔고딕", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDefective.Location = new System.Drawing.Point(845, 3);
            this.btnDefective.Name = "btnDefective";
            this.btnDefective.Size = new System.Drawing.Size(416, 77);
            this.btnDefective.TabIndex = 2;
            this.btnDefective.Text = "불량 처리 등록";
            this.btnDefective.UseVisualStyleBackColor = true;
            this.btnDefective.Click += new System.EventHandler(this.btnDefective_Click);
            // 
            // btnWorker
            // 
            this.btnWorker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnWorker.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnWorker.Font = new System.Drawing.Font("나눔고딕", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnWorker.Location = new System.Drawing.Point(424, 3);
            this.btnWorker.Name = "btnWorker";
            this.btnWorker.Size = new System.Drawing.Size(415, 77);
            this.btnWorker.TabIndex = 1;
            this.btnWorker.Text = "작업자 설정";
            this.btnWorker.UseVisualStyleBackColor = true;
            this.btnWorker.Click += new System.EventHandler(this.btnWorker_Click);
            // 
            // btnProduceStart
            // 
            this.btnProduceStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProduceStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProduceStart.Font = new System.Drawing.Font("나눔고딕", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnProduceStart.Location = new System.Drawing.Point(3, 3);
            this.btnProduceStart.Name = "btnProduceStart";
            this.btnProduceStart.Size = new System.Drawing.Size(415, 77);
            this.btnProduceStart.TabIndex = 0;
            this.btnProduceStart.Text = "생산 시작";
            this.btnProduceStart.UseVisualStyleBackColor = true;
            // 
            // lblWorker
            // 
            this.lblWorker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWorker.Font = new System.Drawing.Font("나눔고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWorker.Location = new System.Drawing.Point(0, 0);
            this.lblWorker.Name = "lblWorker";
            this.lblWorker.Size = new System.Drawing.Size(1264, 26);
            this.lblWorker.TabIndex = 0;
            this.lblWorker.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PopMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1264, 961);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "PopMain";
            this.Text = "POP화면";
            this.Load += new System.EventHandler(this.PopMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWork)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerformance)).EndInit();
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnNextDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPreDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btnDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox cboLine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboFactory;
        private System.Windows.Forms.Button btnLineSearch;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.DataGridView dgvWork;
        private System.Windows.Forms.Button btnWorkStart;
        private System.Windows.Forms.Button btnDownTime;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnDefective;
        private System.Windows.Forms.Button btnWorker;
        private System.Windows.Forms.Button btnProduceStart;
        private System.Windows.Forms.Label lblWorker;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.DataGridView dgvProduce;
        private System.Windows.Forms.DataGridView dgvPerformance;
    }
}

