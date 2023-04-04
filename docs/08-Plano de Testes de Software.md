# Plano de Testes de Software

Os requisitos para realização dos testes de software são:

● Aplicação desenvolvida em C#;

● Banco de Dados MySQL;

● Conectividade de Internet para acesso às plataformas (APIs);

Os testes funcionais a serem realizados no aplicativo são descritos a seguir:

Por exemplo:
 
| **Caso de Teste** 	| **CT-01 – Single Page- Botão Produtores**|
|:---:	|:---:	|
|	Requisito Associado 	| RF-01 - Sistema deve permitir o cadastro dos produtores na aplicação.|
| Objetivo do Teste 	| Testar se o botão "Produtores" esta funcionando.|
| Passos 	| 1- Abrir a aplicação <br> 2- Clicar no botão "Produtores"<br> 3- Efetuar o cadastro<br>|
|Critério de Êxito |  O cadastro do produtor foi realizado com sucesso.|
|  	|  	|
| **Caso de Teste** 	| **CT-02 – Single Page - Botão Distribuidores**	
|  	|  	|
|Requisito Associado | RF-02	- O sistema deve permitir o cadastro dos distribuidores na aplicação.|
| Objetivo do Teste 	| Testar se o botão "Distribuidores" esta funcionando.|
| Passos 	| 1- Abrir a aplicação <br> 2- Clicar no botão "Distribuidores"<br> 3- Efetuar o cadastro<br>| 
|Critério de Êxito | O cadastro do distribuidor foi realizado com sucesso.|
|  	|  	|
| **Caso de Teste** 	| **CT-03 - Single Page - Botão Restaurantes e Lojas Varejos**	
|  	|  	|
|Requisito Associado | RF-03 - O sistema deve permitir o cadastro dos restaurantes e lojas varejos na aplicação.|
| Objetivo do Teste 	| Testar se o botão "Restaurantes e Lojas Varejos" esta funcionando|
| Passos 	| 1- Abrir a aplicação <br> 2- Clicar no botão "Restaurantes e Lojas Varejos"<br> 3- Efetuar o cadastro<br>| 
|Critério de Êxito | O cadastro restaurante/ loja varejo foi realizado com sucesso.|
|  	|  	|
| **Caso de Teste** 	| **CT-04 - Single Page - Meu Perfil**|
|  	|  	|
|Requisito Associado | RF-04 - O sistema deverá ter o módulo de informações cadastrais, produtos, minhas compras, minhas vendas, anúncios, estoques, reputação, métricas, perguntas, respostas, faturamento, meu perfil.|
| Objetivo do Teste 	| Testar se o botão "Meu Perfil" esta funcionando|
| Passos 	| 1- Abrir a aplicação<br> 2- Selecione se é Produtor<br> Revendedor ou Restaurante e/ou Loja Varejo<br> 3- Em seguida digite seu usuário e senha<br>|
|Critério de Êxito | Será direcionado para a área de meu perfil, onde terá acesso as informações de anúncios, compras, vendas, informações cadastrais, estoques, reputações, métricas, perguntas, respostas, perfil|
|  	|  	|
| **Caso de Teste** 	| **CT-05 - Banco de Dados - Cadastro de Produto**|
|  	|  	|
|Requisito Associado | RF-05 - O sistema deve permitir o cadastro dos produtos (frutas, legumes e verduras) na aplicação.|
| Objetivo do Teste 	| O Sistema irá testar o cadastro dos produtos no banco de dados|
| Passos 	| 1- Abrir a aplicação<br> 2- Selecione se é Produtor, Revendedor ou Restaurante e/ou Loja Varejo<br> 3- Em seguida digite seu usuário e senha<br> 4- Clique no Botão cadastre seu produto<br>|
|Critério de Êxito | Será direcionado para a área de cadastro de produto|
|   |   |
| **Caso de Teste** 	| **CT-06 - Banco de Dados - Buscar Produtos por Localidade**|
|  	|  	|
|Requisito Associado | RF-06 - O sistema deve permitir visualizar a busca de produtos por localidade.|
| Objetivo do Teste 	| Será testado se tem produtos em todos os locais e o que esta no sistema|
| Passos 	| 1- Abrir a aplicação<br> 2- Selecione se é Produtor, Revendedor ou Restaurante e/ou Loja Varejo<br> 3- Em seguida digite seu usuário e senha<br> 4- Clique no Botão buscar e filtre por localidade<br>|
|Critério de Êxito | Será disponibilizado apenas os produtos da região escolhida.|
|  	|  	|
| **Caso de Teste** 	| **CT-07 - Área Logada - Negociação**|
|  	|  	|
|Requisito Associado | RF- 07 - O sistema deve ter uma área logada para negociar os produtos.|
| Objetivo do Teste 	| Área logada para o cliente negociar com vendedor |
| Passos 	| 1- Abrir a aplicação<br> 2- Selecione se é Produtor, Revendedor ou Restaurante e/ou Loja Varejo<br> 3- Em seguida digite seu usuário e senha<br> 4- Escolher qual vendedor gostaria de negociar, acessar o perfil localizar o vendedor e encaminhar mensagem<br>|
|Critério de Êxito | Será direcionado para um ambiente de msgs para negociação entre comprador e vendedor|
|  	|  	|
| **Caso de Teste** 	| **CT-08 - Área Logada - Efetuar Pedidos**|
|  	|  	|
|Requisito Associado | RF-08 - O sistema deve ter uma área logada para realizar os pedidos.|
| Objetivo do Teste 	| Área logada para realizar os pedidos|
| Passos 	| 1- Abrir a aplicação<br> 2- Selecione se é Produtor, Revendedor ou Restaurante e/ou Loja Varejo<br> 3- Em seguida digite seu usuário e senha<br>4- Clique no Botão buscar e filtre por localidade<br> 5- Adicione no carrinho<br>|
|Critério de Êxito | Será direcionado para uma ambiente de confirmação de pedido|
|  	|  	|
| **Caso de Teste** 	| **CT-09 - Área Logada - Efetuar  Pagamento (API)**|
|  	|   |
|Requisito Associado | RF-09 - O sistema deve permitir o pagamento através da API de pagamento pela aplicação.|
| Objetivo do Teste 	|Área logada para efetuar pagamentos|
| Passos 	| 1- Abrir a aplicação<br> 2- Selecione se é Produtor, Revendedor ou Restaurante e/ou Loja Varejo<br> 3- Em seguida digite seu usuário e senha<br> 4- Clique no Botão buscar e filtre por localidade<br> 5- Adicione no carrinho<br> 6- Escolhe forma de pagamento<br>|
|Critério de Êxito | Será direcionado para uma ambiente de confirmação de pagamento|
|  	|  	|
| **Caso de Teste** 	| **CT-10 - Single Page - Meu Perfil**	|
|  	|  	|
|Requisito Associado | RF-10 - O sistema deve permitir incluir, excluir, alterar usuários |
| Objetivo do Teste 	|Incluir, excluir e alterar usuários na aplicação |
| Passos 	| 1- Abrir a aplicação<br> 2- Selecione se é Produtor, Revendedor ou Restaurante e/ou Loja Varejo<br> 3- Em seguida digite seu usuário e senha<br> 4- Clique em "Meu Perfil"<br> 5- Escolha a opção Incluir, Excluir ou Alterar Usuário<br>|6- Preencha o formulário e salve<br>
|Critério de Êxito | Será direcionado para uma ambiente de confirmação de alteração|
|  	|  	|
| **Caso de Teste** 	| **CT-11 - Banco de Dados - Produtos Cadastrados**	|
|  	|  	|
|Requisito Associado | RF-11 - O sistema deve ter um banco de dados com todos os produtos cadastrados |
| Objetivo do Teste 	|Realizar um pré cadastro no BD de todas as frutas, legumes e verduras para nossos usuários não terem problema quanto forem anunciar seus produtos|
| Passos 	| 1- Acessar o banco de dados incluir todas as tabelas atualizada<br>|
|Critério de Êxito | Será direcionado para uma ambiente incluindo as tabelas|
|  	|  	|
| **Caso de Teste** 	| **CT-12 - Meu Perfil - Relatórios Gerenciais**	|
|  	|  	|
|Requisito Associado | RF-12 - O sistema deve gerar relatórios gerenciais |
| Objetivo do Teste 	|Acompanhar as vendas, estoques, clientes|
| Passos 	|1- Abrir a aplicação<br> 2- Selecione se é Produtor, Revendedor ou Restaurante e/ou Loja Varejo<br> 3- Em seguida digite seu usuário e senha<br> 4- Clique em "Meu Perfil"<br> 5- Relatórios Gerenciais<br>|
|Critério de Êxito | Será direcionado para uma ambiente com acesso a relatórios gerenciais|
|  	|  	|
| **Caso de Teste** 	| **CT-13 - Single Page (API CLIMA)**|
|  	|  	|
|Requisito Associado | RF - 13 - O sistema deve enviar mala direta com promoções (API Clima) e Sazonalidades|
| Objetivo do Teste 	|Diferencial para nossos clientes, comunicando a todos ajudando com dicas para vender mais|
| Passos 	|1- Adquirir estatisca API Clima<br> 2- Preparar Arquivo<br> 3- Selecionar o arquivo<br> 4 - Selecionar os destinatários<br> 5 - Enviar<br>|
|Critério de Êxito | Será direcionado para API para trabalhar estimativa do tempo e sazonalidades e depois encaminhar aos clientes|




 
> **Links Úteis**:
> - [IBM - Criação e Geração de Planos de Teste](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Práticas e Técnicas de Testes Ágeis](http://assiste.serpro.gov.br/serproagil/Apresenta/slides.pdf)
> -  [Teste de Software: Conceitos e tipos de testes](https://blog.onedaytesting.com.br/teste-de-software/)
> - [Criação e Geração de Planos de Teste de Software](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Ferramentas de Test para Java Script](https://geekflare.com/javascript-unit-testing/)
> - [UX Tools](https://uxdesign.cc/ux-user-research-and-user-testing-tools-2d339d379dc7)
