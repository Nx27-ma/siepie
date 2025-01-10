using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
  public int maxHealth;
  public int health;
  public Transform respawnPoint;
  public float respawnTime;

  private PlayerMovement move;

  // Start is called before the first frame update
  void Start()
  {
    health = maxHealth;
    move = GetComponent<PlayerMovement>();
  }

  // Update is called once per frame
  void Update()
  {
    if (health <= 0)
    {
      StartCoroutine(Death());
    }
  }
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Enemy"))
    {
      health--;

    }
  }

  private IEnumerator Death()
  {
    print("Player died");
    move.enabled = false;
    yield return new WaitForSeconds(respawnTime);
    move.enabled = true;
    transform.position = respawnPoint.position;
    health = maxHealth;


  }
}
