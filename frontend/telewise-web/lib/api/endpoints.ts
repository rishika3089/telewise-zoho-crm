export const Endpoints = {
  // Health
  health: "/health",

  // Settings
  settings: "/settings",

  // OAuth
  oauthLogin: "/oauth/login",
  oauthCallback: "/oauth/callback",

  // CRM
  crmEvents: "/crm/events",

  // Notifications
  notifications: "/notifications",
} as const;