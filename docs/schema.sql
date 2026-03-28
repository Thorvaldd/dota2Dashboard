-- =============================================================
-- Final SQL Server schema — derived from 6 EF6 migrations
-- WebApiRepository/Migrations/ (2016-06-10 → 2016-06-16)
--
-- Use this as the ground-truth reference when creating the
-- EF Core InitialCreate migration in Phase 3 (issue #8).
-- =============================================================

-- Migration 1: 201606100731348_initial
-- Migration 2: 201606101049093_remove_blob_HeroImages
-- Migration 3: 201606101051014_rename_column_HeroesImages_CloudinaryUrl
-- Migration 4: 201606161103479_NewTable_GameItems
-- Migration 5: 201606161143307_Rename (index rename only)
-- Migration 6: 201606161150374_NewField_IsRecipe_In_GameItems

-- -------------------------------------------------------------
-- Table: dbo.Heroes
-- Created: migration 1. No subsequent changes.
-- -------------------------------------------------------------
CREATE TABLE dbo.Heroes (
    Id              INT             NOT NULL IDENTITY(1,1),
    Name            NVARCHAR(MAX)   NULL,
    ValveHeroName   NVARCHAR(MAX)   NULL,
    CONSTRAINT PK_Heroes PRIMARY KEY (Id)
);

-- -------------------------------------------------------------
-- Table: dbo.HeroesImages
-- Created: migration 1.
-- Migration 2: dropped Blob column; renamed SmaillImageCloudinaryUrl → cloudinmaryUrl (typo)
-- Migration 3: renamed cloudinmaryUrl → cloudinaryUrl (typo fixed)
-- Migration 5: dropped index on lowercase 'heroid'; recreated on 'HeroId'
-- -------------------------------------------------------------
CREATE TABLE dbo.HeroesImages (
    HeroId          INT             NOT NULL,   -- PK and FK to dbo.Heroes.Id
    Id              INT             NOT NULL,
    cloudinaryUrl   NVARCHAR(MAX)   NULL,
    -- NOTE: Blob BINARY column existed briefly (migration 1) then was dropped (migration 2)
    -- NOTE: Column was originally named SmaillImageCloudinaryUrl (migration 1),
    --       renamed to cloudinmaryUrl (migration 2 — typo), then to cloudinaryUrl (migration 3)
    CONSTRAINT PK_HeroesImages PRIMARY KEY (HeroId),
    CONSTRAINT FK_HeroesImages_Heroes FOREIGN KEY (HeroId)
        REFERENCES dbo.Heroes (Id)
);

CREATE INDEX IX_HeroesImages_HeroId ON dbo.HeroesImages (HeroId);

-- -------------------------------------------------------------
-- Table: dbo.GameItems
-- Created: migration 4.
-- Migration 6: added IsRecipe column.
-- NOTE: The original migration 4 had a column named 'Name' (NVARCHAR 300).
--       Migration 5 (Rename) only changed indexes on HeroesImages, not GameItems.
--       The DotaBuffItemName column was present from creation per the C# model.
-- -------------------------------------------------------------
CREATE TABLE dbo.GameItems (
    Id                  INT             NOT NULL IDENTITY(1,1),
    Cost                INT             NOT NULL,
    LocalizedName       NVARCHAR(300)   NULL,
    DotaBuffItemName    NVARCHAR(300)   NULL,
    IsRecipe            BIT             NOT NULL    DEFAULT 0,
    CONSTRAINT PK_GameItems PRIMARY KEY (Id)
);
