#load "tools/includes.fsx"
open IntelliFactory.Build

let bt =
    BuildTool().PackageId("WebSharper.AspNetMvc")
        .VersionFrom("WebSharper")

let main =
    bt.WebSharper.Library("WebSharper.AspNetMvc")
        .SourcesFromProject()
        .References(fun r ->
            [
                r.Assembly("System.Web")
                r.Assembly("System.ComponentModel.DataAnnotations")
                r.NuGet("Microsoft.AspNet.Mvc").Version("4.0.30506.0").Reference()
            ])

bt.Solution [
    main

    bt.NuGet.CreatePackage()
        .Configure(fun c ->
            { c with
                Title = Some "WebSharper.AspNetMvc"
                LicenseUrl = Some "http://websharper.com/licensing"
                ProjectUrl = Some "https://github.com/intellifactory/websharper.aspnetmvc"
                Description = "WebSharper module for ASP.NET MVC 4"
                RequiresLicenseAcceptance = true })
        .Add(main)
]
|> bt.Dispatch
