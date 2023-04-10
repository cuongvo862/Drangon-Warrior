using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound;
    private Transform currentCheckpoint; //we'll store our last checkpoint here
    private Health playerHealth;
    private UIManager uiManager;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void CheckRespawn()
    {
        //check if check point avaiable
        if (currentCheckpoint == null)
        {
            //show game over screen
            uiManager.GameOver();

            return; //don't execute the rest of this function 
        }
        playerHealth.Respawn(); //restore player health and reset animation
        transform.position = currentCheckpoint.position; //move player to checkpoint position
    }

    //activate checkpoint
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform; //store the checkpoint that we activated as the current one
            SoundManager.instance.PlaySound(checkpointSound);
            collision.GetComponent<Collider2D>().enabled = false; //deactivate checkpoint collider
            collision.GetComponent<Animator>().SetTrigger("appear"); //trigger checkpoint animation
        }
    }
}


