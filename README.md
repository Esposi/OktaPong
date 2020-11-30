# OktaPong
Unity3D Game

## Sobre.**<br/>
OktaPong é um minigame baseado em turnos. Seu funcionamento consiste:
- Disputa entre 2 players, onde a cada turno,um tenta destruir o outro, utilizando um projétil.
- Cada jogador tem 100 pontos de vida
- Ganha quem consumir os 100 pontos de vida do oponente
- O projétil ricocheteia nas paredes e obstáculos.
- Há quatro tipos de projéteis que podem ser utilizados pelos jogadores. Cada um possui funcionalidades diferentes referante a tamanho, dano e velocidade.


## Funcionamento

O jogador pode se movimentar utilizando as setas do teclado ou as teclas "W","S","A","D" para o segundo jogador. As setas nas verticais movimenta o jogador para cima e para baixo enquanto as setas nas horizontais rotaciona o jogador para ajustar seu tiro.


![alt text](https://github.com/Esposi/OktaPong/blob/main/clone%20def/movimentacaoplayer.png)

O jogador tem disponível quatro tipos de projetéis. Para utiliza-los o jogador deve usar a tecla "1","2","3" e "4":

![alt text](https://github.com/Esposi/OktaPong/blob/main/clone%20def/skills1.png)

- 1 - Roxo: Projétil padrão
- 2 - Vermelho: Projétil veloz
- 3 - Verde: Projétil grande devagar
- 4 - Shuriken: Projétil que causa o dobro de dano.

![alt text](https://github.com/Esposi/OktaPong/blob/main/clone%20def/skills2.png)

As telas utilizadas seguem o fluxo 'Main Menu->Game->Chose Map->Dices->Results->Retry'. Antes de começar a partida os jogadores terão que selecionar a fase que querem jogar e disputar dados para ver quem começará:

Main Menu

![alt text](https://github.com/Esposi/OktaPong/blob/main/clone%20def/menu1.png)

Chose Map

![alt text](https://github.com/Esposi/OktaPong/blob/main/clone%20def/fases.png)

Dices 

![alt text](https://github.com/Esposi/OktaPong/blob/main/clone%20def/menu2.png)

After Game

![alt text](https://github.com/Esposi/OktaPong/blob/main/clone%20def/menu3.png)


Para seleção de mapas foi oferecido as opções:

- 1 - Mapa Limpo (Clean);
- 2 - Mapa com poucos obstáculos (Medium);
- 3 - Mapa com obstáculos grandes (9999qi)


![alt text](https://github.com/Esposi/OktaPong/blob/main/clone%20def/maps.png)


## Estrutura

Nesta sessão será apresentado estruturas utilizadas no projeto.

### Pastas

- Assets
  - Material
  - Prefab   
    - Levels    
  - Scene
  - Scripts   
    - Controllers   
    - UI    
  - Sprites
  
### Scripts

Os scripts foram projetados para ter dois pontos de manuseamento principal de funções. MechanicsManager.cs cuida das mecanicas envolvidas na partida entre os jogadores enquanto UIManager.cs cuida de gerenciar as funções basicas dentro de cada tela presente no jogo. O diagrama abaixo exemplifica:


![alt text](https://github.com/Esposi/OktaPong/blob/main/scripts.png)


#### MechanicsManager.cs

Há dois scripts que enviam funções para MechanicsManager.cs:

- PlayerController: Envia funções de identificação de colisão e fim de turno referente ao desparo do projétil;
- InventoryManager: Recebe e Envia informações referentes à dados do jogador, como vida e tiros desparados.

#### UIManager.cs

Há cinco scripts que enviam funções para MechanicsManager.cs:

- MainMenuUI: Solicita abrir e fechar janelas para MainMenu->ChoseLVL;
- ChoseLvlUI: Envia o mapa selecionado para UIManager, e posteriormente é enviado para o MechanicsManager que instanciará o mapa;
- TurnUI: Faz a disputa entre os dados e envia os valores para UIManager que encaminha também para MechanicsManager;
- GameUI: Recebe informações por MechanicsManager -> UIManager para atualização das informações dos jogadores na UI da partida;
- AfterGameUI: Após o termino da partida é enviado informações de InventoryManager->MechanicsManager->UIManager->GameUI que mostrarão a vida restante e os tiros disparados pelos jogadores.


#### ProjectileController.cs

A movimentação do projétil foi programada sem as funções basicas existentes da Unity. Logo, para isso, não foi utilizado o componente RigidBody para os projéteis disparados no jogo. Para movimentação utilizou-se a movimentação de transform.position em relação aos frames do jogo, como mostra abaixo:

![alt text](https://github.com/Esposi/OktaPong/blob/main/clone%20def/movimentprojectile.png)

Para reflexão do projétil foi utilizado a função OnTriggeredEnter. Ao identificar uma parede foi necessario calcular o angulo de reflexão referente ao angulo do vetor velocidade em relação ao vetor normal da parede. A imagem abaixo exemplifica

Desta forma, foi utilizado a seguinte ideia:

![alt text](https://github.com/Esposi/OktaPong/blob/main/clone%20def/movimentprojectileexample.png)

Assim, a reflexão será 2*alpha + angulo inicial. Em codigo ficou:

![alt text](https://github.com/Esposi/OktaPong/blob/main/clone%20def/getnewangle.png)

Foi utilizado speed *=-1 para alteração de direção direita-esqueda. Para isto foi designado tags para supérfícies que mudam a direção do projétil quando é maior que 180º. Desta forma, além do grau de reflexão, quando for identificado "VertBar" o alvo mudará sua direção direita-esqueda.
