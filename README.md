# test-previsul
<div align='center'>Teste para Desenvolvedor de Software da Previsul Seguradora - 2020</div>

<div align='center'>Teste Cadastro de Cliente - Backend</div>

<br>
<p>O objetivo desse teste é criar um CRUD (Create, Read, Update and Delete) de Cliente e seus endereços.</p>
<ol> 
<li>Criar as tabelas no banco de dados através dos scripts CLIENTES.SQL e CLIENTE_ENDERECOS.SQL ou através de migration.</li>
<li>Criar um projeto WebApi .net core. De preferência utilizar entityFramework Core ou Dapper.</li>
<li>Criar 4 serviços contendo os métodos do protocolo HTTP (POST, PUT, GET e DELETE).
<ol>
<li>Criar um serviço para criação do cliente.</li>
<li>Ao salvar o cliente, na mesma requisição deverá ser incluso uma lista de endereços do cliente em questão.</li>
<li>Criar um serviço para listar os clientes e seus devidos endereços. 3.3 - Criar um serviço para alterar o cliente e seus devidos endereços.</li>
<li>Caso o cliente existir na lista e não existir no banco de dados, deverá inserir o mesmo.</li>
<li>Caso o cliente existir na lista e no banco de dados, deverá alterar o mesmo registro.</li>
<li>Caso o cliente existir no banco de dados e não existir na lista, deverá excluir o cliente do banco de dados.</li>
<li>Criar um serviço para excluir o cliente e seus devidos endereços.</li>
</ol></li>
<li>Criar um projeto de teste de integração, de todos os serviços (POST, PUT, GET, DELETE) criados, utilizando como opção: xUnit, NUnit, MSTest ou através da ferramenta Postman. Caso optar pela ferramenta Postman, enviar o arquivo JSON, exportada dessa ferramenta.</li>
</ol>
