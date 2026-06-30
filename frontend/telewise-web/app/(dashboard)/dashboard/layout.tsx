import type { ReactNode } from "react";

import { AppHeader } from "@/components/layout/app-header";
import { Footer } from "@/components/layout/footer";
import { PageContainer } from "@/components/layout/page-container";
import { Sidebar } from "@/components/layout/sidebar";

interface DashboardLayoutProps {
  children: ReactNode;
}

export default function DashboardLayout({
  children,
}: DashboardLayoutProps) {
  return (
    <div className="flex min-h-screen flex-col bg-background">
      <AppHeader />

      <div className="flex flex-1">
        <Sidebar />

        <PageContainer>
          {children}
        </PageContainer>
      </div>

      <Footer />
    </div>
  );
}