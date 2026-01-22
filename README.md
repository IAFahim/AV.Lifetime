# AV.Lifetime

Target context and lifetime management system for Unity with lazy caching and Data-Oriented Design architecture.

## Features

- **Target Context System**: Centralized transform references for game events
- **ETarget Enum**: Type-safe targeting (Self, Owner, Source, Target, Custom0, Custom1)
- **Lazy Caching**: Efficient component resolution with automatic cache invalidation
- **DOD Architecture**: Static logic classes with in/out parameters
- **Burst Compatible**: Designed for high-performance systems

## Installation

Install via Unity Package Manager or add to `Packages/manifest.json`:

```json
{
  "dependencies": {
    "com.av.lifetime": "1.0.0"
  }
}
```

## Usage

### Target Context

```csharp
// Define target context on a central manager
public class TargetContext : MonoBehaviour
{
    public Transform Owner;
    public Transform Source;
    public Transform Target;
    public Transform Custom0;
    public Transform Custom1;
}
```

### Resolve Targets

```csharp
using AV.Lifetime.Realtime;

// Get transform for a target type
TargetLogic.TryGetTransform(transform, targetContext, ETarget.Source, out var sourceTransform);

// Resolve component from target with caching
TargetLogic.TryResolveGroup(
    transform,
    ref targetCacheGroup,
    targetContext,
    ETarget.Target,
    out IRpgStatsMap statsMap
);
```

### TargetContextBehaviour

```csharp
// Base component that provides target context
public class TargetContextBehaviour : MonoBehaviour
{
    public TargetContext targetContext;
}
```

## API

### TargetLogic

Static class for target resolution:

- `TryGetTransform()` - Get transform by ETarget enum
- `TryResolveGroup()` - Resolve component with lazy caching
- `TryLazyResolveComponent()` - Extension method for LazyCache

### ETarget Enum

- `Self` - The transform itself
- `Owner` - The owning object
- `Source` - The object that triggered an event
- `Target` - The target of an action
- `Custom0` - User-defined slot 0
- `Custom1` - User-defined slot 1

## Code Quality

This package follows strict naming guidelines from AGENTS.md:
- ✅ **No abbreviations**: `TargetContextBehaviour` (not `InitializeMono`)
- ✅ **Descriptive names**: `targetContext` (not `ctx` or `tc`)
- ✅ **Pronounceable**: All class and variable names read naturally
- ✅ **Clear intent**: Names describe exactly what they represent
- ✅ **Full words**: `TryResolveGroup` (not `TryResGrp`)

**Class Rename**: `InitializeMono` → `TargetContextBehaviour`
- Old name used "Mono" abbreviation for MonoBehaviour
- New name clearly indicates it's a behaviour that provides target context

## License

MIT License - see [LICENSE.md](LICENSE.md)

## Author

IAFahim - [iafahim.dev@gmail.com](mailto:iafahim.dev@gmail.com)
