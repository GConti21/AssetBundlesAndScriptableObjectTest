using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class HTTPConnection : MonoBehaviour {

    /// <summary>
    /// Performs an HTTP GET request
    /// </summary>
    /// <param name="url"> The request's url </param>
    /// <param name="onComplete"> The callback method once the GET request has completed </param>
    public WWW GET(string url, Action<WWW> onComplete ) {
        // TODO: Averiguar si haciendo "using (WWW www = new WWW(assetBundleUrl)) {" al final se libera la memoria...
        WWW www = new WWW (url);
        StartCoroutine (WaitForRequest (www, onComplete));
        return www;
    }


    /// <summary>
    /// Performs an HTTP POST request
    /// </summary>
    /// <param name="url"> The request's url </param>
    /// <param name="postData"> Form data to be sent to the POST request </param>
    /// <param name="onComplete"> The callback method once the POST request has completed </param>
    /// <param name="header"> Request header. Use this to simulate another HTTP methods, like PUT, DELETE, etc </param>
    public WWW POST(string url, byte[] postData, Action<WWW> onComplete, Dictionary<string,string> header=null) {
        WWWForm form = new WWWForm();
        // Performs the POST request
        WWW www = new WWW(url, postData, header);
        // Waits until the request has a response and calls the onComplete callback
        StartCoroutine(WaitForRequest(www, onComplete));
        return www;
    }


    /// <summary>
    /// Coroutine who calls the onComplete callback once the request has completed
    /// </summary>
    /// <param name="www"> The request response </param>
    /// <param name="onComplete"> The callback method once the POST request has completed </param>
    private IEnumerator WaitForRequest(WWW www, Action<WWW> onComplete) {
        yield return www;
        // check for errors
        if (www.error == null) {
            onComplete(www);
        } 
        else {
            Debug.LogError ("Error: " + www.error);
            Debug.LogError ("Details: " + www.text);
            throw new Exception("WWW download had an error:" + www.error);
        }
    }


    /// <summary>
    /// Prints the result.
    /// </summary>
    /// <param name="www"> The request response </param>
    public void PrintResult (WWW www) {
        Debug.Log("Response: " + www.text);
    }

}
