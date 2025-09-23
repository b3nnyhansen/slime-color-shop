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
                string colorName = content[3];
                string colorHexCode = content[4];
                string colorLikePhrase = content[5];
                string colorCombinationPhrase = content[6];

                string entryFilePath = string.Format(entryStringPathFormat, dataPath, i);
                ColorQuestionEntry entry = ScriptableObject.CreateInstance<ColorQuestionEntry>();
                entry.R = r;
                entry.G = g;
                entry.B = b;
                entry.ColorName = colorName;
                entry.ColorHexCode = colorHexCode;
                entry.ColorLikePhrase = colorLikePhrase;
                entry.ColorCombinationPhrase = colorCombinationPhrase;

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