"use client";

import { useEffect, useState } from "react";

import { Badge } from "@/components/ui/badge";
import {
  Card,
  CardContent,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";

import {
  getNotifications,
  NotificationItem,
} from "@/features/notifications/notification.service";

export default function NotificationsPage() {
  const [notifications, setNotifications] = useState<NotificationItem[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    async function load() {
      try {
        const data = await getNotifications();
        setNotifications(data);
      } finally {
        setLoading(false);
      }
    }

    load();
  }, []);

  if (loading) {
    return <p>Loading notifications...</p>;
  }

  return (
    <div className="space-y-8">
      <div>
        <h1 className="text-3xl font-bold">
          Notifications
        </h1>

        <p className="text-muted-foreground mt-2">
          Notification delivery history.
        </p>
      </div>

      <Card>

        <CardHeader>

          <CardTitle>
            Notification Logs
          </CardTitle>

        </CardHeader>

        <CardContent>

          <div className="overflow-x-auto">

            <table className="w-full">

              <thead>

                <tr className="border-b">

                  <th className="py-3 text-left">
                    Event
                  </th>

                  <th className="py-3 text-left">
                    Destination
                  </th>

                  <th className="py-3 text-left">
                    Status
                  </th>

                  <th className="py-3 text-left">
                    Sent
                  </th>

                </tr>

              </thead>

              <tbody>

                {notifications.map((item, index) => (

                  <tr
                    key={index}
                    className="border-b"
                  >

                    <td className="py-4">
                      {item.eventType}
                    </td>

                    <td>
                      {item.destination}
                    </td>

                    <td>

                      <Badge
                        variant={
                          item.status === "Sent"
                            ? "default"
                            : item.status === "Pending"
                            ? "secondary"
                            : "destructive"
                        }
                      >
                        {item.status}
                      </Badge>

                    </td>

                    <td>
                      {new Date(
                        item.sentAtUtc,
                      ).toLocaleString()}
                    </td>

                  </tr>

                ))}

              </tbody>

            </table>

          </div>

        </CardContent>

      </Card>

    </div>
  );
}