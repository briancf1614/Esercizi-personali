# EsercizioPrincipioS

ASP.NET Core Web API (.NET 10) demo del **Single Responsibility Principle** (Strategy Pattern) para cancelación de suscripciones con penalidades según el plan.

## Endpoint

```
POST /api/Cancelacion   Body: Suscripcion JSON   →   ResultadoCancelacion JSON
```

## Build & Run

```bash
dotnet run
```
Servidor en `http://localhost:5286` (perfil `https` por defecto en `Properties/launchSettings.json`).  
Swagger UI en `/swagger` solo en Development.

## Arquitectura

- `Controllers/CancelacionController.cs` — único endpoint HTTP
- `Business/Services/CancelacionService.cs` — orquestación (define `ICancelacionService` en el mismo archivo)
- `Business/Services/EmailNotificacionService.cs` — notificación simulada (solo `Console.WriteLine`)
- `Business/Strategies/` — 3 implementaciones de `ICalculadorPenalidadStrategy` inyectadas como `IEnumerable<T>`:
  - `PenalidadPlanBasico` → penalidad $0 (plan `Basico`)
  - `PenalidadPlanPro` → 20% del costo mensual (plan `Pro`)
  - `PenalidadPlanEnterprise` → $150 flat (plan `Enterprise`)
- `Domain/` — modelos (`Suscripcion`, `Usuario`, `ResultadoCancelacion`), enum `TipoPlan`, interfaces

## Convenciones

- `_camelCase` para campos privados, `PascalCase` para públicos, prefijo `I` para interfaces
- Identificadores y comentarios en español/italiano (no traducir)
- Sin base de datos, sin tests, sin linters configurados
- `EsercizioPrincipioS.http` tiene un endpoint `weatherforecast` de template que **no funciona** — ignorar
