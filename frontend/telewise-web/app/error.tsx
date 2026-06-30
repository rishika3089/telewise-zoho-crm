"use client";

export default function Error({
  error,
  reset,
}: {
  error: Error;
  reset: () => void;
}) {
  return (
    <main className="flex min-h-screen flex-col items-center justify-center gap-4">
      <h1 className="text-3xl font-bold">
        Something went wrong
      </h1>

      <p>{error.message}</p>

      <button
        onClick={reset}
        className="rounded-md border px-4 py-2"
      >
        Try Again
      </button>
    </main>
  );
}