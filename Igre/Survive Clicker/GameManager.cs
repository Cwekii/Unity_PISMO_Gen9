using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
public class GameManager : MonoBehaviour
{

    /*
     * vrijeme (dan)
     * 
     Drvo, kamen, metal, zlato

    population, hrana, voda
     
     */
    //TODO: Da ljudi ne umiru odmah nego sa odgodom

    [Header("UI Text")]
    [SerializeField] TMP_Text daysText;
    [SerializeField] TMP_Text woodText;
    [SerializeField] TMP_Text stoneText;
    [SerializeField] TMP_Text metalText;
    [SerializeField] TMP_Text goldText;
    [SerializeField] TMP_Text populationText;
    [SerializeField] TMP_Text foodText;
    [SerializeField] TMP_Text waterText;

    [Header("Values")]
    [SerializeField] int days;
    [SerializeField] float lengthOfDay = 60;
    [SerializeField] int wood;
    [SerializeField] int stone;
    [SerializeField] int metal;
    [SerializeField] int gold; // just currency
    [SerializeField] int population;
    [SerializeField] int idle;
    [SerializeField] int workers;
    [SerializeField] int soldiers;
    [SerializeField] int food;
    [SerializeField] int water;

    [Space]

    [Header("Buttons")]
    [SerializeField] Button confirmButton;
    [SerializeField] Button mineButton;
    [SerializeField] Button farmButton;
    [SerializeField] Button mercenaryButton;

    [Header("Input Fields")]
    [SerializeField] TMP_InputField workerInputField;

    [Header("Panels")]
    [SerializeField] GameObject panel;
    [SerializeField] TextMeshProUGUI panelText;
    [SerializeField] GameObject notificationPanel;

    [SerializeField] Slider timeSlider;
 

    //private variables
    bool isGameOver;

    private int waterWorkers;
    private int foodWorkers;
    private int woodWorkers;
    private int mineWorkers;

    int woodCost = 100;
    int foodCost = 100;
    int waterCost = 100;
    int stoneCost = 100;
    int metalCost = 100;
    int goldCost = 100;

    int mineIndex;
    int farmIndex;

    public void TestSlider()
    {
        Time.timeScale = timeSlider.value;
    }


    private void Start()
    {
        StartCoroutine(DayIncrease());
        StartCoroutine(WeeklyUpdate());
        UpdateUI();
    }

    void UpdateUI()
    {
        woodText.text = $"Wood: {wood}";
        stoneText.text = $"Stone: {stone}";
        metalText.text = $"Metal: {metal}";
        goldText.text = $"Gold: {gold}";
        populationText.text = $"Population: {population}";
        foodText.text = $"Food: {food}";
        waterText.text = $"Water: {water}";

        populationText.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text =
            $"Idle: {idle}";
        populationText.transform.GetChild(0).transform.GetChild(1).GetComponent<TMP_Text>().text =
            $"Workers: {workers}";
        populationText.transform.GetChild(0).transform.GetChild(2).GetComponent<TMP_Text>().text =
            $"Soldiers: {soldiers}";
    }

    IEnumerator DayIncrease()
    {
        daysText.text = $"Day: {days}";

        while (!isGameOver)
        {
            yield return new WaitForSeconds(lengthOfDay);
            DailyUpdate();
        }
    }
    void DailyUpdate()
    {
        IncreaseDay();
        WaterGathering();
        FoodGathering();
        StoneGathering();
        WoodGathering();
        EatFood();
        DrinkWater();
        IncreasePopulation();
        UpdateCostChecker();
        UpdateUI();
    }

