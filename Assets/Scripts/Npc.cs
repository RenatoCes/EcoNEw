using System;
using UnityEngine;
using UnityEngine.UI;

public class Npc : MonoBehaviour
{
    public string mensagem = "Olá, bem-vindo à minha loja!";
    public GameObject caixaDeTexto;
    public Text textoUI;
    private bool jogadorPerto = false;
    private bool textoVisivel = false;

    void Start()
    {
        if (caixaDeTexto != null)
        {
            caixaDeTexto.SetActive(false); // Esconde a caixa de texto inicialmente
        }
    }

    void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.Return)) // Tecla Enter
        {
            print("Tecla Enter pressionada");
            AlternarMensagem();
        }
    }

    void AlternarMensagem()
    {
        if (caixaDeTexto != null && textoUI != null)
        {
            textoVisivel = !textoVisivel;
            caixaDeTexto.SetActive(textoVisivel);
            if (textoVisivel)
            {
                textoUI.text = mensagem;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
            print("Jogador perto");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
            if (caixaDeTexto != null)
            {
                caixaDeTexto.SetActive(false);
                textoVisivel = false;
            }
        }
    }
}