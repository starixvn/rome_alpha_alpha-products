// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Sonar Code Smell", "S101:Types should be named in camel case",
    Justification = "<Pending>",
    Scope = "type",
    Target = "~T:Alpha.Products.Core.Contracts.ProductStatusManager")]
[assembly: SuppressMessage("Sonar Code Smell", "S1694:An abstract class should have both abstract and concrete methods",
    Justification = "<Pending>",
    Scope = "type",
    Target = "~T:Alpha.Products.Core.Shared.Enumeration")]
[assembly: SuppressMessage("Formatting", "RCS1057:Add empty line between declarations.", Justification = "<Pending>", Scope = "type", Target = "~T:Alpha.Products.Core.Values.ProductStatus")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>", Scope = "type", Target = "~T:Alpha.Products.Core.Services.ConfigurationService")]