export interface SettingsDto {
  notificationsEnabled: boolean;
  defaultWebhook: string;
}

export interface UpdateSettingsRequest {
  notificationsEnabled: boolean;
  defaultWebhook: string;
}