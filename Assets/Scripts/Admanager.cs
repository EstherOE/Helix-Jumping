using System;
using UnityEngine;
using GoogleMobileAds.Api;
public class Admanager : MonoBehaviour
{
    private BannerView view;
    private InterstitialAd ad;

    public static Admanager instance;
   
    // Start is called before the first frame update

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        MobileAds.Initialize(InitializationStatus => { });
        

        this.RequestBanner();
    }

    private AdRequest createRequest()
    {
        return new AdRequest.Builder().Build();
    }
    private void RequestBanner()
    {
        string unitId = "ca-app-pub-3940256099942544/6300978111";
        this.view = new BannerView(unitId, AdSize.SmartBanner, AdPosition.Bottom);
        
        this.view.LoadAd(createRequest());
    }


    public void RequestInter()
    {
        string adUnit = "ca-app-pub-3940256099942544/1033173712";
        if (this.ad != null)
            this.ad.Destroy();
        this.ad = new InterstitialAd(adUnit);
        this.ad.LoadAd(this.createRequest());
    }

    public void showInter()
    {
        if(this.ad.IsLoaded())
        {
            ad.Show();
        }

        else
        {
            Debug.Log("Not working");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
