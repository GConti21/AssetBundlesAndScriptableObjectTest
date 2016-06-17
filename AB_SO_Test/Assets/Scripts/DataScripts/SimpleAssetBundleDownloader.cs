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

    void Start () {
        StartCoroutine(DownloadAssetBundle());
    }

    /// <summary>
    /// Downloads the asset bundle.
    /// </summary>
    IEnumerator DownloadAssetBundle() {
        // Download the file from the URL. It will not be saved in the Cache
        // Memory is freed from the web stream (www.Dispose() gets called implicitly)
        using (WWW www = new WWW(assetBundleUrl)) {
            yield return www;
            if (www.error != null) {
                throw new Exception("WWW download had an error:" + www.error);
            }                
            AssetBundle bundle = www.assetBundle;
            myDataObject.spriteField = bundle.LoadAsset<Sprite>(assetBundleName);

        }
    }

}
