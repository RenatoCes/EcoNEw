using System;
using UnityEngine;
using UnityEngine.UI;

public class Npc : MonoBehaviour
{
    public string mensagem = "Olá, gostaria de visitar a minha loja?";
    public GameObject caixaDeTexto;
    public Text textoNPC;
    public Text textoRespostaPlayer;
    private bool jogadorPerto = false;
    private bool textoVisivel = false;

    
    private string[] playerResponses =
{
        "1 - Como você está?",
        "2 - O que você faz por aqui?",
        "3 - Adeus."
    };

    private string[] npcResponses =
    {
        "Estou bem, obrigado por perguntar!",
        "Eu protejo esta vila dos perigos da floresta.",
        "Até logo, viajante!"
    };

    void Start()
    {
        if (caixaDeTexto != null)
        {
            caixaDeTexto.SetActive(false); // Esconde a caixa de texto inicialmente
        }
    }

    void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.Alpha1))
        {

        }
        if (jogadorPerto && Input.GetKeyDown(KeyCode.Alpha2))
        {

        }
        if (jogadorPerto && Input.GetKeyDown(KeyCode.Alpha3))
        {

        }
    }

    void AlternarVisibilidadeMensagem()
    {
        if (caixaDeTexto != null && textoNPC != null)
        {
            textoVisivel = !textoVisivel;
            caixaDeTexto.SetActive(textoVisivel);
            if (textoVisivel)
            {
                textoNPC.text = mensagem;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
            AlternarVisibilidadeMensagem();
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
    //Fazer função que sirva para exibir pergunta do player
    //Fazer função que sirva para exibir resposta do NPC
    //Fazer com que as opções de resposta do player sejam realizadas por meio de botões
    //Navegação da tela seja pormeio de botões que estejam na área de dialogo
}