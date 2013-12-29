using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Collections;

namespace Bussiness.Common
{
    /// <summary>
    /// 水印的类型
    /// </summary>
    public enum WaterMarkType
    {
        /// <summary>
        /// 文字水印
        /// </summary>
        TextMark,
        /// <summary>
        /// 图片水印
        /// </summary>
        //ImageMark // 暂时只能添加文字水印
    };

    /// <summary>
    /// 水印的位置
    /// </summary>
    public enum WaterMarkPosition
    {
        /// <summary>
        /// 左上角
        /// </summary>
        WMP_Left_Top,
        /// <summary>
        /// 左下角
        /// </summary>
        WMP_Left_Bottom,
        /// <summary>
        /// 右上角
        /// </summary>
        WMP_Right_Top,
        /// <summary>
        /// 右下角
        /// </summary>
        WMP_Right_Bottom
    };
    public class Images
    {
        #region Data

        private Stream data = null;

        /// <summary>
        /// 设置图像数据流
        /// </summary>
        /// <param name="imageData"></param>
        public Stream SetImageData
        {
            set { data = value; }
            get { return data; }
        }

        #endregion

        #region Method

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path"></param>
        public void Delete(string filePath)
        {
            filePath = System.Web.HttpContext.Current.Server.MapPath(filePath);
            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        /// <summary>
        /// 检查目录
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string CheckedDirectory(string path)
        {
            path = System.Web.HttpContext.Current.Server.MapPath(path) + @"\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }


        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public bool Image(string fileName, string filePath)
        {
            if (data != null)
            {
                filePath = CheckedDirectory(filePath) + fileName;
                using (System.Drawing.Image img = System.Drawing.Image.FromStream(data))
                {
                    img.Save(filePath);
                }

                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 缩略图
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="path">路径</param>
        /// <param name="targetWidth">宽度</param>
        /// <param name="targetHeight">高度</param>
        /// <returns></returns>
        public bool ThumbnailImage(string fileName, string filePath, ref int targetWidth, ref int targetHeight)
        {
            if (data != null)
            {
                filePath = CheckedDirectory(filePath);

                using (System.Drawing.Image originalImage = System.Drawing.Image.FromStream(data))
                {
                    if (targetWidth <= 0 && targetHeight <= 0)
                    {
                        targetWidth = originalImage.Width;
                        targetHeight = originalImage.Height;
                        originalImage.Save(filePath + fileName);
                        return true;
                    }

                    if (targetWidth > 0 && targetHeight == 0)
                        targetHeight = (int)((float)originalImage.Height / ((float)originalImage.Width / (float)targetWidth));
                    else if (targetWidth == 0 && targetHeight > 0)
                        targetWidth = (int)((float)originalImage.Width / ((float)originalImage.Height / (float)targetHeight));

                    System.Drawing.Image img = originalImage.GetThumbnailImage(targetWidth, targetHeight, null, IntPtr.Zero);
                    img.Save(filePath + fileName);
                    img.Dispose();
                }

                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 委托回调
        /// </summary>
        /// <returns></returns>
        bool ThumbnailCallback()
        {
            return false;
        }

        /// <summary>
        /// 裁切图片
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="path">路径</param>
        /// <param name="x1">起始横坐标</param>
        /// <param name="y1">起始纵坐标</param>
        /// <param name="x2">终始横坐标</param>
        /// <param name="y2">终始纵坐标</param>
        /// <param name="targetWidth">宽度</param>
        /// <param name="targetHeight">高度</param>
        /// <returns></returns>
        public bool Image(string fileName, string filePath, int x1, int y1, int x2, int y2, int targetWidth, int targetHeight)
        {
            if (data != null)
            {
                filePath = CheckedDirectory(filePath);

                using (System.Drawing.Image originalImage = System.Drawing.Image.FromStream(data))
                {
                    int width = x2 - x1;
                    int height = y2 - y1;

                    using (System.Drawing.Image finalImage = new Bitmap(width, height))
                    {
                        using (System.Drawing.Graphics graphic = Graphics.FromImage(finalImage))
                        {
                            // Create rectangle for source image.
                            Rectangle desRect = new Rectangle(0, 0, width, height);
                            Rectangle srcRect = new Rectangle(x1, y1, width, height);
                            GraphicsUnit units = GraphicsUnit.Pixel;

                            graphic.InterpolationMode = InterpolationMode.High;
                            graphic.SmoothingMode = SmoothingMode.HighQuality;
                            graphic.Clear(Color.White);
                            graphic.DrawImage(originalImage, desRect, srcRect, units);
                        }

                        Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                        System.Drawing.Image zoomImage = finalImage.GetThumbnailImage(targetWidth, targetHeight, myCallback, IntPtr.Zero);

                        zoomImage.Save(filePath + fileName);
                        zoomImage.Dispose();

                    }
                }

                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 裁切图片
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="path">路径</param>
        /// <param name="targetWidth">宽度</param>
        /// <param name="targetHeight">高度</param>
        /// <returns></returns>
        public bool Image(string fileName, string filePath, int targetWidth, int targetHeight)
        {
            if (data != null)
            {
                filePath = CheckedDirectory(filePath);

                using (System.Drawing.Image originalImage = System.Drawing.Image.FromStream(data))
                {
                    int width = originalImage.Width;
                    int height = originalImage.Height;
                    int newWidth, newHeight;

                    ///目标宽高比率
                    float targetRatio = float.Parse(targetWidth.ToString()) / float.Parse(targetHeight.ToString());
                    ///当前图像宽高比率
                    float imageRatio = float.Parse(width.ToString()) / float.Parse(height.ToString());

                    ///如果目标比率 与 当前图像比率 比较
                    if (targetRatio < imageRatio)
                    {
                        ///大于
                        ///高度取目标比率
                        newHeight = targetHeight;
                        ///宽度同比率缩放尺寸
                        newWidth = int.Parse(Math.Floor(imageRatio * float.Parse(targetHeight.ToString())).ToString());
                    }
                    else
                    {
                        newHeight = int.Parse(Math.Floor(float.Parse((height * targetWidth).ToString()) / float.Parse(width.ToString())).ToString());
                        newWidth = targetWidth;
                    }

                    int paste_x = -Math.Abs((targetWidth - newWidth) / 2);
                    int paste_y = -Math.Abs((targetHeight - newHeight) / 2);

                    using (System.Drawing.Image finalImage = new Bitmap(targetWidth, targetHeight))
                    {
                        using (System.Drawing.Graphics graphic = Graphics.FromImage(finalImage))
                        {
                            graphic.InterpolationMode = InterpolationMode.High;
                            graphic.SmoothingMode = SmoothingMode.HighQuality;
                            graphic.Clear(Color.White);
                            graphic.DrawImage(originalImage, new Rectangle(paste_x, paste_y, newWidth, newHeight));
                        }

                        finalImage.Save(filePath + fileName);
                    }
                }

                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 缩放图片
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="path">路径</param>
        /// <param name="targetWidth">宽度</param>
        /// <param name="targetHeight">高度</param>
        /// <param name="color">背景色</param>
        /// <returns></returns>
        public bool Image(string fileName, string filePath, int targetWidth, int targetHeight, System.Drawing.Color color)
        {
            if (data != null)
            {
                filePath = CheckedDirectory(filePath);

                using (System.Drawing.Image originalImage = System.Drawing.Image.FromStream(data))
                {
                    int width = originalImage.Width;
                    int height = originalImage.Height;
                    int newWidth, newHeight;

                    float targetRatio = float.Parse(targetWidth.ToString()) / float.Parse(targetHeight.ToString());
                    float imageRatio = float.Parse(width.ToString()) / float.Parse(height.ToString());

                    if (targetRatio > imageRatio)
                    {
                        newHeight = targetHeight;
                        newWidth = int.Parse(Math.Floor(imageRatio * float.Parse(targetHeight.ToString())).ToString());
                    }
                    else
                    {
                        newHeight = int.Parse(Math.Floor(float.Parse(targetWidth.ToString()) / imageRatio).ToString());
                        newWidth = targetWidth;
                    }

                    newWidth = newWidth > targetWidth ? targetWidth : newWidth;
                    newHeight = newHeight > targetHeight ? targetHeight : newHeight;

                    using (System.Drawing.Image finalImage = new Bitmap(targetWidth, targetHeight))
                    {
                        using (System.Drawing.Graphics graphic = Graphics.FromImage(finalImage))
                        {
                            graphic.FillRectangle(new System.Drawing.SolidBrush(color), new System.Drawing.Rectangle(0, 0, targetWidth, targetHeight));
                            int paste_x = (targetWidth - newWidth) / 2;
                            int paste_y = (targetHeight - newHeight) / 2;
                            graphic.InterpolationMode = InterpolationMode.High;
                            graphic.SmoothingMode = SmoothingMode.HighQuality;
                            graphic.DrawImage(originalImage, paste_x, paste_y, newWidth, newHeight);

                            finalImage.Save(filePath + fileName);
                        }
                    }
                }

                return true;
            }
            else
                return false;
        }
     #endregion

        #region 给图片加水印
        /// <summary>
        /// 添加水印(分图片水印与文字水印两种)
        /// </summary>
        /// <param name="oldpath">原图片绝对地址</param>
        /// <param name="newpath">新图片放置的绝对地址</param>
        /// <param name="wmtType">要添加的水印的类型</param>
        /// <param name="sWaterMarkContent">水印内容，若添加文字水印，此即为要添加的文字；
        /// 若要添加图片水印，此为图片的路径</param>
        public void addWaterMark(string oldpath, string newpath,
            WaterMarkType wmtType, string sWaterMarkContent)
        {
            try
            {
                Image image = System.Drawing.Image.FromFile(oldpath);

                Bitmap b = new Bitmap(image.Width, image.Height,
                    PixelFormat.Format24bppRgb);

                Graphics g = Graphics.FromImage(b);
                g.Clear(Color.White);
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.High;

                g.DrawImage(image, 0, 0, image.Width, image.Height);

                switch (wmtType)
                {
                    /*case WaterMarkType.ImageMark:
                        //图片水印
                        this.addWatermarkImage(g, 
                            Page.Server.MapPath(Watermarkimgpath), 
                            WatermarkPosition,image.Width,image.Height);
                        break;*/
                    case WaterMarkType.TextMark:
                        //文字水印
                        this.addWatermarkText(g, sWaterMarkContent, "WM_BOTTOM_RIGHT",
                            image.Width, image.Height);
                        break;
                }

                b.Save(newpath);
                b.Dispose();
                image.Dispose();
            }
            catch
            {
                if (File.Exists(oldpath))
                {
                    File.Delete(oldpath);
                }
            }
            finally
            {
                if (File.Exists(oldpath))
                {
                    File.Delete(oldpath);
                }
            }
        }

        /// <summary>
        ///  加水印文字
        /// </summary>
        /// <param name="picture">imge 对象</param>
        /// <param name="_watermarkText">水印文字内容</param>
        /// <param name="_watermarkPosition">水印位置</param>
        /// <param name="_width">被加水印图片的宽</param>
        /// <param name="_height">被加水印图片的高</param>
        private void addWatermarkText(Graphics picture, string _watermarkText,
            string _watermarkPosition, int _width, int _height)
        {
            // 确定水印文字的字体大小
            int[] sizes = new int[] { 32, 30, 28, 26, 24, 22, 20, 18, 16, 14, 12, 10, 8, 6, 4 };
            Font crFont = null;
            SizeF crSize = new SizeF();
            for (int i = 0; i < sizes.Length; i++)
            {
                crFont = new Font("Arial Black", sizes[i], FontStyle.Bold);
                crSize = picture.MeasureString(_watermarkText, crFont);

                if ((ushort)crSize.Width < (ushort)_width)
                {
                    break;
                }
            }

            // 生成水印图片（将文字写到图片中）
            Bitmap floatBmp = new Bitmap((int)crSize.Width + 3,
                           (int)crSize.Height + 3, PixelFormat.Format32bppArgb);
            Graphics fg = Graphics.FromImage(floatBmp);
            PointF pt = new PointF(0, 0);

            // 画阴影文字
            Brush TransparentBrush0 = new SolidBrush(Color.FromArgb(255, Color.Black));
            Brush TransparentBrush1 = new SolidBrush(Color.FromArgb(255, Color.Black));
            fg.DrawString(_watermarkText, crFont, TransparentBrush0, pt.X, pt.Y + 1);
            fg.DrawString(_watermarkText, crFont, TransparentBrush0, pt.X + 1, pt.Y);

            fg.DrawString(_watermarkText, crFont, TransparentBrush1, pt.X + 1, pt.Y + 1);
            fg.DrawString(_watermarkText, crFont, TransparentBrush1, pt.X, pt.Y + 2);
            fg.DrawString(_watermarkText, crFont, TransparentBrush1, pt.X + 2, pt.Y);

            TransparentBrush0.Dispose();
            TransparentBrush1.Dispose();

            // 画文字
            fg.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            fg.DrawString(_watermarkText,
                crFont, new SolidBrush(Color.White),
                pt.X, pt.Y, StringFormat.GenericDefault);

            // 保存刚才的操作
            fg.Save();
            fg.Dispose();
            // floatBmp.Save("d:\\WebSite\\DIGITALKM\\ttt.jpg");

            // 将水印图片加到原图中
            this.addWatermarkImage(
                picture,
                new Bitmap(floatBmp),
                "WM_BOTTOM_RIGHT",
                _width,
                _height);
        }

        /// <summary>
        ///  加水印图片
        /// </summary>
        /// <param name="picture">imge 对象</param>
        /// <param name="iTheImage">Image对象（以此图片为水印）</param>
        /// <param name="_watermarkPosition">水印位置</param>
        /// <param name="_width">被加水印图片的宽</param>
        /// <param name="_height">被加水印图片的高</param>
        private void addWatermarkImage(Graphics picture, Image iTheImage,
            string _watermarkPosition, int _width, int _height)
        {
            Image watermark = new Bitmap(iTheImage);

            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMap colorMap = new ColorMap();

            colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
            colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
            ColorMap[] remapTable = { colorMap };

            imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

            float[][] colorMatrixElements = {
                                                new float[] {1.0f, 0.0f, 0.0f, 0.0f, 0.0f},
                                                new float[] {0.0f, 1.0f, 0.0f, 0.0f, 0.0f},
                                                new float[] {0.0f, 0.0f, 1.0f, 0.0f, 0.0f},
                                                new float[] {0.0f, 0.0f, 0.0f, 0.3f, 0.0f},
                                                new float[] {0.0f, 0.0f, 0.0f, 0.0f, 1.0f}
                                            };

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            int xpos = 0;
            int ypos = 0;
            int WatermarkWidth = 0;
            int WatermarkHeight = 0;
            double bl = 1d;

            //计算水印图片的比率
            //取背景的1/4宽度来比较
            if ((_width > watermark.Width * 4) && (_height > watermark.Height * 4))
            {
                bl = 1;
            }
            else if ((_width > watermark.Width * 4) && (_height < watermark.Height * 4))
            {
                bl = Convert.ToDouble(_height / 4) / Convert.ToDouble(watermark.Height);

            }
            else if ((_width < watermark.Width * 4) && (_height > watermark.Height * 4))
            {
                bl = Convert.ToDouble(_width / 4) / Convert.ToDouble(watermark.Width);
            }
            else
            {
                if ((_width * watermark.Height) > (_height * watermark.Width))
                {
                    bl = Convert.ToDouble(_height / 4) / Convert.ToDouble(watermark.Height);

                }
                else
                {
                    bl = Convert.ToDouble(_width / 4) / Convert.ToDouble(watermark.Width);

                }

            }

            WatermarkWidth = Convert.ToInt32(watermark.Width * bl);
            WatermarkHeight = Convert.ToInt32(watermark.Height * bl);

            switch (_watermarkPosition)
            {
                case "WM_TOP_LEFT":
                    xpos = 10;
                    ypos = 10;
                    break;
                case "WM_TOP_RIGHT":
                    xpos = _width - WatermarkWidth - 10;
                    ypos = 10;
                    break;
                case "WM_BOTTOM_RIGHT":
                    xpos = _width - WatermarkWidth - 10;
                    ypos = _height - WatermarkHeight - 10;
                    break;
                case "WM_BOTTOM_LEFT":
                    xpos = 10;
                    ypos = _height - WatermarkHeight - 10;
                    break;
            }

            picture.DrawImage(
                watermark,
                new Rectangle(xpos, ypos, WatermarkWidth, WatermarkHeight),
                0,
                0,
                watermark.Width,
                watermark.Height,
                GraphicsUnit.Pixel,
                imageAttributes);

            watermark.Dispose();
            imageAttributes.Dispose();
        }

        /// <summary>
        ///  加水印图片
        /// </summary>
        /// <param name="picture">imge 对象</param>
        /// <param name="WaterMarkPicPath">水印图片的地址</param>
        /// <param name="_watermarkPosition">水印位置</param>
        /// <param name="_width">被加水印图片的宽</param>
        /// <param name="_height">被加水印图片的高</param>
        private void addWatermarkImage(Graphics picture, string WaterMarkPicPath,
            string _watermarkPosition, int _width, int _height)
        {
            Image watermark = new Bitmap(WaterMarkPicPath);

            this.addWatermarkImage(picture, watermark, _watermarkPosition, _width,
                _height);
        }
        #endregion

        #region 生成缩略图
        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="image">Image 对象</param>
        /// <param name="savePath">保存路径</param>
        /// <param name="ici">指定格式的编解码参数</param>
        private void SaveImage(Image image, string savePath, ImageCodecInfo ici)
        {
            //设置 原图片 对象的 EncoderParameters 对象
            EncoderParameters parameters = new EncoderParameters(1);
            parameters.Param[0] = new EncoderParameter(
                System.Drawing.Imaging.Encoder.Quality, ((long)90));
            image.Save(savePath, ici, parameters);
            parameters.Dispose();
        }

        /// <summary>
        /// 获取图像编码解码器的所有相关信息
        /// </summary>
        /// <param name="mimeType">包含编码解码器的多用途网际邮件扩充协议 (MIME) 类型的字符串</param>
        /// <returns>返回图像编码解码器的所有相关信息</returns>
        private ImageCodecInfo GetCodecInfo(string mimeType)
        {
            ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo ici in CodecInfo)
            {
                if (ici.MimeType == mimeType)
                    return ici;
            }
            return null;
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="sourceImagePath">原图片路径(相对路径)</param>
        /// <param name="thumbnailImagePath">生成的缩略图路径,如果为空则保存为原图片路径(相对路径)</param>
        /// <param name="thumbnailImageWidth">缩略图的宽度（高度与按源图片比例自动生成）</param>
        public void ToThumbnailImages(
            string SourceImagePath,
            string ThumbnailImagePath,
            int ThumbnailImageWidth)
        {
            Hashtable htmimes = new Hashtable();
            htmimes[".jpeg"] = "image/jpeg";
            htmimes[".jpg"] = "image/jpeg";
            htmimes[".png"] = "image/png";
            htmimes[".tif"] = "image/tiff";
            htmimes[".tiff"] = "image/tiff";
            htmimes[".bmp"] = "image/bmp";
            htmimes[".gif"] = "image/gif";

            // 取得原图片的后缀
            string sExt = SourceImagePath.Substring(
                SourceImagePath.LastIndexOf(".")).ToLower();

            //从 原图片 创建 Image 对象
            Image image = System.Drawing.Image.FromFile(SourceImagePath);
            int num = ((ThumbnailImageWidth / 4) * 3);
            int width = image.Width;
            int height = image.Height;

            //计算图片的比例
            if ((((double)width) / ((double)height)) >= 1.3333333333333333f)
            {
                num = ((height * ThumbnailImageWidth) / width);
            }
            else
            {
                ThumbnailImageWidth = ((width * num) / height);
            }
            if ((ThumbnailImageWidth < 1) || (num < 1))
            {
                return;
            }

            //用指定的大小和格式初始化 Bitmap 类的新实例
            Bitmap bitmap = new Bitmap(ThumbnailImageWidth, num,
                PixelFormat.Format32bppArgb);

            //从指定的 Image 对象创建新 Graphics 对象
            Graphics graphics = Graphics.FromImage(bitmap);

            //清除整个绘图面并以透明背景色填充
            graphics.Clear(Color.Transparent);

            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.High;

            //在指定位置并且按指定大小绘制 原图片 对象
            graphics.DrawImage(image, new Rectangle(0, 0, ThumbnailImageWidth, num));
            image.Dispose();

            try
            {
                //将此 原图片 以指定格式并用指定的编解码参数保存到指定文件 
                SaveImage(bitmap, ThumbnailImagePath,
                    GetCodecInfo((string)htmimes[sExt]));
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        #endregion
    }    
}
