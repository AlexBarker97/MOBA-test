using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    [Header("Ability 1")]
    public Image abilityImage1;
    public float cooldown1 = 5;
    bool isCooldown1 = false;
    public KeyCode ability1;

    [Header("Ability 2")]
    public Image abilityImage2;
    public float cooldown2 = 10;
    bool isCooldown2 = false;
    public KeyCode ability2;

    [Header("Ability 3")]
    public Image abilityImage3;
    public float cooldown3 = 15;
    bool isCooldown3 = false;
    public KeyCode ability3;
    float timeRemaining = -1;

    // Start is called before the first frame update
    void Start()
    {
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        abilityImage3.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Ability1();
        Ability2();
        Ability3();
    }

    void Ability1()
    {
        if (Input.GetKey(ability1) && isCooldown1 == false)
        {
            isCooldown1 = true;
            abilityImage1.fillAmount = 1;
        }
        if (isCooldown1)
        {
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if (abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isCooldown1 = false;
            }
        }
    }
    void Ability2()
    {
        if (Input.GetKey(ability2) && isCooldown2 == false)
        {
            isCooldown2 = true;
            abilityImage2.fillAmount = 1;
        }
        if (isCooldown2)
        {
            abilityImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;

            if (abilityImage2.fillAmount <= 0)
            {
                abilityImage2.fillAmount = 0;
                isCooldown2 = false;
            }
        }
    }
    void Ability3()
    {
        if (Input.GetKey(ability3) && isCooldown3 == false) 
        {
            isCooldown3 = true;
            abilityImage3.fillAmount = 1;

            timeRemaining = 10;
            GameObject lightGameObject = new GameObject("Player Light Ability");
            Light lightComp = lightGameObject.AddComponent<Light>();
            lightComp.intensity = 5;
            
            lightGameObject.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(0, 4, 0);
            lightGameObject.transform.SetParent((GameObject.FindGameObjectWithTag("Player")).transform);
        }

        if (timeRemaining > 0)
        {
            if(timeRemaining < 1)
            {
                timeRemaining = 0;
            }
            else
            {
                timeRemaining -= Time.deltaTime;
            }

        }
        else if (timeRemaining == 0)
        {
            Destroy(GameObject.Find("Player Light Ability"));
            timeRemaining = -1;
        }

        if (isCooldown3)
        {
            abilityImage3.fillAmount -= 1 / cooldown3 * Time.deltaTime;

            if (abilityImage3.fillAmount <= 0)
            {
                abilityImage3.fillAmount = 0;
                isCooldown3 = false;
            }
        }
    }
}
