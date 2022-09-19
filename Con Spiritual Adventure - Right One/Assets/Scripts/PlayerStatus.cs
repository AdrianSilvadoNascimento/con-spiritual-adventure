using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

  CharacterStatus character = new CharacterStatus();
  private int playerStrength, playerCritical, playerTrueDamage;
  private float playerHealth;

  void Start() {
      character.Strength = 50;
      character.Critical = 80;
      character.TrueDamage = (character.Strength + character.Critical);
      character.Health = 70f;
      playerStrength = character.Strength;
      playerCritical = character.Critical;
      playerTrueDamage = character.TrueDamage;
      playerHealth = character.Health;

      // Debug.Log("Strength: " + playerStrength);
      // Debug.Log("Critical: " + playerCritical);
      // Debug.Log("TrueDamage: " + playerTrueDamage);
      // Debug.Log("Health: " + playerHealth);
  }

  void Update() {
    if (Input.GetKeyDown(KeyCode.Space)) {
      StartCoroutine(Recover());
    }

    if (Input.GetKeyDown(KeyCode.E)) {
      TakeDamage(15);
    }
  }

  void TakeDamage(int Damage) {
    playerHealth -= (float)Damage;
    if (playerHealth <= 0) {
      playerHealth = 0;
    }
    print("Health: " + playerHealth);
  }

  private void OnTriggerEnter(Collider other) {
    if (other.tag == "enemy") {
      TakeDamage(30);
    }
  }

  IEnumerator Recover() {
    if (playerHealth > 0) {
      if (playerHealth < 100) {
        playerHealth += playerHealth * 0.3f;
        if (playerHealth > 100) {
          playerHealth = 100;
        }
        yield return new WaitForSeconds(1.5f);
        print("Health: " + playerHealth);
      }
    }
  }
}
