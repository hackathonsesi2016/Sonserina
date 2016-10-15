using UnityEngine;
using System.Collections;

public class Joystick : MonoBehaviour {

    public GameObject mesa;
   
    int mudaSentidoAnimacao = 0;
    //int[] seq = {3, 0, 4, 2, 1 };
    [SerializeField]
    private int estado = 0;
    [SerializeField]
    private int estadosCount = 4;
    [SerializeField]
    private GameObject[] gameObjects;
    private GameObject[] primeiroFrame;
    private Animator animator;
    [SerializeField]
    float curTime;
    [SerializeField]
    private float delayDeTroca = 0.5f;

    // Use this for initialization
    void Start () {
        animator = mesa.GetComponent<Animator>();
        primeiroFrame = GameObject.FindGameObjectsWithTag("PrimeiroFrame");
	}
	
	// Update is called once per frame
	void Update () {
        curTime += Time.fixedDeltaTime;
        mesa.transform.position = new Vector3(9.9F, 0, 5.91F);
        mesa.transform.localScale += new Vector3(0.1F * (-Input.GetAxis("Horizontal")), 0.1F * (-Input.GetAxis("Horizontal")), 0.1F * (-Input.GetAxis("Horizontal")));
        if (curTime < delayDeTroca)
            return;
        var horizontal = Input.GetAxisRaw("Vertical");
        if(horizontal > 0.5)
        {
            mudaSentidoAnimacao = 1;
            curTime = 0;
        }
        if(horizontal < -0.5)
        {
            mudaSentidoAnimacao = -1;
            curTime = 0;
        }
        estado += mudaSentidoAnimacao;
        if (estado > estadosCount)
        {
            estado = estadosCount;
        }
        else if (estado <= 0)
            estado = 0;
        bool ePrimeiro = estado == 1 ? true: false;
        if(estado == 0)
        {
            for(int i = 0; i < primeiroFrame.Length; i++)
            {
                primeiroFrame[i].SetActive(ePrimeiro);
            }
        }
        if (mudaSentidoAnimacao < 0)
        {
            setVisibility(estado);
        }
        else if (mudaSentidoAnimacao >= 0)
        {
            setVisibility(estado);
            animator.SetInteger("Estado", estado);
        }
        print(estado);
        mudaSentidoAnimacao = 0;
    }
    void setVisibility(int estado)
    {
        estado--;
        int estadoInicial = estado;
        for(int i = 0; i < gameObjects.Length; i++)
        {
            if (i <= estado)
                gameObjects[i].SetActive(true);
            else
                gameObjects[i].SetActive(false);
            if (estado == 1)
            {
                gameObjects[estadoInicial + 1].SetActive(true);
            }else if(i > 1 )
            {
                estado = estadoInicial + 1;
            }
            
        }
        if (estadoInicial == 0)
        {
            gameObjects[1].SetActive(false);
        }
    }
}
