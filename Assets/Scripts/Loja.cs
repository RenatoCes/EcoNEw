using UnityEngine;
using UnityEngine.UI;

public class Loja : MonoBehaviour
{
    public GameObject canvaLoja;
    public int dinheiro = 100; // Dinheiro inicial do jogador
    public Text dinheiroTexto;
    public Button botaoItem1;
    public Button botaoItem2;
    public Button botaoItem3;
    private bool jogadorPerto = false;

    void Start()
    {
        AtualizarUI();
        canvaLoja.SetActive(false);
        botaoItem1.onClick.AddListener(() => ComprarItem(1));
        botaoItem2.onClick.AddListener(() => ComprarItem(2));
        botaoItem3.onClick.AddListener(() => ComprarItem(3));
    }

    void ComprarItem(int item)
    {
        int preco = ObterPreco(item);
        if (dinheiro >= preco)
        {
            dinheiro -= preco;
            Debug.Log("Item " + item + " comprado por " + preco + " moedas.");
            AtualizarUI();
        }
        else
        {
            Debug.Log("Dinheiro insuficiente para comprar o item " + item);
        }
    }

    int ObterPreco(int item)
    {
        switch (item)
        {
            case 1: return 20;
            case 2: return 50;
            case 3: return 75;
            default: return 0;
        }
    }

    void AtualizarUI()
    {
        if (dinheiroTexto != null)
        {
            dinheiroTexto.text = "Dinheiro: " + dinheiro;
        }
    }
    void AlternarVisibilidadeMensagem()
    {
        if (canvaLoja != null)
        {
            canvaLoja.SetActive(true);
        }
        else
        {
            canvaLoja.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
            print("Jogador perto");
            canvaLoja.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
            canvaLoja.SetActive(false);
        }
    }
}