#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace SlimeColorShop.Editor
{
    public class SaveDataEditor
    {
        [MenuItem("Assets/Editor/Change Save Value/Add Coin by 100")]
        public static void AddCoinBy100()
        {
            InventoryManager.Instance.AddCoin(100, false);
        }

        [MenuItem("Assets/Editor/Change Save Value/Reset Save")]
        public static void ResetSave()
        {
            PlayerPrefs.DeleteAll();
        }

        [MenuItem("Assets/Editor/Show Save Value/PERSONAL_RECORD")]
        public static void Show_PERSONAL_RECORD()
        {
            string key = "PERSONAL_RECORD";
            string saveData = PlayerPrefs.GetString(key, "");
            Debug.Log(
                string.Format("'{0}': '{1}'", key, saveData)
            );
        }
    }
}
#endif