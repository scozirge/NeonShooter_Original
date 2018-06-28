﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AmmoPrefab : MonoBehaviour
{
    public bool IsLaunching { get; protected set; }
    protected Vector3 Force;
    protected Rigidbody2D MyRigi;
    public virtual int BaseDamage { get; protected set; }
    public virtual int Damage { get { return BaseDamage; } }
    public virtual void Init(Dictionary<string,object> _dic)
    {
        IsLaunching = false;
        MyRigi = transform.GetComponent<Rigidbody2D>();
        BaseDamage = (int)_dic["Damage"];
        BattleManager.AddToStartPauseFnc(PauseGame);
        BattleManager.AddToEndPauseFnc(ResumeGame);
    }
    protected virtual void Update()
    {
    }
    public virtual void Launch()
    {
        MyRigi.AddForce(Force);
        IsLaunching = true;
    }
    protected virtual void OnTriggerEnter2D(Collider2D _col)
    {
    }
    public virtual void SelfDestroy()
    {
        BattleManager.RemoveFromStartPauseFnc(PauseGame);
        BattleManager.RemoveFromEndPauseFnc(ResumeGame);
        Destroy(gameObject);
    }
    protected virtual void SpawnParticleOnSelf(string _effectName)
    {
        GameObject particlePrefab = Resources.Load(string.Format("Particles/{0}/{0}", _effectName)) as GameObject;
        GameObject particleGo = Instantiate(particlePrefab.gameObject, Vector3.zero, Quaternion.identity) as GameObject;
        particleGo.transform.SetParent(transform);
        particleGo.transform.localPosition = Vector3.zero;
    }
    protected virtual void SpawnParticleOnPos(string _effectName)
    {
        GameObject particlePrefab = Resources.Load(string.Format("Particles/{0}/{0}", _effectName)) as GameObject;
        GameObject particleGo = Instantiate(particlePrefab.gameObject, Vector3.zero, Quaternion.identity) as GameObject;
        particleGo.transform.position = transform.position;
    }

    protected Vector2 SavedVelocity;
    protected float SavedAngularVelocity;

    protected virtual void PauseGame()
    {
        SavedVelocity = MyRigi.velocity;
        SavedAngularVelocity = MyRigi.angularVelocity;
        MyRigi.velocity = Vector2.zero;
        MyRigi.angularVelocity = 0;
    }

    protected virtual void ResumeGame()
    {
        MyRigi.velocity = SavedVelocity;
        MyRigi.angularVelocity = SavedAngularVelocity;
    }
}
