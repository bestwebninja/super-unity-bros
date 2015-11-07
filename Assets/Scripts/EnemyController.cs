﻿using UnityEngine;
using System.Collections;

public class EnemyController : EntityController
{
    public virtual void OnJumped(MarioController player)
    {
        Die();
        player.JumpOnEnemy(this);
    }

    public virtual void OnHitByPlayer(MarioController player)
    {
        player.Die();
    }

    protected override void OnStart()
    {
        base.OnStart();
        m_Velocity.x = direction * walkSpeed;
    }

    protected override void OnObstacle(Cell cell)
    {
        Flip();
        m_Velocity.x = -m_Velocity.x;
    }

    #region Collisions

    void OnTriggerEnter2D(Collider2D other)
    {
        if (dead) return;

        EnemyController enemy = other.GetComponent<EnemyController>();
        if (enemy != null)
        {
            Flip();
            m_Velocity.x = -m_Velocity.x;
        }
    }

    #endregion
}
