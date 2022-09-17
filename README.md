# Eventos da Cidade - Projeto Final - Web API

Este repositório contém a minha avaliação final do módulo Web API III da turma 854 - programa Top Coders da Ada com o banco Safra.

> Conceitos aplicados: Web API | Controllers | Diretrizes REST | Decorators | Filters | Validação de Campos | Tratamento de Exceções | Status Codes | Injeção de Dependência | Arquitetura de Software | Conexão com Banco de Dados
</br>


## Enunciado
Construa uma API que registre e manipule eventos que acontecem na cidade, como shows, peças de teatro, eventos especiais em restaurantes, entre outros.

Implemente a documentação completa da API, utilizando Swagger. Todos os métodos devem possuir validação dos campos obrigatórios, quais os formatos de dados que a API recebe e responde e quais os possíveis status de retorno.

Construa uma API bem estruturada, respeitando as diretrizes de REST, SOLID e os princípios base de arquitetura.

Trate as exceções que forem necessárias.

Esta API deverá ter um cadastro do evento e um cadastro de reservas. Siga a estrutura apresentada abaixo:
```
CityEvent:
IdEvent             long          incremento PK
Title               string        not null
Description         string        null
DateHourEvent       DateTime      not null
Local               string        not null
Address             string        null
Price               decimal       null
Status              bool          not null

EventReservation:
IdReservation       long          incremento PK
IdEvent             long          not null FK
PersonName          string        not null
Quantity            long          not null
```

Para o CityEvent, construa os métodos:
- Inclusão de um novo evento; *Autenticação e Autorização admin
- Edição de um evento existente, filtrando por id; *Autenticação e Autorização admin
- Remoção de um evento, caso o mesmo não possua reservas em andamento, caso possua inative-o; *Autenticação e Autorização admin
- Consulta por título, utilizando similaridades, por exemplo, caso pesquise Show, traga todos os eventos que possuem a palavra Show no título;
- Consulta por local e data;
- Consulta por range de preço e a data;
</br>
Para o EventReservation, construa os métodos:

- Inclusão de uma nova reserva; *Autenticação
- Edição da quantidade de uma reserva; *Autenticação e Autorização admin
- Remoção de uma reserva; *Autenticação e Autorização admin
- Consulta de reserva pelo PersonName e Title do evento, utilizando similaridade para o title; *Autenticação
<br/>
Utilize para autenticação os seguintes parametros:

```C#
Audience = "APIEvents.com"
Issuer = "APIClientes.com"
key = "<chave secreta>"
```
<br/>

## :hammer: Como executar o programa
- Clone o repositório em uma pasta local: `git clone https://github.com/sathyagimenes/WebAPI_ProjetoFinal.git`
- Abra a solução do projeto com o Visual Studio: arquivo `WebAPI_ProjetoFinal.sln`
- Crie o arquivo `appsettings.json` e informe os dados para estabelecer a conexão com o banco de dados e a SecretKey.
```
  "ConnectionStrings": {
        "DefaultConnection": "Server= <Digite o endereço do servidor>; Database= <Informe a base de dados>; User Id= <Digite seu usuário>; Password= <Digite sua senha> ; Encrypt=False"
        }
    "SecretKey": "<chave secreta>"
```
- Execute o projeto com `CTRL + F5`

### Token - Para gerar o token de autenticação:
- Clone o repositório da [API Cliente](https://github.com/sathyagimenes/WEBAPI.Aula01): `git clone https://github.com/sathyagimenes/WEBAPI.Aula01.git`
- Siga as intruções de execução informadas no `README.md` da API Cliente.
