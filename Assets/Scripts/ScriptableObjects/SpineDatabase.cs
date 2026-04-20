using UnityEngine;
using Spine.Unity;
using System.Collections.Generic;

namespace SlimeColorShop.Data
{
    [CreateAssetMenu(fileName = "SpineDatabase", menuName = "Database/SpineDatabase")]
    public class SpineDatabase : ScriptableObject
    {
        public List<SkeletonDataAsset> SkeletonDataAssets;
        public List<SkeletonDataAsset> SkeletonDataAssets_Slime;
        public List<SkeletonDataAsset> SkeletonDataAssets_ExpressionNormal;
        public List<SkeletonDataAsset> SkeletonDataAssets_ExpressionHappy;
        public List<SkeletonDataAsset> SkeletonDataAssets_ExpressionSad;

        public SkeletonDataAsset GetSkeletonDataAsset(int id)
        {
            if (id < 0 || id >= SkeletonDataAssets.Count)
                id = 0;
            return SkeletonDataAssets[id];
        }

        public SkeletonDataAsset GetSkeletonDataAsset()
        {
            int id = Random.Range(0, SkeletonDataAssets.Count);
            return GetSkeletonDataAsset(id);
        }

        public SkeletonDataAsset GetSkeletonDataAssetFromList(List<SkeletonDataAsset> source, int id)
        {
            if (id < 0 || id >= source.Count)
                id = 0;
            return source[id];
        }

        public SkeletonDataAsset GetSkeletonDataAssetFromList(List<SkeletonDataAsset> source)
        {
            int id = Random.Range(0, source.Count);
            return GetSkeletonDataAssetFromList(source, id);
        }

        public SkeletonDataAsset GetSkeletonDataAsset_Slime()
        {
            return GetSkeletonDataAssetFromList(SkeletonDataAssets_Slime);
        }

        public SkeletonDataAsset GetSkeletonDataAsset_ExpressionNormal()
        {
            return GetSkeletonDataAssetFromList(SkeletonDataAssets_ExpressionNormal);
        }

        public SkeletonDataAsset GetSkeletonDataAsset_ExpressionHappy()
        {
            return GetSkeletonDataAssetFromList(SkeletonDataAssets_ExpressionHappy);
        }

        public SkeletonDataAsset GetSkeletonDataAsset_ExpressionSad()
        {
            return GetSkeletonDataAssetFromList(SkeletonDataAssets_ExpressionSad);
        }
    }
}
