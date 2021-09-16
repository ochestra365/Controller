using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public enum MemberType 
        {
            VIP=0,
            Regular,
            Associate,
            DayPass
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Cyan;
            button1.ForeColor = Color.Blue;
            button1.Text = "Processing...";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = checkBox1.Checked;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Mask = "(999)000-0000";
            //DB정보로 해줘도 됨.
            listBox1.Items.Add("VIP회원");
            listBox1.Items.Add("정회원");
            listBox1.Items.Add("준회원");
            listBox1.Items.Add("일일 회원");
            listBox1.SelectedIndex = 1;

            string[] data = { "사과", "토마토", "포도", "배", "복숭아" };
            checkedListBox1.SetItemChecked(0, true);
            checkedListBox1.SetItemChecked(1, true);
            comboBox1.Items.AddRange(data);
            comboBox1.SelectedIndex = 0;

            string currDir = Environment.CurrentDirectory;
            DirectoryInfo di = new DirectoryInfo(currDir);
            FileInfo[] files = di.GetFiles();

            listView1.BeginUpdate();
            listView1.View = View.Details;
            listView1.LargeImageList = imageList1;
            listView1.SmallImageList = imageList2;
            foreach(var fi in files)
            {
                ListViewItem lvi = new ListViewItem(fi.Name);
                lvi.SubItems.Add(fi.Length.ToString());
                lvi.SubItems.Add(fi.LastWriteTime.ToString());
                lvi.ImageIndex = 0;
                listView1.Items.Add(lvi);
            }
            listView1.Columns.Add("파일명", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("사이즈", 70, HorizontalAlignment.Left);
            listView1.Columns.Add("날짜", 150, HorizontalAlignment.Left);
            listView1.EndUpdate();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = checkedListBox1.SelectedIndex;
            string item = checkedListBox1.SelectedIndex.ToString();
            Debug.WriteLine(index + "/" + item + "이 선택됨");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = dateTimePicker1.Value;
            string str = string.Format("{0}월 {1}일을 선택", dt.Month, dt.Day);
            MessageBox.Show(str, "선택 날짜");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.BackColor = (label1.BackColor == Color.Blue) ? Color.Azure : Color.Blue;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.naver.com");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            memberType = (MemberType)listBox1.SelectedIndex;
        }
        private MemberType memberType;

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.Details;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.List;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.Tile;
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (e.Position < 5)
            {
                toolTip1.Show("숫자나 공란만 입력가능", this);
            }
            else
            {
                toolTip1.Show("숫자만 입력 가능", this);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string val = maskedTextBox1.Text;//f
            MessageBox.Show(val);
        }
    }
}
