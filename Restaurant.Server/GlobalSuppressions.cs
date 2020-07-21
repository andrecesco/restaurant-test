// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Globalization", "CA1308:Normalize strings to uppercase", Justification = "Output needs to be in lower case", Scope = "member", Target = "~M:Restaurant.Domain.Dishes.Orders.Models.ProcessingOrder.ToString~System.String")]
[assembly: SuppressMessage("Globalization", "CA1308:Normalize strings to uppercase", Justification = "Output needs to be in lower case", Scope = "member", Target = "~M:Restaurant.Domain.Dishes.Orders.Models.SelectOrder.ToString~System.String")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Method is called in the setup lifecycle", Scope = "member", Target = "~M:Restaurant.Startup.ConfigureContainer(Autofac.ContainerBuilder)")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Method is called in the setup lifecycle", Scope = "member", Target = "~M:Restaurant.Startup.Configure(Microsoft.AspNetCore.Builder.IApplicationBuilder,Microsoft.AspNetCore.Hosting.IWebHostEnvironment)")]
