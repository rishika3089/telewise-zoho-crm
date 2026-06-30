"use client";

import { useEffect, useState } from "react";

import {
  Activity,
  Bell,
  ShieldCheck,
} from "lucide-react";

import { Badge } from "@/components/ui/badge";
import {
  Card,
  CardContent,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";

import {
  DashboardSummary,
  getDashboardSummary,
} from "@/features/dashboard/dashboard.service";

export default function DashboardPage() {
  const [summary, setSummary] =
    useState<DashboardSummary | undefined>();

  const [loading, setLoading] =
    useState(true);

  useEffect(() => {
    async function load() {
      try {
        const result =
          await getDashboardSummary();

        setSummary(result);
      } finally {
        setLoading(false);
      }
    }

    void load();
  }, []);

  if (loading) {
    return (
      <p className="text-muted-foreground">
        Loading dashboard...
      </p>
    );
  }

  return (
    <div className="space-y-8">

      <div>
        <h1 className="text-3xl font-bold">
          Dashboard
        </h1>

        <p className="mt-2 text-muted-foreground">
          Welcome to the Telewise CRM Event
          Notifier dashboard.
        </p>
      </div>

      <div className="grid gap-6 lg:grid-cols-3">

        <Card>

          <CardHeader className="flex flex-row items-center justify-between">

            <CardTitle>
              Backend
            </CardTitle>

            <Activity className="h-5 w-5 text-blue-500" />

          </CardHeader>

          <CardContent>

            <Badge
              variant={
                summary?.backendHealthy
                  ? "default"
                  : "destructive"
              }
            >
              {summary?.backendHealthy
                ? "Connected"
                : "Offline"}
            </Badge>

          </CardContent>

        </Card>

        <Card>

          <CardHeader className="flex flex-row items-center justify-between">

            <CardTitle>
              Notifications
            </CardTitle>

            <Bell className="h-5 w-5 text-yellow-500" />

          </CardHeader>

          <CardContent>

            <p className="text-4xl font-bold">
              {summary?.notificationCount}
            </p>

            <p className="mt-2 text-muted-foreground">
              Notification logs
            </p>

          </CardContent>

        </Card>

        <Card>

          <CardHeader className="flex flex-row items-center justify-between">

            <CardTitle>
              Webhook
            </CardTitle>

            <ShieldCheck className="h-5 w-5 text-green-500" />

          </CardHeader>

          <CardContent>

            <Badge
              variant={
                summary?.notificationsEnabled
                  ? "default"
                  : "secondary"
              }
            >
              {summary?.notificationsEnabled
                ? "Enabled"
                : "Disabled"}
            </Badge>

          </CardContent>

        </Card>

      </div>

      <Card>

        <CardHeader>

          <CardTitle>
            System Overview
          </CardTitle>

        </CardHeader>

        <CardContent className="space-y-3">

          <div className="flex justify-between border-b pb-2">

            <span className="text-muted-foreground">
              Backend Status
            </span>

            <span>
              {summary?.backendHealthy
                ? "Operational"
                : "Offline"}
            </span>

          </div>

          <div className="flex justify-between border-b pb-2">

            <span className="text-muted-foreground">
              Notifications
            </span>

            <span>
              {summary?.notificationCount}
            </span>

          </div>

          <div className="flex justify-between">

            <span className="text-muted-foreground">
              Webhook
            </span>

            <span>
              {summary?.notificationsEnabled
                ? "Configured"
                : "Disabled"}
            </span>

          </div>

        </CardContent>

      </Card>

    </div>
  );
}