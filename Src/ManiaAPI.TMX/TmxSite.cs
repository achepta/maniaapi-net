namespace ManiaAPI.TMX;

public enum TmxSite
{
    TMUF,
    TMNF,
    Nations,
    Sunrise,
    Original,
    Maniaplanet,
    Trackmania,
    Shootmania
}

public static class TmxSiteExtensions {
    public static bool isMX(this TmxSite site) {
        switch(site) {
            case TmxSite.Maniaplanet:
            case TmxSite.Trackmania:
            case TmxSite.Shootmania:
                return true;
            default:
                return false;
        } 
    }
}