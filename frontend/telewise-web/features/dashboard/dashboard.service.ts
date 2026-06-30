import { apiClient, Endpoints } from "@/lib/api";

export interface DashboardSummary {
  backendHealthy: boolean;
  notificationsEnabled: boolean;
  notificationCount: number;
}

export async function getDashboardSummary(): Promise<DashboardSummary> {
  const [health, settings, notifications] = await Promise.all([
    apiClient.get(Endpoints.health),
    apiClient.get(Endpoints.settings),
    apiClient.get(Endpoints.notifications),
  ]);

  return {
    backendHealthy: health.status === 200,
    notificationsEnabled: settings.data.notificationsEnabled,
    notificationCount: notifications.data.length,
  };
}