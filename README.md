# charp_cnita

# Question de compréhension

1. À quoi sert une solution .sln ?
   (https://learn.microsoft.com/fr-fr/visualstudio/extensibility/internals/solution-dot-sln-file?view=vs-2022)

- Le .sln est un fichier qui contient des informations textuelles que l’environnement utilise pour rechercher et charger
  les paramètres pour les données persistantes et le projet qu’il référence.

2. À quoi sert un projet .csproj ? (https://filext.com/fr/extension-de-fichier/CSPROJ)

- Un fichier CSPROJ est un projet d'application C# créé avec un environnement de développement
- Il ne contient pas de code source C# réel,
- il contient des données encodées XML telles que le schéma de données, les paramètres, les références au code source et
  d'autres informations requises pour compiler un C# dans un exécutable Windows.

3. Quelle commande permet de lancer un projet précis ?

- dotnet run --project

4. Pourquoi utilise-t-on une classe OutdoorEvent plutôt que plusieurs variables séparées comme
   eventName1, eventDate1, eventLocation1 ?

- Pour une structuration plus propre, au sein d'une même classe

5. Expliquez avec vos mots la différence entre : string Name | string? Description

- String sans le ?, défini que c'est un string obligatoire, pas nullable, contrairement a Description, ou il dois être a
  string mais il est nullable

6. Quel est l’avantage d’une List<OutdoorEvent> par rapport à plusieurs variables
   indépendantes ?
- Que toute les variables sont stocké dans une liste, qu'on peut boucler donc moins de code, et plus maintenanable car il est stocké dans une liste