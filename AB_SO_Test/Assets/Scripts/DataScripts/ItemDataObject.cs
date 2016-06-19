using UnityEngine;
using System.Collections;

/// <summary>
/// Item data object.
/// </summary>
[System.Serializable]
public class ItemDataObject {

    /// <summary>
    /// The name.
    /// </summary>
    public string name;

    /// <summary>
    /// The identifier on the server side
    /// </summary>
    public int id;

    /// <summary>
    /// The URL to get the asset bundle on the server
    /// </summary>
    public string url;

    /// <summary>
    /// The upper sprite.
    /// </summary>
    public Sprite smallSprite;

    /// <summary>
    /// The lower sprite.
    /// </summary>
    public Sprite bigSprite;

}
