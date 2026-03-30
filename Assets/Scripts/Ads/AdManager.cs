using GoogleMobileAds.Api;
using UnityEngine;

namespace SlimeColorShop.Ads
{
    public class AdManager : MonoBehaviour
    {
        private string _bannerId;
        private string _interstitialId;
        private string _rewardedId;

        private BannerView _bannerView;
        private InterstitialAd _interstitialAd;
        private RewardedAd _rewardedAd;

        public void Init()
        {
            _bannerId = AdConst.DemoAdaptiveBannerAdUnitId;
            _interstitialId = AdConst.DemoInterstitialAdUnitId;
            _rewardedId = AdConst.DemoRewardedAdsAdUnitId;

            MobileAds.Initialize((InitializationStatus status) => {
                Debug.Log("AdMob Initialized.");
                
                LoadInterstitialAd();
                LoadRewardedAd();
            });
        }

        #region BANNER
        public void LoadBannerAd()
        {
            if (_bannerView != null) _bannerView.Destroy();
            
            // Create a 320x50 banner at the top of the screen
            _bannerView = new BannerView(_bannerId, AdSize.Banner, AdPosition.Top);
            _bannerView.LoadAd(new AdRequest());
        }
        #endregion

        #region INTERSTITIAL (Full Screen)
        public void LoadInterstitialAd()
        {
            if (_interstitialAd != null) _interstitialAd.Destroy();

            InterstitialAd.Load(_interstitialId, new AdRequest(), (ad, error) => {
                if (error != null) return;
                _interstitialAd = ad;
            });
        }

        public void ShowInterstitial()
        {
            if (_interstitialAd != null && _interstitialAd.CanShowAd())
                _interstitialAd.Show();
            else
                LoadInterstitialAd();
        }
        #endregion

        #region REWARDED (Video for coins/lives)
        public void LoadRewardedAd()
        {
            if (_rewardedAd != null) _rewardedAd.Destroy();

            RewardedAd.Load(_rewardedId, new AdRequest(), (ad, error) => {
                if (error != null) return;
                _rewardedAd = ad;
            });
        }

        public void ShowRewarded()
        {
            if (_rewardedAd != null && _rewardedAd.CanShowAd())
            {
                _rewardedAd.Show((Reward reward) => {
                    Debug.Log($"Player earned: {reward.Amount} {reward.Type}");
                    // Add your reward logic here!
                });
            }
        }
        #endregion
    }

    public class AdConst
    {
        public const string DemoAppOpenAdUnitId = "ca-app-pub-3940256099942544/9257395921";
        public const string DemoAdaptiveBannerAdUnitId = "ca-app-pub-3940256099942544/9214589741";
        public const string DemoInterstitialAdUnitId = "ca-app-pub-3940256099942544/1033173712";
        public const string DemoRewardedAdsAdUnitId = "ca-app-pub-3940256099942544/5224354917";
    }
}