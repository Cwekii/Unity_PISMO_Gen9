using UnityEngine;

public class FieldTile : MonoBehaviour
{
    private Crop currentCrop;

    public GameObject cropPrefab;

    public SpriteRenderer sr;

    private bool tilled;

    [Header("Sprites")]
    public Sprite grassSprite;
    public Sprite tilledSprite;
    public Sprite wateredTilledSprite;

    private void Start()
    {
        sr.sprite = grassSprite;
    }

    public void Interact()
    {
        if (!tilled)
        {
            Till();
        }

        else if (!HasCrop() && GameManager.instance.CanPlantCrop())
        {
            PlantNewCrop(GameManager.instance.selectedCropToPlant);
        }

        else if (HasCrop() && currentCrop.CanHarvest())
        {
            GameManager.instance.onNewDay -= OnNewDay;
            currentCrop.Harvest();
        }

        else
        {
            Water();
        }




    }

    private void PlantNewCrop(CropData crop)
    {
        if(!tilled)
        {
            return;
        }

        currentCrop = Instantiate(cropPrefab, transform).GetComponent<Crop>();
        currentCrop.Plant(crop);

        GameManager.instance.onNewDay += OnNewDay;
        
    }

    private void Till()
    {
        tilled = true;
        sr.sprite = tilledSprite;
    }

    private void Water()
    {
        sr.sprite = wateredTilledSprite;

        if(HasCrop())
        {
            currentCrop.Water();
        }
    }

    public void OnNewDay()
    {
        if(currentCrop == null)
        {
            tilled = false;
            sr.sprite = grassSprite;

            GameManager.instance.onNewDay -= OnNewDay;
        }

        else if(currentCrop != null)
        {
            sr.sprite = tilledSprite;
            currentCrop.NewDayCheck();
        }
    }

    private bool HasCrop()
    {
        return currentCrop != null;
    }
}
