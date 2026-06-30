import type { Metadata } from "next";
import "./globals.css";

export const metadata: Metadata = {
  title: "Telewise CRM Event Notifier",
  description:
    "Production-ready Zoho CRM Marketplace Extension",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body>{children}</body>
    </html>
  );
}