using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float hp = 100;
    public Image healthBar;
    private float startHealth;
    private bool dead = false;
    public void Start()
    {
        startHealth = hp;
    }

    public void takeDamage(float amount)
    {
        hp -= amount;
        healthBar.fillAmount = hp / startHealth;
    }

    public void Update()
    {
        if (hp <= 0)
        { 
            if(this.gameObject.tag == "Zombie" && !dead)
            {
                GlobalVariables.highscore += 1;
		dead = true;
            }
            Destroy(gameObject, 0.1f);
        }
    }
}
