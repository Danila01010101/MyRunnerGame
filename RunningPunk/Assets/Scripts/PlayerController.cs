using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Animator _playerAnimator;
    private AudioSource _audioSourse;
    [SerializeField]
    private AudioClip _jumpSound;
    [SerializeField]
    private AudioClip _crashSound;
    [SerializeField]
    private ParticleSystem _explosionParticles;
    [SerializeField]
    private ParticleSystem _dirtParticles;
    [SerializeField]
    private float _jumpForce = 15;
    [SerializeField]
    private float _gravityModifier = 3;
    private bool _isOnGround = true;
    private bool _isGameOver = false;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerAnimator = GetComponent<Animator>();
        _audioSourse = GetComponent<AudioSource>();
        Physics.gravity *= _gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isOnGround && !_isGameOver)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isOnGround = false;
            _dirtParticles.Pause();
            _audioSourse.PlayOneShot(_jumpSound, 1.0f);
            _playerAnimator.SetTrigger("Jump_trig");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
            _dirtParticles.Play();
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over !");
            _isGameOver = true;
            _explosionParticles.Play();
            _dirtParticles.Pause();
            _audioSourse.PlayOneShot(_crashSound,1.0f);
            _playerAnimator.SetBool("Death_b", _isGameOver);
            _playerAnimator.SetInteger("DeathType_int", 1);
            Invoke("ReloadScene", 2f);
        }
    }

    public bool GetIsGameOver()
    {
        return _isGameOver;
    }
    private void ReloadScene()
    {
        Physics.gravity /= _gravityModifier;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
