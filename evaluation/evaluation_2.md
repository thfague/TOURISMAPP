# Evaluation

## Remarques générales

* Il manque toute la partie documentation.
* Utilisez un package NuGet pour référencer Microsoft.Maps.MapControl.WPF (!)

## Objets 2 : Conception et programmation orientées objets (C#, .NET)

### Documentation

| Critère | Points | Max | Commentaires |
|---------|--------|-----|--------------|
| Je sais concevoir un diagramme de classes qui représente mon application. | 0 | 8 |
| Je sais réaliser un diagramme de paquetages qui illustre bien l'isolation entre les parties de mon application. | 0 | 4 |
| Je sais réaliser un diagramme de séquences qui décrit l'un des processus de mon application. | 0 | 2 | 
| Je sais décrire mes trois diagrammes en mettant en valeur et en justifiant les éléments essentiels. | 0 | 6 |

**Note provisoire** 0/20

### Code

| Critère | Points | Max | Commentaires |
|---------|--------|-----|--------------|
| Je maîtrise les bases de la programmation C# (classes, structures, instances...) | 2 | 2 | OK |  
| Je sais utiliser l'abstraction à bon escient (héritage, interface, polymorphisme). | 0 | 3 | Il n'y a pas d'héritage, pas d'interface. Etoffer votre modèle. |
| Je sais gérer des collections simples (tableaux, listes, ...) | 2 | 2 | OK |
| Je sais gérer des collections avancées (dictionnaires). | 0 | 2 | Vous n'utilisez pas de collection avancée |
| Je sais contrôler l'encapsulation au sein de mon application. | 0 | 5 | Tout est public. |
| Je sais tester mon application. | 0 | 4 | Pas de projet de tests |
| Je sais utiliser LINQ. | 1 | 1 | OK |
| Je sais gérer les évènements. | 0 | 1 | Le métier n'émet pas d'évènement |

**Note provisoire** 5/20

## IHM : Interface Homme-Machine (WAML, WPF)

### Documentation

| Critère | Points | Max | Commentaires |
|---------|--------|-----|--------------|
| Je sais décrire le contexte de mon application pour qu'il soit compréhensible par tout le monde. | 0 | 4 |
| Je sais dessiner des sketchs pour concevoir les fenêtres de mon application. | 0 | 4 |
| Je sais enchaîner mes sketchs au sein d'un storyboard. | 0 | 4 | 
| Je sais concevoir un diagramme de cas d'utilisation qui représente les fonctionnalités de mon application. | 0 | 5 |
| Je sais concevoir une application ergonomique. | 0 | 2 |
| Je sais concevoir une application avec une prise en compte de l'accessibilité. | 0 | 1 |

**Note provisoire** 0/20

### Code

| Critère | Points | Max | Commentaires |
|---------|--------|-----|--------------|
| Je sais choisir mes layouts à bon escient. | 1 | 1 | OK |
| Je sais choisir mes composants à bon escient. | 0.5 | 1 | Les images ne s'affichent pas. Vous devez les inclure en tant que ressource de la DLL. |
| Je sais créer mon propre composant. | 2 | 2 | OK |
| Je sais personnaliser mon application en utilisant des ressources et des styles. | 1 | 2 | Utilisation de styles locaux |
| Je sais utiliser les DataTemplates (locaux et globaux). | 0 | 2 | Pas de datatemplate |
| Je sais intercepter les évènements de la vue. | 2 | 2 | OK |
| Je sais notifier la vue depuis des évènements métier. | 0 | 2 | Le métier n'émet pas d'évènement |
| Je sais gérer le DataBinding sur mon master. | 0 | 1 | Pas de binding sur le master  |
| Je sais gérer le DataBinding sur mon détail. | 1 | 1 | OK |
| Je sais gérer le DataBinding et les Dependency Property sur mes UserControls. | 0 | 2 | N/A |
| Je sais développer un Master/Detail (navigation, liens entre les deux écrans, ...) | 3 | 4 | La navigation semble être bonne mais je n'ai pas pu tout tester (crash sur l'ajout d'un lieu) |

**Note provisoire** 10.5/20

## Projet Tuteuré S2

### Documentation

| Critère | Points | Max | Commentaires |
|---------|--------|-----|--------------|
| Je sais mettre en avant dans mon diagramme de classes la persistance de mon application. | 0 | 2 |
| Je sais mettre en avant dans mon diagramme de classes ma partie personnelle. | 0 | 4 |
| Je sais mettre en avant dans mon diagramme de paquetages la persistance de mon application. | 0 | 4 | 
| Je sais réaliser une vidéo de 1 à 3 minutes qui montre la démo de mon application. | 0 | 10 |

**Note provisoire** 0/20

### Code

| Critère | Points | Max | Commentaires |
|---------|--------|-----|--------------|
| Je sais coder la persitance au sein de mon application. | 1 | 3 | La persistance n'existe pas sur le périmètre du master/detail (juste sur le login) |
| Je sais coder une fonctionnalité qui m'est personnelle. | 0 | 3 | Quelle est votre fonctionnalité personnelle ? |
| Je sais documenter mon code. | 0 | 2 | Votre code n'est pas documenté |
| Je sais utiliser Git. | 2 | 2 | OK |
| Je sais développer une application qui compile. | 0 | 3 | La DLL MS.Map n'est pas référencée convenablement. L'application ne compilait pas lors de la récupération de votre code. |
| Je sais développer une application fonctionnelle. | 2 | 4 | Crash sur la validation de la saisie d'un lieu. |
| Je sais mettre à disposition un outil pour déployer mon application. | 0 | 3 | Pas d'installer |

**Note provisoire** 05/20
