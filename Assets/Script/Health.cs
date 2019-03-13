using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float hp;
    private float startHealth = 100;
    public Image healthBar;

    public void takeDamage(float amount)
    {
        hp -= amount;
        healthBar.fillAmount = hp / startHealth;
    }

    public void Update()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
