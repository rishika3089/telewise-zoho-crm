export const env = {
  appName:
    process.env.NEXT_PUBLIC_APP_NAME ??
    "Telewise CRM Event Notifier",

  apiBaseUrl:
    process.env.NEXT_PUBLIC_API_BASE_URL ??
    "http://localhost:5209",
} as const;