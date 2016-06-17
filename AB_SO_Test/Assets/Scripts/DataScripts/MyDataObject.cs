using UnityEngine;
using System.Collections;

/// <summary>
/// Class to represent some generic data.
/// </summary>
[CreateAssetMenu(fileName = "MyDataObject")]
public class MyDataObject : ScriptableObject {
    
    /// <summary>
    /// A string generic field.
    /// </summary>
    public string stringField;

    /// <summary>
    /// A float generic field.
    /// </summary>
    public float floatField;

    /// <summary>
    /// A sprite generic field.
    /// </summary>
    public Sprite spriteField;

}
