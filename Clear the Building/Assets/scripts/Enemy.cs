using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] movePoints;
    [SerializeField] private float speed = 5f;

    private bool _canMoveRight = false;   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckCanMoveRight();
        MoveTowards();
    }
     private void MoveTowards()
    {
        if (!_canMoveRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoints[0].position, speed * Time.deltaTime);
            LookAtTheTarget(movePoints[0].transform.position);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoints[1].position, speed * Time.deltaTime);
            LookAtTheTarget(movePoints[1].transform.position);
        }
    }

    private void CheckCanMoveRight()
    {
        if (Vector3.Distance(transform.position, movePoints[0].position) <= 0.1f ) 
        {
            _canMoveRight= true;

        }
        else if(Vector3.Distance(transform.position, movePoints[1].position) <=  0.1f )
        { 
            _canMoveRight= false;
        }
    }

    private void LookAtTheTarget(Vector3 newTarget)
    {
        Quaternion targetRotation = Quaternion.LookRotation(newTarget - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speed * Time.deltaTime);
    }
}
