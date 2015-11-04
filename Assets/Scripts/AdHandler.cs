using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class AdHandler : MonoBehaviour {

    private BannerView bannerView;
    
    void Awake()
    {
        // Banner
        string adUnitId = "ca-app-pub-8299109678258685/4687466858";

        AdSize adSize = new AdSize(250, 50);
        bannerView = new BannerView(adUnitId, adSize, AdPosition.Bottom);
        //bannerView.LoadAd(new AdRequest.Builder().AddTestDevice(deviceId).Build());
        bannerView.LoadAd(new AdRequest.Builder().Build());
        bannerView.Show();
    }

    void OnDestroy() 
    { 
        DestroyBanner(); 
    }

    public void HideBanner()
    {
        bannerView.Hide();
    }

    public void ShowBanner()
    {
        bannerView.Show();
    }

    public void DestroyBanner()
    {
        bannerView.Destroy();
    }

    
}
