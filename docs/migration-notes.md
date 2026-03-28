# Migration Notes — Database & Configuration

Generated as part of [Issue #4](https://github.com/Thorvaldd/dota2Dashboard/issues/4).

---

## EF6 Migration History Summary

6 migrations total in `WebApiRepository/Migrations/`, spanning 2016-06-10 to 2016-06-16:

| # | File | Change |
|---|------|--------|
| 1 | `201606100731348_initial` | Creates `dbo.Heroes` and `dbo.HeroesImages` (with `Blob` column and misnamed `SmaillImageCloudinaryUrl`) |
| 2 | `201606101049093_remove_blob_HeroImages` | Drops `Blob`; renames `SmaillImageCloudinaryUrl` → `cloudinmaryUrl` (typo introduced) |
| 3 | `201606101051014_rename_column_HeroesImages_CloudinaryUrl` | Fixes typo: renames `cloudinmaryUrl` → `cloudinaryUrl` |
| 4 | `201606161103479_NewTable_GameItems` | Creates `dbo.GameItems` with `Id`, `Cost`, `LocalizedName`, `DotaBuffItemName` |
| 5 | `201606161143307_Rename` | Drops index on lowercase `heroid`; recreates on correctly-cased `HeroId` |
| 6 | `201606161150374_NewField_IsRecipe_In_GameItems` | Adds `IsRecipe BIT NOT NULL DEFAULT 0` to `GameItems` |

---

## Final Schema (3 tables)

See [`docs/schema.sql`](schema.sql) for the full DDL.

| Table | Columns | Notes |
|-------|---------|-------|
| `dbo.Heroes` | `Id` (PK, identity), `Name`, `ValveHeroName` | |
| `dbo.HeroesImages` | `HeroId` (PK + FK → Heroes), `Id`, `cloudinaryUrl` | One-to-one with Heroes |
| `dbo.GameItems` | `Id` (PK, identity), `Cost`, `LocalizedName`, `DotaBuffItemName`, `IsRecipe` | |

---

## Connection String Consolidation

Two connection strings exist across config files — they refer to the **same production database**:

| File | Name | Value |
|------|------|-------|
| `Dota2/Web.config` | `1gbD2api` | SQL Server at `mssql4.1gb.ua` |
| `Dota2Import/App.config` | `1gbD2api` | Same SQL Server connection |
| `WebApiRepository/App.config` | `Dota2Db` | **SQLite** at `D:\Work\VSPRJ\Dota2\dota2Db.db` — **vestigial dev artefact** |

### Action required
- The `Dota2Db` SQLite entry in `WebApiRepository/App.config` is dead code from early local development. The SQLite provider (`System.Data.SQLite.EF6`) is also referenced in that `App.config` EF providers block — all of it can be deleted.
- Post-migration, the single connection string moves to `appsettings.json` under key `ConnectionStrings:DefaultConnection` (see issue #21).

---

## EF Core Migration — Phase 3 Action

When executing issue #8:

1. Delete all 6 EF6 migration files (including `.Designer.cs` files) and `Configuration.cs` from `WebApiRepository/Migrations/`.
2. Run:
   ```bash
   dotnet ef migrations add InitialCreate --project WebApiRepository --startup-project Dota2
   ```
3. Verify the generated `Up()` method matches `docs/schema.sql` exactly before applying to production.
4. On an existing production database (where the schema already exists), mark the migration as applied without running it:
   ```bash
   dotnet ef database update --connection "..." -- InitialCreate
   # or insert directly:
   INSERT INTO __EFMigrationsHistory (MigrationId, ProductVersion) VALUES ('InitialCreate', '9.0.0');
   ```
