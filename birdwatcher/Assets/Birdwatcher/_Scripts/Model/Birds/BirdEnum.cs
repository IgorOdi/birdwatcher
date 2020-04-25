namespace Birdwatcher.Model.Birds {

    public enum BirdPart {

        BEAK,
        BODY,
        WINGS,
        LEGS,
        TAIL,
        COLOR_PATTERN
    }

    public enum Beak {

        GENERALIST,
        INSECT,
        GRAIN,
        SEED,
        NECTAR,
        FRUIT,
        CHISEL,
        NETTING,
        AERIAL_FISHING,
        RAPTORIAL
    }

    public enum Body {

        SMALL,
        MEDIUM,
        BIG,
        HUGE,
    }

    public enum Wing {

        FAST, //Good for zooming. Ex: Falcons
        FLAPPY, //Good for darting around yards. Ex: Sparrows
        SWOOPY, //Good for taking off and circling. Ex: Big Hawks, Eagles and Vultures
        GULL, //Good for cruising very efficiently. Ex: Gulls and Albatrosses
    }

    public enum Legs {

        GENERIC,
        LONG,
        RAPTORIAL,
        PADDLING,
        GRIPPING,
    }

    public enum Tail {

        BASIC,
        LONG,
        FORKED,
        MAJESTIC,
    }
}