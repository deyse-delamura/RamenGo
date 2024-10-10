# 🍜 **RamenGo** 🍜  
### _Delicie-se com a combinação perfeita de caldos e proteínas!_ 😋✨

---

## 🚀 **Sobre o Projeto**
O **RamenGo** é uma aplicação simples e intuitiva desenvolvida como parte de um teste técnico para um processo seletivo, ! 🍲✨

---

## 🧩 **Estrutura do Projeto**

### 🗂️ **Backend: .NET C# API**
🔹 **Camada de Domínio**: Implementa a lógica central e as regras de negócio.  
🔹 **Camada de Aplicação**: Gerencia a comunicação entre o domínio e a infraestrutura.  
🔹 **Camada de Infraestrutura**: Faz a comunicação com bancos de dados e serviços externos.  
🔹 **Endpoints Principais**:
  - `GET /api/v1/caldos` - Lista todos os caldos disponíveis.
  - `GET /api/v1/proteinas` - Lista todas as proteínas disponíveis.
  - `POST /api/v1/pedido` - Processa o pedido e retorna o preço total e o número de confirmação.

### 🖼️ **Frontend: HTML, CSS e JavaScript Puro**
O front-end foi construído bom base no design proposto no figma. 

🔸 **Home Page**: Uma interface bonita com 1 botão.  
🔸 **Página de Pedido**: Permite que o usuário escolha seu caldo e proteína, exibindo o preço final.  
🔸 **Responsividade**: Adaptado para desktop e mobile, garantindo uma navegação fluida em qualquer tamanho de tela.  

---

## 🌟 **Como Executar o Projeto?**

### 🔧 **1. Clonar o Repositório**
```bash
git clone https://github.com/seu-usuario/RamenGo.git
```

### 📦 **2. Executar o Backend (API)**
Navegue até a pasta do projeto .NET:
```bash
cd RamenGoBackend
```

Compile e execute a aplicação:
```bash
dotnet build
dotnet run
```
A API estará disponível em http://localhost:5000/api/v1.

### 💻 **3. Rodar o Frontend**
Navegue até a pasta do front-end:
```bash
cd RamenGoFront
```
Abra o arquivo index.html no seu navegador ou use uma extensão como Live Server para visualizar o site.

---

## 📚 **Tecnologias Utilizadas**
- **Backend**: .NET Core, C#, Arquitetura Hexagonal, DDD  
- **Frontend**: HTML, CSS, JavaScript  
- **Banco de Dados**: DynamoDB (para persistência de dados)  
- **Ferramentas de Versionamento**: Git, GitHub  
- **Docker**: Para deploy e ambientes isolados  

---

## ✨ **Funcionalidades**
- **Escolha de Ingredientes**: O usuário pode escolher o caldo e a proteína desejada.  
- **Preço Dinâmico**: Cada combinação altera o valor final.  
- **Confirmação de Pedido**: Geração de um número de pedido exclusivo para o cliente.  
