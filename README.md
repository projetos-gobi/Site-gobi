# Site Gobi Consulting

Site institucional da Gobi Consulting desenvolvido em ASP.NET Core MVC.

## 📋 Pré-requisitos

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download) ou superior
- Conta no [SendGrid](https://sendgrid.com/) para funcionalidade de e-mail
- Git

## 🚀 Começando

### 1. Clone o repositório

```bash
git clone https://github.com/projetos-gobi/Site-gobi.git
cd Site-gobi
```

### 2. Configure as credenciais do SendGrid

O projeto usa o SendGrid para envio de e-mails. Você precisa configurar suas credenciais antes de rodar a aplicação.

#### Opção A: User Secrets (Recomendado para desenvolvimento)

```bash
cd src/Gobi.Consulting
dotnet user-secrets set "SEND_GRID_API_KEY" "sua-chave-sendgrid-aqui"
dotnet user-secrets set "SEND_GRID_FROM" "seu-email@gobi.consulting"
```

#### Opção B: Variáveis de Ambiente

```bash
export SEND_GRID_API_KEY="sua-chave-sendgrid-aqui"
export SEND_GRID_FROM="seu-email@gobi.consulting"
```

#### Opção C: Arquivo appsettings.json (NÃO RECOMENDADO)

Edite o arquivo `src/Gobi.Consulting/appsettings.json` e adicione suas credenciais:

```json
{
  "SEND_GRID_API_KEY": "sua-chave-sendgrid-aqui",
  "SEND_GRID_FROM": "seu-email@gobi.consulting"
}
```

⚠️ **ATENÇÃO:** Se usar esta opção, NUNCA faça commit deste arquivo com suas credenciais reais!

### 3. Restaure as dependências

```bash
cd src/Gobi.Consulting
dotnet restore
```

### 4. Execute o projeto

```bash
dotnet run
```

O site estará disponível em:
- HTTPS: `https://localhost:5001`
- HTTP: `http://localhost:5000`

## 🛠️ Tecnologias Utilizadas

- **ASP.NET Core MVC** - Framework web
- **SendGrid** - Serviço de envio de e-mails
- **jQuery** - Biblioteca JavaScript
- **jQuery Validation** - Validação de formulários
- **SimplyScroll** - Plugin para scroll de logos de parceiros

## 📁 Estrutura do Projeto

```
Site-gobi/
├── src/
│   └── Gobi.Consulting/
│       ├── Controllers/          # Controladores MVC
│       ├── Models/              # Modelos de dados
│       ├── Views/               # Views Razor
│       ├── wwwroot/             # Arquivos estáticos (CSS, JS, imagens)
│       ├── appsettings.json     # Configurações da aplicação
│       └── Program.cs           # Ponto de entrada
└── README.md
```

## 📧 Funcionalidades

- **Página Home** - Apresentação da empresa e serviços
- **Seção Sobre** - Informações sobre a Gobi Consulting
- **Seção Serviços** - Descrição dos serviços oferecidos
- **Seção Clientes** - Logos dos parceiros e clientes
- **Formulário de Contato** - Envio de mensagens via SendGrid
- **Política de Privacidade** - Termos e condições

## 🔒 Segurança

Este projeto utiliza as melhores práticas de segurança:

- Credenciais sensíveis não são commitadas no repositório
- Uso de User Secrets para desenvolvimento local
- Validação de formulários no cliente e servidor
- CAPTCHA para proteção contra spam

## 🤝 Como Contribuir

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/MinhaFeature`)
3. Commit suas mudanças (`git commit -m 'Adiciona MinhaFeature'`)
4. Push para a branch (`git push origin feature/MinhaFeature`)
5. Abra um Pull Request

## 📝 Licença

Este projeto é propriedade da Gobi Consulting.

## 📞 Contato

**Gobi Consulting**
- Website: [gobi.consulting](https://gobi.consulting)
- Email: gobi@gobi.consulting

---

Desenvolvido com ❤️ pela equipe Gobi Consulting

