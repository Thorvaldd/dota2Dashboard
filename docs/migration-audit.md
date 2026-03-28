# Migration Audit — System.Web and .NET Framework-Only API References

Generated as part of [Issue #2](https://github.com/Thorvaldd/dota2Dashboard/issues/2).
Scope: all `.cs` and `.cshtml` files across the active projects (`DotabuffWrapper` excluded — deprecated, see issue #5).

---

## Summary

| Category | File count | Occurrences |
|----------|-----------|-------------|
| `System.Web.*` namespace imports | 11 files | 19 usages |
| `System.Web.Http` / Web API 2 | 3 files | 5 usages |
| `System.Web.Hosting.HostingEnvironment` | 3 files | 3 usages |
| `System.Configuration.ConfigurationManager` | 2 files | 4 usages |
| `System.Data.Entity` (EF6) | 7 files | 20+ usages |
| `System.Drawing` / GDI+ | 1 file | 2 usages |
| `WebClient` (obsolete) | 9 files | 14 usages |
| Windows backslash paths | 2 files | 7 usages |
| `MvcHtmlString` / `AjaxHelper` / `IHtmlString` | 1 file | 5 usages |
| `@Scripts.Render` / `@Html.Partial` (Razor) | 4 files | 23 usages |
| `Encoding.Default` (platform-dependent) | 1 file | 1 usage |
| `IsChildAction` (removed in Core) | 1 file | 1 usage |

---

## Detailed Findings

### 1. `System.Web.Mvc` — MVC 5 controller infrastructure

| File | Line | API Used | .NET 10 Replacement | Tracked In |
|------|------|----------|---------------------|------------|
| `Dota2/Global.asax.cs` | 1–4 | `System.Web.Http`, `System.Web.Mvc`, `System.Web.Optimization`, `System.Web.Routing` | Delete file; replace with `Program.cs` minimal hosting | #17 |
| `Dota2/Global.asax.cs` | 9 | `System.Web.HttpApplication` | `WebApplication.CreateBuilder(args)` in `Program.cs` | #17 |
| `Dota2/Global.asax.cs` | 13 | `AreaRegistration.RegisterAllAreas()` | Not needed in ASP.NET Core | #17 |
| `Dota2/Global.asax.cs` | 17 | `GlobalConfiguration.Configure(WebApiConfig.Register)` | Web API merged into MVC in Core; delete `WebApiConfig.cs` | #17 |
| `Dota2/Global.asax.cs` | 18 | `RouteTable.Routes` | `app.MapControllerRoute(...)` in `Program.cs` | #17 |
| `Dota2/Controllers/BaseController.cs` | 1 | `using System.Web.Mvc` | `using Microsoft.AspNetCore.Mvc` | #18 |
| `Dota2/Controllers/HomeController.cs` | 2 | `using System.Web.Mvc` | `using Microsoft.AspNetCore.Mvc` | #18 |
| `Dota2/Controllers/HeroesController.cs` | 1 | `using System.Web.Mvc` | `using Microsoft.AspNetCore.Mvc` | #18 |
| `Dota2/Controllers/StatsController.cs` | 2–3 | `using System.Web.DynamicData`, `using System.Web.Mvc` | Remove `DynamicData`; `using Microsoft.AspNetCore.Mvc` | #18 |
| `Dota2/App_Start/RouteConfig.cs` | 1–2 | `System.Web.Mvc`, `System.Web.Routing` | Delete file; route moved to `Program.cs` | #17 |
| `Dota2/App_Start/FilterConfig.cs` | 1 | `System.Web.Mvc` | Delete file; `app.UseExceptionHandler("/Home/Error")` | #17 |
| `Dota2/App_Start/UnityConfig.cs` | 2 | `System.Web.Mvc` (`DependencyResolver`) | Delete file; `builder.Services.*` in `Program.cs` | #10 |

---

### 2. `System.Web.Http` — Web API 2

| File | Line | API Used | .NET 10 Replacement | Tracked In |
|------|------|----------|---------------------|------------|
| `Dota2/App_Start/WebApiConfig.cs` | 1 | `using System.Web.Http` | Delete file entirely | #17 |
| `Dota2/App_Start/WebApiConfig.cs` | 7 | `HttpConfiguration config` | `WebApplication` / `IEndpointRouteBuilder` | #17 |
| `Dota2/App_Start/WebApiConfig.cs` | 9 | `config.EnableCors()` | `builder.Services.AddCors()` + `app.UseCors()` | #19 |
| `Dota2/Controllers/DotaBuffController.cs` | 7–8 | `using System.Web.Http`, `using System.Web.Http.Cors` | `using Microsoft.AspNetCore.Mvc` | #19 |
| `Dota2/Controllers/DotaBuffController.cs` | 13 | `[EnableCors("*","*","*")]` | `[EnableCors("PolicyName")]` with named Core CORS policy | #19 |
| `Dota2/Controllers/DotaBuffController.cs` | 15 | `ApiController` base class | `ControllerBase` | #19 |
| `Dota2/Controllers/DotaBuffController.cs` | 19 | `Task<HttpResponseMessage>` return type | `Task<IActionResult>` | #19 |
| `Dota2/Controllers/DotaBuffController.cs` | 21 | `new HttpResponseMessage()` | `return Ok(content)` | #19 |

---

### 3. `System.Web.Optimization` — Bundling

| File | Line | API Used | .NET 10 Replacement | Tracked In |
|------|------|----------|---------------------|------------|
| `Dota2/App_Start/BundleConfig.cs` | 1 | `using System.Web.Optimization` | Delete file entirely | #22 |
| `Dota2/App_Start/BundleConfig.cs` | 8 | `BundleCollection bundles` | `WebOptimizer` or direct `<script>`/`<link>` tags | #22 |
| `Dota2/App_Start/BundleConfig.cs` | 10–35 | `ScriptBundle`, `StyleBundle`, `bundles.Add(...)` | Define in `WebOptimizer` pipeline or remove | #22 |

---

### 4. `System.Web.Hosting.HostingEnvironment` — Path resolution

| File | Line | API Used | .NET 10 Replacement | Tracked In |
|------|------|----------|---------------------|------------|
| `WebApiRepository/Implementations/DotaBuffParser/DotaBuffParser.cs` | 6 | `using System.Web.Hosting` | Remove | #15 |
| `WebApiRepository/Implementations/DotaBuffParser/DotaBuffParser.cs` | 34 | `HostingEnvironment.MapPath("~/")` | Inject `IWebHostEnvironment`; use `env.ContentRootPath` | #15 |
| `DotaBuffWrapper/Controller/JsonController.cs` | 3 | `using System.Web.Hosting` | Remove | #15 |
| `DotaBuffWrapper/Controller/JsonController.cs` | 14 | `HostingEnvironment.MapPath("~/")` | `IWebHostEnvironment.ContentRootPath` or `AppContext.BaseDirectory` | #15 |
| `DotaBuffWrapper/Controller/VersionController.cs` | 7 | `using System.Web.Hosting` | Remove | #15 |

---

### 5. Windows backslash path separators

Breaks on Linux/macOS. All in `DotaBuffWrapper` and `WebApiRepository`.

| File | Lines | Pattern | .NET 10 Replacement | Tracked In |
|------|-------|---------|---------------------|------------|
| `DotaBuffWrapper/Controller/VersionController.cs` | 131–136 | `string.Format(@"Mapping\{0}\{1}\Enums.json", ...)` | `Path.Combine("Mapping", source, version, "Enums.json")` | #15 |
| `WebApiRepository/Implementations/DotaBuffParser/DotaBuffParser.cs` | 32 | `string.Format(@"Mapping\{0}\{1}\Enums.json", ...)` | `Path.Combine("Mapping", source, version, "Enums.json")` | #15 |

---

### 6. `System.Web` — `HttpUtility`

| File | Line | API Used | .NET 10 Replacement | Tracked In |
|------|------|----------|---------------------|------------|
| `DotaBuffWrapper/Controller/QueryStringController.cs` | 6 | `using System.Web` | Remove | #15 |
| `DotaBuffWrapper/Controller/QueryStringController.cs` | 69 | `HttpUtility.UrlEncode(key/value)` | `Uri.EscapeDataString(...)` or `System.Net.WebUtility.UrlEncode(...)` | #15 |

> Note: `System.Net.WebUtility` is available in .NET 10 with no package; `Uri.EscapeDataString` is stricter (RFC 3986). Use `WebUtility.UrlEncode` for a drop-in replacement.

---

### 7. `System.Configuration.ConfigurationManager`

| File | Line | API Used | .NET 10 Replacement | Tracked In |
|------|------|----------|---------------------|------------|
| `WebApiRepository/Implementations/ApiRequests/Dota2Results.cs` | 3 | `using System.Configuration` | Remove | #21 |
| `WebApiRepository/Implementations/ApiRequests/Dota2Results.cs` | 19 | `ConfigurationManager.AppSettings["steamApi"]` | Inject `IConfiguration`; read `_config["steamApi"]` | #21 |
| `Dota2Import/ImageConverting.cs` | 2 | `using System.Configuration` | Remove | #21 |
| `Dota2Import/ImageConverting.cs` | 16–18 | `ConfigurationManager.AppSettings["cloudname/apikey/apisecret"]` | Inject `IConfiguration` or `IOptions<CloudinaryOptions>` | #21 |

---

### 8. `System.Data.Entity` — Entity Framework 6

| File | Notes | .NET 10 Replacement | Tracked In |
|------|-------|---------------------|------------|
| `WebApiRepository/ApplicationContext.cs` | EF6 `DbContext`, constructor with connection name string | EF Core `DbContext` + `DbContextOptions<T>` via DI | #8 |
| `WebApiRepository/Repository/GenericRepository.cs` | `using System.Data.Entity` for `DbSet`, `EntityState` | `using Microsoft.EntityFrameworkCore` | #8 |
| `Dota2ApiWrapper/ApiHandler.cs` | `using System.Data.Entity.Infrastructure` — **unused import** | Remove the `using` statement | #11 |
| `Dota2Import/ImageConverting.cs` | `using System.Data.Entity` — appears unused in context | Remove if unused | #23 |
| `Dota2Import/Program.cs` | `Database.SetInitializer<ApplicationContext>(null)` | Remove entirely (EF6-only API) | #23 |
| `WebApiRepository/Migrations/*.cs` (all 5 + designers) | `System.Data.Entity.Migrations` | **Delete entire `Migrations/` folder**; create fresh EF Core migration | #8 |

---

### 9. `System.Drawing` / GDI+ — Image processing

| File | Line | API Used | .NET 10 Replacement | Tracked In |
|------|------|----------|---------------------|------------|
| `Dota2Import/ImageConverting.cs` | 4–5 | `using System.Drawing`, `using System.Drawing.Imaging` | Remove | #30 |
| `Dota2Import/ImageConverting.cs` | (body) | `Image.FromStream(...)`, `img.Save(..., ImageFormat.Png)` | `SixLabors.ImageSharp.Image.Load(...)` + `.SaveAsPngAsync(...)` | #30 |

> **Linux note:** `System.Drawing.Common` throws `PlatformNotSupportedException` on Linux in .NET 6+ by default. ImageSharp is fully cross-platform.

---

### 10. `WebClient` — Obsolete HTTP client

`WebClient` is marked obsolete as of .NET 5 and does not support `async`/`await` or `IHttpClientFactory`. All usages must be replaced with `HttpClient` (injected via `IHttpClientFactory`).

| File | Occurrences | .NET 10 Replacement | Tracked In |
|------|-------------|---------------------|------------|
| `Dota2/Controllers/DotaBuffController.cs` | 1 | `HttpClient` injected via constructor | #16 |
| `DotaBuffWrapper/Controller/HtmlDocumentController.cs` | 4 | Inject `HttpClient`; `await httpClient.GetStreamAsync(url)` | #16 |
| `DotaBuffWrapper/Controller/VersionController.cs` | 1 | `await httpClient.GetStringAsync(url)` | #16 |
| `DotaBuffWrapper/Controller/HealthCheck.cs` | 1 | Via `HtmlDocumentController` (fixed by #16) | #16 |
| `DotaBuffWrapper/Controller/Dotabuff/HeroController.cs` | 1 | Via `HtmlDocumentController` (fixed by #16) | #16 |
| `DotaBuffWrapper/Controller/Dotabuff/PlayerController.cs` | 1 | Via `HtmlDocumentController` (fixed by #16) | #16 |
| `DotaBuffWrapper/Controller/Dotabuff/ItemController.cs` | 1 | Via `HtmlDocumentController` (fixed by #16) | #16 |
| `DotaBuffWrapper/Controller/Dotabuff/FriendController.cs` | 1 | Via `HtmlDocumentController` (fixed by #16) | #16 |

> The root is `HtmlDocumentController.CreateWebclient()` — fixing that method to use `HttpClient` resolves the majority of downstream usages automatically.

---

### 11. `HtmlExtension.cs` — MVC 5-specific helpers

| File | Line | API Used | .NET 10 Replacement | Tracked In |
|------|------|----------|---------------------|------------|
| `Dota2/Extensions/HtmlExtension.cs` | 4–7 | `using System.Web`, `.Mvc`, `.Mvc.Ajax`, `.Routing` | Remove all four `using` statements | #20 |
| `Dota2/Extensions/HtmlExtension.cs` | 20 | `MvcHtmlString Image(this HtmlHelper html, ...)` | `IHtmlContent Image(this IHtmlHelper html, ...)` or remove (blob images dropped in migration 2) | #20 |
| `Dota2/Extensions/HtmlExtension.cs` | 23 | `new MvcHtmlString(...)` | `new HtmlString(...)` (`Microsoft.AspNetCore.Html`) | #20 |
| `Dota2/Extensions/HtmlExtension.cs` | 26 | `IsActive(this HtmlHelper html, ...)` | `IsActive(this IHtmlHelper html, ...)`; remove `IsChildAction` check | #20 |
| `Dota2/Extensions/HtmlExtension.cs` | 31 | `viewContext.Controller.ControllerContext.IsChildAction` | **Removed in ASP.NET Core** — child actions don't exist; simplify method to only check route data | #20 |
| `Dota2/Extensions/HtmlExtension.cs` | 54–63 | `MyActionLink(this AjaxHelper ajaxHelper, ..., AjaxOptions)` | **`AjaxHelper` removed in ASP.NET Core** — replace usages with `<a>` tag + jQuery AJAX `data-` attributes | #20 |
| `Dota2/Extensions/HtmlExtension.cs` | 66–81 | `GenerateLink(this AjaxHelper, ...)` — private helper | Remove along with `MyActionLink` | #20 |

---

### 12. Razor Views — `System.Web.Optimization` helpers and `@Html.Partial`

| File | Line | API Used | .NET 10 Replacement | Tracked In |
|------|------|----------|---------------------|------------|
| `Dota2/Views/Shared/_Layout.cshtml` | 172–174 | `@Scripts.Render(...)` (3 bundle calls) | `<script src="~/js/...">` direct tags | #22 |
| `Dota2/Views/Shared/_DesignLayout.cshtml` | 265–309 | `@Scripts.Render(...)` (17 calls) | `<script src="~/js/...">` direct tags | #22 |
| `Dota2/Views/Heroes/Index.cshtml` | 7 | `@Html.Partial("Partials/HeroesPartial")` | `<partial name="Partials/HeroesPartial" />` | #20 |
| `Dota2/Views/Stats/Index.cshtml` | 8 | `@Html.Partial("Partials/StatsPartial")` | `<partial name="Partials/StatsPartial" />` | #20 |

> Also required: delete `Views/Web.config` (MVC 5-specific); add `Views/_ViewImports.cshtml` with `@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers`.

---

### 13. `Encoding.Default` — Platform-dependent encoding

| File | Line | API Used | .NET 10 Replacement | Tracked In |
|------|------|----------|---------------------|------------|
| `Dota2/Helpers/Gravatar.cs` | 12 | `Encoding.Default.GetBytes(email)` | `Encoding.UTF8.GetBytes(email)` | #18 |

> `Encoding.Default` is Windows-1252 on Windows and UTF-8 on Linux — this silently produces different Gravatar hashes cross-platform. Replace with `Encoding.UTF8`.

---

## Files to Delete Entirely

These files have no purpose in ASP.NET Core and should be deleted as part of the migration:

| File | Reason |
|------|--------|
| `Dota2/Global.asax` + `Global.asax.cs` | Replaced by `Program.cs` |
| `Dota2/App_Start/RouteConfig.cs` | Routes moved to `Program.cs` |
| `Dota2/App_Start/FilterConfig.cs` | `UseExceptionHandler` middleware replaces it |
| `Dota2/App_Start/WebApiConfig.cs` | Web API 2 unified into Core MVC |
| `Dota2/App_Start/BundleConfig.cs` | `System.Web.Optimization` removed |
| `Dota2/App_Start/UnityConfig.cs` | Unity replaced by built-in DI |
| `Dota2/Views/Web.config` | MVC 5 Razor view config; replaced by `_ViewImports.cshtml` |
| `WebApiRepository/Migrations/*.cs` (all) | EF6 migrations; replaced by new EF Core migration |
| All `packages.config` files (7) | Replaced by `<PackageReference>` in SDK-style `.csproj` |
| `DotabuffWrapper/` (entire directory) | Dead code — deprecated v0.1.0.0 scraper (see issue #5) |

---

## Files to Add

| File | Purpose |
|------|---------|
| `Dota2/Program.cs` | ASP.NET Core entry point (replaces Global.asax + App_Start/) |
| `Dota2/appsettings.json` | Configuration (replaces Web.config app settings) |
| `Dota2/appsettings.Development.json` | Local dev overrides (add to .gitignore) |
| `Dota2/Views/_ViewImports.cshtml` | Tag helper registration (replaces Views/Web.config) |
| `Directory.Build.props` | Shared MSBuild settings |
| `Directory.Packages.props` | Central NuGet version management |
| `WebApiRepository/Migrations/InitialCreate.cs` | Fresh EF Core migration |
| `.github/workflows/ci.yml` | GitHub Actions CI pipeline |
