using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Crop data", menuName = "New crop data")]
public class CropData : ScriptableObject
{
    public int daysToGrow;

    public Sprite[] growProgressSprites;

    public Sprite readyToHarvestSprite;

    public int purchasePrice;

    public int sellPrice;
}
