using UnityEngine;

public class PlayerAttack : BaseAttack
{
    public string attackTriggerName;

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetButtonDown(attackTriggerName))
            Attack();
    }
}
