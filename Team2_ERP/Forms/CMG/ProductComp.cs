using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team2_ERP.Service.CMG;
using Team2_VO;

namespace Team2_ERP
{
    public partial class ProductComp : BasePopup
    {
        public enum EditMode { Insert, Update }

        string mode = string.Empty;
        string pCode = string.Empty;
        string pName = string.Empty;

        int count = 0;

        byte[] filePath;

        List<ProductVO> list = null;

        SemiProductCompControl spc;

        public ProductComp(EditMode editMode, ProductVO item)
        {
            InitializeComponent();

            if (editMode == EditMode.Insert)
            {
                lblName.Text = "완제품 등록";
                mode = "Insert";
                pbxTitle.Image = Properties.Resources.AddFile_32x32;
            }
            else
            {
                lblName.Text = "완제품 수정";
                mode = "Update";
                pbxTitle.Image = Properties.Resources.Edit_32x32;
                pCode = item.Product_ID;
                pName = item.Product_Name;
            }
        }

        private void InitCombo()
        {
            StandardService service = new StandardService();
            List<ComboItemVO> productList = (from item in service.GetComboProductCategory() where item.ID.Contains("CP") select item).ToList();
            UtilClass.ComboBinding(cboProductCategory, productList, "선택");
            List<ComboItemVO> categoryList = (from item in service.GetComboProductCategory() where item.ID.Contains("CS") select item).ToList();
            UtilClass.ComboBinding(cboSemiProductCategory, categoryList, "선택");
            CategoryLabelName(categoryList);

        }

        private void InitGridView()
        {
            UtilClass.SettingDgv(dgvProduct);

            UtilClass.AddNewColum(dgvProduct, "제품이름", "Product_Name", true, 100);
            UtilClass.AddNewColum(dgvProduct, "제품가격", "Product_Price", true, 100, DataGridViewContentAlignment.MiddleRight);
            UtilClass.AddNewColum(dgvProduct, "제품카테고리", "Product_Category", false, 100);
            UtilClass.AddNewColum(dgvProduct, "제품ID", "Product_ID", false, 100);
            dgvProduct.Columns[1].DefaultCellStyle.Format = "#,##0원";

            dgvProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void LoadGridView()
        {
            StandardService service = new StandardService();
            list = service.GetAllProduct();
            List<ProductVO> resourceList = (from item in list where item.Product_Category.Contains($"{cboSemiProductCategory.SelectedValue.ToString()}") select item).ToList();
            dgvProduct.DataSource = resourceList;
        }

        private void CategoryLabelName(List<ComboItemVO> countList)
        {
            for (int i = 1; i < countList.Count; i++)
            {
                spc = new SemiProductCompControl();
                spc.Location = new Point(0, i * 40);
                spc.LblName.Text = countList[i].Name;
                spc.LblName.Tag = countList[i].ID;

                spc.Qty.ValueChanged += new EventHandler(TotalPrice);
                numProductQty.ValueChanged += new EventHandler(TotalPrice);

                splitContainer2.Panel1.Controls.Add(spc);
            }
        }

        private void TotalPrice(object sender, EventArgs e)
        {
            int sum = 0;

            foreach (Control control in splitContainer2.Panel1.Controls)
            {
                if (control is SemiProductCompControl)
                {
                    SemiProductCompControl spc = (SemiProductCompControl)control;

                    if (!string.IsNullOrEmpty(spc.LblMoney.Text))
                        sum += Convert.ToInt32(list.Find(i => i.Product_ID == spc.TxtName.Tag.ToString()).Product_Price * spc.Qty.Value);

                    txtProductMoney.Tag = sum;
                    numericUpDown1_ValueChanged(this, null);
                }
            }
        }

        private void GetImage()
        {
            StandardService service = new StandardService();
            List<ProductVO> productList = service.GetImage(pCode);
            filePath = productList[0].Product_Image;
            MemoryStream ms = new MemoryStream(filePath);
            pictureBox1.Image = Image.FromStream(ms);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProductComp_Load(object sender, EventArgs e)
        {
            InitCombo();
            InitGridView();
            if (mode.Equals("Update"))
            {
                txtProductName.Text = pName;
                GetImage();
            }
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSemiProductCategory.SelectedIndex < 1)
                return;

            if (!cboSemiProductCategory.SelectedValue.ToString().Contains("CS"))
                return;

            LoadGridView();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numProductQty.Value > 0)
            {
                txtProductMoney.Text = (Convert.ToInt32(txtProductMoney.Tag) * Convert.ToInt32(numProductQty.Value)).ToString("#,##0") + "원";
            }
            else
            {
                txtProductMoney.Text = "0원";
            }
        }

