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
using Team2_ERP.Properties;
using Team2_ERP.Service.CMG;
using Team2_VO;

namespace Team2_ERP
{
    public partial class ProductComp : BasePopup
    {
        public enum EditMode { Insert, Update }

        string mode = string.Empty;
        string pCode = string.Empty;
        string pCategory = string.Empty;

        int count = 0;

        byte[] filePath;

        List<ProductVO> list = null;
        List<BOMVO> productList = null;

        SemiProductCompControl spc;

        public ProductComp(EditMode editMode, ProductVO item)
        {
            InitializeComponent();

            if (editMode == EditMode.Insert)
            {
                lblName.Text = "완제품 등록";
                mode = "Insert";
                pbxTitle.Image = Resources.AddFile_32x32;
            }
            else
            {
                lblName.Text = "완제품 수정";
                mode = "Update";
                pbxTitle.Image = Resources.Edit_32x32;
                pCategory = item.Product_Category;
                pCode = item.Product_ID;
                txtProductName.Text = item.Product_Name;
            }
        }

        private void InitCombo()
        {
            try
            {
                BOMService service = new BOMService();
                if (mode.Equals("Insert"))
                {
                    //완제품의 모든 카테고리 목록 바인딩
                    List<ComboItemVO> productList = (from item in service.GetComboProductCategory() where item.ID.Contains("CP") select item).ToList();
                    UtilClass.ComboBinding(cboProductCategory, productList, "선택");
                }
                else
                {
                    //수정할 완제품의 카테고리만 바인딩
                    List<ComboItemVO> productList = (from item in service.GetComboProductCategory() where item.ID.Equals(pCategory) select item).ToList();
                    UtilClass.ComboBinding(cboProductCategory, productList);
                }
                //반제품의 모든 카테고리 목록 바인딩
                List<ComboItemVO> categoryList = (from item in service.GetComboProductCategory() where item.ID.Contains("CS") select item).ToList();
                UtilClass.ComboBinding(cboSemiProductCategory, categoryList, "선택");
                CategoryLabelName(categoryList);
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
        }

        //데이터그리드뷰 설정
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
            try
            {
                BOMService service = new BOMService();
                list = service.GetAllProduct();
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
            List<ProductVO> resourceList = (from item in list where item.Product_Category.Contains($"{cboSemiProductCategory.SelectedValue.ToString()}") select item).ToList();
            dgvProduct.DataSource = resourceList;
        }

        //사용자컨트롤을 반제품 카테고리 수 만큼 생성하고 라벨 이름을 반제품 카테고리명으로 바꾸고 태그에 카테고리ID를 할당한다.
        private void CategoryLabelName(List<ComboItemVO> countList)
        {
            for (int i = 1; i < countList.Count; i++)
            {
                spc = new SemiProductCompControl();
                spc.Location = new Point(0, i * 40);
                spc.LblName.Text = countList[i].Name;
                spc.LblName.Tag = countList[i].ID;

                spc.Qty.ValueChanged += new EventHandler(TotalPrice);
                nummargin.ValueChanged += new EventHandler(TotalPrice);

                splitContainer2.Panel1.Controls.Add(spc);
            }
        }

        //반제품의 개수를 수정하면 하단에 있는 단가를 수정한다.
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
                    nummargin_ValueChanged(this, null);
                }
            }
        }

        //수정할 때 수정하는 완제품의 이미지를 가져온다.
        private void GetImage()
        {
            try
            {
                BOMService service = new BOMService();
                List<ProductVO> productList = service.GetImage(pCode);
                filePath = productList[0].Product_Image;
                MemoryStream ms = new MemoryStream(filePath);
                pictureBox1.Image = Image.FromStream(ms);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
        }

        //수정할 완제품의 조합데이터를 List에 받아서 사용자 컨트롤에 할당
        private void UpdateInfoLoad()
        {
            try
            {
                BOMService service = new BOMService();
                list = service.GetAllProduct();
                productList = service.GetAllCombination($"'{pCode}'");
                foreach (Control control in splitContainer2.Panel1.Controls)
                {
                    if (control is SemiProductCompControl)
                    {
                        SemiProductCompControl spc = (SemiProductCompControl)control;

                        for (int i = 0; i < productList.Count; i++)
                        {
                            if (spc.LblName.Tag.ToString().Equals(productList[i].Product_Category))
                            {
                                spc.TxtName.Text = productList[i].Product_Name;
                                spc.TxtName.Tag = productList[i].Combination_Product_ID;
                                spc.Qty.Tag = productList[i].Product_Price;
                                spc.Qty.Value = productList[i].Combination_RequiredQty;
                                spc.LblMoney.Tag = 1;
                                spc.LblMoney.Text = productList[i].Product_Price.ToString("#,##0") + "원";
                            }
                        }
                        spc.Qty.ValueChanged += new EventHandler(TotalPrice);
                        nummargin.ValueChanged += new EventHandler(TotalPrice);
                    }
                }
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProductComp_Load(object sender, EventArgs e)
        {
            lblOrigin.Visible = false;
            InitCombo();
            InitGridView();
            //신규등록일 때 기본이미지를 PictureBox에 준다.
            if (mode.Equals("Insert"))
            {
                pictureBox1.Image = pictureBox1.InitialImage;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            //수정일 때 수정하는 완제품의 이미지를 가져오고 완제품의 조합데이터를 가져온다.
            else
            {
                GetImage();
                UpdateInfoLoad();
            }
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //반제품의 목록을 선택 안했을 때
            if (cboSemiProductCategory.SelectedIndex < 1)
                return;

            //반제품의 목록이 아닌 다른것을 선택했을 때
            if (!cboSemiProductCategory.SelectedValue.ToString().Contains("CS"))
                return;

            LoadGridView();
        }

        private void InsertProduct()
        {
            //이미지를 Byte 배열로 변환
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
                Product_Origin = Convert.ToInt32(lblOrigin.Text.Replace(",", "").Replace("원", "")),
                Product_Image = ImageData
            };

            List<BOMVO> citemList = new List<BOMVO>();

            foreach (Control control in splitContainer2.Panel1.Controls)
            {
                if (control is SemiProductCompControl)
                {
                    SemiProductCompControl spc = (SemiProductCompControl)control;

                    BOMVO citem = new BOMVO
                    {
                        Combination_Product_ID = spc.TxtName.Tag.ToString(),
                        Combination_RequiredQty = Convert.ToInt32(spc.Qty.Value)
                    };

                    count += spc.Controls.Count;
                    citemList.Add(citem);
                }
            }

            try
            {
                BOMService service = new BOMService();
                service.InsertProduct(Pitem, citemList, count);
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
        }

        private void UpdateProduct()
        {
            //이미지를 Byte배열로 변환
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
                Product_Origin = Convert.ToInt32(lblOrigin.Text),
                Product_Category = cboProductCategory.SelectedValue.ToString()
            };

            List<BOMVO> citemList = new List<BOMVO>();

            foreach (Control control in splitContainer2.Panel1.Controls)
            {
                if (control is SemiProductCompControl)
                {
                    SemiProductCompControl spc = (SemiProductCompControl)control;

                    BOMVO citem = new BOMVO
                    {
                        Combination_Product_ID = spc.TxtName.Tag.ToString(),
                        Combination_RequiredQty = Convert.ToInt32(spc.Qty.Value)
                    };

                    count += spc.Controls.Count;
                    citemList.Add(citem);
                }
            }

            try
            {
                BOMService service = new BOMService();
                service.UpdateProduct(Pitem, citemList, count);
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cboProductCategory.SelectedValue != null && cboSemiProductCategory.SelectedValue != null && spc.TxtName.Tag != null && pictureBox1.Image != pictureBox1.InitialImage && txtProductName.Text.Length > 0 && txtProductMoney.Text.Length > 0)
            {
                if (mode.Equals("Insert"))
                {
                    InsertProduct();
                    DialogResult = MessageBox.Show(Resources.AddDone, Resources.AddDone, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    UpdateProduct();
                    DialogResult = MessageBox.Show(Resources.ModDone, Resources.ModDone, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(Resources.isEssential, Resources.MsgBoxTitleWarn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnImageAdd_Click(object sender, EventArgs e)
        {
            //찾아보기 버튼을 누를 때 이미지 확장자로만 선택할 수 있게 하고 이미지를 선택하면 PictureBox에 보인다.
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

        //반제품을 선택하면 해당하는 반제품 카테고리 ID와 유저컨트롤 태그 ID를 비교해서 맞는 부분에 반제품 이름과 가격을 설정한다.
        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && dgvProduct.SelectedRows.Count > 0)
            {
                foreach (Control control in splitContainer2.Panel1.Controls)
                {
                    if (control is SemiProductCompControl)
                    {
                        SemiProductCompControl spc = (SemiProductCompControl)control;

                        //데이터그리드뷰에서 선택한 반제품 카테고리와 사용자 컨트롤 반제품 카테고리가 같을 때
                        if (spc.LblName.Tag.ToString() == dgvProduct.SelectedRows[0].Cells[2].Value.ToString())
                        {
                            //사용자컨트롤에 아무정보가 없을 때
                            if (spc.TxtName.Tag == null)
                            {
                                spc.TxtName.Text = dgvProduct.SelectedRows[0].Cells[0].Value.ToString(); //제품이름
                                spc.TxtName.Tag = dgvProduct.SelectedRows[0].Cells[3].Value; //제품ID
                                spc.LblMoney.Text = Convert.ToInt32(dgvProduct.SelectedRows[0].Cells[1].Value).ToString("#,##0") + "원"; //제품가격
                                spc.LblMoney.Tag = 1;
                                spc.Qty.Tag = dgvProduct.SelectedRows[0].Cells[1].Value; //제품가격
                                spc.Qty.Value += 1;
                            }
                            //사용자컨트롤에 정보가 있을 때
                            else
                            {
                                //데이터그리드뷰에서 선택한 반제품 ID와 사용자컨트롤에 있는 반제품의 ID가 같을 때
                                if (spc.TxtName.Tag.ToString() == dgvProduct.SelectedRows[0].Cells[3].Value.ToString())
                                {
                                    spc.Qty.Value += 1;
                                }
                                else
                                {
                                    spc.TxtName.Text = dgvProduct.SelectedRows[0].Cells[0].Value.ToString(); //제품이름
                                    spc.TxtName.Tag = dgvProduct.SelectedRows[0].Cells[3].Value; //제품ID
                                    spc.LblMoney.Text = Convert.ToInt32(dgvProduct.SelectedRows[0].Cells[1].Value).ToString("#,##0") + "원"; //제품가격
                                    spc.LblMoney.Tag = 2;
                                    spc.Qty.Tag = dgvProduct.SelectedRows[0].Cells[1].Value; //제품가격
                                    spc.Qty.Value = 0;
                                    spc.Qty.Value += 1;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void nummargin_ValueChanged(object sender, EventArgs e)
        {
            //마진을 수정해도 원가정보는 변하지 않게 한다.
            lblOrigin.Text = Convert.ToInt32(txtProductMoney.Tag).ToString("#,##0") + "원";

            //마진을 수정할 때
            if (nummargin.Value > 0 && txtProductMoney.Tag != null)
            {
                //원가 + (원가 * 0.01)한 값을 가격에 보여준다.
                txtProductMoney.Text = (Convert.ToInt32(txtProductMoney.Tag) + (Convert.ToInt32(txtProductMoney.Tag) * Convert.ToInt32(nummargin.Value)) * 0.01).ToString("#,##0") + "원";
            }
            else
            {
                //원가를 가격에 보여준다.
                txtProductMoney.Text = Convert.ToInt32(txtProductMoney.Tag).ToString("#,##0") + "원";
            }
        }
    }
}