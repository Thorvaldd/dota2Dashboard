# CLAUDE.md — Dota 2 Dashboard

This file provides context and conventions for AI assistants working in this codebase.

---

## Project Overview

A Dota 2 statistics dashboard built on **ASP.NET MVC 5 / .NET Framework 4.5**. It aggregates hero, item, and player data from multiple sources: the Steam Dota 2 API, Dotabuff (web scraping), and YASP. The project is **unfinished and in active development**.

---

## Solution Structure

```
Dota2.sln
├── Dota2/               # ASP.NET MVC web application (UI layer)
├── WebApiRepository/    # Data access layer (EF6, Repository/UoW patterns)
├── Dota2ApiWrapper/     # Steam Dota 2 API client (async wrapper)
├── DotabuffWrapper/     # Dotabuff/YASP web scraper (older version, ~0.1.0.0)
├── DotaBuffWrapper/     # Dotabuff/YASP web scraper (newer refactor, ~0.1.0.3)
├── Dota2Import/         # Console app: imports heroes/items into the database
└── ViewModels/          # Shared view model classes
```

### Dota2 (MVC Web App)

- **Controllers/**: `BaseController`, `HomeController`, `HeroesController`, `DotaBuffController`, `StatsController`
- **Views/**: Razor `.cshtml` templates; partials under `Views/{Controller}/Partials/`
- **App_Start/**: `RouteConfig`, `UnityConfig` (DI), `BundleConfig`, `WebApiConfig`, `FilterConfig`
- **Scripts/pages/**: Page-specific JavaScript; `Scripts/libs/` for third-party JS
- Default route → `Heroes/Index`

### WebApiRepository (Data Layer)

- **ApplicationContext**: EF6 `DbContext`
- **Models/**: `Heroes`, `HeroesImages`, `GameItems` (decorated with `[Table]`/`[Column]`)
- **Repository/**: `IGenericRepository<T>` / `GenericRepository<T>`
- **UnitOfWork/**: `IUnitOfWork` / `UnitOfWork`
- **Interfaces/** + **Implementations/**: `IDota2HeroesService` / `Dota2HeroesService`
- **Migrations/**: EF Code-First migrations (5 migrations, 2016-06-10 → 2016-06-16)

### Dota2ApiWrapper (Steam API Client)

- **ApiHandler.cs**: All Steam API calls as async `Task<T>` methods
- **ApiClasses/**: ~57 domain model classes (Hero, Match, Player, Team, etc.)
- **Results/**: Generic `ApiResult<T>` wrappers for each endpoint
- **Converters/**: Custom `JsonConverter` subclasses for Steam's quirky JSON (Unix timestamps, enum-as-int, etc.)
- **Enums/**: `GameMode`, `Faction`, `LobbyType`, `LeaverStatus`, etc.
- **Exceptions/**: `InvalidApiKeyException`, `ServiceUnavailableException`, etc.

### DotabuffWrapper / DotaBuffWrapper (Web Scrapers)

- **Dataparser.cs**: Public entry point
- **Controller/**: Per-entity controllers (`HeroController`, `ItemController`, `PlayerController`, …) + `Dotabuff/` and `Yasp/` subdirectories
- **Model/**: Domain models with interfaces in `Model/Dotabuff/Interfaces/`
- **Mapping/Dotabuff/{version}/**: JSON files (`Urls.json`, `XPaths.json`, `Selectors.json`, `QueryStrings.json`, etc.) — **config-driven scraping logic**
- Mapping configs are versioned and can be fetched live from GitHub Gist (`GistClient.cs`)

### Dota2Import (Console App)

- Imports heroes and game items from the Steam API into the SQL Server database
- Handles image conversion/upload via Cloudinary

---

## Key Technologies

| Concern | Library / Version |
|---|---|
| Web framework | ASP.NET MVC 5.2.3 |
| ORM | Entity Framework 6.1.3 |
| DI container | Microsoft Unity 3.5 |
| JSON | Newtonsoft.Json 9.0.1 |
| HTML parsing | HtmlAgilityPack 1.4.9 |
| Image hosting | CloudinaryDotNet 1.0.22-23 |
| Frontend | jQuery 1.10.2, Bootstrap 3.0.0, Material Design Lite |
| Build | MSBuild (Visual Studio 2015 solution format) |
| Package mgmt | NuGet (`packages.config` per project) |

---

## Architecture Patterns

- **Repository Pattern** — `IGenericRepository<T>` abstracts all DB access
- **Unit of Work** — `IUnitOfWork` coordinates multi-repo transactions
- **Service Layer** — `IDota2HeroesService` encapsulates business logic
- **Dependency Injection** — Unity container wired in `UnityConfig.cs`; `IUnitOfWork` uses `HierarchicalLifetimeManager`
- **Mapper Classes** — Separate `ApiMappers/` and `ModelMappers/` for DTO transformation
- **Async throughout** — `Dota2ApiWrapper` uses `async`/`await` for all HTTP calls

---

## Coding Conventions

- **Naming**: PascalCase for types and public members; `_camelCase` for private fields; `I` prefix for interfaces
- **Controllers**: Named `[Entity]Controller`; actions return `ActionResult` or `JsonResult`
- **Regions**: `#region ... #endregion` used to group related members (see `HeroesController`)
- **XML doc comments** on public methods and interfaces
- **Auto-properties**: `{ get; set; }` for EF model properties
- **EF attributes**: `[Table("name")]`, `[Column("name")]` for explicit mapping
- **Razor partials**: Live under `Views/{Controller}/Partials/`; rendered via AJAX for dynamic content

---

## Configuration & Secrets

All configuration lives in **Web.config** (MVC app) or **App.config** (class libraries). There are no `.env` files.

> **Warning:** API keys and the database connection string are currently hardcoded in `Web.config`. Do not commit real credentials; rotate keys before publishing.

Key `<appSettings>` entries:
- `steamApi` — Steam Web API key
- `githubAccessToken` — Used by `GistClient.cs` to fetch scraper mapping configs

Database connection named `1gbD2api` — SQL Server on mssql4.1gb.ua.

---

## Database

- **SQL Server** with EF6 Code-First migrations
- Run `Update-Database` in Package Manager Console (targeting **WebApiRepository**) to apply migrations
- Seed data is populated by the **Dota2Import** console app (heroes, items, images via Cloudinary)

---

## External Data Sources

| Source | Method | Used For |
|---|---|---|
| Steam Dota 2 API | HTTP (async) | Hero list, match history, player/team data |
| Dotabuff.com | HTML scraping (HtmlAgilityPack) | Hero win rates, item stats, player stats |
| YASP | JSON scraping | Alternative player statistics |
| GitHub Gist | HTTP | Remote versioned scraper mapping configs |
| Cloudinary | SDK | Hero/item image storage and delivery |

---

## Routing

Default route resolves to `Heroes/Index`. Standard MVC pattern: `{controller}/{action}/{id}`.

---

## Frontend

- **Layout**: `Views/Shared/_Layout.cshtml` (Material Design Lite + Bootstrap)
- **Bundles**: Defined in `bundleconfig.json`; managed by ASP.NET bundling
- **CSS compilation**: `compilerconfig.json` (LESS/SCSS)
- **JavaScript**: Page-specific scripts in `Scripts/pages/`; jQuery + Bootstrap + chart libraries (Chart.js)
- **Gulp**: Minimal `gulpfile.js` present but largely a placeholder

---

## Testing

No test projects exist in the solution. There is no automated test suite. Manual/integration testing only.

---

## CI/CD

No CI pipeline is configured (no `.github/workflows`). Build via Visual Studio 2015 or MSBuild.

---

## Development Notes

- There are **two scraper libraries** (`DotabuffWrapper` and `DotaBuffWrapper`) — the capitalised `DotaBuffWrapper` is the newer refactor (version 0.1.0.3 vs 0.1.0.0). Prefer `DotaBuffWrapper` for new work.
- The `Dota2Import` console app must be run before the web app has meaningful data; it seeds heroes, images, and items.
- Scraper mapping files in `Mapping/{source}/{version}/` are the first place to update when Dotabuff changes its HTML structure.
- Unity DI registration is in `App_Start/UnityConfig.cs` — add new service bindings there.
- Keep EF model properties in sync with migration history; always generate a new migration rather than editing existing ones.
