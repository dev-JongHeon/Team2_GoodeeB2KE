using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team2_VO;

namespace Team2_POP
{
    public class UtilClass
    {
        /// <summary>
        /// DataGridView의 컬럼 추가
        /// </summary>
        /// <param name="dgv">DataGridView 이름</param>
        /// <param name="headrText">컬럼명</param>
        /// <param name="dataPropertyName">데이터명</param>
        /// <param name="visible">표시여부</param>
        /// <param name="colwidth">컬럼넓이</param>
        /// <param name="txtAllign">글자정렬</param>
        public static void AddNewColum(DataGridView dgv,
                                       string headerText,
                                       string dataPropertyName,
                                       bool visible = true,
                                       int colwidth = 100,
                                       DataGridViewContentAlignment txtAllign = DataGridViewContentAlignment.MiddleLeft)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = headerText.Trim();
            col.DataPropertyName = dataPropertyName;
            col.Width = colwidth;
            col.Visible = visible;
            col.ValueType = typeof(string);
            col.ReadOnly = true;
            col.DefaultCellStyle.Alignment = txtAllign;
            dgv.Columns.Add(col);
        }

        /// <summary>
        /// DataGridView 기본속성들 설정
        /// </summary>
        /// <param name="dgv">DataGridView 이름</param>
        public static void SettingDgv(DataGridView dgv)
        {
            dgv.Font = new Font("나눔고딕", 15);
            dgv.ColumnHeadersHeight = 30;
            
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv.RowsDefaultCellStyle.BackColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgv.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(55, 113, 138);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(55, 113, 138);
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        #region comboBox 바인딩 관련 유틸리티
        public static void ComboBinding(ComboBox combo, List<ComboItemVO> list)
        {
            combo.ValueMember = "Name";
            combo.DisplayMember = "ID";
            combo.DataSource = list;
        }

        public static void ComboBinding(ComboBox combo, List<ComboItemVO> list, string blankText)
        {
            if (list == null)
                list = new List<ComboItemVO>();

            list.Insert(0, new ComboItemVO(blankText));
            combo.DataSource = list;
            combo.DisplayMember = "Name";
            combo.ValueMember = "ID";
        }

        public static void ComboBinding<T>(ComboBox combo, List<T> list, string Code, string CodeNm)
        {
            if (list == null)
                list = new List<T>();

            combo.DataSource = list;
            combo.DisplayMember = CodeNm;
            combo.ValueMember = Code;
        }

        public static void ComboBinding<T>(ComboBox combo, List<T> list, string Code, string CodeNm, string blankText) where T : class, new()
        {
            if (list == null)
                list = new List<T>();

            T blankItem = new T();
            blankItem.GetType().GetProperty(CodeNm).SetValue(blankItem, blankText);
            list.Insert(0, blankItem);

            combo.DataSource = list;
            combo.DisplayMember = CodeNm;
            combo.ValueMember = Code;
        }
        #endregion
    }
}
