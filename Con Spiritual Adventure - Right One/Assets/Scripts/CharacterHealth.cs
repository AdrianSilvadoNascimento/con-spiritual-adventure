using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour {
    [SerializeField] private int health = 0;
    [SerializeField] private int curHealth, maxHealth;
    [SerializeField] private Slider healthSlider;

    private void Awake() {
        health = 100;
        maxHealth = health;
        curHealth = health;
        healthSlider = GetComponent<Slider>();
        healthSlider.maxValue = health;
        healthSlider.minValue = 0;
        healthSlider.value = curHealth;
    }

    public void Tester() {
        if (Input.GetKeyDown(KeyCode.R)) {
            health -= 30;
        }
    }
}
