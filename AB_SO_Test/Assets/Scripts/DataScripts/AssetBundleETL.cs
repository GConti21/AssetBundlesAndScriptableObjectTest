using UnityEngine;
using System.Collections;
using System;

public class AssetBundleETL : MonoBehaviour {

    public CampaignScriptableObject campaignScriptableObject;

    private const string SMALL = "_small";
    private const string BIG = "_big";


	// Use this for initialization
	void Start () {
        DownloadAssetBundles();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void DownloadAssetBundles () {
        foreach (CategoryDataObject category in campaignScriptableObject.categoryList) {            
            foreach (ItemDataObject item in category.itemList) {
//                print ("\tItem = " + item.name);
//                print ("\t\tUrl = " + item.url);
//                print ("\t\tLowerSprite = " + item.name.ToLower() + LOWER);
//                print ("\t\tUpperSprite = " + item.name.ToLower() + UPPER);
                string lowerAssetName = item.name.ToLower() + SMALL;
                string upperAssetName = item.name.ToLower() + BIG;
                StartCoroutine(DownloadAssetBundle(item.url, lowerAssetName, upperAssetName, item));
            }
        }
    }

    IEnumerator DownloadAssetBundle(string assetBundleUrl, string assetName, string assetName2, ItemDataObject itemOnScriptableObject) {
        // Download the file from the URL. It will not be saved in the Cache
        // Memory is freed from the web stream (www.Dispose() gets called implicitly)
        using (WWW www = new WWW(assetBundleUrl)) {
            yield return www;
            if (www.error != null) {
                throw new Exception("WWW download had an error:" + www.error);
            }
            Sprite sprite = www.assetBundle.LoadAsset<Sprite>(assetName);
            Sprite sprite2 = www.assetBundle.LoadAsset<Sprite>(assetName2);
            itemOnScriptableObject.smallSprite = sprite;
            itemOnScriptableObject.bigSprite = sprite2;
        }
    }

    void ResetScriptableObject () {

    }

}
