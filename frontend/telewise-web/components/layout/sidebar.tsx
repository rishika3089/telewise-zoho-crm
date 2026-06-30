"use client";

import Link from "next/link";
import { usePathname } from "next/navigation";

const navigation = [
  {
    href: "/dashboard",
    label: "Dashboard",
  },
  {
    href: "/health",
    label: "Health",
  },
  {
    href: "/oauth",
    label: "OAuth",
  },
  {
    href: "/settings",
    label: "Settings",
  },
  {
    href: "/notifications",
    label: "Notifications",
  },
];

export function Sidebar() {
  const pathname = usePathname();

  return (
    <aside className="w-64 border-r bg-muted/30">
      <nav className="flex flex-col gap-2 p-5">
        {navigation.map((item) => {
          const active = pathname === item.href;

          return (
            <Link
              key={item.href}
              href={item.href}
              className={`rounded-lg px-4 py-3 text-sm font-medium transition-all ${
                active
                  ? "bg-primary text-primary-foreground shadow"
                  : "hover:bg-accent hover:text-accent-foreground"
              }`}
            >
              {item.label}
            </Link>
          );
        })}
      </nav>
    </aside>
  );
}