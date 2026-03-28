# NuGet Package Compatibility Audit

Generated as part of [Issue #3](https://github.com/Thorvaldd/dota2Dashboard/issues/3).
All `packages.config` files across the 6 active projects inspected against .NET 10 compatibility.

---

## Blockers — packages with no .NET 5+ build (must replace)

| Package | Current Version | Project(s) | Status | Replacement | Notes |
|---------|----------------|-----------|--------|-------------|-------|
| `EasyGitHub` | 1.0.27.0 | DotaBuffWrapper | ❌ No .NET 5+ build | `Octokit` 13.x (official GitHub SDK) | Used only in `GistClient.cs` to fetch a Gist. See issue #13 |
| `ServiceStack.Text` | 3.9.58 | DotaBuffWrapper | ❌ AGPL, .NET Framework only | `System.Text.Json` / `Newtonsoft.Json 13.x` | Verify actual call sites before removing. See issue #14 |
| `Unity` | 3.5.1404.0 | Dota2 | ❌ Replace entirely | `Microsoft.Extensions.DependencyInjection` (built-in, no package needed) | See issue #10 |
| `WebActivatorEx` | 2.0 | Dota2 | ❌ Not needed in ASP.NET Core | Delete | Used only to bootstrap Unity on startup |
| `CommonServiceLocator` | 1.3 | Dota2 | ❌ Not needed | Delete | Service-locator pattern; Unity dependency |
| `Microsoft.AspNet.Mvc` | 5.2.3 | Dota2 | ❌ .NET Framework only | `Microsoft.AspNetCore.Mvc` (included in `Microsoft.NET.Sdk.Web`) | See issue #18 |
| `Microsoft.AspNet.WebApi` + sub-packages | 5.2.3 | Dota2 | ❌ .NET Framework only | ASP.NET Core unified MVC; no separate WebApi package | 5 packages total; see issue #19 |
| `Microsoft.AspNet.Web.Optimization` | 1.1.3 | Dota2 | ❌ .NET Framework only | `WebOptimizer` NuGet or direct `<script>` tags | See issue #22 |
| `WebGrease` | 1.5.2 | Dota2 | ❌ Transitive dep of Optimization | Delete | No replacement needed once bundling is replaced |
| `Antlr` | 3.4.1.9004 | Dota2 | ❌ Transitive dep of WebGrease | Delete | |
| `Microsoft.Bcl.Build` | 1.0.21 | Dota2 | ❌ Legacy MSBuild compatibility shim | Delete | Not needed with SDK-style projects |
| `Microsoft.Net.Compilers` | 1.0.0 | Dota2 | ❌ Legacy Roslyn shim | Delete | SDK-style projects include the compiler |
| `Microsoft.CodeDom.Providers.DotNetCompilerPlatform` | 1.0.0 | Dota2 | ❌ Legacy | Delete | |
| `Microsoft.Bcl.Build` / `Microsoft.Net.Http` | various | Dota2 | ❌ Legacy BCL packages | Delete | `System.Net.Http` is built-in on .NET 10 |
| `EntityFramework` | 6.0.0 – 6.1.3-beta1 | All projects | ❌ EF6 (.NET Framework) | `Microsoft.EntityFrameworkCore` 9.x + `Microsoft.EntityFrameworkCore.SqlServer` 9.x | See issue #8 |

---

## Updates required — compatible packages with stale versions

| Package | Current Versions | Project(s) | Target Version | Breaking Changes |
|---------|----------------|-----------|---------------|-----------------|
| `Newtonsoft.Json` | 6.0.4 / 8.0.2 / 8.0.3 / 9.0.1 | All projects (inconsistent) | **13.0.3** | None for basic serialization; `JsonConverter` subclasses unchanged |
| `HtmlAgilityPack` | 1.4.9 | Dota2, WebApiRepository, DotaBuffWrapper | **1.11.67** | No breaking changes; same API surface |
| `CloudinaryDotNet` | 1.0.22 (Dota2), 1.0.23 (Dota2Import) | Dota2, Dota2Import | **1.26.x** | `GetResource(string)` overload removed → use `GetResource(new GetResourceParams(id))`. See issue #12 |
| `JetBrains.Annotations` | 10.0.0 | Dota2 | **2024.x** | No breaking changes |
| `Microsoft.jQuery.Unobtrusive.Ajax` | 3.2.3 | Dota2 | Remove or keep as static file | Package not needed in ASP.NET Core; reference JS directly |
| `jQuery` | 1.10.2 | Dota2 | Latest 3.x (optional) | Significant API changes between 1.x and 3.x — defer to later |
| `bootstrap` | 3.0.0 | Dota2 | Latest 5.x (optional) | Major UI changes — defer to later |
| `Modernizr` | 2.6.2 | Dota2 | Remove | Largely obsolete for modern browsers |
| `Respond` / `Sammy.js` | various | Dota2 | Remove | IE8 polyfill (Respond) and obsolete routing lib (Sammy) |

---

## Compatible — no action required

| Package | Current Version | Project(s) | Notes |
|---------|----------------|-----------|-------|
| `System.Runtime` | 4.0.0 | Dota2 | Built-in on .NET 10; remove the explicit reference |
| `Microsoft.Web.Infrastructure` | 1.0.0.0 | Dota2 | Remove; MVC 5 bootstrap shim, not needed in Core |
| `jQuery.Validation` | 1.11.1 | Dota2 | Static JS file; unaffected by migration |
| `Microsoft.jQuery.Unobtrusive.Validation` | 3.2.3 | Dota2 | Static JS file; unaffected |

---

## Version inconsistencies (same package, different versions across projects)

| Package | Dota2 | Dota2ApiWrapper | WebApiRepository | Dota2Import | DotaBuffWrapper |
|---------|-------|----------------|-----------------|-------------|----------------|
| `Newtonsoft.Json` | 9.0.1 | **6.0.4** | 8.0.2 | 8.0.3 | 9.0.1 |
| `EntityFramework` | 6.1.3 | 6.1.3 | 6.1.3 | **6.0.0** | **6.1.3-beta1** |
| `CloudinaryDotNet` | **1.0.22** | — | — | 1.0.23 | — |
| `HtmlAgilityPack` | 1.4.9 | — | 1.4.9 | — | 1.4.9 |

All inconsistencies resolved by `Directory.Packages.props` (see issue #28).

---

## Summary — packages to add (net10.0)

| Package | Version | Replaces |
|---------|---------|---------|
| `Microsoft.EntityFrameworkCore` | 9.0.x | `EntityFramework` |
| `Microsoft.EntityFrameworkCore.SqlServer` | 9.0.x | `EntityFramework.SqlServer` |
| `Microsoft.EntityFrameworkCore.Design` | 9.0.x | EF migrations tooling |
| `Microsoft.EntityFrameworkCore.InMemory` | 9.0.x | Testing |
| `Microsoft.Extensions.DependencyInjection` | 10.0.x | `Unity` |
| `Microsoft.Extensions.Configuration.Json` | 10.0.x | `ConfigurationManager` |
| `Microsoft.Extensions.Http` | 10.0.x | `WebClient` / `HttpClient` factory |
| `Octokit` | 13.x | `EasyGitHub` |
| `SixLabors.ImageSharp` | 3.x | `System.Drawing.Common` |
| `WebOptimizer.Core` | latest | `Microsoft.AspNet.Web.Optimization` |
| `Newtonsoft.Json` | 13.0.3 | All existing versions (unified) |
| `HtmlAgilityPack` | 1.11.67 | 1.4.9 |
| `CloudinaryDotNet` | 1.26.x | 1.0.22/1.0.23 |
