using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float hp = 100;
    private float startHealth;
    public Image healthBar;
    public static int zombieDeath = 0;
    public void Start()
    {
        startHealth = hp;
    }

    public void takeDamage(float amount)
    {
        if(this.gameObject.tag=="Wall")
        {
            
            if (zombieDeath >= 10) {
                zombieDeath = 0;
                this.gameObject.tag = "Wall2";
            }
        }
        else
        {
            hp -= amount;
            healthBar.fillAmount = hp / startHealth;
        }
    }

    public void Update()
    {
        if (hp <= 0)
        { 
            Destroy(gameObject, 0.001f);
            
            if(this.gameObject.tag == "Zombie")
            {
                zombieDeath++;
            }
        }
    }
}
