# Telewise CRM Event Notifier

A full-stack Zoho CRM Marketplace Extension that listens to CRM events such as Lead Created, Contact Created, and Deal Created, stores event information in MongoDB, and provides a modern dashboard to manage OAuth authentication, webhook configuration, notification history, and backend health monitoring.

---

# Features

- Zoho CRM OAuth 2.0 Authentication
- ASP.NET Core 8 REST API
- Next.js 15 Dashboard
- MongoDB Integration
- Health Monitoring
- Notification Management
- Webhook Configuration
- Docker Support
- Swagger API Documentation

---

# Technology Stack

## Frontend

- Next.js 15
- React
- TypeScript
- Tailwind CSS
- shadcn/ui
- Axios

## Backend

- ASP.NET Core 8 Web API
- C#
- Dependency Injection
- Swagger

## Database

- MongoDB

## DevOps

- Docker
- Docker Compose

---

# Project Structure

```
telewise-zoho-crm

├── backend
│   └── Telewise.Api
│
├── frontend
│   └── telewise-web
│
├── extension
│
├── docs
│
├── docker
│
└── docker-compose.yml
```

---

# Application Modules

## Dashboard

Displays

- Backend Health
- Notification Status
- Notification Count
- Webhook Status

---

## Health

Checks backend availability and API status.

---

## OAuth

Implements Zoho OAuth 2.0 authentication flow.

---

## Settings

Allows webhook URL configuration and notification preferences.

---

## Notifications

Displays notification history stored by the backend.

---

# Backend APIs

| Endpoint | Description |
|----------|-------------|
| GET /health | Backend health check |
| GET /oauth/login | Generate Zoho OAuth URL |
| GET /oauth/callback | OAuth callback |
| GET /settings | Retrieve settings |
| POST /settings | Save settings |
| GET /notifications | Retrieve notifications |

---

# Local Setup

## Prerequisites

- Node.js 20+
- .NET SDK 8
- MongoDB
- Docker Desktop (optional)

---

## Backend

```bash
cd backend/Telewise.Api

dotnet restore

dotnet run
```

Runs at

```
http://localhost:5209
```

Swagger

```
http://localhost:5209/swagger
```

---

## Frontend

```bash
cd frontend/telewise-web

npm install

npm run dev
```

Runs at

```
http://localhost:3000
```

---

# Environment Variables

## Backend (.env)

```
ZOHO_CLIENT_ID

ZOHO_CLIENT_SECRET

ZOHO_REDIRECT_URI

ZOHO_ACCOUNTS_URL

ZOHO_API_URL

MONGO_CONNECTION_STRING

MONGO_DATABASE
```

## Frontend (.env.local)

```
NEXT_PUBLIC_API_BASE_URL=http://localhost:5209

NEXT_PUBLIC_APP_NAME=Telewise CRM Event Notifier
```

---

# Future Improvements

- CRM Event Registration
- Real-time Notifications
- Email Provider Integration
- Teams/Slack Notifications
- Kubernetes Deployment
- Marketplace Publishing

---

# Author

Rishika Rajput

Telewise 