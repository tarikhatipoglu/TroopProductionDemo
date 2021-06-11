using UnityEngine;
using UnityEngine.UI;

public class Trooper : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 100f;
    public bool damage;

    public Slider healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        UnitSelection.Instance.unitList.Add(this.gameObject);
    }
    public void OnDestroy()
    {
        UnitSelection.Instance.unitList.Remove(this.gameObject);
    }
    void Update()
    {
        healthBar.value = currentHealth;


        if(damage)
        {
            currentHealth -= 20f * Time.deltaTime;
        }
        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Lava")
        {
            damage = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Lava")
        {
            damage = false;
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        //You can add other things too
        if (collision.gameObject.tag == "Bullet")
        {
            currentHealth -= 5f;
        }
    }
}