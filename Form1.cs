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
        enum Meat 
        {등심,안심,갈비 }
        private Meat _selectedMeat;

        public enum MemberType 
        {
            VIP=0,
            Regular,
            Associate,
            DayPass
        }
        private Timer timer;
        private int timerCount = 0;
        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
            progressBar2.PerformStep();
            if (++timerCount == 10)
            {
                timer.Stop();
                progressBar3.Enabled = false;
            }
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
            progressBar1.Style = ProgressBarStyle.Blocks;

            progressBar2.Style = ProgressBarStyle.Continuous;
            progressBar2.Minimum = 0;
            progressBar2.Maximum = 90;
            progressBar2.Step = 5;
            progressBar2.Value = 0;

            progressBar3.Style = ProgressBarStyle.Marquee;
            progressBar3.Enabled = true;

            timer.Start();

            numericUpDown1.Value = 21.0M;
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

            monthCalendar1.SelectionStart = DateTime.Now;
            monthCalendar1.SelectionEnd = DateTime.Now.AddDays(3);

            monthCalendar1.MaxSelectionCount = 31;

            ContextMenu ctx = new ContextMenu();
            ctx.MenuItems.Add(new MenuItem("열기"));
            ctx.MenuItems.Add(new MenuItem("실행"));
            ctx.MenuItems.Add("-");
            ctx.MenuItems.Add(new MenuItem("종료", new EventHandler((s, ex) => this.Close())));
            notifyIcon1.ContextMenu = ctx;

            textBox4.Text = "제주특별자치도 헤헤";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("이름 : 박성철");
            sb.AppendLine("나이 : 28세");
            sb.AppendLine("국적 : 탐라국");
            textBox4.Text = sb.ToString();
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

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox1.Text = monthCalendar1.SelectionStart.ToShortDateString();
            textBox2.Text = monthCalendar1.SelectionEnd.ToShortDateString();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            decimal C = numericUpDown1.Value;
            decimal F = C * (9.0M / 5.0M) + 32.0M;
            this.textBox3.Text = F.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Bitmap.FromFile("folder.png");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.SizeMode == PictureBoxSizeMode.Zoom)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            this._selectedMeat = Meat.등심;
            DisPlayMenu();
        }

        private void DisPlayMenu()
        {
            label2.Text = string.Format("{0}", this._selectedMeat.ToString());
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            this._selectedMeat = Meat.안심;
            DisPlayMenu();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            this._selectedMeat = Meat.갈비;
            DisPlayMenu();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.SelectionStart = textBox4.TextLength;
            textBox4.SelectionLength = 0;
        }
    }
}
