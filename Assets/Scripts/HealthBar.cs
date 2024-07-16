using UnityEngine;
using System;


namespace Assets.Scripts
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private LifeHandler _lifeHandler;
        [SerializeField] private Transform _healthBar;

        private int _startHp;

        private void Start()
        {
            _startHp = _lifeHandler.Hp;

            _lifeHandler.Changed += LifeHandlerOnChanged;
        }

        private void OnDisable()
        {
            _lifeHandler.Changed -= LifeHandlerOnChanged;
        }

        private void LifeHandlerOnChanged()
        {
            Debug.Log("MINUS LIFE");

            var transfrmLocalScale = _healthBar.transform.localScale;
            transfrmLocalScale.x = (float)_lifeHandler.Hp / _startHp;
            _healthBar.transform.localScale = transfrmLocalScale; 
        }
    }
}
