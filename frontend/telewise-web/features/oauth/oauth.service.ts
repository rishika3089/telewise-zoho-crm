import { apiClient, Endpoints } from "@/lib/api";

import type { OAuthAuthorizationResponse } from "./types";

export async function getAuthorizationUrl(): Promise<string> {
  const { data } =
    await apiClient.get<OAuthAuthorizationResponse>(
      Endpoints.oauthLogin,
    );

  return data.authorizationUrl;
}