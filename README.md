# AV.Lifetime

![Header](documentation_header.svg)

[![Unity](https://img.shields.io/badge/Unity-2022.3%2B-000000.svg?style=flat-square&logo=unity)](https://unity.com)
[![License](https://img.shields.io/badge/License-MIT-blue.svg?style=flat-square)](LICENSE.md)

Targeting context system with efficient lazy caching.

## ✨ Features

- **Target Context**: Centralized references for `Owner`, `Source`, `Target`, and Custom slots.
- **Lazy Resolution**: `TargetLogic` resolves components from targets only when needed.
- **Caching**: Minimizes `GetComponent` calls using `LazyCache`.

## 📦 Installation

Install via Unity Package Manager (git URL).

### Dependencies
- **AV.Unity.Extend**

## 🚀 Usage

```csharp
// 1. Define Context
var context = new TargetContext { Owner = transform, Target = enemy };

// 2. Resolve Component from Target (Cached)
if (TargetLogic.TryResolveGroup(transform, ref cache, context, ETarget.Target, out Health health))
{
    health.TakeDamage(10);
}
```

## ⚠️ Status

- 🧪 **Tests**: Missing.
- 📘 **Samples**: None.
