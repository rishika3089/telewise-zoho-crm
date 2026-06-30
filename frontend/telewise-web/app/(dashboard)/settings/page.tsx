"use client";

import { useEffect, useState } from "react";

import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";

import {
  getSettings,
  saveSettings,
} from "@/features/settings/settings.service";

export default function SettingsPage() {
  const [notificationsEnabled, setNotificationsEnabled] =
    useState(true);

  const [defaultWebhook, setDefaultWebhook] =
    useState("");

  useEffect(() => {
    async function load() {
      const settings =
        await getSettings();

      setNotificationsEnabled(
        settings.notificationsEnabled,
      );

      setDefaultWebhook(
        settings.defaultWebhook,
      );
    }

    load();
  }, []);

  async function onSave() {
    await saveSettings({
      notificationsEnabled,
      defaultWebhook,
    });

    alert("Settings saved.");
  }

  return (
    <div className="space-y-8">

      <div>

        <h1 className="text-3xl font-bold">
          Settings
        </h1>

      </div>

      <div className="space-y-4 max-w-xl">

        <Input
          value={defaultWebhook}
          onChange={(e) =>
            setDefaultWebhook(
              e.target.value,
            )
          }
          placeholder="Webhook URL"
        />

        <label className="flex gap-2 items-center">

          <input
            type="checkbox"
            checked={notificationsEnabled}
            onChange={(e) =>
              setNotificationsEnabled(
                e.target.checked,
              )
            }
          />

          Notifications Enabled

        </label>

        <Button onClick={onSave}>
          Save Settings
        </Button>

      </div>

    </div>
  );
}