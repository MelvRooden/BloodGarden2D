using UnityEngine;

public class PlayerAttack : BaseAttack
{
    [SerializeField]
    private string attackTriggerName;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown(attackTriggerName))
            Attack();
    }
}
