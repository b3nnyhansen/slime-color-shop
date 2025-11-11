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
    }
}
#endif