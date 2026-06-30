import { apiClient, Endpoints } from "@/lib/api";
import type { HealthResponse } from "@/types/health";

export class HealthService {
  static async getHealth(): Promise<HealthResponse> {
    const response = await apiClient.get<HealthResponse>(
      Endpoints.health,
    );

    return response.data;
  }
}