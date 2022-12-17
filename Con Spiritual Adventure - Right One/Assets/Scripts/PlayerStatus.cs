using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {
  CharacterStatus character = new CharacterStatus();

  [SerializeField]
  private int playerStrength, playerCritical, playerTrueDamage;

  void Start() {
      character.Strength = 50;
      character.Critical = 80;
      character.TrueDamage = (character.Strength + character.Critical);
      playerStrength = character.Strength;
      playerCritical = character.Critical;
      playerTrueDamage = character.TrueDamage;

      // Debug.Log("Strength: " + playerStrength);
      // Debug.Log("Critical: " + playerCritical);
      // Debug.Log("TrueDamage: " + playerTrueDamage);
      // Debug.Log("Health: " + playerHealth);
  }

  void Update() {
  }

   /**
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
   */
}
