# Angular Series

Parts 7 to 15 of the Code Maze .NET Core Web Development series, the Angular client for the
`AccountOwner` API, one folder per article in reading order. Each folder is the previous folder
plus that article's work, so a reader can start anywhere and diff forward.

| # | Folder | Article |
|---|---|---|
| 1 | [`AngularProjectSetup`](AngularProjectSetup) | Angular Components and Project Setup |
| 2 | [`AngularRoutingAndNavigation`](AngularRoutingAndNavigation) | Angular Routing and Navigation Menu |
| 3 | [`AngularHttpClientAndServices`](AngularHttpClientAndServices) | Angular HttpClient and Environment Files |
| 4 | [`LazyLoading`](LazyLoading) | Angular Lazy Loading: Load Routes on Demand |
| 5 | [`ErrorHandling`](ErrorHandling) | Angular Error Handling: HTTP Errors and Error Pages |
| 6 | [`InputsAndOutputs`](InputsAndOutputs) | Angular @Input and @Output Decorators and Directives |
| 7 | [`FormValidationAndPostRequests`](FormValidationAndPostRequests) | Angular Reactive Form Validation and POST Requests |
| 8 | [`PutRequests`](PutRequests) | Angular PUT Request to an ASP.NET Core Web API |
| 9 | [`DeleteRequests`](DeleteRequests) | Angular DELETE Request to an ASP.NET Core Web API |

`DeleteRequests` is the series' final state: it is the only folder that carries all five owner
screens (list, details, create, update, delete).

## Versions

Every folder is the same Angular 22 workspace, and every folder commits its `package-lock.json`.

| | Version |
|---|---|
| Node | 24 |
| Angular | 22.1.5 |
| Angular CLI | 22.1.7 |
| TypeScript | 6.0.3 |
| RxJS | 7.8.2 |
| ngx-bootstrap | 22.0.0 |
| Bootstrap | 5.3.8 |

Strict mode is on. TypeScript 6 enables `strict` by its own default, so a workspace the current
CLI generates carries no `"strict": true` line and is strict all the same, `strictTemplates`
included.

## Running one part on its own

```bash
cd DeleteRequests      # or any other folder
npm ci
npm start              # ng serve on http://localhost:4200
```

`npm run build` produces a production build in `dist/`. Nothing is shared between folders: each
one installs, builds and serves independently.

## The back end

Parts 4 to 9 of this list call the Web API from the Basic Web API series. Run
[`aspnetcore-webapi/BasicWebApiSeries/UsingRepositoryForWriteRequests`](../../aspnetcore-webapi/BasicWebApiSeries/UsingRepositoryForWriteRequests),
which holds the GET, POST, PUT and DELETE actions this client sends:

```bash
cd ../../aspnetcore-webapi/BasicWebApiSeries/UsingRepositoryForWriteRequests/AccountOwnerServer
dotnet run --launch-profile http
```

**Use the `http` profile.** It listens on `http://localhost:5000`, which is the address
`src/environments/environment.development.ts` carries. `Program.cs` calls `UseHttpsRedirection()`
unconditionally, so under the `https` profile a call to port 5000 can be redirected to
`https://localhost:5001` and the browser meets a development certificate the client was never
told about. CORS needs nothing: the API allows any origin, so `http://localhost:4200` works as
generated.

Create the database first. `aspnetcore-webapi/BasicWebApiSeries/Database/init.sql` creates
`AccountOwner`, both tables and the sample data; `Database/README.md` has the LocalDB and
container commands.

## Environments

From `AngularHttpClientAndServices` onward each folder carries `src/environments/environment.ts`
with the production address and `src/environments/environment.development.ts` with
`http://localhost:5000`. `angular.json` replaces the base file with the development one under the
`development` configuration, which is what `ng serve` uses. A bare `ng build` is a production
build and reads the base file untouched.

## One thing to know before you delete an owner

`DeleteOwner` refuses to delete an owner that still has accounts and answers `400 Bad Request`
with the reason. Every owner in `init.sql` has at least one account, so the delete screen's
success path is reachable only on an owner created through the create screen from part 13.
