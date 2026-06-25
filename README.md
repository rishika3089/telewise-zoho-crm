cat > README.md << 'EOF'
# Telewise CRM Event Notifier

A production-ready Zoho CRM Marketplace Extension that listens to CRM events (Lead Created, Contact Created, Deal Created) and dispatches notifications via configurable providers.

## Tech Stack

- **Frontend:** Next.js 15, TypeScript, Tailwind CSS, shadcn/ui
- **Backend:** ASP.NET Core 8 Web API
- **Database:** MongoDB 7
- **Infrastructure:** Docker, Kubernetes

## Repository Structure
telewise-zoho-crm/

├── backend/        # ASP.NET Core Web API

├── frontend/       # Next.js application

├── extension/      # Zoho Marketplace extension package

├── docs/           # Architecture docs and API contracts

├── docker/         # Docker configs and init scripts

└── docker-compose.yml
## Development

### Prerequisites

- Node.js 20+
- .NET SDK 8.0
- Docker Desktop
- Zoho Extension Toolkit (`npm install -g zoho-extension-toolkit`)

### Start local infrastructure

```bash
docker compose up -d mongodb
```

## Phases

- [x] Phase 0: Development Environment
- [ ] Phase 1: Zoho CRM Extension Scaffold
- [ ] Phase 2: Backend Foundation
- [ ] Phase 3: Frontend Foundation
- [ ] Phase 4: Zoho OAuth
- [ ] Phase 5: CRM Event Registration
- [ ] Phase 6: Store CRM Payload
- [ ] Phase 7: Notification Service
- [ ] Phase 8: Notification Logs
- [ ] Phase 9: Extension Integration
- [ ] Phase 10: Marketplace Ready
- [ ] Phase 11: Docker (full stack)
- [ ] Phase 12: Kubernetes
EOF
