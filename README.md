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

7. Expliquer oralement :
   1. Qu’est-ce qu’une classe ?
      - Une classe est une structuration essentiellement en POO, qui regroupe des methodes et des attributs
   2. Qu’est-ce qu’une propriété ?
      - Une propriété c'est une variable d'une class
   3. Qu’est-ce qu’une méthode ?
      - Une méthode c'est une fonction interne a une class 
   4. Pourquoi C# demande-t-il des types explicites ?
      - Comme a la java, pour l'optimisation, des types défini evite d'avir des erreur d'execution, etcc  
   5. À quoi sert string? ?
      - Il sert a avoir un string au contenu nullable, pas obligatoire
   6. À quoi sert LINQ ?
      - LINQ permet de faire des requetes sur des variables, comme en sql
   7. Que contient le fichier .csproj ?
      - Il contient le type de sortie, la version du dotnet, etc..


8. Pourquoi déplacer OutdoorEvent hors du projet console ?
- Pour séparé la console de la logique métier ?

9. Quelle partie du code serait réutilisable si demain on remplaçait la console par une API web
- Les données, donc la collection ainsi que les fonctions

10. Mes choix :
- avez-vous utilisé un constructeur ?
  - oui
- avez-vous utilisé des valeurs par défaut?
  - pas dans la class mais une fonction qui le fais
- où avez-vous mis la logique IsFull() ?
  - oui