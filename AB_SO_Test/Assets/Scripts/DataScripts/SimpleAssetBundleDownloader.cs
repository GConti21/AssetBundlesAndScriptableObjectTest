using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

/// <summary>
/// Simple asset bundle downloader.
/// </summary>
public class SimpleAssetBundleDownloader : MonoBehaviour {

    /// <summary>
    /// The asset bundle URL.
    /// </summary>
    public string assetBundleUrl;

    /// <summary>
    /// The name of the asset bundle.
    /// </summary>
    public string assetBundleName;

    /// <summary>
    /// The reference to My data object scriptable object.
    /// </summary>
    public MyDataObject myDataObject;

    public delegate void RefAction (ref Sprite param1, AssetBundle param2);

    void Start () {
        //myDataObject.spriteField = DownloadAssetBundle(assetBundleUrl).LoadAsset<Sprite>(assetBundleName);
        StartCoroutine(DownloadAssetBundle(assetBundleUrl, assetBundleName, MapAssetBundle, myDataObject));
    }


    /// <summary>
    /// Downloads the asset bundle.
    /// </summary>
    IEnumerator DownloadAssetBundle(string assetBundleUrl, string assetBundleName, RefAction onComplete, MyDataObject scriptableObject) {
        // Download the file from the URL. It will not be saved in the Cache
        // Memory is freed from the web stream (www.Dispose() gets called implicitly)
        using (WWW www = new WWW(assetBundleUrl)) {
            yield return www;
            if (www.error != null) {
                throw new Exception("WWW download had an error:" + www.error);
            }                
            else {
                onComplete(ref scriptableObject.spriteField, www.assetBundle);
            }
        }
    }

    void MapAssetBundle (ref Sprite sprite, AssetBundle assetBundle) {
        sprite = assetBundle.LoadAsset<Sprite>(assetBundleName);

    }

    /* --------------------------------------------------------------------- */

//    public WWW GET(string url) {
//        // TODO: Averiguar si haciendo "using (WWW www = new WWW(assetBundleUrl)) {" al final se libera la memoria...
//        WWW www = new WWW (url);
//        StartCoroutine (WaitForRequest (www));
//        //yield StartCoroutine(WaitForRequest (www));
//        //yield StartCoroutine("WaitForRequest");
//        return www;
//    }
//
//    private IEnumerator WaitForRequest(WWW www) {
//        yield return www;
//        // check for errors
//        if (www.error != null) {
//            throw new Exception("WWW download had an error:" + www.error);
//        }
//    }
//
//    AssetBundle DownloadAssetBundle (string assetBundleUrl) {
//        return GET(assetBundleUrl).assetBundle;
//    }


}
