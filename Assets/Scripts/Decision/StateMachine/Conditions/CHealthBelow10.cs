using UnityEngine;
using IA26Online.Decision.StateMachine;
public class CHealthBelow10 : Condition
{
    private BossController boss;
    public CHealthBelow10(BossController boss)
    {
        this.boss = boss;
    }

    public override bool Test()
    {
        if (boss.current_health / boss.max_health * 100f < 10f == true)
            return true;
        return false;
    }
}
