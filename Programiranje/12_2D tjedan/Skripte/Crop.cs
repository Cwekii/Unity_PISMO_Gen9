using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Crop : MonoBehaviour
{
    private CropData currentCrop;

    private int plantDay;

    private int daysSinceLastWatered;

    public SpriteRenderer sr;

    public static event UnityAction<CropData> OnPlantCrop;

    public static event UnityAction<CropData> onHarvestCrop;

    public void Plant(CropData crop)
    {
        currentCrop = crop;
        plantDay = GameManager.instance.currentDay;
        daysSinceLastWatered = 1;
        UpdateCropSprite();

        OnPlantCrop?.Invoke(crop);
        Debug.Log("Planted " + transform.position);
    }

    public void NewDayCheck()
    {
        daysSinceLastWatered++;

        if(daysSinceLastWatered > 3)
        {
            Destroy(gameObject);
            Debug.Log("No water " + transform.position);
        }

        Debug.Log("Days since last watered: " + daysSinceLastWatered);
        UpdateCropSprite();
    }


    private void UpdateCropSprite()
    {
        int cropProg = CropProgress();

        if(cropProg < currentCrop.daysToGrow)
        {
            sr.sprite = currentCrop.growProgressSprites[cropProg];
            Debug.Log("Grew " + transform.position);
        }

        else
        {
            sr.sprite = currentCrop.readyToHarvestSprite;
            Debug.Log("Ready! " + transform.position);
        }
    }

    public void Water()
    {
        daysSinceLastWatered = 0;
        Debug.Log("Watered! " + transform.position);
    }

    public void Harvest()
    {
        if(CanHarvest())
        {
            onHarvestCrop?.Invoke(currentCrop);
            Destroy(gameObject);
        }
    }



    private int CropProgress()
    {
        return GameManager.instance.currentDay - plantDay;
    }

    public bool CanHarvest()
    {
        return CropProgress() >= currentCrop.daysToGrow;
    }
}
