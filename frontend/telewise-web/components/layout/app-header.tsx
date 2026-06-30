import { Badge } from "@/components/ui/badge";

export function AppHeader() {
  return (
    <header className="sticky top-0 z-20 border-b bg-background/95 backdrop-blur">
      <div className="flex h-16 items-center justify-between px-8">
        <div>
          <h1 className="text-2xl font-bold tracking-tight">
            Telewise CRM Event Notifier
          </h1>

          <p className="text-sm text-muted-foreground">
            Zoho CRM Marketplace Extension
          </p>
        </div>

        <Badge>
          Backend Connected
        </Badge>
      </div>
    </header>
  );
}