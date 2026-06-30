import type { ReactNode } from "react";

interface PageContainerProps {
  children: ReactNode;
}

export function PageContainer({
  children,
}: PageContainerProps) {
  return (
    <main className="flex-1 overflow-y-auto bg-muted/20 p-8">
      <div className="mx-auto max-w-7xl space-y-8">
        {children}
      </div>
    </main>
  );
}