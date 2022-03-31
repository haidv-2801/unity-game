using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillHealthBar : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Image fillImage;
    private Slider slider;
    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
        fillImage.color = new Color(0, 255, 0);
    }

    // Update is called once per frame
    void Update()
    {

      /*  if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }

        if (slider.value > slider.minValue && !slider.enabled)
        {
            fillImage.enabled = true;
        }*/

        float fillvalue = playerHealth.CurrentHealth / playerHealth.MaxHealth;
        if(fillvalue <= slider.maxValue / 3)
        {
            fillImage.color = Color.white;
        }
        else if (fillvalue > slider.maxValue / 2)
        {
            fillImage.color = Color.red;
        }
        slider.value = fillvalue;
       /* 
        if (fillImage.color.r < 255)
        {
            float k = 51 * (10 - fillvalue) > 255 ? 255 : 51 * (10 - fillvalue);
            fillImage.color = new Color(k, g, 0);
        } else if(fillImage.color.r > 0)
        {
            float k = 51 * fillvalue > 255 ? 255 : 51 * (10 - fillvalue);
            fillImage.color = new Color(k, g, 0);
        }

        UnityEngine.Debug.Log(fillImage.color.r);*/
    }
}
