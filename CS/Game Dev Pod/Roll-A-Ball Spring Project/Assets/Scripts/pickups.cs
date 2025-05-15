 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickups : MonoBehaviour
{
    private bool isCollected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isCollected == true)
        {
            return; //Do nothing. Meaning do not play another sound effect, or update the score.
        }

        //checks to see if the object is the player
        if(other.gameObject.CompareTag("Player"))
        {
            isCollected = true;

            // Destroy the coin
            Destroy(this.gameObject);

            // Update our points
            GameManager.Instance.UpdateScore(1);

            // Play sound effect
            AudioManager.Instance.PlaySound("Collect Coin");
        }
    }
}
