export function Footer() {
  return (
    <footer className="border-t bg-background px-6 py-4">
      <p className="text-center text-sm text-muted-foreground">
        © {new Date().getFullYear()} Telewise CRM Event Notifier
      </p>
    </footer>
  );
}