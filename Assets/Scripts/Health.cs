using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Health : MonoBehaviour
{
	[SerializeField]
	private int startingHealth = 5;

    [SerializeField]
    private int currentHealth;
    [SerializeField]
    private GameObject player;

	private void OnEnable()
	{
		currentHealth = startingHealth;
	}

	public void TakeDamage(int damageAmount)
	{
		currentHealth -= damageAmount;
		if (currentHealth <= 0)
			Die();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

	private void Die()
	{
        var temp1 = gameObject.GetComponent<Enemy>();
        var temp2 = gameObject.GetComponentInParent<Enemy>();
        if (temp1||temp2)
        {
            Debug.Log("1");
            gameObject.GetComponent<NavMeshAgent>().Stop();
            StartCoroutine(EnemyDyingAnimation(gameObject.GetComponentInChildren<Animator>()));
            player.GetComponent<PlayerMovement>().killCount+=1;
        }
        else
        {
            Debug.Log("2");
            StartCoroutine(PlayerDyingAnimation(player.GetComponentInChildren<Animator>()));
        }
	}
    private IEnumerator EnemyDyingAnimation(Animator anim){
        anim.Play("dying");
        yield return new WaitForSecondsRealtime(anim.GetCurrentAnimatorStateInfo(0).length+anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        //anim.Play("Motion");
        anim.Play("dying");
        gameObject.SetActive(false);
    }
    private IEnumerator PlayerDyingAnimation(Animator anim){
        anim.Play("dying");
        yield return new WaitForSecondsRealtime(anim.GetCurrentAnimatorStateInfo(0).length+anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        anim.Play("dying");
        player.SetActive(false);
    }
}