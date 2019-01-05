//------------------------------------------------------------
// This file write for Game Framework v3.x
// Which Copyright © 2013-2018 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
// The code write by Ron Tang.
//------------------------------------------------------------

using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using FairyGUI;
using FairyGUIEditor;

namespace UnityGameFramework.Editor
{
    /// <summary>
    /// 生成数据表行代码
    /// </summary>
    internal static class AutoGenerateUICode
    {
        private static readonly string codePath = "\\Scripts\\UI\\Source\\";

        [MenuItem("Game Framework/AutoGenerateUICode", false, 100)]
        private static void HandleAllDataTables()
        {
            EditorToolSet.LoadPackages();

            var packages = UIPackage.GetPackages();
            foreach (var package in packages)
            {
                var items = package.GetItems();
                foreach (var item in items)
                {
                    if (item.type == PackageItemType.Component && item.name.Contains("Panel") && !item.name.Contains("Frame"))
                    {
                        GenerateCode(package.name, item.name);
                    }
                }
            }
            Debug.Log("GenerateUICode Finish");
        }

        static void GenerateCode(string packageName, string itemName)
        {
            string fullPath = Application.dataPath + codePath + "UI" + itemName + ".cs";
            if (File.Exists(fullPath))
            {
                return;
            }

            StreamWriter sw;
            FileInfo t = new FileInfo(fullPath);
            sw = t.CreateText();

            // 文件头
            sw.WriteLine("using " + packageName + ";");

            sw.WriteLine(string.Format("public class UI{0} : UIFormWin", itemName));
            sw.WriteLine("{");
            sw.WriteLine(string.Format("\tpublic UI_{0} ", itemName) + "UI { get; private set; }");
            sw.WriteLine("");
            WriteFuncOnOpen(sw);
            sw.WriteLine("");
            WriteFuncOnRefresh(sw);
            sw.WriteLine("");
            WriteFuncOnInit(sw, itemName);
            sw.WriteLine("}");

            sw.Flush();
            sw.Close();
            sw.Dispose();
        }

        static void WriteFuncOnInit(StreamWriter sw, string itemName)
        {
            sw.WriteLine("\tprotected override void OnInit()");
            sw.WriteLine("\t{");
            sw.WriteLine("\t\tbase.OnInit();");
            sw.WriteLine(string.Format("\t\tUI = contentPane as UI_{0};", itemName));
            sw.WriteLine("\t}");
        }

        static void WriteFuncOnOpen(StreamWriter sw)
        {
            sw.WriteLine("\tprotected override void DoShown(object userData)");
            sw.WriteLine("\t{");
            sw.WriteLine("");
            sw.WriteLine("\t}");
        }

        static void WriteFuncOnRefresh(StreamWriter sw)
        {
            sw.WriteLine("\tprotected override void DoRefresh(object userData)");
            sw.WriteLine("\t{");
            sw.WriteLine("");
            sw.WriteLine("\t}");
        }
    }
}
