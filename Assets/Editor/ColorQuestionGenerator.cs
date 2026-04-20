#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using SlimeColorShop.Data;

namespace SlimeColorShop.Editor
{
    public class ColorQuestionGenerator
    {
        private static string rawDataPath = "Assets/Editor/raw_data_colors.txt";
        private static string dataPath = "Assets/Data/Questions";
        private static string databasePath = "Assets/Data/Databases";
        private static string entryStringPathFormat = "{0}/Data_ColorQuestion_{1:0000}.asset";
        private static string databaseStringPathFormat = "{0}/Database_ColorQuestion.asset";

        [MenuItem("Assets/Editor/Generate Entry/ColorQuestion")]
        public static void GenerateColorQuestionEntries()
        {
            string rawContent = File.ReadAllText(rawDataPath);
            string[] rawContents = rawContent.Split("||");
            int fileCount = rawContents.Length;
            for (int i = 0; i < fileCount; i++)
            {
                string[] content = rawContents[i].Split("|");
                int r = int.Parse(content[0]);
                int g = int.Parse(content[1]);
                int b = int.Parse(content[2]);
                string colorName_EN = content[3];
                string colorHexCode_EN = content[4];
                string colorLikePhrase_EN = content[5];
                string colorCombinationPhrase_EN = content[6];
                string colorName_ID = content[7];
                string colorHexCode_ID = content[8];
                string colorLikePhrase_ID = content[9];
                string colorCombinationPhrase_ID = content[10];

                string entryFilePath = string.Format(entryStringPathFormat, dataPath, i);
                ColorQuestionEntry entry = ScriptableObject.CreateInstance<ColorQuestionEntry>();
                entry.R = r;
                entry.G = g;
                entry.B = b;
                entry.ColorName_EN = colorName_EN;
                entry.ColorHexCode_EN = colorHexCode_EN;
                entry.ColorLikePhrase_EN = colorLikePhrase_EN;
                entry.ColorCombinationPhrase_EN = colorCombinationPhrase_EN;
                entry.ColorName_ID = colorName_ID;
                entry.ColorHexCode_ID = colorHexCode_ID;
                entry.ColorLikePhrase_ID = colorLikePhrase_ID;
                entry.ColorCombinationPhrase_ID = colorCombinationPhrase_ID;

                try
                {
                    AssetDatabase.CreateAsset(entry, entryFilePath);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                }
                catch (Exception e)
                {
                    Debug.Log(
                        string.Format("An error occurred: {0}", e)
                    );
                    return;
                }
            }
        }

        [MenuItem("Assets/Editor/Generate Database/ColorQuestion")]
        public static void GenerateColorQuestionDatabase()
        {
            string rawContent = File.ReadAllText(rawDataPath);
            string[] rawContents = rawContent.Split("||");
            int fileCount = rawContents.Length;
            List<ColorQuestionEntry> entries = new List<ColorQuestionEntry>();
            for (int i = 0; i < fileCount; i++)
            {
                string assetPath = string.Format(entryStringPathFormat, dataPath, i);
                ColorQuestionEntry currentEntry = AssetDatabase.LoadAssetAtPath<ColorQuestionEntry>(assetPath);
                if (currentEntry != null)
                    entries.Add(currentEntry);
            }

            string databaseFilePath = string.Format(databaseStringPathFormat, databasePath);
            ColorQuestionDatabase entryDatabase = ScriptableObject.CreateInstance<ColorQuestionDatabase>();
            entryDatabase.Entries = entries;
            try
            {
                AssetDatabase.CreateAsset(entryDatabase, databaseFilePath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
            catch (Exception e)
            {
                Debug.Log(
                    string.Format("An error occurred: {0}", e)
                );
                return;
            }
        }
    }
}
#endif