using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float velocidade = 0; // Velocidade de movimento do inimigo

    public bool chegouAoDestino = true; // Indica se o inimigo chegou ao destino de rondagem
    bool rondarArea = true; // Indica se o inimigo está rondando a área
    public bool seguirJogador = false; // Indica se o inimigo está seguindo o jogador

    Vector3 destino; // O destino atual para o qual o inimigo está se movendo

    bool movendoParaDireita = false; // Indica se o inimigo está se movendo para a direita
    bool movendoParaEsquerda = false; // Indica se o inimigo está se movendo para a esquerda
    bool movendoParaFrente = false; // Indica se o inimigo está se movendo para frente
    bool movendoParaTras = false;
    public bool die = false;
    Rigidbody rb;
    Transform mainCameraTransform; // Referência para a transformada da MainCamera

    public GameObject Front;
    public GameObject Left;
    public GameObject Right;
    public GameObject Death;

    private void Start()
    {
        destino = Vector3.zero; // Inicializa o destino como zero
        rb = GetComponent<Rigidbody>(); // Obtém o Rigidbody do inimigo
        mainCameraTransform = Camera.main.transform; // Obtém a transformada da MainCamera
    }

    private void FixedUpdate()
    {
        // Se o inimigo está seguindo o jogador
        if (seguirJogador && die == false && chegouAoDestino == true)
        {
            Vector3 positionPlayer = GameObject.FindWithTag("Player").transform.position; // Obtém a posição do jogador
            transform.position = Vector3.MoveTowards(transform.position, positionPlayer, velocidade * Time.deltaTime); // Move-se em direção ao jogador

            // Olha na direção do jogador
            transform.LookAt(positionPlayer);

            // Define as variáveis de movimento
            movendoParaDireita = (positionPlayer.x > transform.position.x);
            movendoParaEsquerda = (positionPlayer.x < transform.position.x);
            movendoParaFrente = (positionPlayer.z > transform.position.z);
            movendoParaTras = (positionPlayer.z < transform.position.z);
            // Invoca o método para desativar a variável de chegada ao destino após 2 segundos
        }
        // Se o inimigo está rondando a área
        if (rondarArea && die == false)
        {
            // Se o inimigo chegou ao destino
            if (chegouAoDestino)
            {
                // Define um novo destino aleatório dentro de uma área ao redor do inimigo
                float posicaoX = Random.Range(transform.position.x - 50, transform.position.x + 50);
                float posicaoZ = Random.Range(transform.position.z - 50, transform.position.z + 50);
                destino = new Vector3(posicaoX, transform.position.y, posicaoZ);
                Invoke("DesabilitaChegouAoDestino", 3f); // Invoca o método para desativar a variável de chegada ao destino após 2 segundos
            }

            // Se o inimigo não chegou ao destino
            if (!chegouAoDestino)
            {
                // Move-se em direção ao destino
                transform.position = Vector3.MoveTowards(transform.position, destino, velocidade * Time.deltaTime);

                // Define as variáveis de movimento
                movendoParaDireita = (destino.x < transform.position.x);
                movendoParaEsquerda = (destino.x > transform.position.x);
                movendoParaFrente = (destino.z > transform.position.z);
            }

            // Se a distância entre o inimigo e o destino for menor que 0.1f, o inimigo chegou ao destino
            if (Vector3.Distance(transform.position, destino) < 0.1f)
            {
                chegouAoDestino = true;
            }
        }
    }
    void Update()
    {
      transform.LookAt(mainCameraTransform.position);

        if (die == true) 
        {
            Death.SetActive(true);
            Front.SetActive(false);
            Right.SetActive(false);
            Left.SetActive(false);
        }

        if (die == false)
        { // Ativar e desativar objetos com base na direção do movimento
            if (movendoParaDireita)
            {
                Front.SetActive(false);
                Left.SetActive(false);
                Right.SetActive(true);
            }
            else if (movendoParaEsquerda)
            {
                Front.SetActive(false);
                Left.SetActive(true);
                Right.SetActive(false);
            }
            else
            {
                Front.SetActive(true);
                Left.SetActive(false);
                Right.SetActive(false);
            }
        }
    }

    // Método para desativar a variável de chegada ao destino após 2 segundos
    public void DesabilitaChegouAoDestino()
    {
        chegouAoDestino = false; // Desativa a variável de chegada ao destino
        transform.LookAt(mainCameraTransform.position); // Olha na direção do destino
    }

    // Quando algo entra no trigger do inimigo
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && die == false)
        {
            rondarArea = false; // Define que o inimigo não está mais rondando a área
            seguirJogador = true; // Define que o inimigo está seguindo o jogador
        }
    }

    // Quando algo sai do trigger do inimigo
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && die == false)
        {
            rondarArea = true; // Define que o inimigo está rondando a área novamente
            seguirJogador = false; // Define que o inimigo não está mais seguindo o jogador
        }
    }
}