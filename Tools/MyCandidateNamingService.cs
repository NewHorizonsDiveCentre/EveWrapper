using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;

public class MyCandidateNamingService : CandidateNamingService
{
    static HashSet<string> SuffixesBase = new HashSet<string>
    {
        "tx", "mn", "_n", "fl", "bl"
    };
    static HashSet<string> SuffixesRepeat = new HashSet<string>
    {
        "tx"
    };
    static Dictionary<string, string> NameMaps = new Dictionary<string, string>
    {

    };

    string TrimSuffix(string ident, HashSet<string> comp)
    {
        var offset = ident.Length - 2;
        if (ident.Length > 2 && comp.Contains(ident.Substring(offset, 2).ToLowerInvariant()))
            return ident.Substring(0, offset);
        return ident;
    }

    public override string GenerateCandidateIdentifier(string originalIdentifier)
    {
        if (NameMaps.ContainsKey(originalIdentifier))
            originalIdentifier = NameMaps[originalIdentifier];
        else if (originalIdentifier.StartsWith("T_", StringComparison.InvariantCultureIgnoreCase))
            originalIdentifier = originalIdentifier.Substring(4);
        else if (originalIdentifier.Length > 2)
            originalIdentifier = TrimSuffix(TrimSuffix(originalIdentifier.Substring(2), SuffixesBase), SuffixesRepeat);
        return base.GenerateCandidateIdentifier(originalIdentifier);
    }
}
