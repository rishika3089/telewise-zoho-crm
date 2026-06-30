import { apiClient, Endpoints } from "@/lib/api";

export interface NotificationItem {
  eventType: string;
  destination: string;
  status: string;
  sentAtUtc: string;
}

export async function getNotifications() {
  const response = await apiClient.get<NotificationItem[]>(
    Endpoints.notifications,
  );

  return response.data;
}