# Plano de Implementação - Rede Social Microsserviços

Para iniciar um novo chat, você pode dizer algo como:
"Estou implementando uma rede social baseada em microsserviços.
O serviço de autenticação já está implementado com .NET 8 e EF Core.
Estou seguindo um plano de implementação que inclui Kubernetes, Kafka e Azure.
Atualmente estou na fase [X] do plano, trabalhando em [componente específico]."

## Situação Atual
- Microsserviço de Autenticação (Auth) base implementado
- Stack: .NET 8, EF Core, SQLite
- Estrutura: Clean Architecture
- Docker configurado

## Fases de Implementação

### Fase 1: Fortalecer Auth Service
1. Implementar JWT
2. Migrar para PostgreSQL
3. Adicionar health checks
4. Configurar logs estruturados

### Fase 2: Containerização Avançada
1. Configurar Kubernetes
2. Implementar ConfigMaps e Secrets
3. Criar pipelines CI/CD
4. Configurar service mesh (Istio)

### Fase 3: Mensageria
1. Implementar Kafka
2. Criar eventos de domínio
3. Configurar producers/consumers
4. Implementar retry policies

### Fase 4: Cloud (Azure)
1. Configurar AKS
2. Implementar Azure KeyVault
3. Configurar Azure Monitor
4. Implementar Azure Service Bus

### Fase 5: Novos Microsserviços
1. Profile Service
2. Post Service
3. Social Graph Service
4. Notification Service
5. Media Service

## Arquitetura Final
- Gateway API
- Service Mesh
- Event-Driven Architecture
- Observabilidade completa
- Alta disponibilidade

## Stack Tecnológico
- Backend: .NET 8
- Database: PostgreSQL
- Cache: Redis
- Message Broker: Kafka
- Container: Docker/Kubernetes
- Cloud: Azure
- Observability: Azure Monitor
- CI/CD: Azure DevOps

## Comandos Importantes
```bash
# Kubernetes
kubectl apply -f k8s/

# Docker
docker-compose up -d

# Kafka
kafka-topics.sh --create --topic user-events

# Database
dotnet ef database update
```

## Links Úteis
- Swagger: http://localhost:5052/swagger
- Kubernetes Dashboard: http://localhost:8001/api/v1/namespaces/kubernetes-dashboard/services/https:kubernetes-dashboard:/proxy/
- Kafka UI: http://localhost:8080