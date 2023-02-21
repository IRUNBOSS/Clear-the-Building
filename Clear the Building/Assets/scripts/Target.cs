using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int maxHealt = 2;
    private int _curretHealth;
    public int GetHealth
    {
        get 
        {
            return _curretHealth;
        }
        set 
        { 
            _curretHealth= value;
            if(_curretHealth > maxHealt)
            {
                _curretHealth = maxHealt;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _curretHealth = maxHealt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Bullet bullet = other.gameObject.GetComponent<Bullet>();

        if(bullet && bullet.owner != gameObject)
        {
            if (bullet)
            {
                _curretHealth--;

                if (_curretHealth <= 0)
                {
                    Die();
                }

                Destroy(other.gameObject);
            }
        }


       
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
