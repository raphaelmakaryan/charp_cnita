<a name="readme-top"></a>

![GitHub contributors](https://img.shields.io/github/contributors/raphaelmakaryan/charp_cnita?color=0d0&style=for-the-badge)
![GitHub release](https://img.shields.io/github/v/release/raphaelmakaryan/charp_cnita?style=for-the-badge)
![GitHub watchers](https://img.shields.io/github/watchers/raphaelmakaryan/charp_cnita?style=for-the-badge)
![GitHub Repo stars](https://img.shields.io/github/stars/raphaelmakaryan/charp_cnita?color=%23fa0&style=for-the-badge)
![GitHub issues](https://img.shields.io/github/issues/raphaelmakaryan/charp_cnita?style=for-the-badge)


<br />
<div align="center">

<h3 align="center">OutdoorNotebook</h3>

  <p align="center">
    Bienvenue sur le projet : OutdoorNotebook !
    <br>
Vous lisez actuellement la documentation, bonne lecture:)
  </p>
</div>

<details>
  <summary>Tables des matieres :</summary>
  <ol>
    <li>
      <a href="#le-projet">Le projet</a>
      <a href="#prerequis">Prérequis</a>
        <a href="#prerequis">Installation</a>
        <a href="#prerequis">Compilation</a>
        <a href="#prerequis">Tests</a>
        <a href="#prerequis">Console</a>
        <a href="#prerequis">API</a>
        <a href="#prerequis">Exemples</a>
        <a href="#prerequis">Structures</a>
    </li>
  </ol>
</details>

<br>

---
<br>


# Le projet

<br>

OutdoorNotebook est un petit outil pour une association locale : Les Amis de l’Outdoor.

L’association organise des sorties : randonnée, vélo, trail, ski de fond, etc.

Elle veut un premier outil très simple pour suivre :
- le nom des sorties,
- leur date,
- leur lieu,
- leur nombre de places,
- les participants inscrits,
- éventuellement une courte description.

<p align="right">(<a href="#readme-top">Revenir en haut</a>)</p>

# Prérequis

<br>

Pour utiliser OutdoorNotebook, vous devrez avoir .NET installé sur votre machine.

<br>

<p align="right">(<a href="#readme-top">Revenir en haut</a>)</p>

# Installation

<br>

Pour installer OutdoorNotebook, vous devrez téléchargez le code ou faites un clone Git :

```bash
git clone https://github.com/raphaelmakaryan/charp_cnita.git
```

Un dossier ainsi que tout le projet seras affiché sur votre machine.

<br>

<p align="right">(<a href="#readme-top">Revenir en haut</a>)</p>

# Compilation

<br>

Pour compiler OutdoorNotebook, vous devrez faire cet commande :

```bash
dotnet build
```

OutdoorNotebook se généreras.

<br>

<p align="right">(<a href="#readme-top">Revenir en haut</a>)</p>

# Tests

<br>

Pour lancer les tests de OutdoorNotebook, vous devrez faire cet commande :

```bash
dotnet test
```

Lest test de OutdoorNotebook se lanceras.

<br>

<p align="right">(<a href="#readme-top">Revenir en haut</a>)</p>


# Console

<br>

Pour lancer la console OutdoorNotebook, vous devrez faire cet commande :

```bash
dotnet run --project OutdoorNotebook.Console
```

OutdoorNotebook se lanceras avec une liste d'evenements préconfigurés.

<br>

<p align="right">(<a href="#readme-top">Revenir en haut</a>)</p>

# API

<br>

Pour lancer l'API de OutdoorNotebook, vous devrez faire cet commande :

```bash
dotnet run --project OutdoorNotebook.Api
```

Un serveur se lanceras avec une URL prédéfini dans votre console.

Il y'a 3 routes actuellements disponible : 
- /
- /events
- /events/upcoming

<br>

<p align="right">(<a href="#readme-top">Revenir en haut</a>)</p>


# Exemples

<br>

En quelque images, voici l'utilisation de OutdoorNotebook :

<img src="./github/1.png">
<img src="./github/2.png">

<br>

<p align="right">(<a href="#readme-top">Revenir en haut</a>)</p>

# Structure

<br>

Voici comment est structurer OutdoorNotebook : 

``
├── data/
│   └── events.json
├── OutdoorNotebook.Console/
│   ├── Exercices/
│   │   ├── Exercice1
│   │   ├── Exercice2
│   │   └── Exercice3
│   └── Program.cs
├── OutdoorNotebook.Core/
│   ├── bin/
│   │   └── Debug/
│   │       └── net10.0/
│   │           ├── OutdoorNotebook.Core.deps.json
│   │           ├── OutdoorNotebook.Core.dll
│   │           └── OutdoorNotebook.Core.pdb
│   ├── obj/
│   │   ├── Debug/
│   │   │   └── net10.0/
│   │   │       ├── ref/
│   │   │       │   └── OutdoorNotebook.Core.dll
│   │   │       ├── refint/
│   │   │       │   └── OutdoorNotebook.Core.dll
│   │   │       ├── .NETCoreApp,Version=v10.0.AssemblyAttributes.cs
│   │   │       ├── OutdoorNotebook.Core.AssemblyInfo.cs
│   │   │       ├── OutdoorNotebook.Core.AssemblyInfoInputs.cache
│   │   │       ├── OutdoorNotebook.Core.assets.cache
│   │   │       ├── OutdoorNotebook.Core.csproj.CoreCompileInputs.cache
│   │   │       ├── OutdoorNotebook.Core.csproj.FileListAbsolute.txt
│   │   │       ├── OutdoorNotebook.Core.dll
│   │   │       ├── OutdoorNotebook.Core.GeneratedMSBuildEditorConfig.editorconfig
│   │   │       ├── OutdoorNotebook.Core.GlobalUsings.g.cs
│   │   │       ├── OutdoorNotebook.Core.pdb
│   │   │       └── OutdoorNotebook.Core.sourcelink.json
│   │   ├── OutdoorNotebook.Core.csproj.nuget.dgspec.json
│   │   ├── OutdoorNotebook.Core.csproj.nuget.g.props
│   │   ├── OutdoorNotebook.Core.csproj.nuget.g.targets
│   │   ├── project.assets.json
│   │   ├── project.nuget.cache
│   │   ├── project.packagespec.json
│   │   ├── rider.project.model.nuget.info
│   │   └── rider.project.restore.info
│   ├── EventService.cs
│   ├── EventStorageService.cs
│   ├── OutdoorEvents.cs
│   ├── OutdoorNotebook.Core.csproj
│   └── Tools.cs
├── OutdoorNotebook.Tests/
│   ├── bin/
│   │   └── Debug/
│   │       └── net10.0/
│   │           ├── cs/
│   │           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│   │           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│   │           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│   │           ├── de/
│   │           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│   │           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│   │           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│   │           ├── es/
│   │           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│   │           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│   │           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│   │           ├── fr/
│   │           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│   │           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│   │           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│   │           ├── it/
│   │           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│   │           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│   │           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│   │           ├── ja/
│   │           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│   │           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│   │           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│   │           ├── ko/
│   │           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│   │           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│   │           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│   │           ├── pl/
│   │           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│   │           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│   │           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│   │           ├── pt-BR/
│   │           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│   │           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│   │           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│   │           ├── ru/
│   │           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│   │           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│   │           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│   │           ├── tr/
│   │           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│   │           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│   │           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│   │           ├── zh-Hans/
│   │           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│   │           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│   │           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│   │           ├── zh-Hant/
│   │           │   ├── Microsoft.TestPlatform.CommunicationUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CoreUtilities.resources.dll
│   │           │   ├── Microsoft.TestPlatform.CrossPlatEngine.resources.dll
│   │           │   ├── Microsoft.VisualStudio.TestPlatform.Common.resources.dll
│   │           │   └── Microsoft.VisualStudio.TestPlatform.ObjectModel.resources.dll
│   │           ├── .msCoverageSourceRootsMapping_OutdoorNotebook.Tests
│   │           ├── CoverletSourceRootsMapping_OutdoorNotebook.Tests
│   │           ├── Microsoft.TestPlatform.CommunicationUtilities.dll
│   │           ├── Microsoft.TestPlatform.CoreUtilities.dll
│   │           ├── Microsoft.TestPlatform.CrossPlatEngine.dll
│   │           ├── Microsoft.TestPlatform.PlatformAbstractions.dll
│   │           ├── Microsoft.TestPlatform.Utilities.dll
│   │           ├── Microsoft.VisualStudio.CodeCoverage.Shim.dll
│   │           ├── Microsoft.VisualStudio.TestPlatform.Common.dll
│   │           ├── Microsoft.VisualStudio.TestPlatform.ObjectModel.dll
│   │           ├── Newtonsoft.Json.dll
│   │           ├── OutdoorNotebook.Core.dll
│   │           ├── OutdoorNotebook.Core.pdb
│   │           ├── OutdoorNotebook.Tests.deps.json
│   │           ├── OutdoorNotebook.Tests.dll
│   │           ├── OutdoorNotebook.Tests.pdb
│   │           ├── OutdoorNotebook.Tests.runtimeconfig.json
│   │           ├── testhost.dll
│   │           ├── xunit.abstractions.dll
│   │           ├── xunit.assert.dll
│   │           ├── xunit.core.dll
│   │           ├── xunit.execution.dotnet.dll
│   │           └── xunit.runner.visualstudio.testadapter.dll
│   ├── OutdoorNotebook.Tests.csproj
│   └── OutdoorNoteBookTests.cs
├── OutdoorNotebook.slnx
└── README.md
``



<br>

<p align="right">(<a href="#readme-top">Revenir en haut</a>)</p>