# MntVazaoApp
Um aplicativo desenvolvido em Xamarin para consultar as leituras das medições aferidas por um sensor de vazão de água.

<h4 align="center"> 
  <a href="#Tecnologias-e-ferramentas">Tecnologias e ferramentas</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp; 
  <a href="#Sobre-o-projeto">Sobre o projeto</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#Demonstração">Demonstração</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#Licença">Licença</a>
</h4>

<br/>

<p align="center">
  <a href="https://opensource.org/licenses/MIT">
    <img src="https://img.shields.io/badge/License-MIT-blue.svg" alt="License MIT">
  </a>
</p>

# Tecnologias e ferramentas

O projeto foi desenvolvido com as seguintes tecnologias e ferramentas:

- [Visual Studio 2019 Community](#Pré-requisitos)
- [Xamarin](https://dotnet.microsoft.com/apps/xamarin)

# Sobre o projeto

Este é um projeto desenvolvido em Xamarin Forms que consulta uma API para popular suas telas.                                                     
Embora o Xamarin seja multiplataforma, este projeto foi testado apenas no sistema operacional Android.

Abaixo, estão os detalhes do dispositivo Android contruído para simulação:

<p align="center">
  <img src="https://github.com/renanegobbi/MntVazaoApp/blob/main/Github/DetalhesDispositivoSimulacao.png"/>
</p>

# Demonstração

O aplicativo conterá 3 telas. Da esquerda pra direita, da imagem abaixo, temos:                                          
1 - Tela inicial (esquerda): buscará pelo id do sensor e preencherá nesta tela informações de suas especificações e descrições do produto. Caso o id seja válido, populará as três telas com as informações vindas da API consumida.                                            
2 - Tela de dados (meio): conterá uma espaço para que seja plotado o gráfico, a média de vazão lida durante o dia e a data pela qual se quer obter as informações da média e a visualização gráfica ao longo do dia, plotada pelas médias das 24 horas do dia. No eixo-y do gráfico será mostrada a média da vazão de água durante aquela hora, respectiva ao eixo-x.                                                                                                             
3 - Tela de mapa (direita): tela do aplicativo com informações sobre a qual organização o sensor pertence, contato desta organização, descrição de onde encontrar esse sensor e um pin com o endereço mostrado no mapa. 

<p align="center">
  <img src="https://github.com/renanegobbi/MntVazaoApp/blob/main/Github/AppImg1.png"/>
</p>

Aplicação funcionando em um emulador Android.

<img src="https://github.com/renanegobbi/MntVazaoApp/blob/main/Github/AppImg2.png"/>

Aplicação funcionando em um Tablet Android.

<img src="https://github.com/renanegobbi/MntVazaoApp/blob/main/Github/Telas_Tablet.png"/>

<p align="center">
  <img src="https://github.com/renanegobbi/MntVazaoApp/blob/main/Github/MntVazaoApp.gif">
</p>

# Licença
Este projeto está sob a licença do MIT. Consulte a [LICENÇA](https://github.com/TesteReteste/lim/blob/master/LICENSE) para obter mais informações.