        private void InsertProduct()
        {
            Cursor currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            string localFile = pictureBox1.Tag.ToString().Replace("\\", "/");

            byte[] ImageData;
            FileStream fs = new FileStream(localFile, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            ImageData = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();

            ProductVO Pitem = new ProductVO
            {
                Product_Name = txtProductName.Text,
                Product_Price = Convert.ToInt32(txtProductMoney.Text.Replace(",", "").Replace("원", "")),
                Product_Category = cboProductCategory.SelectedValue.ToString(),
                Product_Image = ImageData,
                Product_Qty = Convert.ToInt32(numProductQty.Value)
            };

            List<CombinationVO> citemList = new List<CombinationVO>();

            foreach (Control control in splitContainer2.Panel1.Controls)
            {
                if (control is SemiProductCompControl)
                {
                    SemiProductCompControl spc = (SemiProductCompControl)control;

                    CombinationVO citem = new CombinationVO
                    {
                        Combination_Product_ID = spc.TxtName.Tag.ToString(),
                        Combination_RequiredQty = Convert.ToInt32(spc.Qty.Value)
                    };

                    count += spc.Controls.Count;
                    citemList.Add(citem);
                }
            }

            StandardService service = new StandardService();
            service.InsertProduct(Pitem, citemList, count);
        }

        private void UpdateProduct()
        {
            Cursor currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            string localFile = pictureBox1.Tag.ToString().Replace("\\", "/");

            byte[] ImageData;
            FileStream fs = new FileStream(localFile, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            ImageData = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();

            if (ImageData == null)
            {
                ImageData = filePath;
            }

            ProductVO Pitem = new ProductVO
            {
                Product_ID = pCode,
                Product_Name = txtProductName.Text,
                Product_Image = ImageData,
                Product_Price = Convert.ToInt32(txtProductMoney.Text.Replace(",", "").Replace("원", "")),
                Product_Category = cboProductCategory.SelectedValue.ToString(),
                Product_Qty = Convert.ToInt32(numProductQty.Value)
            };

            List<CombinationVO> citemList = new List<CombinationVO>();

            foreach (Control control in splitContainer2.Panel1.Controls)
            {
                if (control is SemiProductCompControl)
                {
                    SemiProductCompControl spc = (SemiProductCompControl)control;

                    CombinationVO citem = new CombinationVO
                    {
                        Combination_Product_ID = spc.TxtName.Tag.ToString(),
                        Combination_RequiredQty = Convert.ToInt32(spc.Qty.Value)
                    };

                    count += spc.Controls.Count;
                    citemList.Add(citem);
                }
            }

            StandardService service = new StandardService();
            service.UpdateProduct(Pitem, citemList, count);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(spc.TxtName.Tag != null && txtProductImage.Text.Length > 0 && txtProductName.Text.Length > 0 && numProductQty.Value > 0 && txtProductMoney.Text.Length > 0)
            {
                if(mode.Equals("Insert"))
                {
                    InsertProduct();
                    DialogResult = MessageBox.Show(Properties.Settings.Default.AddDone, Properties.Settings.Default.AddDone, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    UpdateProduct();
                    DialogResult = MessageBox.Show(Properties.Settings.Default.ModDone, Properties.Settings.Default.ModDone, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(Properties.Settings.Default.isEssential, Properties.Settings.Default.MsgBoxTitleWarn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnImageAdd_Click(object sender, EventArgs e)
        {
            Cursor currentCursor = this.Cursor;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                openFileDialog1.Title = "Select a Image File";
                openFileDialog1.InitialDirectory = "C:";
                openFileDialog1.Filter = "Images Files(*.jpg; *.jpeg; *.gif; *.png; *.bmp)|*.jpg;*.gpeg;*.gif;*.png;*.bmp";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtProductImage.Text = openFileDialog1.FileName.ToString();
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                    pictureBox1.Tag = openFileDialog1.FileName;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                this.Cursor = currentCursor;
            }
        }

        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && dgvProduct.SelectedRows.Count > 0)
            {
                foreach (Control control in splitContainer2.Panel1.Controls)
                {
                    if (control is SemiProductCompControl)
                    {
                        SemiProductCompControl spc = (SemiProductCompControl)control;

                        if (spc.LblName.Tag.ToString() == dgvProduct.SelectedRows[0].Cells[2].Value.ToString())
                        {
                            spc.TxtName.Text = dgvProduct.SelectedRows[0].Cells[0].Value.ToString();
                            spc.TxtName.Tag = dgvProduct.SelectedRows[0].Cells[3].Value;
                            spc.LblMoney.Text = Convert.ToInt32(dgvProduct.SelectedRows[0].Cells[1].Value).ToString("#,##0") + "원";
                            if (txtProductMoney.Text.Equals("0원") || txtProductMoney.Text.Length < 1)
                                txtProductMoney.Text = spc.LblMoney.Text;
                            else
                                txtProductMoney.Text = (Convert.ToInt32(txtProductMoney.Text.Replace(",", "").Replace("원", "")) + Convert.ToInt32(spc.LblMoney.Text.Replace(",", "").Replace("원", ""))).ToString("#,##0") + "원";

                            spc.Qty.Tag = dgvProduct.SelectedRows[0].Cells[1].Value;
                        }
                    }
                }
            }
        }
    }
}