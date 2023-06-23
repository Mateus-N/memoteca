# Memoteca

Linguagens: C# e TypeScript
Principais tecnologias: AspNetCore, Entity Framwork, Serilog, Ocelot, Angular e Docker.

## Histórico de desenvolvimento
Inicialmente o propósito era desenvolver apenas a aplicação Front em conjunto com o curso de Angular na alura, entretando no decorrer do curso é simulado uma Api com o JSON Server, com isso surgiu a ideia de desenvolver a Api para a aplicação, tendo todas as funcionalidades necessárias para o front que estava sendo desenvolvido, outras ideias foram surgindo como logs mais limpos, paginação, Api Gateway e outras funcionalidades que serão apresentadas logo mais.

# Front-end

<img src="https://github.com/Mateus-N/memoteca/blob/master/images/front.png" alt="Tela inicial da aplicação" width="600">

Aplicação Angular com CRUD simples, requisições HTTP realizadas através de classe service e com HttpClient, formulário construido e validado com FormBuilder.

Após o final do curso surgiu a ideia de colocar a aplicação em um container Docker, adicionei os arquivos para as variáveis que seriam alteradas após a mudaça de ambiente, o Dockerfile tem como base uma imagem do NGINX que cria um servidor utilizando o arquivo nginx.conf que está na raiz na aplicação angular, o nginx expõe a porta <strong>80</strong> que no docker-compose é mapeado para a <strong>8080</strong>.

# Back-end
Para ser utilizada na aplicação front desenvolvida no curso a api deveria ao menos possuir: CRUD completo, paginação, busca e ordenção, além dessas adicionei também a opção de inverter a lista de dados, o resultado após um GET é o seguinte:

<img src="https://github.com/Mateus-N/memoteca/blob/master/images/paginacao.png" alt="Tela inicial da aplicação" width="300">

### GET api/pensamentos
Os seguintes parâmetros que podem ser passados através da Query:

page: pode ser passado o número da página desejada, caso não seja passado, seja passado um número de página negativo ou acima do total de páginas da listagem é retornada a página 1.
```
api/pensamentos?page=2
```

pageSize: pode ser passado a quantidade de itens desejados em cada página, caso não seja passado, seja passado um número negativo ou um número maior que 10, a listagem retorna com 10 itens.
```
api/pensamentos?pageSize=6
```

orderBy: pode ser passado qual atributo que a listagem será ordenada, caso não seja passado ou o atributo passado não exista na entidade é feita a ordenação pelo ID.
```
api/pensamentos?orderBy=autoria
```

busca: pode ser passado um filtro para ser aplicado antes da páginação.
```
api/pensamentos?busca=luffy
```

reverse: pode ser passado um true ou false para inverter a listagem, caso não seja passado tem valor padrão o false.
```
api/pensamentos?reverse=true
```

### GET api/pensamentos/{id}

Busca o pensamento que possúi o id passado.

Caso for encotrado retorna HTTP 200 e o objeto no corpo da requisição.<br>
Caso não for encontrado retorna HTTP 404.<br>
Caso o id não for no formato correto retorna HTTP 400.

### POST api/pensamentos

Recebe no corpo da requisição um objeto que será gravado no banco de dados.
O objeto deve ser no seguinte formato:
```javascript
{
  conteudo: string,
  autoria: string,
  modelo: string
}
```
A requisição retorna HTTP 201, o objeto criado com a adição do campo ID e a rota para acessar o objeto.

### PUT api/pensamentos

Recebe no corpo da requisição um objeto que será alterado no banco de dados.
O objeto deve ser no seguinte formato:
```javascript
{
  id: Guid,
  conteudo: string,
  autoria: string,
  modelo: string
}
```
A requisição retorna HTTP 20e o objeto editado.

### GET api/pensamentos/{id}

Busca e exclui o pensamento que possui o ID passado retornando HTTP 204.
