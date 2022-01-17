using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsTools : MonoBehaviour, IAdsShower
{
    private const string GameId = "4519317";
    private const string BannerId = "Banner_Android";

    private void Start()
    {
        Advertisement.Initialize(GameId);
    }
    public void ShowBanner()
    {
        Advertisement.Show(BannerId);
    }
}
