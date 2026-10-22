# CleanArchStarter.Angular

Standalone Angular client for the CleanArchStarter API. No NgModules — pure
standalone components throughout.

## Run

```bash
cd clients/CleanArchStarter.Angular
npm install
npm start          # serves on http://localhost:4200
```

The API must be running separately on http://localhost:5015 (the default dev port).
Start it with:

```bash
dotnet run --project src/CleanArchStarter.API
```

## Change the API URL

Edit `src/environments/environment.ts`:

```typescript
export const environment = {
  production: false,
  apiBaseUrl: 'http://localhost:5015'   // <-- change this
};
```

## Deleting this folder

This directory is fully self-contained. No .NET project references it and it is not
listed in CleanArchStarter.slnx. Deleting `clients/CleanArchStarter.Angular/` has
zero effect on the backend build or tests.
