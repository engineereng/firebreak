using UnityEngine;
using UnityEngine.UI;
//Mana Bar Script placeholder

public class ManaBar : MonoBehaviour
{
public Slider manaBar;

private int maxMana = 100;
private int currentMana;

public static ManaBar instance;

private void Awake()
{
    instance = this;
}

void Start()
{
    currentMana = maxMana;
    manaBar.maxValue = maxMana;
    manaBar.value = maxMana;
}

public void UseMana(int amount)
{
    if (currentMana - amount >= 0) //Enough mana to perform an action
    {
        currentMana -= amount;
        manaBar.value = currentMana;
    }
    else
    {
        Debug.Log("Depleted Mana"); //No more mana
    }
}
}
