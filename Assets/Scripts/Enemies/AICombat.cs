using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICombat : MonoBehaviour
{
    public float health = 1f;

    private int drop;

    public GameObject dropCore;
    public GameObject dropPotion;

    void Update()
    {
        if (health <= 0f)
        {
            Death();
        }
    }

    private void ChooseDrop()
    {
        drop = Random.Range(0,9);
    }

    private void Death()
    {
        ChooseDrop();

        switch (drop)
        {
            case 0:
                Instantiate(dropCore, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                break;
            case 1:
                Instantiate(dropCore, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                break;
            case 2:
                Instantiate(dropCore, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                break;
            case 3:
                Instantiate(dropPotion, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                break;
            case 4:
                Instantiate(dropPotion, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                break;
            case 5:
                Instantiate(dropPotion, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                break;
            case 6:
                Instantiate(dropPotion, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                break;
            case 7:
                Destroy(this.gameObject);
                break;
            case 8:
                Destroy(this.gameObject);
                break;
            case 9:
                Destroy(this.gameObject);
                break;
        }
    }
}
