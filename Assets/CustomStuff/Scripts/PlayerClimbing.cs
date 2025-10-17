using System.Collections;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class PlayerClimbing : MonoBehaviour
{
    public BoxCollider2D wallCheck; 
    public Rigidbody2D body;
    public LayerMask wallMask;
    public bool climbable;
    public float climbSpeed;

    public Image staminaBar;
    public float stamina, maxStamina;
    public float climbCost;
    public float chargeRate;
    private Coroutine recharge;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        float yInput = Input.GetAxis("Vertical");
        if (stamina > 0)    //Makes sure that the player has enough stamina to keep climbing
        {
            if (Mathf.Abs(yInput) > 0)  //Updates the position of the player based on their inputs
            {
                body.linearVelocity = new Vector2(body.linearVelocityX, yInput * climbSpeed);
                stamina -= climbCost * Time.deltaTime;
                if (stamina < 0)
                {
                    stamina = 0;
                }
                staminaBar.fillAmount = stamina / maxStamina;
                if (recharge != null)   //Makes sure the stamina isn't already recharging
                {
                    StopCoroutine(recharge);
                }
                recharge = StartCoroutine(RechargeStamina());
            }
        }
    }
    private IEnumerator RechargeStamina()   //Corountine to recover stamina after the player has stopped moving
    {
        yield return new WaitForSeconds(1f);    //Waits for the player to stop moving
        while(stamina < maxStamina)
        {
            stamina += chargeRate / 10f;        //Recharges the stamina numerically
            if (stamina > maxStamina)
            {
                stamina = maxStamina;
             }
            staminaBar.fillAmount = stamina / maxStamina;   //Updates the UI element
            yield return new WaitForSeconds(.1f);
            
        }
    }
}
//Movement altered from the PlayerMovement Script, Stamina code altered from youtube video "Stamina Bar in Unity Tutorial" by "Gatsby"