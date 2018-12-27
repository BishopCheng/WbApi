using CacheServers;
using System;
using System.Collections.Generic;
using System.DrawingCore;
using System.DrawingCore.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

namespace ValidateServer
{
    /// <summary>
    /// 公用工具类
    /// </summary>
    public static class Tools
    {

        public static string validateKey = "key";
        /// <summary>
        /// 验证码生成类
        /// </summary>
        public static class identifyingCodeBulid
        {

            private static string charset = "1,2,3,4,5,6,7,8,9,0,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";   //定义显示的字符串
            private static string[] charArr = charset.Split(',');
            private static List<string> charArrayList_;
            private static int Codelength = 4;

            public static List<string> CharArrayList
            {
                get { return charArrayList_; }
                set { charArrayList_ = value; }
            }
            /// <summary>
            /// 获取验证码内容字母集合
            /// </summary>
            /// <returns></returns>
            public static List<string> GetCharArray()
            {
                List<string> CharArray = new List<string>();
                for (int i = 0; i < charArr.Length; i++)
                {
                    CharArray.Add(charArr[i] + "");
                }
                return CharArray;
            }

            /// <summary>
            /// 验证码生成
            /// </summary>
            /// <returns></returns>
            public static string CodeBulid()
            {
                string codeInfo = "";
                if (CharArrayList == null)
                {
                    CharArrayList = GetCharArray();
                }
                Random RM = new Random();
                for (int j = 0; j < Codelength; j++)
                {
                    int kj = RM.Next(CharArrayList.Count);
                    codeInfo += CharArrayList[kj] + "";
                }
                return codeInfo;
            }


            /// <summary>
            /// 验证码图片生成
            /// </summary>
            /// <param name="CodeInput">传入的Code</param>
            /// <returns></returns>
            public static MemoryStream CreateValidateCode(out string codeString)
            {
                string CodeStr = CodeBulid();               //获取生成的字符串
                Bitmap Img = null;                          //准备画布
                Graphics ghics = null;                      //限定绘图区域
                Color[] C = { Color.Black, Color.Red, Color.Blue, Color.Orange, Color.Gray, Color.Green, Color.Pink, Color.Yellow, Color.Purple };//准备颜色
                String[] fonts = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial" };//准备字体
                Random Rm = new Random();

                //定义画布尺寸
                Img = new Bitmap(37 * Codelength, 50); //定义一张 150X50的画布
                ghics = Graphics.FromImage(Img);       //填充区域
                ghics.Clear(Color.White);              //将画布背景设置为白色

                for (int i = 0; i < 50; i++)         //随机在画布上生成50个噪点
                {
                    int x = Rm.Next(Img.Width);
                    int y = Rm.Next(Img.Height);
                    ghics.DrawRectangle(new Pen(Color.LightCyan, 0), x, y, 1, 1);
                }
                //将Code画在ghics上 9种颜色，4种字体
                for (int i = 0; i < Codelength; i++)
                {
                    float charHeigth = 0;                //设定字符高度
                    int indexColorNum = Rm.Next(9);    //产生的颜色位置
                    int indexFontNum = Rm.Next(4);     //产生的字体位置
                    if (i % 2 == 0) { charHeigth = 20; }
                    else { charHeigth = 30; }
                    Font f = new Font(fonts[indexFontNum], 16.0F, FontStyle.Bold);
                    Brush b = new SolidBrush(C[indexColorNum]);
                    string T = CodeStr.Substring(i, 1);
                    ghics.DrawString(T, f, b, 10 + (i * 35), charHeigth); //绘制字符
                }
                MemoryStream ms = new MemoryStream();     //流输出
                Img.Save(ms, ImageFormat.Jpeg);           //以jpeg格式保存流

                //将String值存入缓存
                CommonCache.CacheObj.Save<MemoryCacheHelper>(validateKey, CodeStr);


                Img.Dispose();
                ghics.Dispose();                           //回收资源
                codeString = CodeStr + "";                 //通过out返回要验证的string
                return ms;                                 //返回数据流
            }
        }
    }
}
