using UnityEngine;
using IA26Online.Decision.StateMachine;
public class CDistMoreThanY : Condition
{
    private BossController boss;
    public CDistMoreThanY(BossController boss)
    {
        this.boss = boss;
    }

    public override bool Test()
    {
        float distance = Vector2.Distance(boss.transform.position, boss.playerTransform.position);
        if (distance > boss.range_dist == true)
            return true;
        return false;
    }
}
