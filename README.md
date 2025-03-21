## 🌍 API de Monitoramento e Gestão Ambiental 🌱

API desenvolvida em C# com o .NET 8 utilizando o framework ASP.NET Core, abordando os princípios do **Domain-Driven Design (DDD)**, produzida para gerenciar o meio ambiente de maneira simples e prática. Esta aplicação permite que os usuários se registrem na plataforma, quando feito o login, é possível verificar a temperatura e o nível de poluição de uma determinada localização consumindo a API da [openweathermap]. 
Os usuários também podem registrar alertas de segurança relacionados a efeitos climáticos, como por exemplo, alagamentos ou quedas de árvores causadas por tempestades. É possivel o usuário ver um lista de alertas descritos pelos usuários na plataforma, além de editar e excluir suas proprias publicações. 

Todas as informações são guardadas de forma segura em um banco de dados **SQLite** com  **EntityFramework** atuando como um ORM (Object-Relational-Mapper), simplificando e facilitando as interações com o banco de dados diretamente com objetos .NET  

Ao se registrar, as senhas são criptografadas e armazenadas de forma segura no banco de dados. Além disso, é gerado um **JWT Token** de autenticação e autorização de acesso nos endpoints. Com esse token, ele traz a segurança de apenas o usuário realizar edições e exclusões de suas prórprias publicações, impedindo que usuários não autorizados acessem publicações que não sejam de sua autoria. 

A arquitetura da aplicação se baseaia-se em **REST**, utilizando métodos **HTTP**. O projeto conta com uma documentação **Swagger**,oferecendo uma interface gráfica interativa, que torna a exploração das funcionalidades simples e eficiente. 



## 👨‍💻 Developed in 

![icon-dot-net]
![SQLite]
![icon-swagger]
![icon-rider]
![icon-ubuntu]

## 🔗 Endpoints

- **/AirPollution**
    - **GET** /AirPollution/{lat}/{lon}

- **/Alert**
    - **POST** /AirPollution
    - **GET** /AirPollution
    - **GET** /AirPollution/{location}
    - **GET** /AirPollution/MyAlerts
    - **PUT** /AirPollution/{id}
    - **DELETE** /AirPollution/{id}

- **/Login**
    - **POST** /Login

- **/RegisterUser**
    - **POST** /RegisterUser

- **/Weather**
    - **GET** /Weather/{city}

## ▶️ Getting Started

para obter uma cópia local deste projeto, siga os próximos passos:

### Requisitos

- Visual Studio Versão 2022+, Visual Studio Code ou Rider
- Windows 10+ ou Linux/MacOS com [.NET SDK][dot-net-sdk] instalado 

### Instalação 

1. Clone o repositório:
    ```sh
    git clone git@github.com:lhspinheiro/AquaAirAlert.git
     ```

2. Preencha as informações no arquivo `appsettings.Development.json`. 
```sh
    {
  "ApiKey": {
      "key": "sua key"
  }, 
  "Settings" : {
  "Jwt" : {
    "SigningKey": "senha de 32 caracteres",
    "ExpiresMinutes": 1000
  }
}
}
```

- a key gerada em [openweathermap], na aba "minha API keys".
- A senha de 32 caractres pode ser gerada no [LastPass][LastPass]


3. Execute a API diverta-se.


<!-- Links -->
[dot-net-sdk]: https://dotnet.microsoft.com/pt-br/download/dotnet/8.0
[LastPass]: https://www.lastpass.com/pt/features/password-generator
[openweathermap]: https://openweathermap.org/api


<!-- Icons -->
[icon-dot-net]: https://img.shields.io/badge/.NET-512BD4?logo=dotnet&logoColor=fff&style=for-the-badge
[SQLite]: https://img.shields.io/badge/SQLite-003B57?logo=sqlite&logoColor=fff&style=for-the-badge
[icon-swagger]: https://img.shields.io/badge/Swagger-85EA2D?logo=swagger&logoColor=000&style=for-the-badge
[icon-rider]: https://img.shields.io/badge/Rider-000?logo=rider&logoColor=fff&style=for-the-badge
[icon-ubuntu]: https://img.shields.io/badge/Ubuntu-E95420?logo=ubuntu&logoColor=fff&style=for-the-badge

