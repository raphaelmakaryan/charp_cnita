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

- Que toute les variables sont stocké dans une liste, qu'on peut boucler donc moins de code, et plus maintenanable car
  il est stocké dans une liste

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

11. Pourquoi tester la validation est-il plus intéressant que de tester simplement un affichage console
    ?

- Car il permet d'être sûr que ce qu'on souhaitait faire est conforme, afin de ne pas avoir de surprise tout au long du
  projet

12. Expliquer :
    1. Pourquoi séparer console et cœur métier ?
        - Afin de separer la logique et l'affichage, avoir une structure clair et propre
    2. Qu’est-ce qu’un service métier ?
        - Le service métier est la ou toute la logique passe
    3. Pourquoi le service ne doit-il pas écrire dans la console ?
        - Car on part du principe que le service s'occupe seulement de la logique, afin de laisser la console d'ecrire
          lui
    4. Qu’est-ce qu’un test unitaire ?
        - c'est un test qui vise a tester une fonction, une méthode précise isolé du reste
    5. Qu’est-ce que la structure Arrange / Act / Assert?
        - Arrange : récupération des données, Act : logique et condition, Assert : vérification
    6. Qu’avez-vous trouvé difficile dans l’écriture des tests ?
        - La mise en place et les questions posé pas clairement


13. Quelle différence faites-vous entre : dotnet run --project OutdoorNotebook.Console | dotnet run --project
    OutdoorNotebook.Api ?

- La console, c'est l'application en elle même, tandis que l'api, c'est le lancement d'un serveur


14. Qu’avez-vous compris de spécifique à C# et .NET que vous ne voyiez pas forcément
    dans les autres langages ?

- Ce qui est spécifique à C# et .NET, il y'a LINQ, de faire des requêtes directement dans le code C#


15. Expliquez avec vos mots la différence entre : List<OutdoorEvent> | Task<List<OutdoorEvent>>

- List<OutdoorEvent> c'est une liste d'outdoorEvent qui synchrone, tandis que Task<List<OutdoorEvent>> c'est une tâche
  qui va retourner une liste d'outdoorEvent, donc asynchrone

16. Pourquoi `SaveEventsAsync` retourne-t-elle : Task et non : Task<List<OutdoorEvent>>

- Car elle ne retourne rien, elle sauvegarde juste les données

17. Pourquoi cette ligne ne donne-t-elle pas directement une liste ? var events = storage.LoadEventsAsync("
    data/events.json");

- Parce que l'appel de la fonction ne comporte pas le await, donc elle retourne une tâche, et non la liste directement

18. Pourquoi le test lui-même est-il marqué avec `async Task`?

- Car il utiliser des fonctions asynchrone, et pour pouvoir utiliser le await, il faut que la fonction soit async, et
  retourne une tâche

19. Si chaque météo prend environ une seconde, combien de temps prendra le programme pour 5
    sorties ?

- 5 secondes, car les appels sont fait de manière synchrone, donc il attend la réponse de chaque appel avant de faire le
  suivant

20. Pourquoi la version avec `Task.WhenAll` est-elle plus rapide dans cet exemple ?

- Car elle permet de faire les appels de manière asynchrone, donc elle ne bloque pas le programme en attendant la
  réponse de chaque appel, elle les fait tous en même temps, et attend la réponse de tous les appels en même temps, ce
  qui réduit le temps d'attente total

21. Une méthode `async` utilise-t-elle toujours un nouveau thread (fil d'éxécution) ?

- Non, une méthode async n'utilise pas forcément un nouveau thread, elle peut utiliser le même thread, mais elle
  libère le thread pendant l'attente de la réponse, ce qui permet d'optimiser les ressources et d'éviter les blocages

22. Que se passe-t-il si une tâche échoue mais que les autres réussissent?

- Si une tâche échoue, elle va tomber sur l'exception mais le reste des tâches vont continuer à s'exécuter

23. Dans une vraie application, que préféreriez-vous ?
    1. Faire échouer toute l’opération si une seule météo échoue.
    2. Afficher les météos disponibles et mettre “météo indisponible” pour les autres.
    3. Réessayer l’appel qui a échoué.
       Il n’y a pas une seule bonne réponse. Cela dépend du besoin métier.

- Je préfére le 2

24. Pourquoi dit-on que l’annulation est coopérative ?

- Car pour annuler une tâche, il faut que la tâche elle même vérifie si une demande d'annulation a été faite, et qu'elle
  accepte de s'arrêter, donc c'est une coopération entre la tâche et le code qui demande l'annulation