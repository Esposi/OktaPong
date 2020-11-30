# OktaPong
Unity3D Game

**Sobre.**<br/>
OktaPong é um minigame baseado em turnos. Seu funcionamento consiste:
- Disputa entre 2 players, onde a cada turno,um tenta destruir o outro, utilizando um projétil.
- Cada jogador tem 100 pontos de vida
- Ganha quem consumir os 100 pontos de vida do oponente
- O projétil ricocheteia nas paredes e obstáculos.
- Há quatro tipos de projéteis que podem ser utilizados pelos jogadores. Cada um possui funcionalidades diferentes referante a tamanho, dano e velocidade.


**Funcionamento.**<br/>

O jogador pode se movimentar utilizando as setas do teclado ou as teclas "W","S","A","D" para o segundo jogador. As setas nas verticais movimenta o jogador para cima e para baixo enquanto as setas nas horizontais rotaciona o jogador para ajustar seu tiro.


![alt text](https://github.com/Esposi/OktaPong/blob/main/clone%20def/movimentacaoplayer.png)

O jogador tem disponível quatro tipos de projetéis. Para utiliza-los o jogador deve usar a tecla "1","2","3" e "4":

![alt text](https://github.com/Esposi/OktaPong/blob/main/clone%20def/skills1.png)

- 1 - Roxo: Projétil padrão
- 2 - Vermelho: Projétil veloz
- 3 - Verde: Projétil grande devagar
- 4 - Shuriken: Projétil que causa o dobro de dano.

![alt text](https://github.com/Esposi/OktaPong/blob/main/clone%20def/skills2.png)

As telas utilizadas seguem o Fluxo Main Menu->Game->Chose Map->Dices->Results->Retry. Antes de começar a partida os jogadores terão que selecionar a fase que querem jogar e disputar dados para ver quem começará:

Main Menu

![alt text](https://github.com/Esposi/OktaPong/blob/main/clone%20def/menu1.png)

Chose Map

![alt text](https://github.com/Esposi/OktaPong/blob/main/clone%20def/fases.png)

Dices 

![alt text](https://github.com/Esposi/OktaPong/blob/main/clone%20def/menu2.png)

After Game

![alt text](https://github.com/Esposi/OktaPong/blob/main/clone%20def/menu3.png)


Para seleção de mapas foi oferecido as opções:

- 1 - Mapa Limpo(Clean);
- 2 - Mapa com poucos obstáculos(Medium);
- 3 - Mapa com obstáculos grandes(999qi)
