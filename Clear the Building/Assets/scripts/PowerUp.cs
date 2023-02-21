using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Header("Health Settings")]
    public bool healtPowerUp = false;
    public int healtAmount = 1;
    
    [Header("Ammo Settings")]
    public bool ammoPowerUp = false;
    public int ammoAmount = 5;

    [Header("Transform Settings")]
    [SerializeField]Vector3 turnVector = Vector3.zero;

    [Header("Scale Settings")]
    [SerializeField] private float period = 2f;
    [SerializeField] Vector3 scaleVector;
    private float scaleFactor;
    private Vector3 startScale;

    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale;
        if(healtPowerUp == true && ammoPowerUp == true)
        {
            healtPowerUp= false;
            ammoPowerUp= false; 
        }
        else if (healtPowerUp == true)
        {
            ammoPowerUp = false;
        }
        else if(ammoPowerUp == true) 
        { 
            healtPowerUp= false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(turnVector);
        SinWawe();
    }

    private void SinWawe()
    {
        if(period <= 0) 
        {
            period = 0.1f;
        }
        float cycles = Time.timeSinceLevelLoad / period;

        const float piX2 = MathF.PI * 2;

        float sinusWawe = Mathf.Sin(cycles * piX2);

        scaleFactor = sinusWawe / 2 + 0.5f;

        Vector3 offset = scaleFactor * scaleVector;

        transform.localScale = startScale + offset;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") 
        {
            if (healtPowerUp)
            {
                other.gameObject.GetComponent<Target>().GetHealth += healtAmount;
            }
            else if (ammoPowerUp)
            {
                other.gameObject.GetComponent<Attack>().GetAmmo += ammoAmount;
            }
        }
        
        Destroy(gameObject); 
    }
}
