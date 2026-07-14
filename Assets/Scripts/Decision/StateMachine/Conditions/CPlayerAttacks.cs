using UnityEngine;
using IA26Online.Decision.StateMachine;
public class CPlayerAttacks : Condition
{
    private BossController boss;
    public CPlayerAttacks(BossController boss)
    {
        this.boss = boss;
    }

    public override bool Test()
    {
        if (boss.player_attacks == true)
            return true;
        return false;
    }
}
