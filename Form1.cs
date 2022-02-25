using Flurl.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using WallPaperEngineWinForm.Dtos;

namespace WallPaperEngineWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectFolderPath_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                var path = folderBrowserDialog.SelectedPath;
                txtSelectFolderPath.Text = path;
            }
        }


        public async Task GetWallPaperAsync(string path, int pg)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            const string category = "ls";
            var url = $"https://juehackr.net/bizhis/index/views/t/{category}/cc/6.html?isget=1&pg={pg}";

            var result = await url.GetJsonAsync<IList<WallPaperDto>>();
            foreach (var item in result)
            {
                var file = new FileInfo(item.url);
                var suffix = file.Extension;

                var localPictureName = Path.Combine(path, $"{item.tag.Replace(",", "")}{suffix}");
                var stream = await item.url.GetStreamAsync();

                using var fileStream = new FileStream(localPictureName, FileMode.Create);
                await stream.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            var taskFactory = new TaskFactory();
            await taskFactory.StartNew(async () =>
            {
                await GetWallPaperAsync(txtSelectFolderPath.Text, Convert.ToInt32(txtCount.Text));
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var categoryDtos = new List<CategoryDto>
            {
                new CategoryDto
                {
                    Id = 1,
                    Text = "首页"
                },
                new CategoryDto
                {
                    Id = 1,
                    Text = "最新"
                },
                new CategoryDto
                {
                    Id = 1,
                    Text = "4k",
                },
                new CategoryDto
                {
                    Id = 1,
                    Text = "小清新"
                }
            };

            cmbType.DataSource = categoryDtos;
            cmbType.DisplayMember = "Text";
            cmbType.ValueMember = "TypeCode";
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex == 0)
            {
                return;
            }

            var categoryDtos = new List<CategoryDto>
            {
                new CategoryDto
                {
                    Id = 1,
                    Text = "护眼壁纸"
                },
                new CategoryDto
                {
                    Id = 1,
                    Text = "舒缓压力"
                },
                new CategoryDto
                {
                    Id = 1,
                    Text = "温馨一刻",
                },
                new CategoryDto
                {
                    Id = 1,
                    Text = "清新淡雅"
                },
                new CategoryDto
                {
                    Id = 1,
                    Text = "静物写真"
                },
                new CategoryDto
                {
                    Id = 1,
                    Text = "鸟语花香"
                },
                new CategoryDto
                {
                    Id = 1,
                    Text = "动感水果"
                },
                new CategoryDto
                {
                    Id = 1,
                    Text = "娇艳欲滴"
                }
            };

            if (cmbType.SelectedIndex == 3)
            {
                cmbType2.DataSource = categoryDtos;
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