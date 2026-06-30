"use client";

import { useState } from "react";

import { Button } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";

import { getAuthorizationUrl } from "@/features/oauth/oauth.service";

export default function OAuthPage() {
  const [loading, setLoading] = useState(false);

  const connect = async () => {
    try {
      setLoading(true);

      const url = await getAuthorizationUrl();

      window.location.href = url;
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="space-y-8">
      <div>
        <h1 className="text-3xl font-bold">
          Zoho OAuth
        </h1>

        <p className="mt-2 text-muted-foreground">
          Connect your Zoho CRM account to Telewise.
        </p>
      </div>

      <Card>
        <CardHeader>
          <CardTitle>
            Zoho CRM Connection
          </CardTitle>
        </CardHeader>

        <CardContent className="space-y-6">
          <p className="text-muted-foreground">
            Click below to authorize this application with
            your Zoho CRM account.
          </p>

          <Button
            onClick={connect}
            disabled={loading}
          >
            {loading
              ? "Redirecting..."
              : "Connect Zoho CRM"}
          </Button>
        </CardContent>
      </Card>
    </div>
  );
}