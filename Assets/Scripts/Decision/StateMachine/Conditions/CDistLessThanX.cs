using UnityEngine;
using IA26Online.Decision.StateMachine;
public class CDistLessThanX : Condition
{
    private BossController boss;

    public CDistLessThanX(BossController boss)
    {
        this.boss = boss;
    }

    public override bool Test()
    {
        float distance = Vector2.Distance(boss.transform.position, boss.playerTransform.position);
        if (distance < boss.melee_dist == true)
            return true;
        return false;
    }
}
