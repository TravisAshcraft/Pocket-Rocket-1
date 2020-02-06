using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdManager : MonoBehaviour, IUnityAdsListener
{
    private string playStoreID = "3457215";
    private string appStoreID = "3457214";

    private string interstitialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";

    public bool isTargetPlayStore;
    public bool isTargetAppStore;
    public bool isTestAd;

    private void Start()
    {
        IntializeAdvertisment();
    }

    private void IntializeAdvertisment()
    {
        if(isTargetAppStore)
        {
            Advertisement.Initialize(appStoreID, isTestAd); return;
        }
    }

    public void PlayInterstitialAd()
    {
        if (!Advertisement.IsReady(interstitialAd))
        {
            return;
        }
        Advertisement.Show(interstitialAd);
    }

    public void PlayRewardedVideoAd()
    {
        if (!Advertisement.IsReady(rewardedVideoAd)) { return; }
        Advertisement.Show(rewardedVideoAd);
    }

    public void OnUnityAdsReady(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        AudioListener.volume = 0;
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Finished:
                if(placementId == rewardedVideoAd) { Debug.Log("Reward the player with some rocket fuel bitch!!!"); }
                break;
        }
        AudioListener.volume = 1;
    }
}
