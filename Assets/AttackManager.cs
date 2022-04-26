using System;
using UnityEngine;

// public class AttackManager : MonoBehaviour
// {
//     public BaseAttack[] attacks;
// 
//     public void Update()
//     {
//         if (attacks != null)
//             foreach (var attack in attacks)
//             {
//                 string attackTriggerName = attack.GetAttackTriggerName();
//                 if (attackTriggerName != null)
//                     if (Input.GetButtonDown(attackTriggerName))
//                         Attack(attackTriggerName);
//             }
//     }
// 
//     public void Attack(string name)
//     {
//         IAttack attack = Array.Find(attacks, attack => attack.GetAttackTriggerName() == name);
//         if (attack == null)
//         {
//             Debug.LogWarning("Attack: " + name + " not found!");
//             return;
//         }
//         attack.Attack();
//     }
// }
