using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus {

  private int strength;
  private int critical;
  private int trueDamage;
  private float health;

  public int Strength {
    get { 
      return strength;
    }
    set { 
      strength = value;
    }
  }
  public int Critical {
      get { 
        return critical;
      }
      set { 
        critical = value;
      }
  }
  public int TrueDamage {
      get { 
        return trueDamage;
      }
      set { 
        trueDamage = value;
      }
  }
  public float Health {
      get { 
        return health;
      }
      set { 
        health = value;
      }
  }
}
