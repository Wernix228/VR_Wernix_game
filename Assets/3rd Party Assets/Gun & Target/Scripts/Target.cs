using UnityEngine;

namespace _3rd_Party_Assets.Gun___Target.Scripts
{
    public class Target : MonoBehaviour
    {
        private MeshRenderer _meshRenderer;
        private BoxCollider _boxCollider;
        private AudioSource _audioSource;
        private ParticleSystem _particleSystem;

        private Vector3 _randomRotation;
        private bool _isDisabled;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _boxCollider = GetComponent<BoxCollider>();
            _audioSource = GetComponent<AudioSource>();
            _particleSystem = GetComponent<ParticleSystem>();

            _randomRotation = new Vector3(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
        }

        private void Update() => Rotate();

        private void Rotate() => transform.Rotate(_randomRotation);

        private void OnCollisionEnter(Collision collision)
        {
            if (!_isDisabled && collision.gameObject.CompareTag("Bullet"))
            {
                Destroy(collision.gameObject);
                ToggleTarget();
                TargetSDestroyEffect();
                Invoke("ToggleTarget", 3f);
            }
        }
        private void ToggleTarget()
        {
            _meshRenderer.enabled = _isDisabled;
            _boxCollider.enabled = _isDisabled;

            _isDisabled = !_isDisabled;
        }

        private void TargetSDestroyEffect()
        {
            var random = Random.Range(0.8f,1.2f);
            _audioSource.pitch = random;

            _audioSource.Play();
            _particleSystem.Play();
        }
    }
}