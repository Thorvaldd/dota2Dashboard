﻿namespace DotaBuffWrapper.Model.Dotabuff
{
    public enum ParsingWebsites { Dotabuff, Yasp }
    public enum ItemStatValueTypes { Undefined, Percent, Normal }
    public enum ItemStatTypes { Undefined, Attribute, Effect }
    public enum Roles { Undefined, Melee, Carry, Durable, Support, Ranged, Disabler, Pusher, Nuker, Initiator, Escape }
    public enum Attributes { Undefined, Strength, Agility, Intelligence }
    public enum Skillbrackets { Undefined, NormalSkill, HighSkill, VeryHighSkill }
    public enum Types { Undefined, Normal, Ranked, Team, Solo, Custom }
    public enum Results { Undefined, LostMatch, WonMatch }
    public enum Modes { Undefined, AbilityDraft, AllPick, AllRandom, CaptainsDraft, CaptainsMode, LeastPlayed, LimitedHeroPool, RandomDraft, SingleDraft, AllRandomDeathMatch, OnevOneSoloMid }
    public enum Lanes { Undefined, OffLane, SafeLane, Jungle, MiddleLane }
    public enum Dates { Undefined, Week, Month, ThreeMonth, SixMonth, Year }
    public enum Factions { Undefined, Radiant, Dire }
    public enum Durations { Undefined, TwelveMin, TwentyMin, ThirtyMin, FortyMin, FiftyMin, SixtyMin, LessThan20, Between20And30, Between30And40, Between40And50, Between50And60 }
    public enum Regions
    {
        Undefined,
        USWest,
        USEast,
        EuropeWest,
        SouthKorea,
        SEAsia,
        Chile,
        Australia,
        Russia,
        EuropeEast,
        SouthAmerica,
        SouthAfrica,
        China,
        Dubai,
        Peru,
        India
    }

    public enum Heroes
    {
        Undefined,
        Abaddon,
        Alchemist,
        AncientApparition,
        AntiMage,
        ArcWarden,
        Axe,
        Bane,
        Batrider,
        Beastmaster,
        Bloodseeker,
        BountyHunter,
        Brewmaster,
        Bristleback,
        Broodmother,
        CentaurWarrunner,
        ChaosKnight,
        Chen,
        Clinkz,
        Clockwerk,
        CrystalMaiden,
        DarkSeer,
        Dazzle,
        DeathProphet,
        Disruptor,
        Doom,
        DragonKnight,
        DrowRanger,
        EarthSpirit,
        Earthshaker,
        ElderTitan,
        EmberSpirit,
        Enchantress,
        Enigma,
        FacelessVoid,
        Gyrocopter,
        Huskar,
        Invoker,
        Io,
        Jakiro,
        Juggernaut,
        KeeperoftheLight,
        Kunkka,
        LegionCommander,
        Leshrac,
        Lich,
        Lifestealer,
        Lina,
        Lion,
        LoneDruid,
        Luna,
        Lycan,
        Magnus,
        Medusa,
        Meepo,
        Mirana,
        Morphling,
        NagaSiren,
        NaturesProphet,
        Necrophos,
        NightStalker,
        NyxAssassin,
        OgreMagi,
        Omniknight,
        Oracle,
        OutworldDevourer,
        PhantomAssassin,
        PhantomLancer,
        Phoenix,
        Puck,
        Pudge,
        Pugna,
        QueenofPain,
        Razor,
        Riki,
        Rubick,
        SandKing,
        ShadowDemon,
        ShadowFiend,
        ShadowShaman,
        Silencer,
        SkywrathMage,
        Slardar,
        Slark,
        Sniper,
        Spectre,
        SpiritBreaker,
        StormSpirit,
        Sven,
        Techies,
        TemplarAssassin,
        Terrorblade,
        Tidehunter,
        Timbersaw,
        Tinker,
        Tiny,
        TreantProtector,
        TrollWarlord,
        Tusk,
        Undying,
        Ursa,
        VengefulSpirit,
        Venomancer,
        Viper,
        Visage,
        Warlock,
        Weaver,
        Windranger,
        WinterWyvern,
        WitchDoctor,
        WraithKing,
        Zeus
    }
    public enum Items
    {
        Undefined,
        AbyssalBlade,
        AegisOfTheImmortal,
        AetherLens,
        AghanimsScepter,
        AnimalCourier,
        ArcaneBoots,
        ArmletOfMordiggian,
        AssaultCuirass,
        BandOfElvenskin,
        BattleFury,
        BeltOfStrength,
        BlackKingBar,
        BladeMail,
        BladeOfAlacrity,
        BladesOfAttack,
        BlinkDagger,
        Bloodstone,
        BootsOfSpeed,
        BootsOfTravel,
        Bottle,
        Bracer,
        Broadsword,
        Buckler,
        Butterfly,
        Chainmail,
        Cheese,
        Circlet,
        Clarity,
        Claymore,
        Cloak,
        CrimsonGuard,
        Crystalys,
        Daedalus,
        Dagon,
        DagonLevel2,
        DagonLevel3,
        DagonLevel4,
        DagonLevel5,
        DemonEdge,
        Desolator,
        DiffusalBlade,
        DiffusalBladeLevel2,
        DivineRapier,
        DragonLance,
        DrumOfEndurance,
        DustOfAppearance,
        EagleSong,
        EnchantedMango,
        EnergyBooster,
        EtherealBlade,
        EulsScepterOfDivinity,
        EyeOfSkadi,
        FaerieFire,
        FlyingCourier,
        ForceStaff,
        GauntletsOfStrength,
        GemOfTruesight,
        GhostScepter,
        GlimmerCape,
        GlovesOfHaste,
        GuardianGreaves,
        HandOfMidas,
        Headdress,
        HealingSalve,
        HeartOfTarrasque,
        HeavensHalberd,
        HelmOfIronwill,
        HelmOfTheDominator,
        HoodOfDefiance,
        Hyperstone,
        IronBranch,
        IronTalon,
        Javelin,
        LinkensSphere,
        LotusOrb,
        Maelstrom,
        MagicStick,
        MagicWand,
        MantaStyle,
        MantleOfIntelligence,
        MaskOfMadness,
        MedallionOfCourage,
        Mekansm,
        MithrilHammer,
        Mjollnir,
        MonkeyKingBar,
        MoonShard,
        MorbidMask,
        MysticStaff,
        Necronomicon,
        NecronomiconLevel2,
        NecronomiconLevel3,
        Nulltalisman,
        OblivionStaff,
        ObserverAndSentryWards,
        ObserverWard,
        OctarineCore,
        OgreClub,
        OrbOfVenom,
        OrchidMalevolence,
        Perseverance,
        PhaseBoots,
        PipeOfInsight,
        Platemail,
        PointBooster,
        PoormansShield,
        PowerTreads,
        QuarterStaff,
        QuellingBlade,
        Radiance,
        Reaver,
        RefresherOrb,
        RingOfAquila,
        RingOfBasilius,
        RingOfHealth,
        RingOfProtection,
        RingOfRegen,
        RobeOfTheMagi,
        RodOfAtos,
        SacredRelic,
        SagesMask,
        Sange,
        SangeAndYasha,
        Satanic,
        ScytheOfVyse,
        SentryWard,
        ShadowAmulet,
        ShadowBlade,
        ShivasGuard,
        SilverEdge,
        SkullBasher,
        SlippersOfAgility,
        SmokeOfDeceit,
        SolarCrest,
        SoulBooster,
        SoulRing,
        StaffOfWizardry,
        StoutShield,
        TalismanOfEvasion,
        Tango,
        TangoShared,
        TownportalScroll,
        TranquilBoots,
        UltimateOrb,
        BootsOfTravelLevel2,
        UrnOfShadows,
        Vanguard,
        VeilOfDiscord,
        VitalityBooster,
        VladmirsOffering,
        VoidStone,
        WraithBand,
        Yasha,
        RecipeAetherLens,
        RecipeArmletOfMordiggian,
        RecipeAssaultCuirass,
        RecipeBlackKingBar,
        RecipeBloodstone,
        RecipeBootsofTravel,
        RecipeBracer,
        RecipeBuckler,
        RecipeCrimsonGuard,
        RecipeCrystalys,
        RecipeDaedalus,
        RecipeDagon,
        RecipeDesolator,
        RecipeDiffusalBlade,
        RecipeDrumOfEndurance,
        RecipeEulsScepterOfDivinity,
        RecipeForceStaff,
        RecipeGuardianGreaves,
        RecipeHandOfMidas,
        RecipeHeaddress,
        RecipeHeartOfTarrasque,
        RecipeIronTalon,
        RecipeLinkensSphere,
        RecipeLotusOrb,
        RecipeMaelstrom,
        RecipeMantaStyle,
        RecipeMaskOfMadness,
        RecipeMedallionOfCourage,
        RecipeMekansm,
        RecipeMjollnir,
        RecipeNecronomicon,
        RecipeNullTalisman,
        RecipeOrchidMalevolence,
        RecipePipeOfInsight,
        RecipeRadiance,
        RecipeRefresherOrb,
        RecipeSange,
        RecipeSatanic,
        RecipeShivasGuard,
        RecipeSilverEdge,
        RecipeSkullBasher,
        RecipeSoulRing,
        RecipeUrnOfShadows,
        RecipeVladmirsOffering,
        RecipeWraithBand,
        RecipeYasha
    }
}
