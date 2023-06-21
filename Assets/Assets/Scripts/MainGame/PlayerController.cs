using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : NetworkBehaviour, IBeforeUpdate
{
    [SerializeField] private float movingSpeed;
    private float horizontal;
    private Rigidbody2D rb2d;

    public override void Spawned()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void BeforeUpdate()
    {
        if(Runner.LocalPlayer == Object.HasInputAuthority)
        {
            const string HORIZONTAL = "Horizontal";
            horizontal = Input.GetAxisRaw(HORIZONTAL);
        }
    }
    public override void FixedUpdateNetwork()
    {
        if (Runner.TryGetInputForPlayer<PlayerData>(Object.InputAuthority,out var input))
        {
            rb2d.velocity = new Vector2(input.horizontalInput * movingSpeed, rb2d.velocity.y);
        }
    }

    public PlayerData GetPlayerNetworkInput()
    {
        PlayerData data = new PlayerData();
        data.horizontalInput = horizontal;
        return data;
    }

}
