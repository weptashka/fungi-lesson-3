using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class DamageFlashEffector : AbstractDamageEffector
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _flashTime;
        [SerializeField] private AnimationCurve _animationCurve;

        private Coroutine _flashCor;

        public override void MakeEffect()
        {
            gameObject.SetActive(true);

            if (_flashCor != null)
            {
                StopCoroutine(_flashCor);
                _flashCor = null;
            }

            _flashCor = StartCoroutine(FlashCore());
        }

        private IEnumerator FlashCore()
        {
            float time = 0f;
            float progress = 0f;

            var flashTime = _flashTime / 2;

            var startColor = Color.clear;

            while (time <= flashTime)
            { 
                time += Time.deltaTime;
                progress = time /flashTime;

                _spriteRenderer.color = Color.Lerp(startColor, Color.white, _animationCurve.Evaluate(progress));

                yield return null;
            }

            time = 0f;

            while (time <= flashTime)
            { 
                time += Time.deltaTime;
                progress = time / flashTime;

                _spriteRenderer.color = Color.Lerp(Color.white, startColor, _animationCurve.Evaluate(progress));

                yield return null;
            }

            gameObject.SetActive(false);
        }
    }
}