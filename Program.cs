using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Multimedia.Midi;


namespace MidiToPlist
{
    class Program
    {

        static Dictionary<string, string> compatable = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            string filepath = "";
            //获取程序所在的位置
            string nowpath = AppDomain.CurrentDomain.BaseDirectory;
            compatable = ReadCompatable(nowpath + "compatable.txt");

            //MidiFileReader _smr = new MidiFileReader(filepath);
            //ArrayList _notes = GetNote(_smr);

            if (args.Length >= 1)
            {
                //获取拖入的文件
                foreach (string f in args)
                {
                    filepath = f;

                    //获取路径，名称，还有后缀
                    string path = Path.GetDirectoryName(filepath);
                    string filename = Path.GetFileName(filepath);
                    string Extension = Path.GetExtension(filepath);

                    if (Extension == ".midi" || Extension == ".mid")
                    {



                    }
                    else
                    {
                        Console.WriteLine("这个文件是:" + filename);
                        Console.WriteLine("请放入midi文件。。");
                        Console.ReadLine();
                    }
                }
            }
        }

        static void CreateFille(string filename,string path,ArrayList notes)
        {
            //不存在文件
            if (!File.Exists(filename))
            {
                FileStream fs1 = new FileStream(filename, FileMode.Create, FileAccess.Write);//创建写入文件 
                StreamWriter sw = new StreamWriter(fs1);

                //开始写入值
                sw.WriteLine("<!--  filename:" + filename + "  -->");
                sw.Close();
                fs1.Close();
            }
            //存在文件
            else
            {
                FileStream fs = new FileStream(filename, FileMode.Truncate, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                
                //开始写入值
                sr.WriteLine("<!--  filename:" + filename + "  -->");
                sr.Close();
                fs.Close();
            }
        }

        //读取配置表
        static Dictionary<string, string> ReadCompatable(string filepath)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            StreamReader sr = null;
            try
            {
                sr = File.OpenText(filepath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            string line;
            //逐行读取
            while ((line = sr.ReadLine()) != null)
            {
                string[] str = new string[2];
                str = System.Text.RegularExpressions.Regex.Split(line, "\t");
                dic.Add(str[0], str[1]);
            }
            sr.Close();
            sr.Dispose();

            return dic;
        }
    }
}
