# CleanArchStarter.React

Standalone React + TypeScript + Vite client for the CleanArchStarter API.
No component library — plain HTML/CSS only.

## Run

```bash
cd clients/CleanArchStarter.React
npm install
npm run dev        # serves on http://localhost:5173
```

The API must be running separately on http://localhost:5015 (the default dev port).
Start it with:

```bash
dotnet run --project src/CleanArchStarter.API
```

## Change the API URL

Edit `.env` (copy from `.env.example` if it doesn't exist):

```
VITE_API_BASE_URL=http://localhost:5015
```

Vite exposes the value as `import.meta.env.VITE_API_BASE_URL`. The single
declaration site is `src/products/productsApi.ts` — nothing else needs to change.

## Deleting this folder

This directory is fully self-contained. No .NET project references it and it is not
listed in CleanArchStarter.slnx. Deleting `clients/CleanArchStarter.React/` has
zero effect on the backend build or tests.
