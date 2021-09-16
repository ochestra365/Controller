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
            //DB정보로 해줘도 됨.
            listBox1.Items.Add("VIP회원");
            listBox1.Items.Add("정회원");
            listBox1.Items.Add("준회원");
            listBox1.Items.Add("일일 회원");
            string[] data = { "사과", "토마토", "포도", "배", "복숭아" };
            checkedListBox1.SetItemChecked(0, true);
            checkedListBox1.SetItemChecked(1, true);
            comboBox1.Items.AddRange(data);
            comboBox1.SelectedIndex = 0;
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
      
        }
    }
}
