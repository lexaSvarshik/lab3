using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragonPicker : MonoBehaviour
{
    public GameObject energyShieldPrefab;
    public int numEnergyShield = 3;
    public float energyShieldBottomY = -6f;
    public float energyShieldRadius = 1.5f;
    private GoogleSheet gSheet;
    
    public List<GameObject> shieldList;
    void Start()
    {
        gSheet = GameObject.FindGameObjectWithTag("GSheet").GetComponent<GoogleSheet>();
        StartCoroutine(StartRoutine());
    }

    private IEnumerator StartRoutine()
    {
        yield return StartCoroutine(gSheet.LoadData());
        numEnergyShield = gSheet.NumEnergyShieldsDataHandler[LevelController.GetLevelNumber()];

        shieldList = new List<GameObject>();

        for (int i = 1; i <= numEnergyShield; i++){
            GameObject tShieldGo = Instantiate<GameObject>(energyShieldPrefab);
            tShieldGo.transform.position = new Vector3(0, energyShieldBottomY, 0);
            tShieldGo.transform.localScale = new Vector3(1*i,1*i,1*i);
            shieldList.Add(tShieldGo);
        }
    }

    public void DragonEggDestroyed(){
        GameObject[] tDragonEggArray = GameObject.FindGameObjectsWithTag("Dragon Egg");
        foreach (GameObject tGO in tDragonEggArray){
            Destroy(tGO);
        }
        int shieldIndex = shieldList.Count - 1;
        GameObject tShieldGo = shieldList[shieldIndex];
        shieldList.RemoveAt(shieldIndex);
        Destroy(tShieldGo);

        if (shieldList.Count == 0){
            SceneManager.LoadScene(0);
        }
    }
}
