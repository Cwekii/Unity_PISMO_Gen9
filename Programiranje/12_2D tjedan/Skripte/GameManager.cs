using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int currentDay;

    public int money;

    public int cropInventory;

    public CropData selectedCropToPlant;

    public TextMeshProUGUI statsText;

    public event UnityAction onNewDay;

    public static GameManager instance;


    private void OnEnable()
    {
        Crop.OnPlantCrop += OnPlantCrop;
        Crop.onHarvestCrop += OnHarvestCrop;
    }

    private void OnDisable()
    {
        Crop.OnPlantCrop -= OnPlantCrop;
        Crop.onHarvestCrop -= OnHarvestCrop;
    }
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }

        else
        {
            instance = this;
        }

        UpdateStatsText();
    }

    public void SetNewDay()
    {
        currentDay++;
        onNewDay?.Invoke();
        UpdateStatsText();

    }

    public void OnPlantCrop(CropData crop)
    {
        cropInventory--;
        UpdateStatsText();
    }

    public void OnHarvestCrop(CropData crop)
    {
        money += crop.sellPrice;
        UpdateStatsText();
    }

    public void OnPurchaseCrop(CropData crop)
    {
        money -= crop.purchasePrice;
        cropInventory++;
        UpdateStatsText();
    }

    public bool CanPlantCrop()
    {
        return cropInventory > 0;
    }

    public void OnBuyCropButton(CropData crop)
    {
        if(money >= crop.purchasePrice)
        {
            OnPurchaseCrop(crop);
        }
    }

    private void UpdateStatsText()
    {
        statsText.text = $"Day: {currentDay} \nMoney: {money} \nCrop inventory: {cropInventory}";
    }

}
