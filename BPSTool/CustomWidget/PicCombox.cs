using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BPSTool.CustomWidget
{
    [ToolboxItem(true)]
    public class PicCombox : ComboBox
    {
        public PicCombox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
            ItemHeight = 50;
            Width = 200;
        }

        // Draws the items into the ColorSelector object
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (Items.Count == 0 || e.Index == -1)
                return;
            if ((e.State & DrawItemState.Selected) != 0)
            {
                //渐变画刷
                LinearGradientBrush brush = new LinearGradientBrush(e.Bounds, Color.FromArgb(255, 251, 237),
                                                 Color.FromArgb(255, 236, 181), LinearGradientMode.Vertical);
                //填充区域
                Rectangle borderRect = new Rectangle(3, e.Bounds.Y, e.Bounds.Width - 5, e.Bounds.Height - 2);

                e.Graphics.FillRectangle(brush, borderRect);

                //画边框
                Pen pen = new Pen(Color.FromArgb(229, 195, 101));
                e.Graphics.DrawRectangle(pen, borderRect);
            }
            else
            {
                SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            //获得项图片,绘制图片
            PicComboxItem item = (PicComboxItem)Items[e.Index];
            Image img = item.Image;

            //图片绘制的区域
            Rectangle imgRect = new Rectangle(6, e.Bounds.Y + 3, 45, 45);
            e.Graphics.DrawImage(img, imgRect);

            //文本内容显示区域
            Rectangle textRect =
                    new Rectangle(imgRect.Right + 2, imgRect.Y, e.Bounds.Width - imgRect.Width, e.Bounds.Height - 2);

            //获得项文本内容,绘制文本
            String itemText = Items[e.Index].ToString();

            //文本格式垂直居中
            StringFormat strFormat = new StringFormat();
            strFormat.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(itemText, new Font("微软雅黑", 12), Brushes.Black, textRect, strFormat);
            base.OnDrawItem(e);
        }
    }

    public class PicComboxItem
    {
        public string Text { get; set; }

        public Image Image { get; set; }

        public PicComboxItem(string text, Image img)
        {
            Text = text;
            Image = img;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
