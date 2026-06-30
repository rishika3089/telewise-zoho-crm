import { apiClient, Endpoints } from "@/lib/api";

export interface Settings {
  notificationsEnabled: boolean;
  defaultWebhook: string;
}

export async function getSettings() {
  const response =
    await apiClient.get<Settings>(
      Endpoints.settings,
    );

  return response.data;
}

export async function saveSettings(
  settings: Settings,
) {
  await apiClient.post(
    Endpoints.settings,
    settings,
  );
}