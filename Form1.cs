using Flurl.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using WallPaperEngineWinForm.Dtos;

namespace WallPaperEngineWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 存储目录选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectFolderPath_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                return;

            var path = folderBrowserDialog.SelectedPath;
            txtSelectFolderPath.Text = path;
        }

        /// <summary>
        /// 获取图片Url 默认查询10条
        /// </summary>
        /// <param name="pg"></param>
        private async Task GetWallPaperAsync(int pg)
        {
            const string category = "ls";
            var url = $"https://juehackr.net/bizhis/index/views/t/{category}/cc/6.html?isget=1&pg={pg}";

            var result = await url.GetJsonAsync<IList<WallPaperDto>>();
            await DownLoadAsync(result);
        }

        /// <summary>
        /// 下载到本地
        /// </summary>
        /// <param name="input"></param>
        private async Task DownLoadAsync(IEnumerable<WallPaperDto> input)
        {
            foreach (var item in input)
            {
                var file = new FileInfo(item.url);
                var suffix = file.Extension;

                var localPictureName = Path.Combine(txtSelectFolderPath.Text, $"{item.tag.Replace(",", "")}{suffix}");
                var stream = await item.url.GetStreamAsync();

                using var fileStream = new FileStream(localPictureName, FileMode.Create);
                await stream.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
            }
        }

        /// <summary>
        /// 任务开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnStart_Click(object sender, EventArgs e)
        {
            var taskFactory = new TaskFactory();
            await taskFactory.StartNew(async () => { await GetWallPaperAsync(Convert.ToInt32(txtCount.Text)); });
        }

        /// <summary>
        /// 窗体初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            const string path = @"C:\Users\奉仙\source\repos\WallPaperEngineWinForm\DataFiles";
            const string fileName = "FirstType.json";
            var directory = Path.Combine(path, fileName);

            using var streamReader = new StreamReader(directory);
            var jsonStr = streamReader.ReadToEnd();
            var categoryData = JsonConvert.DeserializeObject<List<CategoryDto>>(jsonStr);

            cmbType.DataSource = categoryData;
            cmbType.DisplayMember = "Text";
            cmbType.ValueMember = "TypeCode";
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex == 0)
            {
                return;
            }

            const string path = @"C:\Users\奉仙\source\repos\WallPaperEngineWinForm\DataFiles";
            const string fileName = "Type.json";
            var directory = Path.Combine(path, fileName);

            using var streamReader = new StreamReader(directory);
            var jsonStr = streamReader.ReadToEnd();
            var categoryData = JsonConvert.DeserializeObject<List<CategoryDto>>(jsonStr)
                .Where(x => x.ParentId == cmbType.SelectedIndex + 1)
                .Select(t => new CategoryDto()
                {
                    Text = t.Text,
                    Id = t.Id,
                    ParentId = t.ParentId,
                    TypeCode = t.TypeCode
                }).ToList();


            if (cmbType.SelectedIndex == 3)
            {
                cmbType2.DataSource = categoryData;
                cmbType2.DisplayMember = "Text";
                cmbType2.ValueMember = "TypeCode";
            }
            else
            {
                cmbType2.DataSource = null;
            }
        }

        private void cmbType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //var dd = sender as ComboBox;
            //MessageBox.Show($"{dd.SelectedIndex}");
        }
    }
}