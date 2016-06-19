using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Campaign data object.
/// </summary>
[CreateAssetMenu(fileName = "CampaignDataObject")]
public class CampaignScriptableObject : ScriptableObject {

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
    /// The category list of this campaign.
    /// </summary>
    public List<CategoryDataObject> categoryList;
	

}