    IEnumerator WeeklyUpdate()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(lengthOfDay * 7);
            RandomEvent();
            TaxThePopulation();
        }
    }

    private void IncreaseDay()
    {
        days++;
        daysText.text = $"Day: {days}";
    }

    void EatFood()
    {
        if (food < population)
        {
            int killPeoples = Mathf.CeilToInt((population - food) * 0.05f);
            KillPopulation(killPeoples);
            food = 0;
        }

        else
        {
            food -= population;
        }
    }

    private void DrinkWater()
    {
        if (water < population)
        {
            int killPeoples = Mathf.CeilToInt((population - water) * 0.05f);
            KillPopulation(killPeoples);
            water = 0;
        }

        else
        {
            water -= population;
        }
    }

    void KillPopulation(int killedPeople)
    {
        //smanjiti svaki dio populacije

        for (int i = 0; i < killedPeople; i++)
        {

            int randomPop = Random.Range(0, 3);

            switch (randomPop)
            {
                case 0:
                    //idle
                    if (idle > 0)
                    {
                        idle--;
                        UpdatePopulation();
                    }
                    else
                    {
                        i--;
                        continue;
                    }
                    break;
                case 1:
                    //worker
                    if (workers > 0)
                    {
                        int randomWorker = Random.Range(0, 4);

                        switch (randomWorker)
                        {
                            case 0:
                                if (waterWorkers > 0)
                                {
                                    waterWorkers--;
                                    UpdatePopulation();
                                    break;

                                }
                                else
                                {
                                    continue;
                                }
                            case 1:
                                if (foodWorkers > 0)
                                {
                                    foodWorkers--;
                                    UpdatePopulation();
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            case 2:
                                if (woodWorkers > 0)
                                {
                                    woodWorkers--;
                                    UpdatePopulation();
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            case 3:
                                if (mineWorkers > 0)
                                {
                                    mineWorkers--;
                                    UpdatePopulation();
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                        }
                    }

                    else
                    {
                        i--;
                        continue;
                    }

                    break;
                case 2:

                    //soldiers
                    if (soldiers > 0)
                    {
                        soldiers--;
                        UpdatePopulation();
                    }
                    else
                    {
                        i--;
                        continue;
                    }
                    break;
            }
        }

        UpdatePopulation();

        if(population <= 0)
        {
            isGameOver = true;
            Notification("You lost all of your people, it's over for you.");
        }
    }

    private void IncreasePopulation()
    {
        if (food > 0 && water > 0)
        {
            idle++;
        }

        UpdatePopulation();
    }

    private void UpdatePopulation()
    {
        workers = foodWorkers + waterWorkers + woodWorkers + mineWorkers;
        population = idle + workers + soldiers;
        UpdateUI();
    }

    void WaterGathering()
    {
        water += waterWorkers * 5;
    }

    void FoodGathering()
    {
        food += foodWorkers * 4;
    }

    private void StoneGathering()
    {
        stone += mineWorkers * 200;
    }

    void WoodGathering()
    {
        wood += woodWorkers * 9;
    }

    public void AssignPanelActive (Transform pivot)
    {
        if (panel.activeInHierarchy && pivot.position == panel.transform.position)
        {
            panel.SetActive(false);
        }

        else 
        { 
            panel.SetActive(true);
            panel.transform.position = pivot.position;
            AssignPanelUpdate(pivot);
        }
    }

   private void AssignPanelUpdate (Transform activeResource)
    {
        if (activeResource.position == waterText.transform.position)
        {
            panelText.text = $"Assigned: {waterWorkers}";
        } 
        
        if (activeResource.position == foodText.transform.position)
        {
            panelText.text = $"Assigned: {foodWorkers}";
        } 
        
        if (activeResource.position == woodText.transform.position)
        {
            panelText.text = $"Assigned: {woodWorkers}";
        }
        
        if (activeResource.position == stoneText.transform.position)
        {
            panelText.text = $"Assigned: {mineWorkers}";
        }
    }

    public void AssignWorkers()
    {
        int addedWorkers = int.Parse(workerInputField.text);
        workerInputField.text = string.Empty;


        if (panel.transform.position == waterText.transform.position)
        {
            addedWorkers = Mathf.Clamp(addedWorkers, -waterWorkers, idle);
            waterWorkers += addedWorkers;
            panelText.text = $"Assigned: {waterWorkers}";
        }

        else if (panel.transform.position == foodText.transform.position)
        {
            addedWorkers = Mathf.Clamp(addedWorkers, -foodWorkers, idle); // dodajemo ili oduzimamo radnike
            foodWorkers += addedWorkers;
            panelText.text = $"Assigned: {foodWorkers}";
        }
        else if (panel.transform.position == woodText.transform.position)
        {
            addedWorkers = Mathf.Clamp(addedWorkers, -woodWorkers, idle);
            woodWorkers += addedWorkers;
            panelText.text = $"Assigned: {woodWorkers}";
        }
        else if (panel.transform.position == stoneText.transform.position)
        {
            addedWorkers = Mathf.Clamp(addedWorkers, -mineWorkers, idle);
            mineWorkers += addedWorkers;
            panelText.text = $"Assigned: {mineWorkers}";
        }

        idle -= addedWorkers;
    }

    void UpdateCostChecker()
    {
        //Mine
        if (wood >= woodCost * (mineIndex + 1) && stone >= stoneCost * (mineIndex + 1))
        {
            mineButton.interactable = true;
        }

        else
        {
            mineButton.interactable = false;
        }

        //farm
        if (wood >= woodCost * (farmIndex + 1) && water >= waterCost * (farmIndex + 1) &&
            food >= foodCost * (farmIndex + 1))
        {
            farmButton.interactable = true;
        }
        else
        {
            farmButton.interactable = false;
        }

        if(gold >= 1000)
        {
            // button interacatable true
            mercenaryButton.interactable = true;
        }

        else
        {
            //Button interactable false
            mercenaryButton.interactable= false;
        }

    }

    public void Mining()
    {
        if(mineButton.interactable == true)
        {
            wood -= woodCost * (mineIndex + 1);
            stone -= stoneCost * (mineIndex + 1);
            mineIndex++;

            mineButton.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = $"Mine: {mineIndex}";
            mineButton.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text =
                $"Wood: {woodCost * (mineIndex + 1)} Stone: {stoneCost * (mineIndex + 1)}";
            StartCoroutine(MinesCraft(4));
            UpdateCostChecker();
            UpdateUI();
        }
    }

    public void BuildFarm()
    {
        if (farmButton.interactable == true)
        {
            //kostat ce wood, food, water
            wood -= woodCost * (farmIndex + 1);
            food -= foodCost * (farmIndex + 1);
            water -= waterCost * (farmIndex + 1);
            farmIndex++;

            farmButton.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text =
                $"Farm: {farmIndex}";
            farmButton.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text =
                $"Wood: {woodCost * (farmIndex + 1)} Food: {foodCost * (farmIndex + 1)}" +
                $" Water: {waterCost * (farmIndex + 1)}";

            StartCoroutine(FarmCraft(10));
            UpdateCostChecker();
            UpdateUI();
        }
    }

    IEnumerator FarmCraft(int value)
    {
        value *= farmIndex + 1;
        while (!isGameOver)
        {
            yield return new WaitForSeconds(lengthOfDay * 7);
            food += Harvest(value);
        }
    }

    int Harvest(int value)
    {
        int random = Random.Range(0, 101);
            Debug.Log( random);
        if (random <= 25)
        {
            Debug.Log("Drought");
            return value -= 8 * (farmIndex - 1);
        }

        else
        {
            return value;
        }
    }

    IEnumerator MinesCraft(int value)
    {
        value *= mineIndex + 1; 
        while (!isGameOver)
        {
            yield return new WaitForSeconds(lengthOfDay * 3);
            stone += value;
            metal += (int)(value * 1.2f);
        }
    }

    void TaxThePopulation()
    {
        gold += population / 10;
        UpdateUI();
    }

    void RandomEvent()
    {
            // raid, sused, good harvest
            int random = Random.Range(0, 101);
            Debug.Log($"Random event {random}");

            //kuga
            if (random <= 2)
            {
                int killPeople = Mathf.CeilToInt(population * 0.75f);
                KillPopulation(killPeople);
                Notification($"Plague! you lost {killPeople} people!");
            }

            //babyBoom
            if (random > 2 && random <= 9)
            {
                int temp = Mathf.CeilToInt(population * 0.75f);
                for (int i = 0; i < temp; i++)
                {
                    IncreasePopulation();
                }
                Notification($"Celebrate, because we got {temp} new babies!!");
            }

            // hidden treasure
            if (random > 9 && random <= 11)
            {
                gold += Random.Range(100, 200);
                Notification($"Our workers found some gold.");
            }

            //Kevin
            if (random > 11 && random <= 15)
            {
                mineWorkers -= (int)(Random.Range(0.1f, 0.5f) * mineWorkers);
                mineIndex -= Random.Range(1, 3);
                if (mineIndex < 0)
                {
                    mineIndex = 0;
                }

                mineButton.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = $"Mine: {mineIndex}";
                mineButton.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text =
                    $"Wood: {woodCost * (mineIndex + 1)} Stone: {stoneCost * (mineIndex + 1)}";
                Notification($"Kevin destroyed some of your mines. He should have stayed at home alone.");
                StartCoroutine(MinesCraft(4));
            }

            //požar
            if (random > 15 && random <= 18)
            {
                int randomKillPop = (int)Random.Range(0, population * 0.03f);
                KillPopulation(randomKillPop);
                wood -= (int)Random.Range(0, wood * 0.05f);

                Notification($"FIRE!!! We lost {randomKillPop} people and some wood");
            }

        // raid

        if (random > 18 && random <= 20)
        {

            int coinFLip = Random.Range(0, 2);

            //obranili smo se
            if (coinFLip == 0 && soldiers > 0)
            {
                soldiers -= (int)(soldiers * 0.2f);
                Notification($"We have been raided but our great soldiers have defended us." +
                    $" We have lost some of our soldiers");
            }
          // nismo se obranili
            else if (coinFLip == 1)
            {
                gold = 0;
                food = 0;

                if(soldiers > 0)
                {
                    soldiers -= (int)(soldiers * 0.5f);
                }
                Notification($"We have been raided and we lost all of our gold and food. Oh and," +
                    $" by the way we lost half of our soldiers");
            }
        }

    }

    void Notification(string notification)
    {
        UpdateUI();
        //notification
        notificationPanel.SetActive(true);
        //zaustaviti vrijeme
        Time.timeScale = 0f;
        //ispisati notifikaciju
        notificationPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = notification;
    }

    public void ContinueGame()
    {
        notificationPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BuyMercenary()
    {
        if (mercenaryButton.interactable == true)
        {
            soldiers++;
            gold -= 1000;
            populationText.transform.GetChild(0).transform.GetChild(2).GetComponent<TMP_Text>().text =
             $"Soldiers: {soldiers}";
        }
        UpdateCostChecker();
        UpdateUI();
    }


}
