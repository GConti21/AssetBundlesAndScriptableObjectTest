using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Category data object.
/// </summary>
[System.Serializable]
public class CategoryDataObject {

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
    /// The item list of this category.
    /// </summary>
    public List<ItemDataObject> itemList;


}
