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
using Excel = Microsoft.Office.Interop.Excel;

namespace Team2_ERP
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
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowsDefaultCellStyle.BackColor = Color.White;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(234, 242, 255);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(234, 242, 255);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(55, 113, 138);
            Font headerfont = new Font("나눔고딕", 12);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(headerfont, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(55, 113, 138);
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv.AllowUserToResizeColumns = true;
            dgv.AllowUserToResizeRows = false;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);   
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
         
            


        }

        #region Excel 유틸리티
        public static string ExportToDataGridView<T>(List<T> dataList, string[] exceptColumns)
        {
            try
            {
                Excel.Application excel = new Excel.Application();
                excel.Application.Workbooks.Add(true);

                int columnIndex = 0;

                foreach (PropertyInfo prop in typeof(T).GetProperties())
                {
                    if (!exceptColumns.Contains(prop.Name))
                    {
                        columnIndex++;
                        excel.Cells[1, columnIndex] = prop.Name;
                    }
                }

                int rowIndex = 0;

                foreach (T data in dataList)
                {
                    rowIndex++;
                    columnIndex = 0;
                    foreach (PropertyInfo prop in typeof(T).GetProperties())
                    {
                        if (!exceptColumns.Contains(prop.Name))
                        {
                            columnIndex++;
                            if (prop.GetValue(data, null) != null)
                            {
                                excel.Cells[rowIndex + 1, columnIndex] = prop.GetValue(data, null).ToString();
                            }
                        }
                    }
                }

                excel.Visible = true;
                Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
                worksheet.Columns.AutoFit();
                worksheet.Activate();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region 이미지관련 유틸리티
        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public static byte[] ImagetoByteArray(Image imgin)
        {
            MemoryStream ms = new MemoryStream();
            imgin.Save(ms, ImageFormat.Gif);
            return ms.ToArray();
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        #endregion

        #region comboBox 바인딩 관련 유틸리티
        public static void ComboBinding(ComboBox combo, List<ComboItemVO> list)
        {
            combo.ValueMember = "ID";
            combo.DisplayMember = "Name";
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
