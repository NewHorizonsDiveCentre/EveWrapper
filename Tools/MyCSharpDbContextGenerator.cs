using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;

public class MyCSharpDbContextGenerator : CSharpDbContextGenerator
{
    Regex _onConfigRemove = new Regex(@"\n\ *?protected override void OnConfiguring.*?{.*?}.*?}\n\ *?(?=\n\ )", RegexOptions.Singleline | RegexOptions.IgnoreCase);

    public MyCSharpDbContextGenerator(
        IScaffoldingProviderCodeGenerator providerCodeGenerator,
        IAnnotationCodeGenerator annotationCodeGenerator,
        ICSharpUtilities cSharpUtilities) :
    base(providerCodeGenerator, annotationCodeGenerator, cSharpUtilities)
    { }

    public override string WriteCode(IModel model, string @namespace, string contextName, string connectionString, bool useDataAnnotations)
    {
        return "using EveWrapper.Models;\n" +
            _onConfigRemove.Replace(base.WriteCode(model, "EveWrapper", "EveContext", connectionString, useDataAnnotations), "");
    }
}
