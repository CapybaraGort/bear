using System;
using UnityEngine;
using YG;

public class Player : MonoBehaviour, IPauseable
{
    [SerializeField] private GameObject starParticles;
    [SerializeField] private Particle particles;
    [Zenject.Inject] private PauseManager pauseManager;
    private Animator animator;
    private Movement currentMovement;
    private Vector2 direction;
    private MovementLimiter limiter;
    private const string WALL_TAG = "Obstacle";
    public event Action OnPlayerDeath;
    public bool IsPaused { get; set; }

    [Zenject.Inject]
    private void Construct(MovementLimiter limiter)
    {
        this.limiter = limiter;
    }

    public void Initialize()
    {
        pauseManager.Register(this);
        animator = GetComponent<Animator>();
        currentMovement = new StandartMovement(transform, limiter);
    }

    private void Update()
    {
        if (IsPaused)
            return;

        Movement();
    }

    private void Movement()
    {
        currentMovement.MovementImplementation();
    }

    public void ChangeMovement(Movement movement)
    {
        currentMovement = movement;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == WALL_TAG)
        {
            animator.SetTrigger("Die");
            particles.OnCollision.Play();
            OnPlayerDeath?.Invoke();
        }
        if (collision.TryGetComponent(out Reward reward))
        {
            ParticleSpawner.SpawnParticles(starParticles, reward.transform.position, 1.6f);
            RuntimeData.AddScore();
            reward.gameObject.SetActive(false);
        }
    }

    [Serializable]
    private struct Particle
    {
        public ParticleSystem OnCollision;
    }
}
