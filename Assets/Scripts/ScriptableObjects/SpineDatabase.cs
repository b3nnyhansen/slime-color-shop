using UnityEngine;
using Spine.Unity;
using System.Collections.Generic;

namespace SlimeColorShop.Data
{
    [CreateAssetMenu(fileName = "SpineDatabase", menuName = "Database/SpineDatabase")]
    public class SpineDatabase : ScriptableObject
    {
        public List<SkeletonDataAsset> SkeletonDataAssets;

        public int GetSkeletonDataAssetCount()
        {
            return SkeletonDataAssets.Count;
        }

        public SkeletonDataAsset GetSkeletonDataAsset(int id)
        {
            if (id < 0 || id >= SkeletonDataAssets.Count)
                id = 0;
            return SkeletonDataAssets[id];
        }

        public SkeletonDataAsset GetSkeletonDataAsset()
        {
            int id = Random.Range(0, GetSkeletonDataAssetCount());
            return GetSkeletonDataAsset(id);
        }
    }
}
