import Link from "next/link";

export default function HomePage() {
  return (
    <main className="flex min-h-screen flex-col items-center justify-center gap-6">
      <h1 className="text-4xl font-bold">
        Telewise CRM Event Notifier
      </h1>

      <p className="text-muted-foreground">
        Production-ready Zoho CRM Marketplace Extension
      </p>

      <Link
        href="/dashboard"
        className="rounded-md bg-primary px-5 py-3 text-primary-foreground"
      >
        Open Dashboard
      </Link>
    </main>
  );
}