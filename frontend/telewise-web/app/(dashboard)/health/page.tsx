"use client";

import { useCallback, useEffect, useState } from "react";

import { Badge } from "@/components/ui/badge";
import { Button } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";

import { ErrorMessage } from "@/components/shared/error-message";
import { Loading } from "@/components/shared/loading";

import { HealthService } from "@/features/health/health.service";

import { env } from "@/lib/config/env";

import type { HealthResponse } from "@/types/health";

export default function HealthPage() {
  const [health, setHealth] =
  useState<HealthResponse | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");

  const loadHealth = useCallback(async () => {
  try {
    setLoading(true);

    const response =
      await HealthService.getHealth();

    setHealth(response);
    setError("");
  } catch {
    setError("Unable to reach backend.");
  } finally {
    setLoading(false);
  }
}, []);
useEffect(() => {
  queueMicrotask(() => {
    void loadHealth();
  });
}, [loadHealth]);

  if (loading) {
    return <Loading />;
  }

  if (error) {
    return <ErrorMessage message={error} />;
  }

  return (
    <div className="space-y-8">
      <div className="flex items-center justify-between">
        <div>
          <h1 className="text-3xl font-bold">
            Backend Health
          </h1>

          <p className="mt-2 text-muted-foreground">
            Monitor the backend service status.
          </p>
        </div>

        <Button onClick={loadHealth}>
          Refresh
        </Button>
      </div>

      <div className="grid gap-6 md:grid-cols-3">
        <Card>
          <CardHeader>
            <CardTitle>Status</CardTitle>
          </CardHeader>

          <CardContent>
            <Badge
              variant={
                health?.status === "Healthy"
                  ? "default"
                  : "destructive"
              }
            >
              {health?.status}
            </Badge>
          </CardContent>
        </Card>

        <Card>
          <CardHeader>
            <CardTitle>Backend URL</CardTitle>
          </CardHeader>

          <CardContent>
            <p className="break-all text-sm text-muted-foreground">
              {env.apiBaseUrl}
            </p>
          </CardContent>
        </Card>

        <Card>
          <CardHeader>
            <CardTitle>Last Health Check</CardTitle>
          </CardHeader>

          <CardContent>
            <p className="text-sm">
              {health?.timestampUtc
                ? new Date(
                    health.timestampUtc,
                  ).toLocaleString()
                : "-"}
            </p>
          </CardContent>
        </Card>
      </div>

      <Card>
        <CardHeader>
          <CardTitle>
            Service Information
          </CardTitle>
        </CardHeader>

        <CardContent className="space-y-3">
          <div className="flex justify-between border-b pb-2">
            <span className="text-muted-foreground">
              Service
            </span>

            <span>Telewise Backend API</span>
          </div>

          <div className="flex justify-between border-b pb-2">
            <span className="text-muted-foreground">
              Environment
            </span>

            <span>Development</span>
          </div>

          <div className="flex justify-between">
            <span className="text-muted-foreground">
              API Base URL
            </span>

            <span className="break-all text-right">
              {env.apiBaseUrl}
            </span>
          </div>
        </CardContent>
      </Card>
    </div>
  );
}